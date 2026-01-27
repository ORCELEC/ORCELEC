USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_TRAZOS]    Script Date: 26/01/2026 07:03:48 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_TRAZOS](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[Consecutivo] [bigint] NOT NULL,
	[No_Trazo] [bigint] NOT NULL,
	[AnchoTela] [numeric](18, 2) NULL,
	[AnchoTrazo] [numeric](18, 2) NULL,
	[LargoTrazo] [numeric](18, 2) NULL,
	[LargoTendido] [numeric](18, 2) NULL,
	[TipoCorte] [nvarchar](50) NULL,
	[HojasDobles/LienzosIzqDer] [bigint] NULL,
	[PromedioOP] [numeric](18, 4) NULL,
	[PromedioTaller] [numeric](18, 4) NULL,
	[TotalPiezas] [bigint] NULL,
	[MetrosOcupados] [numeric](18, 2) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_TRAZOS] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Consecutivo] ASC,
	[No_Trazo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

