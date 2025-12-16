USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_INGRESO_ALMACEN]    Script Date: 15/12/2025 08:57:36 p. m. ******/
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
    DECLARE @NO_OP INT;
    DECLARE @ALMACEN_DESTINO NVARCHAR(50);

    SELECT @ID_Liberacion = X.I.value('@ID_Liberacion','uniqueidentifier'),
           @USUARIO = X.I.value('@Usuario','int'),
           @COMPUTADORA = X.I.value('@Computadora','nvarchar(50)'),
           @NUM_RECEPCION = X.I.value('@NumRecepcion','nvarchar(50)')
    FROM @XML_INGRESO.nodes('/Ingreso') AS X(I);

    DECLARE @FechaMov DATETIME = GETDATE();

    DECLARE @ALMACEN_LIBERACION NVARCHAR(50);

    SELECT TOP 1
           @NO_OP = No_OP,
           @ALMACEN_LIBERACION = LTRIM(RTRIM(ISNULL(AlmacenIngreso,'')))
    FROM OP_LIBERACIONES
    WHERE Empresa = @EMPRESA AND ID_Liberacion = @ID_Liberacion;

    SET @ALMACEN_DESTINO = LTRIM(RTRIM(ISNULL(@ALMACEN_LIBERACION,'')));
    IF (@ALMACEN_DESTINO IS NULL OR @ALMACEN_DESTINO = '')
        SET @ALMACEN_DESTINO = 'RECOLECTADO';

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

    DECLARE @DETALLE_XML TABLE
    (
        Talla NVARCHAR(50),
        Cantidad BIGINT
    );

    INSERT INTO @DETALLE_XML (Talla, Cantidad)
    SELECT
        UPPER(LTRIM(RTRIM(D.value('@Talla','nvarchar(50)')))) AS Talla,
        ISNULL(D.value('@Cantidad','bigint'),0) AS Cantidad
    FROM @XML_INGRESO.nodes('/Ingreso/Detalle') AS X(D)
    WHERE D.value('@Talla','nvarchar(50)') IS NOT NULL;

    IF NOT EXISTS (SELECT 1 FROM @DETALLE_XML)
    BEGIN
        RETURN;
    END;

    DECLARE @DETALLE TABLE
    (
        No_OP BIGINT,
        Cve_Prenda BIGINT,
        Talla NVARCHAR(50),
        CantidadOP BIGINT,
        CantidadAsignada BIGINT,
        CantidadNoAsignada BIGINT,
        CantidadLiberada BIGINT,
        CantidadRecolectada BIGINT,
        SaldoLiberadoAsignado BIGINT,
        SaldoLiberadoNoAsignado BIGINT,
        SaldoRecolectadoAsignado BIGINT,
        SaldoRecolectadoNoAsignado BIGINT,
        CantidadIngresada BIGINT,
        SaldoIngresadoAsignado BIGINT,
        SaldoIngresadoNoAsignado BIGINT,
        CantidadNueva BIGINT,
        No_Pedido BIGINT
    );

    INSERT INTO @DETALLE
    (
        No_OP,
        Cve_Prenda,
        Talla,
        CantidadOP,
        CantidadAsignada,
        CantidadNoAsignada,
        CantidadLiberada,
        CantidadRecolectada,
        SaldoLiberadoAsignado,
        SaldoLiberadoNoAsignado,
        SaldoRecolectadoAsignado,
        SaldoRecolectadoNoAsignado,
        CantidadIngresada,
        SaldoIngresadoAsignado,
        SaldoIngresadoNoAsignado,
        CantidadNueva,
        No_Pedido
    )
    SELECT
        L.No_OP,
        OIT.Cve_Prenda,
        UPPER(OIT.Talla) AS Talla,
        ISNULL(OIT.CantidadOP,0) AS CantidadOP,
        ISNULL(OIT.CantidadAsignada,0) AS CantidadAsignada,
        ISNULL(OIT.CantidadNoAsignada,0) AS CantidadNoAsignada,
        ISNULL(OIT.CantidadLiberada,0) AS CantidadLiberada,
        ISNULL(OIT.CantidadRecolectada,0) AS CantidadRecolectada,
        ISNULL(OIT.SaldoLiberadoAsignado,0) AS SaldoLiberadoAsignado,
        ISNULL(OIT.SaldoLiberadoNoAsignado,0) AS SaldoLiberadoNoAsignado,
        ISNULL(OIT.SaldoRecolectadoAsignado,0) AS SaldoRecolectadoAsignado,
        ISNULL(OIT.SaldoRecolectadoNoAsignado,0) AS SaldoRecolectadoNoAsignado,
        ISNULL(OIT.CantidadIngresada,0) AS CantidadIngresada,
        ISNULL(OIT.SaldoIngresadoAsignado,0) AS SaldoIngresadoAsignado,
        ISNULL(OIT.SaldoIngresadoNoAsignado,0) AS SaldoIngresadoNoAsignado,
        DX.Cantidad,
        OIT.No_PedidoReferencia
    FROM OP_LIBERACIONES L
    INNER JOIN @DETALLE_XML DX
            ON UPPER(L.Talla) = DX.Talla
           AND L.ID_Liberacion = @ID_Liberacion
           AND L.Empresa = @EMPRESA
    INNER JOIN OP_INVENTARIO_TEMPORAL OIT
            ON OIT.Empresa = @EMPRESA
           AND OIT.No_OP = L.No_OP
           AND UPPER(OIT.Talla) = UPPER(L.Talla);

    IF NOT EXISTS (SELECT 1 FROM @DETALLE)
    BEGIN
        RETURN;
    END;

    DECLARE @MOVIMIENTOS TABLE
    (
        No_OP BIGINT,
        Cve_Prenda BIGINT,
        Talla NVARCHAR(50),
        No_Pedido BIGINT,
        Origen NVARCHAR(50),
        Destino NVARCHAR(50),
        TipoInventario NVARCHAR(50),
        Cantidad BIGINT
    );

    DECLARE @ACTUALIZACIONES TABLE
    (
        No_OP BIGINT,
        Cve_Prenda BIGINT,
        Talla NVARCHAR(50),
        CantidadLiberada BIGINT,
        CantidadRecolectada BIGINT,
        SaldoLiberadoAsignado BIGINT,
        SaldoLiberadoNoAsignado BIGINT,
        SaldoRecolectadoAsignado BIGINT,
        SaldoRecolectadoNoAsignado BIGINT,
        CantidadIngresada BIGINT,
        SaldoIngresadoAsignado BIGINT,
        SaldoIngresadoNoAsignado BIGINT
    );

    DECLARE @ACT_AVANCE TABLE
    (
        No_OP BIGINT,
        Talla NVARCHAR(50),
        Cantidad BIGINT
    );

    DECLARE @CUR_No_OP BIGINT,
            @CUR_Cve_Prenda BIGINT,
            @CUR_Talla NVARCHAR(50),
            @CUR_CantidadOP BIGINT,
            @CUR_CantidadAsignada BIGINT,
            @CUR_CantidadNoAsignada BIGINT,
            @CUR_CantidadLiberada BIGINT,
            @CUR_CantidadRecolectada BIGINT,
            @CUR_SaldoLiberadoAsignado BIGINT,
            @CUR_SaldoLiberadoNoAsignado BIGINT,
            @CUR_SaldoRecolectadoAsignado BIGINT,
            @CUR_SaldoRecolectadoNoAsignado BIGINT,
            @CUR_CantidadIngresada BIGINT,
            @CUR_SaldoIngresadoAsignado BIGINT,
            @CUR_SaldoIngresadoNoAsignado BIGINT,
            @CUR_CantidadNueva BIGINT,
            @CUR_No_Pedido BIGINT;

    DECLARE MOV_CURSOR CURSOR LOCAL FAST_FORWARD FOR
    SELECT
        No_OP,
        Cve_Prenda,
        Talla,
        CantidadOP,
        CantidadAsignada,
        CantidadNoAsignada,
        CantidadLiberada,
        CantidadRecolectada,
        SaldoLiberadoAsignado,
        SaldoLiberadoNoAsignado,
        SaldoRecolectadoAsignado,
        SaldoRecolectadoNoAsignado,
        CantidadIngresada,
        SaldoIngresadoAsignado,
        SaldoIngresadoNoAsignado,
        CantidadNueva,
        No_Pedido
    FROM @DETALLE;

    OPEN MOV_CURSOR;

    FETCH NEXT FROM MOV_CURSOR INTO
        @CUR_No_OP,
        @CUR_Cve_Prenda,
        @CUR_Talla,
        @CUR_CantidadOP,
        @CUR_CantidadAsignada,
        @CUR_CantidadNoAsignada,
        @CUR_CantidadLiberada,
        @CUR_CantidadRecolectada,
        @CUR_SaldoLiberadoAsignado,
        @CUR_SaldoLiberadoNoAsignado,
        @CUR_SaldoRecolectadoAsignado,
        @CUR_SaldoRecolectadoNoAsignado,
        @CUR_CantidadIngresada,
        @CUR_SaldoIngresadoAsignado,
        @CUR_SaldoIngresadoNoAsignado,
        @CUR_CantidadNueva,
        @CUR_No_Pedido;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DECLARE @SaldoLiberadoAsignadoActual BIGINT = ISNULL(@CUR_SaldoLiberadoAsignado,0);
        DECLARE @SaldoLiberadoNoAsignadoActual BIGINT = ISNULL(@CUR_SaldoLiberadoNoAsignado,0);
        DECLARE @SaldoRecolectadoAsignadoActual BIGINT = ISNULL(@CUR_SaldoRecolectadoAsignado,0);
        DECLARE @SaldoRecolectadoNoAsignadoActual BIGINT = ISNULL(@CUR_SaldoRecolectadoNoAsignado,0);
        DECLARE @SaldoIngresadoAsignadoActual BIGINT = ISNULL(@CUR_SaldoIngresadoAsignado,0);
        DECLARE @SaldoIngresadoNoAsignadoActual BIGINT = ISNULL(@CUR_SaldoIngresadoNoAsignado,0);
        DECLARE @CantidadRecolectadaActual BIGINT = ISNULL(@CUR_CantidadRecolectada,0);
        DECLARE @CantidadIngresadaActual BIGINT = ISNULL(@CUR_CantidadIngresada,0);
        DECLARE @CantidadLiberadaActual BIGINT = ISNULL(@CUR_CantidadLiberada,0);
        DECLARE @CantidadRecolectadaOriginal BIGINT = @CantidadRecolectadaActual;
        DECLARE @CantidadIngresadaOriginal BIGINT = @CantidadIngresadaActual;

        DECLARE @BalanceRecolectado BIGINT = ISNULL(@CUR_CantidadNueva,0) - ISNULL(@CantidadRecolectadaActual,0);

        IF @BalanceRecolectado > 0
        BEGIN
            DECLARE @DisponibleExtraAsignado BIGINT = CASE WHEN @CUR_CantidadAsignada > @CantidadRecolectadaActual
                                                           THEN @CUR_CantidadAsignada - @CantidadRecolectadaActual
                                                           ELSE 0 END;
            IF @DisponibleExtraAsignado > @SaldoLiberadoAsignadoActual
            BEGIN
                SET @DisponibleExtraAsignado = @SaldoLiberadoAsignadoActual;
            END;

            DECLARE @MoverExtraAsignado BIGINT = CASE WHEN @BalanceRecolectado > @DisponibleExtraAsignado
                                                      THEN @DisponibleExtraAsignado ELSE @BalanceRecolectado END;

            IF @MoverExtraAsignado > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                 'LIBERADO', 'RECOLECTADO', 'Inventario Asignado', @MoverExtraAsignado);
                SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual - @MoverExtraAsignado;
                SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual + @MoverExtraAsignado;
                SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverExtraAsignado;
                SET @BalanceRecolectado = @BalanceRecolectado - @MoverExtraAsignado;
            END;

            IF @BalanceRecolectado > 0
            BEGIN
                DECLARE @MoverExtraNoAsignado BIGINT = CASE WHEN @SaldoLiberadoNoAsignadoActual > @BalanceRecolectado
                                                             THEN @BalanceRecolectado ELSE @SaldoLiberadoNoAsignadoActual END;
                IF @MoverExtraNoAsignado > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                     'LIBERADO', 'RECOLECTADO', 'Inventario no Asignado', @MoverExtraNoAsignado);
                    SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual - @MoverExtraNoAsignado;
                    SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual + @MoverExtraNoAsignado;
                    SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverExtraNoAsignado;
                    SET @BalanceRecolectado = @BalanceRecolectado - @MoverExtraNoAsignado;
                END;
            END;
        END
        ELSE IF @BalanceRecolectado < 0
        BEGIN
            DECLARE @PorDevolver BIGINT = -@BalanceRecolectado;

            DECLARE @MoverRecolectadoNoAsignadoDev BIGINT = CASE WHEN @SaldoRecolectadoNoAsignadoActual > @PorDevolver
                                                                  THEN @PorDevolver ELSE @SaldoRecolectadoNoAsignadoActual END;
            IF @MoverRecolectadoNoAsignadoDev > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                 'RECOLECTADO', 'TEMPORAL CON OP', 'Inventario no Asignado', @MoverRecolectadoNoAsignadoDev);
                SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual - @MoverRecolectadoNoAsignadoDev;
                SET @CantidadRecolectadaActual = @CantidadRecolectadaActual - @MoverRecolectadoNoAsignadoDev;
                SET @PorDevolver = @PorDevolver - @MoverRecolectadoNoAsignadoDev;
            END;

            IF @PorDevolver > 0
            BEGIN
                DECLARE @MoverRecolectadoAsignadoDev BIGINT = CASE WHEN @SaldoRecolectadoAsignadoActual > @PorDevolver
                                                                    THEN @PorDevolver ELSE @SaldoRecolectadoAsignadoActual END;
                IF @MoverRecolectadoAsignadoDev > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                     'RECOLECTADO', 'TEMPORAL CON OP', 'Inventario Asignado', @MoverRecolectadoAsignadoDev);
                    SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual - @MoverRecolectadoAsignadoDev;
                    SET @CantidadRecolectadaActual = @CantidadRecolectadaActual - @MoverRecolectadoAsignadoDev;
                    SET @PorDevolver = @PorDevolver - @MoverRecolectadoAsignadoDev;
                END;
            END;
        END;

        DECLARE @DeltaIngreso BIGINT = ISNULL(@CUR_CantidadNueva,0) - ISNULL(@CUR_CantidadIngresada,0);

        IF @DeltaIngreso > 0
        BEGIN
            DECLARE @MoverIngresoAsignado BIGINT = CASE WHEN @SaldoRecolectadoAsignadoActual > @DeltaIngreso
                                                         THEN @DeltaIngreso ELSE @SaldoRecolectadoAsignadoActual END;
            IF @MoverIngresoAsignado > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                 'RECOLECTADO', @ALMACEN_DESTINO, 'Inventario Asignado', @MoverIngresoAsignado);
                SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual - @MoverIngresoAsignado;
                SET @SaldoIngresadoAsignadoActual = @SaldoIngresadoAsignadoActual + @MoverIngresoAsignado;
                SET @CantidadIngresadaActual = @CantidadIngresadaActual + @MoverIngresoAsignado;
                SET @DeltaIngreso = @DeltaIngreso - @MoverIngresoAsignado;
            END;

            IF @DeltaIngreso > 0
            BEGIN
                DECLARE @MoverIngresoNoAsignado BIGINT = CASE WHEN @SaldoRecolectadoNoAsignadoActual > @DeltaIngreso
                                                              THEN @DeltaIngreso ELSE @SaldoRecolectadoNoAsignadoActual END;
                IF @MoverIngresoNoAsignado > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                     'RECOLECTADO', @ALMACEN_DESTINO, 'Inventario no Asignado', @MoverIngresoNoAsignado);
                    SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual - @MoverIngresoNoAsignado;
                    SET @SaldoIngresadoNoAsignadoActual = @SaldoIngresadoNoAsignadoActual + @MoverIngresoNoAsignado;
                    SET @CantidadIngresadaActual = @CantidadIngresadaActual + @MoverIngresoNoAsignado;
                    SET @DeltaIngreso = @DeltaIngreso - @MoverIngresoNoAsignado;
                END;
            END;

            IF @DeltaIngreso > 0
            BEGIN
                DECLARE @MoverAsignadoDesdeLiberado BIGINT = CASE WHEN @SaldoLiberadoAsignadoActual > @DeltaIngreso
                                                                   THEN @DeltaIngreso ELSE @SaldoLiberadoAsignadoActual END;
                IF @MoverAsignadoDesdeLiberado > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                     'LIBERADO', 'RECOLECTADO', 'Inventario Asignado', @MoverAsignadoDesdeLiberado);
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                     'RECOLECTADO', @ALMACEN_DESTINO, 'Inventario Asignado', @MoverAsignadoDesdeLiberado);
                    SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual - @MoverAsignadoDesdeLiberado;
                    SET @SaldoIngresadoAsignadoActual = @SaldoIngresadoAsignadoActual + @MoverAsignadoDesdeLiberado;
                    SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverAsignadoDesdeLiberado;
                    SET @CantidadIngresadaActual = @CantidadIngresadaActual + @MoverAsignadoDesdeLiberado;
                    SET @DeltaIngreso = @DeltaIngreso - @MoverAsignadoDesdeLiberado;
                END;

                IF @DeltaIngreso > 0
                BEGIN
                    DECLARE @MoverNoAsignadoDesdeLiberado BIGINT = CASE WHEN @SaldoLiberadoNoAsignadoActual > @DeltaIngreso
                                                                          THEN @DeltaIngreso ELSE @SaldoLiberadoNoAsignadoActual END;
                    IF @MoverNoAsignadoDesdeLiberado > 0
                    BEGIN
                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'LIBERADO', 'RECOLECTADO', 'Inventario no Asignado', @MoverNoAsignadoDesdeLiberado);
                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'RECOLECTADO', @ALMACEN_DESTINO, 'Inventario no Asignado', @MoverNoAsignadoDesdeLiberado);
                        SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual - @MoverNoAsignadoDesdeLiberado;
                        SET @SaldoIngresadoNoAsignadoActual = @SaldoIngresadoNoAsignadoActual + @MoverNoAsignadoDesdeLiberado;
                        SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverNoAsignadoDesdeLiberado;
                        SET @CantidadIngresadaActual = @CantidadIngresadaActual + @MoverNoAsignadoDesdeLiberado;
                        SET @DeltaIngreso = @DeltaIngreso - @MoverNoAsignadoDesdeLiberado;
                    END;
                END;

                IF @DeltaIngreso > 0
                BEGIN
                    DECLARE @DisponibleTemporalAsignado BIGINT = CASE WHEN @CUR_CantidadAsignada > @CantidadRecolectadaActual
                                                                       THEN @CUR_CantidadAsignada - @CantidadRecolectadaActual
                                                                       ELSE 0 END;
                    DECLARE @MoverTemporalAsignado BIGINT = CASE WHEN @DisponibleTemporalAsignado > @DeltaIngreso
                                                                   THEN @DeltaIngreso ELSE @DisponibleTemporalAsignado END;
                    IF @MoverTemporalAsignado > 0
                    BEGIN
                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'TEMPORAL CON OP', 'LIBERADO', 'Inventario Asignado', @MoverTemporalAsignado);
                        SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual + @MoverTemporalAsignado;

                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'LIBERADO', 'RECOLECTADO', 'Inventario Asignado', @MoverTemporalAsignado);
                        SET @SaldoLiberadoAsignadoActual = @SaldoLiberadoAsignadoActual - @MoverTemporalAsignado;
                        SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual + @MoverTemporalAsignado;
                        SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverTemporalAsignado;

                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'RECOLECTADO', @ALMACEN_DESTINO, 'Inventario Asignado', @MoverTemporalAsignado);
                        SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual - @MoverTemporalAsignado;
                        SET @SaldoIngresadoAsignadoActual = @SaldoIngresadoAsignadoActual + @MoverTemporalAsignado;
                        SET @CantidadIngresadaActual = @CantidadIngresadaActual + @MoverTemporalAsignado;
                        SET @DeltaIngreso = @DeltaIngreso - @MoverTemporalAsignado;
                    END;
                END;

                IF @DeltaIngreso > 0
                BEGIN
                    DECLARE @RecolectadoNoAsignadoActual BIGINT = CASE WHEN @CantidadRecolectadaActual > @CUR_CantidadAsignada
                                                                        THEN @CantidadRecolectadaActual - @CUR_CantidadAsignada
                                                                        ELSE 0 END;
                    DECLARE @DisponibleTemporalNoAsignado BIGINT = CASE WHEN @CUR_CantidadNoAsignada > @RecolectadoNoAsignadoActual
                                                                            THEN @CUR_CantidadNoAsignada - @RecolectadoNoAsignadoActual
                                                                            ELSE 0 END;
                    DECLARE @MoverTemporalNoAsignado BIGINT = CASE WHEN @DisponibleTemporalNoAsignado > @DeltaIngreso
                                                                       THEN @DeltaIngreso ELSE @DisponibleTemporalNoAsignado END;
                    IF @MoverTemporalNoAsignado > 0
                    BEGIN
                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'TEMPORAL CON OP', 'LIBERADO', 'Inventario no Asignado', @MoverTemporalNoAsignado);
                        SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual + @MoverTemporalNoAsignado;

                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'LIBERADO', 'RECOLECTADO', 'Inventario no Asignado', @MoverTemporalNoAsignado);
                        SET @SaldoLiberadoNoAsignadoActual = @SaldoLiberadoNoAsignadoActual - @MoverTemporalNoAsignado;
                        SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual + @MoverTemporalNoAsignado;
                        SET @CantidadRecolectadaActual = @CantidadRecolectadaActual + @MoverTemporalNoAsignado;

                        INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                         'RECOLECTADO', @ALMACEN_DESTINO, 'Inventario no Asignado', @MoverTemporalNoAsignado);
                        SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual - @MoverTemporalNoAsignado;
                        SET @SaldoIngresadoNoAsignadoActual = @SaldoIngresadoNoAsignadoActual + @MoverTemporalNoAsignado;
                        SET @CantidadIngresadaActual = @CantidadIngresadaActual + @MoverTemporalNoAsignado;
                        SET @DeltaIngreso = @DeltaIngreso - @MoverTemporalNoAsignado;
                    END;
                END;
            END;
        END
        ELSE IF @DeltaIngreso < 0
        BEGIN
            DECLARE @PorRevertirIngreso BIGINT = -@DeltaIngreso;

            DECLARE @MoverIngresoAsignadoRev BIGINT = CASE WHEN @SaldoIngresadoAsignadoActual > @PorRevertirIngreso
                                                            THEN @PorRevertirIngreso ELSE @SaldoIngresadoAsignadoActual END;
            IF @MoverIngresoAsignadoRev > 0
            BEGIN
                INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                 @ALMACEN_DESTINO, 'RECOLECTADO', 'Inventario Asignado', @MoverIngresoAsignadoRev);
                SET @SaldoIngresadoAsignadoActual = @SaldoIngresadoAsignadoActual - @MoverIngresoAsignadoRev;
                SET @SaldoRecolectadoAsignadoActual = @SaldoRecolectadoAsignadoActual + @MoverIngresoAsignadoRev;
                SET @CantidadIngresadaActual = @CantidadIngresadaActual - @MoverIngresoAsignadoRev;
                SET @PorRevertirIngreso = @PorRevertirIngreso - @MoverIngresoAsignadoRev;
            END;

            IF @PorRevertirIngreso > 0
            BEGIN
                DECLARE @MoverIngresoNoAsignadoRev BIGINT = CASE WHEN @SaldoIngresadoNoAsignadoActual > @PorRevertirIngreso
                                                                   THEN @PorRevertirIngreso ELSE @SaldoIngresadoNoAsignadoActual END;
                IF @MoverIngresoNoAsignadoRev > 0
                BEGIN
                    INSERT INTO @MOVIMIENTOS VALUES (@CUR_No_OP, @CUR_Cve_Prenda, @CUR_Talla, @CUR_No_Pedido,
                                                     @ALMACEN_DESTINO, 'RECOLECTADO', 'Inventario no Asignado', @MoverIngresoNoAsignadoRev);
                    SET @SaldoIngresadoNoAsignadoActual = @SaldoIngresadoNoAsignadoActual - @MoverIngresoNoAsignadoRev;
                    SET @SaldoRecolectadoNoAsignadoActual = @SaldoRecolectadoNoAsignadoActual + @MoverIngresoNoAsignadoRev;
                    SET @CantidadIngresadaActual = @CantidadIngresadaActual - @MoverIngresoNoAsignadoRev;
                    SET @PorRevertirIngreso = @PorRevertirIngreso - @MoverIngresoNoAsignadoRev;
                END;
            END;
        END;

        DECLARE @DiferenciaIngRec BIGINT = @CantidadIngresadaActual - ISNULL(@CantidadRecolectadaOriginal,0);

        IF @DiferenciaIngRec > 0
        BEGIN
            SET @CantidadLiberadaActual = @CantidadLiberadaActual + @DiferenciaIngRec;
        END
        ELSE IF @DiferenciaIngRec < 0
        BEGIN
            DECLARE @ReducirLiberada BIGINT = -@DiferenciaIngRec;
            IF @ReducirLiberada >= @CantidadLiberadaActual
            BEGIN
                SET @CantidadLiberadaActual = 0;
            END
            ELSE
            BEGIN
                SET @CantidadLiberadaActual = @CantidadLiberadaActual - @ReducirLiberada;
            END;
        END;

        IF @CantidadLiberadaActual < 0 SET @CantidadLiberadaActual = 0;
        IF @CantidadLiberadaActual > @CUR_CantidadOP SET @CantidadLiberadaActual = @CUR_CantidadOP;
        IF @CantidadRecolectadaActual < 0 SET @CantidadRecolectadaActual = 0;
        IF @CantidadRecolectadaActual > @CUR_CantidadOP SET @CantidadRecolectadaActual = @CUR_CantidadOP;
        IF @CantidadIngresadaActual < 0 SET @CantidadIngresadaActual = 0;
        IF @CantidadIngresadaActual > @CUR_CantidadOP SET @CantidadIngresadaActual = @CUR_CantidadOP;

        IF ISNULL(@CantidadIngresadaActual,0) <> ISNULL(@CantidadIngresadaOriginal,0)
        BEGIN
            INSERT INTO @ACT_AVANCE (No_OP, Talla, Cantidad)
            VALUES (@CUR_No_OP, @CUR_Talla, @CantidadIngresadaActual);
        END;

        INSERT INTO @ACTUALIZACIONES
        VALUES
        (
            @CUR_No_OP,
            @CUR_Cve_Prenda,
            @CUR_Talla,
            @CantidadLiberadaActual,
            @CantidadRecolectadaActual,
            CASE WHEN @SaldoLiberadoAsignadoActual < 0 THEN 0 ELSE @SaldoLiberadoAsignadoActual END,
            CASE WHEN @SaldoLiberadoNoAsignadoActual < 0 THEN 0 ELSE @SaldoLiberadoNoAsignadoActual END,
            CASE WHEN @SaldoRecolectadoAsignadoActual < 0 THEN 0 ELSE @SaldoRecolectadoAsignadoActual END,
            CASE WHEN @SaldoRecolectadoNoAsignadoActual < 0 THEN 0 ELSE @SaldoRecolectadoNoAsignadoActual END,
            @CantidadIngresadaActual,
            CASE WHEN @SaldoIngresadoAsignadoActual < 0 THEN 0 ELSE @SaldoIngresadoAsignadoActual END,
            CASE WHEN @SaldoIngresadoNoAsignadoActual < 0 THEN 0 ELSE @SaldoIngresadoNoAsignadoActual END
        );

        FETCH NEXT FROM MOV_CURSOR INTO
            @CUR_No_OP,
            @CUR_Cve_Prenda,
            @CUR_Talla,
            @CUR_CantidadOP,
            @CUR_CantidadAsignada,
            @CUR_CantidadNoAsignada,
            @CUR_CantidadLiberada,
            @CUR_CantidadRecolectada,
            @CUR_SaldoLiberadoAsignado,
            @CUR_SaldoLiberadoNoAsignado,
            @CUR_SaldoRecolectadoAsignado,
            @CUR_SaldoRecolectadoNoAsignado,
            @CUR_CantidadIngresada,
            @CUR_SaldoIngresadoAsignado,
            @CUR_SaldoIngresadoNoAsignado,
            @CUR_CantidadNueva,
            @CUR_No_Pedido;
    END;

    CLOSE MOV_CURSOR;
    DEALLOCATE MOV_CURSOR;

    IF EXISTS (SELECT 1 FROM @ACTUALIZACIONES)
    BEGIN
        UPDATE OIT
        SET OIT.CantidadLiberada = A.CantidadLiberada,
            OIT.CantidadRecolectada = A.CantidadRecolectada,
            OIT.SaldoLiberadoAsignado = A.SaldoLiberadoAsignado,
            OIT.SaldoLiberadoNoAsignado = A.SaldoLiberadoNoAsignado,
            OIT.SaldoRecolectadoAsignado = A.SaldoRecolectadoAsignado,
            OIT.SaldoRecolectadoNoAsignado = A.SaldoRecolectadoNoAsignado,
            OIT.CantidadIngresada = A.CantidadIngresada,
            OIT.SaldoIngresadoAsignado = A.SaldoIngresadoAsignado,
            OIT.SaldoIngresadoNoAsignado = A.SaldoIngresadoNoAsignado,
            OIT.FechaUltimaActualizacion = @FechaMov
        FROM OP_INVENTARIO_TEMPORAL OIT
        INNER JOIN @ACTUALIZACIONES A
                ON A.No_OP = OIT.No_OP
               AND A.Cve_Prenda = OIT.Cve_Prenda
               AND UPPER(A.Talla) = UPPER(OIT.Talla)
        WHERE OIT.Empresa = @EMPRESA;
    END;

    IF EXISTS (SELECT 1 FROM @ACT_AVANCE)
    BEGIN
        UPDATE A
        SET A.Cantidad = AV.Cantidad,
            A.Fecha = @FechaMov,
            A.Usuario = @USUARIO,
            A.FechaHora = @FechaMov,
            A.Computadora = @COMPUTADORA
        FROM OP_AVANCEPROCESOS A
        INNER JOIN (
                SELECT No_OP, Talla, MAX(Cantidad) AS Cantidad
                FROM @ACT_AVANCE
                GROUP BY No_OP, Talla
        ) AS AV
                ON AV.No_OP = A.No_OP
               AND UPPER(AV.Talla) = UPPER(A.Talla)
        WHERE A.Empresa = @EMPRESA
          AND A.ID_Liberacion = @ID_Liberacion
          AND ISNULL(A.Cantidad,0) <> ISNULL(AV.Cantidad,0);
    END;

    IF EXISTS (SELECT 1 FROM @MOVIMIENTOS)
    BEGIN
        UPDATE IA
        SET IA.InventarioAsignado = IA.InventarioAsignado - M.Cantidad
        FROM PRENDA_INVENTARIO_ALMACEN IA
        INNER JOIN (
            SELECT Cve_Prenda, Talla, Origen AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario Asignado'
            GROUP BY Cve_Prenda, Talla, Origen
        ) AS M
                ON IA.Empresa = @EMPRESA
               AND IA.Cve_Prenda = M.Cve_Prenda
               AND UPPER(IA.Talla) = UPPER(M.Talla)
               AND IA.Almacen = M.Almacen;

        UPDATE IA
        SET IA.InventarioNoAsignado = IA.InventarioNoAsignado - M.Cantidad
        FROM PRENDA_INVENTARIO_ALMACEN IA
        INNER JOIN (
            SELECT Cve_Prenda, Talla, Origen AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario no Asignado'
            GROUP BY Cve_Prenda, Talla, Origen
        ) AS M
                ON IA.Empresa = @EMPRESA
               AND IA.Cve_Prenda = M.Cve_Prenda
               AND UPPER(IA.Talla) = UPPER(M.Talla)
               AND IA.Almacen = M.Almacen;

        MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
        USING (
            SELECT Cve_Prenda, Talla, Destino AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario Asignado'
            GROUP BY Cve_Prenda, Talla, Destino
        ) AS SOURCE
                ON TARGET.Empresa = @EMPRESA
               AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
               AND UPPER(TARGET.Talla) = UPPER(SOURCE.Talla)
               AND TARGET.Almacen = SOURCE.Almacen
        WHEN MATCHED THEN
            UPDATE SET TARGET.InventarioAsignado = TARGET.InventarioAsignado + SOURCE.Cantidad
        WHEN NOT MATCHED THEN
            INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
            VALUES (@EMPRESA, SOURCE.Cve_Prenda, SOURCE.Almacen, SOURCE.Talla, 0, SOURCE.Cantidad);

        MERGE PRENDA_INVENTARIO_ALMACEN AS TARGET
        USING (
            SELECT Cve_Prenda, Talla, Destino AS Almacen, SUM(Cantidad) AS Cantidad
            FROM @MOVIMIENTOS
            WHERE TipoInventario = 'Inventario no Asignado'
            GROUP BY Cve_Prenda, Talla, Destino
        ) AS SOURCE
                ON TARGET.Empresa = @EMPRESA
               AND TARGET.Cve_Prenda = SOURCE.Cve_Prenda
               AND UPPER(TARGET.Talla) = UPPER(SOURCE.Talla)
               AND TARGET.Almacen = SOURCE.Almacen
        WHEN MATCHED THEN
            UPDATE SET TARGET.InventarioNoAsignado = TARGET.InventarioNoAsignado + SOURCE.Cantidad
        WHEN NOT MATCHED THEN
            INSERT (Empresa, Cve_Prenda, Almacen, Talla, InventarioNoAsignado, InventarioAsignado)
            VALUES (@EMPRESA, SOURCE.Cve_Prenda, SOURCE.Almacen, SOURCE.Talla, SOURCE.Cantidad, 0);

        DECLARE @BITACORA TABLE
        (
            No_Pedido BIGINT,
            Cve_Prenda BIGINT,
            Talla NVARCHAR(50),
            TipoMovimiento NVARCHAR(50),
            Almacen NVARCHAR(50),
            TipoInventario NVARCHAR(50),
            Cantidad BIGINT,
            No_OP BIGINT,
            Cve_Maquilador BIGINT,
            Nom_Maquilador NVARCHAR(255)
        );

        INSERT INTO @BITACORA
        SELECT
            M.No_Pedido,
            M.Cve_Prenda,
            M.Talla,
            'SALIDA',
            M.Origen,
            M.TipoInventario,
            M.Cantidad,
            M.No_OP,
            OA.Cve_Maquilador,
            OA.Nom_Maquilador
        FROM @MOVIMIENTOS M
        INNER JOIN OP_ASIGNACION OA
                ON OA.Empresa = @EMPRESA
               AND OA.No_OP = M.No_OP
        WHERE M.Cantidad > 0
          AND M.No_Pedido IS NOT NULL

        UNION ALL

        SELECT
            M.No_Pedido,
            M.Cve_Prenda,
            M.Talla,
            'ENTRADA',
            M.Destino,
            M.TipoInventario,
            M.Cantidad,
            M.No_OP,
            OA.Cve_Maquilador,
            OA.Nom_Maquilador
        FROM @MOVIMIENTOS M
        INNER JOIN OP_ASIGNACION OA
                ON OA.Empresa = @EMPRESA
               AND OA.No_OP = M.No_OP
        WHERE M.Cantidad > 0
          AND M.No_Pedido IS NOT NULL;

        IF EXISTS (SELECT 1 FROM @BITACORA)
        BEGIN
            INSERT INTO PRENDA_INVENTARIO_BITACORA
            (
                Empresa,
                No_Pedido,
                Consecutivo,
                Cve_Prenda,
                Talla,
                TipoMovimiento,
                Almacen,
                TipoInventario,
                No_OP,
                Cve_Maquilador,
                Nom_Maquilador,
                Cantidad,
                CantidadAvance,
                USUARIO,
                FECHAHORA,
                COMPUTADORA
            )
            SELECT
                @EMPRESA,
                B.No_Pedido,
                ISNULL(MC.MaxConsecutivo,0) + B.RN,
                B.Cve_Prenda,
                B.Talla,
                B.TipoMovimiento,
                B.Almacen,
                B.TipoInventario,
                B.No_OP,
                B.Cve_Maquilador,
                B.Nom_Maquilador,
                B.Cantidad,
                0,
                @USUARIO,
                @FechaMov,
                @COMPUTADORA
            FROM (
                SELECT
                    BI.*, 
                    ROW_NUMBER() OVER (PARTITION BY BI.No_Pedido
                                       ORDER BY CASE WHEN BI.TipoMovimiento = 'SALIDA' THEN 0 ELSE 1 END,
                                                BI.TipoInventario,
                                                BI.Almacen,
                                                BI.Cve_Prenda,
                                                BI.Talla) AS RN
                FROM @BITACORA BI
            ) AS B
            OUTER APPLY (
                SELECT ISNULL(MAX(Consecutivo),0) AS MaxConsecutivo
                FROM PRENDA_INVENTARIO_BITACORA
                WHERE Empresa = @EMPRESA
                  AND No_Pedido = B.No_Pedido
            ) AS MC;
        END;
    END;
END
GO

