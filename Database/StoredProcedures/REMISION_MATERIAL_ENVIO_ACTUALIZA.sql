USE [NORCELEC]
GO

/****** Object:  StoredProcedure [dbo].[REMISION_MATERIAL_ENVIO_ACTUALIZA]    Script Date: 26/03/2026 03:38:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[REMISION_MATERIAL_ENVIO_ACTUALIZA]
    @EMPRESA BIGINT,
    @NO_REMISION BIGINT,
    @FECHAENVIO DATE = NULL, -- Establece un valor predeterminado de NULL
    @QUIENSELOLLEVO NVARCHAR(255) = NULL, -- Establece un valor predeterminado de NULL
    @OBSERVACIONES NVARCHAR(MAX) = NULL,
    @USUARIO BIGINT,
    @COMPUTADORA NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS(SELECT * FROM REMISION_MATERIAL_ENVIO WHERE Empresa = @EMPRESA AND No_Remision = @NO_REMISION)
    BEGIN
		--Se actualiza el dato existente
        UPDATE REMISION_MATERIAL_ENVIO
        SET
            FechaQueSeMando = ISNULL(@FECHAENVIO, FechaQueSeMando), -- Actualiza si @FECHAENVIO no es NULL
            QuienSeLoLLevo = ISNULL(@QUIENSELOLLEVO, QuienSeLoLLevo), -- Actualiza si @QUIENSELOLLEVO no es NULL
            ObservacionesAdicionales = ISNULL(@OBSERVACIONES,ObservacionesAdicionales),-- Actualiza si @@OBSERVACIONES no es NULL
			USUARIOACTUALIZO = @USUARIO,
			FECHAHORAACTUALIZO = GETDATE(),
			COMPUTADORAACTUALIZO = @COMPUTADORA
        WHERE
            Empresa = @EMPRESA
        AND No_Remision = @NO_REMISION
    END
	ELSE
	BEGIN
		--Se inserta el dato
		INSERT INTO REMISION_MATERIAL_ENVIO
		(
			Empresa,
			No_Remision,
			FechaQueSeMando,
			QuienSeLoLLevo,
			ObservacionesAdicionales,
			USUARIO,
			FECHAHORA,
			COMPUTADORA
		)
		SELECT
			@EMPRESA,
			@NO_REMISION,
			@FECHAENVIO,
			@QUIENSELOLLEVO,
			@OBSERVACIONES,
			@USUARIO,
			GETDATE(),
			@COMPUTADORA
	END
END
GO

