USE [NORCELEC]
GO

/****** Object:  Table [dbo].[FOLIOS_ADMINISTRACION]    Script Date: 09/10/2025 11:29:37 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FOLIOS_ADMINISTRACION](
	[Empresa] [numeric](18, 0) NOT NULL,
	[Num_Folio] [numeric](18, 0) NOT NULL,
	[Fecha] [date] NULL,
	[Cve_Vendedor] [numeric](18, 0) NULL,
	[Cve_Cliente] [numeric](18, 0) NULL,
	[PedidosAsignados] [numeric](18, 0) NULL,
	[PedidosUtilizados] [numeric](18, 0) NULL,
	[TipoPedido] [char](1) NULL,
	[Cve_PedCliente] [nvarchar](100) NULL,
	[Fec_Pedido] [date] NULL,
	[Fec_Recepcion] [date] NULL,
	[Cve_Proveedor] [nvarchar](100) NULL,
	[Orden_Surtimiento] [nvarchar](100) NULL,
	[Contrato_Cliente] [nvarchar](100) NULL,
	[StatusPedidos] [bit] NULL,
	[Status] [bit] NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_FOLIOS] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Num_Folio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

