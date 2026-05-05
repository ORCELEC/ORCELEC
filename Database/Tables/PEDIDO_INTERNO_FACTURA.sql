USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO_FACTURA]    Script Date: 04/05/2026 09:04:56 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO_FACTURA](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[DescripcionPrenda] [nvarchar](500) NULL,
	[LugarDeEntrega] [bigint] NOT NULL,
	[NombreLugarDeEntrega] [nvarchar](150) NULL,
	[Prioridad] [bigint] NOT NULL,
	[Talla] [nvarchar](10) NOT NULL,
	[Cantidad] [numeric](18, 0) NULL,
	[No_OP] [bigint] NULL,
	[No_Factura] [bigint] NOT NULL,
	[FacturaPartida] [bigint] NOT NULL,
	[FacturaEstatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO_FACTURA_1] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Cve_Prenda] ASC,
	[LugarDeEntrega] ASC,
	[Prioridad] ASC,
	[Talla] ASC,
	[No_Factura] ASC,
	[FacturaPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

