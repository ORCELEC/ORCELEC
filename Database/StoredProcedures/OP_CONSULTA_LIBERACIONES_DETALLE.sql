USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[OP_CONSULTA_LIBERACIONES_DETALLE]    Script Date: 23/07/2025 01:40:48 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[OP_CONSULTA_LIBERACIONES_DETALLE]
    @EMPRESA BIGINT,
    @NO_LIBERACION INT
AS
BEGIN
    ;WITH Det AS (
        SELECT
            L.Talla,
            SUM(L.Cantidad) AS CantidadLiberada,
            MAX(L.CantidadRecolectada) AS CantidadRecolectada,
            MAX(U1.NOM_USUARIO) AS QuienRecolecto,
            MAX(L.FechaHoraRecolecta) AS FechaHoraRecolecta,
            MAX(L.CantidadIngresada) AS CantidadIngresada,
            MAX(L.AlmacenIngreso) AS AlmacenIngreso,
            MAX(L.NumRecepcion) AS NumRecepcion,
            MAX(U2.NOM_USUARIO) AS QuienIngreso,
            MAX(L.FechaHoraIngreso) AS FechaHoraIngreso,
            MAX(L.Observaciones) AS Observaciones,
            MAX(TG.Partida) AS Partida
        FROM OP_LIBERACIONES L
            JOIN TALLAS_GENERALES TG ON TG.Talla = L.Talla
            LEFT JOIN USUARIOS U1 ON U1.Cve_Usu = L.UsuarioRecolecta
            LEFT JOIN USUARIOS U2 ON U2.Cve_Usu = L.UsuarioIngreso
        WHERE L.Empresa = @EMPRESA
            AND L.No_Liberacion = @NO_LIBERACION
        GROUP BY L.Talla
    )
    SELECT *
    FROM (
        SELECT
            Det.Talla,
            Det.CantidadLiberada AS [Cantidad Liberada],
            Det.CantidadRecolectada AS [Cantidad Recolectada],
            Det.QuienRecolecto AS [Quién Recolectó],
            Det.FechaHoraRecolecta AS [Fecha y hora de recolección],
            Det.CantidadIngresada AS [Cantidad Ingresada al Almacén],
            Det.AlmacenIngreso AS [Almacén de Ingreso],
            Det.NumRecepcion AS [Num. de Recepción],
            Det.QuienIngreso AS [Quién Ingreso al Almacén],
            Det.FechaHoraIngreso AS [Fecha y hora de Ingreso al Almacén],
            Det.Observaciones,
            Det.Partida AS Orden
        FROM Det
        UNION ALL
        SELECT
            'Total' AS Talla,
            SUM(CantidadLiberada) AS [Cantidad Liberada],
            SUM(CantidadRecolectada) AS [Cantidad Recolectada],
            NULL AS [Quién Recolectó],
            NULL AS [Fecha y hora de recolección],
            SUM(CantidadIngresada) AS [Cantidad Ingresada],
            NULL AS [Almacén de Ingreso],
            NULL AS [Num. de Recepción],
            NULL AS [Quién Ingreso al Almacén],
            NULL AS [Fecha y hora de Ingreso al Almacén],
            MAX(Observaciones) AS Observaciones,
            999999 AS Orden
        FROM Det
    ) AS Datos
    ORDER BY Datos.Orden;
END
GO

