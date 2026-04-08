USE [NORCELEC]
GO

/****** Object:  Table [dbo].[SUGERIDO_COMPRA_ORDEN_COMPRA]    Script Date: 08/04/2026 01:05:12 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SUGERIDO_COMPRA_ORDEN_COMPRA](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](20) NOT NULL,
	[No_OrdenCompra] [bigint] NOT NULL,
	[Partida_OrdenCompra] [bigint] NULL,
	[Estatus_OrdenCompra] [nvarchar](10) NULL,
 CONSTRAINT [PK_SUGERIDO_COMPRA_ORDEN_COMPRA] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC,
	[No_OrdenCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

