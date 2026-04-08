USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_ALTA_MODIFICACION_ORDEN_COMPRA]    Script Date: 08/04/2026 01:02:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ALTA_MODIFICACION_ORDEN_COMPRA]
	@EMPRESA BIGINT,
	@NO_ORDENCOMPRA BIGINT,
	@PARTIDA BIGINT,
	@NO_PEDIDO BIGINT,
	@CLIENTE NVARCHAR(255),
	@CVE_PROVEEDOR BIGINT,
	@CVE_LUGARENTREGA BIGINT,
	@TIPOMATERIAL NVARCHAR(1),
	@CVEMATERIAL NVARCHAR(15),
	@DESCRIPCIONMATERIAL NVARCHAR(255),
	@CVE_UNIDAD BIGINT,
	@DESCRIPCIONUNIDAD NVARCHAR(100),
	@FACTOR NUMERIC(18,2),
	@CANTIDADORIGINAL NUMERIC(18,2),
	@CANTIDAD NUMERIC(18,2),
	@PRECIOUNITARIO NUMERIC(18,4),
	@SUBTOTAL NUMERIC(18,4),
	@IVA NUMERIC(18,4),
	@TOTAL NUMERIC(18,4),
	@TIPOMOVIMIENTO NVARCHAR(50),
	@USUARIO BIGINT,
	@COMPUTADORA NVARCHAR(50),
	@NO_OP BIGINT,
	@NO_ORDENCOMPRAOUTPUT BIGINT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE
		@CONTADOR BIGINT,
		@ESTATUS NVARCHAR(50),
		@CONSECUTIVO BIGINT,
		@FECHAPROMESAANT DATE,
		@CANTIDADPROMESAANT NUMERIC(18,2),
		@USUARIOANT BIGINT,
		@FECHAHORAANT DATETIME,
		@COMPUTADORAANT NVARCHAR(50),
		@CANTIDADCOMPRADAANT NUMERIC(18,2),
		@TIPOPEDIDO NVARCHAR(1)

	IF @TIPOMOVIMIENTO = 'ALTA'
	BEGIN
		SELECT @CONSECUTIVO = ISNULL(MAX(NO_ORDENCOMPRA),0) FROM ORDEN_COMPRA WHERE EMPRESA = @EMPRESA

		SET @CONSECUTIVO += 1

		--GUARDA LA PARTIDA DE LA ORDEN DE COMPRA
		INSERT INTO ORDEN_COMPRA
		(
			[Empresa]
           ,[No_OrdenCompra]
           ,[Partida]
           ,[No_Pedido]
		   ,[CLIENTE]
           ,[Cve_Proveedor]
           ,[Nom_Proveedor]
           ,[ProveedorRFC]
           ,[ProveedorCalle]
           ,[ProveedorColonia]
           ,[ProveedorCiudad]
           ,[ProveedorlMunDel]
           ,[ProveedorEstado]
           ,[ProveedorCP]
           ,[ProveedorTelefono]
           ,[ProveedorFax]
           ,[ProveedorCelular]
           ,[ProveedorAtencion]
           ,[ProveedorViaEmbarque]
           ,[ProveedorCondicionesPago]
           ,[Cve_LugarEntrega]
           ,[LugarEntregaNombre]
           ,[LugarEntregaRFC]
           ,[LugarEntregaCalle]
           ,[LugarEntregaColonia]
           ,[LugarEntregaDM]
           ,[LugarEntregaEstado]
           ,[LugarEntregaCiudad]
           ,[LugarEntregaCP]
           ,[LugarEntregaTelefono]
           ,[LugarEntregaFax]
           ,[LugarEntregaAtencion]
           ,[TipoMaterial]
           ,[Cve_Material]
           ,[DescripcionMaterial]
           ,[Cve_Unidad]
           ,[DescripcionUnidad]
           ,[Factor]
           ,[CantidadOriginal]
           ,[Cantidad]
           ,[PrecioUnitario]
		   ,[Subtotal]
		   ,[IVA]
		   ,[Total]
           ,[Status]
		   ,[Recibido]
		   ,[CantidadDisponible]
		   ,[No_OP]
           ,[USUARIO]
           ,[FECHAHORA]
           ,[COMPUTADORA]
		)
		SELECT
			@EMPRESA,
			CASE WHEN @PARTIDA = 1 THEN	@CONSECUTIVO ELSE @NO_ORDENCOMPRA END,
			@PARTIDA,
			@NO_PEDIDO,
			@CLIENTE,
			P.Cve_Proveedor,
			P.Nom_Proveedor,
			P.RFC,
            P.Calle,
            P.Colonia,
            P.Ciudad,
            P.MunDel,
            P.Estado,
            P.CP,
            P.Telefono,
            P.Fax,
            P.Celular,
            P.Atencion,
            P.ViaEmbarque,
            P.CondPago,
            LE.Cve_LugarEntrega,
            LE.Nombre,
            LE.RFC,
            LE.Calle,
            LE.Colonia,
            LE.DelMun,
            LE.Estado,
            LE.Ciudad,
            LE.CP,
            LE.Telefono,
            LE.Fax,
            LE.Atencion,
			@TIPOMATERIAL,
			@CVEMATERIAL,
			@DESCRIPCIONMATERIAL,
            @CVE_UNIDAD,
            @DESCRIPCIONUNIDAD,
            @FACTOR,
            @CANTIDADORIGINAL,
            @CANTIDAD,
            @PRECIOUNITARIO,
			@SUBTOTAL,
			@IVA,
			@TOTAL,
            'CREADA',
			0,
			CASE WHEN ((@CANTIDAD*@FACTOR)-@CANTIDADORIGINAL)>0 THEN ((@CANTIDAD*@FACTOR)-@CANTIDADORIGINAL) ELSE 0 END,
			@NO_OP,
	        @USUARIO,
            GETDATE(),
            @COMPUTADORA
		FROM
			PROVEEDOR P,
			LUGAR_ENTREGA LE
		WHERE
			P.Cve_Proveedor = @CVE_PROVEEDOR
		AND LE.Cve_LugarEntrega = @CVE_LUGARENTREGA

		--GUARDA LA INFORMACIÓN DE LA ORDEN DE COMPRA EN LA TABLA SUGERIDO_COMPRA_ORDEN_COMPRA
		IF @NO_PEDIDO <> 0
		BEGIN
			SELECT @TIPOPEDIDO = FA.TipoPedido FROM PEDIDO_INTERNO PI,FOLIOS_ADMINISTRACION FA WHERE PI.Empresa = @EMPRESA AND PI.No_Pedido = @NO_PEDIDO AND FA.Empresa = PI.Empresa AND FA.Num_Folio = PI.Num_Folio

			IF @TIPOPEDIDO NOT IN ('C')
			BEGIN
			
				INSERT INTO SUGERIDO_COMPRA_ORDEN_COMPRA
				(
					Empresa,
					No_Pedido,
					TipoMaterial,
					Cve_Material,
					No_OrdenCompra,
					Partida_OrdenCompra,
					Estatus_OrdenCompra
				)
				VALUES(
					@EMPRESA,
					@NO_PEDIDO,
					@TIPOMATERIAL,
					@CVEMATERIAL,
					CASE WHEN @PARTIDA = 1 THEN	@CONSECUTIVO ELSE @NO_ORDENCOMPRA END,
					@PARTIDA,
					'CREADA'
				)
			END
		END

		--ACTUALIZA EL CAMPO CANTIDADCOMPRADA
		UPDATE
			SUGERIDO_COMPRA
		SET
			CantidadComprada = ISNULL(CantidadComprada,0)+(@CANTIDAD*@FACTOR)
		WHERE
			Empresa = @EMPRESA
		AND No_Pedido = @NO_PEDIDO
		AND TipoMaterial = @TIPOMATERIAL
		AND Cve_Material = @CVEMATERIAL
		AND Cantidad = @CANTIDADORIGINAL
		AND No_OP = @NO_OP

		--ACTUALIZA EL ESTATUS DE LA PARTIDA CUANDO YA SE COMPRO COMPLETA LA PARTIDA DEL SUGERIDO DE COMPRA
		UPDATE
			SUGERIDO_COMPRA
		SET
			Status = 'COMPRADO'
		WHERE
			Empresa = @EMPRESA
		AND No_Pedido = @NO_PEDIDO
		AND TipoMaterial = @TIPOMATERIAL
		AND Cve_Material = @CVEMATERIAL
		AND No_OP = @NO_OP
		AND Cantidad = @CANTIDADORIGINAL
		AND CantidadComprada >= Cantidad

		IF @PARTIDA = 1
			SET @NO_ORDENCOMPRAOUTPUT = @CONSECUTIVO
		IF @PARTIDA > 1
			SET @NO_ORDENCOMPRAOUTPUT = @NO_ORDENCOMPRA
	END
	----TERMINA CODIGO PARA DAR DE ALTA
	IF @TIPOMOVIMIENTO = 'MODIFICACION'
	BEGIN
		--RECUPERA EL VALOR COMPRADO ANTERIOR
		SELECT
			@CANTIDADCOMPRADAANT = Cantidad*Factor
		FROM
			ORDEN_COMPRA
		WHERE
			Empresa = @EMPRESA
		AND No_OrdenCompra = @NO_ORDENCOMPRA
		AND Partida = @PARTIDA
		
		--ACTUALIZA ORDEN DE COMPRA
		UPDATE
			ORDEN_COMPRA
		SET
			Cve_Proveedor = P.Cve_Proveedor,
			Nom_Proveedor = P.Nom_Proveedor,
			ProveedorRFC = P.RFC,
			ProveedorCalle = P.Calle,
			ProveedorColonia = P.Colonia,
            ProveedorCiudad = P.Ciudad,
            ProveedorlMunDel = P.MunDel,
            ProveedorEstado = P.Estado,
            ProveedorCP = P.CP,
            ProveedorTelefono = P.Telefono,
            ProveedorFax = P.Fax,
            ProveedorCelular = P.Celular,
            ProveedorAtencion = P.Atencion,
            ProveedorViaEmbarque = P.ViaEmbarque,
            ProveedorCondicionesPago = P.CondPago,
            Cve_LugarEntrega = LE.Cve_LugarEntrega,
            LugarEntregaNombre = LE.Nombre,
            LugarEntregaRFC = LE.RFC,
            LugarEntregaCalle = LE.Calle,
            LugarEntregaColonia = LE.Colonia,
            LugarEntregaDM = LE.DelMun,
            LugarEntregaEstado = LE.Estado,
            LugarEntregaCiudad = LE.Ciudad,
            LugarEntregaCP = LE.CP,
            LugarEntregaTelefono = LE.Telefono,
            LugarEntregaFax = LE.Fax,
            LugarEntregaAtencion = LE.Atencion,
            TipoMaterial = @TIPOMATERIAL,
            Cve_Material = @CVEMATERIAL,
            DescripcionMaterial = @DESCRIPCIONMATERIAL,
            Cve_Unidad = @CVE_UNIDAD,
            DescripcionUnidad = @DESCRIPCIONUNIDAD,
            Factor = @FACTOR,
            CantidadOriginal = @CANTIDADORIGINAL,
            Cantidad = @CANTIDAD,
            PrecioUnitario = @PRECIOUNITARIO,
		    Subtotal = @SUBTOTAL,
		    IVA = @IVA,
		    Total = @TOTAL,
			CantidadDisponible = CASE WHEN ((@CANTIDAD*@FACTOR)-@CANTIDADORIGINAL)>0 THEN ((@CANTIDAD*@FACTOR)-@CANTIDADORIGINAL) ELSE 0 END,
			USUARIO = @USUARIO,
            FECHAHORA = GETDATE(),
			COMPUTADORA = @COMPUTADORA
		FROM
			PROVEEDOR P,
			LUGAR_ENTREGA LE
		WHERE
			ORDEN_COMPRA.Empresa = @EMPRESA
		AND ORDEN_COMPRA.No_OrdenCompra = @NO_ORDENCOMPRA
		AND ORDEN_COMPRA.Partida = @PARTIDA
		AND	P.Cve_Proveedor = @CVE_PROVEEDOR
		AND LE.Cve_LugarEntrega = @CVE_LUGARENTREGA

		--ACTUALIZA LA CANTIDAD COMPRADA DEL SUGERIDO DE COMPRA SI ES QUE HUBO CAMBIO
		IF @CANTIDADCOMPRADAANT <> @CANTIDAD 
		BEGIN
			--ACTUALIZA EL CAMPO CANTIDADCOMPRADA
			UPDATE
				SUGERIDO_COMPRA
			SET
				CantidadComprada = ISNULL(CantidadComprada,0)-@CANTIDADCOMPRADAANT+(@CANTIDAD*@FACTOR)
			WHERE
				Empresa = @EMPRESA
			AND No_Pedido = @NO_PEDIDO
			AND TipoMaterial = @TIPOMATERIAL
			AND Cve_Material = @CVEMATERIAL
			AND Cantidad = @CANTIDADORIGINAL
			AND No_OP = @NO_OP

			--ACTUALIZA EL ESTATUS DE LA PARTIDA CUANDO YA SE COMPRO COMPLETA LA PARTIDA DEL SUGERIDO DE COMPRA
			UPDATE
				SUGERIDO_COMPRA
			SET
				Status = 'COMPRADO'
			WHERE
				Empresa = @EMPRESA
			AND No_Pedido = @NO_PEDIDO
			AND TipoMaterial = @TIPOMATERIAL
			AND Cve_Material = @CVEMATERIAL
			AND No_OP = @NO_OP
			AND Cantidad = @CANTIDADORIGINAL
			AND CantidadComprada >= Cantidad

			UPDATE
				SUGERIDO_COMPRA
			SET
				Status = 'PENDIENTE'
			WHERE
				Empresa = @EMPRESA
			AND No_Pedido = @NO_PEDIDO
			AND TipoMaterial = @TIPOMATERIAL
			AND Cve_Material = @CVEMATERIAL
			AND No_OP = @NO_OP
			AND Cantidad = @CANTIDADORIGINAL
			AND CantidadComprada < Cantidad
		END
		SET @NO_ORDENCOMPRAOUTPUT = @NO_ORDENCOMPRA
	END
END
GO

