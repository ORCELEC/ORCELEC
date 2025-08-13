USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA]    Script Date: 13/08/2025 11:40:15 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA]
--DECLARE
	@EMPRESA NUMERIC(18,0),
	@NO_PEDIDO NUMERIC(18,0)
AS
BEGIN
	--SE MODIFICÓ EL 13/07/2023 PARA QUE DIVIDA EN LOTES EL INVENTARIO RESERVADO.
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--	SET @EMPRESA = 1
--	SET @NO_PEDIDO = 1630

	DECLARE @TRAN_STARTED BIT
	SET @TRAN_STARTED = 0
	
	BEGIN TRY
	
		BEGIN TRANSACTION
		SET @TRAN_STARTED = 1


	CREATE TABLE #PRE_EXPLOSION_MATERIALES
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		Cve_Prenda bigint,
		Prioridad bigint,
		TipoMaterial nvarchar(1),
		Cve_Tela numeric(18,0),
		Cve_Material nvarchar(20),
		Cve_Grupo nvarchar(3),
		Cve_Habilitacion numeric(18,0),
		DescripcionMaterial nvarchar(255),
		Cantidad numeric(18,2),
		Unidad nvarchar(50)
	)
	INSERT INTO #PRE_EXPLOSION_MATERIALES
	(
		Empresa,
		No_Pedido,
		Cve_Prenda,
		Prioridad,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Cantidad,
		Unidad
	)
	SELECT
		PIT.Empresa,
		PIT.No_Pedido,
		PIT.Cve_Prenda,
		PIT.Prioridad,
		PEMD.TipoMaterial,
		CASE WHEN PEMD.TipoMaterial = 'T' THEN CONVERT(NVARCHAR(15),PEMD.Cve_Tela) ELSE PEMD.Cve_Grupo + RIGHT('000000'+ CAST(PEMD.Cve_Habilitacion AS VARCHAR),6) END,
		CASE WHEN PEMD.TipoMaterial = 'T' THEN PEMD.Cve_Tela ELSE NULL END,
		CASE WHEN PEMD.TipoMaterial = 'H' THEN PEMD.Cve_Grupo ELSE NULL END,
		CASE WHEN PEMD.TipoMaterial = 'H' THEN PEMD.Cve_Habilitacion ELSE NULL END,
		PEMD.Descripcion,
		CASE WHEN TipoMaterial = 'T' THEN SUM(CONVERT(NUMERIC(18,2),((PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0))*PEMD.Consumo))/CT.ANCHO) ELSE SUM(CONVERT(NUMERIC(18,2),(PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0))*PEMD.Consumo)) END,
		CASE WHEN TipoMaterial = 'T' THEN 'METROS' ELSE HG.Unidad END
	FROM
		PRENDA_ESTRUCTURA_MATERIALES PEM,
		PEDIDO_INTERNO_TALLAS PIT
		LEFT JOIN
			RESERVADO_INVENTARIO_PRODUCTO_TERMINADO RIPT
		ON
			RIPT.Empresa = PIT.Empresa
		AND RIPT.No_Pedido = PIT.No_Pedido
		AND RIPT.Partida = PIT.Partida
		AND RIPT.Cve_Prenda = PIT.Cve_Prenda
		AND RIPT.LugarDeEntrega = PIT.LugarDeEntrega
		AND RIPT.Prioridad = PIT.Prioridad
		AND RIPT.Talla = PIT.Talla,
		PRENDA_ESTRUCTURA_MATERIALES_DETALLE PEMD
		LEFT JOIN
			CATALOGO_TELA CT
		ON
			CT.Cve_Tela = PEMD.Cve_Tela
		LEFT JOIN
			HABILITACION_GRUPO HG
		ON
			HG.Cve_Grupo = PEMD.Cve_Grupo
	WHERE
		PIT.Empresa = @EMPRESA
	AND PIT.No_Pedido = @NO_PEDIDO
	AND	PEMD.Cve_Prenda = PIT.Cve_Prenda
	AND PEM.Cve_Prenda = PEMD.Cve_Prenda
	AND PEM.Partida = PEMD.Partida
	AND PIT.Talla = PEM.Talla
	GROUP BY
		PIT.Empresa,
		PIT.No_Pedido,
		PIT.Cve_Prenda,
		PIT.Prioridad,
		PEMD.TipoMaterial,
		PEMD.Cve_Tela,
		PEMD.Cve_Grupo,
		PEMD.Cve_Habilitacion,
		PEMD.Descripcion,
		HG.Unidad

	UPDATE 
		#PRE_EXPLOSION_MATERIALES
	SET 
		Cantidad = CEILING(Cantidad)
	WHERE 
		Unidad = 'PIEZA(S)' 
	AND Cantidad != ROUND(Cantidad, 0);

	CREATE TABLE #EXPLOSION_MATERIALES
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		TipoMaterial nvarchar(1),
		Cve_Tela numeric(18,0),
		Cve_Material nvarchar(20),
		Cve_Grupo nvarchar(3),
		Cve_Habilitacion numeric(18,0),
		DescripcionMaterial nvarchar(255),
		Cve_Proveedor numeric(18,0),
		Proveedor nvarchar(255),
		Stock numeric(18,2),
		Cantidad numeric(18,2),
		Unidad nvarchar(50)
	)
	
	--PRIMERO SE HACE LA EXPLOSIÓN DE MATERIALES POR TALLA Y PRENDA
	INSERT INTO #EXPLOSION_MATERIALES
	(
		Empresa,
		No_Pedido,
		Cve_Material,
		TipoMaterial,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Cantidad,
		Unidad
	)
	SELECT
		Empresa,
		No_Pedido,
		Cve_Material,
		TipoMaterial,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		SUM(Cantidad),
		Unidad
	FROM
		#PRE_EXPLOSION_MATERIALES
	GROUP BY
		Empresa,
		No_Pedido,
		TipoMaterial,
		Cve_Tela,
		Cve_Material,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Unidad

	DROP TABLE #PRE_EXPLOSION_MATERIALES
	
	UPDATE
		#EXPLOSION_MATERIALES
	SET
		Cve_Proveedor = (SELECT CT.Cve_Proveedor FROM CATALOGO_TELA CT,PROVEEDOR P WHERE CT.Cve_Tela = #EXPLOSION_MATERIALES.Cve_Tela AND P.Cve_Proveedor = CT.Cve_Proveedor),
		Proveedor = (SELECT P.Nom_Proveedor FROM CATALOGO_TELA CT,PROVEEDOR P WHERE CT.Cve_Tela = #EXPLOSION_MATERIALES.Cve_Tela AND P.Cve_Proveedor = CT.Cve_Proveedor)
	WHERE
		TIPOMATERIAL = 'T'

	--UPDATE
	--	#EXPLOSION_MATERIALES
	--SET
	--	Stock = (SELECT H.Existencia FROM HABILITACION H WHERE H.Cve_Grupo = #EXPLOSION_MATERIALES.Cve_Grupo AND H.Cve_Habilitacion = #EXPLOSION_MATERIALES.Cve_Habilitacion)
	--WHERE
	--	TIPOMATERIAL = 'H'

	CREATE TABLE #LOTES
	(
		CONSECUTIVO BIGINT,
		CantidadMovimiento NUMERIC(18,2),
		Origen NVARCHAR(50),
		Origen_No NUMERIC(18,0),
		No_Documento NUMERIC(18,0)
	)
	
	CREATE TABLE #EXPLOSION_MATERIALESFINAL
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		TipoMaterial nvarchar(1),
		Cve_Material nvarchar(20),
		Cve_Tela numeric(18,0),
		Cve_Grupo nvarchar(3),
		Cve_Habilitacion numeric(18,0),
		DescripcionMaterial nvarchar(255),
		Cve_Proveedor numeric(18,0),
		Proveedor nvarchar(255),
		Stock numeric(18,2),
		Cantidad numeric(18,2),
		Unidad nvarchar(50)
	)
	INSERT INTO #EXPLOSION_MATERIALESFINAL
	(
		Empresa,
		No_Pedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Cve_Proveedor,
		Proveedor,
		Stock,
		Cantidad,
		Unidad
	)
	SELECT
		Empresa,
		No_Pedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		CVE_PROVEEDOR,
		PROVEEDOR,
		0,
		SUM(CANTIDAD) AS CANTIDAD_CONSUMO,
		Unidad
	FROM
		#EXPLOSION_MATERIALES
	GROUP BY
		Empresa,
		No_Pedido,
		Cve_Material,
		TipoMaterial,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		CVE_PROVEEDOR,
		PROVEEDOR,
		Unidad

	DROP TABLE #EXPLOSION_MATERIALES

	--SE BUSCARA Y APARTARA MATERIAL EN EXISTENCIA, SOLO EN INVENTARIO
	
	DECLARE
		@TIPOMATERIAL NVARCHAR(1),
		@CVE_TELA NUMERIC(18,0),
		@CVE_GRUPO NVARCHAR(3),
		@CVE_HABILITACION NUMERIC(18,0),
		@DESCRIPCIONMATERIAL NVARCHAR(500),
		@DESCRIPCIONMATERIALOC NVARCHAR(500),
		@CANTIDAD_CONSUMO NUMERIC(18,2),
		@STOCK NUMERIC(18,2),
		@EXISTENCIAMATERIAL NUMERIC(18,2),
		@INVENTARIO NUMERIC(18,2),
		@ORIGEN NVARCHAR(50),
		@ORIGEN_NO NUMERIC(18,0),
		@NO_DOCUMENTO NUMERIC(18,0),
		@PARTIDA_OC NUMERIC(18,0),
		@CONSECUTIVO BIGINT,
		@ITERACIONES_LOTEINVENTARIO BIGINT,
		@CONSECUTIVO_LOTEINVENTARIO BIGINT,
		@EXISTENCIA_AUX NUMERIC(18,2),
		@EXISTENCIA_LOTE NUMERIC(18,2),
		@CONTADOR BIGINT,
		@ORIGEN_ACTUAL NVARCHAR(50),
		@ORIGEN_NO_ACTUAL NUMERIC(18,0),
		@NO_DOCUMENTO_ACTUAL NUMERIC(18,0)
	
	DECLARE LISTAMATERIALES CURSOR FOR
	SELECT
		Empresa,
		No_Pedido,
		TipoMaterial,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Cantidad
	FROM
		#EXPLOSION_MATERIALESFINAL EM
	OPEN LISTAMATERIALES
	FETCH NEXT FROM LISTAMATERIALES INTO @EMPRESA,@NO_PEDIDO,@TIPOMATERIAL,@CVE_TELA,@CVE_GRUPO,@CVE_HABILITACION,@DESCRIPCIONMATERIAL,@CANTIDAD_CONSUMO
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--SE REINICIAN VARIABLES AUXILIARES A 0
		SET @STOCK = 0
		SET @EXISTENCIAMATERIAL = 0

		IF @TIPOMATERIAL = 'T' --CODIGO PARA TELAS
		BEGIN
			--PRIMERO VAMOS A BUSCAR EN INVENTARIO
			SELECT
				@EXISTENCIAMATERIAL = ISNULL(Existencia,0)
			FROM
				CATALOGO_TELA
			WHERE
				Cve_Tela = @CVE_TELA

			IF @EXISTENCIAMATERIAL > 0
			BEGIN
				DELETE #LOTES
				--SE CHECA EL NÚMERO DE LOTES QUE SE TIENEN QUE TOMAR EN CUENTA
				--SE HACE EL PROCESO DE CONTEO DE LOTE
				--------------ESTE CÓDIGO SE MODIFICO EL 29/04/2024
				--SET @EXISTENCIA_AUX = @EXISTENCIAMATERIAL
				--SET @ITERACIONES_LOTEINVENTARIO = 0
				--WHILE @EXISTENCIA_AUX > 0
				--BEGIN
				--	SELECT
				--		TOP (@ITERACIONES_LOTEINVENTARIO+1) @EXISTENCIA_LOTE = CantidadMovimiento
				--	FROM 
				--		TELA_MOVIMIENTO TM 
				--	WHERE 
				--		TM.Cve_Tela = @CVE_TELA 
				--	AND TM.TipoMovimiento = 'E' 
				--	AND TM.Origen NOT IN ('REMISIÓN')
				--	ORDER BY 
				--		TM.NoMovimiento DESC
					
				--	IF @EXISTENCIA_LOTE <= @EXISTENCIA_AUX
				--	BEGIN
				--		SET @EXISTENCIA_AUX = @EXISTENCIA_AUX-@EXISTENCIA_LOTE
				--		INSERT INTO #LOTES
				--		(
				--			CONSECUTIVO,
				--			CantidadMovimiento,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		)
				--		SELECT
				--			TOP (@ITERACIONES_LOTEINVENTARIO+1) 
				--			@ITERACIONES_LOTEINVENTARIO+1,
				--			@EXISTENCIA_LOTE,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		FROM
				--			TELA_MOVIMIENTO TM
				--		WHERE
				--			TM.Cve_Tela = @CVE_TELA
				--		AND TM.TipoMovimiento = 'E'
				--		AND TM.ORIGEN NOT IN ('REMISIÓN')
				--		ORDER BY
				--			TM.NoMovimiento DESC
				--	END
				--	ELSE
				--	BEGIN
				--		INSERT INTO #LOTES
				--		(
				--			CONSECUTIVO,
				--			CantidadMovimiento,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		)
				--		SELECT
				--			TOP (@ITERACIONES_LOTEINVENTARIO+1) 
				--			@ITERACIONES_LOTEINVENTARIO+1,
				--			@EXISTENCIA_AUX,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		FROM
				--			TELA_MOVIMIENTO TM
				--		WHERE
				--			TM.Cve_Tela = @CVE_TELA
				--		AND TM.TipoMovimiento = 'E'
				--		AND TM.ORIGEN NOT IN ('REMISIÓN')
				--		ORDER BY
				--			TM.NoMovimiento DESC
				--		SET @EXISTENCIA_AUX = 0
				--	END
				--	SET @ITERACIONES_LOTEINVENTARIO += 1
				--END
				--------------ESTE CÓDIGO SE MODIFICO EL 29/04/2024
				--------------ESTE CÓDIGO SE INSERTO EL 29/04/2024
				SET @EXISTENCIA_AUX = @EXISTENCIAMATERIAL;
				SET @ITERACIONES_LOTEINVENTARIO = 0;
				SET @CONSECUTIVO_LOTEINVENTARIO = 0

				WHILE @EXISTENCIA_AUX > 0
				BEGIN
					SELECT TOP (@ITERACIONES_LOTEINVENTARIO+1)
						@EXISTENCIA_LOTE = CantidadMovimiento,
						@ORIGEN_ACTUAL = Origen,
						@ORIGEN_NO_ACTUAL = Origen_No,
						@NO_DOCUMENTO_ACTUAL = No_Documento
					FROM TELA_MOVIMIENTO TM 
					WHERE TM.Cve_Tela = @CVE_TELA 
						AND TM.TipoMovimiento = 'E' 
						AND TM.Origen NOT IN ('REMISIÓN')
					ORDER BY TM.NoMovimiento DESC;

					IF @EXISTENCIA_LOTE <= @EXISTENCIA_AUX
					BEGIN
						SET @EXISTENCIA_AUX = @EXISTENCIA_AUX - @EXISTENCIA_LOTE;
					END
					ELSE
					BEGIN
						SET @EXISTENCIA_LOTE = @EXISTENCIA_AUX;
						SET @EXISTENCIA_AUX = 0;
					END

					IF EXISTS (
						SELECT 1 
						FROM #LOTES 
						WHERE Origen = @ORIGEN_ACTUAL 
							AND Origen_No = @ORIGEN_NO_ACTUAL 
							AND No_Documento = @NO_DOCUMENTO_ACTUAL
					)
					BEGIN
						UPDATE #LOTES
						SET CantidadMovimiento += @EXISTENCIA_LOTE
						WHERE Origen = @ORIGEN_ACTUAL 
							AND Origen_No = @ORIGEN_NO_ACTUAL 
							AND No_Documento = @NO_DOCUMENTO_ACTUAL;
					END
					ELSE
					BEGIN
						INSERT INTO #LOTES
						(
							CONSECUTIVO,
							CantidadMovimiento,
							Origen,
							Origen_No,
							No_Documento
						)
						VALUES
						(
							@CONSECUTIVO_LOTEINVENTARIO + 1,
							@EXISTENCIA_LOTE,
							@ORIGEN_ACTUAL,
							@ORIGEN_NO_ACTUAL,
							@NO_DOCUMENTO_ACTUAL
						);
						SET @CONSECUTIVO_LOTEINVENTARIO += 1
					END

					SET @ITERACIONES_LOTEINVENTARIO += 1;
				END
				select 'telas', * from #LOTES
				SET @EXISTENCIA_AUX = @EXISTENCIAMATERIAL
				--SE CORRE EL PROCESO DE ASIGNACIÓN LA CANTIDAD DE LOTES LA CANTIDAD DE LOTES QUE SE DETERMINARON
				SELECT @CONTADOR = COUNT(*) FROM #LOTES
				WHILE @CONTADOR > 0
				BEGIN
					IF @CANTIDAD_CONSUMO > 0
					BEGIN
						--COMO HAY EXISTENCIA, VAMOS A OBTENER LOTE DEL ULTIMO MOVIMIENTO DE INVENTARIO DE ENTRADA
						SELECT
							@EXISTENCIA_LOTE = L.CantidadMovimiento,
							@ORIGEN = L.Origen,
							@ORIGEN_NO = L.Origen_No,
							@NO_DOCUMENTO = L.No_Documento,
							@PARTIDA_OC = (SELECT OC.Partida FROM ORDEN_COMPRA OC WHERE OC.Empresa = @EMPRESA AND OC.No_OrdenCompra = L.Origen_No AND OC.TipoMaterial = 'T' AND OC.Cve_Material = CONVERT(NVARCHAR,@CVE_TELA))
						FROM
							#LOTES L
						WHERE
							L.CONSECUTIVO = @CONTADOR
							SELECT @EXISTENCIA_LOTE AS EXISTENCIA_LOTE,@ORIGEN AS ORIGEN,@ORIGEN_NO AS ORIGEN_NO,@NO_DOCUMENTO AS NO_DOCUMENTO,@PARTIDA_OC AS PARTIDA_OC
						IF @EXISTENCIA_LOTE <= @CANTIDAD_CONSUMO
						BEGIN
							--COMO LA EXISTENCIA ES MENOR O IGUAL A LO REQUERIDO, SE RESERVA TODA LA TELA DISPONIBLE
							UPDATE
								CATALOGO_TELA
							SET 
								Existencia = Existencia-@EXISTENCIA_LOTE,
								Reservado = Reservado+@EXISTENCIA_LOTE
							WHERE
								Cve_Tela = @CVE_TELA

							--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
							SELECT
								@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
							FROM
								RESERVADO_MATERIAL
							WHERE
								EMPRESA = @EMPRESA
					
							SET @CONSECUTIVO += 1

							--SE OBTIENE LA DESCRIPCIÓN DEL MATERIAL DE LA OC
							SELECT @DESCRIPCIONMATERIALOC = DescripcionMaterial FROM ORDEN_COMPRA WHERE Empresa = @EMPRESA AND No_OrdenCompra = @ORIGEN_NO AND TipoMaterial = @TIPOMATERIAL AND Cve_Material = @CVE_TELA
							
							--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
							INSERT INTO RESERVADO_MATERIAL
							(
								Empresa,
								No_Reservado,
								No_Pedido,
								TipoMaterial,
								Cve_Material,
								Cve_Tela,
								DescripcionMaterial,
								TipoReservado,
								Origen_No,
								No_Documento,
								CantidadReservada,
								CantidadUsada,
								Estatus,
								FECHAHORA,
								No_OP
							)
							VALUES
							(
								@EMPRESA,
								@CONSECUTIVO,
								@NO_PEDIDO,
								@TIPOMATERIAL,
								CONVERT(NVARCHAR,@CVE_TELA),
								@CVE_TELA,
								@DESCRIPCIONMATERIALOC,
								@ORIGEN,
								@ORIGEN_NO,
								@NO_DOCUMENTO,
								@EXISTENCIA_LOTE,
								0,
								'DISPONIBLE',
								GETDATE(),
								0
							)
							------------------------------
							SELECT 
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								CONVERT(NVARCHAR,@CVE_TELA),
								@DESCRIPCIONMATERIAL,
								1,
								@EXISTENCIA_LOTE,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@EXISTENCIA_LOTE
							
							INSERT INTO ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO
							(
								Empresa,
								No_Pedido,
								No_OrdenCompra,
								Partida,
								TipoMaterial,
								Cve_Material,
								Descripcion_Material,
								Factor,
								Cantidad,
								No_Parcialidad,
								FechaPromesa,
								CantidadPromesa,
								No_OP
							)
							SELECT 
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								CONVERT(NVARCHAR,@CVE_TELA),
								@DESCRIPCIONMATERIAL,
								1,
								@EXISTENCIA_LOTE,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@EXISTENCIA_LOTE,
								0 AS No_OP

							--ACTUALIZA STOCK Y CONSUMO
							SET @STOCK += @EXISTENCIA_LOTE
							SET @CANTIDAD_CONSUMO -= @EXISTENCIA_LOTE
						END
						ELSE
						BEGIN
							--COMO LA EXISTENCIA ES MAYOR A LO REQUERIDO, SE RESERVA LA CANTIDAD REQUERIDA
							UPDATE
								CATALOGO_TELA
							SET 
								Existencia = Existencia-@CANTIDAD_CONSUMO,
								Reservado = Reservado+@CANTIDAD_CONSUMO
							WHERE
								Cve_Tela = @CVE_TELA

							--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
							SELECT
								@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
							FROM
								RESERVADO_MATERIAL
							WHERE
								EMPRESA = @EMPRESA
					
							SET @CONSECUTIVO += 1

							--SE OBTIENE LA DESCRIPCIÓN DEL MATERIAL DE LA OC
							SELECT @DESCRIPCIONMATERIALOC = DescripcionMaterial FROM ORDEN_COMPRA WHERE Empresa = @EMPRESA AND No_OrdenCompra = @ORIGEN_NO AND TipoMaterial = @TIPOMATERIAL AND Cve_Material = @CVE_TELA

							--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
							INSERT INTO RESERVADO_MATERIAL
							(
								Empresa,
								No_Reservado,
								No_Pedido,
								TipoMaterial,
								Cve_Material,
								Cve_Tela,
								DescripcionMaterial,
								TipoReservado,
								Origen_No,
								No_Documento,
								CantidadReservada,
								CantidadUsada,
								Estatus,
								FECHAHORA,
								No_OP
							)
							VALUES
							(
								@EMPRESA,
								@CONSECUTIVO,
								@NO_PEDIDO,
								@TIPOMATERIAL,
								CONVERT(NVARCHAR,@CVE_TELA),
								@CVE_TELA,
								@DESCRIPCIONMATERIALOC,
								@ORIGEN,
								@ORIGEN_NO,
								@NO_DOCUMENTO,
								@CANTIDAD_CONSUMO,
								0,
								'DISPONIBLE',
								GETDATE(),
								0
							)

							SELECT
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								CONVERT(NVARCHAR,@CVE_TELA),
								@DESCRIPCIONMATERIAL,
								1,
								@CANTIDAD_CONSUMO,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@CANTIDAD_CONSUMO

							INSERT INTO ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO
							(
								Empresa,
								No_Pedido,
								No_OrdenCompra,
								Partida,
								TipoMaterial,
								Cve_Material,
								Descripcion_Material,
								Factor,
								Cantidad,
								No_Parcialidad,
								FechaPromesa,
								CantidadPromesa,
								No_OP
							)
							SELECT
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								CONVERT(NVARCHAR,@CVE_TELA),
								@DESCRIPCIONMATERIAL,
								1,
								@CANTIDAD_CONSUMO,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@CANTIDAD_CONSUMO,
								0 AS No_OP

							--ACTUALIZA STOCK Y CONSUMO
							SET @STOCK += @CANTIDAD_CONSUMO
							SET @CANTIDAD_CONSUMO = 0
						END
					END
					SET @CONTADOR-=1
				END
			END

			----CONTINUA VERIFICANDO QUE HAYA MATERIAL AHORA EN OC SI ES QUE TODAVIA HAY CONSUMO PENDIENTE
			--IF @CANTIDAD_CONSUMO > 0
			--BEGIN
				
			--	--SE CREA CURSOR CON LAS OC QUE HAYA DISPONIBLE MATERIAL EN OC
			--	DECLARE LISTAOC CURSOR FOR
			--	SELECT
			--		OC.No_OrdenCompra,
			--		OC.PARTIDA,
			--		(SELECT MAX(No_Parcialidad) FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA OCFPE WHERE OCFPE.Empresa = @EMPRESA AND OCFPE.No_OrdenCompra = OC.No_OrdenCompra AND OCFPE.Partida = OC.Partida),
			--		CantidadDisponible
			--	FROM 
			--		ORDEN_COMPRA OC
			--	WHERE
			--		Empresa = @EMPRESA
			--	AND TipoMaterial = @TIPOMATERIAL
			--	AND Cve_Material = @CVE_TELA
			--	AND Status = 'AUTORIZADA'
			--	AND Recibido = 0
			--	AND CantidadDisponible > 0
			--	OPEN LISTAOC
			--	FETCH NEXT FROM LISTAOC INTO @ORIGEN_NO,@PARTIDA_OC,@NO_DOCUMENTO,@EXISTENCIAMATERIAL
			--	WHILE @@FETCH_STATUS = 0
			--	BEGIN
			--		IF @CANTIDAD_CONSUMO > 0
			--		BEGIN
			--			IF @EXISTENCIAMATERIAL <= @CANTIDAD_CONSUMO
			--			BEGIN
			--				--COMO LA CANTIDAD DISPONIBLE DE LA OC ES MENOR A LO REQUERIDO SE TOMA COMPLETO
			--				--SE ACTUALIZA LA CANTIDADDISPONIBLE DE LA OC
			--				UPDATE
			--					ORDEN_COMPRA
			--				SET
			--					CantidadDisponible = CantidadDisponible-@EXISTENCIAMATERIAL
			--				WHERE
			--					Empresa = @EMPRESA
			--				AND No_OrdenCompra = @ORIGEN_NO
			--				AND Partida = @PARTIDA_OC
			--				AND TipoMaterial = @TIPOMATERIAL
			--				AND Cve_Material = @CVE_TELA
			--				AND Status = 'AUTORIZADA'
			--				AND Recibido = 0
							
			--				--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
			--				SELECT
			--					@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
			--				FROM
			--					RESERVADO_MATERIAL
			--				WHERE
			--					EMPRESA = @EMPRESA
					
			--				SET @CONSECUTIVO += 1

			--				--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
			--				INSERT INTO RESERVADO_MATERIAL
			--				(
			--					Empresa,
			--					No_Reservado,
			--					No_Pedido,
			--					TipoMaterial,
			--					Cve_Tela,
			--					DescripcionMaterial,
			--					TipoReservado,
			--					Origen_No,
			--					No_Documento,
			--					CantidadReservada,
			--					CantidadUsada,
			--					Estatus,
			--					FECHAHORA
			--				)
			--				VALUES
			--				(
			--					@EMPRESA,
			--					@CONSECUTIVO,
			--					@NO_PEDIDO,
			--					@TIPOMATERIAL,
			--					@CVE_TELA,
			--					@DESCRIPCIONMATERIAL,
			--					'OC',
			--					@ORIGEN_NO,
			--					@NO_DOCUMENTO,
			--					@EXISTENCIAMATERIAL,
			--					0,
			--					'DISPONIBLE',
			--					GETDATE()
			--				)

			--				--ACTUALIZA STOCK Y CONSUMO
			--				SET @STOCK += @EXISTENCIAMATERIAL
			--				SET @CANTIDAD_CONSUMO -= @EXISTENCIAMATERIAL
			--			END
			--			ELSE
			--			BEGIN
			--				--COMO LA CANTIDAD DISPONIBLE DE LA OC ES MAYOR A LO REQUERIDO SE RESERVA LO REQUERIDO
			--				--SE ACTUALIZA LA CANTIDADDISPONIBLE DE LA OC
			--				UPDATE
			--					ORDEN_COMPRA
			--				SET
			--					CantidadDisponible = CantidadDisponible-@CANTIDAD_CONSUMO
			--				WHERE
			--					Empresa = @EMPRESA
			--				AND No_OrdenCompra = @ORIGEN_NO
			--				AND Partida = @PARTIDA_OC
			--				AND TipoMaterial = @TIPOMATERIAL
			--				AND Cve_Material = @CVE_TELA
			--				AND Status = 'AUTORIZADA'
			--				AND Recibido = 0
							
			--				--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
			--				SELECT
			--					@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
			--				FROM
			--					RESERVADO_MATERIAL
			--				WHERE
			--					EMPRESA = @EMPRESA
					
			--				SET @CONSECUTIVO += 1

			--				--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
			--				INSERT INTO RESERVADO_MATERIAL
			--				(
			--					Empresa,
			--					No_Reservado,
			--					No_Pedido,
			--					TipoMaterial,
			--					Cve_Tela,
			--					DescripcionMaterial,
			--					TipoReservado,
			--					Origen_No,
			--					No_Documento,
			--					CantidadReservada,
			--					CantidadUsada,
			--					Estatus,
			--					FECHAHORA
			--				)
			--				VALUES
			--				(
			--					@EMPRESA,
			--					@CONSECUTIVO,
			--					@NO_PEDIDO,
			--					@TIPOMATERIAL,
			--					@CVE_TELA,
			--					@DESCRIPCIONMATERIAL,
			--					'OC',
			--					@ORIGEN_NO,
			--					@NO_DOCUMENTO,
			--					@CANTIDAD_CONSUMO,
			--					0,
			--					'DISPONIBLE',
			--					GETDATE()
			--				)

			--				--ACTUALIZA STOCK Y CONSUMO
			--				SET @STOCK += @CANTIDAD_CONSUMO
			--				SET @CANTIDAD_CONSUMO = 0
			--			END
			--		END
			--		FETCH NEXT FROM LISTAOC INTO @ORIGEN_NO,@PARTIDA_OC,@NO_DOCUMENTO,@EXISTENCIAMATERIAL
			--	END
			--	CLOSE LISTAOC
			--	DEALLOCATE LISTAOC
			--END

			--ACTUALIZA TABLA DE EXPLOSION DE MATERIALES CON LAS CANTIDAD ACTUALIZADAS
			UPDATE
				#EXPLOSION_MATERIALESFINAL
			SET
				Stock = @STOCK,
				Cantidad = @CANTIDAD_CONSUMO
			WHERE
				Empresa = @EMPRESA
			AND No_Pedido = @NO_PEDIDO
			AND TipoMaterial = @TIPOMATERIAL
			AND Cve_Tela = @CVE_TELA

		END ---TERMINA CODIGO PARA TELAS


		IF @TIPOMATERIAL = 'H' --CODIGO PARA HABILITACIONES
		BEGIN
			--PRIMERO VAMOS A BUSCAR EN INVENTARIO
			SELECT
				@EXISTENCIAMATERIAL = ISNULL(Existencia,0)
			FROM
				HABILITACION
			WHERE
				Cve_Grupo = @CVE_GRUPO
			AND Cve_Habilitacion = @CVE_HABILITACION

			IF @EXISTENCIAMATERIAL > 0
			BEGIN
				--COMO HAY EXISTENCIA, VAMOS A OBTENER LOS LOTES
				DELETE #LOTES
				--SE CHECA EL NÚMERO DE LOTES QUE SE TIENEN QUE TOMAR EN CUENTA
				--SE HACE EL PROCESO DE CONTEO DE LOTE
				----------ESTE CÓDIGO SE DESHABILITA EL 29/04/2024
				--SET @EXISTENCIA_AUX = @EXISTENCIAMATERIAL
				--SET @ITERACIONES_LOTEINVENTARIO = 0
				--WHILE @EXISTENCIA_AUX > 0
				--BEGIN
				--	SELECT
				--		TOP (@ITERACIONES_LOTEINVENTARIO+1)
				--		@EXISTENCIA_LOTE = HK.CantidadMovimiento
				--	FROM
				--		HABILITACION_KARDEX HK
				--	WHERE
				--		HK.Cve_Grupo = @CVE_GRUPO
				--	AND HK.Cve_Habilitacion = @CVE_HABILITACION
				--	AND HK.TipoMovimiento = 'E'
				--	AND HK.Origen NOT IN ('REMISIÓN')
				--	ORDER BY
				--		HK.NoMovimiento DESC
					
				--	IF @EXISTENCIA_LOTE <= @EXISTENCIA_AUX
				--	BEGIN
				--		SET @EXISTENCIA_AUX = @EXISTENCIA_AUX-@EXISTENCIA_LOTE
				--		INSERT INTO #LOTES
				--		(
				--			CONSECUTIVO,
				--			CantidadMovimiento,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		)
				--		SELECT
				--			TOP (@ITERACIONES_LOTEINVENTARIO+1) 
				--			@ITERACIONES_LOTEINVENTARIO+1,
				--			@EXISTENCIA_LOTE,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		FROM
				--			HABILITACION_KARDEX HK
				--		WHERE
				--			HK.Cve_Grupo = @CVE_GRUPO
				--		AND HK.Cve_Habilitacion = @CVE_HABILITACION
				--		AND HK.TipoMovimiento = 'E'
				--		AND HK.Origen NOT IN ('REMISIÓN')
				--		ORDER BY
				--			HK.NoMovimiento DESC
				--	END
				--	ELSE
				--	BEGIN
				--		INSERT INTO #LOTES
				--		(
				--			CONSECUTIVO,
				--			CantidadMovimiento,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		)
				--		SELECT
				--			TOP (@ITERACIONES_LOTEINVENTARIO+1) 
				--			@ITERACIONES_LOTEINVENTARIO+1,
				--			@EXISTENCIA_AUX,
				--			Origen,
				--			Origen_No,
				--			No_Documento
				--		FROM
				--			HABILITACION_KARDEX HK
				--		WHERE
				--			HK.Cve_Grupo = @CVE_GRUPO
				--		AND HK.Cve_Habilitacion = @CVE_HABILITACION
				--		AND HK.TipoMovimiento = 'E'
				--		AND HK.Origen NOT IN ('REMISIÓN')
				--		ORDER BY
				--			HK.NoMovimiento DESC
				--		SET @EXISTENCIA_AUX = 0
				--	END
				--	SET @ITERACIONES_LOTEINVENTARIO += 1
				--END
				----FIN DE CÓDIGO DESHABILITADO
				----SE INSERTA NUEVO CÓDIGO EL 29/04/2024
				SET @EXISTENCIA_AUX = @EXISTENCIAMATERIAL;
				SET @ITERACIONES_LOTEINVENTARIO = 0;
				SET @CONSECUTIVO_LOTEINVENTARIO = 0

				WHILE @EXISTENCIA_AUX > 0
				BEGIN

					SELECT TOP (@ITERACIONES_LOTEINVENTARIO+1)
						@EXISTENCIA_LOTE = HK.CantidadMovimiento,
						@ORIGEN_ACTUAL = HK.Origen,
						@ORIGEN_NO_ACTUAL = HK.Origen_No,
						@NO_DOCUMENTO_ACTUAL = HK.No_Documento
					FROM HABILITACION_KARDEX HK
					WHERE HK.Cve_Grupo = @CVE_GRUPO
						AND HK.Cve_Habilitacion = @CVE_HABILITACION
						AND HK.TipoMovimiento = 'E'
						AND HK.Origen NOT IN ('REMISIÓN')
					ORDER BY HK.NoMovimiento DESC;

					IF @EXISTENCIA_LOTE <= @EXISTENCIA_AUX
					BEGIN
						SET @EXISTENCIA_AUX = @EXISTENCIA_AUX - @EXISTENCIA_LOTE;
					END
					ELSE
					BEGIN
						SET @EXISTENCIA_LOTE = @EXISTENCIA_AUX;
						SET @EXISTENCIA_AUX = 0;
					END

					IF EXISTS (
						SELECT 1 FROM #LOTES
						WHERE Origen = @ORIGEN_ACTUAL
							AND Origen_No = @ORIGEN_NO_ACTUAL
							AND No_Documento = @NO_DOCUMENTO_ACTUAL
					)
					BEGIN
						UPDATE #LOTES
						SET CantidadMovimiento += @EXISTENCIA_LOTE
						WHERE Origen = @ORIGEN_ACTUAL
							AND Origen_No = @ORIGEN_NO_ACTUAL
							AND No_Documento = @NO_DOCUMENTO_ACTUAL;
					END
					ELSE
					BEGIN
						INSERT INTO #LOTES
						(
							CONSECUTIVO,
							CantidadMovimiento,
							Origen,
							Origen_No,
							No_Documento
						)
						VALUES
						(
							@CONSECUTIVO_LOTEINVENTARIO + 1,
							@EXISTENCIA_LOTE,
							@ORIGEN_ACTUAL,
							@ORIGEN_NO_ACTUAL,
							@NO_DOCUMENTO_ACTUAL
						);
						SET @CONSECUTIVO_LOTEINVENTARIO += 1;
					END

					SET @ITERACIONES_LOTEINVENTARIO += 1;
				END

				--select 'habilitaciones',* from #LOTES
				SET @EXISTENCIA_AUX = @EXISTENCIAMATERIAL
				--SE CORRE EL PROCESO DE ASIGNACIÓN LA CANTIDAD DE LOTES LA CANTIDAD DE LOTES QUE SE DETERMINARON
				--SELECT 'HABILITACIONES',@ITERACIONES_LOTEINVENTARIO AS CANTLOTESDETERMINADOS
				SELECT @CONTADOR = COUNT(*) FROM #LOTES

				WHILE @CONTADOR > 0
				BEGIN
					IF @CANTIDAD_CONSUMO > 0
					BEGIN
						SELECT
							@EXISTENCIA_LOTE = L.CantidadMovimiento,
							@ORIGEN = L.Origen,
							@ORIGEN_NO = L.Origen_No,
							@NO_DOCUMENTO = L.No_Documento,
							@PARTIDA_OC = (SELECT OC.Partida FROM ORDEN_COMPRA OC WHERE OC.Empresa = @EMPRESA AND OC.No_OrdenCompra = L.Origen_No AND OC.TipoMaterial = 'H' AND OC.Cve_Material = @CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6))
						FROM
							#LOTES L
						WHERE
							L.CONSECUTIVO = @CONTADOR

						IF @EXISTENCIA_LOTE <= @CANTIDAD_CONSUMO
						BEGIN

							--COMO LA EXISTENCIA ES MENOR O IGUAL A LO REQUERIDO, SE RESERVA TODA LA HABILITACIÓN DISPONIBLE
							UPDATE
								HABILITACION
							SET 
								Existencia = Existencia-@EXISTENCIA_LOTE,
								Reservado = Reservado+@EXISTENCIA_LOTE
							WHERE
								Cve_Grupo = @CVE_GRUPO
							AND Cve_Habilitacion = @CVE_HABILITACION

							--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
							SELECT
								@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
							FROM
								RESERVADO_MATERIAL
							WHERE
								EMPRESA = @EMPRESA
					
							SET @CONSECUTIVO += 1

							--SE OBTIENE LA DESCRIPCIÓN DEL MATERIAL DE LA OC
							SELECT @DESCRIPCIONMATERIALOC = DescripcionMaterial FROM ORDEN_COMPRA WHERE Empresa = @EMPRESA AND No_OrdenCompra = @ORIGEN_NO AND TipoMaterial = @TIPOMATERIAL AND Cve_Material = @CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6)

							--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
							INSERT INTO RESERVADO_MATERIAL
							(
								Empresa,
								No_Reservado,
								No_Pedido,
								TipoMaterial,
								Cve_Material,
								Cve_Grupo,
								Cve_Habilitacion,
								DescripcionMaterial,
								TipoReservado,
								Origen_No,
								No_Documento,
								CantidadReservada,
								CantidadUsada,
								Estatus,
								FECHAHORA,
								No_OP
							)
							VALUES
							(
								@EMPRESA,
								@CONSECUTIVO,
								@NO_PEDIDO,
								@TIPOMATERIAL,
								@CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6),
								@CVE_GRUPO,
								@CVE_HABILITACION,
								@DESCRIPCIONMATERIALOC,
								@ORIGEN,
								@ORIGEN_NO,
								@NO_DOCUMENTO,
								@EXISTENCIA_LOTE,
								0,
								'DISPONIBLE',
								GETDATE(),
								0
							)

							SELECT
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								@CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6),
								@DESCRIPCIONMATERIAL,
								1,
								@EXISTENCIA_LOTE,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@EXISTENCIA_LOTE

							INSERT INTO ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO
							(
								Empresa,
								No_Pedido,
								No_OrdenCompra,
								Partida,
								TipoMaterial,
								Cve_Material,
								Descripcion_Material,
								Factor,
								Cantidad,
								No_Parcialidad,
								FechaPromesa,
								CantidadPromesa,
								No_OP
							)
							SELECT
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								@CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6),
								@DESCRIPCIONMATERIAL,
								1,
								@EXISTENCIA_LOTE,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@EXISTENCIA_LOTE,
								0 AS No_OP

							--ACTUALIZA STOCK Y CONSUMO
							SET @STOCK += @EXISTENCIA_LOTE
							SET @CANTIDAD_CONSUMO -= @EXISTENCIA_LOTE
						END
						ELSE
						BEGIN
							--COMO LA EXISTENCIA ES MAYOR A LO REQUERIDO, SE RESERVA LA CANTIDAD REQUERIDA
							UPDATE
								HABILITACION
							SET 
								Existencia = Existencia-@CANTIDAD_CONSUMO,
								Reservado = Reservado+@CANTIDAD_CONSUMO
							WHERE
								Cve_Grupo = @CVE_GRUPO
							AND Cve_Habilitacion = @CVE_HABILITACION

							--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
							SELECT
								@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
							FROM
								RESERVADO_MATERIAL
							WHERE
								EMPRESA = @EMPRESA
					
							SET @CONSECUTIVO += 1

							--SE OBTIENE LA DESCRIPCIÓN DEL MATERIAL DE LA OC
							SELECT @DESCRIPCIONMATERIALOC = DescripcionMaterial FROM ORDEN_COMPRA WHERE Empresa = @EMPRESA AND No_OrdenCompra = @ORIGEN_NO AND TipoMaterial = @TIPOMATERIAL AND Cve_Material = @CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6)

							--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
							INSERT INTO RESERVADO_MATERIAL
							(
								Empresa,
								No_Reservado,
								No_Pedido,
								TipoMaterial,
								Cve_Material,
								Cve_Grupo,
								Cve_Habilitacion,
								DescripcionMaterial,
								TipoReservado,
								Origen_No,
								No_Documento,
								CantidadReservada,
								CantidadUsada,
								Estatus,
								FECHAHORA,
								No_OP
							)
							VALUES
							(
								@EMPRESA,
								@CONSECUTIVO,
								@NO_PEDIDO,
								@TIPOMATERIAL,
								@CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6),
								@CVE_GRUPO,
								@CVE_HABILITACION,
								@DESCRIPCIONMATERIALOC,
								@ORIGEN,
								@ORIGEN_NO,
								@NO_DOCUMENTO,
								@CANTIDAD_CONSUMO,
								0,
								'DISPONIBLE',
								GETDATE(),
								0
							)

							SELECT
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								@CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6),
								@DESCRIPCIONMATERIAL,
								1,
								@CANTIDAD_CONSUMO,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@CANTIDAD_CONSUMO

							INSERT INTO ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO
							(
								Empresa,
								No_Pedido,
								No_OrdenCompra,
								Partida,
								TipoMaterial,
								Cve_Material,
								Descripcion_Material,
								Factor,
								Cantidad,
								No_Parcialidad,
								FechaPromesa,
								CantidadPromesa,
								No_OP
							)
							SELECT
								@EMPRESA,
								@NO_PEDIDO,
								@ORIGEN_NO,
								@PARTIDA_OC,
								@TIPOMATERIAL,
								@CVE_GRUPO + RIGHT(REPLICATE('0', 6) + CAST(@CVE_HABILITACION AS VARCHAR), 6),
								@DESCRIPCIONMATERIAL,
								1,
								@CANTIDAD_CONSUMO,
								@NO_DOCUMENTO,
								CONVERT(DATE,GETDATE()),
								@CANTIDAD_CONSUMO,
								0 AS No_OP

							--ACTUALIZA STOCK Y CONSUMO
							SET @STOCK += @CANTIDAD_CONSUMO
							SET @CANTIDAD_CONSUMO = 0
						END
					END
					SET @CONTADOR-=1
				END
			END

			----CONTINUA VERIFICANDO QUE HAYA MATERIAL AHORA EN OC SI ES QUE TODAVIA HAY CONSUMO PENDIENTE
			--IF @CANTIDAD_CONSUMO > 0
			--BEGIN
			--	--SE CREA CURSOR CON LAS OC QUE HAYA DISPONIBLE MATERIAL EN OC
			--	DECLARE LISTAOC CURSOR FOR
			--	SELECT
			--		OC.No_OrdenCompra,
			--		OC.PARTIDA,
			--		(SELECT MAX(No_Parcialidad) FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA OCFPE WHERE OCFPE.Empresa = @EMPRESA AND OCFPE.No_OrdenCompra = OC.No_OrdenCompra AND OCFPE.Partida = OC.Partida),
			--		CantidadDisponible
			--	FROM 
			--		ORDEN_COMPRA OC
			--	WHERE
			--		Empresa = @EMPRESA
			--	AND TipoMaterial = @TIPOMATERIAL
			--	AND SUBSTRING(Cve_Material,1,3) = @CVE_GRUPO
			--	AND SUBSTRING(Cve_Material,4,6) = @CVE_HABILITACION
			--	AND Status = 'AUTORIZADA'
			--	AND Recibido = 0
			--	AND CantidadDisponible > 0
			--	OPEN LISTAOC
			--	FETCH NEXT FROM LISTAOC INTO @ORIGEN_NO,@PARTIDA_OC,@NO_DOCUMENTO,@EXISTENCIAMATERIAL
			--	WHILE @@FETCH_STATUS = 0
			--	BEGIN
			--		IF @CANTIDAD_CONSUMO > 0
			--		BEGIN
			--			IF @EXISTENCIAMATERIAL <= @CANTIDAD_CONSUMO
			--			BEGIN
			--				--COMO LA CANTIDAD DISPONIBLE DE LA OC ES MENOR A LO REQUERIDO SE TOMA COMPLETO
			--				--SE ACTUALIZA LA CANTIDADDISPONIBLE DE LA OC
			--				UPDATE
			--					ORDEN_COMPRA
			--				SET
			--					CantidadDisponible = CantidadDisponible-@EXISTENCIAMATERIAL
			--				WHERE
			--					Empresa = @EMPRESA
			--				AND No_OrdenCompra = @ORIGEN_NO
			--				AND Partida = @PARTIDA_OC
			--				AND TipoMaterial = @TIPOMATERIAL
			--				AND SUBSTRING(Cve_Material,1,3) = @CVE_GRUPO
			--				AND SUBSTRING(Cve_Material,4,6) = @CVE_HABILITACION
			--				AND Status = 'AUTORIZADA'
			--				AND Recibido = 0
							
			--				--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
			--				SELECT
			--					@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
			--				FROM
			--					RESERVADO_MATERIAL
			--				WHERE
			--					EMPRESA = @EMPRESA
					
			--				SET @CONSECUTIVO += 1

			--				--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
			--				INSERT INTO RESERVADO_MATERIAL
			--				(
			--					Empresa,
			--					No_Reservado,
			--					No_Pedido,
			--					TipoMaterial,
			--					Cve_Grupo,
			--					Cve_Habilitacion,
			--					DescripcionMaterial,
			--					TipoReservado,
			--					Origen_No,
			--					No_Documento,
			--					CantidadReservada,
			--					CantidadUsada,
			--					Estatus,
			--					FECHAHORA
			--				)
			--				VALUES
			--				(
			--					@EMPRESA,
			--					@CONSECUTIVO,
			--					@NO_PEDIDO,
			--					@TIPOMATERIAL,
			--					@CVE_GRUPO,
			--					@CVE_HABILITACION,
			--					@DESCRIPCIONMATERIAL,
			--					'OC',
			--					@ORIGEN_NO,
			--					@NO_DOCUMENTO,
			--					@EXISTENCIAMATERIAL,
			--					0,
			--					'DISPONIBLE',
			--					GETDATE()
			--				)

			--				--ACTUALIZA STOCK Y CONSUMO
			--				SET @STOCK += @EXISTENCIAMATERIAL
			--				SET @CANTIDAD_CONSUMO -= @EXISTENCIAMATERIAL
			--			END
			--			ELSE
			--			BEGIN
			--				--COMO LA CANTIDAD DISPONIBLE DE LA OC ES MAYOR A LO REQUERIDO SE RESERVA LO REQUERIDO
			--				--SE ACTUALIZA LA CANTIDADDISPONIBLE DE LA OC
			--				UPDATE
			--					ORDEN_COMPRA
			--				SET
			--					CantidadDisponible = CantidadDisponible-@CANTIDAD_CONSUMO
			--				WHERE
			--					Empresa = @EMPRESA
			--				AND No_OrdenCompra = @ORIGEN_NO
			--				AND Partida = @PARTIDA_OC
			--				AND TipoMaterial = @TIPOMATERIAL
			--				AND SUBSTRING(Cve_Material,1,3) = @CVE_GRUPO
			--				AND SUBSTRING(Cve_Material,4,6) = @CVE_HABILITACION
			--				AND Status = 'AUTORIZADA'
			--				AND Recibido = 0
							
			--				--OBTIENE EL SIGUIENTE CONSECUTIVO DE LA TABLA RESERVADO
			--				SELECT
			--					@CONSECUTIVO = ISNULL(MAX(No_Reservado),0)
			--				FROM
			--					RESERVADO_MATERIAL
			--				WHERE
			--					EMPRESA = @EMPRESA
					
			--				SET @CONSECUTIVO += 1

			--				--INSERTA EL REGISTRO DEL MATERIAL RESERVADO
			--				INSERT INTO RESERVADO_MATERIAL
			--				(
			--					Empresa,
			--					No_Reservado,
			--					No_Pedido,
			--					TipoMaterial,
			--					Cve_Grupo,
			--					Cve_Habilitacion,
			--					DescripcionMaterial,
			--					TipoReservado,
			--					Origen_No,
			--					No_Documento,
			--					CantidadReservada,
			--					CantidadUsada,
			--					Estatus,
			--					FECHAHORA
			--				)
			--				VALUES
			--				(
			--					@EMPRESA,
			--					@CONSECUTIVO,
			--					@NO_PEDIDO,
			--					@TIPOMATERIAL,
			--					@CVE_GRUPO,
			--					@CVE_HABILITACION,
			--					@DESCRIPCIONMATERIAL,
			--					'OC',
			--					@ORIGEN_NO,
			--					@NO_DOCUMENTO,
			--					@CANTIDAD_CONSUMO,
			--					0,
			--					'DISPONIBLE',
			--					GETDATE()
			--				)

			--				--ACTUALIZA STOCK Y CONSUMO
			--				SET @STOCK += @CANTIDAD_CONSUMO
			--				SET @CANTIDAD_CONSUMO = 0
			--			END
			--		END
			--		FETCH NEXT FROM LISTAOC INTO @ORIGEN_NO,@PARTIDA_OC,@NO_DOCUMENTO,@EXISTENCIAMATERIAL
			--	END
			--	CLOSE LISTAOC
			--	DEALLOCATE LISTAOC
			--END

			--ACTUALIZA TABLA DE EXPLOSION DE MATERIALES FINAL CON LAS CANTIDAD ACTUALIZADAS DE STOCK Y CONSUMO
			UPDATE
				#EXPLOSION_MATERIALESFINAL
			SET
				Stock = @STOCK,
				Cantidad = @CANTIDAD_CONSUMO
			WHERE
				Empresa = @EMPRESA
			AND No_Pedido = @NO_PEDIDO
			AND TipoMaterial = @TIPOMATERIAL
			AND Cve_Grupo = @CVE_GRUPO
			AND Cve_Habilitacion = @CVE_HABILITACION

		END ---TERMINA CODIGO PARA HABILITACIONES

		FETCH NEXT FROM LISTAMATERIALES INTO @EMPRESA,@NO_PEDIDO,@TIPOMATERIAL,@CVE_TELA,@CVE_GRUPO,@CVE_HABILITACION,@DESCRIPCIONMATERIAL,@CANTIDAD_CONSUMO
	END
	CLOSE LISTAMATERIALES
	DEALLOCATE LISTAMATERIALES

	
	INSERT INTO SUGERIDO_COMPRA
	(
		Empresa,
		Consecutivo,
		No_Pedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Stock,
		Cantidad,
		CantidadComprada,
		Unidad,
		No_OP,
		Status,
		FECHAHORA
	)
	SELECT
		Empresa,
		ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Consecutivo,
		No_Pedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		Stock,
		Cantidad,
		0,
		Unidad,
		0 AS NO_OP,
		'PENDIENTE',
		GETDATE()
	FROM 
		#EXPLOSION_MATERIALESFINAL
	WHERE
		Stock > 0
		OR Cantidad > 0;


	--ACTUALIZA A INVENTARIO EL SUGERIDO DE COMPRA QUE HAYA ALCANZADO CON EL INVENTARIO,
	--ES DECIR LO QUE TENGA 0 PARA COMPRAR
	UPDATE
		SUGERIDO_COMPRA 
	SET
		Status = 'INVENTARIO'
	WHERE
		Empresa = @EMPRESA
	AND No_Pedido = @NO_PEDIDO
	AND Cantidad = 0

	DECLARE @CantidadPendientes AS BIGINT

	SELECT @CantidadPendientes = ISNULL(COUNT(*),0) FROM SUGERIDO_COMPRA WHERE Empresa = @EMPRESA AND No_Pedido = @NO_PEDIDO AND Status = 'PENDIENTE'

	IF @CantidadPendientes = 0
	BEGIN
		UPDATE
			PEDIDO_INTERNO 
		SET
			ListoCalculoOP = 1
		WHERE
			Empresa = @EMPRESA 
		AND No_Pedido = @NO_PEDIDO
	END


	SELECT * FROM #EXPLOSION_MATERIALESFINAL WHERE Stock > 0 OR Cantidad > 0

	DROP TABLE #EXPLOSION_MATERIALESFINAL
	DROP TABLE #LOTES
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

--EXEC SP_EXPLOSION_MATERIALES_SUGERIDO_COMPRA 1,1422
--SELECT * FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO WHERE No_Pedido = 1583

--select * from HABILITACION where Cve_Grupo = 'crf' and Cve_Habilitacion = 106
--select * from HABILITACION_KARDEX where Cve_Grupo = 'crf' and Cve_Habilitacion = 106 and TipoMovimiento = 'e' order by NoMovimiento desc
GO

