USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO_TALLAS]    Script Date: 07/07/2025 11:54:37 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO_TALLAS](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [numeric](18, 0) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[DescripcionPrenda] [nvarchar](500) NULL,
	[LugarDeEntrega] [numeric](18, 0) NOT NULL,
	[NombreLugarDeEntrega] [nvarchar](150) NULL,
	[LugarDeCobro] [bigint] NULL,
	[NombreLugarDeCobro] [nvarchar](150) NULL,
	[InstruccionesCobro] [text] NULL,
	[FechaVencimiento] [date] NULL,
	[Prioridad] [bigint] NOT NULL,
	[MotivoPrioridad] [nvarchar](1000) NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[Cantidad] [numeric](18, 0) NULL,
	[PrecioUnitario] [numeric](18, 4) NULL,
	[Subtotal] [numeric](18, 4) NULL,
	[Iva] [numeric](18, 4) NULL,
	[Total] [numeric](18, 4) NULL,
	[ObservacionesPartidaProduccion] [nvarchar](max) NULL,
	[ObservacionesPartidaLogistica] [nvarchar](max) NULL,
	[ObservacionesPartidaFacturacion] [nvarchar](max) NULL,
	[No_OP] [bigint] NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[GORRO] [bit] NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO_TALLAS_1] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Partida] ASC,
	[Cve_Prenda] ASC,
	[LugarDeEntrega] ASC,
	[Prioridad] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

