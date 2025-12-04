USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[GUARDA_FACTURAS]    Script Date: 03/12/2025 08:22:57 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GUARDA_FACTURAS]
--DECLARE
	@EMPRESA BIGINT,
	@NO_PEDIDO BIGINT,
	@FACTURAR_COMPLETO BIT,
	@FACTURAR_ZONA_PRIORIDAD BIT,
	@ZONAS NVARCHAR(255),
	@FACTURAR_ROPA_DISPONIBLE BIT,
	@LUGAR_ENTREGA BIT,
	@PARTIDA BIT,
	@PARTIDAPORTALLA BIT,
	@PARTIDATODASLASTALLAS BIT,
	@DESCRIPCION_FACTURA DESCRIPCIONFACTURA READONLY,
	@USUARIO BIGINT,
	@COMPUTADORA NVARCHAR(50)
AS
BEGIN
--SET @EMPRESA = 1
--SET @NO_PEDIDO = 1232
--SET @FACTURAR_COMPLETO = 0
--SET @FACTURAR_ZONA_PRIORIDAD = 0
--SET @ZONAS = NULL
--SET @FACTURAR_ROPA_DISPONIBLE = 0
--SET @LUGAR_ENTREGA = 1
--SET @PARTIDA = 0

--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'34',5,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'36',50,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'38',35,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'40',10,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'42',35,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'44',35,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'46',15,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'48',15,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'50',10,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'52',5,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'54',10,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'56',10,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'58',5,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,6,3137,9158,'0000804860 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00006 CAMISA DE ALGODÓN MANGA LARGA COLOR KAKI.',794.90,'65',5,'POS. 00006','53101600','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'26',5,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'30',10,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'32',35,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'33',30,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'34',35,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'36',35,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'38',25,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'40',15,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'42',15,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'48',10,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'50',20,'POS. 00013','53101500','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(1232,15,3137,9161,'0000084627 PANTALÓN KAKI DE TRABAJO ALMACÉN 1000 MATERIAL ACTIVO ESTA POSICIÓN ES CREADA CON REFERENCIA A LA SOLPED 500648829 POSICIÓN 00013 PANTALÓN KAKI DE TRABAJO.',794.90,'52',10,'POS. 00013','53101500','H87','Pieza')


--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA DE FACTURA 1 TALLA/CANTIDAD 30/5  32/10  34/12  36/51  38/174  40/149  42/71  44/51  46/21  48/4  50/1  52/1',1.0000,NULL,NULL,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,46,'PRUEBA DE FACTURA 3 TALLA/CANTIDAD 28/11  30/14  32/24  33/8  34/65  36/20  38/4  40/8  42/4',1.0000,NULL,NULL,'POS.00003','51433016','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,52,'PRUEBA DE FACTURA 5 TALLA/CANTIDAD 30/10  32/10  34/9  36/109  38/312  40/195  42/186  44/35  46/20  48/15  50/4  52/2',1.0000,NULL,NULL,'POS.00005','51433018','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,3,46,'PRUEBA DE FACTURA 3 TALLA/CANTIDAD 28/10  30/24  32/38  33/10  34/82  36/48  38/24  42/8  44/4  50/2',1.0000,NULL,NULL,'POS.00003','51433016','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,4,46,'PRUEBA DE FACTURA 3 TALLA/CANTIDAD 28/2  30/44  31/4  32/109  33/46  34/257  36/144  38/99  40/54  42/17  44/10  46/4',1.0000,NULL,NULL,'POS.00003','51433016','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,43,'PRUEBA PARTIDA 1 TALLA/CANTIDAD 30/2 32/1 38/100 44/25',1.0000,'30',2,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,43,'PRUEBA PARTIDA 1 TALLA/CANTIDAD 30/2 32/1 38/100 44/25',1.0000,'32',1,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,43,'PRUEBA PARTIDA 1 TALLA/CANTIDAD 30/2 32/1 38/100 44/25',1.0000,'38',1000,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,43,'PRUEBA PARTIDA 1 TALLA/CANTIDAD 30/2 32/1 38/100 44/25',1.0000,'44',25,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,44,'PRUEBA PARTIDA 2 TALLA/CANTIDAD 28/3 32/5 36/20 40/50',1.0000,'28',3,'POS.00002','51433015','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,44,'PRUEBA PARTIDA 2 TALLA/CANTIDAD 28/3 32/5 36/20 40/50',1.0000,'32',5,'POS.00002','51433015','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,44,'PRUEBA PARTIDA 2 TALLA/CANTIDAD 28/3 32/5 36/20 40/50',1.0000,'36',20,'POS.00002','51433015','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,1,44,'PRUEBA PARTIDA 2 TALLA/CANTIDAD 28/3 32/5 36/20 40/50',1.0000,'40',50,'POS.00002','51433015','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA PARTIDA 3 TALLA/CANTIDAD 30/5 32/10 36/30 40/100 42/71 44/35',1.0000,'30',5,'POS.00001','51433012','H87','Pieza')

--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA PARTIDA 3 TALLA/CANTIDAD 30/5 32/10 36/30 40/100 42/71 44/35',1.0000,'32',10,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA PARTIDA 3 TALLA/CANTIDAD 30/5 32/10 36/30 40/100 42/71 44/35',1.0000,'36',30,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA PARTIDA 3 TALLA/CANTIDAD 30/5 32/10 36/30 40/100 42/71 44/35',1.0000,'40',100,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA PARTIDA 3 TALLA/CANTIDAD 30/5 32/10 36/30 40/100 42/71 44/35',1.0000,'42',71,'POS.00001','51433012','H87','Pieza')
--INSERT INTO @DESCRIPCION_FACTURA VALUES(7,2,43,'PRUEBA PARTIDA 3 TALLA/CANTIDAD 30/5 32/10 36/30 40/100 42/71 44/35',1.0000,'44',35,'POS.00001','51433012','H87','Pieza')


--SET @USUARIO = 0
--SET	@COMPUTADORA = 'ANALISISUNO'

