USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_EXPLOSION_MATERIALES]    Script Date: 17/07/2025 01:40:56 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_EXPLOSION_MATERIALES](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [nvarchar](10) NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[DescripcionPrenda] [nvarchar](500) NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](10) NOT NULL,
	[Cve_Tela] [numeric](18, 0) NULL,
	[Cve_Grupo] [nvarchar](3) NULL,
	[Cve_Habilitacion] [numeric](18, 0) NULL,
	[DescripcionMaterial] [nvarchar](500) NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[RecibidoCompletoPorMaquilador] [bit] NULL,
	[USUARIORECIBIDOCOMPLETO] [bigint] NULL,
	[FECHAHORARECIBIDOCOMPLETO] [datetime] NULL,
	[COMPUTADORARECIBIDOCOMPLETO] [nvarchar](50) NULL,
	[InspeccionadoCompletoPorInspector] [bit] NULL,
	[USUARIOINSPECCIONADOCOMPLETO] [bigint] NULL,
	[FECHAHORAINSPECCIONADOCOMPLETO] [datetime] NULL,
	[COMPUTADORAINSPECCIONADOCOMPLETO] [nvarchar](50) NULL,
	[FECHAHORA] [datetime] NULL,
	[NoSeRequirio] [bit] NULL,
	[USUARIONoSeRequirio] [bigint] NULL,
	[FECHAHORANoSeRequirio] [datetime] NULL,
	[COMPUTADORANoSeRequirio] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_EXPLOSION_MATERIALES_1] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[No_Pedido] ASC,
	[Cve_Prenda] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

