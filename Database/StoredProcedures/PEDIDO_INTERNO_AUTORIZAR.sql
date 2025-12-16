USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[PEDIDO_INTERNO_AUTORIZAR]    Script Date: 15/12/2025 08:56:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PEDIDO_INTERNO_AUTORIZAR]
	-- Add the parameters for the stored procedure here
	@EMPRESA BIGINT,
	@NO_PEDIDO BIGINT,
	@NOTAS_AL_AUTORIZAR NVARCHAR(MAX),
	@USUARIO BIGINT,
	@COMPUTADORA NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DECLARE @TRAN_STARTED BIT
	SET @TRAN_STARTED = 0

        BEGIN TRY

                BEGIN TRANSACTION
                SET @TRAN_STARTED = 1

            -- Cambia el estatus de pedido a autorizado
                UPDATE
                        PEDIDO_INTERNO
                SET
                        Status = 'AUTORIZADO',
                        ObservacionesAlAutorizar = @NOTAS_AL_AUTORIZAR,
                        USUARIOAUTORIZO = @USUARIO,
                        FECHAHORAAUTORIZO = GETDATE(),
                        COMPUTADORAAUTORIZO = @COMPUTADORA
                WHERE
                        Empresa = @EMPRESA
                AND No_Pedido = @NO_PEDIDO

                DECLARE
                        @TIPOPEDIDO AS NVARCHAR(10),
                        @USARINVENTARIODISPONIBLE BIT

                SELECT
                        @TIPOPEDIDO = FA.TipoPedido,
                        @USARINVENTARIODISPONIBLE = ISNULL(PI.UsarInventarioDisponible,0)
                FROM PEDIDO_INTERNO PI
                INNER JOIN FOLIOS_ADMINISTRACION FA
                        ON PI.Empresa = FA.Empresa AND PI.Num_Folio = FA.Num_Folio
                WHERE PI.Empresa = @EMPRESA AND PI.No_Pedido = @NO_PEDIDO

                IF @TIPOPEDIDO = 'N' AND @USARINVENTARIODISPONIBLE = 1
                BEGIN
                        DECLARE @NO_RESERVADO BIGINT

                        SELECT @NO_RESERVADO = ISNULL(MAX(No_Reservado),0)
                        FROM RESERVADO_INVENTARIO_PRODUCTO_TERMINADO
                        WHERE Empresa = @EMPRESA

                        DECLARE @REQUERIMIENTOS TABLE
                        (
                                Partida BIGINT,
                                Cve_Prenda BIGINT,
                                LugarDeEntrega NUMERIC(18,0),
                                Prioridad BIGINT,
                                Talla NVARCHAR(50),
                                CantidadSolicitada BIGINT,
                                CantidadAsignada BIGINT
                        );

                        INSERT INTO @REQUERIMIENTOS
                        (
                                Partida,
                                Cve_Prenda,
                                LugarDeEntrega,
                                Prioridad,
                                Talla,
                                CantidadSolicitada,
                                CantidadAsignada
                        )
                        SELECT
                                PIT.Partida,
                                PIT.Cve_Prenda,
                                PIT.LugarDeEntrega,
                                PIT.Prioridad,
                                PIT.Talla,
                                SUM(CAST(ISNULL(PIT.Cantidad,0) AS BIGINT)) AS CantidadSolicitada,
                                0 AS CantidadAsignada
                        FROM PEDIDO_INTERNO_TALLAS PIT
                        WHERE PIT.Empresa = @EMPRESA
                        AND PIT.No_Pedido = @NO_PEDIDO
                        GROUP BY PIT.Partida, PIT.Cve_Prenda, PIT.LugarDeEntrega, PIT.Prioridad, PIT.Talla;

                        IF EXISTS (SELECT 1 FROM @REQUERIMIENTOS)
                        BEGIN
                                DECLARE @INVENTARIO TABLE
                                (
                                        Cve_Prenda BIGINT,
                                        Talla NVARCHAR(50),
                                        Almacen NVARCHAR(50),
                                        Prioridad INT,
                                        Disponible BIGINT
                                );

                                INSERT INTO @INVENTARIO
                                (
                                        Cve_Prenda,
                                        Talla,
                                        Almacen,
                                        Prioridad,
                                        Disponible
                                )
                                SELECT
                                        PIA.Cve_Prenda,
                                        PIA.Talla,
                                        PIA.Almacen,
                                        CASE
                                                WHEN PIA.Almacen NOT IN ('TEMPORAL SIN OP','TEMPORAL CON OP') THEN 1
                                                WHEN PIA.Almacen = 'TEMPORAL CON OP' THEN 2
                                                ELSE 3
                                        END AS Prioridad,
                                        CAST(ISNULL(PIA.InventarioNoAsignado,0) AS BIGINT) AS Disponible
                                FROM PRENDA_INVENTARIO_ALMACEN PIA
                                INNER JOIN (
                                        SELECT DISTINCT Cve_Prenda, Talla
                                        FROM @REQUERIMIENTOS
                                ) R
                                        ON R.Cve_Prenda = PIA.Cve_Prenda
                                        AND R.Talla = PIA.Talla
                                WHERE PIA.Empresa = @EMPRESA
                                AND ISNULL(PIA.InventarioNoAsignado,0) > 0;

                                DECLARE @MOVIMIENTOS TABLE
                                (
                                        Partida BIGINT,
                                        Cve_Prenda BIGINT,
                                        LugarDeEntrega NUMERIC(18,0),
                                        Prioridad BIGINT,
                                        Talla NVARCHAR(50),
                                        Almacen NVARCHAR(50),
                                        Cantidad BIGINT
                                );

                                DECLARE @ReqPartida BIGINT,
                                        @ReqCvePrenda BIGINT,
                                        @ReqLugar NUMERIC(18,0),
                                        @ReqPrioridad BIGINT,
                                        @ReqTalla NVARCHAR(50),
                                        @ReqCantidad BIGINT;

                                DECLARE REQ_CURSOR CURSOR LOCAL FAST_FORWARD FOR
                                SELECT Partida, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, CantidadSolicitada
                                FROM @REQUERIMIENTOS
                                ORDER BY Partida, Cve_Prenda, Talla;

                                OPEN REQ_CURSOR;

                                FETCH NEXT FROM REQ_CURSOR INTO @ReqPartida, @ReqCvePrenda, @ReqLugar, @ReqPrioridad, @ReqTalla, @ReqCantidad;

                                WHILE @@FETCH_STATUS = 0
                                BEGIN
                                        DECLARE @CantidadRestante BIGINT;
                                        SET @CantidadRestante = @ReqCantidad;

                                        WHILE @CantidadRestante > 0
                                        BEGIN
                                                DECLARE @AlmacenInventario NVARCHAR(50);
                                                DECLARE @DisponibleInventario BIGINT;

                                                SET @AlmacenInventario = NULL;
                                                SET @DisponibleInventario = 0;

                                                SELECT TOP 1
                                                        @AlmacenInventario = I.Almacen,
                                                        @DisponibleInventario = I.Disponible
                                                FROM @INVENTARIO I
                                                WHERE I.Cve_Prenda = @ReqCvePrenda
                                                AND I.Talla = @ReqTalla
                                                AND I.Disponible > 0
                                                ORDER BY I.Prioridad, I.Almacen;

                                                IF @AlmacenInventario IS NULL OR @DisponibleInventario <= 0
                                                BEGIN
                                                        BREAK;
                                                END

                                                DECLARE @CantidadAConsumir BIGINT;
                                                IF @CantidadRestante < @DisponibleInventario
                                                BEGIN
                                                        SET @CantidadAConsumir = @CantidadRestante;
                                                END
                                                ELSE
                                                BEGIN
                                                        SET @CantidadAConsumir = @DisponibleInventario;
                                                END

                                                UPDATE @INVENTARIO
                                                SET Disponible = Disponible - @CantidadAConsumir
                                                WHERE Cve_Prenda = @ReqCvePrenda
                                                AND Talla = @ReqTalla
                                                AND Almacen = @AlmacenInventario;

                                                UPDATE @REQUERIMIENTOS
                                                SET CantidadAsignada = CantidadAsignada + @CantidadAConsumir
                                                WHERE Partida = @ReqPartida
                                                AND Cve_Prenda = @ReqCvePrenda
                                                AND LugarDeEntrega = @ReqLugar
                                                AND Prioridad = @ReqPrioridad
                                                AND Talla = @ReqTalla;

                                                INSERT INTO @MOVIMIENTOS
                                                (
                                                        Partida,
                                                        Cve_Prenda,
                                                        LugarDeEntrega,
                                                        Prioridad,
                                                        Talla,
                                                        Almacen,
                                                        Cantidad
                                                )
                                                VALUES
                                                (
                                                        @ReqPartida,
                                                        @ReqCvePrenda,
                                                        @ReqLugar,
                                                        @ReqPrioridad,
                                                        @ReqTalla,
                                                        @AlmacenInventario,
                                                        @CantidadAConsumir
                                                );

                                                SET @CantidadRestante = @CantidadRestante - @CantidadAConsumir;
                                        END

                                        FETCH NEXT FROM REQ_CURSOR INTO @ReqPartida, @ReqCvePrenda, @ReqLugar, @ReqPrioridad, @ReqTalla, @ReqCantidad;
                                END

                                CLOSE REQ_CURSOR;
                                DEALLOCATE REQ_CURSOR;

                                IF EXISTS (SELECT 1 FROM @REQUERIMIENTOS WHERE CantidadAsignada > 0)
                                BEGIN
                                        SET @NO_RESERVADO = @NO_RESERVADO + 1

                                        INSERT INTO RESERVADO_INVENTARIO_PRODUCTO_TERMINADO
                                        (
                                                Empresa,
                                                No_Reservado,
                                                No_Pedido,
                                                Partida,
                                                Cve_Prenda,
                                                LugarDeEntrega,
                                                Prioridad,
                                                Talla,
                                                Cantidad,
                                                USUARIO,
                                                FECHAHORA,
                                                COMPUTADORA
                                        )
                                        SELECT
                                                @EMPRESA,
                                                @NO_RESERVADO,
                                                @NO_PEDIDO,
                                                R.Partida,
                                                R.Cve_Prenda,
                                                R.LugarDeEntrega,
                                                R.Prioridad,
                                                R.Talla,
                                                R.CantidadAsignada,
                                                @USUARIO,
                                                GETDATE(),
                                                @COMPUTADORA
                                        FROM @REQUERIMIENTOS R
                                        WHERE R.CantidadAsignada > 0;

                                END

                                DECLARE @REQUERIMIENTOS_TEMPORAL TABLE
                                (
                                        Partida BIGINT,
                                        Cve_Prenda BIGINT,
                                        Talla NVARCHAR(50),
                                        Cantidad BIGINT
                                );

                                DECLARE @CONSUMO_OP_DETALLE TABLE
                                (
                                        PartidaDestino BIGINT,
                                        Cve_Prenda BIGINT,
                                        Talla NVARCHAR(50),
                                        No_OP BIGINT NULL,
                                        Cantidad BIGINT,
                                        No_PedidoReferencia BIGINT NULL
                                );

                                IF EXISTS (SELECT 1 FROM @MOVIMIENTOS)
                                BEGIN
                                        INSERT INTO @REQUERIMIENTOS_TEMPORAL
                                        (
                                                Partida,
                                                Cve_Prenda,
                                                Talla,
                                                Cantidad
                                        )
                                        SELECT
                                                M.Partida,
                                                M.Cve_Prenda,
                                                M.Talla,
                                                SUM(M.Cantidad) AS Cantidad
                                        FROM @MOVIMIENTOS M
                                        WHERE M.Almacen = 'TEMPORAL SIN OP'
                                        GROUP BY M.Partida, M.Cve_Prenda, M.Talla;

                                        DECLARE @MOVIMIENTOS_CON_OP TABLE
                                        (
                                                Partida BIGINT,
                                                Cve_Prenda BIGINT,
                                                Talla NVARCHAR(50),
                                                Cantidad BIGINT
                                        );

                                        INSERT INTO @MOVIMIENTOS_CON_OP
                                        (
                                                Partida,
                                                Cve_Prenda,
                                                Talla,
                                                Cantidad
                                        )
                                        SELECT
                                                M.Partida,
                                                M.Cve_Prenda,
                                                M.Talla,
                                                SUM(M.Cantidad) AS Cantidad
                                        FROM @MOVIMIENTOS M
                                        WHERE M.Almacen = 'TEMPORAL CON OP'
                                        GROUP BY M.Partida, M.Cve_Prenda, M.Talla;

                                        IF EXISTS (SELECT 1 FROM @MOVIMIENTOS_CON_OP)
                                        BEGIN
                                                DECLARE @OPPartidaDestino BIGINT;
                                                DECLARE @OPCvePrenda BIGINT;
                                                DECLARE @OPTalla NVARCHAR(50);
                                                DECLARE @OPCantidad BIGINT;

                                                DECLARE CURSOR_MOV_OP CURSOR LOCAL FAST_FORWARD FOR
                                                SELECT Partida, Cve_Prenda, Talla, Cantidad
                                                FROM @MOVIMIENTOS_CON_OP;

                                                OPEN CURSOR_MOV_OP;

                                                FETCH NEXT FROM CURSOR_MOV_OP INTO @OPPartidaDestino, @OPCvePrenda, @OPTalla, @OPCantidad;

                                                WHILE @@FETCH_STATUS = 0
                                                BEGIN
                                                        DECLARE @OPCantidadPendiente BIGINT;
                                                        SET @OPCantidadPendiente = @OPCantidad;

                                                        DECLARE @DetalleNoOP BIGINT;
                                                        DECLARE @DetalleSaldo BIGINT;
                                                        DECLARE @DetallePedidoReferencia BIGINT;

                                                        DECLARE CURSOR_OP_SALDOS CURSOR LOCAL FAST_FORWARD FOR
                                                        SELECT No_OP, CantidadNoAsignada, No_PedidoReferencia
                                                        FROM OP_INVENTARIO_TEMPORAL
                                                        WHERE Empresa = @EMPRESA
                                                        AND Cve_Prenda = @OPCvePrenda
                                                        AND Talla = @OPTalla
                                                        AND CantidadNoAsignada > 0
                                                        ORDER BY FechaUltimaActualizacion, No_OP;

                                                        OPEN CURSOR_OP_SALDOS;

                                                        FETCH NEXT FROM CURSOR_OP_SALDOS INTO @DetalleNoOP, @DetalleSaldo, @DetallePedidoReferencia;

                                                        WHILE @@FETCH_STATUS = 0 AND @OPCantidadPendiente > 0
                                                        BEGIN
                                                                DECLARE @ConsumoActual BIGINT;
                                                                IF @DetalleSaldo >= @OPCantidadPendiente
                                                                BEGIN
                                                                        SET @ConsumoActual = @OPCantidadPendiente;
                                                                END
                                                                ELSE
                                                                BEGIN
                                                                        SET @ConsumoActual = @DetalleSaldo;
                                                                END

                                                                IF @ConsumoActual > 0
                                                                BEGIN
                                                                        INSERT INTO @CONSUMO_OP_DETALLE
                                                                        (
                                                                                PartidaDestino,
                                                                                Cve_Prenda,
                                                                                Talla,
                                                                                No_OP,
                                                                                Cantidad,
                                                                                No_PedidoReferencia
                                                                        )
                                                                        VALUES
                                                                        (
                                                                                @OPPartidaDestino,
                                                                                @OPCvePrenda,
                                                                                @OPTalla,
                                                                                @DetalleNoOP,
                                                                                @ConsumoActual,
                                                                                @DetallePedidoReferencia
                                                                        );

                                                                        SET @OPCantidadPendiente = @OPCantidadPendiente - @ConsumoActual;
                                                                END

                                                                FETCH NEXT FROM CURSOR_OP_SALDOS INTO @DetalleNoOP, @DetalleSaldo, @DetallePedidoReferencia;
                                                        END

                                                        CLOSE CURSOR_OP_SALDOS;
                                                        DEALLOCATE CURSOR_OP_SALDOS;

                                                        IF @OPCantidadPendiente > 0
                                                        BEGIN
                                                                INSERT INTO @CONSUMO_OP_DETALLE
                                                                (
                                                                        PartidaDestino,
                                                                        Cve_Prenda,
                                                                        Talla,
                                                                        No_OP,
                                                                        Cantidad,
                                                                        No_PedidoReferencia
                                                                )
                                                                VALUES
                                                                (
                                                                        @OPPartidaDestino,
                                                                        @OPCvePrenda,
                                                                        @OPTalla,
                                                                        NULL,
                                                                        @OPCantidadPendiente,
                                                                        NULL
                                                                );
                                                        END

                                                        FETCH NEXT FROM CURSOR_MOV_OP INTO @OPPartidaDestino, @OPCvePrenda, @OPTalla, @OPCantidad;
                                                END

                                                CLOSE CURSOR_MOV_OP;
                                                DEALLOCATE CURSOR_MOV_OP;
                                        END

                                        DECLARE @MOVIMIENTOS_AGREGADOS TABLE
                                        (
                                                Cve_Prenda BIGINT,
                                                Talla NVARCHAR(50),
                                                Almacen NVARCHAR(50),
                                                Cantidad BIGINT
                                        );

                                        INSERT INTO @MOVIMIENTOS_AGREGADOS
                                        (
                                                Cve_Prenda,
                                                Talla,
                                                Almacen,
                                                Cantidad
                                        )
                                        SELECT
                                                M.Cve_Prenda,
                                                M.Talla,
                                                M.Almacen,
                                                SUM(M.Cantidad) AS Cantidad
                                        FROM @MOVIMIENTOS M
                                        GROUP BY M.Cve_Prenda, M.Talla, M.Almacen;

                                        DECLARE @MOVIMIENTOS_LIBERADO TABLE
                                        (
                                                Partida BIGINT,
                                                Cve_Prenda BIGINT,
                                                Talla NVARCHAR(50),
                                                Almacen NVARCHAR(50),
                                                Cantidad BIGINT
                                        );

                                        INSERT INTO @MOVIMIENTOS_LIBERADO
                                        (
                                                Partida,
                                                Cve_Prenda,
                                                Talla,
                                                Almacen,
                                                Cantidad
                                        )
                                        SELECT
                                                M.Partida,
                                                M.Cve_Prenda,
                                                M.Talla,
                                                UPPER(RTRIM(LTRIM(M.Almacen))) AS Almacen,
                                                M.Cantidad
                                        FROM @MOVIMIENTOS M
                                        WHERE UPPER(RTRIM(LTRIM(M.Almacen))) IN ('LIBERADO','RECOLECTADO');

                                        DECLARE @LIBERACION_SALDOS TABLE
                                        (
                                                Almacen NVARCHAR(50),
                                                ID_Liberacion UNIQUEIDENTIFIER,
                                                No_OP BIGINT,
                                                Cve_Prenda BIGINT,
                                                Talla NVARCHAR(50),
                                                CantidadDisponible BIGINT,
                                                FechaHora DATETIME,
                                                Cve_Maquilador BIGINT NULL,
                                                Nom_Maquilador NVARCHAR(255) NULL
                                        );

                                        DECLARE @CONSUMO_LIBERADO TABLE
                                        (
                                                PartidaDestino BIGINT,
                                                Cve_Prenda BIGINT,
                                                Talla NVARCHAR(50),
                                                Almacen NVARCHAR(50),
                                                No_OP BIGINT NULL,
                                                Cantidad BIGINT,
                                                Cve_Maquilador BIGINT NULL,
                                                Nom_Maquilador NVARCHAR(255) NULL
                                        );

                                        IF EXISTS (SELECT 1 FROM @MOVIMIENTOS_LIBERADO)
                                        BEGIN
                                                INSERT INTO @LIBERACION_SALDOS
                                                (
                                                        Almacen,
                                                        ID_Liberacion,
                                                        No_OP,
                                                        Cve_Prenda,
                                                        Talla,
                                                        CantidadDisponible,
                                                        FechaHora,
                                                        Cve_Maquilador,
                                                        Nom_Maquilador
                                                )
                                                SELECT
                                                        LOC.AlmacenDestino,
                                                        L.ID_Liberacion,
                                                        CAST(L.No_OP AS BIGINT),
                                                        OPDATA.Cve_Prenda,
                                                        L.Talla,
                                                        LOC.CantidadDestino,
                                                        L.FechaHora,
                                                        CAST(OA.Cve_Maquilador AS BIGINT),
                                                        OA.Nom_Maquilador
                                                FROM OP_LIBERACIONES L
                                                OUTER APPLY
                                                (
                                                        SELECT TOP 1 PIT2.Cve_Prenda
                                                        FROM PEDIDO_INTERNO_TALLAS PIT2
                                                        WHERE PIT2.Empresa = L.Empresa
                                                        AND PIT2.No_OP = L.No_OP
                                                        AND PIT2.Talla = L.Talla
                                                        ORDER BY PIT2.Partida
                                                ) AS OPDATA
                                                CROSS APPLY
                                                (
                                                        SELECT
                                                                CASE
                                                                        WHEN NULLIF(RTRIM(L.AlmacenIngreso),'') IS NULL THEN 'LIBERADO'
                                                                        ELSE UPPER(RTRIM(LTRIM(L.AlmacenIngreso)))
                                                                END AS AlmacenDestino,
                                                                CAST(
                                                                        CASE
                                                                                WHEN UPPER(RTRIM(LTRIM(ISNULL(L.AlmacenIngreso,'')))) = 'RECOLECTADO' THEN ISNULL(L.CantidadRecolectada, ISNULL(L.Cantidad,0))
                                                                                ELSE ISNULL(L.Cantidad,0)
                                                                        END AS BIGINT
                                                                ) AS CantidadDestino
                                                ) AS LOC
                                                LEFT JOIN OP_ASIGNACION OA
                                                        ON OA.Empresa = L.Empresa
                                                        AND OA.No_OP = L.No_OP
                                                WHERE L.Empresa = @EMPRESA
                                                AND OPDATA.Cve_Prenda IS NOT NULL
                                                AND LOC.AlmacenDestino IN ('LIBERADO','RECOLECTADO')
                                                AND LOC.CantidadDestino > 0;

                                                DECLARE @MovPartida BIGINT;
                                                DECLARE @MovCvePrenda BIGINT;
                                                DECLARE @MovTalla NVARCHAR(50);
                                                DECLARE @MovAlmacen NVARCHAR(50);
                                                DECLARE @MovCantidad BIGINT;

                                                DECLARE CURSOR_LIB CURSOR LOCAL FAST_FORWARD FOR
                                                SELECT Partida, Cve_Prenda, Talla, Almacen, Cantidad
                                                FROM @MOVIMIENTOS_LIBERADO;

                                                OPEN CURSOR_LIB;

                                                FETCH NEXT FROM CURSOR_LIB INTO @MovPartida, @MovCvePrenda, @MovTalla, @MovAlmacen, @MovCantidad;

                                                WHILE @@FETCH_STATUS = 0
                                                BEGIN
                                                        DECLARE @CantidadPendiente BIGINT;
                                                        SET @CantidadPendiente = @MovCantidad;

                                                        WHILE @CantidadPendiente > 0
                                                        BEGIN
                                                                DECLARE @FuenteID UNIQUEIDENTIFIER;
                                                                DECLARE @FuenteOP BIGINT;
                                                                DECLARE @FuenteDisponible BIGINT;
                                                                DECLARE @FuenteCveMaq BIGINT;
                                                                DECLARE @FuenteNomMaq NVARCHAR(255);

                                                                SET @FuenteID = NULL;
                                                                SET @FuenteOP = NULL;
                                                                SET @FuenteDisponible = 0;
                                                                SET @FuenteCveMaq = NULL;
                                                                SET @FuenteNomMaq = NULL;

                                                                SELECT TOP 1
                                                                        @FuenteID = LS.ID_Liberacion,
                                                                        @FuenteOP = LS.No_OP,
                                                                        @FuenteDisponible = LS.CantidadDisponible,
                                                                        @FuenteCveMaq = LS.Cve_Maquilador,
                                                                        @FuenteNomMaq = LS.Nom_Maquilador
                                                                FROM @LIBERACION_SALDOS LS
                                                                WHERE LS.Almacen = @MovAlmacen
                                                                AND LS.Cve_Prenda = @MovCvePrenda
                                                                AND LS.Talla = @MovTalla
                                                                AND LS.CantidadDisponible > 0
                                                                ORDER BY LS.FechaHora, LS.No_OP;

                                                                IF @FuenteID IS NULL
                                                                BEGIN
                                                                        INSERT INTO @CONSUMO_LIBERADO
                                                                        (
                                                                                PartidaDestino,
                                                                                Cve_Prenda,
                                                                                Talla,
                                                                                Almacen,
                                                                                No_OP,
                                                                                Cantidad,
                                                                                Cve_Maquilador,
                                                                                Nom_Maquilador
                                                                        )
                                                                        VALUES
                                                                        (
                                                                                @MovPartida,
                                                                                @MovCvePrenda,
                                                                                @MovTalla,
                                                                                @MovAlmacen,
                                                                                NULL,
                                                                                @CantidadPendiente,
                                                                                NULL,
                                                                                NULL
                                                                        );

                                                                        SET @CantidadPendiente = 0;
                                                                END
                                                                ELSE
                                                                BEGIN
                                                                        DECLARE @CantidadAplicarLiberado BIGINT;
                                                                        IF @CantidadPendiente < @FuenteDisponible
                                                                        BEGIN
                                                                                SET @CantidadAplicarLiberado = @CantidadPendiente;
                                                                        END
                                                                        ELSE
                                                                        BEGIN
                                                                                SET @CantidadAplicarLiberado = @FuenteDisponible;
                                                                        END

                                                                        INSERT INTO @CONSUMO_LIBERADO
                                                                        (
                                                                                PartidaDestino,
                                                                                Cve_Prenda,
                                                                                Talla,
                                                                                Almacen,
                                                                                No_OP,
                                                                                Cantidad,
                                                                                Cve_Maquilador,
                                                                                Nom_Maquilador
                                                                        )
                                                                        VALUES
                                                                        (
                                                                                @MovPartida,
                                                                                @MovCvePrenda,
                                                                                @MovTalla,
                                                                                @MovAlmacen,
                                                                                @FuenteOP,
                                                                                @CantidadAplicarLiberado,
                                                                                @FuenteCveMaq,
                                                                                @FuenteNomMaq
                                                                        );

                                                                        UPDATE @LIBERACION_SALDOS
                                                                        SET CantidadDisponible = CantidadDisponible - @CantidadAplicarLiberado
                                                                        WHERE ID_Liberacion = @FuenteID;

                                                                        SET @CantidadPendiente = @CantidadPendiente - @CantidadAplicarLiberado;
                                                                END
                                                        END

                                                        FETCH NEXT FROM CURSOR_LIB INTO @MovPartida, @MovCvePrenda, @MovTalla, @MovAlmacen, @MovCantidad;
                                                END

                                                CLOSE CURSOR_LIB;
                                                DEALLOCATE CURSOR_LIB;
                                        END

                                        UPDATE PIA
                                        SET InventarioNoAsignado = CASE
                                                                            WHEN InventarioNoAsignado >= M.Cantidad THEN InventarioNoAsignado - M.Cantidad
                                                                            ELSE 0
                                                                    END,
                                            InventarioAsignado = InventarioAsignado + M.Cantidad
                                        FROM PRENDA_INVENTARIO_ALMACEN PIA
                                        INNER JOIN @MOVIMIENTOS_AGREGADOS M
                                                ON PIA.Cve_Prenda = M.Cve_Prenda
                                                AND PIA.Talla = M.Talla
                                                AND PIA.Almacen = M.Almacen
                                        WHERE PIA.Empresa = @EMPRESA;

                                        DECLARE @MAX_CONSECUTIVO BIGINT;
                                        SELECT @MAX_CONSECUTIVO = ISNULL(MAX(Consecutivo),0)
                                        FROM PRENDA_INVENTARIO_BITACORA
                                        WHERE Empresa = @EMPRESA
                                        AND No_Pedido = @NO_PEDIDO;

                                        ;WITH MOVS AS
                                        (
                                                SELECT
                                                        M.Cve_Prenda,
                                                        M.Talla,
                                                        M.Almacen,
                                                        M.Cantidad,
                                                        ROW_NUMBER() OVER (ORDER BY M.Almacen, M.Cve_Prenda, M.Talla) AS RN
                                                FROM @MOVIMIENTOS_AGREGADOS M
                                                WHERE UPPER(RTRIM(LTRIM(M.Almacen))) NOT IN ('TEMPORAL CON OP','LIBERADO','RECOLECTADO')
                                        )
                                        INSERT INTO PRENDA_INVENTARIO_BITACORA
                                        (
                                                Empresa,
                                                No_Pedido,
                                                Consecutivo,
                                                Cve_Prenda,
                                                Talla,
                                                TipoMovimiento,
                                                Almacen,
                                                TipoInventario,
                                                No_OP,
                                                Cve_Maquilador,
                                                Nom_Maquilador,
                                                Cantidad,
                                                CantidadAvance,
                                                USUARIO,
                                                FECHAHORA,
                                                COMPUTADORA
                                        )
                                        SELECT
                                                @EMPRESA,
                                                @NO_PEDIDO,
                                                @MAX_CONSECUTIVO + CA.Offset,
                                                MOVS.Cve_Prenda,
                                                MOVS.Talla,
                                                CA.TipoMovimiento,
                                                MOVS.Almacen,
                                                CA.TipoInventario,
                                                NULL,
                                                NULL,
                                                NULL,
                                                MOVS.Cantidad,
                                                0,
                                                @USUARIO,
                                                GETDATE(),
                                                @COMPUTADORA
                                        FROM MOVS
                                        CROSS APPLY
                                        (
                                                VALUES
                                                ('SALIDA', 'Inventario no Asignado', (MOVS.RN * 2) - 1),
                                                ('ENTRADA', 'Inventario Asignado', (MOVS.RN * 2))
                                        ) CA (TipoMovimiento, TipoInventario, Offset);

                                        IF EXISTS (SELECT 1 FROM @CONSUMO_LIBERADO)
                                        BEGIN
                                                SELECT @MAX_CONSECUTIVO = ISNULL(MAX(Consecutivo),0)
                                                FROM PRENDA_INVENTARIO_BITACORA
                                                WHERE Empresa = @EMPRESA
                                                AND No_Pedido = @NO_PEDIDO;

                                                ;WITH DATOS_LIB AS
                                                (
                                                        SELECT
                                                                ROW_NUMBER() OVER (ORDER BY CL.Almacen, CL.Cve_Prenda, CL.Talla, COALESCE(CL.No_OP,0), CL.PartidaDestino) AS RN,
                                                                CL.Cve_Prenda,
                                                                CL.Talla,
                                                                CL.Almacen,
                                                                CL.No_OP,
                                                                CL.Cantidad,
                                                                CL.Cve_Maquilador,
                                                                CL.Nom_Maquilador
                                                        FROM @CONSUMO_LIBERADO CL
                                                )
                                                INSERT INTO PRENDA_INVENTARIO_BITACORA
                                                (
                                                        Empresa,
                                                        No_Pedido,
                                                        Consecutivo,
                                                        Cve_Prenda,
                                                        Talla,
                                                        TipoMovimiento,
                                                        Almacen,
                                                        TipoInventario,
                                                        No_OP,
                                                        Cve_Maquilador,
                                                        Nom_Maquilador,
                                                        Cantidad,
                                                        CantidadAvance,
                                                        USUARIO,
                                                        FECHAHORA,
                                                        COMPUTADORA
                                                )
                                                SELECT
                                                        @EMPRESA,
                                                        @NO_PEDIDO,
                                                        @MAX_CONSECUTIVO + CA.Offset,
                                                        D.Cve_Prenda,
                                                        D.Talla,
                                                        CA.TipoMovimiento,
                                                        D.Almacen,
                                                        CA.TipoInventario,
                                                        D.No_OP,
                                                        D.Cve_Maquilador,
                                                        D.Nom_Maquilador,
                                                        D.Cantidad,
                                                        0,
                                                        @USUARIO,
                                                        GETDATE(),
                                                        @COMPUTADORA
                                                FROM DATOS_LIB D
                                                CROSS APPLY
                                                (
                                                        VALUES
                                                        ('SALIDA', 'Inventario no Asignado', (D.RN * 2) - 1),
                                                        ('ENTRADA', 'Inventario Asignado', (D.RN * 2))
                                                ) CA (TipoMovimiento, TipoInventario, Offset);
                                                DECLARE @CONSUMO_LIBERADO_REFERENCIAS TABLE
                                                (
                                                        PartidaDestino BIGINT,
                                                        Cve_Prenda BIGINT,
                                                        Talla NVARCHAR(50),
                                                        Almacen NVARCHAR(50),
                                                        No_OP BIGINT NULL,
                                                        Cantidad BIGINT,
                                                        No_PedidoReferencia BIGINT NULL
                                                );

                                                INSERT INTO @CONSUMO_LIBERADO_REFERENCIAS
                                                (
                                                        PartidaDestino,
                                                        Cve_Prenda,
                                                        Talla,
                                                        Almacen,
                                                        No_OP,
                                                        Cantidad,
                                                        No_PedidoReferencia
                                                )
                                                SELECT
                                                        CL.PartidaDestino,
                                                        CL.Cve_Prenda,
                                                        CL.Talla,
                                                        CL.Almacen,
                                                        CL.No_OP,
                                                        CL.Cantidad,
                                                        OIT.No_PedidoReferencia
                                                FROM @CONSUMO_LIBERADO CL
                                                LEFT JOIN OP_INVENTARIO_TEMPORAL OIT
                                                        ON OIT.Empresa = @EMPRESA
                                                        AND OIT.No_OP = CL.No_OP
                                                        AND OIT.Cve_Prenda = CL.Cve_Prenda
                                                        AND OIT.Talla = CL.Talla;

                                                IF EXISTS (
                                                        SELECT 1
                                                        FROM @CONSUMO_LIBERADO_REFERENCIAS
                                                        WHERE No_OP IS NOT NULL
                                                        AND Cantidad > 0
                                                )
                                                BEGIN
                                                        UPDATE OIT
                                                        SET
                                                                OIT.CantidadAsignada = CASE
                                                                        WHEN OIT.CantidadAsignada + MOV.CantidadConvertida <= OIT.CantidadOP THEN OIT.CantidadAsignada + MOV.CantidadConvertida
                                                                        ELSE OIT.CantidadOP
                                                                END,
                                                                OIT.CantidadNoAsignada = CASE
                                                                        WHEN OIT.CantidadNoAsignada >= MOV.CantidadConvertida THEN OIT.CantidadNoAsignada - MOV.CantidadConvertida
                                                                        ELSE 0
                                                                END,
                                                                OIT.FechaUltimaActualizacion = GETDATE()
                                                        FROM OP_INVENTARIO_TEMPORAL OIT
                                                        INNER JOIN
                                                        (
                                                                SELECT No_OP, Cve_Prenda, Talla, SUM(Cantidad) AS Cantidad
                                                                FROM @CONSUMO_LIBERADO_REFERENCIAS
                                                                WHERE No_OP IS NOT NULL
                                                                GROUP BY No_OP, Cve_Prenda, Talla
                                                        ) RES
                                                                ON OIT.Empresa = @EMPRESA
                                                                AND OIT.No_OP = RES.No_OP
                                                                AND OIT.Cve_Prenda = RES.Cve_Prenda
                                                                AND OIT.Talla = RES.Talla
                                                        CROSS APPLY
                                                        (
                                                                SELECT CASE
                                                                                WHEN OIT.CantidadNoAsignada >= RES.Cantidad THEN RES.Cantidad
                                                                                ELSE OIT.CantidadNoAsignada
                                                                        END AS CantidadConvertida
                                                        ) MOV;
                                                END

                                                IF EXISTS (
                                                        SELECT 1
                                                        FROM @CONSUMO_LIBERADO_REFERENCIAS
                                                        WHERE No_PedidoReferencia IS NOT NULL
                                                        AND Cantidad > 0
                                                )
                                                BEGIN
                                                        DECLARE @ASIGNACIONES_LIB TABLE
                                                        (
                                                                No_Pedido_Origen BIGINT,
                                                                Partida_Origen BIGINT,
                                                                Partida_Destino BIGINT,
                                                                Cve_Prenda BIGINT,
                                                                Talla NVARCHAR(50),
                                                                CantidadAsignada BIGINT
                                                        );

                                                        DECLARE @RefPedidoLib BIGINT;
                                                        DECLARE @RefPartidaDestinoLib BIGINT;
                                                        DECLARE @RefCvePrendaLib BIGINT;
                                                        DECLARE @RefTallaLib NVARCHAR(50);
                                                        DECLARE @RefCantidadLib BIGINT;

                                                        DECLARE CURSOR_CONSUMO_LIB CURSOR LOCAL FAST_FORWARD FOR
                                                        SELECT No_PedidoReferencia, PartidaDestino, Cve_Prenda, Talla, SUM(Cantidad) AS Cantidad
                                                        FROM @CONSUMO_LIBERADO_REFERENCIAS
                                                        WHERE No_PedidoReferencia IS NOT NULL
                                                        GROUP BY No_PedidoReferencia, PartidaDestino, Cve_Prenda, Talla;

                                                        OPEN CURSOR_CONSUMO_LIB;

                                                        FETCH NEXT FROM CURSOR_CONSUMO_LIB INTO @RefPedidoLib, @RefPartidaDestinoLib, @RefCvePrendaLib, @RefTallaLib, @RefCantidadLib;

                                                        WHILE @@FETCH_STATUS = 0
                                                        BEGIN
                                                                DECLARE @CantidadPendienteLib BIGINT;
                                                                SET @CantidadPendienteLib = @RefCantidadLib;

                                                                DECLARE @OrigenPartidaLib BIGINT;
                                                                DECLARE @OrigenCantRegistradaLib BIGINT;
                                                                DECLARE @OrigenCantAsignadaLib BIGINT;

                                                                DECLARE CURSOR_SALDOS_LIB CURSOR LOCAL FAST_FORWARD FOR
                                                                SELECT Partida_Origen, CantidadRegistrada, CantidadAsignada
                                                                FROM PEDIDO_INTERNO_INVENTARIO_DISPONIBLE
                                                                WHERE Empresa = @EMPRESA
                                                                AND No_Pedido_Origen = @RefPedidoLib
                                                                AND Cve_Prenda = @RefCvePrendaLib
                                                                AND Talla = @RefTallaLib
                                                                AND CantidadRegistrada > CantidadAsignada
                                                                ORDER BY FechaRegistro, Partida_Origen;

                                                                OPEN CURSOR_SALDOS_LIB;

                                                                FETCH NEXT FROM CURSOR_SALDOS_LIB INTO @OrigenPartidaLib, @OrigenCantRegistradaLib, @OrigenCantAsignadaLib;

                                                                WHILE @@FETCH_STATUS = 0 AND @CantidadPendienteLib > 0
                                                                BEGIN
                                                                        DECLARE @DisponibleOrigenLib BIGINT;
                                                                        SET @DisponibleOrigenLib = @OrigenCantRegistradaLib - @OrigenCantAsignadaLib;

                                                                        IF @DisponibleOrigenLib > 0
                                                                        BEGIN
                                                                                DECLARE @CantidadAplicarLib BIGINT;
                                                                                IF @CantidadPendienteLib < @DisponibleOrigenLib
                                                                                BEGIN
                                                                                        SET @CantidadAplicarLib = @CantidadPendienteLib;
                                                                                END
                                                                                ELSE
                                                                                BEGIN
                                                                                        SET @CantidadAplicarLib = @DisponibleOrigenLib;
                                                                                END

                                                                                UPDATE PEDIDO_INTERNO_INVENTARIO_DISPONIBLE
                                                                                SET CantidadAsignada = CantidadAsignada + @CantidadAplicarLib,
                                                                                        FechaUltimaActualizacion = GETDATE(),
                                                                                        UsuarioRegistro = @USUARIO,
                                                                                        ComputadoraRegistro = @COMPUTADORA
                                                                                WHERE Empresa = @EMPRESA
                                                                                AND No_Pedido_Origen = @RefPedidoLib
                                                                                AND Partida_Origen = @OrigenPartidaLib
                                                                                AND Cve_Prenda = @RefCvePrendaLib
                                                                                AND Talla = @RefTallaLib;

                                                                                INSERT INTO @ASIGNACIONES_LIB
                                                                                (
                                                                                        No_Pedido_Origen,
                                                                                        Partida_Origen,
                                                                                        Partida_Destino,
                                                                                        Cve_Prenda,
                                                                                        Talla,
                                                                                        CantidadAsignada
                                                                                )
                                                                                VALUES
                                                                                (
                                                                                        @RefPedidoLib,
                                                                                        @OrigenPartidaLib,
                                                                                        @RefPartidaDestinoLib,
                                                                                        @RefCvePrendaLib,
                                                                                        @RefTallaLib,
                                                                                        @CantidadAplicarLib
                                                                                );

                                                                                SET @CantidadPendienteLib = @CantidadPendienteLib - @CantidadAplicarLib;
                                                                        END

                                                                        FETCH NEXT FROM CURSOR_SALDOS_LIB INTO @OrigenPartidaLib, @OrigenCantRegistradaLib, @OrigenCantAsignadaLib;
                                                                END

                                                                CLOSE CURSOR_SALDOS_LIB;
                                                                DEALLOCATE CURSOR_SALDOS_LIB;

                                                                FETCH NEXT FROM CURSOR_CONSUMO_LIB INTO @RefPedidoLib, @RefPartidaDestinoLib, @RefCvePrendaLib, @RefTallaLib, @RefCantidadLib;
                                                        END

                                                        CLOSE CURSOR_CONSUMO_LIB;
                                                        DEALLOCATE CURSOR_CONSUMO_LIB;

                                                        IF EXISTS (SELECT 1 FROM @ASIGNACIONES_LIB)
                                                        BEGIN
                                                                INSERT INTO PEDIDO_INTERNO_INVENTARIO_APLICACION
                                                                (
                                                                        Empresa,
                                                                        No_Pedido_Origen,
                                                                        Partida_Origen,
                                                                        No_Pedido_Destino,
                                                                        Partida_Destino,
                                                                        Cve_Prenda,
                                                                        Talla,
                                                                        CantidadAsignada,
                                                                        FechaAsignacion,
                                                                        UsuarioAsignacion,
                                                                        ComputadoraAsignacion
                                                                )
                                                                SELECT
                                                                        @EMPRESA,
                                                                        L.No_Pedido_Origen,
                                                                        L.Partida_Origen,
                                                                        @NO_PEDIDO,
                                                                        L.Partida_Destino,
                                                                        L.Cve_Prenda,
                                                                        L.Talla,
                                                                        L.CantidadAsignada,
                                                                        GETDATE(),
                                                                        @USUARIO,
                                                                        @COMPUTADORA
                                                                FROM @ASIGNACIONES_LIB L;
                                                        END
                                                END
                                        END

                                        IF EXISTS (SELECT 1 FROM @CONSUMO_OP_DETALLE)
                                        BEGIN
                                                SELECT @MAX_CONSECUTIVO = ISNULL(MAX(Consecutivo),0)
                                                FROM PRENDA_INVENTARIO_BITACORA
                                                WHERE Empresa = @EMPRESA
                                                AND No_Pedido = @NO_PEDIDO;

                                                ;WITH DATOS_OP AS
                                                (
                                                        SELECT
                                                                ROW_NUMBER() OVER (ORDER BY COD.PartidaDestino, COD.Cve_Prenda, COD.Talla, COD.No_OP) AS RN,
                                                                COD.PartidaDestino,
                                                                COD.Cve_Prenda,
                                                                COD.Talla,
                                                                COD.No_OP,
                                                                COD.Cantidad,
                                                                OA.Cve_Maquilador,
                                                                OA.Nom_Maquilador
                                                        FROM @CONSUMO_OP_DETALLE COD
                                                        LEFT JOIN OP_ASIGNACION OA
                                                                ON OA.Empresa = @EMPRESA
                                                                AND OA.No_OP = COD.No_OP
                                                        WHERE COD.Cantidad > 0
                                                )
                                                INSERT INTO PRENDA_INVENTARIO_BITACORA
                                                (
                                                        Empresa,
                                                        No_Pedido,
                                                        Consecutivo,
                                                        Cve_Prenda,
                                                        Talla,
                                                        TipoMovimiento,
                                                        Almacen,
                                                        TipoInventario,
                                                        No_OP,
                                                        Cve_Maquilador,
                                                        Nom_Maquilador,
                                                        Cantidad,
                                                        CantidadAvance,
                                                        USUARIO,
                                                        FECHAHORA,
                                                        COMPUTADORA
                                                )
                                                SELECT
                                                        @EMPRESA,
                                                        @NO_PEDIDO,
                                                        @MAX_CONSECUTIVO + CA.Offset,
                                                        D.Cve_Prenda,
                                                        D.Talla,
                                                        CA.TipoMovimiento,
                                                        'TEMPORAL CON OP',
                                                        CA.TipoInventario,
                                                        D.No_OP,
                                                        CAST(D.Cve_Maquilador AS BIGINT),
                                                        D.Nom_Maquilador,
                                                        D.Cantidad,
                                                        0,
                                                        @USUARIO,
                                                        GETDATE(),
                                                        @COMPUTADORA
                                                FROM DATOS_OP D
                                                CROSS APPLY
                                                (
                                                        VALUES
                                                        ('SALIDA', 'Inventario no Asignado', (D.RN * 2) - 1),
                                                        ('ENTRADA', 'Inventario Asignado', (D.RN * 2))
                                                ) CA (TipoMovimiento, TipoInventario, Offset);
                                        END
                                END

                                DECLARE @SALDO_NO_RESERVADO TABLE
                                (
                                        Cve_Prenda BIGINT,
                                        Talla NVARCHAR(50),
                                        Cantidad BIGINT
                                );

                                INSERT INTO @SALDO_NO_RESERVADO
                                (
                                        Cve_Prenda,
                                        Talla,
                                        Cantidad
                                )
                                SELECT
                                        R.Cve_Prenda,
                                        R.Talla,
                                        SUM(R.CantidadSolicitada - R.CantidadAsignada) AS Cantidad
                                FROM @REQUERIMIENTOS R
                                WHERE R.CantidadSolicitada > R.CantidadAsignada
                                GROUP BY R.Cve_Prenda, R.Talla;

                                IF EXISTS (SELECT 1 FROM @SALDO_NO_RESERVADO)
                                BEGIN
                                        MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
                                        USING @SALDO_NO_RESERVADO AS SRC
                                                ON TARGET.Empresa = @EMPRESA
                                                AND TARGET.Cve_Prenda = SRC.Cve_Prenda
                                                AND TARGET.Talla = SRC.Talla
                                                AND TARGET.Almacen = 'TEMPORAL SIN OP'
                                        WHEN MATCHED THEN
                                                UPDATE SET TARGET.InventarioAsignado = TARGET.InventarioAsignado + SRC.Cantidad
                                        WHEN NOT MATCHED THEN
                                                INSERT
                                                (
                                                        Empresa,
                                                        Cve_Prenda,
                                                        Almacen,
                                                        Talla,
                                                        InventarioNoAsignado,
                                                        InventarioAsignado
                                                )
                                                VALUES
                                                (
                                                        @EMPRESA,
                                                        SRC.Cve_Prenda,
                                                        'TEMPORAL SIN OP',
                                                        SRC.Talla,
                                                        0,
                                                        SRC.Cantidad
                                                );

                                        DECLARE @MAX_CONSECUTIVO_SALDO BIGINT;
                                        SELECT @MAX_CONSECUTIVO_SALDO = ISNULL(MAX(Consecutivo),0)
                                        FROM PRENDA_INVENTARIO_BITACORA
                                        WHERE Empresa = @EMPRESA
                                        AND No_Pedido = @NO_PEDIDO;

                                        ;WITH SALDOS AS
                                        (
                                                SELECT
                                                        S.Cve_Prenda,
                                                        S.Talla,
                                                        S.Cantidad,
                                                        ROW_NUMBER() OVER (ORDER BY S.Cve_Prenda, S.Talla) AS RN
                                                FROM @SALDO_NO_RESERVADO S
                                        )
                                        INSERT INTO PRENDA_INVENTARIO_BITACORA
                                        (
                                                Empresa,
                                                No_Pedido,
                                                Consecutivo,
                                                Cve_Prenda,
                                                Talla,
                                                TipoMovimiento,
                                                Almacen,
                                                TipoInventario,
                                                No_OP,
                                                Cve_Maquilador,
                                                Nom_Maquilador,
                                                Cantidad,
                                                CantidadAvance,
                                                USUARIO,
                                                FECHAHORA,
                                                COMPUTADORA
                                        )
                                        SELECT
                                                @EMPRESA,
                                                @NO_PEDIDO,
                                                @MAX_CONSECUTIVO_SALDO + SALDOS.RN,
                                                SALDOS.Cve_Prenda,
                                                SALDOS.Talla,
                                                'ENTRADA',
                                                'TEMPORAL SIN OP',
                                                'Inventario Asignado',
                                                NULL,
                                                NULL,
                                                NULL,
                                                SALDOS.Cantidad,
                                                0,
                                                @USUARIO,
                                                GETDATE(),
                                                @COMPUTADORA
                                        FROM SALDOS;
                                END

                                IF EXISTS (SELECT 1 FROM @REQUERIMIENTOS_TEMPORAL)
                                BEGIN
                                        DECLARE @ASIGNACIONES TABLE
                                        (
                                                No_Pedido_Origen BIGINT,
                                                Partida_Origen BIGINT,
                                                Partida_Destino BIGINT,
                                                Cve_Prenda BIGINT,
                                                Talla NVARCHAR(50),
                                                CantidadAsignada BIGINT
                                        );

                                        DECLARE @ReqTempPartida BIGINT,
                                                @ReqTempCvePrenda BIGINT,
                                                @ReqTempTalla NVARCHAR(50),
                                                @ReqTempCantidad BIGINT;

                                        DECLARE TEMP_CURSOR CURSOR LOCAL FAST_FORWARD FOR
                                        SELECT Partida, Cve_Prenda, Talla, Cantidad
                                        FROM @REQUERIMIENTOS_TEMPORAL;

                                        OPEN TEMP_CURSOR;

                                        FETCH NEXT FROM TEMP_CURSOR INTO @ReqTempPartida, @ReqTempCvePrenda, @ReqTempTalla, @ReqTempCantidad;

                                        WHILE @@FETCH_STATUS = 0
                                        BEGIN
                                                DECLARE @CantidadRestanteTemp BIGINT;
                                                SET @CantidadRestanteTemp = @ReqTempCantidad;

                                                WHILE @CantidadRestanteTemp > 0
                                                BEGIN
                                                        DECLARE @PedidoOrigen BIGINT;
                                                        DECLARE @PartidaOrigen BIGINT;
                                                        DECLARE @CantidadDisponible BIGINT;

                                                        SET @PedidoOrigen = NULL;
                                                        SET @PartidaOrigen = NULL;
                                                        SET @CantidadDisponible = 0;

                                                        SELECT TOP 1
                                                                @PedidoOrigen = PID.No_Pedido_Origen,
                                                                @PartidaOrigen = PID.Partida_Origen,
                                                                @CantidadDisponible = PID.CantidadRegistrada - PID.CantidadAsignada
                                                        FROM PEDIDO_INTERNO_INVENTARIO_DISPONIBLE PID
                                                        WHERE PID.Empresa = @EMPRESA
                                                        AND PID.Cve_Prenda = @ReqTempCvePrenda
                                                        AND PID.Talla = @ReqTempTalla
                                                        AND PID.CantidadRegistrada > PID.CantidadAsignada
                                                        ORDER BY PID.FechaRegistro, PID.No_Pedido_Origen, PID.Partida_Origen;

                                                        IF @PedidoOrigen IS NULL
                                                        BEGIN
                                                                BREAK;
                                                        END

                                                        DECLARE @CantidadConsumirTemp BIGINT;
                                                        IF @CantidadRestanteTemp < @CantidadDisponible
                                                        BEGIN
                                                                SET @CantidadConsumirTemp = @CantidadRestanteTemp;
                                                        END
                                                        ELSE
                                                        BEGIN
                                                                SET @CantidadConsumirTemp = @CantidadDisponible;
                                                        END

                                                        UPDATE PEDIDO_INTERNO_INVENTARIO_DISPONIBLE
                                                        SET CantidadAsignada = CantidadAsignada + @CantidadConsumirTemp,
                                                                FechaUltimaActualizacion = GETDATE(),
                                                                UsuarioRegistro = @USUARIO,
                                                                ComputadoraRegistro = @COMPUTADORA
                                                        WHERE Empresa = @EMPRESA
                                                        AND No_Pedido_Origen = @PedidoOrigen
                                                        AND Partida_Origen = @PartidaOrigen
                                                        AND Cve_Prenda = @ReqTempCvePrenda
                                                        AND Talla = @ReqTempTalla;

                                                        INSERT INTO @ASIGNACIONES
                                                        (
                                                                No_Pedido_Origen,
                                                                Partida_Origen,
                                                                Partida_Destino,
                                                                Cve_Prenda,
                                                                Talla,
                                                                CantidadAsignada
                                                        )
                                                        VALUES
                                                        (
                                                                @PedidoOrigen,
                                                                @PartidaOrigen,
                                                                @ReqTempPartida,
                                                                @ReqTempCvePrenda,
                                                                @ReqTempTalla,
                                                                @CantidadConsumirTemp
                                                        );

                                                        SET @CantidadRestanteTemp = @CantidadRestanteTemp - @CantidadConsumirTemp;
                                                END

                                                FETCH NEXT FROM TEMP_CURSOR INTO @ReqTempPartida, @ReqTempCvePrenda, @ReqTempTalla, @ReqTempCantidad;
                                        END

                                        CLOSE TEMP_CURSOR;
                                        DEALLOCATE TEMP_CURSOR;

                                        IF EXISTS (SELECT 1 FROM @ASIGNACIONES)
                                        BEGIN
                                                INSERT INTO PEDIDO_INTERNO_INVENTARIO_APLICACION
                                                (
                                                        Empresa,
                                                        No_Pedido_Origen,
                                                        Partida_Origen,
                                                        No_Pedido_Destino,
                                                        Partida_Destino,
                                                        Cve_Prenda,
                                                        Talla,
                                                        CantidadAsignada,
                                                        FechaAsignacion,
                                                        UsuarioAsignacion,
                                                        ComputadoraAsignacion
                                                )
                                                SELECT
                                                        @EMPRESA,
                                                        A.No_Pedido_Origen,
                                                        A.Partida_Origen,
                                                        @NO_PEDIDO,
                                                        A.Partida_Destino,
                                                        A.Cve_Prenda,
                                                        A.Talla,
                                                        A.CantidadAsignada,
                                                        GETDATE(),
                                                        @USUARIO,
                                                        @COMPUTADORA
                                                FROM @ASIGNACIONES A;
                                        END
                                END

                                IF EXISTS (SELECT 1 FROM @CONSUMO_OP_DETALLE)
                                BEGIN
                                        IF EXISTS (SELECT 1 FROM @CONSUMO_OP_DETALLE WHERE No_OP IS NOT NULL)
                                        BEGIN
                                               UPDATE OIT
                                               SET
                                                       OIT.CantidadAsignada = CASE
                                                                                       WHEN OIT.CantidadAsignada + MOV.CantidadConvertida <= OIT.CantidadOP THEN OIT.CantidadAsignada + MOV.CantidadConvertida
                                                                                       ELSE OIT.CantidadOP
                                                                               END,
                                                       OIT.CantidadNoAsignada = CASE
                                                                                       WHEN OIT.CantidadNoAsignada >= MOV.CantidadConvertida THEN OIT.CantidadNoAsignada - MOV.CantidadConvertida
                                                                                       ELSE 0
                                                                               END,
                                                       OIT.FechaUltimaActualizacion = GETDATE()
                                               FROM OP_INVENTARIO_TEMPORAL OIT
                                               INNER JOIN
                                               (
                                                       SELECT No_OP, Cve_Prenda, Talla, SUM(Cantidad) AS Cantidad
                                                       FROM @CONSUMO_OP_DETALLE
                                                       WHERE No_OP IS NOT NULL
                                                       GROUP BY No_OP, Cve_Prenda, Talla
                                               ) OP_SUM
                                                       ON OIT.Empresa = @EMPRESA
                                                       AND OIT.No_OP = OP_SUM.No_OP
                                                       AND OIT.Cve_Prenda = OP_SUM.Cve_Prenda
                                                       AND OIT.Talla = OP_SUM.Talla
                                               CROSS APPLY
                                               (
                                                       SELECT CASE
                                                                       WHEN OIT.CantidadNoAsignada >= OP_SUM.Cantidad THEN OP_SUM.Cantidad
                                                                       ELSE OIT.CantidadNoAsignada
                                                               END AS CantidadConvertida
                                               ) MOV;
                                        END

                                        IF EXISTS (SELECT 1 FROM @CONSUMO_OP_DETALLE WHERE No_PedidoReferencia IS NOT NULL)
                                        BEGIN
                                                DECLARE @ASIGNACIONES_OP TABLE
                                                (
                                                        No_Pedido_Origen BIGINT,
                                                        Partida_Origen BIGINT,
                                                        Partida_Destino BIGINT,
                                                        Cve_Prenda BIGINT,
                                                        Talla NVARCHAR(50),
                                                        CantidadAsignada BIGINT
                                                );

                                                DECLARE @RefPedido BIGINT;
                                                DECLARE @RefPartidaDestino BIGINT;
                                                DECLARE @RefCvePrenda BIGINT;
                                                DECLARE @RefTalla NVARCHAR(50);
                                                DECLARE @RefCantidad BIGINT;

                                                DECLARE CURSOR_CONSUMO_OP CURSOR LOCAL FAST_FORWARD FOR
                                                SELECT No_PedidoReferencia, PartidaDestino, Cve_Prenda, Talla, SUM(Cantidad) AS Cantidad
                                                FROM @CONSUMO_OP_DETALLE
                                                WHERE No_PedidoReferencia IS NOT NULL
                                                GROUP BY No_PedidoReferencia, PartidaDestino, Cve_Prenda, Talla;

                                                OPEN CURSOR_CONSUMO_OP;

                                                FETCH NEXT FROM CURSOR_CONSUMO_OP INTO @RefPedido, @RefPartidaDestino, @RefCvePrenda, @RefTalla, @RefCantidad;

                                                WHILE @@FETCH_STATUS = 0
                                                BEGIN
                                                        DECLARE @CantidadPendienteRef BIGINT;
                                                        SET @CantidadPendienteRef = @RefCantidad;

                                                        DECLARE @OrigenPartida BIGINT;
                                                        DECLARE @OrigenCantRegistrada BIGINT;
                                                        DECLARE @OrigenCantAsignada BIGINT;

                                                        DECLARE CURSOR_SALDOS_ORIGEN CURSOR LOCAL FAST_FORWARD FOR
                                                        SELECT Partida_Origen, CantidadRegistrada, CantidadAsignada
                                                        FROM PEDIDO_INTERNO_INVENTARIO_DISPONIBLE
                                                        WHERE Empresa = @EMPRESA
                                                        AND No_Pedido_Origen = @RefPedido
                                                        AND Cve_Prenda = @RefCvePrenda
                                                        AND Talla = @RefTalla
                                                        AND CantidadRegistrada > CantidadAsignada
                                                        ORDER BY FechaRegistro, Partida_Origen;

                                                        OPEN CURSOR_SALDOS_ORIGEN;

                                                        FETCH NEXT FROM CURSOR_SALDOS_ORIGEN INTO @OrigenPartida, @OrigenCantRegistrada, @OrigenCantAsignada;

                                                        WHILE @@FETCH_STATUS = 0 AND @CantidadPendienteRef > 0
                                                        BEGIN
                                                                DECLARE @DisponibleOrigen BIGINT;
                                                                SET @DisponibleOrigen = @OrigenCantRegistrada - @OrigenCantAsignada;

                                                                IF @DisponibleOrigen > 0
                                                                BEGIN
                                                                        DECLARE @CantidadAplicar BIGINT;
                                                                        IF @CantidadPendienteRef < @DisponibleOrigen
                                                                        BEGIN
                                                                                SET @CantidadAplicar = @CantidadPendienteRef;
                                                                        END
                                                                        ELSE
                                                                        BEGIN
                                                                                SET @CantidadAplicar = @DisponibleOrigen;
                                                                        END

                                                                        UPDATE PEDIDO_INTERNO_INVENTARIO_DISPONIBLE
                                                                        SET CantidadAsignada = CantidadAsignada + @CantidadAplicar,
                                                                                FechaUltimaActualizacion = GETDATE(),
                                                                                UsuarioRegistro = @USUARIO,
                                                                                ComputadoraRegistro = @COMPUTADORA
                                                                        WHERE Empresa = @EMPRESA
                                                                        AND No_Pedido_Origen = @RefPedido
                                                                        AND Partida_Origen = @OrigenPartida
                                                                        AND Cve_Prenda = @RefCvePrenda
                                                                        AND Talla = @RefTalla;

                                                                        INSERT INTO @ASIGNACIONES_OP
                                                                        (
                                                                                No_Pedido_Origen,
                                                                                Partida_Origen,
                                                                                Partida_Destino,
                                                                                Cve_Prenda,
                                                                                Talla,
                                                                                CantidadAsignada
                                                                        )
                                                                        VALUES
                                                                        (
                                                                                @RefPedido,
                                                                                @OrigenPartida,
                                                                                @RefPartidaDestino,
                                                                                @RefCvePrenda,
                                                                                @RefTalla,
                                                                                @CantidadAplicar
                                                                        );

                                                                        SET @CantidadPendienteRef = @CantidadPendienteRef - @CantidadAplicar;
                                                                END

                                                                FETCH NEXT FROM CURSOR_SALDOS_ORIGEN INTO @OrigenPartida, @OrigenCantRegistrada, @OrigenCantAsignada;
                                                        END

                                                        CLOSE CURSOR_SALDOS_ORIGEN;
                                                        DEALLOCATE CURSOR_SALDOS_ORIGEN;

                                                        FETCH NEXT FROM CURSOR_CONSUMO_OP INTO @RefPedido, @RefPartidaDestino, @RefCvePrenda, @RefTalla, @RefCantidad;
                                                END

                                                CLOSE CURSOR_CONSUMO_OP;
                                                DEALLOCATE CURSOR_CONSUMO_OP;

                                                IF EXISTS (SELECT 1 FROM @ASIGNACIONES_OP)
                                                BEGIN
                                                        INSERT INTO PEDIDO_INTERNO_INVENTARIO_APLICACION
                                                        (
                                                                Empresa,
                                                                No_Pedido_Origen,
                                                                Partida_Origen,
                                                                No_Pedido_Destino,
                                                                Partida_Destino,
                                                                Cve_Prenda,
                                                                Talla,
                                                                CantidadAsignada,
                                                                FechaAsignacion,
                                                                UsuarioAsignacion,
                                                                ComputadoraAsignacion
                                                        )
                                                        SELECT
                                                                @EMPRESA,
                                                                A.No_Pedido_Origen,
                                                                A.Partida_Origen,
                                                                @NO_PEDIDO,
                                                                A.Partida_Destino,
                                                                A.Cve_Prenda,
                                                                A.Talla,
                                                                A.CantidadAsignada,
                                                                GETDATE(),
                                                                @USUARIO,
                                                                @COMPUTADORA
                                                        FROM @ASIGNACIONES_OP A;
                                                END
                                        END
                                END
                        END
                END

                IF @USARINVENTARIODISPONIBLE = 0
                BEGIN
                        DECLARE @TOTAL_PEDIDO TABLE
                        (
                                Partida BIGINT,
                                Cve_Prenda BIGINT,
                                Talla NVARCHAR(50),
                                Cantidad BIGINT
                        );

                        INSERT INTO @TOTAL_PEDIDO
                        (
                                Partida,
                                Cve_Prenda,
                                Talla,
                                Cantidad
                        )
                        SELECT
                                PIT.Partida,
                                PIT.Cve_Prenda,
                                PIT.Talla,
                                SUM(CAST(ISNULL(PIT.Cantidad,0) AS BIGINT)) AS Cantidad
                        FROM PEDIDO_INTERNO_TALLAS PIT
                        WHERE PIT.Empresa = @EMPRESA
                        AND PIT.No_Pedido = @NO_PEDIDO
                        GROUP BY PIT.Partida, PIT.Cve_Prenda, PIT.Talla;

                        IF EXISTS (SELECT 1 FROM @TOTAL_PEDIDO)
                        BEGIN
                                MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
                                USING
                                (
                                        SELECT
                                                Cve_Prenda,
                                                Talla,
                                                SUM(Cantidad) AS Cantidad
                                        FROM @TOTAL_PEDIDO
                                        GROUP BY Cve_Prenda, Talla
                                ) AS SRC
                                        ON TARGET.Empresa = @EMPRESA
                                        AND TARGET.Cve_Prenda = SRC.Cve_Prenda
                                        AND TARGET.Talla = SRC.Talla
                                        AND TARGET.Almacen = 'TEMPORAL SIN OP'
                                WHEN MATCHED THEN
                                        UPDATE SET TARGET.InventarioNoAsignado = TARGET.InventarioNoAsignado + SRC.Cantidad
                                WHEN NOT MATCHED THEN
                                        INSERT
                                        (
                                                Empresa,
                                                Cve_Prenda,
                                                Almacen,
                                                Talla,
                                                InventarioNoAsignado,
                                                InventarioAsignado
                                        )
                                        VALUES
                                        (
                                                @EMPRESA,
                                                SRC.Cve_Prenda,
                                                'TEMPORAL SIN OP',
                                                SRC.Talla,
                                                SRC.Cantidad,
                                                0
                                        );

                                MERGE PEDIDO_INTERNO_INVENTARIO_DISPONIBLE AS TARGET
                                USING
                                (
                                        SELECT
                                                Partida,
                                                Cve_Prenda,
                                                Talla,
                                                Cantidad
                                        FROM @TOTAL_PEDIDO
                                ) AS SRC
                                        ON TARGET.Empresa = @EMPRESA
                                        AND TARGET.No_Pedido_Origen = @NO_PEDIDO
                                        AND TARGET.Partida_Origen = SRC.Partida
                                        AND TARGET.Cve_Prenda = SRC.Cve_Prenda
                                        AND TARGET.Talla = SRC.Talla
                                WHEN MATCHED THEN
                                        UPDATE SET
                                                TARGET.CantidadRegistrada = SRC.Cantidad,
                                                TARGET.CantidadAsignada = CASE
                                                                                WHEN TARGET.CantidadAsignada > SRC.Cantidad THEN SRC.Cantidad
                                                                                ELSE TARGET.CantidadAsignada
                                                                        END,
                                                TARGET.FechaUltimaActualizacion = GETDATE(),
                                                TARGET.UsuarioRegistro = @USUARIO,
                                                TARGET.ComputadoraRegistro = @COMPUTADORA
                                WHEN NOT MATCHED THEN
                                        INSERT
                                        (
                                                Empresa,
                                                No_Pedido_Origen,
                                                Partida_Origen,
                                                Cve_Prenda,
                                                Talla,
                                                CantidadRegistrada,
                                                CantidadAsignada,
                                                FechaRegistro,
                                                UsuarioRegistro,
                                                ComputadoraRegistro,
                                                FechaUltimaActualizacion
                                        )
                                        VALUES
                                        (
                                                @EMPRESA,
                                                @NO_PEDIDO,
                                                SRC.Partida,
                                                SRC.Cve_Prenda,
                                                SRC.Talla,
                                                SRC.Cantidad,
                                                0,
                                                GETDATE(),
                                                @USUARIO,
                                                @COMPUTADORA,
                                                GETDATE()
                                        );

                                DECLARE @MAX_CONSECUTIVO_ENTRADA BIGINT;
                                SELECT @MAX_CONSECUTIVO_ENTRADA = ISNULL(MAX(Consecutivo),0)
                                FROM PRENDA_INVENTARIO_BITACORA
                                WHERE Empresa = @EMPRESA
                                AND No_Pedido = @NO_PEDIDO;

                                ;WITH TOTAL_AGREGADO AS
                                (
                                        SELECT
                                                Cve_Prenda,
                                                Talla,
                                                SUM(Cantidad) AS Cantidad
                                        FROM @TOTAL_PEDIDO
                                        GROUP BY Cve_Prenda, Talla
                                ),
                                MOVIMIENTOS AS
                                (
                                        SELECT
                                                TA.Cve_Prenda,
                                                TA.Talla,
                                                TA.Cantidad,
                                                ROW_NUMBER() OVER (ORDER BY TA.Cve_Prenda, TA.Talla) AS RN
                                        FROM TOTAL_AGREGADO TA
                                )
                                INSERT INTO PRENDA_INVENTARIO_BITACORA
                                (
                                        Empresa,
                                        No_Pedido,
                                        Consecutivo,
                                        Cve_Prenda,
                                        Talla,
                                        TipoMovimiento,
                                        Almacen,
                                        TipoInventario,
                                        No_OP,
                                        Cve_Maquilador,
                                        Nom_Maquilador,
                                        Cantidad,
                                        CantidadAvance,
                                        USUARIO,
                                        FECHAHORA,
                                        COMPUTADORA
                                )
                                SELECT
                                        @EMPRESA,
                                        @NO_PEDIDO,
                                        @MAX_CONSECUTIVO_ENTRADA + M.RN,
                                        M.Cve_Prenda,
                                        M.Talla,
                                        'ENTRADA',
                                        'TEMPORAL SIN OP',
                                        'Inventario no Asignado',
                                        NULL,
                                        NULL,
                                        NULL,
                                        M.Cantidad,
                                        0,
                                        @USUARIO,
                                        GETDATE(),
                                        @COMPUTADORA
                                FROM MOVIMIENTOS M;
                        END
                END

        IF @TIPOPEDIDO NOT IN ('C','L')
        BEGIN
            --Explosiona pedido
            --EXEC SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA @EMPRESA,@NO_PEDIDO
            PRINT 'SE EXPLOSIONA'
        END

		COMMIT TRANSACTION
                SET @TRAN_STARTED = 0

        END TRY

        BEGIN CATCH

                IF @TRAN_STARTED = 1
                BEGIN
                        ROLLBACK TRANSACTION
                END

                DECLARE @ERROR_MESSAGE NVARCHAR(4000)
                DECLARE @ERROR_SEVERITY INT
                DECLARE @ERROR_STATE INT

                SELECT @ERROR_MESSAGE = ERROR_MESSAGE(),
                           @ERROR_SEVERITY = ERROR_SEVERITY(),
                           @ERROR_STATE = ERROR_STATE()

                RAISERROR(@ERROR_MESSAGE, @ERROR_SEVERITY, @ERROR_STATE)

        END CATCH
END
GO

