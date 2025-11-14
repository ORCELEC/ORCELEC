USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[OP_CONSULTA_TALLAS_CANTIDADES_INGRESO_SALDO_POR_RECIBIR]    Script Date: 13/11/2025 07:23:48 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OP_CONSULTA_TALLAS_CANTIDADES_INGRESO_SALDO_POR_RECIBIR]
--DECLARE
	@EMPRESA BIGINT,
	@NO_OP BIGINT
AS
BEGIN

--	SET @EMPRESA = 1
--	SET @NO_OP = 1369

	CREATE TABLE #ORDEN_PRODUCCION
	(
		NO_OP BIGINT,
		CVE_MAQUILADOR BIGINT,
		NOM_MAQUILADOR NVARCHAR(255),
		No_Pedido bigint,
		Cve_Prenda bigint,
		DescripcionPrenda nvarchar(1000),
		Cve_Cliente bigint,
		Nom_Cliente nvarchar(255),
		Partida bigint,
		FechaEntrada datetime,
		No_Entrada bigint,
		FolioManual nvarchar(50),
		Talla nvarchar(20),
		Cantidad bigint,
		CantidadRecibida bigint,
		Total bigint,
		ColumnaControl bit
	)

	INSERT INTO #ORDEN_PRODUCCION
	(
		NO_OP,
		CVE_MAQUILADOR,
		NOM_MAQUILADOR,
		No_Pedido,
		Cve_Prenda,
		DescripcionPrenda,
		Cve_Cliente,
		Nom_Cliente,
		Partida,
		Talla,
		Cantidad,
		CantidadRecibida,
		Total,
		ColumnaControl
	)
	SELECT
		OPA.No_OP,
		OPA.Cve_Maquilador,
		OPA.Nom_Maquilador,
		PIT.No_Pedido,
		PIT.Cve_Prenda,
		PIT.DescripcionPrenda,
		PI.Cve_Cliente,
		PI.Nom_Cliente,
		TG.Partida,
		PIT.Talla,
		SUM(PIT.Cantidad)-ISNULL(SUM(RIPT.CANTIDAD),0) AS Cantidad,
		(SUM(PIT.Cantidad)-ISNULL(SUM(RIPT.CANTIDAD),0))-(SELECT ISNULL(SUM(PEI.Cantidad),0) FROM PRENDA_ENTRADA_INVENTARIO PEI WHERE PEI.Empresa = @EMPRESA AND PEI.TipoEntrada = 'OP' AND PEI.TipoEntradaNumero = OPA.No_OP AND PEI.Talla = PIT.Talla AND PEI.Estatus = 'AUTORIZADO'),
		(SELECT SUM(PIT1.Cantidad-ISNULL(RIPT1.Cantidad,0)) FROM PEDIDO_INTERNO_TALLAS PIT1 LEFT JOIN RESERVADO_INVENTARIO_PRODUCTO_TERMINADO RIPT1 ON RIPT1.Empresa = PIT1.Empresa AND RIPT1.No_Pedido = PIT1.No_Pedido AND RIPT1.Partida = PIT1.Partida AND RIPT1.Cve_Prenda = PIT1.Cve_Prenda AND RIPT1.LugarDeEntrega = PIT1.LugarDeEntrega AND RIPT1.Prioridad = PIT1.Prioridad AND RIPT1.Talla = PIT1.Talla WHERE PIT1.Empresa = @EMPRESA AND PIT1.No_OP = @NO_OP)-(SELECT ISNULL(SUM(PEI.Cantidad),0) FROM PRENDA_ENTRADA_INVENTARIO PEI WHERE PEI.Empresa = @EMPRESA AND PEI.TipoEntrada = 'OP' AND PEI.TipoEntradaNumero = OPA.No_OP AND PEI.Estatus = 'AUTORIZADO'),
		--(SELECT ISNULL(SUM(PEI.Cantidad),0) FROM PRENDA_ENTRADA_INVENTARIO PEI WHERE PEI.Empresa = @EMPRESA AND PEI.TipoEntrada = 'OP' AND PEI.TipoEntradaNumero = OPA.No_OP AND PEI.Estatus = 'AUTORIZADO')
		0
	FROM
		OP_ASIGNACION OPA,
		PEDIDO_INTERNO PI,
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
		TALLAS_GENERALES TG
	WHERE
		OPA.Empresa = @EMPRESA
	AND OPA.No_OP = @NO_OP
	AND	PIT.Empresa = OPA.Empresa
	AND PIT.No_OP = OPA.No_OP
	AND PI.Empresa = PIT.Empresa
	AND PI.No_Pedido = PIT.No_Pedido
	AND PIT.Talla = TG.Talla
	GROUP BY
		OPA.No_OP,
		OPA.Cve_Maquilador,
		OPA.Nom_Maquilador,
		PIT.No_Pedido,
		PIT.Cve_Prenda,
		PIT.DescripcionPrenda,
		PI.Cve_Cliente,
		PI.Nom_Cliente,
		TG.Partida,
		PIT.Talla
	HAVING
		SUM(PIT.Cantidad) - ISNULL(SUM(RIPT.CANTIDAD), 0) > 0
	ORDER BY
		TG.Partida

	DECLARE 
		@tallas_tabla as nvarchar(max),
		@tallas AS NVARCHAR(MAX),
		@query AS NVARCHAR(MAX);

	-- Obtener las tallas únicas ordenadas por 'Partida' y concatenarlas en una cadena separada por comas
	SELECT @tallas_tabla =
	STUFF((SELECT ',' + QUOTENAME(Talla) + ' nvarchar(50)'
			   FROM (SELECT DISTINCT Talla, Partida FROM #ORDEN_PRODUCCION) AS Tallas
			   ORDER BY Partida
			   FOR XML PATH(''), TYPE
			   ).value('.', 'NVARCHAR(MAX)'), 
			   1, 1, ''),
		@tallas = 
		STUFF((SELECT ',' + QUOTENAME(Talla) 
			   FROM (SELECT DISTINCT Talla, Partida FROM #ORDEN_PRODUCCION) AS Tallas
			   ORDER BY Partida
			   FOR XML PATH(''), TYPE
			   ).value('.', 'NVARCHAR(MAX)'), 
			   1, 1, '');
	--set @query = '
	--CREATE TABLE #ORDEN_PRODUCCION_MOVIMIENTOS
	--(
	--	NO_OP BIGINT,
	--	CVE_MAQUILADOR BIGINT,
	--	NOM_MAQUILADOR NVARCHAR(255),
	--	No_Pedido bigint,
	--	Cve_Prenda bigint,
	--	DescripcionPrenda nvarchar(1000),
	--	Cve_Cliente bigint,
	--	Nom_Cliente nvarchar(255),'
	--	+ @tallas_tabla + '
	--)'

	--EXEC sp_executesql @query;

	--select * from #ORDEN_PRODUCCION_MOVIMIENTOS
	-- Construir la consulta PIVOT dinámica
	SET @query = '
	SELECT NO_OP, CVE_MAQUILADOR, NOM_MAQUILADOR, No_Pedido, Cve_Prenda, DescripcionPrenda, Cve_Cliente, Nom_Cliente, FechaEntrada,No_Entrada,' + '''Saldo por Recibir''' + ' as FolioManual,' + @tallas + ',Total,ColumnaControl
	FROM
	(
		SELECT OP.NO_OP, OP.CVE_MAQUILADOR, OP.NOM_MAQUILADOR, OP.No_Pedido, OP.Cve_Prenda, OP.DescripcionPrenda, OP.Cve_Cliente, OP.Nom_Cliente,OP.FechaEntrada,OP.No_Entrada,OP.FolioManual,OP.Talla, OP.CantidadRecibida,OP.Total,OP.ColumnaControl
		FROM #ORDEN_PRODUCCION OP
	) AS SourceTable
	PIVOT
	(
		SUM(CantidadRecibida)
		FOR Talla IN (' + @tallas + ')
	) AS PivotTable
	ORDER BY No_Pedido;';

	-- Ejecutar la consulta PIVOT dinámica
	EXEC sp_executesql @query;

	--SET @query = '
	--SELECT TIPOENTRADANUMERO, CVE_MAQUILADOR, NOM_MAQUILADOR, No_Pedido, Cve_Prenda, DescripcionPrenda, Cve_Cliente, Nom_Cliente, ' + @tallas + '
	--FROM
	--(
	--    SELECT NO_OP, CVE_MAQUILADOR, NOM_MAQUILADOR, No_Pedido, Cve_Prenda, DescripcionPrenda, Cve_Cliente, Nom_Cliente, Talla, Cantidad
	--    FROM #ORDEN_PRODUCCION
	--) AS SourceTable
	--PIVOT
	--(
	--    SUM(Cantidad)
	--    FOR Talla IN (' + @tallas + ')
	--) AS PivotTable
	--ORDER BY No_Pedido;';

	--SELECT 
	--	TipoEntradaNumero,No_Entrada, [CH],[2XG],[3XG] 
	--FROM  
	--	(
	--	SELECT TipoEntradaNumero,No_Entrada, Talla, Cantidad
	--	FROM PRENDA_ENTRADA_INVENTARIO
	--	) 
	--	AS SourceTable  PIVOT  
	--	(      
	--	SUM(Cantidad)      
	--	FOR Talla IN ([CH],[2XG],[3XG])  
	--	) 
	--	AS PivotTable  
	--	ORDER BY No_Entrada;

	--SELECT * FROM PRENDA_ENTRADA_INVENTARIO

	DROP TABLE #ORDEN_PRODUCCION

	--SELECT * FROM PEDIDO_INTERNO_TALLAS WHERE No_OP = 1369
END

--OP_CONSULTA_TALLAS_CANTIDADES_INGRESO_SALDO_POR_RECIBIR 1,1369
GO

