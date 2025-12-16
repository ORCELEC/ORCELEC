USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[OP_AUTORIZAR_REGRESA_ASIGNACION]    Script Date: 15/12/2025 08:56:17 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OP_AUTORIZAR_REGRESA_ASIGNACION]
	@EMPRESA BIGINT,
	@NO_OP BIGINT,
	@ESTATUS NVARCHAR(50),
	@CVE_MAQUILADOR BIGINT,
	@OBSERVACIONES NVARCHAR(MAX),
	@USUARIO BIGINT,
	@COMPUTADORA NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	    DECLARE @NOM_MAQUILADORASIGNADO NVARCHAR(255)
        DECLARE @CVE_MAQUILADORORIGINAL BIGINT
        DECLARE @NOM_MAQUILADORORIGINAL NVARCHAR(255)
        DECLARE @CONSECUTIVO BIGINT
        DECLARE @OMITIRINVENTARIO BIT
        DECLARE @CONSECUTIVOINV BIGINT
        DECLARE @PEDIDOS_OP TABLE
        (
                No_Pedido BIGINT,
                UsarInventarioDisponible BIT
        )
        DECLARE @NO_PEDIDO_BASE BIGINT

    -- Insert statements for procedure here
	IF @ESTATUS = 'AUTORIZADA'
	BEGIN

		        SELECT @NOM_MAQUILADORASIGNADO = Encargado FROM MAQUILADOR WHERE Cve_Maquilador = @CVE_MAQUILADOR
                SELECT @CVE_MAQUILADORORIGINAL = Cve_Maquilador, @NOM_MAQUILADORORIGINAL = Nom_Maquilador FROM OP_ASIGNACION WHERE Empresa = @EMPRESA AND No_OP = @NO_OP

                INSERT INTO @PEDIDOS_OP
                (
                        No_Pedido,
                        UsarInventarioDisponible
                )
                SELECT DISTINCT
                        CAST(PIT.No_Pedido AS BIGINT) AS No_Pedido,
                        ISNULL(PI.UsarInventarioDisponible,0) AS UsarInventarioDisponible
                FROM PEDIDO_INTERNO_TALLAS PIT
                INNER JOIN PEDIDO_INTERNO PI
                        ON PI.Empresa = PIT.Empresa
                        AND PI.No_Pedido = PIT.No_Pedido
                WHERE PIT.Empresa = @EMPRESA
                AND PIT.No_OP = @NO_OP

               DECLARE @TOTAL_PEDIDOS_OP INT;
               DECLARE @PEDIDOS_SIN_INVENTARIO_DISP INT;

               SET @TOTAL_PEDIDOS_OP = 0;
               SET @PEDIDOS_SIN_INVENTARIO_DISP = 0;

               SELECT
                       @TOTAL_PEDIDOS_OP = COUNT(*),
                       @PEDIDOS_SIN_INVENTARIO_DISP = SUM(CASE WHEN UsarInventarioDisponible = 0 THEN 1 ELSE 0 END)
               FROM @PEDIDOS_OP;

               IF @TOTAL_PEDIDOS_OP > 0 AND @TOTAL_PEDIDOS_OP = @PEDIDOS_SIN_INVENTARIO_DISP
               BEGIN
                       SELECT TOP 1 @NO_PEDIDO_BASE = No_Pedido
                       FROM @PEDIDOS_OP
                       WHERE UsarInventarioDisponible = 0
                       ORDER BY No_Pedido;
               END
               ELSE
               BEGIN
                       SET @NO_PEDIDO_BASE = NULL;
               END

		IF @CVE_MAQUILADORORIGINAL <> @CVE_MAQUILADOR
		BEGIN--ACTUALIZA MAQUILADOR YA QUE SE SELECCIONO UNO DIFERENTE
			UPDATE
				OP_ASIGNACION
			SET 
				Cve_Maquilador = @CVE_MAQUILADOR,
				Nom_Maquilador = @NOM_MAQUILADORASIGNADO,
				Estatus = @ESTATUS,
				USUARIOAutorizo = @USUARIO,
				FECHAHORAAutorizo = GETDATE(),
				COMPUTADORAAutorizo = @COMPUTADORA
			WHERE
				Empresa = @EMPRESA
			AND No_OP = @NO_OP

			--OBTIENE EL ULTIMO CONSECUTIVO DE LAS OBSERVACIONES DEL PROCESO DE AUTORIZACIÓN
			SELECT @CONSECUTIVO = ISNULL(MAX(Consecutivo),0) FROM OP_OBSERVACIONESAUTORIZAR WHERE Empresa = @EMPRESA AND No_OP = @NO_OP

			--AUMENTE EN 1 EL CONSECUTIVO
			SET @CONSECUTIVO +=1

			--INSERTA EL REGISTRO EN OP_OBSERVACIONESAUTORIZAR
			INSERT INTO OP_OBSERVACIONESAUTORIZAR
			(
				Empresa,
				NO_OP,
				Consecutivo,
				TipoAutorizacion,
				Observaciones,
				Cve_MaquiladorOriginal,
				Nom_MaquiladorOriginal,
				Cve_MaquiladorAsignado,
				Nom_MaquiladorAsignado,
				USUARIO,
				FECHAHORA,
				COMPUTADORA
			)
			SELECT
				@EMPRESA,
				@NO_OP,
				@CONSECUTIVO,
				'AUTORIZADA',
				@OBSERVACIONES,
				@CVE_MAQUILADORORIGINAL,
				@NOM_MAQUILADORORIGINAL,
				@CVE_MAQUILADOR,
				@NOM_MAQUILADORASIGNADO,
				@USUARIO,
				GETDATE(),
				@COMPUTADORA
		END
		ELSE
		BEGIN
			UPDATE
				OP_ASIGNACION
			SET 
				Estatus = @ESTATUS,
				USUARIOAutorizo = @USUARIO,
				FECHAHORAAutorizo = GETDATE(),
				COMPUTADORAAutorizo = @COMPUTADORA
			WHERE
				Empresa = @EMPRESA
			AND No_OP = @NO_OP

			--OBTIENE EL ULTIMO CONSECUTIVO DE LAS OBSERVACIONES DEL PROCESO DE AUTORIZACIÓN
			SELECT @CONSECUTIVO = ISNULL(MAX(Consecutivo),0) FROM OP_OBSERVACIONESAUTORIZAR WHERE Empresa = @EMPRESA AND No_OP = @NO_OP

			--AUMENTE EN 1 EL CONSECUTIVO
			SET @CONSECUTIVO +=1

			--INSERTA EL REGISTRO EN OP_OBSERVACIONESAUTORIZAR
			INSERT INTO OP_OBSERVACIONESAUTORIZAR
			(
				Empresa,
				NO_OP,
				Consecutivo,
				TipoAutorizacion,
				Observaciones,
				Cve_MaquiladorOriginal,
				Nom_MaquiladorOriginal,
				Cve_MaquiladorAsignado,
				Nom_MaquiladorAsignado,
				USUARIO,
				FECHAHORA,
				COMPUTADORA
			)
			VALUES
			(
				@EMPRESA,
				@NO_OP,
				@CONSECUTIVO,
				'AUTORIZADA',
				@OBSERVACIONES,
				@CVE_MAQUILADORORIGINAL,
				@NOM_MAQUILADORORIGINAL,
				@CVE_MAQUILADORORIGINAL,
				@NOM_MAQUILADORORIGINAL,
				@USUARIO,
				GETDATE(),
				@COMPUTADORA
			)

		END

		       DECLARE @MOVIMIENTOS_BITACORA TABLE
               (
                       Cve_Prenda BIGINT,
                       Talla NVARCHAR(50),
                       No_Pedido BIGINT,
                       Cantidad BIGINT
               );

               DECLARE @MOVIMIENTOS_DETALLE TABLE
               (
                       Cve_Prenda BIGINT,
                       Talla NVARCHAR(50),
                       No_Pedido BIGINT,
                       CantidadAsignada BIGINT,
                       CantidadNoAsignada BIGINT,
                       UsaInventarioDisponible BIT
               );

               ;WITH CANTIDADES_PEDIDO AS
               (
                       SELECT
                               PIT.Cve_Prenda,
                               PIT.Talla,
                               CAST(PIT.No_Pedido AS BIGINT) AS No_Pedido,
                               SUM(CAST(ISNULL(PIT.Cantidad,0) AS BIGINT)) AS CantidadPedido,
                               SUM(CAST(ISNULL(RIPT.Cantidad,0) AS BIGINT)) AS CantidadReservada,
                               MAX(CASE WHEN ISNULL(PI.UsarInventarioDisponible,0) = 1 THEN 1 ELSE 0 END) AS UsaInventarioDisponible
                       FROM PEDIDO_INTERNO_TALLAS PIT
                       INNER JOIN PEDIDO_INTERNO PI
                               ON PI.Empresa = PIT.Empresa
                               AND PI.No_Pedido = PIT.No_Pedido
                       LEFT JOIN RESERVADO_INVENTARIO_PRODUCTO_TERMINADO RIPT
                               ON RIPT.Empresa = PIT.Empresa
                               AND RIPT.No_Pedido = PIT.No_Pedido
                               AND RIPT.Partida = PIT.Partida
                               AND RIPT.Cve_Prenda = PIT.Cve_Prenda
                               AND RIPT.LugarDeEntrega = PIT.LugarDeEntrega
                               AND RIPT.Prioridad = PIT.Prioridad
                               AND RIPT.Talla = PIT.Talla
                       WHERE PIT.Empresa = @EMPRESA
                       AND PIT.No_OP = @NO_OP
                       GROUP BY PIT.Cve_Prenda, PIT.Talla, PIT.No_Pedido
               ),
               INVENTARIO_BASE AS
               (
                       SELECT
                               PID.No_Pedido_Origen AS No_Pedido,
                               PID.Cve_Prenda,
                               PID.Talla,
                               SUM(CAST(ISNULL(PID.CantidadRegistrada,0) AS BIGINT)) AS CantidadRegistrada,
                               SUM(CAST(ISNULL(PID.CantidadAsignada,0) AS BIGINT)) AS CantidadAsignada
                       FROM PEDIDO_INTERNO_INVENTARIO_DISPONIBLE PID
                       WHERE PID.Empresa = @EMPRESA
                       AND PID.No_Pedido_Origen IN (SELECT DISTINCT No_Pedido FROM @PEDIDOS_OP WHERE UsarInventarioDisponible = 0)
                       GROUP BY PID.No_Pedido_Origen, PID.Cve_Prenda, PID.Talla
               )
               INSERT INTO @MOVIMIENTOS_DETALLE
               (
                       Cve_Prenda,
                       Talla,
                       No_Pedido,
                       CantidadAsignada,
                       CantidadNoAsignada,
                       UsaInventarioDisponible
               )
               SELECT
                       CP.Cve_Prenda,
                       CP.Talla,
                       CP.No_Pedido,
                       CASE
                               WHEN CP.UsaInventarioDisponible = 1 THEN
                                       CASE
                                               WHEN (CP.CantidadPedido - CP.CantidadReservada) > 0 THEN CAST(CP.CantidadPedido - CP.CantidadReservada AS BIGINT)
                                               ELSE 0
                                       END
                               ELSE CAST(ISNULL(IB.CantidadAsignada,0) AS BIGINT)
                       END AS CantidadAsignada,
                       CASE
                               WHEN CP.UsaInventarioDisponible = 1 THEN 0
                               ELSE
                                       CAST(
                                               CASE
                                                       WHEN ISNULL(IB.CantidadRegistrada, CP.CantidadPedido) - ISNULL(IB.CantidadAsignada,0) > 0 THEN
                                                               ISNULL(IB.CantidadRegistrada, CP.CantidadPedido) - ISNULL(IB.CantidadAsignada,0)
                                                       ELSE 0
                                               END AS BIGINT)
                       END AS CantidadNoAsignada,
                       CP.UsaInventarioDisponible
               FROM CANTIDADES_PEDIDO CP
               LEFT JOIN INVENTARIO_BASE IB
                       ON IB.No_Pedido = CP.No_Pedido
                       AND IB.Cve_Prenda = CP.Cve_Prenda
                       AND IB.Talla = CP.Talla;

               INSERT INTO @MOVIMIENTOS_BITACORA
               (
                       Cve_Prenda,
                       Talla,
                       No_Pedido,
                       Cantidad
               )
               SELECT
                       MD.Cve_Prenda,
                       MD.Talla,
                       MD.No_Pedido,
                       MD.CantidadAsignada
               FROM @MOVIMIENTOS_DETALLE MD
               WHERE MD.CantidadAsignada > 0;

               DECLARE @PRENDAS_OP TABLE
               (
                       Cve_Prenda BIGINT,
                       Talla NVARCHAR(50)
               );

               INSERT INTO @PRENDAS_OP
               SELECT DISTINCT
                       PIT.Cve_Prenda,
                       PIT.Talla
               FROM PEDIDO_INTERNO_TALLAS PIT
               WHERE PIT.Empresa = @EMPRESA
               AND PIT.No_OP = @NO_OP;

               IF NOT EXISTS (SELECT 1 FROM @PRENDAS_OP)
               BEGIN
                       INSERT INTO @PRENDAS_OP
                       SELECT DISTINCT
                               PEI.Cve_Prenda,
                               PEI.Talla
                       FROM PRENDA_ENTRADA_INVENTARIO PEI
                       WHERE PEI.Empresa = @EMPRESA
                       AND PEI.TipoEntrada = 'OP'
                       AND PEI.TipoEntradaNumero = @NO_OP;
               END

               IF EXISTS (SELECT 1 FROM @MOVIMIENTOS_BITACORA)
               BEGIN
                       DECLARE @TOTALES_INVENTARIO TABLE
                       (
                               Cve_Prenda BIGINT,
                               Talla NVARCHAR(50),
                               Cantidad BIGINT
                       );

                       INSERT INTO @TOTALES_INVENTARIO
                       (
                               Cve_Prenda,
                               Talla,
                               Cantidad
                       )
                       SELECT
                               Cve_Prenda,
                               Talla,
                               SUM(Cantidad) AS Cantidad
                       FROM @MOVIMIENTOS_BITACORA
                       GROUP BY Cve_Prenda, Talla;

                       UPDATE PIA
                       SET InventarioAsignado = CASE WHEN InventarioAsignado >= T.Cantidad THEN InventarioAsignado - T.Cantidad ELSE 0 END
                       FROM PRENDA_INVENTARIO_ALMACEN PIA
                       INNER JOIN @TOTALES_INVENTARIO T
                               ON PIA.Cve_Prenda = T.Cve_Prenda
                               AND PIA.Talla = T.Talla
                       WHERE PIA.Empresa = @EMPRESA
                       AND PIA.Almacen = 'TEMPORAL SIN OP';

                       MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
                       USING @TOTALES_INVENTARIO AS SRC
                               ON TARGET.Empresa = @EMPRESA
                               AND TARGET.Cve_Prenda = SRC.Cve_Prenda
                               AND TARGET.Talla = SRC.Talla
                               AND TARGET.Almacen = 'TEMPORAL CON OP'
                       WHEN MATCHED THEN
                               UPDATE SET TARGET.InventarioAsignado = TARGET.InventarioAsignado + SRC.Cantidad
                       WHEN NOT MATCHED THEN
                               INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
                               VALUES (@EMPRESA, SRC.Cve_Prenda, 'TEMPORAL CON OP', SRC.Talla, 0, SRC.Cantidad);

                       ;WITH MAXCONSECUTIVO AS
                       (
                               SELECT
                                       No_Pedido,
                                       MAX(Consecutivo) AS MaxConsecutivo
                               FROM PRENDA_INVENTARIO_BITACORA
                               WHERE Empresa = @EMPRESA
                               AND No_Pedido IN (SELECT DISTINCT No_Pedido FROM @MOVIMIENTOS_BITACORA)
                               GROUP BY No_Pedido
                       ),
                       MOVIMIENTOS AS
                       (
                               SELECT
                                       M.Cve_Prenda,
                                       M.Talla,
                                       M.No_Pedido,
                                       M.Cantidad,
                                       ISNULL(MC.MaxConsecutivo,0) AS MaxConsecutivo,
                                       ROW_NUMBER() OVER (PARTITION BY M.No_Pedido ORDER BY M.Cve_Prenda, M.Talla) AS RN
                               FROM @MOVIMIENTOS_BITACORA M
                               LEFT JOIN MAXCONSECUTIVO MC
                                       ON MC.No_Pedido = M.No_Pedido
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
                              @EMPRESA AS Empresa,
                              M.No_Pedido,
                              M.MaxConsecutivo + CA.ConsecutivoOffset AS Consecutivo,
                              M.Cve_Prenda,
                              M.Talla,
                              CA.TipoMovimiento,
                              CA.Almacen,
                              CA.TipoInventario,
                              CA.No_OP,
                              CA.Cve_Maquilador,
                              CA.Nom_Maquilador,
                              M.Cantidad,
                              0 AS CantidadAvance,
                              @USUARIO AS USUARIO,
                              GETDATE() AS FECHAHORA,
                              @COMPUTADORA AS COMPUTADORA
                      FROM MOVIMIENTOS M
                      CROSS APPLY
                      (
                              VALUES
                              ('SALIDA', 'TEMPORAL SIN OP', 'Inventario Asignado', NULL, NULL, NULL, (M.RN * 2) - 1),
                              ('ENTRADA', 'TEMPORAL CON OP', 'Inventario Asignado', @NO_OP, @CVE_MAQUILADOR, @NOM_MAQUILADORASIGNADO, (M.RN * 2))
                      ) CA (TipoMovimiento, Almacen, TipoInventario, No_OP, Cve_Maquilador, Nom_Maquilador, ConsecutivoOffset);
               END

               IF @NO_PEDIDO_BASE IS NOT NULL
               BEGIN
                       DECLARE @MOVIMIENTOS_NO_ASIGNADO TABLE
                       (
                               Cve_Prenda BIGINT,
                               Talla NVARCHAR(50),
                               Cantidad BIGINT
                       );

                       INSERT INTO @MOVIMIENTOS_NO_ASIGNADO
                       (
                               Cve_Prenda,
                               Talla,
                               Cantidad
                       )
                       SELECT
                               MD.Cve_Prenda,
                               MD.Talla,
                               SUM(MD.CantidadNoAsignada) AS Cantidad
                       FROM @MOVIMIENTOS_DETALLE MD
                       WHERE MD.No_Pedido = @NO_PEDIDO_BASE
                       AND MD.CantidadNoAsignada > 0
                       GROUP BY MD.Cve_Prenda, MD.Talla;

                       IF EXISTS (SELECT 1 FROM @MOVIMIENTOS_NO_ASIGNADO)
                       BEGIN
                               UPDATE PIA
                               SET InventarioNoAsignado = CASE WHEN InventarioNoAsignado >= M.Cantidad THEN InventarioNoAsignado - M.Cantidad ELSE 0 END
                               FROM PRENDA_INVENTARIO_ALMACEN PIA
                               INNER JOIN @MOVIMIENTOS_NO_ASIGNADO M
                                       ON PIA.Cve_Prenda = M.Cve_Prenda
                                       AND PIA.Talla = M.Talla
                               WHERE PIA.Empresa = @EMPRESA
                               AND PIA.Almacen = 'TEMPORAL SIN OP';

                               MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
                               USING @MOVIMIENTOS_NO_ASIGNADO AS SRC
                                       ON TARGET.Empresa = @EMPRESA
                                       AND TARGET.Cve_Prenda = SRC.Cve_Prenda
                                       AND TARGET.Talla = SRC.Talla
                                       AND TARGET.Almacen = 'TEMPORAL CON OP'
                               WHEN MATCHED THEN
                                       UPDATE SET TARGET.InventarioNoAsignado = TARGET.InventarioNoAsignado + SRC.Cantidad
                               WHEN NOT MATCHED THEN
                                       INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
                                       VALUES (@EMPRESA, SRC.Cve_Prenda, 'TEMPORAL CON OP', SRC.Talla, SRC.Cantidad, 0);

                               DECLARE @MAX_CONSECUTIVO_NO_ASIG BIGINT;
                               SELECT @MAX_CONSECUTIVO_NO_ASIG = ISNULL(MAX(Consecutivo),0)
                               FROM PRENDA_INVENTARIO_BITACORA
                               WHERE Empresa = @EMPRESA
                               AND No_Pedido = @NO_PEDIDO_BASE;

                               ;WITH MOVS_NO_ASIG AS
                               (
                                       SELECT
                                               M.Cve_Prenda,
                                               M.Talla,
                                               M.Cantidad,
                                               ROW_NUMBER() OVER (ORDER BY M.Cve_Prenda, M.Talla) AS RN
                                       FROM @MOVIMIENTOS_NO_ASIGNADO M
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
                                       @NO_PEDIDO_BASE,
                                       @MAX_CONSECUTIVO_NO_ASIG + CA.Offset,
                                       M.Cve_Prenda,
                                       M.Talla,
                                       CA.TipoMovimiento,
                                       CA.Almacen,
                                       CA.TipoInventario,
                                       CA.No_OP,
                                       CA.Cve_Maquilador,
                                       CA.Nom_Maquilador,
                                       M.Cantidad,
                                       0,
                                       @USUARIO,
                                       GETDATE(),
                                       @COMPUTADORA
                               FROM MOVS_NO_ASIG M
                               CROSS APPLY
                               (
                                       VALUES
                                       ('SALIDA', 'TEMPORAL SIN OP', 'Inventario no Asignado', NULL, NULL, NULL, (M.RN * 2) - 1),
                                       ('ENTRADA', 'TEMPORAL CON OP', 'Inventario no Asignado', @NO_OP, @CVE_MAQUILADOR, @NOM_MAQUILADORASIGNADO, (M.RN * 2))
                               ) CA (TipoMovimiento, Almacen, TipoInventario, No_OP, Cve_Maquilador, Nom_Maquilador, Offset);
                       END
               END

               IF EXISTS (
                       SELECT 1
                       FROM @MOVIMIENTOS_DETALLE
                       WHERE ISNULL(CantidadAsignada,0) > 0
                       OR ISNULL(CantidadNoAsignada,0) > 0
               )
               BEGIN
                       ;WITH RESUMEN AS
                       (
                               SELECT
                                       Cve_Prenda,
                                       Talla,
                                       SUM(CAST(ISNULL(CantidadAsignada,0) AS BIGINT)) AS CantidadAsignada,
                                       SUM(CAST(ISNULL(CantidadNoAsignada,0) AS BIGINT)) AS CantidadNoAsignada
                               FROM @MOVIMIENTOS_DETALLE
                               GROUP BY Cve_Prenda, Talla
                       ),
                       REFERENCIAS AS
                       (
                               SELECT
                                       Cve_Prenda,
                                       Talla,
                                       MIN(CAST(No_Pedido AS BIGINT)) AS No_PedidoReferencia
                               FROM @MOVIMIENTOS_DETALLE
                               WHERE No_Pedido IS NOT NULL
                               GROUP BY Cve_Prenda, Talla
                       )
                       MERGE OP_INVENTARIO_TEMPORAL AS TARGET
                       USING (
                               SELECT
                                       @EMPRESA AS Empresa,
                                       @NO_OP AS No_OP,
                                       R.Cve_Prenda,
                                       R.Talla,
                                       R.CantidadAsignada,
                                       R.CantidadNoAsignada,
                                       R.CantidadAsignada + R.CantidadNoAsignada AS CantidadOP,
                                       ISNULL(REF.No_PedidoReferencia, NULL) AS No_PedidoReferencia
                               FROM RESUMEN R
                               LEFT JOIN REFERENCIAS REF
                                       ON REF.Cve_Prenda = R.Cve_Prenda
                                       AND REF.Talla = R.Talla
                       ) AS SOURCE
                               ON TARGET.Empresa = SOURCE.Empresa
                               AND TARGET.No_OP = SOURCE.No_OP
                               AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
                               AND TARGET.Talla = SOURCE.Talla
                       WHEN MATCHED THEN
                               UPDATE SET
                                       TARGET.CantidadOP = SOURCE.CantidadOP,
                                       TARGET.CantidadAsignada = SOURCE.CantidadAsignada,
                                       TARGET.CantidadNoAsignada = SOURCE.CantidadNoAsignada,
                                       TARGET.CantidadLiberada = CASE
                                                                       WHEN TARGET.CantidadLiberada > SOURCE.CantidadOP THEN SOURCE.CantidadOP
                                                                       ELSE TARGET.CantidadLiberada
                                                                 END,
                                       TARGET.No_PedidoReferencia = SOURCE.No_PedidoReferencia,
                                       TARGET.FechaUltimaActualizacion = GETDATE()
                       WHEN NOT MATCHED THEN
                               INSERT
                               (
                                       Empresa,
                                       No_OP,
                                       Cve_Prenda,
                                       Talla,
                                       CantidadOP,
                                       CantidadAsignada,
                                       CantidadNoAsignada,
                                       CantidadLiberada,
                                       CantidadRecolectada,
                                       No_PedidoReferencia,
                                       FechaUltimaActualizacion
                               )
                               VALUES
                               (
                                       SOURCE.Empresa,
                                       SOURCE.No_OP,
                                       SOURCE.Cve_Prenda,
                                       SOURCE.Talla,
                                       SOURCE.CantidadOP,
                                       SOURCE.CantidadAsignada,
                                       SOURCE.CantidadNoAsignada,
                                       0,
                                       0,
                                       SOURCE.No_PedidoReferencia,
                                       GETDATE()
                               );
               END
        END

	IF @ESTATUS = 'REGRESARASIGNACION'
	BEGIN
		
		SELECT @CVE_MAQUILADORORIGINAL = Cve_Maquilador, @NOM_MAQUILADORORIGINAL = Nom_Maquilador FROM OP_ASIGNACION WHERE Empresa = @EMPRESA AND No_OP = @NO_OP
		
		--SOLO ACTUALIZA EL ESTATUS A PENDIENTE DE ASIGNACIÓN
		UPDATE
			OP_ASIGNACION
		SET 
			Asignada = 0,
			FechaFinalizacion = NULL,
			DiasProceso = 0,
			Estatus = 'PENDIENTE',
			Cve_Maquilador = NULL,
			Nom_Maquilador = NULL
		WHERE
			Empresa = @EMPRESA
		AND No_OP = @NO_OP

		--OBTIENE EL ULTIMO CONSECUTIVO DE LAS OBSERVACIONES DEL PROCESO DE AUTORIZACIÓN
		SELECT @CONSECUTIVO = ISNULL(MAX(Consecutivo),0) FROM OP_OBSERVACIONESAUTORIZAR WHERE Empresa = @EMPRESA AND No_OP = @NO_OP

		--AUMENTE EN 1 EL CONSECUTIVO
		SET @CONSECUTIVO +=1

		--INSERTA EL REGISTRO EN OP_OBSERVACIONESAUTORIZAR
		INSERT INTO OP_OBSERVACIONESAUTORIZAR
		(
			Empresa,
			NO_OP,
			Consecutivo,
			TipoAutorizacion,
			Observaciones,
			Cve_MaquiladorOriginal,
			Nom_MaquiladorOriginal,
			USUARIO,
			FECHAHORA,
			COMPUTADORA
		)
		SELECT
			@EMPRESA,
			@NO_OP,
			@CONSECUTIVO,
			'REGRESARASIGNACION',
			@OBSERVACIONES,
			@CVE_MAQUILADORORIGINAL,
			@NOM_MAQUILADORORIGINAL,
			@USUARIO,
			GETDATE(),
			@COMPUTADORA
	END
END
GO

