USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_AVANCES_XML]    Script Date: 15/12/2025 08:57:15 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GUARDAR_AVANCES_XML]
        @EMPRESA BIGINT,
        @CVE_ORDEN BIGINT,
        @USUARIO BIGINT,
        @COMPUTADORA NVARCHAR(50),
        @XML_AVANCES XML
AS
BEGIN
        SET NOCOUNT ON;

        DECLARE @USUARIO_WORK BIGINT = ISNULL(@USUARIO,0);
        DECLARE @COMPUTADORA_WORK NVARCHAR(50) = ISNULL(@COMPUTADORA,'');
        DECLARE @FECHA DATETIME = GETDATE();

        IF @XML_AVANCES IS NULL OR @XML_AVANCES.exist('/Avances') = 0
        BEGIN
                RETURN;
        END

        SELECT
                @USUARIO_WORK = ISNULL(A.value('@Usuario','bigint'),@USUARIO_WORK),
                @COMPUTADORA_WORK = ISNULL(A.value('@Computadora','nvarchar(50)'), @COMPUTADORA_WORK)
        FROM @XML_AVANCES.nodes('/Avances') AS X(A);

        ---------------------------------------------------------------------
        --  Lógica existente: guardar avances de procesos en la OP          --
        ---------------------------------------------------------------------

        DECLARE @PROCESO_ITEMS TABLE
        (
                Nivel1 INT,
                Nivel2 INT,
                Nivel3 INT,
                Talla NVARCHAR(50),
                Cantidad BIGINT,
                SinCambios BIT
        );

        INSERT INTO @PROCESO_ITEMS
        (
                Nivel1,
                Nivel2,
                Nivel3,
                Talla,
                Cantidad,
                SinCambios
        )
        SELECT
                NULLIF(P.value('@Nivel1','int'),0),
                NULLIF(P.value('@Nivel2','int'),0),
                NULLIF(P.value('@Nivel3','int'),0),
                NULLIF(LTRIM(RTRIM(P.value('@Talla','nvarchar(50)'))),''),
                ISNULL(P.value('@Cantidad','bigint'),0),
                CASE WHEN ISNULL(P.value('@SinCambios','int'),0) <> 0 THEN 1 ELSE 0 END
        FROM @XML_AVANCES.nodes('/Avances/Proceso') AS X(P)
        WHERE ISNULL(P.value('@Cantidad','bigint'),0) <> 0
        AND NULLIF(LTRIM(RTRIM(P.value('@Talla','nvarchar(50)'))),'') IS NOT NULL;

        DECLARE @AVANCES TABLE
        (
                ID_Avance UNIQUEIDENTIFIER PRIMARY KEY,
                No_OP BIGINT,
                Orden INT,
                Nivel1 INT,
                Nivel2 INT,
                Nivel3 INT,
                Descripcion NVARCHAR(255),
                Observaciones NVARCHAR(MAX),
                FechaAvance DATETIME NULL,
                ID_Liberacion UNIQUEIDENTIFIER NULL
        );

        INSERT INTO @AVANCES
        (
                ID_Avance,
                No_OP,
                Orden,
                Nivel1,
                Nivel2,
                Nivel3,
                Descripcion,
                Observaciones,
                FechaAvance,
                ID_Liberacion
        )
        SELECT
                NEWID(),
                @CVE_ORDEN,
                COALESCE(OPP.Orden,0),
                P.Nivel1,
                P.Nivel2,
                P.Nivel3,
                OPP.Descripcion,
                NULL,
                NULL,
                NULL
        FROM (
                SELECT DISTINCT
                        Nivel1,
                        Nivel2,
                        Nivel3
                FROM @PROCESO_ITEMS
        ) AS P
        LEFT JOIN OP_PROCESOS OPP
                ON OPP.Empresa = @EMPRESA
                AND OPP.No_OP = @CVE_ORDEN
                AND ISNULL(OPP.Nivel1,0) = ISNULL(P.Nivel1,0)
                AND ISNULL(OPP.Nivel2,0) = ISNULL(P.Nivel2,0)
                AND ISNULL(OPP.Nivel3,0) = ISNULL(P.Nivel3,0)
        WHERE P.Nivel1 IS NOT NULL OR P.Nivel2 IS NOT NULL OR P.Nivel3 IS NOT NULL;

        DECLARE @AVANCES_DETALLE TABLE
        (
                ID_Avance UNIQUEIDENTIFIER,
                Talla NVARCHAR(50),
                Cantidad BIGINT
        );

        INSERT INTO @AVANCES_DETALLE
        (
                ID_Avance,
                Talla,
                Cantidad
        )
        SELECT
                A.ID_Avance,
                PI.Talla,
                PI.Cantidad
        FROM @PROCESO_ITEMS PI
        INNER JOIN @AVANCES A
                ON ISNULL(A.Nivel1,0) = ISNULL(PI.Nivel1,0)
                AND ISNULL(A.Nivel2,0) = ISNULL(PI.Nivel2,0)
                AND ISNULL(A.Nivel3,0) = ISNULL(PI.Nivel3,0);

        -- La inserción en OP_AVANCEPROCESOS se realiza al final una vez que
        -- se hayan determinado las liberaciones correspondientes.

        ---------------------------------------------------------------------
        --  Nuevas funcionalidades: cálculo de saldos y movimientos de OP   --
        ---------------------------------------------------------------------

        DECLARE @RESULT_LIBERACIONES TABLE
        (
                ID_Liberacion UNIQUEIDENTIFIER,
                No_Liberacion INT,
                No_OP BIGINT
        );

        DECLARE @LIBERACIONES_INSERTADAS TABLE
        (
                ID_Liberacion UNIQUEIDENTIFIER,
                No_Liberacion INT,
                No_OP BIGINT,
                Talla NVARCHAR(50),
                Cantidad BIGINT,
                DetalleOrden INT
        );

        DECLARE @LIBERACION_AVANCES TABLE
        (
                ID_Avance UNIQUEIDENTIFIER,
                No_OP BIGINT,
                Cve_Prenda BIGINT,
                Nivel1 INT,
                Nivel2 INT,
                Nivel3 INT
        );

        INSERT INTO @LIBERACION_AVANCES
        (
                ID_Avance,
                No_OP,
                Cve_Prenda,
                Nivel1,
                Nivel2,
                Nivel3
        )
        SELECT
                A.ID_Avance,
                A.No_OP,
                OPP.Cve_Prenda,
                A.Nivel1,
                A.Nivel2,
                A.Nivel3
        FROM @AVANCES A
        INNER JOIN OP_PROCESOS OPP
                ON OPP.Empresa = @EMPRESA
                AND OPP.No_OP = A.No_OP
                AND ISNULL(OPP.Nivel1,0) = ISNULL(A.Nivel1,0)
                AND ISNULL(OPP.Nivel2,0) = ISNULL(A.Nivel2,0)
                AND ISNULL(OPP.Nivel3,0) = ISNULL(A.Nivel3,0)
        WHERE UPPER(RTRIM(LTRIM(ISNULL(OPP.Descripcion,'')))) = 'LIBERACIÓN';

        IF EXISTS (SELECT 1 FROM @LIBERACION_AVANCES)
        BEGIN
                DECLARE @NEXT_NO_LIB INT;
                SELECT @NEXT_NO_LIB = ISNULL(MAX(No_Liberacion),0) + 1
                FROM OP_LIBERACIONES
                WHERE Empresa = @EMPRESA;

                DECLARE @LIB_OPS TABLE (RowID INT IDENTITY(1,1), No_OP BIGINT);

                INSERT INTO @LIB_OPS (No_OP)
                SELECT DISTINCT No_OP
                FROM @LIBERACION_AVANCES;

                DECLARE @TOTAL_OPS INT = (SELECT COUNT(1) FROM @LIB_OPS);
                DECLARE @INDEX_OP INT = 1;

                DECLARE @LIBERACIONES_NUEVAS TABLE
                (
                        ID_Liberacion UNIQUEIDENTIFIER,
                        No_Liberacion INT,
                        No_OP BIGINT,
                        Talla NVARCHAR(50),
                        Cantidad BIGINT,
                        DetalleOrden INT
                );

                WHILE @INDEX_OP <= @TOTAL_OPS
                BEGIN
                        DECLARE @CURR_OP BIGINT;
                        SELECT @CURR_OP = No_OP FROM @LIB_OPS WHERE RowID = @INDEX_OP;

                        DECLARE @CURR_ID_LIB UNIQUEIDENTIFIER = NEWID();
                        DECLARE @CURR_NO_LIB INT = @NEXT_NO_LIB;

                        DECLARE @OBS_LIB NVARCHAR(MAX);
                        SELECT TOP 1 @OBS_LIB = OBS.Observacion
                        FROM
                        (
                                SELECT
                                        COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')) AS Observacion,
                                        COALESCE(NULLIF(O.value('@NoOP','bigint'),0), @CURR_OP) AS No_OP,
                                        UPPER(RTRIM(LTRIM(ISNULL(O.value('@Descripcion','nvarchar(255)'),'')))) AS DescUpper
                                FROM @XML_AVANCES.nodes('/Avances/Observacion') AS XO(O)
                                UNION ALL
                                SELECT
                                        COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')),
                                        COALESCE(NULLIF(O.value('@NoOP','bigint'),0), @CURR_OP),
                                        UPPER(RTRIM(LTRIM(ISNULL(O.value('@Descripcion','nvarchar(255)'),''))))
                                FROM @XML_AVANCES.nodes('/Avances/Proceso') AS XP(P)
                                CROSS APPLY P.nodes('Observaciones/Observacion') AS XO(O)
                        ) AS OBS
                        WHERE (OBS.No_OP IS NULL OR OBS.No_OP = @CURR_OP)
                        AND OBS.Observacion IS NOT NULL
                        AND OBS.DescUpper = 'LIBERACIÓN';

                        DELETE FROM @LIBERACIONES_NUEVAS;

                        INSERT INTO @LIBERACIONES_NUEVAS
                        (
                                ID_Liberacion,
                                No_Liberacion,
                                No_OP,
                                Talla,
                                Cantidad,
                                DetalleOrden
                        )
                        SELECT
                                @CURR_ID_LIB,
                                @CURR_NO_LIB,
                                @CURR_OP,
                                D.Talla,
                                D.Cantidad,
                                ROW_NUMBER() OVER (ORDER BY D.Talla)
                        FROM @LIBERACION_AVANCES LA
                        INNER JOIN @AVANCES_DETALLE D
                                ON D.ID_Avance = LA.ID_Avance
                        WHERE LA.No_OP = @CURR_OP
                        AND ISNULL(D.Cantidad,0) > 0
                        AND D.Talla IS NOT NULL;

                        IF EXISTS (SELECT 1 FROM @LIBERACIONES_NUEVAS)
                        BEGIN
                                INSERT INTO OP_LIBERACIONES
                                (
                                        Empresa,
                                        No_Liberacion,
                                        No_OP,
                                        Talla,
                                        Cantidad,
                                        Usuario,
                                        FechaHora,
                                        Computadora,
                                        ID_Liberacion,
                                        Observaciones
                                )
                                SELECT
                                        @EMPRESA,
                                        LN.No_Liberacion,
                                        LN.No_OP,
                                        LN.Talla,
                                        LN.Cantidad,
                                        @USUARIO_WORK,
                                        @FECHA,
                                        @COMPUTADORA_WORK,
                                        LN.ID_Liberacion,
                                        @OBS_LIB
                                FROM @LIBERACIONES_NUEVAS LN;

                                INSERT INTO @LIBERACIONES_INSERTADAS
                                (
                                        ID_Liberacion,
                                        No_Liberacion,
                                        No_OP,
                                        Talla,
                                        Cantidad,
                                        DetalleOrden
                                )
                                SELECT
                                        LN.ID_Liberacion,
                                        LN.No_Liberacion,
                                        LN.No_OP,
                                        LN.Talla,
                                        LN.Cantidad,
                                        LN.DetalleOrden
                                FROM @LIBERACIONES_NUEVAS LN;

                                INSERT INTO @RESULT_LIBERACIONES
                                SELECT DISTINCT
                                        LN.ID_Liberacion,
                                        LN.No_Liberacion,
                                        LN.No_OP
                                FROM @LIBERACIONES_NUEVAS LN;

                                UPDATE A
                                SET ID_Liberacion = @CURR_ID_LIB
                                FROM @AVANCES A
                                INNER JOIN @LIBERACION_AVANCES LA
                                        ON LA.ID_Avance = A.ID_Avance
                                WHERE LA.No_OP = @CURR_OP;

                                SET @NEXT_NO_LIB = @NEXT_NO_LIB + 1;
                        END

                        SET @INDEX_OP = @INDEX_OP + 1;
                END

                IF EXISTS (SELECT 1 FROM @LIBERACIONES_INSERTADAS)
                BEGIN
                        DECLARE @LIBERACIONES_INFO TABLE
                (
                        ID_Liberacion UNIQUEIDENTIFIER,
                        No_Liberacion INT,
                        No_OP BIGINT,
                        Cve_Prenda BIGINT,
                        Talla NVARCHAR(50),
                        Cantidad BIGINT,
                        No_Pedido BIGINT,
                        Partida BIGINT,
                        UsarInventarioDisponible BIT
                );

                        INSERT INTO @LIBERACIONES_INFO
                        (
                                ID_Liberacion,
                                No_Liberacion,
                                No_OP,
                                Cve_Prenda,
                                Talla,
                                Cantidad,
                                No_Pedido,
                                Partida,
                                UsarInventarioDisponible
                        )
                        SELECT
                                LI.ID_Liberacion,
                                LI.No_Liberacion,
                                LI.No_OP,
                                OITDATA.Cve_Prenda,
                                LI.Talla,
                                LI.Cantidad,
                                PINFO.No_Pedido,
                                PINFO.Partida,
                                ISNULL(PINFO.UsarInventarioDisponible,0)
                        FROM @LIBERACIONES_INSERTADAS LI
                        OUTER APPLY (
                                SELECT TOP 1 OIT.Cve_Prenda
                                FROM OP_INVENTARIO_TEMPORAL OIT
                                WHERE OIT.Empresa = @EMPRESA
                                AND OIT.No_OP = LI.No_OP
                                AND OIT.Talla = LI.Talla
                                ORDER BY OIT.Cve_Prenda
                        ) AS OITDATA
                        OUTER APPLY (
                                SELECT TOP 1
                                        PIT.No_Pedido,
                                        PIT.Partida,
                                        ISNULL(PI.UsarInventarioDisponible,0) AS UsarInventarioDisponible
                                FROM PEDIDO_INTERNO_TALLAS PIT
                                INNER JOIN PEDIDO_INTERNO PI
                                        ON PI.Empresa = PIT.Empresa
                                        AND PI.No_Pedido = PIT.No_Pedido
                                WHERE PIT.Empresa = @EMPRESA
                                AND PIT.No_OP = LI.No_OP
                                AND PIT.Talla = LI.Talla
                                ORDER BY PIT.Partida
                        ) AS PINFO;

                        DECLARE @MOVIMIENTOS TABLE
                        (
                                ID_Liberacion UNIQUEIDENTIFIER,
                                No_Liberacion INT,
                                No_OP BIGINT,
                                Cve_Prenda BIGINT,
                                Talla NVARCHAR(50),
                                No_Pedido BIGINT,
                                Partida BIGINT,
                                UsarInventarioDisponible BIT,
                                CantidadSolicitada BIGINT,
                                CantidadProcesada BIGINT,
                                CantidadAsignado BIGINT,
                                CantidadNoAsignado BIGINT
                        );

                        INSERT INTO @MOVIMIENTOS
                        (
                                ID_Liberacion,
                                No_Liberacion,
                                No_OP,
                                Cve_Prenda,
                                Talla,
                                No_Pedido,
                                Partida,
                                UsarInventarioDisponible,
                                CantidadSolicitada,
                                CantidadProcesada,
                                CantidadAsignado,
                                CantidadNoAsignado
                        )
                        SELECT
                                LI.ID_Liberacion,
                                LI.No_Liberacion,
                                LI.No_OP,
                                OIT.Cve_Prenda,
                                LI.Talla,
                                LI.No_Pedido,
                                LI.Partida,
                                LI.UsarInventarioDisponible,
                                LI.Cantidad,
                                CP.CantidadProcesada,
                                CA.CantidadAsignado,
                                CNA.CantidadNoAsignado
                        FROM @LIBERACIONES_INFO LI
                        INNER JOIN OP_INVENTARIO_TEMPORAL OIT
                                ON OIT.Empresa = @EMPRESA
                                AND OIT.No_OP = LI.No_OP
                                AND OIT.Talla = LI.Talla
                                AND (LI.Cve_Prenda IS NULL OR OIT.Cve_Prenda = LI.Cve_Prenda)
                        CROSS APPLY
                        (
                                SELECT
                                        CASE WHEN OIT.CantidadAsignada > OIT.SaldoLiberadoAsignado THEN OIT.CantidadAsignada - OIT.SaldoLiberadoAsignado ELSE 0 END AS DisponibleAsignado,
                                        CASE WHEN OIT.CantidadNoAsignada > OIT.SaldoLiberadoNoAsignado THEN OIT.CantidadNoAsignada - OIT.SaldoLiberadoNoAsignado ELSE 0 END AS DisponibleNoAsignado
                        ) AS DISPONIBLES
                        CROSS APPLY
                        (
                                SELECT
                                        CASE
                                                WHEN DISPONIBLES.DisponibleAsignado + DISPONIBLES.DisponibleNoAsignado <= 0 THEN 0
                                                WHEN LI.Cantidad <= (DISPONIBLES.DisponibleAsignado + DISPONIBLES.DisponibleNoAsignado) THEN LI.Cantidad
                                                ELSE DISPONIBLES.DisponibleAsignado + DISPONIBLES.DisponibleNoAsignado
                                        END AS CantidadProcesada
                        ) AS CP
                        CROSS APPLY
                        (
                                SELECT
                                        CASE
                                                WHEN CP.CantidadProcesada <= DISPONIBLES.DisponibleAsignado THEN CP.CantidadProcesada
                                                ELSE DISPONIBLES.DisponibleAsignado
                                        END AS CantidadAsignado
                        ) AS CA
                        CROSS APPLY
                        (
                                SELECT
                                        CASE
                                                WHEN CP.CantidadProcesada > CA.CantidadAsignado THEN
                                                        CASE
                                                                WHEN (CP.CantidadProcesada - CA.CantidadAsignado) <= DISPONIBLES.DisponibleNoAsignado THEN (CP.CantidadProcesada - CA.CantidadAsignado)
                                                                ELSE DISPONIBLES.DisponibleNoAsignado
                                                        END
                                                ELSE 0
                                        END AS CantidadNoAsignado
                        ) AS CNA
                        WHERE LI.Cve_Prenda IS NOT NULL;

                        DELETE FROM @MOVIMIENTOS WHERE CantidadProcesada <= 0;

                        IF EXISTS (SELECT 1 FROM @MOVIMIENTOS)
                        BEGIN
                                UPDATE IA
                                SET IA.InventarioAsignado = IA.InventarioAsignado - ASAL.Cantidad
                                FROM PRENDA_INVENTARIO_ALMACEN IA
                                INNER JOIN (
                                        SELECT Cve_Prenda, Talla, SUM(CantidadAsignado) AS Cantidad
                                        FROM @MOVIMIENTOS
                                        WHERE CantidadAsignado > 0
                                        GROUP BY Cve_Prenda, Talla
                                ) AS ASAL
                                        ON ASAL.Cve_Prenda = IA.Cve_Prenda
                                        AND ASAL.Talla = IA.Talla
                                WHERE IA.Empresa = @EMPRESA
                                AND IA.Almacen = 'TEMPORAL CON OP';

                                UPDATE IA
                                SET IA.InventarioNoAsignado = IA.InventarioNoAsignado - NAS.Cantidad
                                FROM PRENDA_INVENTARIO_ALMACEN IA
                                INNER JOIN (
                                        SELECT Cve_Prenda, Talla, SUM(CantidadNoAsignado) AS Cantidad
                                        FROM @MOVIMIENTOS
                                        WHERE CantidadNoAsignado > 0
                                        GROUP BY Cve_Prenda, Talla
                                ) AS NAS
                                        ON NAS.Cve_Prenda = IA.Cve_Prenda
                                        AND NAS.Talla = IA.Talla
                                WHERE IA.Empresa = @EMPRESA
                                AND IA.Almacen = 'TEMPORAL CON OP';

                                MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
                                USING (
                                        SELECT Cve_Prenda, Talla, SUM(CantidadAsignado) AS Cantidad
                                        FROM @MOVIMIENTOS
                                        WHERE CantidadAsignado > 0
                                        GROUP BY Cve_Prenda, Talla
                                ) AS SOURCE
                                        ON TARGET.Empresa = @EMPRESA
                                        AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
                                        AND TARGET.Talla = SOURCE.Talla
                                        AND TARGET.Almacen = 'LIBERADO'
                                WHEN MATCHED THEN
                                        UPDATE SET InventarioAsignado = TARGET.InventarioAsignado + SOURCE.Cantidad
                                WHEN NOT MATCHED THEN
                                        INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
                                        VALUES (@EMPRESA, SOURCE.Cve_Prenda, 'LIBERADO', SOURCE.Talla, 0, SOURCE.Cantidad);

                                MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
                                USING (
                                        SELECT Cve_Prenda, Talla, SUM(CantidadNoAsignado) AS Cantidad
                                        FROM @MOVIMIENTOS
                                        WHERE CantidadNoAsignado > 0
                                        GROUP BY Cve_Prenda, Talla
                                ) AS SOURCE
                                        ON TARGET.Empresa = @EMPRESA
                                        AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
                                        AND TARGET.Talla = SOURCE.Talla
                                        AND TARGET.Almacen = 'LIBERADO'
                                WHEN MATCHED THEN
                                        UPDATE SET InventarioNoAsignado = TARGET.InventarioNoAsignado + SOURCE.Cantidad
                                WHEN NOT MATCHED THEN
                                        INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
                                        VALUES (@EMPRESA, SOURCE.Cve_Prenda, 'LIBERADO', SOURCE.Talla, SOURCE.Cantidad, 0);

                                UPDATE OIT
                                SET
                                        OIT.SaldoLiberadoAsignado = OIT.SaldoLiberadoAsignado + M.CantidadAsignado,
                                        OIT.SaldoLiberadoNoAsignado = OIT.SaldoLiberadoNoAsignado + M.CantidadNoAsignado,
                                        OIT.CantidadLiberada = CASE
                                                                        WHEN OIT.CantidadLiberada + M.CantidadProcesada <= OIT.CantidadOP THEN OIT.CantidadLiberada + M.CantidadProcesada
                                                                        ELSE OIT.CantidadOP
                                                                END,
                                        OIT.FechaUltimaActualizacion = @FECHA
                                FROM OP_INVENTARIO_TEMPORAL OIT
                                INNER JOIN (
                                        SELECT
                                                No_OP,
                                                Cve_Prenda,
                                                Talla,
                                                SUM(CantidadProcesada) AS CantidadProcesada,
                                                SUM(CantidadAsignado) AS CantidadAsignado,
                                                SUM(CantidadNoAsignado) AS CantidadNoAsignado
                                        FROM @MOVIMIENTOS
                                        GROUP BY No_OP, Cve_Prenda, Talla
                                ) AS M
                                        ON OIT.Empresa = @EMPRESA
                                        AND OIT.No_OP = M.No_OP
                                        AND OIT.Cve_Prenda = M.Cve_Prenda
                                        AND OIT.Talla = M.Talla;

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
                                        'SALIDA',
                                        'TEMPORAL CON OP',
                                        'Inventario Asignado',
                                        M.CantidadAsignado,
                                        M.No_OP,
                                        OA.Cve_Maquilador,
                                        OA.Nom_Maquilador
                                FROM @MOVIMIENTOS M
                                INNER JOIN OP_ASIGNACION OA
                                        ON OA.Empresa = @EMPRESA
                                        AND OA.No_OP = M.No_OP
                                WHERE M.CantidadAsignado > 0
                                AND M.No_Pedido IS NOT NULL

                                UNION ALL

                                SELECT
                                        M.No_Pedido,
                                        M.Cve_Prenda,
                                        M.Talla,
                                        'ENTRADA',
                                        'LIBERADO',
                                        'Inventario Asignado',
                                        M.CantidadAsignado,
                                        M.No_OP,
                                        OA.Cve_Maquilador,
                                        OA.Nom_Maquilador
                                FROM @MOVIMIENTOS M
                                INNER JOIN OP_ASIGNACION OA
                                        ON OA.Empresa = @EMPRESA
                                        AND OA.No_OP = M.No_OP
                                WHERE M.CantidadAsignado > 0
                                AND M.No_Pedido IS NOT NULL

                                UNION ALL

                                SELECT
                                        M.No_Pedido,
                                        M.Cve_Prenda,
                                        M.Talla,
                                        'SALIDA',
                                        'TEMPORAL CON OP',
                                        'Inventario no Asignado',
                                        M.CantidadNoAsignado,
                                        M.No_OP,
                                        OA.Cve_Maquilador,
                                        OA.Nom_Maquilador
                                FROM @MOVIMIENTOS M
                                INNER JOIN OP_ASIGNACION OA
                                        ON OA.Empresa = @EMPRESA
                                        AND OA.No_OP = M.No_OP
                                WHERE M.CantidadNoAsignado > 0
                                AND M.No_Pedido IS NOT NULL

                                UNION ALL

                                SELECT
                                        M.No_Pedido,
                                        M.Cve_Prenda,
                                        M.Talla,
                                        'ENTRADA',
                                        'LIBERADO',
                                        'Inventario no Asignado',
                                        M.CantidadNoAsignado,
                                        M.No_OP,
                                        OA.Cve_Maquilador,
                                        OA.Nom_Maquilador
                                FROM @MOVIMIENTOS M
                                INNER JOIN OP_ASIGNACION OA
                                        ON OA.Empresa = @EMPRESA
                                        AND OA.No_OP = M.No_OP
                                WHERE M.CantidadNoAsignado > 0
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
                                                @USUARIO_WORK,
                                                @FECHA,
                                                @COMPUTADORA_WORK
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
                                                SELECT
                                                        ISNULL(MAX(Consecutivo),0) AS MaxConsecutivo
                                                FROM PRENDA_INVENTARIO_BITACORA
                                                WHERE Empresa = @EMPRESA
                                                AND No_Pedido = P.No_Pedido
                                        ) AS MC;
                                END
                        END
                END
        END

        IF EXISTS (SELECT 1 FROM @AVANCES_DETALLE)
        BEGIN
                INSERT INTO OP_AVANCEPROCESOS
                (
                        Empresa,
                        No_OP,
                        Nivel1,
                        Nivel2,
                        Nivel3,
                        Talla,
                        Cantidad,
                        Fecha,
                        Usuario,
                        FechaHora,
                        Computadora,
                        ID_Liberacion
                )
                SELECT
                        @EMPRESA,
                        A.No_OP,
                        ISNULL(A.Nivel1,0),
                        ISNULL(A.Nivel2,0),
                        ISNULL(A.Nivel3,0),
                        D.Talla,
                        D.Cantidad,
                        @FECHA,
                        @USUARIO_WORK,
                        COALESCE(A.FechaAvance,@FECHA),
                        @COMPUTADORA_WORK,
                        CASE
                                WHEN RTRIM(LTRIM(ISNULL(OPP.Descripcion,''))) = 'LIBERACIÓN' THEN COALESCE(A.ID_Liberacion, RL.ID_Liberacion)
                                ELSE NULL
                        END
                FROM @AVANCES A
                INNER JOIN @AVANCES_DETALLE D
                        ON D.ID_Avance = A.ID_Avance
                LEFT JOIN OP_PROCESOS OPP
                        ON OPP.Empresa = @EMPRESA
                        AND OPP.No_OP = A.No_OP
                        AND ISNULL(OPP.Nivel1,0) = ISNULL(A.Nivel1,0)
                        AND ISNULL(OPP.Nivel2,0) = ISNULL(A.Nivel2,0)
                        AND ISNULL(OPP.Nivel3,0) = ISNULL(A.Nivel3,0)
                OUTER APPLY
                (
                        SELECT TOP 1 L.ID_Liberacion
                        FROM @LIBERACIONES_INSERTADAS L
                        WHERE L.No_OP = A.No_OP
                        AND L.Talla = D.Talla
                        ORDER BY L.DetalleOrden
                ) AS RL;
        END

        ---------------------------------------------------------------------
        --  Observaciones de procesos                                        --
        ---------------------------------------------------------------------

        DECLARE @OBSERVACIONES TABLE
        (
                No_OP BIGINT,
                Nivel1 INT,
                Nivel2 INT,
                Nivel3 INT,
                Descripcion NVARCHAR(255),
                Observacion NVARCHAR(MAX),
                TieneIdentificador BIT
        );

        INSERT INTO @OBSERVACIONES (No_OP, Nivel1, Nivel2, Nivel3, Descripcion, Observacion, TieneIdentificador)
        SELECT
                COALESCE(NULLIF(O.value('@NoOP','bigint'),0), @CVE_ORDEN),
                NULLIF(O.value('@Nivel1','int'),0),
                NULLIF(O.value('@Nivel2','int'),0),
                NULLIF(O.value('@Nivel3','int'),0),
                NULLIF(LTRIM(RTRIM(O.value('@Descripcion','nvarchar(255)'))),''),
                NULLIF(LTRIM(RTRIM(COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')))),'') ,
                CASE WHEN NULLIF(O.value('@ID_Observacion','nvarchar(50)'),'') IS NULL THEN 0 ELSE 1 END
        FROM @XML_AVANCES.nodes('/Avances/Observacion') AS X(O)
        WHERE NULLIF(LTRIM(RTRIM(COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')))),'') IS NOT NULL;

        INSERT INTO @OBSERVACIONES (No_OP, Nivel1, Nivel2, Nivel3, Descripcion, Observacion, TieneIdentificador)
        SELECT
                NULLIF(O.value('@NoOP','bigint'),0),
                NULLIF(O.value('@Nivel1','int'),0),
                NULLIF(O.value('@Nivel2','int'),0),
                NULLIF(O.value('@Nivel3','int'),0),
                NULLIF(LTRIM(RTRIM(O.value('@Descripcion','nvarchar(255)'))),''),
                NULLIF(LTRIM(RTRIM(COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')))),'') ,
                CASE WHEN NULLIF(O.value('@ID_Observacion','nvarchar(50)'),'') IS NULL THEN 0 ELSE 1 END
        FROM @XML_AVANCES.nodes('/Avances/Observaciones/Observacion') AS X(O)
        WHERE NULLIF(LTRIM(RTRIM(COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')))),'') IS NOT NULL;

        INSERT INTO @OBSERVACIONES (No_OP, Nivel1, Nivel2, Nivel3, Descripcion, Observacion, TieneIdentificador)
        SELECT
                COALESCE(NULLIF(O.value('@NoOP','bigint'),0), @CVE_ORDEN),
                COALESCE(NULLIF(O.value('@Nivel1','int'),0), NULLIF(P.value('@Nivel1','int'),0)),
                COALESCE(NULLIF(O.value('@Nivel2','int'),0), NULLIF(P.value('@Nivel2','int'),0)),
                COALESCE(NULLIF(O.value('@Nivel3','int'),0), NULLIF(P.value('@Nivel3','int'),0)),
                COALESCE(NULLIF(LTRIM(RTRIM(O.value('@Descripcion','nvarchar(255)'))),''), NULLIF(LTRIM(RTRIM(P.value('@Descripcion','nvarchar(255)'))),'')),
                NULLIF(LTRIM(RTRIM(COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')))),'') ,
                CASE WHEN NULLIF(O.value('@ID_Observacion','nvarchar(50)'),'') IS NULL THEN 0 ELSE 1 END
        FROM @XML_AVANCES.nodes('/Avances/Proceso') AS X(P)
        CROSS APPLY P.nodes('Observaciones/Observacion') AS XO(O)
        WHERE NULLIF(LTRIM(RTRIM(COALESCE(O.value('@Texto','nvarchar(max)'), O.value('@Observacion','nvarchar(max)')))),'') IS NOT NULL;

        IF EXISTS (SELECT 1 FROM @OBSERVACIONES WHERE TieneIdentificador = 0 AND COALESCE(Observacion,'') <> '')
        BEGIN
                INSERT INTO OP_PROCESOS_OBSERVACIONES
                (
                        Empresa,
                        No_OP,
                        Consecutivo,
                        Nivel1,
                        Nivel2,
                        Nivel3,
                        FechaHora,
                        Usuario,
                        Descripcion,
                        Observacion
                )
                SELECT
                        @EMPRESA,
                        OI.No_OP,
                        ISNULL(MC.MaxConsecutivo,0) + OI.RN,
                        OI.Nivel1,
                        OI.Nivel2,
                        OI.Nivel3,
                        @FECHA,
                        @USUARIO_WORK,
                        OI.Descripcion,
                        OI.Observacion
                FROM (
                        SELECT
                                COALESCE(No_OP, @CVE_ORDEN) AS No_OP,
                                COALESCE(Nivel1,0) AS Nivel1,
                                COALESCE(Nivel2,0) AS Nivel2,
                                COALESCE(Nivel3,0) AS Nivel3,
                                Descripcion,
                                Observacion,
                                ROW_NUMBER() OVER (
                                        PARTITION BY COALESCE(No_OP, @CVE_ORDEN)
                                        ORDER BY COALESCE(Nivel1,0), COALESCE(Nivel2,0), COALESCE(Nivel3,0), COALESCE(Descripcion,''), Observacion
                                ) AS RN
                        FROM @OBSERVACIONES
                        WHERE TieneIdentificador = 0
                        AND COALESCE(Observacion,'') <> ''
                ) AS OI
                OUTER APPLY (
                        SELECT ISNULL(MAX(Consecutivo),0) AS MaxConsecutivo
                        FROM OP_PROCESOS_OBSERVACIONES
                        WHERE Empresa = @EMPRESA
                        AND No_OP = OI.No_OP
                ) AS MC;
        END

        SELECT
                CASE 
                        WHEN O.FechaHora = @FECHA THEN 'NUEVA'
                        ELSE 'ANTERIOR'
                END AS Tipo,
                O.FechaHora,
                O.Descripcion,
                O.Observacion,
                U.Email
        FROM OP_PROCESOS_OBSERVACIONES O
        INNER JOIN USUARIOS U ON O.Usuario = U.CVE_USU
        WHERE O.Empresa = @EMPRESA AND O.No_OP = @CVE_ORDEN
        ORDER BY O.FechaHora;

        SELECT DISTINCT
                ID_Liberacion,
                No_Liberacion,
                No_OP
        FROM @RESULT_LIBERACIONES;
END
GO

