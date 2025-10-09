USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[CONSULTA_CONTROL_TELAS_HABILITACIONES]    Script Date: 09/10/2025 11:28:46 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CONSULTA_CONTROL_TELAS_HABILITACIONES]
--DECLARE
	@EMPRESA BIGINT,
	@NO_PEDIDOINICIAL BIGINT,
	@NO_PEDIDOFINAL BIGINT,
	@NO_OPINICIAL BIGINT,
	@NO_OPFINAL BIGINT,
	@ORDENADO BIGINT,---1.-PEDIDO, SE ORDENA POR MATERIAL,2.-OP SE ORDENAN LOS MATERIALES POR OP
	@ADICIONAL BIGINT --1.-OP Pendiente de Enviar,2.-OP En Transito
AS
BEGIN
--EN ESTE CÓDIGO SE VA A IR POR MODULOS, 
--1. SE SACA EL TOTAL DE CONSUMO DE MATERIALES POR PEDIDO
--2. SE CONSULTA EL SUGERIDO Y ORDENES DE COMPRA
--3. SE CONSULTAN LAS OP ASIGNADAS Y LA CANTIDAD DE MATERIAL POR OP
--4. SE CONSULTA LO REMISIONADO
	--SET @EMPRESA = 1
	--SET @NO_PEDIDOINICIAL = 0
	--SET @NO_PEDIDOFINAL = 0
	--SET @NO_OPINICIAL = 3087
	--SET @NO_OPFINAL = 3087
	--SET @ADICIONAL = 0

	IF @NO_PEDIDOINICIAL = 0
		SET @NO_PEDIDOINICIAL = 1

	IF @NO_PEDIDOFINAL = 0
		SET @NO_PEDIDOFINAL = 99999


	CREATE TABLE #EXPLOSION_MATERIALES
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		LugarDeEntrega bigint,
		Prioridad int,
		Cve_Cliente bigint,
		RazonSocial nvarchar(255),
		Cve_Prenda bigint,
		DescripcionPrenda nvarchar(1000),
		CantidadPrendasPedido bigint,
		FechaVencimientoPedido datetime,
		TipoMaterial nvarchar(1),
		Cve_Material nvarchar(20),
		Cve_Tela numeric(18,0),
		Cve_Grupo nvarchar(3),
		Cve_Habilitacion numeric(18,0),
		DescripcionMaterial nvarchar(255),
		ConsumoMaterialPedido numeric(18,2),
		ConsumoMaterialPrenda numeric(18,2),
		Unidad nvarchar(50)
	)

	DECLARE @SQL AS NVARCHAR(MAX)
	SET @SQL = 'SELECT
		PIT.Empresa,
		PIT.No_Pedido,
		PIT.LugarDeEntrega,
		PIT.Prioridad,
		PI.Cve_Cliente,
		PI.Nom_Cliente,
		PIT.Cve_Prenda,
		PIT.DescripcionPrenda,
		SUM(PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0)) AS CantidadPrendasPedido,
		PIT.FechaVencimiento,
		PEMD.TipoMaterial,
		CASE WHEN PEMD.TipoMaterial = ' + '''T''' + ' THEN CONVERT(NVARCHAR(15),PEMD.Cve_Tela) ELSE PEMD.Cve_Grupo + RIGHT(' + '''000000''' + '+ CAST(PEMD.Cve_Habilitacion AS VARCHAR),6) END,
		CASE WHEN PEMD.TipoMaterial = ' + '''T''' + ' THEN PEMD.Cve_Tela ELSE NULL END,
		CASE WHEN PEMD.TipoMaterial = ' + '''H''' + ' THEN PEMD.Cve_Grupo ELSE NULL END,
		CASE WHEN PEMD.TipoMaterial = ' + '''H''' + ' THEN PEMD.Cve_Habilitacion ELSE NULL END,
		PEMD.Descripcion,
		CASE WHEN TipoMaterial = ' + '''T''' + ' THEN SUM(CONVERT(NUMERIC(18,2),((PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0))*PEMD.Consumo))/CT.ANCHO) ELSE SUM(CONVERT(NUMERIC(18,2),(PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0))*PEMD.Consumo)) END,
		CASE WHEN TipoMaterial = ' + '''T''' + ' THEN SUM(CONVERT(NUMERIC(18,2),((PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0))*PEMD.Consumo))/CT.ANCHO) ELSE SUM(CONVERT(NUMERIC(18,2),(PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0))*PEMD.Consumo)) END,
		CASE WHEN TipoMaterial = ' + '''T''' + ' THEN ' + '''METROS''' + ' ELSE HG.Unidad END
	FROM
		FOLIOS_ADMINISTRACION FA,
		PEDIDO_INTERNO PI,
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
		AND RIPT.Talla = PIT.Talla
		LEFT JOIN
			OP_ASIGNACION OPA
		ON
			OPA.Empresa = PIT.Empresa
		AND OPA.No_OP = PIT.No_OP,
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
		PIT.Empresa = ' + CONVERT(NVARCHAR,@EMPRESA) + '
	AND PIT.No_Pedido >= ' + CONVERT(NVARCHAR,@NO_PEDIDOINICIAL) + '
	AND PIT.No_Pedido <= ' + CONVERT(NVARCHAR,@NO_PEDIDOFINAL)
	
	IF @NO_OPINICIAL > 0
	BEGIN
		SET @SQL = @SQL + '
	AND PIT.NO_OP >= ' + CONVERT(NVARCHAR,@NO_OPINICIAL) + '
	AND PIT.NO_OP <= ' + CONVERT(NVARCHAR,@NO_OPFINAL) 
	END

	SET @SQL = @SQL + '
	AND	PEMD.Cve_Prenda = PIT.Cve_Prenda
	AND PEM.Cve_Prenda = PEMD.Cve_Prenda
	AND PEM.Partida = PEMD.Partida
	AND PIT.Talla = PEM.Talla
	AND PI.Empresa = PIT.Empresa
	AND PI.No_Pedido = PIT.No_Pedido
	AND FA.Empresa = PI.Empresa
	AND FA.Num_Folio = PI.Num_Folio
	AND FA.TipoPedido <> ' + '''C''' + '
	AND PI.Status = ' + '''AUTORIZADO''' + '
	GROUP BY
		PIT.Empresa,
		PIT.No_Pedido,
		PIT.LugarDeEntrega,
		PIT.Prioridad,
		PI.Cve_Cliente,
		PI.Nom_Cliente,
		PIT.Cve_Prenda,
		PIT.DescripcionPrenda,
		PIT.FechaVencimiento,
		PEMD.TipoMaterial,
		PEMD.Cve_Tela,
		PEMD.Cve_Grupo,
		PEMD.Cve_Habilitacion,
		PEMD.Descripcion,
		HG.Unidad'
	
	INSERT INTO #EXPLOSION_MATERIALES
	(
		Empresa,
		No_Pedido,
		LugarDeEntrega,
		Prioridad,
		Cve_Cliente,
		RazonSocial,
		Cve_Prenda,
		DescripcionPrenda,
		CantidadPrendasPedido,
		FechaVencimientoPedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		ConsumoMaterialPedido,
		ConsumoMaterialPrenda,
		Unidad
	)
	EXEC sp_executesql @sql;

	DELETE #EXPLOSION_MATERIALES WHERE ConsumoMaterialPedido = 0

	--PASO 2
	CREATE TABLE #EXPLOSION_MATERIALES_SC_OC
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		FechaVencimientoPedido datetime,
		Cve_Cliente bigint,
		RazonSocial nvarchar(255),
		Cve_Prenda bigint,
		DescripcionPrenda nvarchar(1000),
		CantidadPrendasPedido bigint,
		ConsumoMaterialPrenda numeric(18,2),
		TipoMaterial nvarchar(1),
		Cve_Tela numeric(18,0),
		Cve_Material nvarchar(20),
		Cve_Grupo nvarchar(3),
		Cve_Habilitacion numeric(18,0),
		DescripcionMaterial nvarchar(255),
		ConsumoMaterialPedido numeric(18,2),
		Unidad nvarchar(50),
		No_OrdenCompra bigint,
		CantidadOC numeric(18,2),
		PendienteDeOC numeric(18,2),
		CantidadRecibidaOC numeric(18,2)
	)

	INSERT INTO #EXPLOSION_MATERIALES_SC_OC
	(
		Empresa,
		No_Pedido,
		FechaVencimientoPedido,
		Cve_Cliente,
		RazonSocial,
		Cve_Prenda,
		DescripcionPrenda,
		CantidadPrendasPedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		ConsumoMaterialPedido,
		ConsumoMaterialPrenda,
		Unidad,
		No_OrdenCompra,
		CantidadOC,
		CantidadRecibidaOC
	)
	SELECT
		EM.Empresa,
		EM.No_Pedido,
		EM.FechaVencimientoPedido,
		EM.Cve_Cliente,
		EM.RazonSocial,
		EM.Cve_Prenda,
		EM.DescripcionPrenda,
		EM.CantidadPrendasPedido,
		EM.TipoMaterial,
		EM.Cve_Material,
		EM.Cve_Tela,
		EM.Cve_Grupo,
		EM.Cve_Habilitacion,
		EM.DescripcionMaterial,
		(SELECT SUM(EM1.ConsumoMaterialPedido) FROM #EXPLOSION_MATERIALES EM1 WHERE EM1.Empresa = EM.Empresa AND EM1.No_Pedido = EM.No_Pedido AND EM1.TipoMaterial = EM.TipoMaterial AND EM1.Cve_Material = EM.Cve_Material),
		EM.ConsumoMaterialPrenda,
		EM.Unidad,
		OCFPES.No_OrdenCompra,
		OCFPES.Cantidad,
		(SELECT ISNULL(SUM(ISNULL(OC.Factor*OCFPR.CantidadRecibida,0)),0) FROM ORDEN_COMPRA OC,ORDEN_COMPRA_FECHA_PROMESA_RECIBO OCFPR WHERE OCFPR.Empresa = EM.Empresa AND OC.No_OrdenCompra = OCFPES.No_OrdenCompra AND OC.TipoMaterial = EM.TipoMaterial AND OC.Cve_Material = EM.Cve_Material AND OCFPR.No_OrdenCompra = OC.No_OrdenCompra AND OCFPR.Partida = OC.Partida)
	FROM 
		#EXPLOSION_MATERIALES EM,
		ORDEN_COMPRA_ASIGNACION_ITERACIONES OCAI
		LEFT JOIN
			SUGERIDO_COMPRA SC
		ON
			SC.Empresa = OCAI.Empresa
		AND SC.No_Pedido = OCAI.No_Pedido
		AND SC.No_OrdenCompra = OCAI.No_OrdenCompra
		AND SC.TipoMaterial = OCAI.TipoMaterial
		AND SC.Cve_Material = OCAI.Cve_Material
		LEFT JOIN
			ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO OCFPES
		ON
			OCFPES.Empresa = OCAI.Empresa
		AND OCFPES.No_Pedido = OCAI.No_Pedido
		AND OCFPES.No_OrdenCompra = OCAI.No_OrdenCompra
		AND OCFPES.TipoMaterial = OCAI.TipoMaterial
		AND OCFPES.Cve_Material = OCAI.Cve_Material
	WHERE
		OCAI.Empresa = EM.Empresa
	AND OCAI.No_Pedido = EM.No_Pedido
	AND OCAI.Prioridad = EM.Prioridad
	AND OCAI.LugarEntrega = EM.LugarDeEntrega
	AND OCAI.Cve_Prenda = EM.Cve_Prenda
	AND OCAI.TipoMaterial = EM.TipoMaterial
	AND OCAI.Cve_Material = EM.Cve_Material
	GROUP BY
		EM.Empresa,
		EM.No_Pedido,
		EM.FechaVencimientoPedido,
		EM.Cve_Cliente,
		EM.RazonSocial,
		EM.Cve_Prenda,
		EM.DescripcionPrenda,
		EM.CantidadPrendasPedido,
		EM.TipoMaterial,
		EM.Cve_Material,
		EM.Cve_Tela,
		EM.Cve_Grupo,
		EM.Cve_Habilitacion,
		EM.DescripcionMaterial,
		EM.ConsumoMaterialPrenda,
		EM.Unidad,
		OCFPES.No_OrdenCompra,
		OCFPES.Cantidad
	ORDER BY
		EM.No_Pedido

	UPDATE 
		#EXPLOSION_MATERIALES_SC_OC
	SET 
		PendienteDeOC = ConsumoMaterialPedido - 
		(
		SELECT 
			SUM(DistinctCantidadOC) 
		FROM 
			(
			SELECT 
				EMSC_OC.No_OrdenCompra, 
				EMSC_OC.CantidadOC AS DistinctCantidadOC
			FROM 
				#EXPLOSION_MATERIALES_SC_OC AS EMSC_OC
			WHERE 
				EMSC_OC.Empresa = #EXPLOSION_MATERIALES_SC_OC.Empresa
			AND EMSC_OC.No_Pedido = #EXPLOSION_MATERIALES_SC_OC.No_Pedido
			AND EMSC_OC.Cve_Material = #EXPLOSION_MATERIALES_SC_OC.Cve_Material
			AND EMSC_OC.TipoMaterial = #EXPLOSION_MATERIALES_SC_OC.TipoMaterial
			GROUP BY 
				EMSC_OC.No_OrdenCompra,
				EMSC_OC.CantidadOC
			) AS Agrupado
		)


	UPDATE
		#EXPLOSION_MATERIALES_SC_OC
	SET
		PendienteDeOC = 0
	WHERE
		PendienteDeOC < 0

	--PASO 3
	CREATE TABLE #ORDENES_PRODUCCION
	(
		Empresa bigint,
		No_Pedido bigint,
		Cve_Prenda bigint,
		DescripcionPrenda nvarchar(1000),
		No_OP bigint,
		CantidadPrendasOP numeric(18,0),
		Cve_Maquilador bigint,
		Nom_Maquilador nvarchar(255),
		FechaProgramaDeFinalizacionOP datetime,
		TipoMaterialOP nvarchar(1),
		Cve_MaterialOP nvarchar(20),
		DescripcionMaterialOP nvarchar(255),
		ConsumoMaterialOP numeric(18,2)
	)
	
	INSERT INTO #ORDENES_PRODUCCION
	(
		Empresa,
		No_Pedido,
		Cve_Prenda,
		DescripcionPrenda,
		No_OP,
		CantidadPrendasOP,
		Cve_Maquilador,
		Nom_Maquilador,
		FechaProgramaDeFinalizacionOP,
		TipoMaterialOP,
		Cve_MaterialOP,
		DescripcionMaterialOP,
		ConsumoMaterialOP
	)
	SELECT 
		PIT.Empresa,
		PIT.No_Pedido,
		PIT.Cve_Prenda,
		PIT.DescripcionPrenda,
		PIT.No_OP,
		SUM(PIT.Cantidad-ISNULL(RIPT.Cantidad,0)) AS CantidadPrendasOP,
		OPA.Cve_Maquilador,
		OPA.Nom_Maquilador,
		OPA.FechaFinalizacion,
		OPEM.TipoMaterial,
		OPEM.Cve_Material,
		OPEM.DescripcionMaterial,
		OPEM.Cantidad+(SELECT ISNULL(SUM(Cantidad),0) FROM OP_EXPLOSION_MATERIALES_INSPECTOR OPEMI WHERE OPEMI.Empresa = PIT.Empresa AND OPEMI.TipoMovimiento = 'FALTANTE' AND OPEMI.No_OP = PIT.No_OP AND OPEMI.TipoMaterial = OPEM.TipoMaterial AND OPEMI.Cve_Material = OPEM.Cve_Material)
	FROM 
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
		OP_EXPLOSION_MATERIALES OPEM,
		OP_ASIGNACION OPA
	WHERE
		PIT.Empresa = @EMPRESA
	AND PIT.No_Pedido IN (SELECT EM.No_Pedido FROM #EXPLOSION_MATERIALES EM GROUP BY EM.No_Pedido)
	AND	OPEM.Empresa = PIT.Empresa
	AND OPEM.No_Pedido = PIT.No_Pedido
	AND OPEM.No_OP = PIT.No_OP
	AND OPEM.Cve_Prenda = PIT.Cve_Prenda
	AND	OPA.Empresa = PIT.Empresa
	AND OPA.No_OP = PIT.No_OP
	AND OPA.Cancelada = 0
	AND OPA.Estatus NOT IN ('CANCELADA')
	GROUP BY
		PIT.Empresa,
		PIT.No_Pedido,
		PIT.Cve_Prenda,
		PIT.DescripcionPrenda,
		PIT.No_OP,
		OPA.Cve_Maquilador,
		OPA.Nom_Maquilador,
		OPA.FechaFinalizacion,
		OPEM.TipoMaterial,
		OPEM.Cve_Material,
		OPEM.DescripcionMaterial,
		OPEM.Cantidad
	ORDER BY
		PIT.No_Pedido

	CREATE TABLE #EXPLOSION_MATERIALES_OP
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		CantidadPrendasPedido bigint,
		Cve_Cliente bigint,
		RazonSocial nvarchar(255),
		FechaVencimientoPedido datetime,
		TipoMaterial nvarchar(1),
		Cve_Material nvarchar(20),
		Cve_Tela numeric(18,0),
		Cve_Grupo nvarchar(3),
		Cve_Habilitacion numeric(18,0),
		DescripcionMaterial nvarchar(255),
		ConsumoMaterialPedido numeric(18,2),
		Unidad nvarchar(50),
		No_OrdenCompra bigint,
		CantidadOC numeric(18,2),
		PendienteDeOC numeric(18,2),
		CantidaRecibidaOC numeric(18,2),
		Cve_Prenda bigint,
		DescripcionPrenda nvarchar(1000),
		CantidadPrendasPendientesAsignarOP bigint,
		ConsumoMaterialPrenda numeric(18,2),
		No_OP bigint,
		Cve_Maquilador bigint,
		Nom_Maquilador nvarchar(255),
		CantidadPrendasOP numeric(18,0),
		FechaProgramaDeFinalizacionOP datetime,
		TipoMaterialOP nvarchar(1),
		Cve_MaterialOP nvarchar(20),
		DescripcionMaterialOP nvarchar(255),
		ConsumoMaterialOP numeric(18,2),
		MaterialPendienteAsignarOP numeric(18,2)
	)

	SET @SQL = 'SELECT 
		EM.Empresa,
		EM.No_Pedido,
		EM.CantidadPrendasPedido,
		EM.Cve_Cliente,
		EM.RazonSocial,
		EM.FechaVencimientoPedido,
		EM.TipoMaterial,
		EM.Cve_Material,
		EM.Cve_Tela,
		EM.Cve_Grupo,
		EM.Cve_Habilitacion,
		EM.DescripcionMaterial,
		EM.ConsumoMaterialPedido,
		EM.Unidad,
		EM.No_OrdenCompra,
		EM.CantidadOC,
		EM.PendienteDeOC,
		EM.CantidadRecibidaOC,
		EM.Cve_Prenda,
		EM.DescripcionPrenda,
		EM.ConsumoMaterialPrenda,
		OP.No_OP,
		OP.Cve_Maquilador,
		OP.Nom_Maquilador,
		OP.CantidadPrendasOP,
		OP.FechaProgramaDeFinalizacionOP,
		OP.TipoMaterialOP,
		OP.Cve_MaterialOP,
		OP.DescripcionMaterialOP,
		OP.ConsumoMaterialOP
	FROM 
		#EXPLOSION_MATERIALES_SC_OC EM
		LEFT JOIN
			#ORDENES_PRODUCCION OP
		ON
			OP.Empresa = EM.Empresa
		AND OP.No_Pedido = EM.No_Pedido
		AND OP.Cve_Prenda = EM.Cve_Prenda
		AND OP.TipoMaterialOP = EM.TipoMaterial
		AND OP.Cve_MaterialOP = EM.Cve_Material'

	IF @NO_OPINICIAL > 0
	BEGIN
		SET @SQL = @SQL + '
		AND OP.NO_OP >= ' + CONVERT(nvarchar,@NO_OPINICIAL) + '
		AND OP.NO_OP <= ' + CONVERT(nvarchar,@NO_OPFINAL) 
	END

	SET @SQL = @SQL + '
	ORDER BY
		EM.No_Pedido'
	
	INSERT INTO #EXPLOSION_MATERIALES_OP
	(
		Empresa,
		No_Pedido,
		CantidadPrendasPedido,
		Cve_Cliente,
		RazonSocial,
		FechaVencimientoPedido,
		TipoMaterial,
		Cve_Material,
		Cve_Tela,
		Cve_Grupo,
		Cve_Habilitacion,
		DescripcionMaterial,
		ConsumoMaterialPedido,
		Unidad,
		No_OrdenCompra,
		CantidadOC,
		PendienteDeOC,
		CantidaRecibidaOC,
		Cve_Prenda,
		DescripcionPrenda,
		ConsumoMaterialPrenda,
		No_OP,
		Cve_Maquilador,
		Nom_Maquilador,
		CantidadPrendasOP,
		FechaProgramaDeFinalizacionOP,
		TipoMaterialOP,
		Cve_MaterialOP,
		DescripcionMaterialOP,
		ConsumoMaterialOP
	)
	EXEC sp_executesql @sql;

	UPDATE
		#EXPLOSION_MATERIALES_OP
	SET
		CantidadPrendasPendientesAsignarOP = CantidadPrendasPedido-ISNULL(CantidadPrendasOP,0),
		MaterialPendienteAsignarOP = ConsumoMaterialPedido-
		(
			SELECT 
				ISNULL(SUM(ISNULL(EMOP1.ConsumoMaterialOP,0)),0)
			FROM
				#EXPLOSION_MATERIALES_OP EMOP1
			WHERE
				EMOP1.Empresa = #EXPLOSION_MATERIALES_OP.Empresa
			AND EMOP1.No_Pedido = #EXPLOSION_MATERIALES_OP.No_Pedido
			AND EMOP1.TipoMaterial = #EXPLOSION_MATERIALES_OP.TipoMaterial
			AND EMOP1.Cve_Material = #EXPLOSION_MATERIALES_OP.Cve_Material
		)

	--PASO 4
	CREATE TABLE #EXPLOSION_MATERIALES_OP_REMISIONES
	(
		Empresa numeric(18,0),
		No_Pedido numeric(18,0),
		Cve_Cliente bigint,
		RazonSocial nvarchar(255),
		FechaVencimientoPedido datetime,
		TipoMaterial nvarchar(1),
		Cve_Material nvarchar(20),
		DescripcionMaterial nvarchar(255),
		ConsumoMaterialPedido numeric(18,2),
		Unidad nvarchar(50),
		MaterialPendienteAsignarOP numeric(18,2),
		No_OrdenCompra bigint,
		CantidadOC numeric(18,2),
		PendienteDeOC numeric(18,2),
		CantidaRecibidaOC numeric(18,2),
		Cve_Prenda bigint,
		DescripcionPrenda nvarchar(1000),
		CantidadPrendasPedido bigint,
		ConsumoMaterialPrenda numeric(18,2),
		CantidadPrendasPendientesAsignarOP bigint,
		No_OP bigint,
		Cve_Maquilador bigint,
		Nom_Maquilador nvarchar(255),
		FechaProgramaDeFinalizacionOP datetime,
		CantidadPrendasOP numeric(18,0),
		ConsumoMaterialOP numeric(18,2),
		No_Remision bigint,
		CantidadRemisionada numeric(18,2),
		TotalEnviado numeric(18,2),
		PendienteEnviar numeric(18,2),
		FechaEnvio date,
		QuienSeLoLlevo nvarchar(255),
		ObservacionesAdicionales nvarchar(max),
		FechaFirmaAcuse date,
		QuienFirmaAcuse nvarchar(255),
		Acuse nvarchar(2),
		RutaAcuse nvarchar(255),
		SePuedeModificarFechaEnvio bit,
		SePuedeModificarAcuse bit,
		ColumnaControl nvarchar(2)
	)
	INSERT INTO #EXPLOSION_MATERIALES_OP_REMISIONES
	(
		Empresa,
		No_Pedido,
		Cve_Cliente,
		RazonSocial,
		FechaVencimientoPedido,
		TipoMaterial,
		Cve_Material,
		DescripcionMaterial,
		ConsumoMaterialPedido,
		Unidad,
		MaterialPendienteAsignarOP,
		No_OrdenCompra,
		CantidadOC,
		PendienteDeOC,
		CantidaRecibidaOC,
		Cve_Prenda,
		DescripcionPrenda,
		CantidadPrendasPedido,
		ConsumoMaterialPrenda,
		CantidadPrendasPendientesAsignarOP,
		No_OP,
		Cve_Maquilador,
		Nom_Maquilador,
		FechaProgramaDeFinalizacionOP,
		CantidadPrendasOP,
		ConsumoMaterialOP,
		No_Remision,
		CantidadRemisionada,
		FechaEnvio,
		QuienSeLoLlevo,
		ObservacionesAdicionales,
		FechaFirmaAcuse,
		QuienFirmaAcuse,
		RutaAcuse,
		SePuedeModificarFechaEnvio,
		SePuedeModificarAcuse
	)
	SELECT 
		EMOP.Empresa,
		EMOP.No_Pedido,
		EMOP.Cve_Cliente,
		EMOP.RazonSocial,
		EMOP.FechaVencimientoPedido,
		EMOP.TipoMaterial,
		EMOP.Cve_Material,
		EMOP.DescripcionMaterial,
		EMOP.ConsumoMaterialPedido,
		EMOP.Unidad,
		EMOP.MaterialPendienteAsignarOP,
		EMOP.No_OrdenCompra,
		EMOP.CantidadOC,
		EMOP.PendienteDeOC,
		EMOP.CantidaRecibidaOC,
		EMOP.Cve_Prenda,
		EMOP.DescripcionPrenda,
		EMOP.CantidadPrendasPedido,
		EMOP.ConsumoMaterialPrenda,
		EMOP.CantidadPrendasPendientesAsignarOP,
		EMOP.No_OP,
		EMOP.Cve_Maquilador,
		EMOP.Nom_Maquilador,
		EMOP.FechaProgramaDeFinalizacionOP,
		EMOP.CantidadPrendasOP,
		EMOP.ConsumoMaterialOP,
		RM.No_Remision,
		RM.Cantidad AS CantidadRemisionada,
		RME.FechaQueSeMando,
		RME.QuienSeLoLLevo,
		RME.ObservacionesAdicionales,
		OPARM.FechaFirmaAcuse,
		OPARM.QuienFirmaAcuse,
		OPARM.RutaAcuse,
		0,
		CASE WHEN FechaFirmaAcuse IS NOT NULL AND QuienFirmaAcuse IS NOT NULL AND RutaAcuse IS NOT NULL THEN 0 ELSE 1 END
	FROM 
		#EXPLOSION_MATERIALES_OP EMOP
	LEFT JOIN
		REMISION_MATERIAL RM
	ON
		RM.Empresa = EMOP.Empresa
	AND RM.No_OP = EMOP.No_OP
	AND RM.TipoMaterial = EMOP.TipoMaterial
	AND RM.Cve_Material = EMOP.Cve_Material
	AND RM.No_OrdenCompra = EMOP.No_OrdenCompra
	AND RM.Estatus = 'AUTORIZADA'
	LEFT JOIN
		REMISION_MATERIAL_ENVIO RME
	ON
		RME.Empresa = RM.Empresa
	AND RME.No_Remision = RM.No_Remision
	LEFT JOIN
		OP_ACUSES_RECIBOMATERIAL OPARM
	ON
		OPARM.Empresa = RM.Empresa
	AND OPARM.No_RemisionSistema = RM.No_Remision
	AND OPARM.No_OP = RM.No_OP
	AND OPARM.TipoMaterial = RM.TipoMaterial
	AND OPARM.Cve_Material = RM.Cve_Material
	AND OPARM.No_OrdenCompra = RM.No_OrdenCompra
	ORDER BY
		EMOP.No_Pedido,
		CASE EMOP.TipoMaterial 
			WHEN 'T' THEN 1
			WHEN 'H' THEN 2
		END,
		EMOP.Cve_Material,
		EMOP.Cve_Prenda,
		EMOP.No_OrdenCompra,
		RM.No_Remision

	INSERT INTO #EXPLOSION_MATERIALES_OP_REMISIONES
	(
		Empresa,
		No_Pedido,
		Cve_Cliente,
		RazonSocial,
		FechaVencimientoPedido,
		TipoMaterial,
		Cve_Material,
		DescripcionMaterial,
		ConsumoMaterialPedido,
		Unidad,
		MaterialPendienteAsignarOP,
		No_OrdenCompra,
		CantidadOC,
		PendienteDeOC,
		CantidaRecibidaOC,
		Cve_Prenda,
		DescripcionPrenda,
		CantidadPrendasPedido,
		ConsumoMaterialPrenda,
		CantidadPrendasPendientesAsignarOP,
		No_OP,
		Cve_Maquilador,
		Nom_Maquilador,
		FechaProgramaDeFinalizacionOP,
		CantidadPrendasOP,
		ConsumoMaterialOP,
		No_Remision,
		CantidadRemisionada,
		FechaEnvio,
		QuienSeLoLlevo,
		ObservacionesAdicionales,
		FechaFirmaAcuse,
		QuienFirmaAcuse,
		RutaAcuse,
		SePuedeModificarFechaEnvio,
		SePuedeModificarAcuse
	)
	SELECT 
		EMOP.Empresa,
		EMOP.No_Pedido,
		EMOP.Cve_Cliente,
		EMOP.RazonSocial,
		EMOP.FechaVencimientoPedido,
		EMOP.TipoMaterial,
		EMOP.Cve_Material,
		EMOP.DescripcionMaterial,
		EMOP.ConsumoMaterialPedido,
		EMOP.Unidad,
		EMOP.MaterialPendienteAsignarOP,
		EMOP.No_OrdenCompra,
		EMOP.CantidadOC,
		EMOP.PendienteDeOC,
		EMOP.CantidaRecibidaOC,
		EMOP.Cve_Prenda,
		EMOP.DescripcionPrenda,
		EMOP.CantidadPrendasPedido,
		EMOP.ConsumoMaterialPrenda,
		EMOP.CantidadPrendasPendientesAsignarOP,
		EMOP.No_OP,
		EMOP.Cve_Maquilador,
		EMOP.Nom_Maquilador,
		EMOP.FechaProgramaDeFinalizacionOP,
		EMOP.CantidadPrendasOP,
		EMOP.ConsumoMaterialOP,
		RM.No_Remision,
		RM.Cantidad AS CantidadRemisionada,
		RME.FechaQueSeMando,
		RME.QuienSeLoLLevo,
		RME.ObservacionesAdicionales,
		OPARM.FechaFirmaAcuse,
		OPARM.QuienFirmaAcuse,
		OPARM.RutaAcuse,
		0,
		CASE WHEN FechaFirmaAcuse IS NOT NULL AND QuienFirmaAcuse IS NOT NULL AND RutaAcuse IS NOT NULL THEN 0 ELSE 1 END
	FROM 
		#EXPLOSION_MATERIALES_OP EMOP,
		REMISION_MATERIAL RM
	LEFT JOIN
		REMISION_MATERIAL_ENVIO RME
	ON
		RME.Empresa = RM.Empresa
	AND RME.No_Remision = RM.No_Remision
	LEFT JOIN
		OP_ACUSES_RECIBOMATERIAL OPARM
	ON
		OPARM.Empresa = RM.Empresa
	AND OPARM.No_RemisionSistema = RM.No_Remision
	AND OPARM.No_OP = RM.No_OP
	AND OPARM.TipoMaterial = RM.TipoMaterial
	AND OPARM.Cve_Material = RM.Cve_Material
	AND OPARM.No_OrdenCompra = RM.No_OrdenCompra
	WHERE
		RM.Empresa = EMOP.Empresa
	AND RM.No_OP = EMOP.No_OP
	AND RM.TipoMaterial = EMOP.TipoMaterial
	AND RM.Cve_Material = EMOP.Cve_Material
	AND RM.No_OrdenCompra = 0
	AND RM.Estatus = 'AUTORIZADA'
	ORDER BY
		EMOP.No_Pedido,
		CASE EMOP.TipoMaterial 
			WHEN 'T' THEN 1
			WHEN 'H' THEN 2
		END,
		EMOP.Cve_Material,
		EMOP.Cve_Prenda,
		EMOP.No_OrdenCompra,
		RM.No_Remision

	DROP TABLE #EXPLOSION_MATERIALES
	DROP TABLE #EXPLOSION_MATERIALES_SC_OC
	DROP TABLE #ORDENES_PRODUCCION
	DROP TABLE #EXPLOSION_MATERIALES_OP

	--ACTUALIZA EL TOTALEVIADO Y PENDIENTE DE ENVIAR DE HABILITACIONES
	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		TotalEnviado =
		(
			SELECT 
				ISNULL(SUM(ISNULL(EMOPR.CantidadRemisionada,0)),0)
			FROM
				#EXPLOSION_MATERIALES_OP_REMISIONES EMOPR
			WHERE
				EMOPR.Empresa = #EXPLOSION_MATERIALES_OP_REMISIONES.Empresa
			AND EMOPR.No_Pedido = #EXPLOSION_MATERIALES_OP_REMISIONES.No_Pedido
			AND EMOPR.TipoMaterial = #EXPLOSION_MATERIALES_OP_REMISIONES.TipoMaterial
			AND EMOPR.Cve_Material = #EXPLOSION_MATERIALES_OP_REMISIONES.Cve_Material
			AND EMOPR.Cve_Prenda = #EXPLOSION_MATERIALES_OP_REMISIONES.Cve_Prenda
			AND EMOPR.No_OP = #EXPLOSION_MATERIALES_OP_REMISIONES.No_OP
		),
		PendienteEnviar = ConsumoMaterialOP -
		(
			SELECT 
				ISNULL(SUM(ISNULL(EMOPR.CantidadRemisionada,0)),0)
			FROM
				#EXPLOSION_MATERIALES_OP_REMISIONES EMOPR
			WHERE
				EMOPR.Empresa = #EXPLOSION_MATERIALES_OP_REMISIONES.Empresa
			AND EMOPR.No_Pedido = #EXPLOSION_MATERIALES_OP_REMISIONES.No_Pedido
			AND EMOPR.TipoMaterial = #EXPLOSION_MATERIALES_OP_REMISIONES.TipoMaterial
			AND EMOPR.Cve_Material = #EXPLOSION_MATERIALES_OP_REMISIONES.Cve_Material
			AND EMOPR.Cve_Prenda = #EXPLOSION_MATERIALES_OP_REMISIONES.Cve_Prenda
			AND EMOPR.No_OP = #EXPLOSION_MATERIALES_OP_REMISIONES.No_OP
		)
	WHERE
		TipoMaterial = 'H'

	--ACTUALIZA EL TOTALEVIADO Y PENDIENTE DE ENVIAR DE TELAS
	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		TotalEnviado =
		(
			SELECT 
				ISNULL(SUM(OPAT.Cantidad),0) 
			FROM
				OP_ACUSES_TELA OPAT
			WHERE
				OPAT.Empresa = #EXPLOSION_MATERIALES_OP_REMISIONES.Empresa
			AND OPAT.No_OP = #EXPLOSION_MATERIALES_OP_REMISIONES.No_OP
			AND OPAT.TipoMaterial = #EXPLOSION_MATERIALES_OP_REMISIONES.TipoMaterial
			AND OPAT.Cve_Material = #EXPLOSION_MATERIALES_OP_REMISIONES.Cve_Material
		),
		PendienteEnviar = ConsumoMaterialOP -
		(
			SELECT 
				ISNULL(SUM(OPAT.Cantidad),0) 
			FROM
				OP_ACUSES_TELA OPAT
			WHERE
				OPAT.Empresa = #EXPLOSION_MATERIALES_OP_REMISIONES.Empresa
			AND OPAT.No_OP = #EXPLOSION_MATERIALES_OP_REMISIONES.No_OP
			AND OPAT.TipoMaterial = #EXPLOSION_MATERIALES_OP_REMISIONES.TipoMaterial
			AND OPAT.Cve_Material = #EXPLOSION_MATERIALES_OP_REMISIONES.Cve_Material
		)
	WHERE
		TipoMaterial = 'T'
	

	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		TotalEnviado = 0
	WHERE
		TipoMaterial = 'T'
	AND TotalEnviado IS NULL

	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		PendienteEnviar = 0
	WHERE
		TipoMaterial = 'T'
	AND PendienteEnviar IS NULL
	
	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		MaterialPendienteAsignarOP = 0
	WHERE
		MaterialPendienteAsignarOP IS NULL

	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		MaterialPendienteAsignarOP = 0
	WHERE
		MaterialPendienteAsignarOP < 0

	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		Acuse = 'Si'
	WHERE
		No_Remision IS NOT NULL
	AND RutaAcuse IS NOT NULL
	
	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		Acuse = 'No'
	WHERE
		No_Remision IS NOT NULL
	AND RutaAcuse IS NULL
	
	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		SePuedeModificarFechaEnvio = 1
	WHERE
		No_Remision IS NOT NULL
	AND (
			FechaEnvio IS NULL
		AND QuienSeLoLlevo IS NULL
	)

	UPDATE
		#EXPLOSION_MATERIALES_OP_REMISIONES
	SET
		SePuedeModificarAcuse = 1
	WHERE
		No_Remision IS NOT NULL
	AND (
			FechaFirmaAcuse IS NULL
		OR QuienFirmaAcuse IS NULL
		OR RutaAcuse IS NULL
	)

	IF @ADICIONAL = 1 --' SE SELECCIONO EL FILTRO PENDIENTES DE ENVIAR
	BEGIN
		SELECT 
			Empresa,
			No_Pedido,
			Cve_Cliente,
			RazonSocial,
			FechaVencimientoPedido,
			TipoMaterial,
			Cve_Material,
			DescripcionMaterial,
			ConsumoMaterialPedido,
			Unidad,
			No_OrdenCompra,
			CantidadOC,
			PendienteDeOC,
			CantidaRecibidaOC,
			Cve_Prenda,
			DescripcionPrenda,
			CantidadPrendasPedido,
			ConsumoMaterialPrenda,
			CantidadPrendasPendientesAsignarOP,
			No_OP,
			Cve_Maquilador,
			Nom_Maquilador,
			FechaProgramaDeFinalizacionOP,
			CantidadPrendasOP,
			ConsumoMaterialOP,
			TotalEnviado,
			PendienteEnviar,
			No_Remision,
			CantidadRemisionada,
			FechaEnvio,
			QuienSeLoLlevo,
			ObservacionesAdicionales,
			FechaFirmaAcuse,
			QuienFirmaAcuse,
			Acuse,
			RutaAcuse,
			ColumnaControl,
			SePuedeModificarFechaEnvio,
			SePuedeModificarAcuse
		FROM
			#EXPLOSION_MATERIALES_OP_REMISIONES
		WHERE
			PendienteEnviar > 0
		ORDER BY
			No_Pedido,
			CASE TipoMaterial 
				WHEN 'T' THEN 1
				WHEN 'H' THEN 2
			END,
			Cve_Material,
			Cve_Prenda,
			No_OrdenCompra,
			No_Remision
	END
	IF @ADICIONAL = 2 --SE SELECCIONO EL FILTRO OP EN TRANSITO
	BEGIN
		SELECT 
			Empresa,
			No_Pedido,
			Cve_Cliente,
			RazonSocial,
			FechaVencimientoPedido,
			TipoMaterial,
			Cve_Material,
			DescripcionMaterial,
			ConsumoMaterialPedido,
			Unidad,
			No_OrdenCompra,
			CantidadOC,
			PendienteDeOC,
			CantidaRecibidaOC,
			Cve_Prenda,
			DescripcionPrenda,
			CantidadPrendasPedido,
			ConsumoMaterialPrenda,
			CantidadPrendasPendientesAsignarOP,
			No_OP,
			Cve_Maquilador,
			Nom_Maquilador,
			FechaProgramaDeFinalizacionOP,
			CantidadPrendasOP,
			ConsumoMaterialOP,
			TotalEnviado,
			PendienteEnviar,
			No_Remision,
			CantidadRemisionada,
			FechaEnvio,
			QuienSeLoLlevo,
			ObservacionesAdicionales,
			FechaFirmaAcuse,
			QuienFirmaAcuse,
			Acuse,
			RutaAcuse,
			ColumnaControl,
			SePuedeModificarFechaEnvio,
			SePuedeModificarAcuse
		FROM
			#EXPLOSION_MATERIALES_OP_REMISIONES
		WHERE
			No_OP IS NOT NULL
		AND FechaEnvio IS NOT NULL
		AND FechaFirmaAcuse IS NULL
		ORDER BY
			No_Pedido,
			CASE TipoMaterial 
				WHEN 'T' THEN 1
				WHEN 'H' THEN 2
			END,
			Cve_Material,
			Cve_Prenda,
			No_OrdenCompra,
			No_Remision
	END
	IF @ADICIONAL NOT IN (1,2)
	BEGIN
		SELECT 
			Empresa,
			No_Pedido,
			Cve_Cliente,
			RazonSocial,
			FechaVencimientoPedido,
			TipoMaterial,
			Cve_Material,
			DescripcionMaterial,
			ConsumoMaterialPedido,
			Unidad,
			No_OrdenCompra,
			CantidadOC,
			PendienteDeOC,
			CantidaRecibidaOC,
			Cve_Prenda,
			DescripcionPrenda,
			CantidadPrendasPedido,
			ConsumoMaterialPrenda,
			CantidadPrendasPendientesAsignarOP,
			No_OP,
			Cve_Maquilador,
			Nom_Maquilador,
			FechaProgramaDeFinalizacionOP,
			CantidadPrendasOP,
			ConsumoMaterialOP,
			TotalEnviado,
			PendienteEnviar,
			No_Remision,
			CantidadRemisionada,
			FechaEnvio,
			QuienSeLoLlevo,
			ObservacionesAdicionales,
			FechaFirmaAcuse,
			QuienFirmaAcuse,
			Acuse,
			RutaAcuse,
			ColumnaControl,
			SePuedeModificarFechaEnvio,
			SePuedeModificarAcuse
		FROM
			#EXPLOSION_MATERIALES_OP_REMISIONES
		ORDER BY
			No_Pedido,
			CASE TipoMaterial 
				WHEN 'T' THEN 1
				WHEN 'H' THEN 2
			END,
			Cve_Material,
			Cve_Prenda,
			No_OrdenCompra,
			No_Remision
	END
		
	DROP TABLE #EXPLOSION_MATERIALES_OP_REMISIONES
END

--exec CONSULTA_CONTROL_TELAS_HABILITACIONES 1,0,0,1749,1749,0,0

--SELECT * FROM ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO WHERE No_Pedido = 1558 AND Cve_Material = 'ETC000001'

--SELECT * FROM SUGERIDO_COMPRA WHERE No_Pedido = 1558 AND Cve_Material = 'ETC000001'

--SELECT * FROM ORDEN_COMPRA_ASIGNACION_ITERACIONES WHERE No_Pedido = 1558 AND Cve_Material = 'ETC000001'
--SELECT * FROM ORDEN_COMPRA_ASIGNACION_ITERACIONES WHERE No_Pedido = 1558 AND Cve_Material = 'ETC000001' AND Cve_Prenda = 7202 AND LugarEntrega = 3234

--SELECT * FROM PEDIDO_INTERNO_TALLAS WHERE No_Pedido = 1558 AND No_OP = 1748

--SELECT * FROM REMISION_MATERIAL WHERE No_OP = 1748 AND TipoMaterial = 'H' AND Cve_Material = 'ETC000001'

--SELECT * FROM OP_EXPLOSION_MATERIALES_INSPECTOR WHERE TipoMovimiento = 'FALTANTE' AND NO_OP = 1695
GO

