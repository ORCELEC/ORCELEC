USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[OP_GENERA_REMISIONES]    Script Date: 17/07/2025 12:08:23 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OP_GENERA_REMISIONES]
--DECLARE
	@EMPRESA BIGINT,
	@NO_OP BIGINT,
	@USUARIO BIGINT,
	@COMPUTADORA NVARCHAR(50)
AS 
BEGIN
--SET @EMPRESA = 1
--SET @NO_OP = 1361
--SET @USUARIO = 0
--SET @COMPUTADORA = 'SISTEMASUNO'
	DECLARE @TRAN_STARTED BIT
	SET @TRAN_STARTED = 0
	
	BEGIN TRY
	
		BEGIN TRANSACTION
		SET @TRAN_STARTED = 1		
		
		DECLARE 
			@NO_PEDIDO AS BIGINT,
			@TipoMaterial nvarchar(1),
			@Cve_Material nvarchar(20),
			@CantidadARemisionar numeric(18,2),
			@Origen nvarchar(20),
			@No_OrdenCompra bigint,
			@Partida bigint,
			@No_Parcialidad bigint,
			@No_EntregaOReservado bigint,
			@CantidadDisponibleARemisionar numeric(18,2),
			@NO_MOVIMIENTO BIGINT,
			@SALDOANTERIOR NUMERIC(18,2)

		SELECT @NO_PEDIDO = No_Pedido FROM PEDIDO_INTERNO_TALLAS PIT WHERE PIT.Empresa = @EMPRESA AND PIT.No_OP = @NO_OP

		CREATE TABLE #CANTIDAD_A_REMISIONAR
		(
			NO_OP BIGINT,
			CVE_MAQUILADOR BIGINT,
			TIPOMATERIAL NVARCHAR(1),
			CVE_MATERIAL NVARCHAR(50),
			DESCRIPCION NVARCHAR(250),
			CVE_TELA BIGINT,
			CVE_GRUPO NVARCHAR(3),
			CVE_HABILITACION BIGINT,
			CANTIDAD_A_REMISIONAR NUMERIC(18,2),
			CANTIDAD_FINAL_A_REMISIONAR NUMERIC(18,2)
		)

		INSERT INTO #CANTIDAD_A_REMISIONAR
		(
			NO_OP,
			CVE_MAQUILADOR,
			TIPOMATERIAL,
			CVE_MATERIAL,
			DESCRIPCION,
			CVE_TELA,
			CVE_GRUPO,
			CVE_HABILITACION,
			CANTIDAD_A_REMISIONAR,
			CANTIDAD_FINAL_A_REMISIONAR
		)
		SELECT 
			OPA.No_OP,
			OPA.Cve_Maquilador,
			OPEM.TipoMaterial,
			OPEM.Cve_Material,
			OPEM.DescripcionMaterial,
			OPEM.Cve_Tela,
			OPEM.Cve_Grupo,
			OPEM.Cve_Habilitacion,
			OPEM.Cantidad-(SELECT ISNULL(SUM(RM.Cantidad),0) FROM REMISION_MATERIAL RM WHERE RM.Empresa = OPA.Empresa AND RM.No_OP = OPA.No_OP AND RM.TipoMaterial = OPEM.TipoMaterial AND RM.Cve_Material = OPEM.Cve_Material AND RM.Estatus = 'AUTORIZADA'),
			0
		FROM 
			OP_ASIGNACION OPA,
			OP_EXPLOSION_MATERIALES OPEM
		WHERE
			OPA.Empresa = @EMPRESA
		AND OPA.No_OP = @NO_OP
		AND OPEM.Empresa = OPA.Empresa
		AND OPEM.No_OP = OPA.No_OP

		CREATE TABLE #DISPONIBLE_PARA_REMISIONAR
		(
			Origen nvarchar(20),
			TipoMaterial nvarchar(1),
			Cve_Material nvarchar(20),
			No_OrdenCompra bigint,
			Partida bigint,
			No_Parcialidad bigint,
			No_EntregaOReservado bigint,
			CantidadDisponibleARemisionar numeric(18,2),
			Factor numeric(18,2),
			CantidadRemisionada numeric(18,2),
			DescripcionMaterialOC nvarchar(255)
		)
		INSERT INTO #DISPONIBLE_PARA_REMISIONAR
		(
			Origen,
			TipoMaterial,
			Cve_Material,
			No_OrdenCompra,
			Partida,
			No_Parcialidad,
			No_EntregaOReservado,
			CantidadDisponibleARemisionar,
			Factor,
			CantidadRemisionada,
			DescripcionMaterialOC
		)
		--SELECT
		--	'OrdenCompra',
		--	OC.TipoMaterial,
		--	OC.Cve_Material,
		--	OC.No_OrdenCompra,
		--	OC.Partida,
		--	OCFPR.No_Parcialidad,
		--	OCFPR.No_Entrega,
		--	(CantidadDisponibleRemision*OC.Factor),
		--	OC.Factor,
		--	0,
		--	OC.DescripcionMaterial
		--FROM
		--	ORDEN_COMPRA OC,
		--	ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR
		--WHERE
		--	OC.Empresa = @EMPRESA
		--AND OC.No_Pedido = @NO_PEDIDO
		--AND OCFPR.Empresa = OC.Empresa
		--AND OCFPR.No_OrdenCompra = OC.No_OrdenCompra
		--AND OCFPR.Partida = OC.Partida
		--AND CantidadDisponibleRemision > 0
		SELECT
			'OrdenCompra',
			OC.TipoMaterial,
			OC.Cve_Material,
			OC.No_OrdenCompra,
			OC.Partida,
			OCFPR.No_Parcialidad,
			OCFPR.No_Entrega,
			(CantidadDisponibleRemision*OC.Factor),
			OC.Factor,
			0,
			OC.DescripcionMaterial
		FROM
			ORDEN_COMPRA OC,
			ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR,
			PEDIDO_INTERNO_TALLAS PIT,
			ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI
		WHERE
			OC.Empresa = @EMPRESA
		AND OC.No_OrdenCompra = OCAI.No_OrdenCompra
		AND OC.Partida = OCAI.Partida
		AND OCFPR.Empresa = OC.Empresa
		AND OCFPR.No_OrdenCompra = OC.No_OrdenCompra
		AND OCFPR.Partida = OC.Partida
		AND PIT.Empresa = OC.Empresa
		AND PIT.No_OP = @NO_OP
		AND	OCAI.Empresa = PIT.Empresa
		AND OCAI.No_Pedido = PIT.No_Pedido
		AND OCAI.Prioridad = PIT.Prioridad
		AND OCAI.LugarEntrega = PIT.LugarDeEntrega
		AND OCAI.Cve_Prenda = PIT.Cve_Prenda
		AND OCAI.TipoMaterial = OC.TipoMaterial
		AND OCAI.Cve_Material = OC.Cve_Material
		AND OCFPR.CantidadDisponibleRemision > 0
		AND OCFPR.No_OrdenCompra NOT IN (SELECT RM.Origen_No FROM RESERVADO_MATERIAL RM,PEDIDO_INTERNO_TALLAS PIT,ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI WHERE RM.Empresa = @EMPRESA AND RM.No_Pedido = PIT.No_Pedido AND PIT.Empresa = RM.Empresa AND PIT.No_OP = @NO_OP AND	OCAI.Empresa = PIT.Empresa AND OCAI.No_Pedido = PIT.No_Pedido AND OCAI.Prioridad = PIT.Prioridad AND OCAI.LugarEntrega = PIT.LugarDeEntrega AND OCAI.Cve_Prenda = PIT.Cve_Prenda AND OCAI.TipoMaterial = RM.TipoMaterial AND OCAI.Cve_Material = RM.Cve_Material AND RM.Origen_No = OCAI.No_OrdenCompra GROUP BY RM.Origen_No)
		GROUP BY
			OC.TipoMaterial,
			OC.Cve_Material,
			OC.No_OrdenCompra,
			OC.Partida,
			OCFPR.No_Parcialidad,
			OCFPR.No_Entrega,
			(CantidadDisponibleRemision*OC.Factor),
			OC.Factor,
			OC.DescripcionMaterial
			
		INSERT INTO #DISPONIBLE_PARA_REMISIONAR
		(
			Origen,
			TipoMaterial,
			Cve_Material,
			No_OrdenCompra,
			Partida,
			No_Parcialidad,
			No_EntregaOReservado,
			CantidadDisponibleARemisionar,
			Factor,
			CantidadRemisionada,
			DescripcionMaterialOC
		)
		--SELECT
		--	'RESERVADOMATERIAL',
		--	RM.TipoMaterial,
		--	RM.Cve_Material,
		--	RM.Origen_No,
		--	RM.No_Documento,
		--	1,
		--	RM.No_Reservado,
		--	RM.CantidadReservada-RM.CantidadUsada,
		--	1,
		--	0,
		--	DescripcionMaterial
		--FROM 
		--	RESERVADO_MATERIAL RM
		--WHERE
		--	RM.Empresa = @EMPRESA 
		--AND RM.No_Pedido = @NO_PEDIDO
		SELECT
			'RESERVADOMATERIAL',
			RM.TipoMaterial,
			RM.Cve_Material,
			RM.Origen_No,
			RM.No_Documento,
			1,
			RM.No_Reservado,
			OCAI.AsignacionPromesa,
			--RM.CantidadReservada-RM.CantidadUsada,
			1,
			0,
			RM.DescripcionMaterial
		FROM 
			RESERVADO_MATERIAL RM,
			PEDIDO_INTERNO_TALLAS PIT,
			ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI
		WHERE
			RM.Empresa = @EMPRESA
		AND RM.No_Pedido = PIT.No_Pedido
		AND PIT.Empresa = RM.Empresa
		AND PIT.No_OP = @NO_OP
		AND	OCAI.Empresa = PIT.Empresa
		AND OCAI.No_Pedido = PIT.No_Pedido
		AND OCAI.Prioridad = PIT.Prioridad
		AND OCAI.LugarEntrega = PIT.LugarDeEntrega
		AND OCAI.Cve_Prenda = PIT.Cve_Prenda
		AND OCAI.TipoMaterial = RM.TipoMaterial
		AND OCAI.Cve_Material = RM.Cve_Material
		AND RM.Origen_No = OCAI.No_OrdenCompra
		GROUP BY
			RM.TipoMaterial,
			RM.Cve_Material,
			RM.Origen_No,
			RM.No_Documento,
			RM.No_Reservado,
			OCAI.AsignacionPromesa,
			--RM.CantidadReservada-RM.CantidadUsada,
			RM.DescripcionMaterial

		CREATE TABLE #Remisiones
		(
			No_Remision bigint
		)

		DECLARE MaterialARemisionar CURSOR FOR
		SELECT
			TIPOMATERIAL,
			CVE_MATERIAL,
			CANTIDAD_A_REMISIONAR
		FROM
			#CANTIDAD_A_REMISIONAR
		OPEN MaterialARemisionar
		FETCH NEXT FROM MaterialARemisionar INTO @TipoMaterial,@Cve_Material,@CantidadARemisionar
		WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE DisponibleARemisionar CURSOR FOR
			SELECT
				Origen,
				No_OrdenCompra,
				Partida,
				No_Parcialidad,
				No_EntregaOReservado,
				CantidadDisponibleARemisionar
			FROM
				#DISPONIBLE_PARA_REMISIONAR
			WHERE
				TipoMaterial = @TipoMaterial
			AND Cve_Material = @Cve_Material
			OPEN DisponibleARemisionar
			FETCH NEXT FROM DisponibleARemisionar INTO @Origen,@No_OrdenCompra,@Partida,@No_Parcialidad,@No_EntregaOReservado,@CantidadDisponibleARemisionar
			WHILE @@FETCH_STATUS = 0
			BEGIN
				IF @CantidadARemisionar > 0
				BEGIN
					IF @CantidadDisponibleARemisionar >= @CantidadARemisionar
					BEGIN
						UPDATE
							#CANTIDAD_A_REMISIONAR
						SET
							CANTIDAD_FINAL_A_REMISIONAR = CANTIDAD_FINAL_A_REMISIONAR+@CantidadARemisionar
						WHERE
							NO_OP = @NO_OP
						AND TIPOMATERIAL = @TipoMaterial
						AND CVE_MATERIAL = @Cve_Material

						UPDATE
							#DISPONIBLE_PARA_REMISIONAR
						SET
							CantidadRemisionada = @CantidadARemisionar
						WHERE
							Origen = @Origen
						AND TipoMaterial = @TipoMaterial
						AND Cve_Material = @Cve_Material
						AND No_OrdenCompra = @No_OrdenCompra
						AND Partida = @Partida
						AND No_Parcialidad = @No_Parcialidad
						AND No_EntregaOReservado = @No_EntregaOReservado

						SET @CantidadARemisionar = 0
					END
					ELSE
					BEGIN
						UPDATE
							#CANTIDAD_A_REMISIONAR
						SET
							CANTIDAD_FINAL_A_REMISIONAR += @CantidadDisponibleARemisionar
						WHERE
							NO_OP = @NO_OP
						AND TIPOMATERIAL = @TipoMaterial
						AND CVE_MATERIAL = @Cve_Material

						UPDATE
							#DISPONIBLE_PARA_REMISIONAR
						SET
							CantidadRemisionada += @CantidadDisponibleARemisionar
						WHERE
							Origen = @Origen
						AND TipoMaterial = @TipoMaterial
						AND Cve_Material = @Cve_Material
						AND No_OrdenCompra = @No_OrdenCompra
						AND Partida = @Partida
						AND No_Parcialidad = @No_Parcialidad
						AND No_EntregaOReservado = @No_EntregaOReservado

						SET @CantidadARemisionar -= @CantidadDisponibleARemisionar
					END
				END
				FETCH NEXT FROM DisponibleARemisionar INTO @Origen,@No_OrdenCompra,@Partida,@No_Parcialidad,@No_EntregaOReservado,@CantidadDisponibleARemisionar
			END
			CLOSE DisponibleARemisionar
			DEALLOCATE DisponibleARemisionar
			FETCH NEXT FROM MaterialARemisionar INTO @TipoMaterial,@Cve_Material,@CantidadARemisionar
		END
		CLOSE MaterialARemisionar
		DEALLOCATE MaterialARemisionar
		
		--DESPÚES DE ASIGNAR MATERIALES DISPONIBLES, ME GENERA LAS REMISIONES
		--PRIMERO REMISIÓN DE TELA
		DECLARE @NO_REMISION AS BIGINT
		SELECT @NO_REMISION = ISNULL(MAX(NO_REMISION), 0)+1 FROM REMISION_MATERIAL;

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
			PI.Empresa,
			@NO_REMISION,
			ROW_NUMBER() OVER (ORDER BY CAR.CVE_MATERIAL),
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
			PI.No_Pedido,
			DPR.No_OrdenCompra,
			DPR.Partida,
			DPR.No_Parcialidad,
			SUM(DPR.CantidadRemisionada) AS CantidadRemisionada,
			DPR.DescripcionMaterialOC,
			CAR.TipoMaterial,
			CAR.Cve_Material,
			CAR.CVE_TELA,
			CAR.Cve_Grupo,
			CAR.Cve_Habilitacion,
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
			#DISPONIBLE_PARA_REMISIONAR DPR,
			PEDIDO_INTERNO PI,
			OP_ASIGNACION OPA,
			MAQUILADOR M
		WHERE 
			PI.Empresa = @EMPRESA
		AND PI.No_Pedido = @NO_PEDIDO
		AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
		AND OPA.Empresa = PI.Empresa 
		AND OPA.No_OP = @NO_OP
		AND M.Cve_Maquilador = OPA.Cve_Maquilador
		AND OPA.Estatus = 'AUTORIZADA'
		AND CAR.NO_OP = OPA.No_OP
		AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
		AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
		AND CAR.TIPOMATERIAL = 'T'
		AND DPR.TipoMaterial = CAR.TIPOMATERIAL
		AND DPR.Cve_Material = CAR.CVE_MATERIAL
		AND DPR.CantidadRemisionada > 0
		GROUP BY
			PI.Empresa,
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
			PI.No_Pedido,
			DPR.No_OrdenCompra,
			DPR.Partida,
			DPR.No_Parcialidad,
			DPR.DescripcionMaterialOC,
			CAR.TipoMaterial,
			CAR.Cve_Material,
			CAR.CVE_TELA,
			CAR.Cve_Grupo,
			CAR.Cve_Habilitacion
		ORDER BY
			CAR.TIPOMATERIAL,
			CAR.CVE_MATERIAL

		--IF EXISTS(SELECT 
		--	PI.Empresa,
		--	@NO_REMISION,
		--	ROW_NUMBER() OVER (ORDER BY CAR.CVE_MATERIAL),
		--	GETDATE(),
		--	'Maquilador',
		--	M.Cve_Maquilador,
		--	M.Encargado + '/' + M.RazonSocial,
		--	M.RFC,
		--	M.Calle,
		--	M.Colonia,
		--	M.DelMun,
		--	M.CP,
		--	M.Entidad,
		--	M.Estado,
		--	M.Telefono,
		--	M.Celular,
		--	STUFF((
		--		SELECT ', ' + MC.Email
		--		FROM MAQUILADOR_CORREO MC
		--		WHERE M.CVE_MAQUILADOR = MC.CVE_MAQUILADOR
		--		FOR XML PATH(''), TYPE
		--	).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Correos,
		--	M.Encargado,
		--	M.Telefono,
		--	OPA.No_OP,
		--	PI.No_Pedido,
		--	DPR.No_OrdenCompra,
		--	DPR.Partida,
		--	DPR.No_Parcialidad,
		--	DPR.CantidadRemisionada,
		--	CAR.Descripcion,
		--	CAR.TipoMaterial,
		--	CAR.Cve_Material,
		--	CAR.CVE_TELA,
		--	CAR.Cve_Grupo,
		--	CAR.Cve_Habilitacion,
		--	0,
		--	0,
		--	0,
		--	0,
		--	0,
		--	0,
		--	0,
		--	0,
		--	'',
		--	1,
		--	'PIEZAS',
		--	'AUTORIZADA',
		--	0,
		--	@USUARIO,
		--	GETDATE(),
		--	@COMPUTADORA
		--FROM
		--	#CANTIDAD_A_REMISIONAR CAR,
		--	#DISPONIBLE_PARA_REMISIONAR DPR,
		--	PEDIDO_INTERNO PI,
		--	OP_ASIGNACION OPA,
		--	MAQUILADOR M
		--WHERE 
		--	PI.Empresa = @EMPRESA
		--AND PI.No_Pedido = @NO_PEDIDO
		--AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
		--AND OPA.Empresa = PI.Empresa 
		--AND OPA.No_OP = @NO_OP
		--AND M.Cve_Maquilador = OPA.Cve_Maquilador
		--AND OPA.Estatus = 'AUTORIZADA'
		--AND CAR.NO_OP = OPA.No_OP
		--AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
		--AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
		--AND CAR.TIPOMATERIAL = 'T'
		--AND DPR.TipoMaterial = CAR.TIPOMATERIAL
		--AND DPR.Cve_Material = CAR.CVE_MATERIAL
		--AND DPR.CantidadRemisionada > 0
		--)
		--BEGIN
		--	INSERT INTO #Remisiones
		--	(
		--		No_Remision
		--	)
		--	SELECT
		--	@NO_REMISION
		--END

		---INSERTA LOS MOVIMIENTOS DE INVENTARIO
		DECLARE MOVIMIENTOS_INVENTARIO CURSOR FOR
		SELECT
			Origen,
			No_OrdenCompra,
			Partida,
			No_Parcialidad,
			No_EntregaOReservado,
			TIPOMATERIAL,
			CVE_MATERIAL,
			CantidadRemisionada
		FROM
			#DISPONIBLE_PARA_REMISIONAR
		WHERE
			CantidadRemisionada > 0
		AND TipoMaterial = 'T'
		OPEN MOVIMIENTOS_INVENTARIO
		FETCH NEXT FROM MOVIMIENTOS_INVENTARIO INTO @Origen,@No_OrdenCompra,@Partida,@No_Parcialidad,@No_EntregaOReservado,@TIPOMATERIAL,@CVE_MATERIAL,@CantidadARemisionar
		WHILE @@FETCH_STATUS = 0
		BEGIN
			---INSERTA LOS MOVIMIENTOS DE INVENTARIO
			IF @TIPOMATERIAL = 'T'
			BEGIN
				SELECT
					@NO_MOVIMIENTO = ISNULL(MAX(TM.NoMovimiento),0)+1
				FROM 
					TELA_MOVIMIENTO TM
				WHERE
					TM.Cve_Tela = @CVE_MATERIAL

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
					@NO_REMISION,
					@SALDOANTERIOR,
					@CantidadARemisionar,
					@SALDOANTERIOR-@CantidadARemisionar
				FROM
					#DISPONIBLE_PARA_REMISIONAR
				WHERE
					No_OrdenCompra = @No_OrdenCompra
				AND Partida = @Partida
				AND No_Parcialidad = @No_Parcialidad
				AND No_EntregaOReservado = @No_EntregaOReservado
				AND	TipoMaterial = @TipoMaterial
				AND Cve_Material = @Cve_Material
				
				--SE ACTUALIZA EL INVENTARIO DE MATERIAL
				--SELECT
				--	Reservado - @CantidadARemisionar AS Reservado
				--FROM 
				--	CATALOGO_TELA 
				--WHERE
				--	Cve_Tela = @Cve_Material
				
				UPDATE
					CATALOGO_TELA
				SET 
					Reservado = Reservado - @CantidadARemisionar
				WHERE
					Cve_Tela = @CVE_MATERIAL

				---SE ACTUALIZA EL RECIBO DE ORDEN_COMPRA O RESERVADO DE MATERIAL
				IF @Origen = 'RESERVADOMATERIAL'
				BEGIN
					--SELECT
					--	CantidadUsada + @CantidadARemisionar AS CantidadUsada
					--FROM
					--	RESERVADO_MATERIAL 
					--WHERE
					--	Empresa = @EMPRESA
					--AND No_Pedido = @NO_PEDIDO
					--AND TipoMaterial = @TipoMaterial
					--AND Cve_Material = @Cve_Material
					--AND No_Reservado = @No_EntregaOReservado

					UPDATE
						RESERVADO_MATERIAL 
					SET
						CantidadUsada += @CantidadARemisionar
					WHERE
						Empresa = @EMPRESA
					AND No_Pedido = @NO_PEDIDO
					AND TipoMaterial = @TipoMaterial
					AND Cve_Material = @Cve_Material
					AND No_Reservado = @No_EntregaOReservado
				END

				IF @Origen = 'OrdenCompra'
				BEGIN
					--SELECT
					--	CantidadDisponibleRemision - @CantidadARemisionar as CantidadDisponibleRemision
					--FROM
					--	ORDEN_COMPRA_FECHA_PROMESA_RECIBO 
					--WHERE
					--	Empresa = @EMPRESA
					--AND No_OrdenCompra = @No_OrdenCompra
					--AND Partida = @Partida
					--AND No_Parcialidad = @No_Parcialidad
					--AND No_Entrega = @No_EntregaOReservado
					
					UPDATE
						ORDEN_COMPRA_FECHA_PROMESA_RECIBO 
					SET
						CantidadDisponibleRemision -= @CantidadARemisionar
					WHERE
						Empresa = @EMPRESA
					AND No_OrdenCompra = @No_OrdenCompra
					AND Partida = @Partida
					AND No_Parcialidad = @No_Parcialidad
					AND No_Entrega = @No_EntregaOReservado
				END
			END
			FETCH NEXT FROM MOVIMIENTOS_INVENTARIO INTO @Origen,@No_OrdenCompra,@Partida,@No_Parcialidad,@No_EntregaOReservado,@TIPOMATERIAL,@CVE_MATERIAL,@CantidadARemisionar
		END
		CLOSE MOVIMIENTOS_INVENTARIO
		DEALLOCATE MOVIMIENTOS_INVENTARIO

		--AHORA GENERA LA REMISIÓN DE HABILITACIONES
		SELECT @NO_REMISION = ISNULL(MAX(NO_REMISION), 0)+1 FROM REMISION_MATERIAL;
		
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
			PI.Empresa,
			@NO_REMISION,
			ROW_NUMBER() OVER (ORDER BY CAR.CVE_MATERIAL),
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
			PI.No_Pedido,
			DPR.No_OrdenCompra,
			DPR.Partida,
			DPR.No_Parcialidad,
			SUM(DPR.CantidadRemisionada) AS CantidadRemisionada,
			DPR.DescripcionMaterialOC,
			CAR.TipoMaterial,
			CAR.Cve_Material,
			CAR.CVE_TELA,
			CAR.Cve_Grupo,
			CAR.Cve_Habilitacion,
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
			#DISPONIBLE_PARA_REMISIONAR DPR,
			PEDIDO_INTERNO PI,
			OP_ASIGNACION OPA,
			MAQUILADOR M
		WHERE 
			PI.Empresa = @EMPRESA
		AND PI.No_Pedido = @NO_PEDIDO
		AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
		AND OPA.Empresa = PI.Empresa 
		AND OPA.No_OP = @NO_OP
		AND M.Cve_Maquilador = OPA.Cve_Maquilador
		AND OPA.Estatus = 'AUTORIZADA'
		AND CAR.NO_OP = OPA.No_OP
		AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
		AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
		AND CAR.TIPOMATERIAL = 'H'
		AND DPR.TipoMaterial = CAR.TIPOMATERIAL
		AND DPR.Cve_Material = CAR.CVE_MATERIAL
		AND DPR.CantidadRemisionada > 0
		GROUP BY
			PI.Empresa,
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
			PI.No_Pedido,
			DPR.No_OrdenCompra,
			DPR.Partida,
			DPR.No_Parcialidad,
			DPR.DescripcionMaterialOC,
			CAR.TipoMaterial,
			CAR.Cve_Material,
			CAR.CVE_TELA,
			CAR.Cve_Grupo,
			CAR.Cve_Habilitacion
		ORDER BY
			CAR.TIPOMATERIAL,
			CAR.CVE_MATERIAL
		
		IF EXISTS(
		SELECT 
			PI.Empresa,
			@NO_REMISION,
			ROW_NUMBER() OVER (ORDER BY CAR.CVE_MATERIAL),
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
			PI.No_Pedido,
			DPR.No_OrdenCompra,
			DPR.Partida,
			DPR.No_Parcialidad,
			DPR.CantidadRemisionada,
			CAR.Descripcion,
			CAR.TipoMaterial,
			CAR.Cve_Material,
			CAR.CVE_TELA,
			CAR.Cve_Grupo,
			CAR.Cve_Habilitacion,
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
			#DISPONIBLE_PARA_REMISIONAR DPR,
			PEDIDO_INTERNO PI,
			OP_ASIGNACION OPA,
			MAQUILADOR M
		WHERE 
			PI.Empresa = @EMPRESA
		AND PI.No_Pedido = @NO_PEDIDO
		AND PI.Status NOT IN ('CANCELADO','FINALIZADO')
		AND OPA.Empresa = PI.Empresa 
		AND OPA.No_OP = @NO_OP
		AND M.Cve_Maquilador = OPA.Cve_Maquilador
		AND OPA.Estatus = 'AUTORIZADA'
		AND CAR.NO_OP = OPA.No_OP
		AND CAR.CVE_MAQUILADOR = OPA.Cve_Maquilador
		AND CAR.CANTIDAD_FINAL_A_REMISIONAR > 0
		AND CAR.TIPOMATERIAL = 'H'
		AND DPR.TipoMaterial = CAR.TIPOMATERIAL
		AND DPR.Cve_Material = CAR.CVE_MATERIAL
		AND DPR.CantidadRemisionada > 0
		)
		BEGIN
			INSERT INTO #Remisiones
			(
				No_Remision
			)
			SELECT
				@NO_REMISION
		END
		---INSERTA LOS MOVIMIENTOS DE INVENTARIO
		DECLARE MOVIMIENTOS_INVENTARIO CURSOR FOR
		SELECT
			Origen,
			No_OrdenCompra,
			Partida,
			No_Parcialidad,
			No_EntregaOReservado,
			TIPOMATERIAL,
			CVE_MATERIAL,
			CantidadRemisionada
		FROM
			#DISPONIBLE_PARA_REMISIONAR
		WHERE
			CantidadRemisionada > 0
		AND TipoMaterial = 'H'
		OPEN MOVIMIENTOS_INVENTARIO
		FETCH NEXT FROM MOVIMIENTOS_INVENTARIO INTO @Origen,@No_OrdenCompra,@Partida,@No_Parcialidad,@No_EntregaOReservado,@TIPOMATERIAL,@CVE_MATERIAL,@CantidadARemisionar
		WHILE @@FETCH_STATUS = 0
		BEGIN
			---INSERTA LOS MOVIMIENTOS DE INVENTARIO
			IF @TIPOMATERIAL = 'H'
			BEGIN
				SELECT
					@NO_MOVIMIENTO = ISNULL(MAX(HK.NoMovimiento),0)+1
				FROM 
					HABILITACION_KARDEX HK
				WHERE
					HK.Cve_Grupo = SUBSTRING(@CVE_MATERIAL,1,3)
				AND HK.Cve_Habilitacion = CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6))

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
					@NO_REMISION,
					@SALDOANTERIOR,
					@CantidadARemisionar,
					@SALDOANTERIOR-@CantidadARemisionar
				FROM
					#DISPONIBLE_PARA_REMISIONAR
				WHERE
					No_OrdenCompra = @No_OrdenCompra
				AND Partida = @Partida
				AND No_Parcialidad = @No_Parcialidad
				AND No_EntregaOReservado = @No_EntregaOReservado
				AND	TipoMaterial = @TipoMaterial
				AND Cve_Material = @Cve_Material
				
				--SE ACTUALIZA EL INVENTARIO DE MATERIAL
				--SELECT
				--	Reservado - @CantidadARemisionar AS Reservado
				--FROM 
				--	HABILITACION 
				--WHERE
				--	Cve_Grupo = SUBSTRING(@CVE_MATERIAL,1,3)
				--AND Cve_Habilitacion = CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6))
				
				UPDATE
					HABILITACION
				SET 
					Reservado = Reservado - @CantidadARemisionar
				WHERE
					Cve_Grupo = SUBSTRING(@CVE_MATERIAL,1,3)
				AND Cve_Habilitacion = CONVERT(NUMERIC(18,0),SUBSTRING(@CVE_MATERIAL,4,6))

				---SE ACTUALIZA EL RECIBO DE ORDEN_COMPRA O RESERVADO DE MATERIAL
				IF @Origen = 'RESERVADOMATERIAL'
				BEGIN
					--SELECT
					--	CantidadUsada + @CantidadARemisionar AS CantidadUsada
					--FROM
					--	RESERVADO_MATERIAL 
					--WHERE
					--	Empresa = @EMPRESA
					--AND No_Pedido = @NO_PEDIDO
					--AND TipoMaterial = @TipoMaterial
					--AND Cve_Material = @Cve_Material
					--AND No_Reservado = @No_EntregaOReservado

					UPDATE
						RESERVADO_MATERIAL 
					SET
						CantidadUsada += @CantidadARemisionar
					WHERE
						Empresa = @EMPRESA
					AND No_Pedido = @NO_PEDIDO
					AND TipoMaterial = @TipoMaterial
					AND Cve_Material = @Cve_Material
					AND No_Reservado = @No_EntregaOReservado
				END

				IF @Origen = 'OrdenCompra'
				BEGIN
					--SELECT
					--	DPR.Factor,
					--	OCFPR.CantidadDisponibleRemision - (@CantidadARemisionar/DPR.Factor) as CantidadDisponibleRemision
					--FROM
					--	ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR,
					--	#DISPONIBLE_PARA_REMISIONAR DPR 
					--WHERE
					--	OCFPR.Empresa = @EMPRESA
					--AND OCFPR.No_OrdenCompra = @No_OrdenCompra
					--AND OCFPR.Partida = @Partida
					--AND OCFPR.No_Parcialidad = @No_Parcialidad
					--AND OCFPR.No_Entrega = @No_EntregaOReservado
					--AND DPR.No_OrdenCompra = OCFPR.No_OrdenCompra
					--AND DPR.Partida = OCFPR.Partida
					--AND DPR.No_Parcialidad = OCFPR.No_Parcialidad
					--AND DPR.No_EntregaOReservado =  OCFPR.No_Entrega
					--AND DPR.TipoMaterial = @TipoMaterial
					--AND DPR.Cve_Material = @Cve_Material
					
					UPDATE
						OCFPR 
					SET
						OCFPR.CantidadDisponibleRemision -= (@CantidadARemisionar/DPR.Factor)
					FROM
						ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR,
						#DISPONIBLE_PARA_REMISIONAR DPR
					WHERE
						OCFPR.Empresa = @EMPRESA
					AND OCFPR.No_OrdenCompra = @No_OrdenCompra
					AND OCFPR.Partida = @Partida
					AND OCFPR.No_Parcialidad = @No_Parcialidad
					AND OCFPR.No_Entrega = @No_EntregaOReservado
					AND DPR.No_OrdenCompra = OCFPR.No_OrdenCompra
					AND DPR.Partida = OCFPR.Partida
					AND DPR.No_Parcialidad = OCFPR.No_Parcialidad
					AND DPR.No_EntregaOReservado =  OCFPR.No_Entrega
					AND DPR.TipoMaterial = @TipoMaterial
					AND DPR.Cve_Material = @Cve_Material
				END
			END
			FETCH NEXT FROM MOVIMIENTOS_INVENTARIO INTO @Origen,@No_OrdenCompra,@Partida,@No_Parcialidad,@No_EntregaOReservado,@TIPOMATERIAL,@CVE_MATERIAL,@CantidadARemisionar
		END
		CLOSE MOVIMIENTOS_INVENTARIO
		DEALLOCATE MOVIMIENTOS_INVENTARIO
		--SELECT * FROM #CANTIDAD_A_REMISIONAR
		--SELECT * FROM #DISPONIBLE_PARA_REMISIONAR
		SELECT * FROM #Remisiones

		DROP TABLE #CANTIDAD_A_REMISIONAR
		DROP TABLE #DISPONIBLE_PARA_REMISIONAR
		DROP TABLE #Remisiones
		
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

--EXEC OP_GENERA_REMISIONES 1,1361,0,'SISTEMASUNO'
--SELECT * FROM REMISION_MATERIAL WHERE No_OP = 1361
GO

