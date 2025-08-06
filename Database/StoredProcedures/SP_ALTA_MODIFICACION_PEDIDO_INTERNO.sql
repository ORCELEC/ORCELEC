USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_ALTA_MODIFICACION_PEDIDO_INTERNO]    Script Date: 06/08/2025 02:21:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ALTA_MODIFICACION_PEDIDO_INTERNO]
	@Empresa numeric(18,0),
	@Cve_Cliente numeric(18,0),
	@Nom_Cliente nvarchar(255),
    @No_Pedido numeric(18,0) output,
	@Clave_Proveedor nvarchar(100),
	@Cve_PedCliente nvarchar(100),
	@Contrato_Cliente nvarchar(100),
	@Orden_Surtimiento nvarchar(100),
    @DocumentacionEntrega text,
    @LlevaInspeccion bit,
    @QuienInspecciona nvarchar(255),
	@LugarInspeccion nvarchar(255),
	@HorarioInspeccion nvarchar(255),
    @AdmitenEntregaParcial bit,
    @PorcentajeSancionDiaria numeric(18,2),
	@PorcentajeSancionMaxima numeric(18,2),
	@PorcentajeIVA as numeric(18,2),
	@RegimenFiscal nvarchar(255),
	@UsoCFDI nvarchar(255),
	@MetodoPago nvarchar(255),
	@FormaPago nvarchar(255),
	@CuentaPago nvarchar(255),
	@BancoPago nvarchar(255),
	@TipoPedido nvarchar(50),
	@CondicionesPagoDias numeric(18,0),
	@CondicionesPagoTipoDias nvarchar(50),
	@CondicionesPagoCondicion nvarchar(100),
	@ObservacionesGeneralesProduccion nvarchar(max),
	@ObservacionesGeneralesLogistica nvarchar(max),
	@ObservacionesGeneralesFacturacion nvarchar(max),
    @USUARIO bigint,
    @COMPUTADORA nvarchar(50),
	@MOVIMIENTO NVARCHAR(50)
