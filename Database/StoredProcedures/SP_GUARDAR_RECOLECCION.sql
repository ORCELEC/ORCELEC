USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_RECOLECCION]    Script Date: 24/10/2025 01:05:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GUARDAR_RECOLECCION]
    @EMPRESA INT,
    @XML_RECOLECCION XML
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_Liberacion UNIQUEIDENTIFIER;
    DECLARE @USUARIO INT;
    DECLARE @COMPUTADORA NVARCHAR(50);
    DECLARE @ALMACEN NVARCHAR(50);
    DECLARE @NO_OP NUMERIC(18,0);

    SELECT @ID_Liberacion = X.R.value('@ID_Liberacion','uniqueidentifier'),
           @USUARIO = X.R.value('@Usuario','int'),
           @COMPUTADORA = X.R.value('@Computadora','nvarchar(50)'),
           @ALMACEN = X.R.value('@Almacen','nvarchar(50)')
    FROM @XML_RECOLECCION.nodes('/Recoleccion') AS X(R);

    SELECT TOP 1 @NO_OP = No_OP
    FROM OP_LIBERACIONES
    WHERE Empresa = @EMPRESA AND ID_Liberacion = @ID_Liberacion;

    UPDATE L
    SET L.CantidadRecolectada = D.value('@Cantidad','int'),
        L.Recolectado = 1,
        L.UsuarioRecolecta = @USUARIO,
        L.FechaHoraRecolecta = GETDATE(),
        L.ComputadoraRecolecta = @COMPUTADORA,
        L.AlmacenIngreso = @ALMACEN
    FROM OP_LIBERACIONES L
    INNER JOIN @XML_RECOLECCION.nodes('/Recoleccion/Detalle') AS X(D)
        ON L.ID_Liberacion = @ID_Liberacion
       AND L.Talla = D.value('@Talla','varchar(10)')
    WHERE L.Empresa = @EMPRESA;

    UPDATE A
    SET A.Cantidad = D.value('@Cantidad','int')
    FROM OP_AVANCEPROCESOS A
    INNER JOIN @XML_RECOLECCION.nodes('/Recoleccion/Detalle') AS X(D)
        ON A.ID_Liberacion = @ID_Liberacion
       AND A.Talla = D.value('@Talla','varchar(10)')
       AND A.No_OP = @NO_OP
    WHERE A.Empresa = @EMPRESA
      AND A.Cantidad <> D.value('@Cantidad','int');
END
GO

