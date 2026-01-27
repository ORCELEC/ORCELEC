USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PRENDA_ESTRUCTURA_MATERIALES_DETALLE]    Script Date: 20/01/2026 12:46:19 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRENDA_ESTRUCTURA_MATERIALES_DETALLE](
	[Renglon] [numeric](38, 0) NOT NULL,
	[Cve_Prenda] [numeric](18, 0) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[TipoMaterial] [nvarchar](1) NULL,
	[TipoTela] [nvarchar](1) NULL,
	[Cve_Tela] [numeric](18, 0) NULL,
	[Cve_Grupo] [nvarchar](3) NULL,
	[Cve_Habilitacion] [numeric](18, 0) NULL,
	[Descripcion] [nvarchar](1000) NULL,
	[Consumo] [numeric](18, 4) NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_PRENDA_ESTRUCTURA_MATERIALES_DETALLE] PRIMARY KEY CLUSTERED 
(
	[Renglon] ASC,
	[Cve_Prenda] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

