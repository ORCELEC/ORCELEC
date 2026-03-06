USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO_RESERVA_MOV]    Script Date: 05/03/2026 08:00:10 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO_RESERVA_MOV](
	[Empresa] [bigint] NOT NULL,
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[No_Pedido] [numeric](18, 0) NULL,
	[Partida] [bigint] NULL,
	[Cve_Prenda] [bigint] NULL,
	[Talla] [nvarchar](50) NULL,
	[AlmacenOrigen] [nvarchar](50) NULL,
	[AlmacenDestino] [nvarchar](50) NULL,
	[Cantidad] [bigint] NOT NULL,
	[TipoMovimiento] [nvarchar](50) NOT NULL,
	[Usuario] [bigint] NULL,
	[FechaHora] [datetime] NOT NULL,
	[Computadora] [nvarchar](50) NULL,
	[Motivo] [nvarchar](255) NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO_RESERVA_MOV] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PEDIDO_INTERNO_RESERVA_MOV] ADD  DEFAULT (getdate()) FOR [FechaHora]
GO

