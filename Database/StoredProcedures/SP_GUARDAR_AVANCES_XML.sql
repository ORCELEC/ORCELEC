USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_AVANCES_XML]    Script Date: 20/10/2025 11:44:17 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GUARDAR_AVANCES_XML]
    @EMPRESA BIGINT,
    @CVE_ORDEN BIGINT,
    @USUARIO BIGINT,
    @COMPUTADORA NVARCHAR(50),
    @XML_AVANCES XML
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @FechaActual DATETIME = GETDATE();
    DECLARE @ID_Liberacion UNIQUEIDENTIFIER = NEWID();

    -- Insertar avances de procesos
    INSERT INTO OP_AVANCEPROCESOS (
        Empresa, No_OP, Fecha, Nivel1, Nivel2, Nivel3, SinCambios,
        Talla, Cantidad, Usuario, FechaHora, Computadora, ID_Liberacion
    )
    SELECT
        @EMPRESA,
        @CVE_ORDEN,
        @FechaActual,
        A.value('@Nivel1','INT'),
        A.value('@Nivel2','INT'),
        A.value('@Nivel3','INT'),
        A.value('@SinCambios','BIT'),
        A.value('@Talla','NVARCHAR(20)'),
        A.value('@Cantidad','BIGINT'),
        @USUARIO,
        @FechaActual,
        @COMPUTADORA,
        CASE WHEN OPP.Descripcion = 'LIBERACIÓN' THEN @ID_Liberacion ELSE NULL END
    FROM @XML_AVANCES.nodes('/Avances/Proceso') AS XTbl(A)
    JOIN OP_PROCESOS OPP
        ON OPP.No_OP = @CVE_ORDEN
        AND OPP.Nivel1 = A.value('@Nivel1','INT')
        AND OPP.Nivel2 = A.value('@Nivel2','INT')
        AND OPP.Nivel3 = A.value('@Nivel3','INT');

    -- Insertar observaciones si existen
    INSERT INTO OP_PROCESOS_OBSERVACIONES (
        Empresa, No_OP, Nivel1, Nivel2, Nivel3, Descripcion,
        Consecutivo, Observacion, Usuario, FechaHora, Computadora
    )
    SELECT
        @EMPRESA,
        @CVE_ORDEN,
        O.value('@Nivel1','INT'),
        O.value('@Nivel2','INT'),
        O.value('@Nivel3','INT'),
        O.value('@Descripcion','NVARCHAR(255)'),
        ISNULL((
            SELECT MAX(Consecutivo) + 1
            FROM OP_PROCESOS_OBSERVACIONES
            WHERE Empresa = @EMPRESA AND No_OP = @CVE_ORDEN
                AND Nivel1 = O.value('@Nivel1','INT')
                AND Nivel2 = O.value('@Nivel2','INT')
                AND Nivel3 = O.value('@Nivel3','INT')
        ), 1),
        O.value('@Texto','NVARCHAR(MAX)'),
        @USUARIO,
        @FechaActual,
        @COMPUTADORA
    FROM @XML_AVANCES.nodes('/Avances/Observacion') AS XTbl(O);

    -- Variables para liberaci\u00f3n
    DECLARE @No_Liberacion INT;

    SELECT @No_Liberacion = ISNULL(MAX(No_Liberacion), 0) + 1
    FROM dbo.OP_LIBERACIONES
    WHERE Empresa = @EMPRESA;

    -- Tabla para capturar validaci\u00f3n de inserci\u00f3n
    DECLARE @LiberacionesTemp TABLE (ID_Liberacion UNIQUEIDENTIFIER);

    -- Insertar registros de liberaci\u00f3n y capturar ID solo si hay match con proceso LIBERACIÓN
    INSERT INTO dbo.OP_LIBERACIONES (
        Empresa, No_OP, No_Liberacion, ID_Liberacion, Talla, Cantidad, Usuario, FechaHora, Computadora, Observaciones,Recolectado,Ingresado
    )
    OUTPUT inserted.ID_Liberacion INTO @LiberacionesTemp(ID_Liberacion)
    SELECT
        @EMPRESA,
        @CVE_ORDEN,
        @No_Liberacion,
        @ID_Liberacion,
        P.value('@Talla','varchar(10)'),
        P.value('@Cantidad','int'),
        @USUARIO,
        GETDATE(),
        @COMPUTADORA,
        ISNULL((
            SELECT TOP 1 Obs.value('@Texto','NVARCHAR(MAX)')
            FROM @XML_AVANCES.nodes('/Avances/Observacion') AS XO(Obs)
            WHERE 
                Obs.value('@Nivel1','int') = P.value('@Nivel1','int') AND
                Obs.value('@Nivel2','int') = P.value('@Nivel2','int') AND
                Obs.value('@Nivel3','int') = P.value('@Nivel3','int') AND
                Obs.value('@Descripcion','NVARCHAR(255)') = 'LIBERACIÓN'
        ), ''),
        0,
        0
    FROM @XML_AVANCES.nodes('/Avances/Proceso') AS P(P)
    JOIN OP_PROCESOS OPP
        ON OPP.No_OP = @CVE_ORDEN
        AND OPP.Nivel1 = P.value('@Nivel1','int')
        AND OPP.Nivel2 = P.value('@Nivel2','int')
        AND OPP.Nivel3 = P.value('@Nivel3','int')
    WHERE OPP.Descripcion = 'LIBERACIÓN';

    -- Devolver TODAS las observaciones, marcando las nuevas con 'NUEVA'
    SELECT
        CASE 
            WHEN O.FechaHora = @FechaActual THEN 'NUEVA' 
            ELSE 'ANTERIOR' 
        END AS Tipo,
        O.FechaHora,
        O.Descripcion,
        O.Observacion,
        U.Email
    FROM OP_PROCESOS_OBSERVACIONES O
    INNER JOIN USUARIOS U ON O.Usuario = U.CVE_USU
    WHERE O.Empresa = @EMPRESA AND O.No_OP = @CVE_ORDEN
    ORDER BY O.FechaHora;

    -- Retornar valores solo si se insertaron registros de liberaci\u00f3n
    IF EXISTS (SELECT 1 FROM @LiberacionesTemp)
    BEGIN
        SELECT @No_Liberacion AS No_Liberacion, @ID_Liberacion AS ID_Liberacion;
    END
END
GO

