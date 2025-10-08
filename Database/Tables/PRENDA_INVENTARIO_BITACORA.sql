USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PRENDA_INVENTARIO_BITACORA]    Script Date: 08/10/2025 05:48:07 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRENDA_INVENTARIO_BITACORA](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[Consecutivo] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[TipoMovimiento] [nvarchar](50) NOT NULL,
	[Almacen] [nvarchar](50) NOT NULL,
	[TipoInventario] [nvarchar](50) NULL,
	[No_OP] [numeric](18, 0) NULL,
	[Cve_Maquilador] [bigint] NULL,
	[Nom_Maquilador] [nvarchar](150) NULL,
	[Cantidad] [bigint] NOT NULL,
	[CantidadAvance] [bigint] NOT NULL,
	[USUARIO] [bigint] NOT NULL,
	[FECHAHORA] [datetime] NOT NULL,
	[COMPUTADORA] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PRENDA_INVENTARIO_BITACORA] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Consecutivo] ASC,
	[Cve_Prenda] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

