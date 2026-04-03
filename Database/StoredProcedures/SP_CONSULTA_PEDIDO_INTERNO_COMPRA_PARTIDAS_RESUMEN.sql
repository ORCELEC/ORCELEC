USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_CONSULTA_PEDIDO_INTERNO_COMPRA_PARTIDAS_RESUMEN]    Script Date: 02/04/2026 07:14:31 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_CONSULTA_PEDIDO_INTERNO_COMPRA_PARTIDAS_RESUMEN]
--DECLARE
	@EMPRESA BIGINT,
	@NO_PEDIDO BIGINT
AS
BEGIN
--    SET @EMPRESA = 1
--    SET @NO_PEDIDO = 1839

    CREATE TABLE #TEMP
    (
        PARTIDA BIGINT,
        TALLA NVARCHAR(50)
    )

    INSERT INTO #TEMP
    (
        PARTIDA,
        TALLA
    )
    SELECT 
        TG.Partida,
        PIT.Talla
    FROM 
        PEDIDO_INTERNO PI
        JOIN PEDIDO_INTERNO_TALLAS PIT ON PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido
        JOIN TALLAS_GENERALES TG ON TG.Talla = PIT.Talla
    WHERE 
        PI.Empresa = @EMPRESA
        AND PI.No_Pedido = @NO_PEDIDO
    GROUP BY
        TG.Partida,
        PIT.Talla
    ORDER BY
        TG.Partida

    CREATE TABLE #PEDIDO_PARTIDAS
    (
		PartidaAcomodo int,
        NO_PEDIDO BIGINT,
        CVE_PRENDA NUMERIC(18,0),
        DESCRIPCIONPRENDA NVARCHAR(1000),
        FECHAVENCIMIENTO DATETIME,
        PARTIDA BIGINT,
        TALLA NVARCHAR(100),
        CANTIDAD NUMERIC(18,0),
        PRECIO NUMERIC(18,4),
		SUBTOTALPARTIDA NUMERIC(18,4),
		IVAPARTIDA NUMERIC(18,4),
		TOTALPARTIDA NUMERIC(18,4),
		SUBTOTALPEDIDO NUMERIC(18,4),
		IVAPEDIDO NUMERIC(18,4),
		TOTALPEDIDO NUMERIC(18,4)
    )

    INSERT INTO #PEDIDO_PARTIDAS
    (
		PartidaAcomodo,
        NO_PEDIDO,
        CVE_PRENDA,
        DESCRIPCIONPRENDA,
        FECHAVENCIMIENTO,
        PARTIDA,
        TALLA,
        CANTIDAD,
        PRECIO,
		SUBTOTALPARTIDA,
		IVAPARTIDA,
		TOTALPARTIDA
    )
    SELECT 
		(SELECT MIN(PIT1.Partida) FROM PEDIDO_INTERNO_TALLAS PIT1 WHERE PIT1.Empresa = @EMPRESA AND PIT1.No_Pedido = PI.NO_PEDIDO AND PIT1.Cve_Prenda = PIT.Cve_Prenda),
        PI.No_Pedido,
        PIT.Cve_Prenda,
        PIT.DescripcionPrenda,
        PIT.FechaVencimiento,
        TG.Partida,
        PIT.Talla,
        SUM(PIT.Cantidad-ISNULL(RIPT.CANTIDAD,0)),
        PIT.PrecioUnitario,
		SUM(PIT.Subtotal) AS SubtotalPartida,
		SUM(PIT.Iva) AS IvaPartida,
		SUM(PIT.Total) AS TotalPartida
    FROM 
        PEDIDO_INTERNO PI
        JOIN PEDIDO_INTERNO_TALLAS PIT ON PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido
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
        JOIN TALLAS_GENERALES TG ON TG.Talla = PIT.Talla
    WHERE 
        PI.Empresa = @EMPRESA
        AND PI.No_Pedido = @NO_PEDIDO
    GROUP BY
        PI.No_Pedido,
        PIT.Cve_Prenda,
        PIT.DescripcionPrenda,
        PIT.FechaVencimiento,
        TG.Partida,
        PIT.Talla,
        PIT.PrecioUnitario

	UPDATE
		#PEDIDO_PARTIDAS
	SET
		SUBTOTALPEDIDO = (SELECT SUM(PP.SUBTOTALPARTIDA) FROM #PEDIDO_PARTIDAS PP),
		IVAPEDIDO = (SELECT SUM(PP.IVAPARTIDA) FROM #PEDIDO_PARTIDAS PP),
		TOTALPEDIDO = (SELECT SUM(PP.TOTALPARTIDA) FROM #PEDIDO_PARTIDAS PP)

    CREATE TABLE #OBSERVACIONESPARTIDAPRODUCCION
    (
        No_Pedido BIGINT,
        Cve_Prenda BIGINT,
        ObservacionesPartidaProduccion NVARCHAR(max)
    )
    INSERT INTO #OBSERVACIONESPARTIDAPRODUCCION
    (
        No_Pedido,
        Cve_Prenda,
        ObservacionesPartidaProduccion
    )
    SELECT
        PIT.No_Pedido,
        PIT.Cve_Prenda,
        REPLACE(PIT.ObservacionesPartidaProduccion, CHAR(13) + CHAR(10), '||') AS ObservacionesPartidaProduccion
    FROM
        PEDIDO_INTERNO PI
        JOIN PEDIDO_INTERNO_TALLAS PIT ON PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido
    WHERE
        PI.Empresa = @EMPRESA
        AND PI.No_Pedido = @NO_PEDIDO
    GROUP BY
        PIT.No_Pedido,
        PIT.Cve_Prenda,
        PIT.ObservacionesPartidaProduccion

    CREATE TABLE #OBSERVACIONESPARTIDALOGISTICA
    (
        No_Pedido BIGINT,
        Cve_Prenda BIGINT,
        ObservacionesPartidaLogistica NVARCHAR(max)
    )
    INSERT INTO #OBSERVACIONESPARTIDALOGISTICA
    (
        No_Pedido,
        Cve_Prenda,
        ObservacionesPartidaLogistica
    )
    SELECT
        PIT.No_Pedido,
        PIT.Cve_Prenda,
        REPLACE(PIT.ObservacionesPartidaLogistica, CHAR(13) + CHAR(10), '||') AS ObservacionesPartidaLogistica
    FROM
        PEDIDO_INTERNO PI
        JOIN PEDIDO_INTERNO_TALLAS PIT ON PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido
    WHERE
        PI.Empresa = @EMPRESA
        AND PI.No_Pedido = @NO_PEDIDO
    GROUP BY
        PIT.No_Pedido,
        PIT.Cve_Prenda,
        PIT.ObservacionesPartidaLogistica

    CREATE TABLE #OBSERVACIONESPARTIDAFACTURACION
    (
        No_Pedido BIGINT,
        Cve_Prenda BIGINT,
        ObservacionesPartidaFacturacion NVARCHAR(max)
    )
    INSERT INTO #OBSERVACIONESPARTIDAFACTURACION
    (
        No_Pedido,
        Cve_Prenda,
        ObservacionesPartidaFacturacion
    )
    SELECT
        PIT.No_Pedido,
        PIT.Cve_Prenda,
        REPLACE(PIT.ObservacionesPartidaFacturacion, CHAR(13) + CHAR(10), '||') AS ObservacionesPartidaFacturacion
    FROM
        PEDIDO_INTERNO PI
        JOIN PEDIDO_INTERNO_TALLAS PIT ON PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido
    WHERE
        PI.Empresa = @EMPRESA
        AND PI.No_Pedido = @NO_PEDIDO
    GROUP BY
        PIT.No_Pedido,
        PIT.Cve_Prenda,
        PIT.ObservacionesPartidaFacturacion

    DECLARE @cols AS NVARCHAR(MAX);
    DECLARE @sql AS NVARCHAR(MAX);

    SELECT @cols = (
        SELECT QUOTENAME(talla) + ', '
        FROM #TEMP
        FOR XML PATH('')
    );

    -- Remueve la última coma y el espacio
    SELECT @cols = LEFT(@cols, LEN(@cols) - 1);

    SET @sql = 'SELECT 
				  PartidaAcomodo,
                  NO_PEDIDO,
                  CVE_PRENDA,
                  DESCRIPCIONPRENDA,
                  FECHAVENCIMIENTO,
                  ' + @cols + ',
				  (SELECT SUM(PP.CANTIDAD) FROM #PEDIDO_PARTIDAS PP WHERE PP.NO_PEDIDO = P.NO_PEDIDO AND PP.CVE_PRENDA = P.CVE_PRENDA) AS TotalPrendasPartida,
                  PRECIO,
				  (SELECT SUM(PP.SUBTOTALPARTIDA) FROM #PEDIDO_PARTIDAS PP WHERE PP.NO_PEDIDO = P.NO_PEDIDO AND PP.CVE_PRENDA = P.CVE_PRENDA) AS SubtotalPartida,
				  (SELECT SUM(PP.IVAPARTIDA) FROM #PEDIDO_PARTIDAS PP WHERE PP.NO_PEDIDO = P.NO_PEDIDO AND PP.CVE_PRENDA = P.CVE_PRENDA) AS IvaPartida,
				  (SELECT SUM(PP.TOTALPARTIDA) FROM #PEDIDO_PARTIDAS PP WHERE PP.NO_PEDIDO = P.NO_PEDIDO AND PP.CVE_PRENDA = P.CVE_PRENDA) AS TotalPartida,
				  SUBTOTALPEDIDO,
				  IVAPEDIDO,
				  TOTALPEDIDO,
				  (SELECT
                      STUFF((SELECT '', '' + REPLACE(OPF.ObservacionesPartidaProduccion, ''||'', CHAR(10))
                             FROM #OBSERVACIONESPARTIDAPRODUCCION AS OPF
                             WHERE OPF.Cve_Prenda = P.CVE_PRENDA
                             FOR XML PATH('''')), 1, 2, '''')
                   ) AS ObservacionesPartidaProduccion,
				   (SELECT
                      STUFF((SELECT '', '' + REPLACE(OPF.ObservacionesPartidaLogistica, ''||'', CHAR(10))
                             FROM #OBSERVACIONESPARTIDALOGISTICA AS OPF
                             WHERE OPF.Cve_Prenda = P.CVE_PRENDA
                             FOR XML PATH('''')), 1, 2, '''')
                   ) AS ObservacionesPartidaLogistica,
                  (SELECT
                      STUFF((SELECT '', '' + REPLACE(OPF.ObservacionesPartidaFacturacion, ''||'', CHAR(10))
                             FROM #OBSERVACIONESPARTIDAFACTURACION AS OPF
                             WHERE OPF.Cve_Prenda = P.CVE_PRENDA
                             FOR XML PATH('''')), 1, 2, '''')
                   ) AS ObservacionesPartidaFacturacion
                FROM 
                (
                  SELECT 
					PartidaAcomodo,
                    NO_PEDIDO,
                    CVE_PRENDA,
                    DESCRIPCIONPRENDA,
                    FECHAVENCIMIENTO,
                    talla AS talla_column,
                    SUM(cantidad) AS cantidad_total,
                    PRECIO,
					SUBTOTALPEDIDO,
					IVAPEDIDO,
					TOTALPEDIDO
                  FROM #PEDIDO_PARTIDAS
                  GROUP BY 
					PartidaAcomodo,
                    NO_PEDIDO,
                    CVE_PRENDA,
                    DESCRIPCIONPRENDA,
                    FECHAVENCIMIENTO,
                    TALLA,
                    PRECIO,
					SUBTOTALPEDIDO,
					IVAPEDIDO,
					TOTALPEDIDO
                ) P
                PIVOT 
                (
                  SUM(cantidad_total)
                  FOR talla_column IN (' + @cols + ')
                ) p
				order by PartidaAcomodo;';

    EXEC sp_executesql @sql;

    DROP TABLE #PEDIDO_PARTIDAS
    DROP TABLE #TEMP
    DROP TABLE #OBSERVACIONESPARTIDAPRODUCCION
    DROP TABLE #OBSERVACIONESPARTIDALOGISTICA
    DROP TABLE #OBSERVACIONESPARTIDAFACTURACION
END

--EXEC SP_CONSULTA_PEDIDO_INTERNO_PARTIDAS_RESUMEN 1,1839
--EXEC SP_CONSULTA_PEDIDO_INTERNO_PARTIDAS_DETALLE 1,1839
GO

