USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[PEDIDO_INTERNO_AUTORIZAR]    Script Date: 16/10/2025 01:50:38 p. m. ******/
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
                        @USARINVENTARIO BIT

                SELECT
                        @TIPOPEDIDO = FA.TipoPedido,
                        @USARINVENTARIO = ISNULL(PI.UsarInventarioDisponible,0)
                FROM PEDIDO_INTERNO PI
                INNER JOIN FOLIOS_ADMINISTRACION FA
                        ON PI.Empresa = FA.Empresa AND PI.Num_Folio = FA.Num_Folio
                WHERE PI.Empresa = @EMPRESA AND PI.No_Pedido = @NO_PEDIDO

                -- Variables de uso general para bitácoras y consecutivos
                DECLARE @NO_RESERVADO BIGINT = NULL,
                        @CONSECUTIVO BIGINT = 0

            -- Reserva inventario utilizando PRENDA_INVENTARIO_ALMACEN cuando se usa inventario disponible
            IF @TIPOPEDIDO = 'N' AND @USARINVENTARIO = 1
            BEGIN
                -- Obtiene el folio de reserva del pedido si ya existe; de lo contrario, genera uno nuevo solo una vez por pedido
                SELECT TOP 1 @NO_RESERVADO = No_Reservado
                FROM RESERVADO_INVENTARIO_PRODUCTO_TERMINADO
                WHERE Empresa = @EMPRESA
                  AND No_Pedido = @NO_PEDIDO
                ORDER BY No_Reservado

                IF @NO_RESERVADO IS NULL
                BEGIN
                        SELECT @NO_RESERVADO = ISNULL(MAX(No_Reservado),0) + 1
                        FROM RESERVADO_INVENTARIO_PRODUCTO_TERMINADO
                        WHERE Empresa = @EMPRESA
                END

                SELECT @CONSECUTIVO = ISNULL(MAX(Consecutivo),0)
                FROM PRENDA_INVENTARIO_BITACORA
                WHERE Empresa = @EMPRESA AND No_Pedido = @NO_PEDIDO

                DECLARE @SOLICITADO_RES TABLE(
                        Partida BIGINT,
                        Cve_Prenda BIGINT,
                        LugarDeEntrega BIGINT,
                        Prioridad BIGINT,
                        Talla NVARCHAR(50),
                        Cantidad BIGINT
                )

                -- Obtiene las prendas y tallas solicitadas en el pedido
                INSERT INTO @SOLICITADO_RES
                SELECT Partida, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, Cantidad
                FROM PEDIDO_INTERNO_TALLAS
                WHERE Empresa = @EMPRESA AND No_Pedido = @NO_PEDIDO

                DECLARE @Partida BIGINT, @Prenda BIGINT, @Lugar BIGINT, @Pri BIGINT, @Talla NVARCHAR(50), @Cant BIGINT
                -- Recorre cada partida para ir asignando el inventario disponible
                DECLARE CUR CURSOR FOR SELECT Partida, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, Cantidad FROM @SOLICITADO_RES ORDER BY Partida, Talla
                OPEN CUR
                FETCH NEXT FROM CUR INTO @Partida,@Prenda,@Lugar,@Pri,@Talla,@Cant
                WHILE @@FETCH_STATUS = 0
                BEGIN
                        DECLARE @Pendiente BIGINT = @Cant
                        DECLARE @AsignadoTotal BIGINT = 0
                        DECLARE @Alm NVARCHAR(50), @Disponible BIGINT, @Asignar BIGINT

                        -- Recalcula existencias en cada iteración y solo descuenta cantidades positivas
                        WHILE @Pendiente > 0
                        BEGIN
                                SET @Alm = NULL
                                SET @Disponible = 0

                                -- Selecciona el mejor almacén disponible priorizando producto terminado y evitando saldos no positivos
                                SELECT TOP 1
                                        @Alm = PIA.Almacen,
                                        @Disponible = ISNULL(PIA.InventarioNoAsignado, 0)
                                FROM PRENDA_INVENTARIO_ALMACEN PIA
                                WHERE PIA.Empresa = @EMPRESA
                                  AND PIA.Cve_Prenda = @Prenda
                                  AND PIA.Talla = @Talla
                                  AND ISNULL(PIA.InventarioNoAsignado, 0) > 0
                                ORDER BY
                                        CASE
                                                WHEN PIA.Almacen NOT IN ('TEMPORAL SIN OP','LIBERADA','RECOLECTADA') THEN 1
                                                WHEN PIA.Almacen = 'RECOLECTADA' THEN 2
                                                WHEN PIA.Almacen = 'LIBERADA' THEN 3
                                                WHEN PIA.Almacen = 'TEMPORAL SIN OP' THEN 4
                                                ELSE 5
                                        END,
                                        ISNULL(PIA.InventarioNoAsignado, 0) DESC,
                                        PIA.Almacen

                                -- Cuando ya no existe inventario disponible, se detiene el ciclo
                                IF @Alm IS NULL OR @Disponible <= 0
                                        BREAK

                                SET @Asignar = CASE WHEN @Pendiente < @Disponible THEN @Pendiente ELSE @Disponible END

                                IF @Asignar <= 0
                                        BREAK

                                -- Si por concurrencia el inventario cambió, vuelve a intentar con los nuevos saldos
                                UPDATE PIA
                                SET InventarioNoAsignado = ISNULL(PIA.InventarioNoAsignado,0) - @Asignar,
                                    InventarioAsignado = ISNULL(PIA.InventarioAsignado,0) + @Asignar
                                FROM PRENDA_INVENTARIO_ALMACEN PIA
                                WHERE PIA.Empresa=@EMPRESA AND PIA.Cve_Prenda=@Prenda AND PIA.Talla=@Talla AND PIA.Almacen=@Alm
                                  AND ISNULL(PIA.InventarioNoAsignado,0) >= @Asignar

                                IF @@ROWCOUNT = 0
                                        CONTINUE

                                -- Registra la salida del inventario no asignado
                                SET @CONSECUTIVO = @CONSECUTIVO + 1
                                INSERT INTO PRENDA_INVENTARIO_BITACORA
                                (Empresa, No_Pedido, Consecutivo, Cve_Prenda, Talla, TipoMovimiento, TipoInventario, Almacen, Cantidad, CantidadAvance, USUARIO, FECHAHORA, COMPUTADORA)
                                VALUES(@EMPRESA, @NO_PEDIDO, @CONSECUTIVO, @Prenda, @Talla, 'Salida', 'Inventario no Asignado', @Alm, @Asignar, 0, @USUARIO, GETDATE(), @COMPUTADORA)

                                -- Registra la entrada al inventario asignado
                                SET @CONSECUTIVO = @CONSECUTIVO + 1
                                INSERT INTO PRENDA_INVENTARIO_BITACORA
                                (Empresa, No_Pedido, Consecutivo, Cve_Prenda, Talla, TipoMovimiento, TipoInventario, Almacen, Cantidad, CantidadAvance, USUARIO, FECHAHORA, COMPUTADORA)
                                VALUES(@EMPRESA, @NO_PEDIDO, @CONSECUTIVO, @Prenda, @Talla, 'Entrada', 'Inventario Asignado', @Alm, @Asignar, 0, @USUARIO, GETDATE(), @COMPUTADORA)

                                SET @Pendiente = @Pendiente - @Asignar
                                SET @AsignadoTotal = @AsignadoTotal + @Asignar
                        END

                        -- Si queda pendiente por asignar, se carga al almacén TEMPORAL SIN OP
                        IF @Pendiente > 0
                        BEGIN
                                UPDATE PIA
                                SET PIA.InventarioAsignado = ISNULL(PIA.InventarioAsignado,0) + @Pendiente
                                FROM PRENDA_INVENTARIO_ALMACEN PIA
                                WHERE PIA.Empresa=@EMPRESA AND PIA.Cve_Prenda=@Prenda AND PIA.Almacen='TEMPORAL SIN OP' AND PIA.Talla=@Talla

                                IF @@ROWCOUNT = 0
                                BEGIN
                                        INSERT INTO PRENDA_INVENTARIO_ALMACEN
                                        (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
                                        VALUES(@EMPRESA, @Prenda, 'TEMPORAL SIN OP', @Talla, 0, @Pendiente)
                                END

                                SET @CONSECUTIVO = @CONSECUTIVO + 1
                                INSERT INTO PRENDA_INVENTARIO_BITACORA
                                (Empresa, No_Pedido, Consecutivo, Cve_Prenda, Talla, TipoMovimiento, TipoInventario, Almacen, Cantidad, CantidadAvance, USUARIO, FECHAHORA, COMPUTADORA)
                                VALUES(@EMPRESA, @NO_PEDIDO, @CONSECUTIVO, @Prenda, @Talla, 'Entrada', 'Inventario Asignado', 'TEMPORAL SIN OP', @Pendiente, 0, @USUARIO, GETDATE(), @COMPUTADORA)
                        END

                        -- Registra el total asignado en la tabla de reservas
                        IF @AsignadoTotal > 0
                        BEGIN
                                INSERT INTO RESERVADO_INVENTARIO_PRODUCTO_TERMINADO
                                (Empresa, No_Reservado, No_Pedido, Partida, Cve_Prenda, LugarDeEntrega, Prioridad, Talla, Cantidad, USUARIO, FECHAHORA, COMPUTADORA)
                                VALUES(@EMPRESA, @NO_RESERVADO, @NO_PEDIDO, @Partida, @Prenda, @Lugar, @Pri, @Talla, @AsignadoTotal, @USUARIO, GETDATE(), @COMPUTADORA)
                        END

                        FETCH NEXT FROM CUR INTO @Partida,@Prenda,@Lugar,@Pri,@Talla,@Cant
                END
                CLOSE CUR
                DEALLOCATE CUR
            END

            -- Acumula inventario no asignado en el almacén TEMPORAL SIN OP cuando no se usa inventario disponible
            IF @TIPOPEDIDO = 'N' AND @USARINVENTARIO = 0
            BEGIN
                DECLARE @SOLICITADO_TEMP TABLE(
                        Cve_Prenda BIGINT,
                        Talla NVARCHAR(50),
                        Cantidad BIGINT
                )

                -- Obtiene las cantidades solicitadas por prenda y talla
                INSERT INTO @SOLICITADO_TEMP
                SELECT PIT.Cve_Prenda, PIT.Talla, SUM(PIT.Cantidad) AS Cantidad
                FROM PEDIDO_INTERNO_TALLAS PIT
                WHERE PIT.Empresa = @EMPRESA AND PIT.No_Pedido = @NO_PEDIDO
                GROUP BY PIT.Cve_Prenda, PIT.Talla

                -- Actualiza el inventario no asignado existente en el almacén TEMPORAL SIN OP
                UPDATE PIA
                SET PIA.InventarioNoAsignado = ISNULL(PIA.InventarioNoAsignado,0) + S.Cantidad
                FROM PRENDA_INVENTARIO_ALMACEN PIA
                INNER JOIN @SOLICITADO_TEMP S
                        ON PIA.Empresa = @EMPRESA
                        AND PIA.Cve_Prenda = S.Cve_Prenda
                        AND PIA.Almacen = 'TEMPORAL SIN OP'
                        AND PIA.Talla = S.Talla

                -- Inserta nuevos registros si no existían en PRENDA_INVENTARIO_ALMACEN
                INSERT INTO PRENDA_INVENTARIO_ALMACEN
                (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
                SELECT @EMPRESA, S.Cve_Prenda, 'TEMPORAL SIN OP', S.Talla, S.Cantidad, 0
                FROM @SOLICITADO_TEMP S
                LEFT JOIN PRENDA_INVENTARIO_ALMACEN PIA
                        ON PIA.Empresa = @EMPRESA
                        AND PIA.Cve_Prenda = S.Cve_Prenda
                        AND PIA.Almacen = 'TEMPORAL SIN OP'
                        AND PIA.Talla = S.Talla
                WHERE PIA.Empresa IS NULL

                SELECT @CONSECUTIVO = ISNULL(MAX(Consecutivo),0)
                FROM PRENDA_INVENTARIO_BITACORA
                WHERE Empresa = @EMPRESA AND No_Pedido = @NO_PEDIDO

                -- Registra la entrada correspondiente en la bitácora
                INSERT INTO PRENDA_INVENTARIO_BITACORA
                (Empresa, No_Pedido, Consecutivo, Cve_Prenda, Talla, TipoMovimiento, TipoInventario, Almacen, Cantidad, CantidadAvance, USUARIO, FECHAHORA, COMPUTADORA)
                SELECT @EMPRESA, @NO_PEDIDO, ROW_NUMBER() OVER(ORDER BY S.Cve_Prenda, S.Talla) + @CONSECUTIVO,
                       S.Cve_Prenda, S.Talla, 'Entrada', 'Inventario no Asignado', 'TEMPORAL SIN OP', S.Cantidad, 0, @USUARIO, GETDATE(), @COMPUTADORA
                FROM @SOLICITADO_TEMP S
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

