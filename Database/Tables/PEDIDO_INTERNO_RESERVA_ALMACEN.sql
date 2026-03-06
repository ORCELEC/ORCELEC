USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO_RESERVA_ALMACEN]    Script Date: 05/03/2026 08:00:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO_RESERVA_ALMACEN](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [numeric](18, 0) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[Almacen] [nvarchar](50) NOT NULL,
	[CantidadReservada] [bigint] NOT NULL,
	[CantidadSurtida] [bigint] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Usuario] [bigint] NULL,
	[Computadora] [nvarchar](50) NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO_RESERVA_ALMACEN] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Partida] ASC,
	[Cve_Prenda] ASC,
	[Talla] ASC,
	[Almacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PEDIDO_INTERNO_RESERVA_ALMACEN] ADD  DEFAULT ((0)) FOR [CantidadReservada]
GO

ALTER TABLE [dbo].[PEDIDO_INTERNO_RESERVA_ALMACEN] ADD  DEFAULT ((0)) FOR [CantidadSurtida]
GO

ALTER TABLE [dbo].[PEDIDO_INTERNO_RESERVA_ALMACEN] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO

