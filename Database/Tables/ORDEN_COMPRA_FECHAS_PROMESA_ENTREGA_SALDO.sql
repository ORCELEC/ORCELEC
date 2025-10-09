USE [NORCELEC]
GO

/****** Object:  Table [dbo].[ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO]    Script Date: 09/10/2025 11:32:30 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[No_OrdenCompra] [numeric](18, 0) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](255) NOT NULL,
	[Descripcion_Material] [nvarchar](255) NULL,
	[Factor] [numeric](18, 2) NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[No_Parcialidad] [int] NOT NULL,
	[FechaPromesa] [date] NULL,
	[CantidadPromesa] [numeric](18, 2) NULL,
	[No_OP] [bigint] NOT NULL,
 CONSTRAINT [PK_ORDEN_COMPRA_FECHAS_PROMESA_ENTREGA_SALDO] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[No_OrdenCompra] ASC,
	[Partida] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC,
	[No_Parcialidad] ASC,
	[No_OP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

