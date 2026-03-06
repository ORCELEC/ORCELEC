USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PRENDA_INVENTARIO_ALMACEN]    Script Date: 05/03/2026 05:56:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRENDA_INVENTARIO_ALMACEN](
	[Empresa] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Almacen] [nvarchar](50) NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[InventarioNoAsignado] [bigint] NOT NULL,
	[InventarioAsignado] [bigint] NOT NULL,
 CONSTRAINT [PK_PRENDA_INVENTARIO_ALMACEN] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Cve_Prenda] ASC,
	[Almacen] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

