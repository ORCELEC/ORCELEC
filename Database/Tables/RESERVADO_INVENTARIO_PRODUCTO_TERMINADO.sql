USE [NORCELEC]
GO

/****** Object:  Table [dbo].[RESERVADO_INVENTARIO_PRODUCTO_TERMINADO]    Script Date: 07/08/2025 05:28:16 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RESERVADO_INVENTARIO_PRODUCTO_TERMINADO](
	[Empresa] [bigint] NOT NULL,
	[No_Reservado] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[Partida] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[LugarDeEntrega] [bigint] NOT NULL,
	[Prioridad] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[Cantidad] [numeric](18, 0) NULL,
 CONSTRAINT [PK_RESERVADO_INVENTARIO_PRODUCTO_TERMINADO] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Reservado] ASC,
	[No_Pedido] ASC,
	[Partida] ASC,
	[Cve_Prenda] ASC,
	[LugarDeEntrega] ASC,
	[Prioridad] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

