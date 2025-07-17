USE [NORCELEC]
GO

/****** Object:  Table [dbo].[CATALOGO_TELA]    Script Date: 17/07/2025 01:45:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CATALOGO_TELA](
	[Cve_Tela] [numeric](18, 0) NOT NULL,
	[Composicion] [nvarchar](100) NULL,
	[Tela] [nvarchar](100) NULL,
	[Tejido] [nvarchar](100) NULL,
	[Color] [nvarchar](100) NULL,
	[Variante] [nvarchar](100) NULL,
	[Peso] [nvarchar](50) NULL,
	[Ancho] [numeric](18, 2) NULL,
	[Cve_Proveedor] [numeric](18, 0) NULL,
	[Existencia] [numeric](18, 2) NULL,
	[Reservado] [numeric](18, 2) NULL,
	[STATUS] [bit] NULL,
	[USUARIOALTA] [numeric](18, 0) NULL,
	[FECHAHORAALTA] [datetime] NULL,
	[COMPUTADORAALTA] [nvarchar](50) NULL,
	[USUARIOMOD] [numeric](18, 0) NULL,
	[FECHAHORAMOD] [datetime] NULL,
	[COMPUTADORAMOD] [nvarchar](50) NULL,
	[USUARIOBAJA] [numeric](18, 0) NULL,
	[FECHAHORABAJA] [datetime] NULL,
	[COMPUTADORABAJA] [nvarchar](50) NULL,
 CONSTRAINT [PK_CATALOGO_TELA] PRIMARY KEY CLUSTERED 
(
	[Cve_Tela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CATALOGO_TELA] ADD  CONSTRAINT [DF_CATALOGO_TELA_Existencia]  DEFAULT ((0)) FOR [Existencia]
GO

ALTER TABLE [dbo].[CATALOGO_TELA] ADD  CONSTRAINT [DF_CATALOGO_TELA_Reservado]  DEFAULT ((0)) FOR [Reservado]
GO

