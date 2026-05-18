USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PRENDA_TABLA_MEDIDA_DETALLE]    Script Date: 15/05/2026 03:20:19 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRENDA_TABLA_MEDIDA_DETALLE](
	[Cve_Prenda] [numeric](18, 0) NOT NULL,
	[Renglon] [numeric](18, 0) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[Tipo_Sufijo] [nvarchar](2) NULL,
	[Cve_Sufijo] [numeric](18, 0) NULL,
	[Talla] [nvarchar](50) NULL,
	[Especificacion] [numeric](18, 4) NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_PRENDA_TABLA_MEDIDA_DETALLE] PRIMARY KEY CLUSTERED 
(
	[Cve_Prenda] ASC,
	[Renglon] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

