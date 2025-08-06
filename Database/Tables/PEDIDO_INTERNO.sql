USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO]    Script Date: 06/08/2025 02:01:16 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO](
	[Empresa] [bigint] NOT NULL,
	[Num_Folio] [numeric](18, 0) NOT NULL,
	[Cve_Cliente] [numeric](18, 0) NOT NULL,
	[Nom_Cliente] [nvarchar](255) NULL,
	[No_Pedido] [numeric](18, 0) NOT NULL,
	[FechaVencimiento] [date] NULL,
	[DocumentacionEntrega] [text] NULL,
	[LugarDeCobro] [numeric](18, 0) NULL,
	[NombreLugarDeCobro] [nvarchar](150) NULL,
	[InstruccionesCobro] [text] NULL,
	[LlevaInspeccion] [bit] NULL,
	[QuienInspecciona] [nvarchar](255) NULL,
	[LugarInspeccion] [nvarchar](255) NULL,
	[HorarioInspeccion] [nvarchar](255) NULL,
	[AdmitenEntregaParcial] [bit] NULL,
	[PorcentajeSancionDiaria] [numeric](18, 2) NULL,
	[PorcentajeSancionMaxima] [numeric](18, 2) NULL,
	[ObservacionesGeneralesProduccion] [nvarchar](max) NULL,
	[ObservacionesGeneralesLogistica] [nvarchar](max) NULL,
	[ObservacionesGeneralesFacturacion] [nvarchar](max) NULL,
	[PorcentajeIVA] [numeric](18, 2) NULL,
	[RegimenFiscal] [nvarchar](255) NULL,
	[UsoCFDI] [nvarchar](255) NULL,
	[MetodoPago] [nvarchar](255) NULL,
	[FormaPago] [nvarchar](255) NULL,
	[CuentaPago] [nvarchar](255) NULL,
	[BancoPago] [nvarchar](255) NULL,
	[CondicionesPagoDias] [numeric](18, 0) NULL,
	[CondicionesPagoTipoDias] [nvarchar](50) NULL,
	[CondicionesPagoCondicion] [nvarchar](100) NULL,
	[Status] [nvarchar](20) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[ObservacionesAlAutorizar] [nvarchar](max) NULL,
	[USUARIOAUTORIZO] [bigint] NULL,
	[FECHAHORAAUTORIZO] [datetime] NULL,
	[COMPUTADORAAUTORIZO] [nvarchar](50) NULL,
	[ListoCalculoOP] [bit] NULL,
	[CalculoOP] [bit] NULL,
	[ListoReservarPedido] [bit] NULL,
	[PedidoReservado] [bit] NULL,
	[TipoAsignacion] [nvarchar](50) NULL,
	[ObservacionesAlCancelar] [nvarchar](max) NULL,
	[USUARIOCANCELO] [bigint] NULL,
	[FECHAHORACANCELO] [datetime] NULL,
	[COMPUTADORACANCELO] [nvarchar](50) NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Num_Folio] ASC,
	[No_Pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bit que Indica si el pedido esta Listo para poder calcular las OP a crear, este proceso se activa cuando las OC Generadas, tienen todas las Fechas Promesa de Entrega Capturadas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PEDIDO_INTERNO', @level2type=N'COLUMN',@level2name=N'ListoCalculoOP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bit que indica si el calculo de Asignación de OP ya fue realizado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PEDIDO_INTERNO', @level2type=N'COLUMN',@level2name=N'CalculoOP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PEPS (Primeras Entradas Primeras Salidad), OPLE (Optimizador Por Lugar de Entrega)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PEDIDO_INTERNO', @level2type=N'COLUMN',@level2name=N'TipoAsignacion'
GO

