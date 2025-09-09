USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_INGRESO_ALMACEN]    Script Date: 08/09/2025 06:34:05 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GUARDAR_INGRESO_ALMACEN]
    @EMPRESA INT,
    @XML_INGRESO XML,
    @NO_ENTRADA BIGINT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_Liberacion UNIQUEIDENTIFIER;
    DECLARE @USUARIO INT;
    DECLARE @COMPUTADORA NVARCHAR(50);
    DECLARE @NUM_RECEPCION NVARCHAR(50);
    DECLARE @ALMACEN NVARCHAR(50);
    DECLARE @NO_OP INT;

    SELECT @ID_Liberacion = X.I.value('@ID_Liberacion','uniqueidentifier'),
           @USUARIO = X.I.value('@Usuario','int'),
           @COMPUTADORA = X.I.value('@Computadora','nvarchar(50)'),
           @NUM_RECEPCION = X.I.value('@NumRecepcion','nvarchar(50)')
    FROM @XML_INGRESO.nodes('/Ingreso') AS X(I);

    DECLARE @FechaMov DATETIME = GETDATE();

    SELECT
        @EMPRESA, @NO_OP, @ID_Liberacion,
        D.value('@Talla','varchar(10)'),
        D.value('@Cantidad','int'),
        @ALMACEN, @NUM_RECEPCION,
        @FechaMov, @USUARIO, @COMPUTADORA
    FROM @XML_INGRESO.nodes('/Ingreso/Detalle') AS X(D);

    SELECT TOP 1 @ALMACEN = AlmacenIngreso,
                 @NO_OP = No_OP
    FROM OP_LIBERACIONES
    WHERE Empresa = @EMPRESA AND ID_Liberacion = @ID_Liberacion;

    DECLARE @CVE_PRENDA BIGINT

	SELECT @NO_ENTRADA = ISNULL(MAX(No_Entrada),0)+1 FROM PRENDA_ENTRADA_INVENTARIO WHERE Empresa = @EMPRESA

    SELECT TOP 1 @CVE_PRENDA = PIT.Cve_Prenda FROM PEDIDO_INTERNO_TALLAS PIT WHERE PIT.Empresa = @EMPRESA AND PIT.No_OP = @NO_OP

	INSERT INTO [dbo].[PRENDA_ENTRADA_INVENTARIO]
	(
		[Empresa]
        ,[Cve_Prenda]
        ,[No_Entrada]
		,[TipoEntrada]
        ,[TipoEntradaNumero]
        ,[Talla]
        ,[Cantidad]
        ,[FechaMovimiento]
        ,[FolioManual]
        ,[Estatus]
        ,[USUARIO]
        ,[FECHAHORA]
        ,[COMPUTADORA]
	)
    SELECT
        @EMPRESA,
        @CVE_PRENDA,
        @NO_ENTRADA,
        'OP',
        @NO_OP,
        D.value('@Talla','varchar(10)'),
        D.value('@Cantidad','int'),
        @FechaMov,
        CASE WHEN @NUM_RECEPCION = '' OR @NUM_RECEPCION IS NULL THEN convert(nvarchar,@NO_ENTRADA) ELSE @NUM_RECEPCION END,
        'AUTORIZADO',
		@USUARIO,
		GETDATE(),
		@COMPUTADORA
    FROM 
        @XML_INGRESO.nodes('/Ingreso/Detalle') AS X(D);

    UPDATE L
    SET L.NumRecepcion = @NUM_RECEPCION,
        L.CantidadIngresada = D.value('@Cantidad','int'),
        L.UsuarioIngreso = @USUARIO,
        L.FechaHoraIngreso = @FechaMov,
        L.ComputadoraIngreso = @COMPUTADORA,
        L.Ingresado = 1
    FROM OP_LIBERACIONES L
    INNER JOIN @XML_INGRESO.nodes('/Ingreso/Detalle') AS X(D)
        ON L.ID_Liberacion = @ID_Liberacion
       AND L.Talla = D.value('@Talla','varchar(10)')
    WHERE L.Empresa = @EMPRESA;
END
GO

