USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[PEDIDO_INTERNO_AUTORIZAR]    Script Date: 13/08/2025 11:39:51 a. m. ******/
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
			@OMITIRINVENTARIO BIT

		SELECT 
			@TIPOPEDIDO = FA.TipoPedido,
            @OMITIRINVENTARIO = ISNULL(PI.OmitirInventario,0)
        FROM PEDIDO_INTERNO PI
        INNER JOIN FOLIOS_ADMINISTRACION FA
			ON PI.Empresa = FA.Empresa AND PI.Num_Folio = FA.Num_Folio
			WHERE PI.Empresa = @EMPRESA AND PI.No_Pedido = @NO_PEDIDO
            
	    IF @TIPOPEDIDO = 'N' AND @OMITIRINVENTARIO = 0
        BEGIN
            DECLARE @NO_RESERVADO BIGINT

            SELECT @NO_RESERVADO = ISNULL(MAX(No_Reservado),0)
            FROM RESERVADO_INVENTARIO_PRODUCTO_TERMINADO
            WHERE Empresa = @EMPRESA

            ;WITH DISPONIBLE AS (
                SELECT
                        PIT.Partida,
                        PIT.Cve_Prenda,
                        PIT.LugarDeEntrega,
                        PIT.Prioridad,
                        PIT.Talla,
                        PIT.Cantidad,
                        ISNULL(IPT.Cantidad,0) AS Disponible
                FROM PEDIDO_INTERNO_TALLAS PIT
                LEFT JOIN PRENDA_INVENTARIO IPT
                    ON IPT.Empresa = PIT.Empresa
                AND IPT.Cve_Prenda = PIT.Cve_Prenda
                AND IPT.Talla = PIT.Talla
                WHERE PIT.Empresa = @EMPRESA AND PIT.No_Pedido = @NO_PEDIDO
            )
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
                Cantidad
            )
            SELECT
                @EMPRESA,
                ROW_NUMBER() OVER (ORDER BY Partida, Talla) + @NO_RESERVADO,
                @NO_PEDIDO,
                Partida,
                Cve_Prenda,
                LugarDeEntrega,
                Prioridad,
                Talla,
                CASE WHEN Disponible >= Cantidad THEN Cantidad ELSE Disponible END
            FROM DISPONIBLE
            WHERE Disponible > 0

            ;WITH RESERVAS AS (
                SELECT Cve_Prenda, Talla,
                        SUM(CASE WHEN Disponible >= Cantidad THEN Cantidad ELSE Disponible END) AS Cantidad
                FROM DISPONIBLE
                WHERE Disponible > 0
                GROUP BY Cve_Prenda, Talla
            )
            UPDATE IPT
            SET IPT.Cantidad = IPT.Cantidad - R.Cantidad
            FROM PRENDA_INVENTARIO IPT
            INNER JOIN RESERVAS R
                ON IPT.Empresa = @EMPRESA
                AND IPT.Cve_Prenda = R.Cve_Prenda
                AND IPT.Talla = R.Talla
        END

        IF @TIPOPEDIDO NOT IN ('C','L')
        BEGIN
            --Explosiona pedido
            EXEC SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA @EMPRESA,@NO_PEDIDO
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

