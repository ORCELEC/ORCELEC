USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_COMPRA_ORDEN_COMPRA]    Script Date: 20/03/2026 07:50:52 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_COMPRA_ORDEN_COMPRA](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[Partida_Pedido] [int] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[No_OrdenCompra] [bigint] NOT NULL,
	[PartidaOC] [bigint] NOT NULL,
	[CantidadOC] [bigint] NULL,
	[EstatusOC] [nvarchar](50) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](100) NULL,
 CONSTRAINT [PK_PEDIDO_COMPRA_ORDEN_COMPRA] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Partida_Pedido] ASC,
	[Cve_Prenda] ASC,
	[Talla] ASC,
	[No_OrdenCompra] ASC,
	[PartidaOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

