USE [NORCELEC]
GO

/****** Object:  Table [dbo].[ORDEN_COMPRA_ASIGNACION_ITERACIONES]    Script Date: 17/07/2025 01:39:31 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDEN_COMPRA_ASIGNACION_ITERACIONES](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [numeric](18, 0) NOT NULL,
	[Prioridad] [int] NOT NULL,
	[LugarEntrega] [int] NOT NULL,
	[NombreLugarEntrega] [nvarchar](255) NULL,
	[Cve_Prenda] [numeric](18, 0) NOT NULL,
	[DescripcionPrenda] [nvarchar](500) NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](50) NOT NULL,
	[DescripcionMaterial] [nvarchar](255) NULL,
	[Consumo] [numeric](18, 2) NULL,
	[No_Parcialidad] [bigint] NOT NULL,
	[No_OrdenCompra] [numeric](18, 0) NOT NULL,
	[Partida] [numeric](18, 0) NOT NULL,
	[CantidadPromesa] [numeric](18, 2) NULL,
	[FechaPromesa] [date] NULL,
	[AsignacionPromesa] [numeric](18, 2) NULL,
	[SaldoConsumo] [numeric](18, 2) NULL,
	[SobrantePromesa] [numeric](18, 2) NULL,
	[PSPE] [bit] NULL,
	[OLE] [bit] NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[No_RemisionSistemaAnterior] [bigint] NULL,
 CONSTRAINT [PK_ORDEN_COMPRA_ASIGNACION_ITERACIONES] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Prioridad] ASC,
	[LugarEntrega] ASC,
	[Cve_Prenda] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC,
	[No_Parcialidad] ASC,
	[No_OrdenCompra] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primeras Salidas Primeras Entradas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ORDEN_COMPRA_ASIGNACION_ITERACIONES', @level2type=N'COLUMN',@level2name=N'PSPE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optimizador por Lugar de Entrega' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ORDEN_COMPRA_ASIGNACION_ITERACIONES', @level2type=N'COLUMN',@level2name=N'OLE'
GO

