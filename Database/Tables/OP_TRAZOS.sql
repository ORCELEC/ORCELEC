USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_TRAZOS]    Script Date: 20/01/2026 12:45:31 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_TRAZOS](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[Consecutivo] [bigint] NOT NULL,
	[No_Trazo] [bigint] NOT NULL,
	[Cuerpos] [bigint] NULL,
	[AnchoTela] [numeric](18, 2) NULL,
	[AnchoTrazo] [numeric](18, 2) NULL,
	[LargoTrazo] [numeric](18, 2) NULL,
	[LargoTendido] [numeric](18, 2) NULL,
	[HojasDobles] [bigint] NULL,
	[PromedioOP] [numeric](18, 2) NULL,
	[PromedioTaller] [numeric](18, 2) NULL,
	[LienzosIzqDer] [nvarchar](100) NULL,
	[TotalPiezas] [bigint] NULL,
	[MetrosOcupados] [numeric](18, 2) NULL,
 CONSTRAINT [PK_OP_TRAZOS] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Consecutivo] ASC,
	[No_Trazo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