--EXEC CONSULTA_TALLAS_CANTIDADES_A_FACTURAR_OPCION_COMPLETO 1,7,0,0,NULL,0,1,0
DECLARE @TRAN_STARTED BIT
	SET @TRAN_STARTED = 0
	
	BEGIN TRY
	
		BEGIN TRANSACTION
		SET @TRAN_STARTED = 1

		CREATE TABLE #PEDIDO
		(
			No_Pedido bigint,
			PartidaPedido bigint,
			Num_Folio bigint,
			No_OP bigint,
			Cve_Cliente bigint,
			Nom_Cliente nvarchar(255),
			Cve_Prenda bigint,
			DescripcionPrenda nvarchar(500),
			LugarDeEntrega bigint,
			NombreLugarDeEntrega nvarchar(255),
			FechaVencimiento date,
			Prioridad bigint,
			MotivoPrioridad nvarchar(1000),
			Partida bigint,
			Talla nvarchar(10),
			Cantidad numeric(18,0),
			PorcentajeIVA numeric(18,2),
			PrecioUnitario numeric(18,4),
			ObservacionesPartida nvarchar(max),
			CantidadFacturada numeric(18,0),
			SaldoAFacturar numeric(18,0),
			CantidadLiberadaOP numeric(18,0),
			SaldoLiberadoAFacturar numeric(18,0),
			RegimenFiscalReceptor nvarchar(255),
			MetodoPago nvarchar(255),
			FormaPago nvarchar(255),
			CuentaPago nvarchar(255),
			BancoPago nvarchar(255),
			UsoCFDI nvarchar(255),
			CondicionesPago nvarchar(150)
		)

		CREATE TABLE #TEMP
		(
			PARTIDA BIGINT,
			TALLA NVARCHAR(10)
		)

		CREATE TABLE #FACTURAS
		(
			NO_FACTURA BIGINT,
			LUGARDEENTREGA BIGINT,
			CVE_PRENDA BIGINT
		)

		CREATE TABLE #FACTURAS_PARTIDAS
		(
			NO_FACTURA BIGINT,
			PartidaPedido bigint,
			CVE_PRENDA BIGINT,
			PARTIDA BIGINT
		)

		CREATE TABLE #DESCRIPCION_FACTURA
		(
			No_Pedido bigint,
			PartidaPedido bigint,
			LugarDeEntrega bigint,
			Cve_Prenda bigint,
			DescripcionPartida nvarchar(1000),
			PrecioUnitario numeric(18,4),
			Talla nvarchar(10),
			Cantidad numeric(18,0),
			CveArticuloCliente nvarchar(50),
			CveProdServ nvarchar(50),
			CveUnidadMedida nvarchar(10),
			UnidadMedida nvarchar(255)
		)

		CREATE TABLE #DESCRIPCIONFACTURA
		(
			CveArticuloCliente NVARCHAR(50),
			PartidaPedido BIGINT,
			TallaAFacturar NVARCHAR(50),
			CantidadAFacturar BIGINT,
			PrecioUnitario NUMERIC(18,4),
			DescripcionFactura NVARCHAR(1000),
			CveProdServ nvarchar(50),
			CveUnidadMedida nvarchar(10),
			UnidadMedida nvarchar(255),
		)

		INSERT INTO #PEDIDO
		(
			No_Pedido,
			PartidaPedido,
			Num_Folio,
			No_OP,
			Cve_Cliente,
			Nom_Cliente,
			Cve_Prenda,
			DescripcionPrenda,
			LugarDeEntrega,
			NombreLugarDeEntrega,
			FechaVencimiento,
			Prioridad,
			MotivoPrioridad,
			Partida,
			Talla,
			Cantidad,
			PorcentajeIVA,
			PrecioUnitario,
			ObservacionesPartida,
			CantidadFacturada,
			SaldoAFacturar,
			CantidadLiberadaOP,
			SaldoLiberadoAFacturar,
			RegimenFiscalReceptor,
			MetodoPago,
			FormaPago,
			CuentaPago,
			BancoPago,
			UsoCFDI,
			CondicionesPago
		)
		SELECT
			PI.No_Pedido,
			PIT.Partida,
			PI.Num_Folio,
			PIT.No_OP,
			PI.Cve_Cliente,
			PI.Nom_Cliente,
			PIT.Cve_Prenda,
			PIT.DescripcionPrenda,
			PIT.LugarDeEntrega,
			PIT.NombreLugarDeEntrega,
			PIT.FechaVencimiento,
			PIT.Prioridad,
			PIT.MotivoPrioridad,
			TG.Partida,
			PIT.Talla,
			PIT.Cantidad,
			PI.PorcentajeIVA,
			PIT.PrecioUnitario,
			PIT.ObservacionesPartidaFacturacion,
			(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
			PIT.Cantidad-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
			(SELECT ISNULL(SUM(OPA.Cantidad),0) FROM OP_AVANCEPROCESOS OPA WHERE OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND OPA.Talla = PIT.Talla AND OPA.Nivel1 = 2 AND OPA.Nivel2 = 40 AND OPA.Nivel3 = 0),
			(SELECT ISNULL(SUM(OPA.Cantidad),0) FROM OP_AVANCEPROCESOS OPA WHERE OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND OPA.Talla = PIT.Talla AND OPA.Nivel1 = 2 AND OPA.Nivel2 = 40 AND OPA.Nivel3 = 0)-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
			PI.RegimenFiscal,
			PI.MetodoPago,
			PI.FormaPago,
			PI.CuentaPago,
			PI.BancoPago,
			PI.UsoCFDI,
			CONVERT(NVARCHAR,PI.CondicionesPagoDias) + ' DIAS ' + PI.CondicionesPagoTipoDias
		FROM 
			PEDIDO_INTERNO PI,
			PEDIDO_INTERNO_TALLAS PIT,
			TALLAS_GENERALES TG
		WHERE 
			PI.Empresa = @EMPRESA
		AND PI.No_Pedido = @NO_PEDIDO
		AND PIT.Empresa = PI.Empresa
		AND PIT.No_Pedido = PI.No_Pedido
		AND TG.Talla = PIT.Talla
		ORDER BY
			PI.No_Pedido,
			PIT.Cve_Prenda,
			PIT.LugarDeEntrega,
			PIT.Prioridad,
			TG.Partida

		DECLARE @SQL NVARCHAR(MAX)
		DECLARE @cols AS NVARCHAR(MAX)
		DECLARE @NO_FACTURA BIGINT

		IF @FACTURAR_COMPLETO = 1 --AQUÍ SE ENTRA CUANDO SE NECESITA FACTURAR COMPLETO EL PEDIDO
		BEGIN
			IF @PARTIDA = 1 --FACTURAR COMPLETO POR PARTIDA
			BEGIN
				SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
				--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

				DELETE #FACTURAS
			
				INSERT INTO #FACTURAS
				(
					NO_FACTURA,
					LUGARDEENTREGA,
					CVE_PRENDA
				)
				SELECT
					(@NO_FACTURA + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
					LugarDeEntrega,
					Cve_Prenda
				FROM
					#PEDIDO
				WHERE
					SaldoAFacturar > 0
				GROUP BY
					LugarDeEntrega,
					Cve_Prenda

				DELETE #FACTURAS_PARTIDAS

				INSERT INTO #FACTURAS_PARTIDAS
				(
					NO_FACTURA,
					CVE_PRENDA,
					PARTIDA
				)
				SELECT
					R.NO_FACTURA,
					P.Cve_Prenda,
					(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
				FROM 
					#PEDIDO P,
					#FACTURAS R
				WHERE
					P.SaldoAFacturar > 0
				AND R.LUGARDEENTREGA = P.LugarDeEntrega
				AND R.CVE_PRENDA = P.Cve_Prenda
				GROUP BY
					R.NO_FACTURA,
					P.Cve_Prenda
				ORDER BY
					R.NO_FACTURA,
					P.Cve_Prenda


				INSERT INTO PEDIDO_INTERNO_FACTURA
				(
					Empresa,
					No_Pedido,
					Cve_Prenda,
					DescripcionPrenda,
					LugarDeEntrega,
					NombreLugarDeEntrega,
					Prioridad,
					Talla,
					Cantidad,
					No_OP,
					NO_FACTURA,
					FacturaPartida,
					FacturaEstatus
				)
				SELECT
					@EMPRESA AS Empresa,
					P.No_Pedido,
					P.Cve_Prenda,
					P.DescripcionPrenda,
					P.LugarDeEntrega, 
					P.NombreLugarDeEntrega, 
					P.Prioridad,
					P.Talla,
					P.SaldoAFacturar,
					P.No_OP,
					R.NO_FACTURA,
					RP.PARTIDA,
					'AUTORIZADA' AS FacturaEstatus
				FROM 
					#PEDIDO P,
					#FACTURAS R,
					#FACTURAS_PARTIDAS RP
				WHERE
					P.SaldoAFacturar > 0
				AND R.LUGARDEENTREGA = P.LugarDeEntrega
				AND RP.NO_FACTURA = R.NO_FACTURA
				AND RP.CVE_PRENDA = P.Cve_Prenda
				ORDER BY
					LugarDeEntrega,
					NombreLugarDeEntrega,
					Cve_Prenda;

				INSERT INTO FACTURA
				(
					Empresa,
					No_Factura,
					Partida,
					FechaHoraFactura,
					Estatus,
					Cve_Cliente,
					Cliente_Nombre,
					ClienteRFC,
					ClienteCalle,
					ClienteNoExterior,
					ClienteNoInterior,
					ClienteColonia,
					ClienteMunicipio,
					ClienteCP,
					ClienteCiudad,
					ClienteEstado,
					ClienteTelefono,
					ClienteFax,
					ClienteEmail,
					ClienteContacto,
					ClienteTelContacto,
					RegimenFiscalReceptor,
					MetodoPago,
					FormaPago,
					CuentaPago,
					BancoPago,
					UsoCFDI,
					CveProdServ,
					CveUnidadMedida,
					UnidadMedida,
					Cve_PedCliente,
					Cve_Proveedor,
					Orden_Surtimiento,
					Contrato_Cliente,
					No_Pedido,
					Num_Folio,
					LugarDeEntrega,
					NombreLugarDeEntrega,
					LugarDeEntregaCalle,
					LugarDeEntregaNoExterior,
					LugarDeEntregaNoInterior,
					LugarDeEntregaColonia,
					LugarDeEntregaMunicipio,
					LugarDeEntregaCP,
					LugarDeEntregaCiudad,
					LugarDeEntregaEstado,
					LugarDeEntregaTelefono,
					LugarDeEntregaFax,
					LugarDeEntregaEmail,
					LugarDeEntregaContacto,
					LugarDeEntregaTelContacto,
					LugarDeEntregaAtencion,
					LugarDeEntregaTelAtencion,
					CondicionesPago,
					PorcentajeIVA,
					CveArticuloCliente,
					Cantidad,
					Descripcion,
					Precio,
					PartidaSubtotal,
					PartidaIVA,
					PartidaTotal,
					USUARIO,
					FECHAHORA,
					COMPUTADORA
				)
				SELECT
					@EMPRESA AS Empresa,
					R.NO_FACTURA,
					RP.PARTIDA,
					GETDATE() AS FechaHoraFactura,
					'AUTORIZADA' AS Estatus,
					P.Cve_Cliente,
					P.Nom_Cliente,
					C.RFC,
					C.Calle,
					C.NoExterior,
					C.NoInterior,
					C.Colonia,
					C.Municipio,
					C.CP,
					C.Ciudad,
					C.Estado,
					C.Telefono,
					C.Fax,
					C.Email,
					C.Contacto,
					C.TelContacto,
					P.RegimenFiscalReceptor,
					P.MetodoPago,
					P.FormaPago,
					P.CuentaPago,
					P.BancoPago,
					P.UsoCFDI,
					DR.CveProdServ,
					DR.CveUnidadMedida,
					DR.UnidadMedida,
					FA.Cve_PedCliente,
					FA.Cve_Proveedor,
					FA.Orden_Surtimiento,
					FA.Contrato_Cliente,
					P.No_Pedido,
					P.Num_Folio,
					P.LugarDeEntrega, 
					P.NombreLugarDeEntrega,
					REM.Calle,
					REM.NoExterior,
					REM.NoInterior,
					REM.Colonia,
					REM.Municipio,
					REM.CP,
					REM.Ciudad,
					REM.Estado,
					REM.Telefono,
					REM.Fax,
					REM.Email,
					REM.Contacto,
					REM.TelContacto,
					REM.Atencion,
					REM.TelAtencion,
					P.CondicionesPago AS Condiciones_Pago,
					P.PorcentajeIVA,
					DR.CveArticuloCliente,
					SUM(P.SaldoAFacturar) AS Cantidad,
					DR.DescripcionPartida,
					DR.PrecioUnitario,
					SUM(P.SaldoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
					(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
					(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
					@USUARIO,
					GETDATE() AS FECHAHORA,
					@COMPUTADORA
				FROM 
					#PEDIDO P,
					#FACTURAS R,
					#FACTURAS_PARTIDAS RP,
					CLIENTES C,
					FOLIOS_ADMINISTRACION FA,
					REMISIONADO REM,
					@DESCRIPCION_FACTURA DR
				WHERE
					P.SaldoAFacturar > 0
				AND R.LUGARDEENTREGA = P.LugarDeEntrega
				AND RP.NO_FACTURA = R.NO_FACTURA
				AND RP.CVE_PRENDA = P.Cve_Prenda
				AND C.Cve_Cliente = P.Cve_Cliente
				AND FA.Num_Folio = P.Num_Folio
				AND REM.Cve_Remisionado = P.LugarDeEntrega
				AND DR.No_Pedido = P.No_Pedido
				AND DR.Cve_Prenda = P.Cve_Prenda
				AND DR.LugarDeEntrega = P.LugarDeEntrega
				GROUP BY
					R.NO_FACTURA,
					RP.PARTIDA,
					P.Cve_Cliente,
					P.Nom_Cliente,
					C.RFC,
					C.Calle,
					C.NoExterior,
					C.NoInterior,
					C.Colonia,
					C.Municipio,
					C.CP,
					C.Ciudad,
					C.Estado,
					C.Telefono,
					C.Fax,
					C.Email,
					C.Contacto,
					C.TelContacto,
					P.RegimenFiscalReceptor,
					P.MetodoPago,
					P.FormaPago,
					P.CuentaPago,
					P.BancoPago,
					P.UsoCFDI,
					DR.CveProdServ,
					DR.CveUnidadMedida,
					DR.UnidadMedida,
					FA.Cve_PedCliente,
					FA.Cve_Proveedor,
					FA.Orden_Surtimiento,
					FA.Contrato_Cliente,
					P.No_Pedido,
					P.Num_Folio,
					P.LugarDeEntrega, 
					P.NombreLugarDeEntrega,
					REM.Calle,
					REM.NoExterior,
					REM.NoInterior,
					REM.Colonia,
					REM.Municipio,
					REM.CP,
					REM.Ciudad,
					REM.Estado,
					REM.Telefono,
					REM.Fax,
					REM.Email,
					REM.Contacto,
					REM.TelContacto,
					REM.Atencion,
					REM.TelAtencion,
					P.CondicionesPago,
					P.PorcentajeIVA,
					DR.CveArticuloCliente,
					DR.DescripcionPartida,
					DR.PrecioUnitario
				ORDER BY
					R.NO_FACTURA,
					RP.Partida

				--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
				UPDATE
					FACTURA
				SET
					FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
					FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
					FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
					ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
				FROM
					#FACTURAS R1
				WHERE
					FACTURA.Empresa = @EMPRESA
				AND FACTURA.NO_FACTURA = R1.NO_FACTURA
					
				SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA
			END
			IF @LUGAR_ENTREGA = 1 --FACTURAR COMPLETO POR LUGAR DE ENTREGA
			BEGIN
				SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
				--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

				DELETE #FACTURAS
			
				INSERT INTO #FACTURAS
				(
					NO_FACTURA,
					LUGARDEENTREGA
				)
				SELECT
					(@NO_FACTURA + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
					LugarDeEntrega
				FROM
					#PEDIDO
				WHERE
					SaldoAFacturar > 0
				GROUP BY
					LugarDeEntrega

				DELETE #FACTURAS_PARTIDAS

				INSERT INTO #FACTURAS_PARTIDAS
				(
					NO_FACTURA,
					CVE_PRENDA,
					PARTIDA
				)
				SELECT
					R.NO_FACTURA,
					P.Cve_Prenda,
					(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
				FROM 
					#PEDIDO P,
					#FACTURAS R
				WHERE
					P.SaldoAFacturar > 0
				AND R.LUGARDEENTREGA = P.LugarDeEntrega
				GROUP BY
					R.NO_FACTURA,
					P.Cve_Prenda
				ORDER BY
					R.NO_FACTURA,
					P.Cve_Prenda


				INSERT INTO PEDIDO_INTERNO_FACTURA
				(
					Empresa,
					No_Pedido,
					Cve_Prenda,
					DescripcionPrenda,
					LugarDeEntrega,
					NombreLugarDeEntrega,
					Prioridad,
					Talla,
					Cantidad,
					No_OP,
					NO_FACTURA,
					FacturaPartida,
					FacturaEstatus
				)
				SELECT
					@EMPRESA AS Empresa,
					P.No_Pedido,
					P.Cve_Prenda,
					P.DescripcionPrenda,
					P.LugarDeEntrega, 
					P.NombreLugarDeEntrega, 
					P.Prioridad,
					P.Talla,
					P.SaldoAFacturar,
					P.No_OP,
					R.NO_FACTURA,
					RP.PARTIDA,
					'AUTORIZADA' AS FacturaEstatus
				FROM 
					#PEDIDO P,
					#FACTURAS R,
					#FACTURAS_PARTIDAS RP
				WHERE
					P.SaldoAFacturar > 0
				AND R.LUGARDEENTREGA = P.LugarDeEntrega
				AND RP.NO_FACTURA = R.NO_FACTURA
				AND RP.CVE_PRENDA = P.Cve_Prenda
				ORDER BY
					LugarDeEntrega,
					NombreLugarDeEntrega,
					Cve_Prenda;

				INSERT INTO FACTURA
				(
					Empresa,
					NO_FACTURA,
					Partida,
					FechaHoraFACTURA,
					Estatus,
					Cve_Cliente,
					Cliente_Nombre,
					ClienteRFC,
					ClienteCalle,
					ClienteNoExterior,
					ClienteNoInterior,
					ClienteColonia,
					ClienteMunicipio,
					ClienteCP,
					ClienteCiudad,
					ClienteEstado,
					ClienteTelefono,
					ClienteFax,
					ClienteEmail,
					ClienteContacto,
					ClienteTelContacto,
					RegimenFiscalReceptor,
					MetodoPago,
					FormaPago,
					CuentaPago,
					BancoPago,
					UsoCFDI,
					CveProdServ,
					CveUnidadMedida,
					UnidadMedida,
					Cve_PedCliente,
					Cve_Proveedor,
					Orden_Surtimiento,
					Contrato_Cliente,
					No_Pedido,
					Num_Folio,
					LugarDeEntrega,
					NombreLugarDeEntrega,
					LugarDeEntregaCalle,
					LugarDeEntregaNoExterior,
					LugarDeEntregaNoInterior,
					LugarDeEntregaColonia,
					LugarDeEntregaMunicipio,
					LugarDeEntregaCP,
					LugarDeEntregaCiudad,
					LugarDeEntregaEstado,
					LugarDeEntregaTelefono,
					LugarDeEntregaFax,
					LugarDeEntregaEmail,
					LugarDeEntregaContacto,
					LugarDeEntregaTelContacto,
					LugarDeEntregaAtencion,
					LugarDeEntregaTelAtencion,
					CondicionesPago,
					PorcentajeIVA,
					CveArticuloCliente,
					Cantidad,
					Descripcion,
					Precio,
					PartidaSubtotal,
					PartidaIVA,
					PartidaTotal,
					Layout,
					USUARIO,
					FECHAHORA,
					COMPUTADORA
				)
				SELECT
					@EMPRESA AS Empresa,
					R.NO_FACTURA,
					RP.PARTIDA,
					GETDATE() AS FechaHoraFACTURA,
					'AUTORIZADA' AS Estatus,
					P.Cve_Cliente,
					P.Nom_Cliente,
					C.RFC,
					C.Calle,
					C.NoExterior,
					C.NoInterior,
					C.Colonia,
					C.Municipio,
					C.CP,
					C.Ciudad,
					C.Estado,
					C.Telefono,
					C.Fax,
					C.Email,
					C.Contacto,
					C.TelContacto,
					P.RegimenFiscalReceptor,
					P.MetodoPago,
					P.FormaPago,
					P.CuentaPago,
					P.BancoPago,
					P.UsoCFDI,
					DR.CveProdServ,
					DR.CveUnidadMedida,
					DR.UnidadMedida,
					FA.Cve_PedCliente,
					FA.Cve_Proveedor,
					FA.Orden_Surtimiento,
					FA.Contrato_Cliente,
					P.No_Pedido,
					P.Num_Folio,
					P.LugarDeEntrega, 
					P.NombreLugarDeEntrega,
					REM.Calle,
					REM.NoExterior,
					REM.NoInterior,
					REM.Colonia,
					REM.Municipio,
					REM.CP,
					REM.Ciudad,
					REM.Estado,
					REM.Telefono,
					REM.Fax,
					REM.Email,
					REM.Contacto,
					REM.TelContacto,
					REM.Atencion,
					REM.TelAtencion,
					P.CondicionesPago AS Condiciones_Pago,
					P.PorcentajeIVA,
					DR.CveArticuloCliente,
					SUM(P.SaldoAFacturar) AS Cantidad,
					DR.DescripcionPartida,
					DR.PrecioUnitario,
					SUM(P.SaldoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
					(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
					(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
					0 AS Layout,
					@USUARIO,
					GETDATE() AS FECHAHORA,
					@COMPUTADORA
				FROM 
					#PEDIDO P,
					#FACTURAS R,
					#FACTURAS_PARTIDAS RP,
					CLIENTES C,
					FOLIOS_ADMINISTRACION FA,
					REMISIONADO REM,
					@DESCRIPCION_FACTURA DR
				WHERE
					P.SaldoAFacturar > 0
				AND R.LUGARDEENTREGA = P.LugarDeEntrega
				AND RP.NO_FACTURA = R.NO_FACTURA
				AND RP.CVE_PRENDA = P.Cve_Prenda
				AND C.Cve_Cliente = P.Cve_Cliente
				AND FA.Num_Folio = P.Num_Folio
				AND REM.Cve_Remisionado = P.LugarDeEntrega
				AND DR.No_Pedido = P.No_Pedido
				AND DR.Cve_Prenda = P.Cve_Prenda
				AND DR.LugarDeEntrega = P.LugarDeEntrega
				GROUP BY
					R.NO_FACTURA,
					RP.PARTIDA,
					P.Cve_Cliente,
					P.Nom_Cliente,
					C.RFC,
					C.Calle,
					C.NoExterior,
					C.NoInterior,
					C.Colonia,
					C.Municipio,
					C.CP,
					C.Ciudad,
					C.Estado,
					C.Telefono,
					C.Fax,
					C.Email,
					C.Contacto,
					C.TelContacto,
					P.RegimenFiscalReceptor,
					P.MetodoPago,
					P.FormaPago,
					P.CuentaPago,
					P.BancoPago,
					P.UsoCFDI,
					DR.CveProdServ,
					DR.CveUnidadMedida,
					DR.UnidadMedida,
					FA.Cve_PedCliente,
					FA.Cve_Proveedor,
					FA.Orden_Surtimiento,
					FA.Contrato_Cliente,
					P.No_Pedido,
					P.Num_Folio,
					P.LugarDeEntrega, 
					P.NombreLugarDeEntrega,
					REM.Calle,
					REM.NoExterior,
					REM.NoInterior,
					REM.Colonia,
					REM.Municipio,
					REM.CP,
					REM.Ciudad,
					REM.Estado,
					REM.Telefono,
					REM.Fax,
					REM.Email,
					REM.Contacto,
					REM.TelContacto,
					REM.Atencion,
					REM.TelAtencion,
					P.CondicionesPago,
					P.PorcentajeIVA,
					DR.CveArticuloCliente,
					DR.DescripcionPartida,
					DR.PrecioUnitario
				ORDER BY
					R.NO_FACTURA,
					RP.Partida


				--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
				UPDATE
					FACTURA
				SET
					FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
					FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
					FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
					ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
				FROM
					#FACTURAS R1
				WHERE
					FACTURA.Empresa = @EMPRESA
				AND FACTURA.NO_FACTURA = R1.NO_FACTURA

				SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA
			END
		END
		ELSE
		BEGIN
			IF @FACTURAR_ZONA_PRIORIDAD = 1 --AQUÍ SE ENTRA CUANDO SE SELECCIONA FACTURAR POR ZONA DE PRIORIDAD
			BEGIN
				IF @LUGAR_ENTREGA = 1 ---CUANDO SE SELECCIONA FACTURAR POR ZONA DE PRIORIDAD POR DEFAULT ES POR LUGAR DE ENTREGA
				BEGIN
					SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
					--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

					SET @SQL = '
					SELECT
						(' + CONVERT(NVARCHAR,@NO_FACTURA) + ' + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
						LugarDeEntrega
					FROM
						#PEDIDO
					WHERE
						SaldoAFacturar > 0
					AND PRIORIDAD IN (' + @ZONAS + ')
					GROUP BY
						LugarDeEntrega'

					DELETE #FACTURAS
			
					INSERT INTO #FACTURAS
					(
						NO_FACTURA,
						LUGARDEENTREGA
					)
					EXEC sp_executesql @sql;
					

					SET @SQL = '
					SELECT
						R.NO_FACTURA,
						P.Cve_Prenda,
						(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
					FROM 
						#PEDIDO P,
						#FACTURAS R
					WHERE
						P.SaldoAFacturar > 0
					AND R.LUGARDEENTREGA = P.LugarDeEntrega
					AND P.PRIORIDAD IN (' + @ZONAS + ')
					GROUP BY
						R.NO_FACTURA,
						P.Cve_Prenda
					ORDER BY
						R.NO_FACTURA,
						P.Cve_Prenda'

					DELETE #FACTURAS_PARTIDAS

					INSERT INTO #FACTURAS_PARTIDAS
					(
						NO_FACTURA,
						CVE_PRENDA,
						PARTIDA
					)
					EXEC sp_executesql @sql;

					SET @SQL = '
					SELECT
						' + CONVERT(NVARCHAR,@EMPRESA) + ' AS Empresa,
						P.No_Pedido,
						P.Cve_Prenda,
						P.DescripcionPrenda,
						P.LugarDeEntrega, 
						P.NombreLugarDeEntrega, 
						P.Prioridad,
						P.Talla,
						P.SaldoAFacturar,
						P.No_OP,
						R.NO_FACTURA,
						RP.PARTIDA,
						' + '''AUTORIZADA''' + ' AS FacturaEstatus
					FROM 
						#PEDIDO P,
						#FACTURAS R,
						#FACTURAS_PARTIDAS RP
					WHERE
						P.SaldoAFacturar > 0
					AND P.PRIORIDAD IN (' + @ZONAS + ')
					AND R.LUGARDEENTREGA = P.LugarDeEntrega
					AND RP.NO_FACTURA = R.NO_FACTURA
					AND RP.CVE_PRENDA = P.Cve_Prenda
					ORDER BY
						LugarDeEntrega,
						NombreLugarDeEntrega,
						Cve_Prenda;'


					INSERT INTO PEDIDO_INTERNO_FACTURA
					(
						Empresa,
						No_Pedido,
						Cve_Prenda,
						DescripcionPrenda,
						LugarDeEntrega,
						NombreLugarDeEntrega,
						Prioridad,
						Talla,
						Cantidad,
						No_OP,
						NO_FACTURA,
						FacturaPartida,
						FacturaEstatus
					)
					EXEC sp_executesql @sql;

					
					INSERT INTO #DESCRIPCION_FACTURA
					(
						No_Pedido,
						LugarDeEntrega,
						Cve_Prenda,
						DescripcionPartida,
						PrecioUnitario,
						CveArticuloCliente,
						CveProdServ,
						CveUnidadMedida,
						UnidadMedida
					)
					SELECT
						No_Pedido,
						LugarDeEntrega,
						Cve_Prenda,
						DescripcionPartida,
						PrecioUnitario,
						CveArticuloCliente,
						CveProdServ,
						CveUnidadMedida,
						UnidadMedida
					FROM
						@DESCRIPCION_FACTURA


					SET @SQL = '
					SELECT
						' + CONVERT(NVARCHAR,@EMPRESA) + ' AS Empresa,
						R.NO_FACTURA,
						RP.PARTIDA,
						GETDATE() AS FechaHoraFactura,
						' + '''AUTORIZADA''' + ' AS Estatus,
						P.Cve_Cliente,
						P.Nom_Cliente,
						C.RFC,
						C.Calle,
						C.NoExterior,
						C.NoInterior,
						C.Colonia,
						C.Municipio,
						C.CP,
						C.Ciudad,
						C.Estado,
						C.Telefono,
						C.Fax,
						C.Email,
						C.Contacto,
						C.TelContacto,
						P.RegimenFiscalReceptor,
						P.MetodoPago,
						P.FormaPago,
						P.CuentaPago,
						P.BancoPago,
						P.UsoCFDI,
						DR.CveProdServ,
						DR.CveUnidadMedida,
						DR.UnidadMedida,
						FA.Cve_PedCliente,
						FA.Cve_Proveedor,
						FA.Orden_Surtimiento,
						FA.Contrato_Cliente,
						P.No_Pedido,
						P.Num_Folio,
						P.LugarDeEntrega, 
						P.NombreLugarDeEntrega,
						REM.Calle,
						REM.NoExterior,
						REM.NoInterior,
						REM.Colonia,
						REM.Municipio,
						REM.CP,
						REM.Ciudad,
						REM.Estado,
						REM.Telefono,
						REM.Fax,
						REM.Email,
						REM.Contacto,
						REM.TelContacto,
						REM.Atencion,
						REM.TelAtencion,
						P.CondicionesPago AS Condiciones_Pago,
						P.PorcentajeIVA,
						DR.CveArticuloCliente,
						SUM(P.SaldoAFacturar) AS Cantidad,
						DR.DescripcionPartida,
						DR.PrecioUnitario,
						SUM(P.SaldoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
						(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
						(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
						0 AS Layout,
						' + CONVERT(NVARCHAR,@USUARIO) + ',
						GETDATE() AS FECHAHORA,
						' + '''' +  @COMPUTADORA + '''' + '
					FROM 
						#PEDIDO P,
						#FACTURAS R,
						#FACTURAS_PARTIDAS RP,
						CLIENTES C,
						FOLIOS_ADMINISTRACION FA,
						REMISIONADO REM,
						#DESCRIPCION_FACTURA DR
					WHERE
						P.SaldoAFacturar > 0
					AND P.PRIORIDAD IN (' + @ZONAS + ')
					AND R.LUGARDEENTREGA = P.LugarDeEntrega
					AND RP.NO_FACTURA = R.NO_FACTURA
					AND RP.CVE_PRENDA = P.Cve_Prenda
					AND C.Cve_Cliente = P.Cve_Cliente
					AND FA.Num_Folio = P.Num_Folio
					AND REM.Cve_Remisionado = P.LugarDeEntrega
					AND DR.No_Pedido = P.No_Pedido
					AND DR.Cve_Prenda = P.Cve_Prenda
					AND DR.LugarDeEntrega = P.LugarDeEntrega
					GROUP BY
						R.NO_FACTURA,
						RP.PARTIDA,
						P.Cve_Cliente,
						P.Nom_Cliente,
						C.RFC,
						C.Calle,
						C.NoExterior,
						C.NoInterior,
						C.Colonia,
						C.Municipio,
						C.CP,
						C.Ciudad,
						C.Estado,
						C.Telefono,
						C.Fax,
						C.Email,
						C.Contacto,
						C.TelContacto,
						P.RegimenFiscalReceptor,
						P.MetodoPago,
						P.FormaPago,
						P.CuentaPago,
						P.BancoPago,
						P.UsoCFDI,
						DR.CveProdServ,
						DR.CveUnidadMedida,
						DR.UnidadMedida,
						FA.Cve_PedCliente,
						FA.Cve_Proveedor,
						FA.Orden_Surtimiento,
						FA.Contrato_Cliente,
						P.No_Pedido,
						P.Num_Folio,
						P.LugarDeEntrega, 
						P.NombreLugarDeEntrega,
						REM.Calle,
						REM.NoExterior,
						REM.NoInterior,
						REM.Colonia,
						REM.Municipio,
						REM.CP,
						REM.Ciudad,
						REM.Estado,
						REM.Telefono,
						REM.Fax,
						REM.Email,
						REM.Contacto,
						REM.TelContacto,
						REM.Atencion,
						REM.TelAtencion,
						P.CondicionesPago,
						P.PorcentajeIVA,
						DR.CveArticuloCliente,
						DR.DescripcionPartida,
						DR.PrecioUnitario
					ORDER BY
						R.NO_FACTURA,
						RP.Partida'

					INSERT INTO FACTURA
					(
						Empresa,
						NO_FACTURA,
						Partida,
						FechaHoraFACTURA,
						Estatus,
						Cve_Cliente,
						Cliente_Nombre,
						ClienteRFC,
						ClienteCalle,
						ClienteNoExterior,
						ClienteNoInterior,
						ClienteColonia,
						ClienteMunicipio,
						ClienteCP,
						ClienteCiudad,
						ClienteEstado,
						ClienteTelefono,
						ClienteFax,
						ClienteEmail,
						ClienteContacto,
						ClienteTelContacto,
						RegimenFiscalReceptor,
						MetodoPago,
						FormaPago,
						CuentaPago,
						BancoPago,
						UsoCFDI,
						CveProdServ,
						CveUnidadMedida,
						UnidadMedida,
						Cve_PedCliente,
						Cve_Proveedor,
						Orden_Surtimiento,
						Contrato_Cliente,
						No_Pedido,
						Num_Folio,
						LugarDeEntrega,
						NombreLugarDeEntrega,
						LugarDeEntregaCalle,
						LugarDeEntregaNoExterior,
						LugarDeEntregaNoInterior,
						LugarDeEntregaColonia,
						LugarDeEntregaMunicipio,
						LugarDeEntregaCP,
						LugarDeEntregaCiudad,
						LugarDeEntregaEstado,
						LugarDeEntregaTelefono,
						LugarDeEntregaFax,
						LugarDeEntregaEmail,
						LugarDeEntregaContacto,
						LugarDeEntregaTelContacto,
						LugarDeEntregaAtencion,
						LugarDeEntregaTelAtencion,
						CondicionesPago,
						PorcentajeIVA,
						CveArticuloCliente,
						Cantidad,
						Descripcion,
						Precio,
						PartidaSubtotal,
						PartidaIVA,
						PartidaTotal,
						Layout,
						USUARIO,
						FECHAHORA,
						COMPUTADORA
					)
					EXEC sp_executesql @sql;

					--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
					UPDATE
						FACTURA
					SET
						FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
						FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
						FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
						ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
					FROM
						#FACTURAS R1
					WHERE
						FACTURA.Empresa = @EMPRESA
					AND FACTURA.NO_FACTURA = R1.NO_FACTURA

					SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA
				END
			END
			ELSE
			BEGIN
				IF @FACTURAR_ROPA_DISPONIBLE = 1 --AQUÍ SE ENTRA CUANDO SE SELECCIONA FACTURAR ROPA DISPONIBLE (LIBERADA POR PRODUCCIÓN)
				BEGIN
					IF @PARTIDA = 1 --FACTURAR ROPA DISPONIBLE POR PARTIDA
					BEGIN
						SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
						--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

						DELETE #FACTURAS
			
						INSERT INTO #FACTURAS
						(
							NO_FACTURA,
							LUGARDEENTREGA,
							CVE_PRENDA
						)
						SELECT
							(@NO_FACTURA + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
							LugarDeEntrega,
							Cve_Prenda
						FROM
							#PEDIDO
						WHERE
							SaldoLiberadoAFacturar > 0
						GROUP BY
							LugarDeEntrega,
							Cve_Prenda

						DELETE #FACTURAS_PARTIDAS

						INSERT INTO #FACTURAS_PARTIDAS
						(
							NO_FACTURA,
							CVE_PRENDA,
							PARTIDA
						)
						SELECT
							R.NO_FACTURA,
							P.Cve_Prenda,
							(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
						FROM 
							#PEDIDO P,
							#FACTURAS R
						WHERE
							P.SaldoLiberadoAFacturar > 0
						AND R.LUGARDEENTREGA = P.LugarDeEntrega
						AND R.CVE_PRENDA = P.Cve_Prenda
						GROUP BY
							R.NO_FACTURA,
							P.Cve_Prenda
						ORDER BY
							R.NO_FACTURA,
							P.Cve_Prenda


						INSERT INTO PEDIDO_INTERNO_FACTURA
						(
							Empresa,
							No_Pedido,
							Cve_Prenda,
							DescripcionPrenda,
							LugarDeEntrega,
							NombreLugarDeEntrega,
							Prioridad,
							Talla,
							Cantidad,
							No_OP,
							NO_FACTURA,
							FacturaPartida,
							FacturaEstatus
						)
						SELECT
							@EMPRESA AS Empresa,
							P.No_Pedido,
							P.Cve_Prenda,
							P.DescripcionPrenda,
							P.LugarDeEntrega, 
							P.NombreLugarDeEntrega, 
							P.Prioridad,
							P.Talla,
							P.SaldoLiberadoAFacturar,
							P.No_OP,
							R.NO_FACTURA,
							RP.PARTIDA,
							'AUTORIZADA' AS FacturaEstatus
						FROM 
							#PEDIDO P,
							#FACTURAS R,
							#FACTURAS_PARTIDAS RP
						WHERE
							P.SaldoLiberadoAFacturar > 0
						AND R.LUGARDEENTREGA = P.LugarDeEntrega
						AND RP.NO_FACTURA = R.NO_FACTURA
						AND RP.CVE_PRENDA = P.Cve_Prenda
						ORDER BY
							LugarDeEntrega,
							NombreLugarDeEntrega,
							Cve_Prenda;

						INSERT INTO FACTURA
						(
							Empresa,
							NO_FACTURA,
							Partida,
							FechaHoraFACTURA,
							Estatus,
							Cve_Cliente,
							Cliente_Nombre,
							ClienteRFC,
							ClienteCalle,
							ClienteNoExterior,
							ClienteNoInterior,
							ClienteColonia,
							ClienteMunicipio,
							ClienteCP,
							ClienteCiudad,
							ClienteEstado,
							ClienteTelefono,
							ClienteFax,
							ClienteEmail,
							ClienteContacto,
							ClienteTelContacto,
							RegimenFiscalReceptor,
							MetodoPago,
							FormaPago,
							CuentaPago,
							BancoPago,
							UsoCFDI,
							CveProdServ,
							CveUnidadMedida,
							UnidadMedida,
							Cve_PedCliente,
							Cve_Proveedor,
							Orden_Surtimiento,
							Contrato_Cliente,
							No_Pedido,
							Num_Folio,
							LugarDeEntrega,
							NombreLugarDeEntrega,
							LugarDeEntregaCalle,
							LugarDeEntregaNoExterior,
							LugarDeEntregaNoInterior,
							LugarDeEntregaColonia,
							LugarDeEntregaMunicipio,
							LugarDeEntregaCP,
							LugarDeEntregaCiudad,
							LugarDeEntregaEstado,
							LugarDeEntregaTelefono,
							LugarDeEntregaFax,
							LugarDeEntregaEmail,
							LugarDeEntregaContacto,
							LugarDeEntregaTelContacto,
							LugarDeEntregaAtencion,
							LugarDeEntregaTelAtencion,
							CondicionesPago,
							PorcentajeIVA,
							CveArticuloCliente,
							Cantidad,
							Descripcion,
							Precio,
							PartidaSubtotal,
							PartidaIVA,
							PartidaTotal,
							Layout,
							USUARIO,
							FECHAHORA,
							COMPUTADORA
						)
						SELECT
							@EMPRESA AS Empresa,
							R.NO_FACTURA,
							RP.PARTIDA,
							GETDATE() AS FechaHoraFACTURA,
							'AUTORIZADA' AS Estatus,
							P.Cve_Cliente,
							P.Nom_Cliente,
							C.RFC,
							C.Calle,
							C.NoExterior,
							C.NoInterior,
							C.Colonia,
							C.Municipio,
							C.CP,
							C.Ciudad,
							C.Estado,
							C.Telefono,
							C.Fax,
							C.Email,
							C.Contacto,
							C.TelContacto,
							P.RegimenFiscalReceptor,
							P.MetodoPago,
							P.FormaPago,
							P.CuentaPago,
							P.BancoPago,
							P.UsoCFDI,
							DR.CveProdServ,
							DR.CveUnidadMedida,
							DR.UnidadMedida,
							FA.Cve_PedCliente,
							FA.Cve_Proveedor,
							FA.Orden_Surtimiento,
							FA.Contrato_Cliente,
							P.No_Pedido,
							P.Num_Folio,
							P.LugarDeEntrega, 
							P.NombreLugarDeEntrega,
							REM.Calle,
							REM.NoExterior,
							REM.NoInterior,
							REM.Colonia,
							REM.Municipio,
							REM.CP,
							REM.Ciudad,
							REM.Estado,
							REM.Telefono,
							REM.Fax,
							REM.Email,
							REM.Contacto,
							REM.TelContacto,
							REM.Atencion,
							REM.TelAtencion,
							P.CondicionesPago AS Condiciones_Pago,
							P.PorcentajeIVA,
							DR.CveArticuloCliente,
							SUM(P.SaldoLiberadoAFacturar) AS Cantidad,
							DR.DescripcionPartida,
							DR.PrecioUnitario,
							SUM(P.SaldoLiberadoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
							(SUM(P.SaldoLiberadoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
							(SUM(P.SaldoLiberadoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
							0 AS Layout,
							@USUARIO,
							GETDATE() AS FECHAHORA,
							@COMPUTADORA
						FROM 
							#PEDIDO P,
							#FACTURAS R,
							#FACTURAS_PARTIDAS RP,
							CLIENTES C,
							FOLIOS_ADMINISTRACION FA,
							REMISIONADO REM,
							@DESCRIPCION_FACTURA DR
						WHERE
							P.SaldoLiberadoAFacturar > 0
						AND R.LUGARDEENTREGA = P.LugarDeEntrega
						AND RP.NO_FACTURA = R.NO_FACTURA
						AND RP.CVE_PRENDA = P.Cve_Prenda
						AND C.Cve_Cliente = P.Cve_Cliente
						AND FA.Num_Folio = P.Num_Folio
						AND REM.Cve_Remisionado = P.LugarDeEntrega
						AND DR.No_Pedido = P.No_Pedido
						AND DR.Cve_Prenda = P.Cve_Prenda
						AND DR.LugarDeEntrega = P.LugarDeEntrega
						GROUP BY
							R.NO_FACTURA,
							RP.PARTIDA,
							P.Cve_Cliente,
							P.Nom_Cliente,
							C.RFC,
							C.Calle,
							C.NoExterior,
							C.NoInterior,
							C.Colonia,
							C.Municipio,
							C.CP,
							C.Ciudad,
							C.Estado,
							C.Telefono,
							C.Fax,
							C.Email,
							C.Contacto,
							C.TelContacto,
							P.RegimenFiscalReceptor,
							P.MetodoPago,
							P.FormaPago,
							P.CuentaPago,
							P.BancoPago,
							P.UsoCFDI,
							DR.CveProdServ,
							DR.CveUnidadMedida,
							DR.UnidadMedida,
							FA.Cve_PedCliente,
							FA.Cve_Proveedor,
							FA.Orden_Surtimiento,
							FA.Contrato_Cliente,
							P.No_Pedido,
							P.Num_Folio,
							P.LugarDeEntrega, 
							P.NombreLugarDeEntrega,
							REM.Calle,
							REM.NoExterior,
							REM.NoInterior,
							REM.Colonia,
							REM.Municipio,
							REM.CP,
							REM.Ciudad,
							REM.Estado,
							REM.Telefono,
							REM.Fax,
							REM.Email,
							REM.Contacto,
							REM.TelContacto,
							REM.Atencion,
							REM.TelAtencion,
							P.CondicionesPago,
							P.PorcentajeIVA,
							DR.CveArticuloCliente,
							DR.DescripcionPartida,
							DR.PrecioUnitario
						ORDER BY
							R.NO_FACTURA,
							RP.Partida

						--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
						UPDATE
							FACTURA
						SET
							FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
							FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
							FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
							ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
						FROM
							#FACTURAS R1
						WHERE
							FACTURA.Empresa = @EMPRESA
						AND FACTURA.NO_FACTURA = R1.NO_FACTURA

						SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA

					END
					IF @LUGAR_ENTREGA = 1 --FACTURAR ROPA DISPONIBLE POR LUGAR DE ENTREGA
					BEGIN
						SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
						--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

						DELETE #FACTURAS
			
						INSERT INTO #FACTURAS
						(
							NO_FACTURA,
							LUGARDEENTREGA
						)
						SELECT
							(@NO_FACTURA + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
							LugarDeEntrega
						FROM
							#PEDIDO
						WHERE
							SaldoLiberadoAFacturar > 0
						GROUP BY
							LugarDeEntrega

						DELETE #FACTURAS_PARTIDAS

						INSERT INTO #FACTURAS_PARTIDAS
						(
							NO_FACTURA,
							CVE_PRENDA,
							PARTIDA
						)
						SELECT
							R.NO_FACTURA,
							P.Cve_Prenda,
							(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
						FROM 
							#PEDIDO P,
							#FACTURAS R
						WHERE
							P.SaldoLiberadoAFacturar > 0
						AND R.LUGARDEENTREGA = P.LugarDeEntrega
						GROUP BY
							R.NO_FACTURA,
							P.Cve_Prenda
						ORDER BY
							R.NO_FACTURA,
							P.Cve_Prenda


						INSERT INTO PEDIDO_INTERNO_FACTURA
						(
							Empresa,
							No_Pedido,
							Cve_Prenda,
							DescripcionPrenda,
							LugarDeEntrega,
							NombreLugarDeEntrega,
							Prioridad,
							Talla,
							Cantidad,
							No_OP,
							NO_FACTURA,
							FacturaPartida,
							FacturaEstatus
						)
						SELECT
							@EMPRESA AS Empresa,
							P.No_Pedido,
							P.Cve_Prenda,
							P.DescripcionPrenda,
							P.LugarDeEntrega, 
							P.NombreLugarDeEntrega, 
							P.Prioridad,
							P.Talla,
							P.SaldoLiberadoAFacturar,
							P.No_OP,
							R.NO_FACTURA,
							RP.PARTIDA,
							'AUTORIZADA' AS FacturaEstatus
						FROM 
							#PEDIDO P,
							#FACTURAS R,
							#FACTURAS_PARTIDAS RP
						WHERE
							P.SaldoLiberadoAFacturar > 0
						AND R.LUGARDEENTREGA = P.LugarDeEntrega
						AND RP.NO_FACTURA = R.NO_FACTURA
						AND RP.CVE_PRENDA = P.Cve_Prenda
						ORDER BY
							LugarDeEntrega,
							NombreLugarDeEntrega,
							Cve_Prenda;

						INSERT INTO FACTURA
						(
							Empresa,
							NO_FACTURA,
							Partida,
							FechaHoraFACTURA,
							Estatus,
							Cve_Cliente,
							Cliente_Nombre,
							ClienteRFC,
							ClienteCalle,
							ClienteNoExterior,
							ClienteNoInterior,
							ClienteColonia,
							ClienteMunicipio,
							ClienteCP,
							ClienteCiudad,
							ClienteEstado,
							ClienteTelefono,
							ClienteFax,
							ClienteEmail,
							ClienteContacto,
							ClienteTelContacto,
							RegimenFiscalReceptor,
							MetodoPago,
							FormaPago,
							CuentaPago,
							BancoPago,
							UsoCFDI,
							CveProdServ,
							CveUnidadMedida,
							UnidadMedida,
							Cve_PedCliente,
							Cve_Proveedor,
							Orden_Surtimiento,
							Contrato_Cliente,
							No_Pedido,
							Num_Folio,
							LugarDeEntrega,
							NombreLugarDeEntrega,
							LugarDeEntregaCalle,
							LugarDeEntregaNoExterior,
							LugarDeEntregaNoInterior,
							LugarDeEntregaColonia,
							LugarDeEntregaMunicipio,
							LugarDeEntregaCP,
							LugarDeEntregaCiudad,
							LugarDeEntregaEstado,
							LugarDeEntregaTelefono,
							LugarDeEntregaFax,
							LugarDeEntregaEmail,
							LugarDeEntregaContacto,
							LugarDeEntregaTelContacto,
							LugarDeEntregaAtencion,
							LugarDeEntregaTelAtencion,
							CondicionesPago,
							PorcentajeIVA,
							CveArticuloCliente,
							Cantidad,
							Descripcion,
							Precio,
							PartidaSubtotal,
							PartidaIVA,
							PartidaTotal,
							Layout,
							USUARIO,
							FECHAHORA,
							COMPUTADORA
						)
						SELECT
							@EMPRESA AS Empresa,
							R.NO_FACTURA,
							RP.PARTIDA,
							GETDATE() AS FechaHoraFACTURA,
							'AUTORIZADA' AS Estatus,
							P.Cve_Cliente,
							P.Nom_Cliente,
							C.RFC,
							C.Calle,
							C.NoExterior,
							C.NoInterior,
							C.Colonia,
							C.Municipio,
							C.CP,
							C.Ciudad,
							C.Estado,
							C.Telefono,
							C.Fax,
							C.Email,
							C.Contacto,
							C.TelContacto,
							P.RegimenFiscalReceptor,
							P.MetodoPago,
							P.FormaPago,
							P.CuentaPago,
							P.BancoPago,
							P.UsoCFDI,
							DR.CveProdServ,
							DR.CveUnidadMedida,
							DR.UnidadMedida,
							FA.Cve_PedCliente,
							FA.Cve_Proveedor,
							FA.Orden_Surtimiento,
							FA.Contrato_Cliente,
							P.No_Pedido,
							P.Num_Folio,
							P.LugarDeEntrega, 
							P.NombreLugarDeEntrega,
							REM.Calle,
							REM.NoExterior,
							REM.NoInterior,
							REM.Colonia,
							REM.Municipio,
							REM.CP,
							REM.Ciudad,
							REM.Estado,
							REM.Telefono,
							REM.Fax,
							REM.Email,
							REM.Contacto,
							REM.TelContacto,
							REM.Atencion,
							REM.TelAtencion,
							P.CondicionesPago AS Condiciones_Pago,
							P.PorcentajeIVA,
							DR.CveArticuloCliente,
							SUM(P.SaldoLiberadoAFacturar) AS Cantidad,
							DR.DescripcionPartida,
							DR.PrecioUnitario,
							SUM(P.SaldoLiberadoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
							(SUM(P.SaldoLiberadoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
							(SUM(P.SaldoLiberadoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
							0 AS Layout,
							@USUARIO,
							GETDATE() AS FECHAHORA,
							@COMPUTADORA
						FROM 
							#PEDIDO P,
							#FACTURAS R,
							#FACTURAS_PARTIDAS RP,
							CLIENTES C,
							FOLIOS_ADMINISTRACION FA,
							REMISIONADO REM,
							@DESCRIPCION_FACTURA DR
						WHERE
							P.SaldoLiberadoAFacturar > 0
						AND R.LUGARDEENTREGA = P.LugarDeEntrega
						AND RP.NO_FACTURA = R.NO_FACTURA
						AND RP.CVE_PRENDA = P.Cve_Prenda
						AND C.Cve_Cliente = P.Cve_Cliente
						AND FA.Num_Folio = P.Num_Folio
						AND REM.Cve_Remisionado = P.LugarDeEntrega
						AND DR.No_Pedido = P.No_Pedido
						AND DR.Cve_Prenda = P.Cve_Prenda
						AND DR.LugarDeEntrega = P.LugarDeEntrega
						GROUP BY
							R.NO_FACTURA,
							RP.PARTIDA,
							P.Cve_Cliente,
							P.Nom_Cliente,
							C.RFC,
							C.Calle,
							C.NoExterior,
							C.NoInterior,
							C.Colonia,
							C.Municipio,
							C.CP,
							C.Ciudad,
							C.Estado,
							C.Telefono,
							C.Fax,
							C.Email,
							C.Contacto,
							C.TelContacto,
							P.RegimenFiscalReceptor,
							P.MetodoPago,
							P.FormaPago,
							P.CuentaPago,
							P.BancoPago,
							P.UsoCFDI,
							DR.CveProdServ,
							DR.CveUnidadMedida,
							DR.UnidadMedida,
							FA.Cve_PedCliente,
							FA.Cve_Proveedor,
							FA.Orden_Surtimiento,
							FA.Contrato_Cliente,
							P.No_Pedido,
							P.Num_Folio,
							P.LugarDeEntrega, 
							P.NombreLugarDeEntrega,
							REM.Calle,
							REM.NoExterior,
							REM.NoInterior,
							REM.Colonia,
							REM.Municipio,
							REM.CP,
							REM.Ciudad,
							REM.Estado,
							REM.Telefono,
							REM.Fax,
							REM.Email,
							REM.Contacto,
							REM.TelContacto,
							REM.Atencion,
							REM.TelAtencion,
							P.CondicionesPago,
							P.PorcentajeIVA,
							DR.CveArticuloCliente,
							DR.DescripcionPartida,
							DR.PrecioUnitario
						ORDER BY
							R.NO_FACTURA,
							RP.Partida


						--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
						UPDATE
							FACTURA
						SET
							FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
							FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
							FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
							ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
						FROM
							#FACTURAS R1
						WHERE
							FACTURA.Empresa = @EMPRESA
						AND FACTURA.NO_FACTURA = R1.NO_FACTURA

						SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA
					END
				END
				ELSE
				BEGIN
					---AQUÍ SE ENTRA CUANDO SE QUIERE FACTURAR LAS CANTIDADES MANUALMENTE
					IF @PARTIDA = 1
					BEGIN

						IF @PARTIDATODASLASTALLAS = 1
						BEGIN
							DELETE #DESCRIPCION_FACTURA
					
							INSERT INTO #DESCRIPCION_FACTURA
							(
								No_Pedido,
								LugarDeEntrega,
								Cve_Prenda,
								DescripcionPartida,
								PrecioUnitario,
								CveArticuloCliente,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Talla,
								Cantidad
							)
							SELECT
								No_Pedido,
								LugarDeEntrega,
								Cve_Prenda,
								DescripcionPartida,
								PrecioUnitario,
								CveArticuloCliente,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Talla,
								Cantidad
							FROM
								@DESCRIPCION_FACTURA

							DELETE #PEDIDO

							INSERT INTO #PEDIDO
							(
								No_Pedido,
								Num_Folio,
								No_OP,
								Cve_Cliente,
								Nom_Cliente,
								Cve_Prenda,
								DescripcionPrenda,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								FechaVencimiento,
								Prioridad,
								MotivoPrioridad,
								Partida,
								Talla,
								Cantidad,
								PorcentajeIVA,
								PrecioUnitario,
								ObservacionesPartida,
								CantidadFacturada,
								SaldoAFacturar,
								CantidadLiberadaOP,
								SaldoLiberadoAFacturar,
								RegimenFiscalReceptor,
								MetodoPago,
								FormaPago,
								CuentaPago,
								BancoPago,
								UsoCFDI,
								CondicionesPago
							)
							SELECT
								PI.No_Pedido,
								PI.Num_Folio,
								PIT.No_OP,
								PI.Cve_Cliente,
								PI.Nom_Cliente,
								PIT.Cve_Prenda,
								PIT.DescripcionPrenda,
								PIT.LugarDeEntrega,
								PIT.NombreLugarDeEntrega,
								PIT.FechaVencimiento,
								PIT.Prioridad,
								PIT.MotivoPrioridad,
								TG.Partida,
								PIT.Talla,
								DR.Cantidad,
								PI.PorcentajeIVA,
								PIT.PrecioUnitario,
								PIT.ObservacionesPartidaFacturacion,
								(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
								DR.Cantidad-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
								(SELECT ISNULL(SUM(OPA.Cantidad),0) FROM OP_AVANCEPROCESOS OPA WHERE OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND OPA.Talla = PIT.Talla AND OPA.Nivel1 = 2 AND OPA.Nivel2 = 40 AND OPA.Nivel3 = 0),
								(SELECT ISNULL(SUM(OPA.Cantidad),0) FROM OP_AVANCEPROCESOS OPA WHERE OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND OPA.Talla = PIT.Talla AND OPA.Nivel1 = 2 AND OPA.Nivel2 = 40 AND OPA.Nivel3 = 0)-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
								PI.RegimenFiscal,
								PI.MetodoPago,
								PI.FormaPago,
								PI.CuentaPago,
								PI.BancoPago,
								PI.UsoCFDI,
								CONVERT(NVARCHAR,PI.CondicionesPagoDias) + ' DIAS ' + PI.CondicionesPagoTipoDias
							FROM 
								PEDIDO_INTERNO PI,
								PEDIDO_INTERNO_TALLAS PIT,
								TALLAS_GENERALES TG,
								#DESCRIPCION_FACTURA DR
							WHERE 
								PI.Empresa = @EMPRESA
							AND PI.No_Pedido = @NO_PEDIDO
							AND PIT.Empresa = PI.Empresa
							AND PIT.No_Pedido = PI.No_Pedido
							AND TG.Talla = PIT.Talla
							AND DR.No_Pedido = PI.No_Pedido
							AND DR.LugarDeEntrega = PIT.LugarDeEntrega
							AND DR.Cve_Prenda = PIT.Cve_Prenda
							AND DR.Talla = PIT.Talla
							ORDER BY
								PI.No_Pedido,
								PIT.Cve_Prenda,
								PIT.LugarDeEntrega,
								PIT.Prioridad,
								TG.Partida

							SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
							--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

							DELETE #FACTURAS
			
							INSERT INTO #FACTURAS
							(
								NO_FACTURA,
								LUGARDEENTREGA,
								CVE_PRENDA
							)
							SELECT
								(@NO_FACTURA + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
								LugarDeEntrega,
								Cve_Prenda
							FROM
								#PEDIDO
							WHERE
								SaldoAFacturar > 0
							GROUP BY
								LugarDeEntrega,
								Cve_Prenda

							DELETE #FACTURAS_PARTIDAS

							INSERT INTO #FACTURAS_PARTIDAS
							(
								NO_FACTURA,
								CVE_PRENDA,
								PARTIDA
							)
							SELECT
								R.NO_FACTURA,
								P.Cve_Prenda,
								(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
							FROM 
								#PEDIDO P,
								#FACTURAS R
							WHERE
								P.SaldoAFacturar > 0
							AND R.LUGARDEENTREGA = P.LugarDeEntrega
							AND R.CVE_PRENDA = P.Cve_Prenda
							GROUP BY
								R.NO_FACTURA,
								P.Cve_Prenda
							ORDER BY
								R.NO_FACTURA,
								P.Cve_Prenda

							INSERT INTO PEDIDO_INTERNO_FACTURA
							(
								Empresa,
								No_Pedido,
								Cve_Prenda,
								DescripcionPrenda,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								Prioridad,
								Talla,
								Cantidad,
								No_OP,
								NO_FACTURA,
								FacturaPartida,
								FacturaEstatus
							)
							SELECT
								@EMPRESA AS Empresa,
								P.No_Pedido,
								P.Cve_Prenda,
								P.DescripcionPrenda,
								P.LugarDeEntrega, 
								P.NombreLugarDeEntrega, 
								P.Prioridad,
								P.Talla,
								P.SaldoAFacturar,
								P.No_OP,
								R.NO_FACTURA,
								RP.PARTIDA,
								'AUTORIZADA' AS FacturaEstatus
							FROM 
								#PEDIDO P,
								#FACTURAS R,
								#FACTURAS_PARTIDAS RP
							WHERE
								P.SaldoAFacturar > 0
							AND R.LUGARDEENTREGA = P.LugarDeEntrega
							AND RP.NO_FACTURA = R.NO_FACTURA
							AND RP.CVE_PRENDA = P.Cve_Prenda
							ORDER BY
								LugarDeEntrega,
								NombreLugarDeEntrega,
								Cve_Prenda;

							INSERT INTO FACTURA
							(
								Empresa,
								NO_FACTURA,
								Partida,
								FechaHoraFACTURA,
								Estatus,
								Cve_Cliente,
								Cliente_Nombre,
								ClienteRFC,
								ClienteCalle,
								ClienteNoExterior,
								ClienteNoInterior,
								ClienteColonia,
								ClienteMunicipio,
								ClienteCP,
								ClienteCiudad,
								ClienteEstado,
								ClienteTelefono,
								ClienteFax,
								ClienteEmail,
								ClienteContacto,
								ClienteTelContacto,
								RegimenFiscalReceptor,
								MetodoPago,
								FormaPago,
								CuentaPago,
								BancoPago,
								UsoCFDI,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Cve_PedCliente,
								Cve_Proveedor,
								Orden_Surtimiento,
								Contrato_Cliente,
								No_Pedido,
								Num_Folio,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								LugarDeEntregaCalle,
								LugarDeEntregaNoExterior,
								LugarDeEntregaNoInterior,
								LugarDeEntregaColonia,
								LugarDeEntregaMunicipio,
								LugarDeEntregaCP,
								LugarDeEntregaCiudad,
								LugarDeEntregaEstado,
								LugarDeEntregaTelefono,
								LugarDeEntregaFax,
								LugarDeEntregaEmail,
								LugarDeEntregaContacto,
								LugarDeEntregaTelContacto,
								LugarDeEntregaAtencion,
								LugarDeEntregaTelAtencion,
								CondicionesPago,
								PorcentajeIVA,
								CveArticuloCliente,
								Cantidad,
								Descripcion,
								Precio,
								PartidaSubtotal,
								PartidaIVA,
								PartidaTotal,
								Layout,
								USUARIO,
								FECHAHORA,
								COMPUTADORA
							)
							SELECT
								@EMPRESA AS Empresa,
								R.NO_FACTURA,
								RP.PARTIDA,
								GETDATE() AS FechaHoraFACTURA,
								'AUTORIZADA' AS Estatus,
								P.Cve_Cliente,
								P.Nom_Cliente,
								C.RFC,
								C.Calle,
								C.NoExterior,
								C.NoInterior,
								C.Colonia,
								C.Municipio,
								C.CP,
								C.Ciudad,
								C.Estado,
								C.Telefono,
								C.Fax,
								C.Email,
								C.Contacto,
								C.TelContacto,
								P.RegimenFiscalReceptor,
								P.MetodoPago,
								P.FormaPago,
								P.CuentaPago,
								P.BancoPago,
								P.UsoCFDI,
								DR.CveProdServ,
								DR.CveUnidadMedida,
								DR.UnidadMedida,
								FA.Cve_PedCliente,
								FA.Cve_Proveedor,
								FA.Orden_Surtimiento,
								FA.Contrato_Cliente,
								P.No_Pedido,
								P.Num_Folio,
								P.LugarDeEntrega, 
								P.NombreLugarDeEntrega,
								REM.Calle,
								REM.NoExterior,
								REM.NoInterior,
								REM.Colonia,
								REM.Municipio,
								REM.CP,
								REM.Ciudad,
								REM.Estado,
								REM.Telefono,
								REM.Fax,
								REM.Email,
								REM.Contacto,
								REM.TelContacto,
								REM.Atencion,
								REM.TelAtencion,
								P.CondicionesPago AS Condiciones_Pago,
								P.PorcentajeIVA,
								DR.CveArticuloCliente,
								SUM(P.SaldoAFacturar) AS Cantidad,
								DR.DescripcionPartida,
								DR.PrecioUnitario,
								SUM(P.SaldoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
								(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
								(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
								0 AS Layout,
								@USUARIO,
								GETDATE() AS FECHAHORA,
								@COMPUTADORA
							FROM 
								#PEDIDO P,
								#FACTURAS R,
								#FACTURAS_PARTIDAS RP,
								CLIENTES C,
								FOLIOS_ADMINISTRACION FA,
								REMISIONADO REM,
								#DESCRIPCION_FACTURA DR
							WHERE
								P.SaldoAFacturar > 0
							AND R.LUGARDEENTREGA = P.LugarDeEntrega
							AND RP.NO_FACTURA = R.NO_FACTURA
							AND RP.CVE_PRENDA = P.Cve_Prenda
							AND C.Cve_Cliente = P.Cve_Cliente
							AND FA.Num_Folio = P.Num_Folio
							AND REM.Cve_Remisionado = P.LugarDeEntrega
							AND DR.No_Pedido = P.No_Pedido
							AND DR.Cve_Prenda = P.Cve_Prenda
							AND DR.LugarDeEntrega = P.LugarDeEntrega
							AND DR.Talla = P.Talla
							GROUP BY
								R.NO_FACTURA,
								RP.PARTIDA,
								P.Cve_Cliente,
								P.Nom_Cliente,
								C.RFC,
								C.Calle,
								C.NoExterior,
								C.NoInterior,
								C.Colonia,
								C.Municipio,
								C.CP,
								C.Ciudad,
								C.Estado,
								C.Telefono,
								C.Fax,
								C.Email,
								C.Contacto,
								C.TelContacto,
								P.RegimenFiscalReceptor,
								P.MetodoPago,
								P.FormaPago,
								P.CuentaPago,
								P.BancoPago,
								P.UsoCFDI,
								DR.CveProdServ,
								DR.CveUnidadMedida,
								DR.UnidadMedida,
								FA.Cve_PedCliente,
								FA.Cve_Proveedor,
								FA.Orden_Surtimiento,
								FA.Contrato_Cliente,
								P.No_Pedido,
								P.Num_Folio,
								P.LugarDeEntrega, 
								P.NombreLugarDeEntrega,
								REM.Calle,
								REM.NoExterior,
								REM.NoInterior,
								REM.Colonia,
								REM.Municipio,
								REM.CP,
								REM.Ciudad,
								REM.Estado,
								REM.Telefono,
								REM.Fax,
								REM.Email,
								REM.Contacto,
								REM.TelContacto,
								REM.Atencion,
								REM.TelAtencion,
								P.CondicionesPago,
								P.PorcentajeIVA,
								DR.CveArticuloCliente,
								DR.DescripcionPartida,
								DR.PrecioUnitario
							ORDER BY
								R.NO_FACTURA,
								RP.Partida

							--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
							UPDATE
								FACTURA
							SET
								FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
								FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
								FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
								ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
							FROM
								#FACTURAS R1
							WHERE
								FACTURA.Empresa = @EMPRESA
							AND FACTURA.NO_FACTURA = R1.NO_FACTURA

							SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA
						END
						IF @PARTIDAPORTALLA = 1
						BEGIN

							INSERT INTO #DESCRIPCIONFACTURA
							(
								CveArticuloCliente,
								PartidaPedido,
								TallaAFacturar,
								CantidadAFacturar,
								PrecioUnitario,
								DescripcionFactura,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida
							)
							SELECT
								CveArticuloCliente,
								PartidaPedido,
								Talla,
								Cantidad,
								PrecioUnitario,
								DescripcionPartida,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida
							FROM
								@DESCRIPCION_FACTURA

							SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA))+1 FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'

							INSERT INTO FACTURA
							(
								Empresa,
								No_Factura,
								Partida,
								FechaHoraFactura,
								Estatus,
								Cve_Cliente,
								Cliente_Nombre,
								ClienteRFC,
								ClienteCalle,
								ClienteNoExterior,
								ClienteNoInterior,
								ClienteColonia,
								ClienteMunicipio,
								ClienteCP,
								ClienteCiudad,
								ClienteEstado,
								ClienteTelefono,
								ClienteFax,
								ClienteEmail,
								ClienteContacto,
								ClienteTelContacto,
								RegimenFiscalReceptor,
								MetodoPago,
								FormaPago,
								CuentaPago,
								BancoPago,
								UsoCFDI,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Cve_PedCliente,
								Cve_Proveedor,
								Orden_Surtimiento,
								Contrato_Cliente,
								No_Pedido,
								Num_Folio,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								LugarDeEntregaCalle,
								LugarDeEntregaNoExterior,
								LugarDeEntregaNoInterior,
								LugarDeEntregaColonia,
								LugarDeEntregaMunicipio,
								LugarDeEntregaCP,
								LugarDeEntregaCiudad,
								LugarDeEntregaEstado,
								LugarDeEntregaTelefono,
								LugarDeEntregaFax,
								LugarDeEntregaEmail,
								LugarDeEntregaContacto,
								LugarDeEntregaTelContacto,
								LugarDeEntregaAtencion,
								LugarDeEntregaTelAtencion,
								CondicionesPago,
								PorcentajeIVA,
								CveArticuloCliente,
								Cantidad,
								Descripcion,
								Precio,
								PartidaSubtotal,
								PartidaIVA,
								PartidaTotal,
								USUARIO,
								FECHAHORA,
								COMPUTADORA
							)
							SELECT
								@EMPRESA AS Empresa,
								@NO_FACTURA,
								ROW_NUMBER() OVER (ORDER BY CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT)) AS Row,
								GETDATE() AS FechaHoraFactura,
								'AUTORIZADA' AS Estatus,
								PI.Cve_Cliente,
								PI.Nom_Cliente,
								C.RFC,
								C.Calle,
								C.NoExterior,
								C.NoInterior,
								C.Colonia,
								C.Municipio,
								C.CP,
								C.Ciudad,
								C.Estado,
								C.Telefono,
								C.Fax,
								C.Email,
								C.Contacto,
								C.TelContacto,
								PI.RegimenFiscal,
								PI.MetodoPago,
								PI.FormaPago,
								PI.CuentaPago,
								PI.BancoPago,
								PI.UsoCFDI,
								DR.CveProdServ,
								DR.CveUnidadMedida,
								DR.UnidadMedida,
								FA.Cve_PedCliente,
								FA.Cve_Proveedor,
								FA.Orden_Surtimiento,
								FA.Contrato_Cliente,
								PI.No_Pedido,
								PI.Num_Folio,
								PIT.LugarDeEntrega, 
								PIT.NombreLugarDeEntrega,
								REM.Calle,
								REM.NoExterior,
								REM.NoInterior,
								REM.Colonia,
								REM.Municipio,
								REM.CP,
								REM.Ciudad,
								REM.Estado,
								REM.Telefono,
								REM.Fax,
								REM.Email,
								REM.Contacto,
								REM.TelContacto,
								REM.Atencion,
								REM.TelAtencion,
								CONVERT(NVARCHAR,PI.CondicionesPagoDias)+ ' DÍAS',
								PI.PorcentajeIVA,
								DR.CveArticuloCliente,
								DR.CantidadAFacturar AS Cantidad,
								DR.DescripcionFactura,
								DR.PrecioUnitario,
								DR.CantidadAFacturar * DR.PrecioUnitario AS PartidaSubtotal,
								(DR.CantidadAFacturar * DR.PrecioUnitario) * (PI.PorcentajeIVA/100) AS PartidaIVA,
								(DR.CantidadAFacturar * DR.PrecioUnitario) * (1+(PI.PorcentajeIVA/100)) AS PartidaTotal,
								@USUARIO,
								GETDATE() AS FECHAHORA,
								@COMPUTADORA
							FROM 
								PEDIDO_INTERNO PI,
								PEDIDO_INTERNO_TALLAS PIT,
								CLIENTES C,
								FOLIOS_ADMINISTRACION FA,
								REMISIONADO REM,
								#DESCRIPCIONFACTURA DR
							WHERE
								PI.Empresa = @EMPRESA
							AND PI.No_Pedido = @NO_PEDIDO
							AND PIT.Empresa = PI.Empresa
							AND PIT.No_Pedido = PI.No_Pedido
							AND PIT.Partida = DR.PartidaPedido
							AND PIT.Talla = DR.TallaAFacturar
							AND C.Cve_Cliente = PI.Cve_Cliente
							AND FA.Num_Folio = PI.Num_Folio
							AND REM.Cve_Remisionado = PIT.LugarDeEntrega
							ORDER BY 
								CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT);

							--ACTUALIZA EL IMPORTE TOTAL DE LAS REMISIONES Y LA CANTIDAD CON LETRA
							UPDATE
								FACTURA
							SET
								FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura),
								FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura),
								FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura),
								ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura))
							WHERE
								FACTURA.Empresa = @EMPRESA
							AND FACTURA.No_Factura = @NO_FACTURA

						
							INSERT INTO PEDIDO_INTERNO_FACTURA
							(
								Empresa,
								No_Pedido,
								Cve_Prenda,
								DescripcionPrenda,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								Prioridad,
								Talla,
								Cantidad,
								No_OP,
								NO_FACTURA,
								FacturaPartida,
								FacturaEstatus
							)
							SELECT
								@EMPRESA AS Empresa,
								PI.No_Pedido,
								PIT.Cve_Prenda,
								PIT.DescripcionPrenda,
								PIT.LugarDeEntrega,
								PIT.NombreLugarDeEntrega,
								PIT.Prioridad,
								DR.TallaAFacturar,
								DR.CantidadAFacturar,
								PIT.No_OP,
								@NO_FACTURA,
								ROW_NUMBER() OVER (ORDER BY CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT)) AS Row,
								'AUTORIZADA' AS Estatus
							FROM 
								PEDIDO_INTERNO PI,
								PEDIDO_INTERNO_TALLAS PIT,
								CLIENTES C,
								FOLIOS_ADMINISTRACION FA,
								REMISIONADO REM,
								#DESCRIPCIONFACTURA DR
							WHERE
								PI.Empresa = @EMPRESA
							AND PI.No_Pedido = @NO_PEDIDO
							AND PIT.Empresa = PI.Empresa
							AND PIT.No_Pedido = PI.No_Pedido
							AND PIT.Partida = DR.PartidaPedido
							AND PIT.Talla = DR.TallaAFacturar
							AND C.Cve_Cliente = PI.Cve_Cliente
							AND FA.Num_Folio = PI.Num_Folio
							AND REM.Cve_Remisionado = PIT.LugarDeEntrega
							ORDER BY 
								CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT);

							IF EXISTS(SELECT * FROM FACTURA WHERE No_Factura = @NO_FACTURA)
								SELECT @NO_FACTURA AS NO_FACTURA
						END
					END
					IF @LUGAR_ENTREGA = 1
					BEGIN
						IF @PARTIDATODASLASTALLAS = 1
						BEGIN
							DELETE #DESCRIPCION_FACTURA

							INSERT INTO #DESCRIPCION_FACTURA
							(
								No_Pedido,
								PartidaPedido,
								LugarDeEntrega,
								Cve_Prenda,
								DescripcionPartida,
								PrecioUnitario,
								CveArticuloCliente,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Talla,
								Cantidad
							)
							SELECT
								No_Pedido,
								PartidaPedido,
								LugarDeEntrega,
								Cve_Prenda,
								DescripcionPartida,
								PrecioUnitario,
								CveArticuloCliente,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Talla,
								Cantidad
							FROM
								@DESCRIPCION_FACTURA

							DELETE #PEDIDO
						
							INSERT INTO #PEDIDO
							(
								No_Pedido,
								PartidaPedido,
								Num_Folio,
								No_OP,
								Cve_Cliente,
								Nom_Cliente,
								Cve_Prenda,
								DescripcionPrenda,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								FechaVencimiento,
								Prioridad,
								MotivoPrioridad,
								Partida,
								Talla,
								Cantidad,
								PorcentajeIVA,
								PrecioUnitario,
								ObservacionesPartida,
								CantidadFacturada,
								SaldoAFacturar,
								CantidadLiberadaOP,
								SaldoLiberadoAFacturar,
								RegimenFiscalReceptor,
								MetodoPago,
								FormaPago,
								CuentaPago,
								BancoPago,
								UsoCFDI,
								CondicionesPago
							)
							SELECT
								PI.No_Pedido,
								PIT.Partida,
								PI.Num_Folio,
								PIT.No_OP,
								PI.Cve_Cliente,
								PI.Nom_Cliente,
								PIT.Cve_Prenda,
								PIT.DescripcionPrenda,
								PIT.LugarDeEntrega,
								PIT.NombreLugarDeEntrega,
								PIT.FechaVencimiento,
								PIT.Prioridad,
								PIT.MotivoPrioridad,
								TG.Partida,
								PIT.Talla,
								DR.Cantidad,
								PI.PorcentajeIVA,
								PIT.PrecioUnitario,
								PIT.ObservacionesPartidaFacturacion,
								(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
								CASE WHEN (PIT.CANTIDAD-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA')-DR.Cantidad) >= 0 
								THEN DR.Cantidad ELSE PIT.CANTIDAD-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA')-DR.Cantidad END, 
								(SELECT ISNULL(SUM(OPA.Cantidad),0) FROM OP_AVANCEPROCESOS OPA WHERE OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND OPA.Talla = PIT.Talla AND OPA.Nivel1 = 2 AND OPA.Nivel2 = 40 AND OPA.Nivel3 = 0),
								(SELECT ISNULL(SUM(OPA.Cantidad),0) FROM OP_AVANCEPROCESOS OPA WHERE OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND OPA.Talla = PIT.Talla AND OPA.Nivel1 = 2 AND OPA.Nivel2 = 40 AND OPA.Nivel3 = 0)-(SELECT ISNULL(SUM(PIR.Cantidad),0) FROM PEDIDO_INTERNO_FACTURA PIR WHERE PIR.Empresa = PIT.Empresa AND PIR.No_Pedido = PIT.No_Pedido AND PIR.Prioridad = PIT.Prioridad AND PIR.Cve_Prenda = PIT.Cve_Prenda AND PIR.LugarDeEntrega = PIT.LugarDeEntrega AND PIR.Talla = PIT.Talla AND PIR.FacturaEstatus <> 'CANCELADA'),
								PI.RegimenFiscal,
								PI.MetodoPago,
								PI.FormaPago,
								PI.CuentaPago,
								PI.BancoPago,
								PI.UsoCFDI,
								CONVERT(NVARCHAR,PI.CondicionesPagoDias) + ' DIAS ' + PI.CondicionesPagoTipoDias
							FROM 
								PEDIDO_INTERNO PI,
								PEDIDO_INTERNO_TALLAS PIT,
								TALLAS_GENERALES TG,
								#DESCRIPCION_FACTURA DR
							WHERE 
								PI.Empresa = @EMPRESA
							AND PI.No_Pedido = @NO_PEDIDO
							AND PIT.Empresa = PI.Empresa
							AND PIT.No_Pedido = PI.No_Pedido
							AND TG.Talla = PIT.Talla
							AND DR.No_Pedido = PI.No_Pedido
							AND DR.LugarDeEntrega = PIT.LugarDeEntrega
							AND DR.Cve_Prenda = PIT.Cve_Prenda
							AND DR.Talla = PIT.Talla
							AND DR.PartidaPedido = PIT.Partida
							ORDER BY
								PI.No_Pedido,
								PIT.Partida,
								PIT.Cve_Prenda,
								PIT.LugarDeEntrega,
								PIT.Prioridad,
								TG.Partida
						
							SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA)) FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'
							--SELECT @NO_FACTURA = ISNULL(MAX(NO_FACTURA),0) FROM FACTURA WHERE Empresa = @EMPRESA

							DELETE #FACTURAS
			
							INSERT INTO #FACTURAS
							(
								NO_FACTURA,
								LUGARDEENTREGA
							)
							SELECT
								(@NO_FACTURA + ROW_NUMBER() OVER (ORDER BY LUGARDEENTREGA)) AS NO_FACTURA,
								LugarDeEntrega
							FROM
								#PEDIDO
							WHERE
								SaldoAFacturar > 0
							GROUP BY
								LugarDeEntrega

							DELETE #FACTURAS_PARTIDAS

							INSERT INTO #FACTURAS_PARTIDAS
							(
								NO_FACTURA,
								PartidaPedido,
								CVE_PRENDA,
								PARTIDA
							)
							SELECT
								R.NO_FACTURA,
								P.PartidaPedido,
								P.Cve_Prenda,
								(0 + ROW_NUMBER() OVER (PARTITION BY R.NO_FACTURA ORDER BY P.CVE_PRENDA)) AS PARTIDA
							FROM 
								#PEDIDO P,
								#FACTURAS R
							WHERE
								P.SaldoAFacturar > 0
							AND R.LUGARDEENTREGA = P.LugarDeEntrega
							GROUP BY
								R.NO_FACTURA,
								P.PartidaPedido,
								P.Cve_Prenda
							ORDER BY
								R.NO_FACTURA,
								P.PartidaPedido,
								P.Cve_Prenda

							INSERT INTO PEDIDO_INTERNO_FACTURA
							(
								Empresa,
								No_Pedido,
								Cve_Prenda,
								DescripcionPrenda,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								Prioridad,
								Talla,
								Cantidad,
								No_OP,
								NO_FACTURA,
								FacturaPartida,
								FacturaEstatus
							)
							SELECT
								@EMPRESA AS Empresa,
								P.No_Pedido,
								P.Cve_Prenda,
								P.DescripcionPrenda,
								P.LugarDeEntrega, 
								P.NombreLugarDeEntrega, 
								P.Prioridad,
								P.Talla,
								P.SaldoAFacturar,
								P.No_OP,
								R.NO_FACTURA,
								RP.PARTIDA,
								'AUTORIZADA' AS FacturaEstatus
							FROM 
								#PEDIDO P,
								#FACTURAS R,
								#FACTURAS_PARTIDAS RP
							WHERE
								P.SaldoAFacturar >= 0
							AND R.LUGARDEENTREGA = P.LugarDeEntrega
							AND RP.NO_FACTURA = R.NO_FACTURA
							AND RP.CVE_PRENDA = P.Cve_Prenda
							AND P.PartidaPedido = RP.PartidaPedido
							ORDER BY
								LugarDeEntrega,
								NombreLugarDeEntrega,
								Cve_Prenda;

							INSERT INTO FACTURA
							(
								Empresa,
								NO_FACTURA,
								Partida,
								FechaHoraFACTURA,
								Estatus,
								Cve_Cliente,
								Cliente_Nombre,
								ClienteRFC,
								ClienteCalle,
								ClienteNoExterior,
								ClienteNoInterior,
								ClienteColonia,
								ClienteMunicipio,
								ClienteCP,
								ClienteCiudad,
								ClienteEstado,
								ClienteTelefono,
								ClienteFax,
								ClienteEmail,
								ClienteContacto,
								ClienteTelContacto,
								RegimenFiscalReceptor,
								MetodoPago,
								FormaPago,
								CuentaPago,
								BancoPago,
								UsoCFDI,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Cve_PedCliente,
								Cve_Proveedor,
								Orden_Surtimiento,
								Contrato_Cliente,
								No_Pedido,
								Num_Folio,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								LugarDeEntregaCalle,
								LugarDeEntregaNoExterior,
								LugarDeEntregaNoInterior,
								LugarDeEntregaColonia,
								LugarDeEntregaMunicipio,
								LugarDeEntregaCP,
								LugarDeEntregaCiudad,
								LugarDeEntregaEstado,
								LugarDeEntregaTelefono,
								LugarDeEntregaFax,
								LugarDeEntregaEmail,
								LugarDeEntregaContacto,
								LugarDeEntregaTelContacto,
								LugarDeEntregaAtencion,
								LugarDeEntregaTelAtencion,
								CondicionesPago,
								PorcentajeIVA,
								CveArticuloCliente,
								Cantidad,
								Descripcion,
								Precio,
								PartidaSubtotal,
								PartidaIVA,
								PartidaTotal,
								Layout,
								USUARIO,
								FECHAHORA,
								COMPUTADORA
							)
							SELECT
								@EMPRESA AS Empresa,
								R.NO_FACTURA,
								RP.PARTIDA,
								GETDATE() AS FechaHoraFACTURA,
								'AUTORIZADA' AS Estatus,
								P.Cve_Cliente,
								P.Nom_Cliente,
								C.RFC,
								C.Calle,
								C.NoExterior,
								C.NoInterior,
								C.Colonia,
								C.Municipio,
								C.CP,
								C.Ciudad,
								C.Estado,
								C.Telefono,
								C.Fax,
								C.Email,
								C.Contacto,
								C.TelContacto,
								P.RegimenFiscalReceptor,
								P.MetodoPago,
								P.FormaPago,
								P.CuentaPago,
								P.BancoPago,
								P.UsoCFDI,
								DR.CveProdServ,
								DR.CveUnidadMedida,
								DR.UnidadMedida,
								FA.Cve_PedCliente,
								FA.Cve_Proveedor,
								FA.Orden_Surtimiento,
								FA.Contrato_Cliente,
								P.No_Pedido,
								P.Num_Folio,
								P.LugarDeEntrega, 
								P.NombreLugarDeEntrega,
								REM.Calle,
								REM.NoExterior,
								REM.NoInterior,
								REM.Colonia,
								REM.Municipio,
								REM.CP,
								REM.Ciudad,
								REM.Estado,
								REM.Telefono,
								REM.Fax,
								REM.Email,
								REM.Contacto,
								REM.TelContacto,
								REM.Atencion,
								REM.TelAtencion,
								P.CondicionesPago AS Condiciones_Pago,
								P.PorcentajeIVA,
								DR.CveArticuloCliente,
								SUM(P.SaldoAFacturar) AS Cantidad,
								DR.DescripcionPartida,
								DR.PrecioUnitario,
								SUM(P.SaldoAFacturar) * DR.PrecioUnitario AS PartidaSubtotal,
								(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (P.PorcentajeIVA/100) AS PartidaIVA,
								(SUM(P.SaldoAFacturar) * DR.PrecioUnitario) * (1+(P.PorcentajeIVA/100)) AS PartidaTotal,
								0 AS Layout,
								@USUARIO,
								GETDATE() AS FECHAHORA,
								@COMPUTADORA
							FROM 
								#PEDIDO P,
								#FACTURAS R,
								#FACTURAS_PARTIDAS RP,
								CLIENTES C,
								FOLIOS_ADMINISTRACION FA,
								REMISIONADO REM,
								#DESCRIPCION_FACTURA DR
							WHERE
								P.SaldoAFacturar > 0
							AND R.LUGARDEENTREGA = P.LugarDeEntrega
							AND RP.NO_FACTURA = R.NO_FACTURA
							AND RP.CVE_PRENDA = P.Cve_Prenda
							AND C.Cve_Cliente = P.Cve_Cliente
							AND FA.Num_Folio = P.Num_Folio
							AND REM.Cve_Remisionado = P.LugarDeEntrega
							AND DR.No_Pedido = P.No_Pedido
							AND DR.Cve_Prenda = P.Cve_Prenda
							AND DR.LugarDeEntrega = P.LugarDeEntrega
							AND DR.Talla = P.Talla
							AND DR.PartidaPedido = P.PartidaPedido
							AND DR.PartidaPedido = RP.PartidaPedido
							GROUP BY
								R.NO_FACTURA,
								RP.PARTIDA,
								P.Cve_Cliente,
								P.Nom_Cliente,
								C.RFC,
								C.Calle,
								C.NoExterior,
								C.NoInterior,
								C.Colonia,
								C.Municipio,
								C.CP,
								C.Ciudad,
								C.Estado,
								C.Telefono,
								C.Fax,
								C.Email,
								C.Contacto,
								C.TelContacto,
								P.RegimenFiscalReceptor,
								P.MetodoPago,
								P.FormaPago,
								P.CuentaPago,
								P.BancoPago,
								P.UsoCFDI,
								DR.CveProdServ,
								DR.CveUnidadMedida,
								DR.UnidadMedida,
								FA.Cve_PedCliente,
								FA.Cve_Proveedor,
								FA.Orden_Surtimiento,
								FA.Contrato_Cliente,
								P.No_Pedido,
								P.Num_Folio,
								P.LugarDeEntrega, 
								P.NombreLugarDeEntrega,
								REM.Calle,
								REM.NoExterior,
								REM.NoInterior,
								REM.Colonia,
								REM.Municipio,
								REM.CP,
								REM.Ciudad,
								REM.Estado,
								REM.Telefono,
								REM.Fax,
								REM.Email,
								REM.Contacto,
								REM.TelContacto,
								REM.Atencion,
								REM.TelAtencion,
								P.CondicionesPago,
								P.PorcentajeIVA,
								DR.CveArticuloCliente,
								DR.DescripcionPartida,
								DR.PrecioUnitario
							ORDER BY
								R.NO_FACTURA,
								RP.Partida

							--ACTUALIZA EL IMPORTE TOTAL DE LAS FACTURAS Y LA CANTIDAD CON LETRA
							UPDATE
								FACTURA
							SET
								FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
								FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
								FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA),
								ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.NO_FACTURA = FACTURA.NO_FACTURA))
							FROM
								#FACTURAS R1
							WHERE
								FACTURA.Empresa = @EMPRESA
							AND FACTURA.NO_FACTURA = R1.NO_FACTURA

							SELECT NO_FACTURA FROM #FACTURAS GROUP BY NO_FACTURA
						END

						IF @PARTIDAPORTALLA = 1
						BEGIN

							INSERT INTO #DESCRIPCIONFACTURA
							(
								CveArticuloCliente,
								PartidaPedido,
								TallaAFacturar,
								CantidadAFacturar,
								PrecioUnitario,
								DescripcionFactura,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida
							)
							SELECT
								CveArticuloCliente,
								PartidaPedido,
								Talla,
								Cantidad,
								PrecioUnitario,
								DescripcionPartida,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida
							FROM
								@DESCRIPCION_FACTURA

							SELECT @NO_FACTURA = MAX(CONVERT(NUMERIC(18,0),FACTURA))+1 FROM COFIDI.dbo.FACTURA WHERE EMPRESA = '0000000001' AND TipoDocumento = '01'

							INSERT INTO FACTURA
							(
								Empresa,
								No_Factura,
								Partida,
								FechaHoraFactura,
								Estatus,
								Cve_Cliente,
								Cliente_Nombre,
								ClienteRFC,
								ClienteCalle,
								ClienteNoExterior,
								ClienteNoInterior,
								ClienteColonia,
								ClienteMunicipio,
								ClienteCP,
								ClienteCiudad,
								ClienteEstado,
								ClienteTelefono,
								ClienteFax,
								ClienteEmail,
								ClienteContacto,
								ClienteTelContacto,
								RegimenFiscalReceptor,
								MetodoPago,
								FormaPago,
								CuentaPago,
								BancoPago,
								UsoCFDI,
								CveProdServ,
								CveUnidadMedida,
								UnidadMedida,
								Cve_PedCliente,
								Cve_Proveedor,
								Orden_Surtimiento,
								Contrato_Cliente,
								No_Pedido,
								Num_Folio,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								LugarDeEntregaCalle,
								LugarDeEntregaNoExterior,
								LugarDeEntregaNoInterior,
								LugarDeEntregaColonia,
								LugarDeEntregaMunicipio,
								LugarDeEntregaCP,
								LugarDeEntregaCiudad,
								LugarDeEntregaEstado,
								LugarDeEntregaTelefono,
								LugarDeEntregaFax,
								LugarDeEntregaEmail,
								LugarDeEntregaContacto,
								LugarDeEntregaTelContacto,
								LugarDeEntregaAtencion,
								LugarDeEntregaTelAtencion,
								CondicionesPago,
								PorcentajeIVA,
								CveArticuloCliente,
								Cantidad,
								Descripcion,
								Precio,
								PartidaSubtotal,
								PartidaIVA,
								PartidaTotal,
								USUARIO,
								FECHAHORA,
								COMPUTADORA
							)
							SELECT
								@EMPRESA AS Empresa,
								@NO_FACTURA,
								ROW_NUMBER() OVER (ORDER BY CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT)) AS Row,
								GETDATE() AS FechaHoraFactura,
								'AUTORIZADA' AS Estatus,
								PI.Cve_Cliente,
								PI.Nom_Cliente,
								C.RFC,
								C.Calle,
								C.NoExterior,
								C.NoInterior,
								C.Colonia,
								C.Municipio,
								C.CP,
								C.Ciudad,
								C.Estado,
								C.Telefono,
								C.Fax,
								C.Email,
								C.Contacto,
								C.TelContacto,
								PI.RegimenFiscal,
								PI.MetodoPago,
								PI.FormaPago,
								PI.CuentaPago,
								PI.BancoPago,
								PI.UsoCFDI,
								DR.CveProdServ,
								DR.CveUnidadMedida,
								DR.UnidadMedida,
								FA.Cve_PedCliente,
								FA.Cve_Proveedor,
								FA.Orden_Surtimiento,
								FA.Contrato_Cliente,
								PI.No_Pedido,
								PI.Num_Folio,
								PIT.LugarDeEntrega, 
								PIT.NombreLugarDeEntrega,
								REM.Calle,
								REM.NoExterior,
								REM.NoInterior,
								REM.Colonia,
								REM.Municipio,
								REM.CP,
								REM.Ciudad,
								REM.Estado,
								REM.Telefono,
								REM.Fax,
								REM.Email,
								REM.Contacto,
								REM.TelContacto,
								REM.Atencion,
								REM.TelAtencion,
								CONVERT(NVARCHAR,PI.CondicionesPagoDias)+ ' DÍAS',
								PI.PorcentajeIVA,
								DR.CveArticuloCliente,
								DR.CantidadAFacturar AS Cantidad,
								DR.DescripcionFactura,
								DR.PrecioUnitario,
								DR.CantidadAFacturar * DR.PrecioUnitario AS PartidaSubtotal,
								(DR.CantidadAFacturar * DR.PrecioUnitario) * (PI.PorcentajeIVA/100) AS PartidaIVA,
								(DR.CantidadAFacturar * DR.PrecioUnitario) * (1+(PI.PorcentajeIVA/100)) AS PartidaTotal,
								@USUARIO,
								GETDATE() AS FECHAHORA,
								@COMPUTADORA
							FROM 
								PEDIDO_INTERNO PI,
								PEDIDO_INTERNO_TALLAS PIT,
								CLIENTES C,
								FOLIOS_ADMINISTRACION FA,
								REMISIONADO REM,
								#DESCRIPCIONFACTURA DR
							WHERE
								PI.Empresa = @EMPRESA
							AND PI.No_Pedido = @NO_PEDIDO
							AND PIT.Empresa = PI.Empresa
							AND PIT.No_Pedido = PI.No_Pedido
							AND PIT.Partida = DR.PartidaPedido
							AND PIT.Talla = DR.TallaAFacturar
							AND C.Cve_Cliente = PI.Cve_Cliente
							AND FA.Num_Folio = PI.Num_Folio
							AND REM.Cve_Remisionado = PIT.LugarDeEntrega
							ORDER BY 
								CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT);

							--ACTUALIZA EL IMPORTE TOTAL DE LAS REMISIONES Y LA CANTIDAD CON LETRA
							UPDATE
								FACTURA
							SET
								FacturaSubtotal = (SELECT ISNULL(SUM(R.PartidaSubtotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura),
								FacturaIVA = (SELECT ISNULL(SUM(R.PartidaIVA),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura),
								FacturaTotal = (SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura),
								ImporteEnLetra = dbo.CantidadConLetra((SELECT ISNULL(SUM(R.PartidaTotal),0) FROM FACTURA R WHERE R.Empresa = FACTURA.Empresa AND R.No_Factura = FACTURA.No_Factura))
							WHERE
								FACTURA.Empresa = @EMPRESA
							AND FACTURA.No_Factura = @NO_FACTURA

						
							INSERT INTO PEDIDO_INTERNO_FACTURA
							(
								Empresa,
								No_Pedido,
								Cve_Prenda,
								DescripcionPrenda,
								LugarDeEntrega,
								NombreLugarDeEntrega,
								Prioridad,
								Talla,
								Cantidad,
								No_OP,
								NO_FACTURA,
								FacturaPartida,
								FacturaEstatus
							)
							SELECT
								@EMPRESA AS Empresa,
								PI.No_Pedido,
								PIT.Cve_Prenda,
								PIT.DescripcionPrenda,
								PIT.LugarDeEntrega,
								PIT.NombreLugarDeEntrega,
								PIT.Prioridad,
								DR.TallaAFacturar,
								DR.CantidadAFacturar,
								PIT.No_OP,
								@NO_FACTURA,
								ROW_NUMBER() OVER (ORDER BY CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT)) AS Row,
								'AUTORIZADA' AS Estatus
							FROM 
								PEDIDO_INTERNO PI,
								PEDIDO_INTERNO_TALLAS PIT,
								CLIENTES C,
								FOLIOS_ADMINISTRACION FA,
								REMISIONADO REM,
								#DESCRIPCIONFACTURA DR
							WHERE
								PI.Empresa = @EMPRESA
							AND PI.No_Pedido = @NO_PEDIDO
							AND PIT.Empresa = PI.Empresa
							AND PIT.No_Pedido = PI.No_Pedido
							AND PIT.Partida = DR.PartidaPedido
							AND PIT.Talla = DR.TallaAFacturar
							AND C.Cve_Cliente = PI.Cve_Cliente
							AND FA.Num_Folio = PI.Num_Folio
							AND REM.Cve_Remisionado = PIT.LugarDeEntrega
							ORDER BY 
								CAST(SUBSTRING(CveArticuloCliente, PATINDEX('%[0-9]%', CveArticuloCliente), LEN(CveArticuloCliente)) AS INT);

							IF EXISTS(SELECT * FROM FACTURA WHERE No_Factura = @NO_FACTURA)
								SELECT @NO_FACTURA AS NO_FACTURA
						END
					END
				END
			END
		END

		DROP TABLE #TEMP
		DROP TABLE #PEDIDO
		DROP TABLE #FACTURAS
		DROP TABLE #FACTURAS_PARTIDAS
		DROP TABLE #DESCRIPCION_FACTURA
		DROP TABLE #DESCRIPCIONFACTURA
		
		
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

--EXEC CONSULTA_TALLAS_CANTIDADES_A_FACTURAR 1,7,0,0,NULL,0,0,1
GO

