USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PRENDA_TABLA_MEDIDA]    Script Date: 09/07/2025 02:35:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRENDA_TABLA_MEDIDA](
	[Cve_Prenda] [numeric](18, 0) NOT NULL,
	[Partida] [numeric](18, 0) NOT NULL,
	[Descripcion_Medida] [nvarchar](200) NULL,
	[Unidad] [nvarchar](10) NULL,
	[Tolerancia] [numeric](18, 4) NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_PRENDA_TABLA_MEDIDA] PRIMARY KEY CLUSTERED 
(
	[Cve_Prenda] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

