USE [NORCELEC]
GO

/****** Object:  Table [dbo].[IMSSAltas]    Script Date: 05/12/2025 02:34:02 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IMSSAltas](
	[Empresa] [bigint] NOT NULL,
	[No_OrdenReposicion] [nvarchar](20) NOT NULL,
	[No_Alta] [nvarchar](50) NOT NULL,
	[Fecha_Alta] [date] NULL,
	[NoContrato] [nvarchar](50) NULL,
	[Clave_Articulo] [nvarchar](20) NULL,
	[CantidadRecibida] [numeric](18, 0) NULL,
	[Importe] [numeric](18, 2) NULL,
	[fpp] [date] NULL,
	[Clasificacion_Presupuestal] [nvarchar](50) NULL,
	[Almacen_Imss] [nvarchar](100) NULL,
	[clasPtalDist] [nvarchar](50) NULL,
	[descDist] [nvarchar](50) NULL,
	[totalItems] [nvarchar](50) NULL,
	[resguardo] [nvarchar](50) NULL,
	[Facturado] [bit] NULL,
	[No_Factura] [bigint] NULL,
	[PartidaFactura] [int] NULL,
 CONSTRAINT [PK_IMSSAltas] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OrdenReposicion] ASC,
	[No_Alta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

