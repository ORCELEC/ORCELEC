USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[ORDEN_COMPRA_RECIBO_GENERACION_REMISIONES]    Script Date: 17/07/2025 12:18:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ORDEN_COMPRA_RECIBO_GENERACION_REMISIONES]
	-- Add the parameters for the stored procedure here
--DECLARE
	@EMPRESA BIGINT,
	@NO_ORDENCOMPRA BIGINT,
	@PARTIDA_OC BIGINT,
	@NO_PARCIALIDAD BIGINT,
	@USUARIO BIGINT,
	@COMPUTADORA NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
--SET	@EMPRESA = 1
--SET	@NO_ORDENCOMPRA = 1699
--SET	@PARTIDA_OC = 1
--SET	@NO_PARCIALIDAD = 1
--SET @USUARIO = 0
--SET @COMPUTADORA = 'ANALISISUNO'

	SET NOCOUNT ON;
    -- Insert statements for procedure here
	--HAY DOS CONDICIONES PARA PODER GENERAR LAS REMISIONES DE LA PARCIALIDAD, QUE ESTAS SE HAYAN
	--RECIBIDO DE MANERA INCOMPLETA O COMPLETA, SI ES COMPLETA, ENTONCES SE GENERAN LAS REMISIONES
	--DIRECTAS PORQUE ES LO QUE CUBRE Y COMO SE ASIGNO EN LA ORDEN_COMPRA_ASIGNACION_ITERACIONES.
	--SI ES INCOMPLETA, SE TIENE QUE VER PRIMERO CUANTO SE RECIBIÓ PARA PODER REPARTIR EN LAS REMISIONES

	DECLARE @TRAN_STARTED BIT
	SET @TRAN_STARTED = 0
	BEGIN TRY

		BEGIN TRANSACTION
		SET @TRAN_STARTED = 1
		---SE VERIFICA CUANDO SE RECIBIÓ DE LA PARCIALIDAD
		DECLARE
			@CANTIDAD_RECIBIDA NUMERIC(18,2),
			@CANTIDAD_PARA_REMISIONES NUMERIC(18,2),
			@No_Entrega AS BIGINT,
			@CantidadDisponibleRemision numeric(18,2),
			@Factor numeric(18,2),
			@NO_MOVIMIENTO BIGINT,
			@NO_OP BIGINT,
			@CVE_MAQUILADOR BIGINT,
			@TIPOMATERIAL NVARCHAR(1),
			@CVE_MATERIAL NVARCHAR(50),
			@CANTIDAD_A_REMISIONAR NUMERIC(18,2),
			@SALDOANTERIOR AS NUMERIC(18,2),
			@NumeroInicial AS INT

		SELECT
			@CANTIDAD_RECIBIDA = SUM(OC.Factor*OCFPR.CantidadDisponibleRemision)
		FROM
			ORDEN_COMPRA OC,
			ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR
		WHERE
			OC.Empresa = @EMPRESA
		AND OC.No_OrdenCompra = @NO_ORDENCOMPRA
		AND OC.Partida = @PARTIDA_OC
		AND OCFPR.Empresa = OC.Empresa
		AND OCFPR.No_OrdenCompra = OC.No_OrdenCompra
		AND OCFPR.Partida = OC.Partida
		AND OCFPR.No_Parcialidad = @NO_PARCIALIDAD

		CREATE TABLE #CANTIDAD_A_REMISIONAR
		(
			NO_OP BIGINT,
			CVE_MAQUILADOR BIGINT,
			TIPOMATERIAL NVARCHAR(1),
			CVE_MATERIAL NVARCHAR(50),
			CANTIDAD NUMERIC(18,2),
			CANTIDAD_FINAL_A_REMISIONAR NUMERIC(18,2)
		)

		CREATE TABLE #REMISIONES_CREADAS
		(
			NO_REMISION BIGINT
		)

		INSERT INTO #CANTIDAD_A_REMISIONAR
		(
			NO_OP,
			CVE_MAQUILADOR,
			TIPOMATERIAL,
			CVE_MATERIAL,
			CANTIDAD,
			CANTIDAD_FINAL_A_REMISIONAR
		)
		SELECT 
			PIT.No_OP,
			OPA.Cve_Maquilador,
			OCAI.TipoMaterial,
			OCAI.Cve_Material,
			OPEM.Cantidad,
			OPEM.Cantidad+(SELECT ISNULL(SUM(OPEMI.Cantidad),0) FROM OP_EXPLOSION_MATERIALES_INSPECTOR OPEMI WHERE OPEMI.Empresa = @EMPRESA AND OPEMI.No_OP = PIT.No_OP AND OPEMI.TipoMovimiento = 'FALTANTE' AND OPEMI.TipoMaterial = OCAI.TipoMaterial AND OPEMI.Cve_Material = OCAI.Cve_Material)-(SELECT ISNULL(SUM(RM.Cantidad),0) FROM REMISION_MATERIAL RM WHERE RM.Empresa = PIT.Empresa AND RM.No_OP = PIT.No_OP AND RM.TipoMaterial = OCAI.TipoMaterial AND RM.Cve_Material = OCAI.Cve_Material AND RM.Estatus = 'AUTORIZADA') AS CANTIDAD_FINAL_A_REMISIONAR
		FROM 
			PEDIDO_INTERNO_TALLAS PIT,
			ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI,
			OP_EXPLOSION_MATERIALES OPEM,
			PEDIDO_INTERNO PI,
			OP_ASIGNACION OPA
		WHERE 
			PIT.Empresa = @EMPRESA
		AND PIT.No_Pedido = OCAI.No_Pedido
		AND OCAI.Empresa = PIT.Empresa 
		AND OCAI.No_Pedido = PIT.No_Pedido 
		AND OCAI.No_OrdenCompra = @NO_ORDENCOMPRA
		AND OCAI.Partida = @PARTIDA_OC
		AND OCAI.No_Parcialidad = @NO_PARCIALIDAD
		AND OCAI.Cve_Prenda = PIT.Cve_Prenda 
		AND OCAI.LugarEntrega = PIT.LugarDeEntrega 
		AND OCAI.Prioridad = PIT.Prioridad
		AND OPEM.Empresa = PIT.Empresa 
		AND OPEM.No_Pedido = PIT.No_Pedido 
		AND OPEM.No_OP = PIT.No_OP 
		AND OPEM.TipoMaterial = OCAI.TipoMaterial 
		AND OPEM.Cve_Material = OCAI.Cve_Material
		AND PI.Empresa = PIT.Empresa 
		AND PI.No_Pedido = PIT.No_Pedido 
		AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
		AND OPA.Empresa = PIT.Empresa 
		AND OPA.No_OP = PIT.No_OP
		AND OPA.Estatus = 'AUTORIZADA'
		GROUP BY 
			PIT.Empresa,
			PIT.No_OP,
			OPA.Cve_Maquilador,
			OCAI.TipoMaterial,
			OCAI.Cve_Material,
			OPEM.Cantidad
		ORDER BY 
			OCAI.TipoMaterial,
			OCAI.Cve_Material
		
		DELETE #CANTIDAD_A_REMISIONAR WHERE CANTIDAD_FINAL_A_REMISIONAR <= 0
		
		SELECT
			@CANTIDAD_PARA_REMISIONES = ISNULL(SUM(CR.CANTIDAD_FINAL_A_REMISIONAR),0)
		FROM 
			#CANTIDAD_A_REMISIONAR CR

		IF @CANTIDAD_RECIBIDA >= @CANTIDAD_PARA_REMISIONES
		BEGIN
			SELECT @NumeroInicial = ISNULL(MAX(NO_REMISION), 0) FROM REMISION_MATERIAL;
		
			--SE GENERAN LAS REMISIONES CON LA CANTIDAD DE LA OP
			INSERT INTO [dbo].[REMISION_MATERIAL]
	        (
				[Empresa]
			   ,[No_Remision]
			   ,[Partida]
			   ,[FechaHoraRemision]
			   ,[TipoDestinatario]
			   ,[Cve_Destinatario]
			   ,[RazonSocialDestinatario]
			   ,[RFCDestinatario]
			   ,[Calle]
			   ,[Colonia]
			   ,[Municipio]
			   ,[CP]
			   ,[Ciudad]
			   ,[Estado]
			   ,[Telefono]
			   ,[Celular]
			   ,[Email]
			   ,[Contacto]
			   ,[TelContacto]
			   ,[No_OP]
			   ,[No_Pedido]
			   ,[No_OrdenCompra]
			   ,[OC_Partida]
			   ,[OC_No_Parcialidad]
			   ,[Cantidad]
			   ,[Descripcion]
			   ,[TipoMaterial]
			   ,[Cve_Material]
			   ,[Cve_Tela]
			   ,[Cve_Grupo]
			   ,[Cve_Habilitacion]
			   ,[PrecioU]
			   ,[PorcentajeIVA]
			   ,[Subtotal_Partida]
			   ,[IVA_Partida]
			   ,[Total_Partida]
			   ,[Subtotal_Remision]
			   ,[IVA_Remision]
			   ,[Total_Remision]
			   ,[ImporteEnLetra]
			   ,[CveUnidadMedida]
			   ,[UnidadMedida]
			   ,[Estatus]
			   ,[Impresa]
			   ,[USUARIO]
			   ,[FECHAHORA]
			   ,[COMPUTADORA]
			)
			SELECT 
				PIT.Empresa,
				@NumeroInicial + ROW_NUMBER() OVER (ORDER BY OPA.NO_OP),
				1,
				GETDATE(),
				'Maquilador',
				M.Cve_Maquilador,
				M.Encargado + '/' + M.RazonSocial,
				M.RFC,
				M.Calle,
				M.Colonia,
				M.DelMun,
				M.CP,
				M.Entidad,
				M.Estado,
				M.Telefono,
				M.Celular,
				STUFF((
					SELECT ', ' + MC.Email
					FROM MAQUILADOR_CORREO MC
					WHERE M.CVE_MAQUILADOR = MC.CVE_MAQUILADOR
					FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Correos,
				M.Encargado,
				M.Telefono,
				OPA.No_OP,
				PIT.No_Pedido,
				OCAI.No_OrdenCompra,
				OCAI.Partida,
				OCAI.No_Parcialidad,
				CAR.CANTIDAD_FINAL_A_REMISIONAR,
				OCAI.DescripcionMaterial,
				OCAI.TipoMaterial,
				OCAI.Cve_Material,
				OPEM.Cve_Tela,
				OPEM.Cve_Grupo,
				OPEM.Cve_Habilitacion,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				'',
				1,
				'PIEZAS',
				'AUTORIZADA',
				0,
				@USUARIO,
				GETDATE(),
				@COMPUTADORA
			FROM 
				#CANTIDAD_A_REMISIONAR CAR,
				PEDIDO_INTERNO_TALLAS PIT,
				ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI,
				OP_EXPLOSION_MATERIALES OPEM,
				PEDIDO_INTERNO PI,
				OP_ASIGNACION OPA,
				MAQUILADOR M
				LEFT JOIN
					MAQUILADOR_CORREO MC
				ON
					MC.Cve_Maquilador = M.Cve_Maquilador
			WHERE 
				PIT.Empresa = @EMPRESA
			AND PIT.No_Pedido = OCAI.No_Pedido
			AND OCAI.Empresa = PIT.Empresa 
			AND OCAI.No_Pedido = PIT.No_Pedido 
			AND OCAI.No_OrdenCompra = @NO_ORDENCOMPRA
			AND OCAI.Partida = @PARTIDA_OC
			AND OCAI.No_Parcialidad = @NO_PARCIALIDAD
			AND OCAI.Cve_Prenda = PIT.Cve_Prenda 
			AND OCAI.LugarEntrega = PIT.LugarDeEntrega 
			AND OCAI.Prioridad = PIT.Prioridad
			AND OPEM.Empresa = PIT.Empresa 
			AND OPEM.No_Pedido = PIT.No_Pedido 
			AND OPEM.No_OP = PIT.No_OP 
			AND OPEM.TipoMaterial = OCAI.TipoMaterial 
			AND OPEM.Cve_Material = OCAI.Cve_Material
			AND PI.Empresa = PIT.Empresa 
			AND PI.No_Pedido = PIT.No_Pedido 
			AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
			AND OPA.Empresa = PIT.Empresa 
			AND OPA.No_OP = PIT.No_OP
			AND M.Cve_Maquilador = OPA.Cve_Maquilador
			AND OPA.Estatus = 'AUTORIZADA'
			AND CAR.NO_OP = OPA.No_OP
			AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
			AND CAR.TIPOMATERIAL = OPEM.TipoMaterial
			AND CAR.CVE_MATERIAL = OPEM.Cve_Material
			AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
			GROUP BY 
				PIT.Empresa,
				M.Cve_Maquilador,
				M.Encargado,
				M.RazonSocial,
				M.RFC,
				M.Calle,
				M.Colonia,
				M.DelMun,
				M.CP,
				M.Entidad,
				M.Estado,
				M.Telefono,
				M.Celular,
				M.Encargado,
				M.Telefono,
				OPA.No_OP,
				PIT.No_Pedido,
				OCAI.No_OrdenCompra,
				OCAI.Partida,
				OCAI.No_Parcialidad,
				CAR.CANTIDAD_FINAL_A_REMISIONAR,
				OCAI.DescripcionMaterial,
				OCAI.TipoMaterial,
				OCAI.Cve_Material,
				OPEM.Cve_Tela,
				OPEM.Cve_Grupo,
				OPEM.Cve_Habilitacion
			ORDER BY 
				OPA.No_OP


			INSERT INTO #REMISIONES_CREADAS
			(
				NO_REMISION
			)
			SELECT 
				@NumeroInicial + ROW_NUMBER() OVER (ORDER BY OPA.NO_OP)
			FROM 
				#CANTIDAD_A_REMISIONAR CAR,
				PEDIDO_INTERNO_TALLAS PIT,
				ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI,
				OP_EXPLOSION_MATERIALES OPEM,
				PEDIDO_INTERNO PI,
				OP_ASIGNACION OPA,
				MAQUILADOR M
				LEFT JOIN
					MAQUILADOR_CORREO MC
				ON
					MC.Cve_Maquilador = M.Cve_Maquilador
			WHERE 
				PIT.Empresa = @EMPRESA
			AND PIT.No_Pedido = OCAI.No_Pedido
			AND OCAI.Empresa = PIT.Empresa 
			AND OCAI.No_Pedido = PIT.No_Pedido 
			AND OCAI.No_OrdenCompra = @NO_ORDENCOMPRA
			AND OCAI.Partida = @PARTIDA_OC
			AND OCAI.No_Parcialidad = @NO_PARCIALIDAD
			AND OCAI.Cve_Prenda = PIT.Cve_Prenda 
			AND OCAI.LugarEntrega = PIT.LugarDeEntrega 
			AND OCAI.Prioridad = PIT.Prioridad
			AND OPEM.Empresa = PIT.Empresa 
			AND OPEM.No_Pedido = PIT.No_Pedido 
			AND OPEM.No_OP = PIT.No_OP 
			AND OPEM.TipoMaterial = OCAI.TipoMaterial 
			AND OPEM.Cve_Material = OCAI.Cve_Material
			AND PI.Empresa = PIT.Empresa 
			AND PI.No_Pedido = PIT.No_Pedido 
			AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
			AND OPA.Empresa = PIT.Empresa 
			AND OPA.No_OP = PIT.No_OP
			AND M.Cve_Maquilador = OPA.Cve_Maquilador
			AND OPA.Estatus = 'AUTORIZADA'
			AND CAR.NO_OP = OPA.No_OP
			AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
			AND CAR.TIPOMATERIAL = OPEM.TipoMaterial
			AND CAR.CVE_MATERIAL = OPEM.Cve_Material
			AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
			GROUP BY 
				PIT.Empresa,
				M.Cve_Maquilador,
				M.Encargado,
				M.RazonSocial,
				M.RFC,
				M.Calle,
				M.Colonia,
				M.DelMun,
				M.CP,
				M.Entidad,
				M.Estado,
				M.Telefono,
				M.Celular,
				M.Encargado,
				M.Telefono,
				OPA.No_OP,
				PIT.No_Pedido,
				OCAI.No_OrdenCompra,
				OCAI.Partida,
				OCAI.No_Parcialidad,
				CAR.CANTIDAD_FINAL_A_REMISIONAR,
				OCAI.DescripcionMaterial,
				OCAI.TipoMaterial,
				OCAI.Cve_Material,
				OPEM.Cve_Tela,
				OPEM.Cve_Grupo,
				OPEM.Cve_Habilitacion
			ORDER BY 
				OPA.No_OP

			---ACTUALIZA LA CANTIDAD DE INGRESO EN LAS REMISIONES POR ORDEN DE ENTREGA
			DECLARE OC_RECIBOS CURSOR FOR
			SELECT
				OCFPR.No_Entrega,
				(CantidadDisponibleRemision*OC.Factor),
				OC.Factor
			FROM
				ORDEN_COMPRA OC,
				ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR
			WHERE
				OC.Empresa = @EMPRESA
			AND OC.No_OrdenCompra = @NO_ORDENCOMPRA
			AND OC.Partida = @PARTIDA_OC
			AND OCFPR.Empresa = OC.Empresa
			AND OCFPR.No_OrdenCompra = OC.No_OrdenCompra
			AND OCFPR.Partida = OC.Partida
			AND OCFPR.No_Parcialidad = @NO_PARCIALIDAD
			AND CantidadDisponibleRemision > 0
			ORDER BY
				No_Entrega
			OPEN OC_RECIBOS
			FETCH NEXT FROM OC_RECIBOS INTO @No_Entrega,@CantidadDisponibleRemision,@Factor
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @CANTIDAD_PARA_REMISIONES > 0
				BEGIN
					IF @CantidadDisponibleRemision >= @CANTIDAD_PARA_REMISIONES
					BEGIN
						UPDATE
							ORDEN_COMPRA_FECHA_PROMESA_RECIBO
						SET 
							CantidadDisponibleRemision = CantidadDisponibleRemision-(@CANTIDAD_PARA_REMISIONES/@Factor)
						WHERE
							Empresa = @EMPRESA
						AND No_OrdenCompra = @NO_ORDENCOMPRA
						AND Partida = @PARTIDA_OC
						AND No_Parcialidad = @NO_PARCIALIDAD
						AND No_Entrega = @No_Entrega

						SET @CANTIDAD_PARA_REMISIONES = 0
					END
					ELSE
					BEGIN
						UPDATE
							ORDEN_COMPRA_FECHA_PROMESA_RECIBO
						SET 
							CantidadDisponibleRemision = 0
						WHERE
							Empresa = @EMPRESA
						AND No_OrdenCompra = @NO_ORDENCOMPRA
						AND Partida = @PARTIDA_OC
						AND No_Parcialidad = @NO_PARCIALIDAD
						AND No_Entrega = @No_Entrega

						SET @CANTIDAD_PARA_REMISIONES -= @CantidadDisponibleRemision
					END
				END
				FETCH NEXT FROM OC_RECIBOS INTO @No_Entrega,@CantidadDisponibleRemision,@Factor
			END
			CLOSE OC_RECIBOS
			DEALLOCATE OC_RECIBOS
		END
		ELSE
		BEGIN
	
			DECLARE OP_A_REMISIONAR CURSOR FOR
			SELECT
				NO_OP,
				CVE_MAQUILADOR,
				TIPOMATERIAL,
				CVE_MATERIAL,
				CANTIDAD
			FROM
				#CANTIDAD_A_REMISIONAR
			ORDER BY
				NO_OP
			OPEN OP_A_REMISIONAR
			FETCH NEXT FROM OP_A_REMISIONAR INTO @NO_OP,@CVE_MAQUILADOR,@TIPOMATERIAL,@CVE_MATERIAL,@CANTIDAD_A_REMISIONAR
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @CANTIDAD_RECIBIDA > 0
				BEGIN
					IF @CANTIDAD_RECIBIDA <= @CANTIDAD_A_REMISIONAR
					BEGIN
						UPDATE
							#CANTIDAD_A_REMISIONAR
						SET
							CANTIDAD_FINAL_A_REMISIONAR = @CANTIDAD_RECIBIDA
						WHERE
							NO_OP = @NO_OP
						AND CVE_MAQUILADOR = @CVE_MAQUILADOR
						AND TIPOMATERIAL = @TIPOMATERIAL
						AND CVE_MATERIAL = @CVE_MATERIAL

						SET @CANTIDAD_RECIBIDA = 0
					END
					ELSE
					BEGIN
						SET @CANTIDAD_RECIBIDA = @CANTIDAD_RECIBIDA-@CANTIDAD_A_REMISIONAR
					END
				END
				ELSE
				BEGIN
					UPDATE
						#CANTIDAD_A_REMISIONAR
					SET
						CANTIDAD_FINAL_A_REMISIONAR = 0
					WHERE
						NO_OP = @NO_OP
					AND CVE_MAQUILADOR = @CVE_MAQUILADOR
					AND TIPOMATERIAL = @TIPOMATERIAL
					AND CVE_MATERIAL = @CVE_MATERIAL
				END
			
				FETCH NEXT FROM OP_A_REMISIONAR INTO @NO_OP,@CVE_MAQUILADOR,@TIPOMATERIAL,@CVE_MATERIAL,@CANTIDAD_A_REMISIONAR
			END
		
			SELECT @NumeroInicial = ISNULL(MAX(NO_REMISION), 0) FROM REMISION_MATERIAL;
			--SE GENERAN LAS REMISIONES CON LA CANTIDAD DE LA OP
			INSERT INTO [dbo].[REMISION_MATERIAL]
	        (
				[Empresa]
			   ,[No_Remision]
			   ,[Partida]
			   ,[FechaHoraRemision]
			   ,[TipoDestinatario]
			   ,[Cve_Destinatario]
			   ,[RazonSocialDestinatario]
			   ,[RFCDestinatario]
			   ,[Calle]
			   ,[Colonia]
			   ,[Municipio]
			   ,[CP]
			   ,[Ciudad]
			   ,[Estado]
			   ,[Telefono]
			   ,[Celular]
			   ,[Email]
			   ,[Contacto]
			   ,[TelContacto]
			   ,[No_OP]
			   ,[No_Pedido]
			   ,[No_OrdenCompra]
			   ,[OC_Partida]
			   ,[OC_No_Parcialidad]
			   ,[Cantidad]
			   ,[Descripcion]
			   ,[TipoMaterial]
			   ,[Cve_Material]
			   ,[Cve_Tela]
			   ,[Cve_Grupo]
			   ,[Cve_Habilitacion]
			   ,[PrecioU]
			   ,[PorcentajeIVA]
			   ,[Subtotal_Partida]
			   ,[IVA_Partida]
			   ,[Total_Partida]
			   ,[Subtotal_Remision]
			   ,[IVA_Remision]
			   ,[Total_Remision]
			   ,[ImporteEnLetra]
			   ,[CveUnidadMedida]
			   ,[UnidadMedida]
			   ,[Estatus]
			   ,[Impresa]
			   ,[USUARIO]
			   ,[FECHAHORA]
			   ,[COMPUTADORA]
			)
			SELECT 
				PIT.Empresa,
				@NumeroInicial + ROW_NUMBER() OVER (ORDER BY OPA.NO_OP),
				1,
				GETDATE(),
				'Maquilador',
				M.Cve_Maquilador,
				M.Encargado + '/' + M.RazonSocial,
				M.RFC,
				M.Calle,
				M.Colonia,
				M.DelMun,
				M.CP,
				M.Entidad,
				M.Estado,
				M.Telefono,
				M.Celular,
				STUFF((
					SELECT ', ' + MC.Email
					FROM MAQUILADOR_CORREO MC
					WHERE M.CVE_MAQUILADOR = MC.CVE_MAQUILADOR
					FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Correos,
				M.Encargado,
				M.Telefono,
				OPA.No_OP,
				PIT.No_Pedido,
				OCAI.No_OrdenCompra,
				OCAI.Partida,
				OCAI.No_Parcialidad,
				CAR.CANTIDAD_FINAL_A_REMISIONAR,
				OCAI.DescripcionMaterial,
				OCAI.TipoMaterial,
				OCAI.Cve_Material,
				OPEM.Cve_Tela,
				OPEM.Cve_Grupo,
				OPEM.Cve_Habilitacion,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				'',
				1,
				'PIEZAS',
				'AUTORIZADA',
				0,
				@USUARIO,
				GETDATE(),
				@COMPUTADORA
			FROM
				#CANTIDAD_A_REMISIONAR CAR,
				PEDIDO_INTERNO_TALLAS PIT,
				ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI,
				OP_EXPLOSION_MATERIALES OPEM,
				PEDIDO_INTERNO PI,
				OP_ASIGNACION OPA,
				MAQUILADOR M
				LEFT JOIN
					MAQUILADOR_CORREO MC
				ON
					MC.Cve_Maquilador = M.Cve_Maquilador
			WHERE 
				PIT.Empresa = @EMPRESA
			AND PIT.No_Pedido = OCAI.No_Pedido
			AND OCAI.Empresa = PIT.Empresa 
			AND OCAI.No_Pedido = PIT.No_Pedido 
			AND OCAI.No_OrdenCompra = @NO_ORDENCOMPRA
			AND OCAI.Partida = @PARTIDA_OC
			AND OCAI.No_Parcialidad = @NO_PARCIALIDAD
			AND OCAI.Cve_Prenda = PIT.Cve_Prenda 
			AND OCAI.LugarEntrega = PIT.LugarDeEntrega 
			AND OCAI.Prioridad = PIT.Prioridad
			AND OPEM.Empresa = PIT.Empresa 
			AND OPEM.No_Pedido = PIT.No_Pedido 
			AND OPEM.No_OP = PIT.No_OP 
			AND OPEM.TipoMaterial = OCAI.TipoMaterial 
			AND OPEM.Cve_Material = OCAI.Cve_Material
			AND PI.Empresa = PIT.Empresa 
			AND PI.No_Pedido = PIT.No_Pedido 
			AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
			AND OPA.Empresa = PIT.Empresa 
			AND OPA.No_OP = PIT.No_OP
			AND M.Cve_Maquilador = OPA.Cve_Maquilador
			AND OPA.Estatus = 'AUTORIZADA'
			AND CAR.NO_OP = OPA.No_OP
			AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
			AND CAR.TIPOMATERIAL = OPEM.TipoMaterial
			AND CAR.CVE_MATERIAL = OPEM.Cve_Material
			AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
			GROUP BY 
				PIT.Empresa,
				M.Cve_Maquilador,
				M.Encargado,
				M.RazonSocial,
				M.RFC,
				M.Calle,
				M.Colonia,
				M.DelMun,
				M.CP,
				M.Entidad,
				M.Estado,
				M.Telefono,
				M.Celular,
				M.Encargado,
				M.Telefono,
				OPA.No_OP,
				PIT.No_Pedido,
				OCAI.No_OrdenCompra,
				OCAI.Partida,
				OCAI.No_Parcialidad,
				CAR.CANTIDAD_FINAL_A_REMISIONAR,
				OCAI.DescripcionMaterial,
				OCAI.TipoMaterial,
				OCAI.Cve_Material,
				OPEM.Cve_Tela,
				OPEM.Cve_Grupo,
				OPEM.Cve_Habilitacion
			ORDER BY 
				OPA.No_OP

			INSERT INTO #REMISIONES_CREADAS
			(
				NO_REMISION
			)
			SELECT 
				@NumeroInicial + ROW_NUMBER() OVER (ORDER BY OPA.NO_OP)
			FROM
				#CANTIDAD_A_REMISIONAR CAR,
				PEDIDO_INTERNO_TALLAS PIT,
				ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI,
				OP_EXPLOSION_MATERIALES OPEM,
				PEDIDO_INTERNO PI,
				OP_ASIGNACION OPA,
				MAQUILADOR M
				LEFT JOIN
					MAQUILADOR_CORREO MC
				ON
					MC.Cve_Maquilador = M.Cve_Maquilador
			WHERE 
				PIT.Empresa = @EMPRESA
			AND PIT.No_Pedido = OCAI.No_Pedido
			AND OCAI.Empresa = PIT.Empresa 
			AND OCAI.No_Pedido = PIT.No_Pedido 
			AND OCAI.No_OrdenCompra = @NO_ORDENCOMPRA
			AND OCAI.Partida = @PARTIDA_OC
			AND OCAI.No_Parcialidad = @NO_PARCIALIDAD
			AND OCAI.Cve_Prenda = PIT.Cve_Prenda 
			AND OCAI.LugarEntrega = PIT.LugarDeEntrega 
			AND OCAI.Prioridad = PIT.Prioridad
			AND OPEM.Empresa = PIT.Empresa 
			AND OPEM.No_Pedido = PIT.No_Pedido 
			AND OPEM.No_OP = PIT.No_OP 
			AND OPEM.TipoMaterial = OCAI.TipoMaterial 
			AND OPEM.Cve_Material = OCAI.Cve_Material
			AND PI.Empresa = PIT.Empresa 
			AND PI.No_Pedido = PIT.No_Pedido 
			AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
			AND OPA.Empresa = PIT.Empresa 
			AND OPA.No_OP = PIT.No_OP
			AND M.Cve_Maquilador = OPA.Cve_Maquilador
			AND OPA.Estatus = 'AUTORIZADA'
			AND CAR.NO_OP = OPA.No_OP
			AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
			AND CAR.TIPOMATERIAL = OPEM.TipoMaterial
			AND CAR.CVE_MATERIAL = OPEM.Cve_Material
			AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
			GROUP BY 
				PIT.Empresa,
				M.Cve_Maquilador,
				M.Encargado,
				M.RazonSocial,
				M.RFC,
				M.Calle,
				M.Colonia,
				M.DelMun,
				M.CP,
				M.Entidad,
				M.Estado,
				M.Telefono,
				M.Celular,
				M.Encargado,
				M.Telefono,
				OPA.No_OP,
				PIT.No_Pedido,
				OCAI.No_OrdenCompra,
				OCAI.Partida,
				OCAI.No_Parcialidad,
				CAR.CANTIDAD_FINAL_A_REMISIONAR,
				OCAI.DescripcionMaterial,
				OCAI.TipoMaterial,
				OCAI.Cve_Material,
				OPEM.Cve_Tela,
				OPEM.Cve_Grupo,
				OPEM.Cve_Habilitacion
			ORDER BY 
				OPA.No_OP

			SELECT
				@CANTIDAD_PARA_REMISIONES = SUM(CANTIDAD_FINAL_A_REMISIONAR)
			FROM
				#CANTIDAD_A_REMISIONAR
			WHERE
				CANTIDAD_FINAL_A_REMISIONAR > 0

			---ACTUALIZA LA CANTIDAD DE INGRESO EN LAS REMISIONES POR ORDEN DE ENTREGA
			DECLARE OC_RECIBOS CURSOR FOR
			SELECT
				OCFPR.No_Entrega,
				(CantidadDisponibleRemision*OC.Factor),
				OC.Factor
			FROM
				ORDEN_COMPRA OC,
				ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR
			WHERE
				OC.Empresa = @EMPRESA
			AND OC.No_OrdenCompra = @NO_ORDENCOMPRA
			AND OC.Partida = @PARTIDA_OC
			AND OCFPR.Empresa = OC.Empresa
			AND OCFPR.No_OrdenCompra = OC.No_OrdenCompra
			AND OCFPR.Partida = OC.Partida
			AND OCFPR.No_Parcialidad = @NO_PARCIALIDAD
			AND CantidadDisponibleRemision > 0
			ORDER BY
				No_Entrega
			OPEN OC_RECIBOS
			FETCH NEXT FROM OC_RECIBOS INTO @No_Entrega,@CantidadDisponibleRemision,@Factor
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @CANTIDAD_PARA_REMISIONES > 0
				BEGIN
					IF @CantidadDisponibleRemision >= @CANTIDAD_PARA_REMISIONES
					BEGIN
						UPDATE
							ORDEN_COMPRA_FECHA_PROMESA_RECIBO
						SET 
							CantidadDisponibleRemision = CantidadDisponibleRemision-(@CANTIDAD_PARA_REMISIONES/@Factor)
						WHERE
							Empresa = @EMPRESA
						AND No_OrdenCompra = @NO_ORDENCOMPRA
						AND Partida = @PARTIDA_OC
						AND No_Parcialidad = @NO_PARCIALIDAD
						AND No_Entrega = @No_Entrega

						SET @CANTIDAD_PARA_REMISIONES = 0
					END
					ELSE
					BEGIN
						UPDATE
							ORDEN_COMPRA_FECHA_PROMESA_RECIBO
						SET 
							CantidadDisponibleRemision = 0
						WHERE
							Empresa = @EMPRESA
						AND No_OrdenCompra = @NO_ORDENCOMPRA
						AND Partida = @PARTIDA_OC
						AND No_Parcialidad = @NO_PARCIALIDAD
						AND No_Entrega = @No_Entrega

						SET @CANTIDAD_PARA_REMISIONES -= @CantidadDisponibleRemision
					END
				END
				FETCH NEXT FROM OC_RECIBOS INTO @No_Entrega,@CantidadDisponibleRemision,@Factor
			END
			CLOSE OC_RECIBOS
			DEALLOCATE OC_RECIBOS

		END

		---INSERTA LOS MOVIMIENTOS DE INVENTARIO
		SET @NumeroInicial+=1
		DECLARE MOVIMIENTOS_INVENTARIO CURSOR FOR
		SELECT
			NO_OP,
			TIPOMATERIAL,
			CVE_MATERIAL,
			CANTIDAD_FINAL_A_REMISIONAR
		FROM
			#CANTIDAD_A_REMISIONAR
		WHERE
			CANTIDAD_FINAL_A_REMISIONAR > 0
		OPEN MOVIMIENTOS_INVENTARIO
		FETCH NEXT FROM MOVIMIENTOS_INVENTARIO INTO @NO_OP,@TIPOMATERIAL,@CVE_MATERIAL,@CANTIDAD_A_REMISIONAR
		WHILE @@FETCH_STATUS = 0
		BEGIN
			---INSERTA LOS MOVIMIENTOS DE INVENTARIO
			IF @TIPOMATERIAL = 'T'
			BEGIN

				SELECT
					@NO_MOVIMIENTO = ISNULL(MAX(TM.NoMovimiento),0)
				FROM 
					TELA_MOVIMIENTO TM
				WHERE
					TM.Cve_Tela = @CVE_MATERIAL

				SET @NO_MOVIMIENTO += 1

				SELECT
					@SALDOANTERIOR = T.Existencia + T.Reservado
				FROM
					CATALOGO_TELA T
				WHERE
					T.Cve_Tela = @CVE_MATERIAL

				INSERT INTO TELA_MOVIMIENTO
				(
					Cve_Tela,
					NoMovimiento,
					TipoMovimiento,
					FechaMovimiento,
					Origen,
					Origen_No,
					No_Documento,
					SaldoAnterior,
					CantidadMovimiento,
					SaldoFinal
				)
				SELECT
					@CVE_MATERIAL,
					@NO_MOVIMIENTO,
					'S',
					GETDATE(),
					'OP',
					@NO_OP,
					@NumeroInicial,
					@SALDOANTERIOR,
					@CANTIDAD_A_REMISIONAR,
					@SALDOANTERIOR-@CANTIDAD_A_REMISIONAR

					--SE ACTUALIZA EL INVENTARIO DE MATERIAL
					UPDATE
						CATALOGO_TELA
					SET 
						Reservado = Reservado - @CANTIDAD_A_REMISIONAR
					WHERE
						Cve_Tela = @CVE_MATERIAL
			END
			IF @TIPOMATERIAL = 'H'
			BEGIN
				SELECT
					@NO_MOVIMIENTO = ISNULL(MAX(HK.NoMovimiento),0)
				FROM 
					HABILITACION_KARDEX HK
				WHERE
					HK.Cve_Grupo = SUBSTRING(@CVE_MATERIAL,1,3)
				AND HK.Cve_Habilitacion = CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6))

				SET @NO_MOVIMIENTO += 1

				SELECT
					@SALDOANTERIOR = H.Existencia + H.Reservado
				FROM
					HABILITACION H
				WHERE
					H.Cve_Grupo = SUBSTRING(@CVE_MATERIAL,1,3)
				AND H.Cve_Habilitacion = CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6))

				INSERT INTO HABILITACION_KARDEX
				(
					Cve_Grupo,
					Cve_Habilitacion,
					NoMovimiento,
					TipoMovimiento,
					FechaMovimiento,
					Origen,
					Origen_No,
					No_Documento,
					SaldoAnterior,
					CantidadMovimiento,
					SaldoFinal
				)
				SELECT
					SUBSTRING(@CVE_MATERIAL,1,3),
					CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6)),
					@NO_MOVIMIENTO,
					'S',
					GETDATE(),
					'OP',
					@NO_OP,
					@NumeroInicial,
					@SALDOANTERIOR,
					@CANTIDAD_A_REMISIONAR,
					@SALDOANTERIOR-@CANTIDAD_A_REMISIONAR

					--SE ACTUALIZA EL INVENTARIO DE MATERIAL
					UPDATE
						HABILITACION
					SET 
						Reservado = Reservado - @CANTIDAD_A_REMISIONAR
					WHERE
						Cve_Grupo = SUBSTRING(@CVE_MATERIAL,1,3)
					AND Cve_Habilitacion = CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6))
				SET @NumeroInicial+=1
			END
			FETCH NEXT FROM MOVIMIENTOS_INVENTARIO INTO @NO_OP,@TIPOMATERIAL,@CVE_MATERIAL,@CANTIDAD_A_REMISIONAR
		END
		CLOSE MOVIMIENTOS_INVENTARIO
		DEALLOCATE MOVIMIENTOS_INVENTARIO

		SELECT * FROM #REMISIONES_CREADAS

		DROP TABLE #REMISIONES_CREADAS
		DROP TABLE #CANTIDAD_A_REMISIONAR

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

