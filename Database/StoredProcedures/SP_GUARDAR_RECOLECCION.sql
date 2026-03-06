USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_RECOLECCION]    Script Date: 05/03/2026 06:08:51 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GUARDAR_RECOLECCION]
    @EMPRESA INT,
    @XML_RECOLECCION XML
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_Liberacion UNIQUEIDENTIFIER;
    DECLARE @USUARIO INT;
    DECLARE @COMPUTADORA NVARCHAR(50);
    DECLARE @ALMACEN NVARCHAR(50);
    DECLARE @NO_OP NUMERIC(18,0);
    DECLARE @FECHA DATETIME = GETDATE();

    SELECT @ID_Liberacion = X.R.value('@ID_Liberacion','uniqueidentifier'),
           @USUARIO = X.R.value('@Usuario','int'),
           @COMPUTADORA = X.R.value('@Computadora','nvarchar(50)'),
           @ALMACEN = X.R.value('@Almacen','nvarchar(50)')
    FROM @XML_RECOLECCION.nodes('/Recoleccion') AS X(R);

    IF @ID_Liberacion IS NULL
    BEGIN
        RETURN;
    END;

    DECLARE @DETALLE_XML TABLE
    (
        Talla NVARCHAR(50),
        Cantidad BIGINT
    );

    INSERT INTO @DETALLE_XML (Talla, Cantidad)
    SELECT
        UPPER(LTRIM(RTRIM(D.value('@Talla','nvarchar(50)')))) AS Talla,
        ISNULL(D.value('@Cantidad','bigint'),0) AS Cantidad
    FROM @XML_RECOLECCION.nodes('/Recoleccion/Detalle') AS X(D)
    WHERE D.value('@Talla','nvarchar(50)') IS NOT NULL;

    IF NOT EXISTS (SELECT 1 FROM @DETALLE_XML)
    BEGIN
        RETURN;
    END;

    DECLARE @DETALLE TABLE
    (
        No_OP BIGINT,
        Cve_Prenda BIGINT,
        Talla NVARCHAR(50),
        CantidadLiberadaDetalle BIGINT,
        CantidadNueva BIGINT,
        CantidadAnterior BIGINT,
        CantidadLiberadaActual BIGINT,
        CantidadAsignada BIGINT,
        CantidadNoAsignada BIGINT,
        SaldoLiberadoAsignado BIGINT,
        SaldoLiberadoNoAsignado BIGINT,
        CantidadRecolectadaActual BIGINT,
        SaldoRecolectadoAsignado BIGINT,
        SaldoRecolectadoNoAsignado BIGINT,
        InventarioTemporalAsignado BIGINT,
        InventarioTemporalNoAsignado BIGINT,
        No_PedidoReferencia BIGINT
    );

    INSERT INTO @DETALLE
    (
        No_OP,
        Cve_Prenda,
        Talla,
        CantidadLiberadaDetalle,
        CantidadNueva,
        CantidadAnterior,
        CantidadLiberadaActual,
        CantidadAsignada,
        CantidadNoAsignada,
        SaldoLiberadoAsignado,
        SaldoLiberadoNoAsignado,
        CantidadRecolectadaActual,
        SaldoRecolectadoAsignado,
        SaldoRecolectadoNoAsignado,
        InventarioTemporalAsignado,
        InventarioTemporalNoAsignado,
        No_PedidoReferencia
    )
    SELECT
        L.No_OP,
        OIT.Cve_Prenda,
        UPPER(OIT.Talla) AS Talla,
        ISNULL(L.Cantidad,0) AS CantidadLiberadaDetalle,
        DX.Cantidad AS CantidadNueva,
        ISNULL(L.CantidadRecolectada,0) AS CantidadAnterior,
        ISNULL(OIT.CantidadLiberada,0) AS CantidadLiberadaActual,
        ISNULL(OIT.CantidadAsignada,0) AS CantidadAsignada,
        ISNULL(OIT.CantidadNoAsignada,0) AS CantidadNoAsignada,
        ISNULL(OIT.SaldoLiberadoAsignado,0) AS SaldoLiberadoAsignado,
        ISNULL(OIT.SaldoLiberadoNoAsignado,0) AS SaldoLiberadoNoAsignado,
        ISNULL(OIT.CantidadRecolectada,0) AS CantidadRecolectadaActual,
        ISNULL(OIT.SaldoRecolectadoAsignado,0) AS SaldoRecolectadoAsignado,
        ISNULL(OIT.SaldoRecolectadoNoAsignado,0) AS SaldoRecolectadoNoAsignado,
        ISNULL(PIA.InventarioAsignado,0) AS InventarioTemporalAsignado,
        ISNULL(PIA.InventarioNoAsignado,0) AS InventarioTemporalNoAsignado,
        OIT.No_PedidoReferencia
    FROM OP_LIBERACIONES L
    INNER JOIN @DETALLE_XML DX
            ON UPPER(L.Talla) = DX.Talla
           AND L.ID_Liberacion = @ID_Liberacion
           AND L.Empresa = @EMPRESA
    INNER JOIN OP_INVENTARIO_TEMPORAL OIT
            ON OIT.Empresa = @EMPRESA
           AND OIT.No_OP = L.No_OP
           AND UPPER(OIT.Talla) = UPPER(L.Talla)
    OUTER APPLY (
        SELECT
            IA.InventarioAsignado,
            IA.InventarioNoAsignado
        FROM PRENDA_INVENTARIO_ALMACEN IA
        WHERE IA.Empresa = @EMPRESA
          AND IA.Cve_Prenda = OIT.Cve_Prenda
          AND UPPER(IA.Talla) = UPPER(OIT.Talla)
          AND IA.Almacen = 'TEMPORAL CON OP'
    ) AS PIA;

    SELECT TOP 1 @NO_OP = No_OP
    FROM OP_LIBERACIONES
    WHERE Empresa = @EMPRESA AND ID_Liberacion = @ID_Liberacion;

    UPDATE L
    SET L.CantidadRecolectada = DX.Cantidad,
        L.Recolectado = CASE WHEN DX.Cantidad > 0 THEN 1 ELSE L.Recolectado END,
        L.UsuarioRecolecta = @USUARIO,
         L.FechaHoraRecolecta = @FECHA,
        L.ComputadoraRecolecta = @COMPUTADORA,
        L.AlmacenIngreso = @ALMACEN
    FROM OP_LIBERACIONES L
    INNER JOIN @DETALLE_XML DX
            ON UPPER(L.Talla) = DX.Talla
           AND L.ID_Liberacion = @ID_Liberacion
           AND L.Empresa = @EMPRESA;

    UPDATE A
    SET A.Cantidad = D.CantidadNueva,
        A.Fecha = @FECHA,
        A.Usuario = @USUARIO,
        A.FechaHora = @FECHA,
        A.Computadora = @COMPUTADORA
    FROM OP_AVANCEPROCESOS A
    INNER JOIN (
            SELECT DISTINCT No_OP, Talla, CantidadNueva
            FROM @DETALLE
    ) AS D
            ON A.Empresa = @EMPRESA
           AND A.ID_Liberacion = @ID_Liberacion
           AND A.No_OP = D.No_OP
           AND UPPER(A.Talla) = UPPER(D.Talla)
    WHERE ISNULL(A.Cantidad,0) <> ISNULL(D.CantidadNueva,0);

    DECLARE @OP_RESUMEN TABLE
    (
        No_OP BIGINT,
        Cve_Prenda BIGINT,
        Talla NVARCHAR(50),
        No_Pedido BIGINT,
        CantidadLiberadaDetalle BIGINT,
        CantidadRecolectadaNueva BIGINT,
        CantidadLiberadaActual BIGINT,
        CantidadAsignada BIGINT,
        CantidadNoAsignada BIGINT,
        SaldoLiberadoAsignado BIGINT,
        SaldoLiberadoNoAsignado BIGINT,
        CantidadRecolectadaActual BIGINT,
        SaldoRecolectadoAsignado BIGINT,
        SaldoRecolectadoNoAsignado BIGINT,
        InventarioTemporalAsignado BIGINT,
        InventarioTemporalNoAsignado BIGINT,
        DeltaLiberacion BIGINT,
        DeltaRecolectada BIGINT,
        NuevoRecolectado BIGINT
    );

    INSERT INTO @OP_RESUMEN
    (
        No_OP,
        Cve_Prenda,
        Talla,
        No_Pedido,
        CantidadLiberadaDetalle,
        CantidadRecolectadaNueva,
        CantidadLiberadaActual,
        CantidadAsignada,
        CantidadNoAsignada,
        SaldoLiberadoAsignado,
        SaldoLiberadoNoAsignado,
        CantidadRecolectadaActual,
        SaldoRecolectadoAsignado,
        SaldoRecolectadoNoAsignado,
        InventarioTemporalAsignado,
        InventarioTemporalNoAsignado,
        DeltaLiberacion,
        DeltaRecolectada,
        NuevoRecolectado
    )
    SELECT
        D.No_OP,
        D.Cve_Prenda,
        D.Talla,
        MAX(D.No_PedidoReferencia) AS No_Pedido,
        SUM(D.CantidadLiberadaDetalle) AS CantidadLiberadaDetalle,
        SUM(D.CantidadNueva) AS CantidadRecolectadaNueva,
        MAX(D.CantidadLiberadaActual) AS CantidadLiberadaActual,
        MAX(D.CantidadAsignada) AS CantidadAsignada,
        MAX(D.CantidadNoAsignada) AS CantidadNoAsignada,
        MAX(D.SaldoLiberadoAsignado) AS SaldoLiberadoAsignado,
        MAX(D.SaldoLiberadoNoAsignado) AS SaldoLiberadoNoAsignado,
        MAX(D.CantidadRecolectadaActual) AS CantidadRecolectadaActual,
        MAX(D.SaldoRecolectadoAsignado) AS SaldoRecolectadoAsignado,
        MAX(D.SaldoRecolectadoNoAsignado) AS SaldoRecolectadoNoAsignado,
        MAX(D.InventarioTemporalAsignado) AS InventarioTemporalAsignado,
        MAX(D.InventarioTemporalNoAsignado) AS InventarioTemporalNoAsignado,
        SUM(D.CantidadNueva - D.CantidadLiberadaDetalle) AS DeltaLiberacion,
        SUM(D.CantidadNueva - D.CantidadAnterior) AS DeltaRecolectada,
        MAX(D.CantidadRecolectadaActual) + SUM(D.CantidadNueva - D.CantidadAnterior) AS NuevoRecolectado
    FROM @DETALLE D
    GROUP BY D.No_OP, D.Cve_Prenda, D.Talla;

    DECLARE @MOVIMIENTOS TABLE
    (
        No_OP BIGINT,
        Cve_Prenda BIGINT,
        Talla NVARCHAR(50),
        No_Pedido BIGINT,
        Origen NVARCHAR(50),
        Destino NVARCHAR(50),
        TipoInventario NVARCHAR(50),
        Cantidad BIGINT
    );

    DECLARE
        @CUR_No_OP BIGINT,
        @CUR_Cve_Prenda BIGINT,
        @CUR_Talla NVARCHAR(50),
        @CUR_No_Pedido BIGINT,
        @CUR_CantidadLiberadaDetalle BIGINT,
        @CUR_CantidadRecolectadaNueva BIGINT,
        @CUR_CantidadLiberada BIGINT,
        @CUR_CantidadAsignada BIGINT,
        @CUR_CantidadNoAsignada BIGINT,
        @CUR_SaldoLiberadoAsignado BIGINT,
        @CUR_SaldoLiberadoNoAsignado BIGINT,
        @CUR_CantidadRecolectada BIGINT,
        @CUR_SaldoRecolectadoAsignado BIGINT,
        @CUR_SaldoRecolectadoNoAsignado BIGINT,
        @CUR_InvTemporalAsignado BIGINT,
        @CUR_InvTemporalNoAsignado BIGINT,
        @CUR_DeltaLiberacion BIGINT,
        @CUR_DeltaRecolectada BIGINT,
        @CUR_NuevoRecolectado BIGINT;

    DECLARE MOV_CURSOR CURSOR FOR
    SELECT
        No_OP,
        Cve_Prenda,
        Talla,
        No_Pedido,
        CantidadLiberadaDetalle,
        CantidadRecolectadaNueva,
        CantidadLiberadaActual,
        CantidadAsignada,
        CantidadNoAsignada,
        SaldoLiberadoAsignado,
        SaldoLiberadoNoAsignado,
        CantidadRecolectadaActual,
        SaldoRecolectadoAsignado,
        SaldoRecolectadoNoAsignado,
        InventarioTemporalAsignado,
        InventarioTemporalNoAsignado,
        DeltaLiberacion,
        DeltaRecolectada,
        NuevoRecolectado
    FROM @OP_RESUMEN;

    OPEN MOV_CURSOR;
    FETCH NEXT FROM MOV_CURSOR INTO @CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, @CUR_CantidadLiberadaDetalle, @CUR_CantidadRecolectadaNueva, @CUR_CantidadLiberada, @CUR_CantidadAsignada,
                                     @CUR_CantidadNoAsignada, @CUR_SaldoLiberadoAsignado, @CUR_SaldoLiberadoNoAsignado, @CUR_CantidadRecolectada,
                                     @CUR_SaldoRecolectadoAsignado, @CUR_SaldoRecolectadoNoAsignado, @CUR_InvTemporalAsignado, @CUR_InvTemporalNoAsignado, @CUR_DeltaLiberacion, @CUR_DeltaRecolectada, @CUR_NuevoRecolectado;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @SaldoLiberadoAsignadoActual BIGINT = ISNULL(@CUR_SaldoLiberadoAsignado,0);
        DECLARE @SaldoLiberadoNoAsignadoActual BIGINT = ISNULL(@CUR_SaldoLiberadoNoAsignado,0);
        DECLARE @CantidadLiberadaActual BIGINT = ISNULL(@CUR_CantidadLiberada,0);
        DECLARE @InventarioAsignadoActual BIGINT = ISNULL(@CUR_InvTemporalAsignado,0);
        DECLARE @InventarioNoAsignadoActual BIGINT = ISNULL(@CUR_InvTemporalNoAsignado,0);
        DECLARE @SaldoRecolectadoAsignadoActual BIGINT = ISNULL(@CUR_SaldoRecolectadoAsignado,0);
        DECLARE @SaldoRecolectadoNoAsignadoActual BIGINT = ISNULL(@CUR_SaldoRecolectadoNoAsignado,0);
        DECLARE @CantidadRecolectadaActual BIGINT = ISNULL(@CUR_CantidadRecolectada,0);

        DECLARE @DeltaLiberacion BIGINT = ISNULL(@CUR_DeltaLiberacion,0);

        IF @DeltaLiberacion > 0
        BEGIN
            DECLARE @PendienteLiberacion BIGINT = @DeltaLiberacion;
            DECLARE @DisponibleAsignado BIGINT = 0;
            IF ISNULL(@CUR_CantidadAsignada,0) > @CantidadLiberadaActual
                SET @DisponibleAsignado = ISNULL(@CUR_CantidadAsignada,0) - @CantidadLiberadaActual;
            IF @DisponibleAsignado > @InventarioAsignadoActual
                SET @DisponibleAsignado = @InventarioAsignadoActual;

            DECLARE @MoverAsignado BIGINT = CASE WHEN @DisponibleAsignado > @PendienteLiberacion THEN @PendienteLiberacion ELSE @DisponibleAsignado END;
            IF @MoverAsignado > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'TEMPORAL CON OP', 'LIBERADO', 'Inventario Asignado', @MoverAsignado);
                SET @InventarioAsignadoActual = @InventarioAsignadoActual - @MoverAsignado;
                SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual + @MoverAsignado;
                SET @CantidadLiberadaActual = @CantidadLiberadaActual + @MoverAsignado;
                SET @PendienteLiberacion = @PendienteLiberacion - @MoverAsignado;
            END;

            IF @PendienteLiberacion > 0
            BEGIN
                DECLARE @MoverNoAsignado BIGINT = CASE WHEN @InventarioNoAsignadoActual > @PendienteLiberacion THEN @PendienteLiberacion ELSE @InventarioNoAsignadoActual END;
                IF @MoverNoAsignado > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'TEMPORAL CON OP', 'LIBERADO', 'Inventario no Asignado', @MoverNoAsignado);
                    SET @InventarioNoAsignadoActual = @InventarioNoAsignadoActual - @MoverNoAsignado;
                    SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual + @MoverNoAsignado;
                    SET @CantidadLiberadaActual = @CantidadLiberadaActual + @MoverNoAsignado;
                    SET @PendienteLiberacion = @PendienteLiberacion - @MoverNoAsignado;
                END;
            END;
        END
        ELSE IF @DeltaLiberacion < 0
        BEGIN
            DECLARE @PorDevolver BIGINT = -@DeltaLiberacion;

            DECLARE @MoverNoAsignadoDev BIGINT = CASE WHEN @SaldoLiberadoNoAsignadoActual > @PorDevolver THEN @PorDevolver ELSE @SaldoLiberadoNoAsignadoActual END;
            IF @MoverNoAsignadoDev > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'LIBERADO', 'TEMPORAL CON OP', 'Inventario no Asignado', @MoverNoAsignadoDev);
                SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual - @MoverNoAsignadoDev;
                SET @CantidadLiberadaActual = @CantidadLiberadaActual - @MoverNoAsignadoDev;
                SET @InventarioNoAsignadoActual = @InventarioNoAsignadoActual + @MoverNoAsignadoDev;
                SET @PorDevolver = @PorDevolver - @MoverNoAsignadoDev;
            END;

            IF @PorDevolver > 0
            BEGIN
                DECLARE @MoverAsignadoDev BIGINT = CASE WHEN @SaldoLiberadoAsignadoActual > @PorDevolver THEN @PorDevolver ELSE @SaldoLiberadoAsignadoActual END;
                IF @MoverAsignadoDev > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'LIBERADO', 'TEMPORAL CON OP', 'Inventario Asignado', @MoverAsignadoDev);
                    SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual - @MoverAsignadoDev;
                    SET @CantidadLiberadaActual = @CantidadLiberadaActual - @MoverAsignadoDev;
                    SET @InventarioAsignadoActual = @InventarioAsignadoActual + @MoverAsignadoDev;
                    SET @PorDevolver = @PorDevolver - @MoverAsignadoDev;
                END;
            END;
        END;

        IF @CUR_DeltaRecolectada > 0
        BEGIN
            DECLARE @PorRecolectar BIGINT = @CUR_DeltaRecolectada;

            DECLARE @MoverAsignadoReco BIGINT = CASE WHEN @SaldoLiberadoAsignadoActual > @PorRecolectar THEN @PorRecolectar ELSE @SaldoLiberadoAsignadoActual END;
            IF @MoverAsignadoReco > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'LIBERADO', 'RECOLECTADO', 'Inventario Asignado', @MoverAsignadoReco);
                SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual - @MoverAsignadoReco;
                SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual + @MoverAsignadoReco;
                SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverAsignadoReco;
                SET @PorRecolectar = @PorRecolectar - @MoverAsignadoReco;
            END;

            IF @PorRecolectar > 0
            BEGIN
                DECLARE @MoverNoAsignadoReco BIGINT = CASE WHEN @SaldoLiberadoNoAsignadoActual > @PorRecolectar THEN @PorRecolectar ELSE @SaldoLiberadoNoAsignadoActual END;
                IF @MoverNoAsignadoReco > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'LIBERADO', 'RECOLECTADO', 'Inventario no Asignado', @MoverNoAsignadoReco);
                    SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual - @MoverNoAsignadoReco;
                    SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual + @MoverNoAsignadoReco;
                    SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverNoAsignadoReco;
                    SET @PorRecolectar = @PorRecolectar - @MoverNoAsignadoReco;
                END;
            END;
        END
        ELSE IF @CUR_DeltaRecolectada < 0
        BEGIN
            DECLARE @PorRevertir BIGINT = -@CUR_DeltaRecolectada;

            DECLARE @MoverAsignadoRevertir BIGINT = CASE WHEN @SaldoRecolectadoAsignadoActual > @PorRevertir THEN @PorRevertir ELSE @SaldoRecolectadoAsignadoActual END;
            IF @MoverAsignadoRevertir > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'RECOLECTADO', 'LIBERADO', 'Inventario Asignado', @MoverAsignadoRevertir);
                SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual - @MoverAsignadoRevertir;
                SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual + @MoverAsignadoRevertir;
                SET @CantidadRecolectadaActual = @CantidadRecolectadaActual - @MoverAsignadoRevertir;
                SET @PorRevertir = @PorRevertir - @MoverAsignadoRevertir;
            END;

            IF @PorRevertir > 0
            BEGIN
                DECLARE @MoverNoAsignadoRevertir BIGINT = CASE WHEN @SaldoRecolectadoNoAsignadoActual > @PorRevertir THEN @PorRevertir ELSE @SaldoRecolectadoNoAsignadoActual END;
                IF @MoverNoAsignadoRevertir > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, 'RECOLECTADO', 'LIBERADO', 'Inventario no Asignado', @MoverNoAsignadoRevertir);
                    SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual - @MoverNoAsignadoRevertir;
                    SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual + @MoverNoAsignadoRevertir;
                    SET @CantidadRecolectadaActual = @CantidadRecolectadaActual - @MoverNoAsignadoRevertir;
                    SET @PorRevertir = @PorRevertir - @MoverNoAsignadoRevertir;
                END;
            END;
        END;

        FETCH NEXT FROM MOV_CURSOR INTO @CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido, @CUR_CantidadLiberadaDetalle, @CUR_CantidadRecolectadaNueva, @CUR_CantidadLiberada, @CUR_CantidadAsignada,
                                         @CUR_CantidadNoAsignada, @CUR_SaldoLiberadoAsignado, @CUR_SaldoLiberadoNoAsignado, @CUR_CantidadRecolectada,
                                         @CUR_SaldoRecolectadoAsignado, @CUR_SaldoRecolectadoNoAsignado, @CUR_InvTemporalAsignado, @CUR_InvTemporalNoAsignado, @CUR_DeltaLiberacion, @CUR_DeltaRecolectada, @CUR_NuevoRecolectado;
    END;

    CLOSE MOV_CURSOR;
    DEALLOCATE MOV_CURSOR;

    IF EXISTS (SELECT 1 FROM @MOVIMIENTOS)
    BEGIN
        UPDATE IA
        SET IA.InventarioAsignado = IA.InventarioAsignado - ORI.Cantidad
        FROM PRENDA_INVENTARIO_ALMACEN IA
        INNER JOIN (
            SELECT Cve_Prenda, Talla, Origen AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario Asignado'
            GROUP BY Cve_Prenda, Talla, Origen
        ) AS ORI
                ON IA.Empresa = @EMPRESA
               AND IA.Cve_Prenda = ORI.Cve_Prenda
               AND UPPER(IA.Talla) = UPPER(ORI.Talla)
               AND IA.Almacen = ORI.Almacen;

        UPDATE IA
        SET IA.InventarioNoAsignado = IA.InventarioNoAsignado - ORI.Cantidad
        FROM PRENDA_INVENTARIO_ALMACEN IA
        INNER JOIN (
            SELECT Cve_Prenda, Talla, Origen AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario no Asignado'
            GROUP BY Cve_Prenda, Talla, Origen
        ) AS ORI
                ON IA.Empresa = @EMPRESA
               AND IA.Cve_Prenda = ORI.Cve_Prenda
               AND UPPER(IA.Talla) = UPPER(ORI.Talla)
               AND IA.Almacen = ORI.Almacen;

        MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
        USING (
            SELECT Cve_Prenda, Talla, Destino AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario Asignado'
            GROUP BY Cve_Prenda, Talla, Destino
        ) AS SOURCE
                ON TARGET.Empresa = @EMPRESA
               AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
               AND UPPER(TARGET.Talla) = UPPER(SOURCE.Talla)
               AND TARGET.Almacen = SOURCE.Almacen
        WHEN MATCHED THEN
            UPDATE SET TARGET.InventarioAsignado = TARGET.InventarioAsignado + SOURCE.Cantidad
        WHEN NOT MATCHED THEN
            INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
            VALUES (@EMPRESA, SOURCE.Cve_Prenda, SOURCE.Almacen, SOURCE.Talla, 0, SOURCE.Cantidad);

        MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
        USING (
            SELECT Cve_Prenda, Talla, Destino AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario no Asignado'
            GROUP BY Cve_Prenda, Talla, Destino
        ) AS SOURCE
                ON TARGET.Empresa = @EMPRESA
               AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
               AND UPPER(TARGET.Talla) = UPPER(SOURCE.Talla)
               AND TARGET.Almacen = SOURCE.Almacen
        WHEN MATCHED THEN
            UPDATE SET TARGET.InventarioNoAsignado = TARGET.InventarioNoAsignado + SOURCE.Cantidad
        WHEN NOT MATCHED THEN
            INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
            VALUES (@EMPRESA, SOURCE.Cve_Prenda, SOURCE.Almacen, SOURCE.Talla, SOURCE.Cantidad, 0);

        WITH MOV AS
        (
            SELECT
                No_OP,
                Cve_Prenda,
                Talla,
                SUM(CASE WHEN Origen = 'TEMPORAL CON OP' AND Destino = 'LIBERADO' AND TipoInventario = 'Inventario Asignado' THEN Cantidad ELSE 0 END) AS TempToLibAsignado,
                SUM(CASE WHEN Origen = 'TEMPORAL CON OP' AND Destino = 'LIBERADO' AND TipoInventario = 'Inventario no Asignado' THEN Cantidad ELSE 0 END) AS TempToLibNoAsignado,
                SUM(CASE WHEN Origen = 'LIBERADO' AND Destino = 'TEMPORAL CON OP' AND TipoInventario = 'Inventario Asignado' THEN Cantidad ELSE 0 END) AS LibToTempAsignado,
                SUM(CASE WHEN Origen = 'LIBERADO' AND Destino = 'TEMPORAL CON OP' AND TipoInventario = 'Inventario no Asignado' THEN Cantidad ELSE 0 END) AS LibToTempNoAsignado,
                SUM(CASE WHEN Origen = 'LIBERADO' AND Destino = 'RECOLECTADO' AND TipoInventario = 'Inventario Asignado' THEN Cantidad ELSE 0 END) AS LibToRecoAsignado,
                SUM(CASE WHEN Origen = 'LIBERADO' AND Destino = 'RECOLECTADO' AND TipoInventario = 'Inventario no Asignado' THEN Cantidad ELSE 0 END) AS LibToRecoNoAsignado,
                SUM(CASE WHEN Origen = 'RECOLECTADO' AND Destino = 'LIBERADO' AND TipoInventario = 'Inventario Asignado' THEN Cantidad ELSE 0 END) AS RecoToLibAsignado,
                SUM(CASE WHEN Origen = 'RECOLECTADO' AND Destino = 'LIBERADO' AND TipoInventario = 'Inventario no Asignado' THEN Cantidad ELSE 0 END) AS RecoToLibNoAsignado
            FROM @MOVIMIENTOS
            GROUP BY No_OP, Cve_Prenda, Talla
        )
        UPDATE OIT
        SET OIT.CantidadLiberada = CASE
                                        WHEN OIT.CantidadLiberada + MOV.TempToLibAsignado + MOV.TempToLibNoAsignado - MOV.LibToTempAsignado - MOV.LibToTempNoAsignado < 0 THEN 0
                                        WHEN OIT.CantidadLiberada + MOV.TempToLibAsignado + MOV.TempToLibNoAsignado - MOV.LibToTempAsignado - MOV.LibToTempNoAsignado > OIT.CantidadOP THEN OIT.CantidadOP
                                        ELSE OIT.CantidadLiberada + MOV.TempToLibAsignado + MOV.TempToLibNoAsignado - MOV.LibToTempAsignado - MOV.LibToTempNoAsignado
                                    END,
            OIT.SaldoLiberadoAsignado = CASE
                                            WHEN OIT.SaldoLiberadoAsignado + MOV.TempToLibAsignado - MOV.LibToTempAsignado - MOV.LibToRecoAsignado + MOV.RecoToLibAsignado < 0 THEN 0
                                            ELSE OIT.SaldoLiberadoAsignado + MOV.TempToLibAsignado - MOV.LibToTempAsignado - MOV.LibToRecoAsignado + MOV.RecoToLibAsignado
                                        END,
            OIT.SaldoLiberadoNoAsignado = CASE
                                            WHEN OIT.SaldoLiberadoNoAsignado + MOV.TempToLibNoAsignado - MOV.LibToTempNoAsignado - MOV.LibToRecoNoAsignado + MOV.RecoToLibNoAsignado < 0 THEN 0
                                            ELSE OIT.SaldoLiberadoNoAsignado + MOV.TempToLibNoAsignado - MOV.LibToTempNoAsignado - MOV.LibToRecoNoAsignado + MOV.RecoToLibNoAsignado
                                        END,
            OIT.CantidadRecolectada = CASE
                                            WHEN OIT.CantidadRecolectada + MOV.LibToRecoAsignado + MOV.LibToRecoNoAsignado - MOV.RecoToLibAsignado - MOV.RecoToLibNoAsignado < 0 THEN 0
                                            WHEN OIT.CantidadRecolectada + MOV.LibToRecoAsignado + MOV.LibToRecoNoAsignado - MOV.RecoToLibAsignado - MOV.RecoToLibNoAsignado > OIT.CantidadOP THEN OIT.CantidadOP
                                            ELSE OIT.CantidadRecolectada + MOV.LibToRecoAsignado + MOV.LibToRecoNoAsignado - MOV.RecoToLibAsignado - MOV.RecoToLibNoAsignado
                                        END,
            OIT.SaldoRecolectadoAsignado = CASE
                                                WHEN OIT.SaldoRecolectadoAsignado + MOV.LibToRecoAsignado - MOV.RecoToLibAsignado < 0 THEN 0
                                                ELSE OIT.SaldoRecolectadoAsignado + MOV.LibToRecoAsignado - MOV.RecoToLibAsignado
                                            END,
            OIT.SaldoRecolectadoNoAsignado = CASE
                                                WHEN OIT.SaldoRecolectadoNoAsignado + MOV.LibToRecoNoAsignado - MOV.RecoToLibNoAsignado < 0 THEN 0
                                                ELSE OIT.SaldoRecolectadoNoAsignado + MOV.LibToRecoNoAsignado - MOV.RecoToLibNoAsignado
                                            END,
            OIT.FechaUltimaActualizacion = @FECHA
        FROM OP_INVENTARIO_TEMPORAL OIT
        INNER JOIN MOV
                ON MOV.No_OP = OIT.No_OP
               AND MOV.Cve_Prenda = OIT.Cve_Prenda
               AND UPPER(MOV.Talla) = UPPER(OIT.Talla)
        WHERE OIT.Empresa = @EMPRESA;

        DECLARE @BITACORA TABLE
        (
            No_Pedido BIGINT,
            Cve_Prenda BIGINT,
            Talla NVARCHAR(50),
            TipoMovimiento NVARCHAR(50),
            Almacen NVARCHAR(50),
            TipoInventario NVARCHAR(50),
            Cantidad BIGINT,
            No_OP BIGINT,
            Cve_Maquilador BIGINT,
            Nom_Maquilador NVARCHAR(255)
        );

        INSERT INTO @BITACORA
        SELECT
            M.No_Pedido,
            M.Cve_Prenda,
            M.Talla,
            'SALIDA' AS TipoMovimiento,
            M.Origen,
            M.TipoInventario,
            M.Cantidad,
            M.No_OP,
            OA.Cve_Maquilador,
            OA.Nom_Maquilador
        FROM @MOVIMIENTOS M
        INNER JOIN OP_ASIGNACION OA
                ON OA.Empresa = @EMPRESA
               AND OA.No_OP = M.No_OP
        WHERE M.Cantidad > 0
          AND M.No_Pedido IS NOT NULL

        UNION ALL

        SELECT
            M.No_Pedido,
            M.Cve_Prenda,
            M.Talla,
            'ENTRADA' AS TipoMovimiento,
            M.Destino,
            M.TipoInventario,
            M.Cantidad,
            M.No_OP,
            OA.Cve_Maquilador,
            OA.Nom_Maquilador
        FROM @MOVIMIENTOS M
        INNER JOIN OP_ASIGNACION OA
                ON OA.Empresa = @EMPRESA
               AND OA.No_OP = M.No_OP
        WHERE M.Cantidad > 0
          AND M.No_Pedido IS NOT NULL;

        IF EXISTS (SELECT 1 FROM @BITACORA)
        BEGIN
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
                P.No_Pedido,
                ISNULL(MC.MaxConsecutivo,0) + P.RN,
                P.Cve_Prenda,
                P.Talla,
                P.TipoMovimiento,
                P.Almacen,
                P.TipoInventario,
                P.No_OP,
                P.Cve_Maquilador,
                P.Nom_Maquilador,
                P.Cantidad,
                0,
                @USUARIO,
                @FECHA,
                @COMPUTADORA
            FROM (
                SELECT
                    B.*, 
                    ROW_NUMBER() OVER (
                        PARTITION BY B.No_Pedido
                        ORDER BY CASE WHEN B.TipoMovimiento = 'SALIDA' THEN 0 ELSE 1 END,
                                B.TipoInventario,
                                B.Almacen,
                                B.Cve_Prenda,
                                B.Talla
                    ) AS RN
                FROM @BITACORA B
            ) AS P
            OUTER APPLY (
                SELECT ISNULL(MAX(Consecutivo),0) AS MaxConsecutivo
                FROM PRENDA_INVENTARIO_BITACORA
                WHERE Empresa = @EMPRESA
                  AND No_Pedido = P.No_Pedido
            ) AS MC;
        END
    END
END
GO