as
begin

	IF @MOVIMIENTO = 'ALTA'
	BEGIN
		--SE GENERA REGISTRO DE FOLIO DE ADMINISTRACIÓN
		DECLARE @NUM_FOLIO AS NUMERIC(18,0)
		
		select @NUM_FOLIO = isnull(max(Num_Folio),0) from FOLIOS_ADMINISTRACION

		set @NUM_FOLIO += 1

		INSERT INTO [dbo].[FOLIOS_ADMINISTRACION]
        (
			[Empresa]
           ,[Num_Folio]
           ,[Fecha]
           ,[Cve_Vendedor]
           ,[Cve_Cliente]
           ,[PedidosAsignados]
           ,[PedidosUtilizados]
           ,[TipoPedido]
           ,[Cve_PedCliente]
           ,[Fec_Pedido]
           ,[Fec_Recepcion]
           ,[Cve_Proveedor]
           ,[Orden_Surtimiento]
           ,[Contrato_Cliente]
           ,[StatusPedidos]
           ,[Status]
           ,[USUARIO]
           ,[FECHAHORA]
           ,[COMPUTADORA]
		)
		VALUES
        (
			@Empresa,
			@NUM_FOLIO,
			CONVERT(DATE,GETDATE()),
			@USUARIO,
			@Cve_Cliente,
			1,
            1,
			CASE @TipoPedido 
				WHEN 'CON CONTRATO' THEN 'N' 
				WHEN 'COMPRA' THEN 'C'
				WHEN 'MUESTRA' THEN 'M'
				ELSE
					NULL 
			END,
			@Cve_PedCliente,
			CONVERT(DATE,GETDATE()),
			CONVERT(DATE,GETDATE()),
			@Clave_Proveedor,
			@Orden_Surtimiento,
			@Contrato_Cliente,
			1,
			1,
			@USUARIO,
			GETDATE(),
			@COMPUTADORA
		)

		--INSERTA EL REGISTRO DEL PEDIDO_INTERNO

		select @No_Pedido = isnull(max(No_Pedido),0) from PEDIDO_INTERNO

		set @No_Pedido += 1

		INSERT INTO [dbo].[PEDIDO_INTERNO]
				   ([Empresa]
				   ,[Num_Folio]
				   ,[Cve_Cliente]
				   ,[Nom_Cliente]
				   ,[No_Pedido]
				   ,[DocumentacionEntrega]
				   ,[LlevaInspeccion]
				   ,[QuienInspecciona]
				   ,[LugarInspeccion]
				   ,[HorarioInspeccion]
				   ,[AdmitenEntregaParcial]
				   ,[PorcentajeSancionDiaria]
				   ,[PorcentajeSancionMaxima]
				   ,[PorcentajeIVA]
				   ,[RegimenFiscal]
				   ,[UsoCFDI]
				   ,[MetodoPago]
				   ,[FormaPago]
				   ,[CuentaPago]
				   ,[BancoPago]
				   ,[CondicionesPagoDias]
				   ,[CondicionesPagoTipoDias]
				   ,[CondicionesPagoCondicion]
				   ,[ObservacionesGeneralesProduccion]
				   ,[ObservacionesGeneralesLogistica]
				   ,[ObservacionesGeneralesFacturacion]
				   ,[Status]
				   ,[USUARIO]
				   ,[FECHAHORA]
				   ,[COMPUTADORA]
				   ,[ListoCalculoOP]
				   ,[CalculoOP])
			 VALUES(
				   @Empresa,
				   @Num_Folio,
				   @Cve_Cliente,
				   @Nom_Cliente,
				   @No_Pedido,
				   @DocumentacionEntrega,
				   @LlevaInspeccion,
				   @QuienInspecciona,
				   @LugarInspeccion,
				   @HorarioInspeccion,
				   @AdmitenEntregaParcial,
				   @PorcentajeSancionDiaria,
				   @PorcentajeSancionMaxima,
				   @PorcentajeIVA,
				   @RegimenFiscal,
				   @UsoCFDI,
				   @MetodoPago,
				   @FormaPago,
				   @CuentaPago,
				   @BancoPago,
				   @CondicionesPagoDias,
				   @CondicionesPagoTipoDias,
				   @CondicionesPagoCondicion,
				   @ObservacionesGeneralesProduccion,
				   @ObservacionesGeneralesLogistica,
				   @ObservacionesGeneralesFacturacion,
				   'EDICIÓN',
				   @USUARIO,
				   GETDATE(),
				   @COMPUTADORA,
				   0,
				   0
			)
			RETURN @No_Pedido
	END
	IF @MOVIMIENTO = 'MODIFICACION'
	BEGIN
		UPDATE
			PEDIDO_INTERNO
		SET 
			Cve_Cliente = @Cve_Cliente,
			Nom_Cliente = @Nom_Cliente,
			DocumentacionEntrega = @DocumentacionEntrega,
			LlevaInspeccion = @LlevaInspeccion,
			QuienInspecciona = @QuienInspecciona,
			LugarInspeccion = @LugarInspeccion,
			HorarioInspeccion = @HorarioInspeccion,
			AdmitenEntregaParcial = @AdmitenEntregaParcial,
			PorcentajeSancionDiaria = @PorcentajeSancionDiaria,
			PorcentajeSancionMaxima = @PorcentajeSancionMaxima,
			PorcentajeIVA = @PorcentajeIVA,
			RegimenFiscal = @RegimenFiscal,
			UsoCFDI = @UsoCFDI,
			MetodoPago = @MetodoPago,
			FormaPago = @FormaPago,
			CuentaPago = @CuentaPago,
			BancoPago = @BancoPago,
			CondicionesPagoDias = @CondicionesPagoDias,
			CondicionesPagoTipoDias = @CondicionesPagoTipoDias,
			@CondicionesPagoCondicion = @CondicionesPagoCondicion,
			ObservacionesGeneralesProduccion = @ObservacionesGeneralesProduccion,
			ObservacionesGeneralesLogistica = @ObservacionesGeneralesLogistica,
			ObservacionesGeneralesFacturacion = @ObservacionesGeneralesFacturacion,
			USUARIO = @USUARIO,
			FECHAHORA = GETDATE(),
			COMPUTADORA = @COMPUTADORA
		WHERE
			Empresa = @Empresa
		AND No_Pedido = @No_Pedido
		RETURN @No_Pedido
	END
END

GO

