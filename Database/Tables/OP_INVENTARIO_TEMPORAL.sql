USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_INVENTARIO_TEMPORAL]    Script Date: 05/03/2026 06:01:58 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_INVENTARIO_TEMPORAL](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[CantidadOP] [bigint] NOT NULL,
	[CantidadAsignada] [bigint] NOT NULL,
	[CantidadNoAsignada] [bigint] NOT NULL,
	[CantidadLiberada] [bigint] NOT NULL,
	[SaldoLiberadoAsignado] [bigint] NOT NULL,
	[SaldoLiberadoNoAsignado] [bigint] NOT NULL,
	[CantidadRecolectada] [bigint] NOT NULL,
	[SaldoRecolectadoAsignado] [bigint] NOT NULL,
	[SaldoRecolectadoNoAsignado] [bigint] NOT NULL,
	[CantidadIngresada] [bigint] NOT NULL,
	[SaldoIngresadoAsignado] [bigint] NOT NULL,
	[SaldoIngresadoNoAsignado] [bigint] NOT NULL,
	[No_PedidoReferencia] [bigint] NULL,
	[FechaUltimaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_OP_INVENTARIO_TEMPORAL] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Cve_Prenda] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_CantidadOP]  DEFAULT ((0)) FOR [CantidadOP]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_CantidadAsignada]  DEFAULT ((0)) FOR [CantidadAsignada]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_CantidadNoAsignada]  DEFAULT ((0)) FOR [CantidadNoAsignada]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_CantidadLiberada]  DEFAULT ((0)) FOR [CantidadLiberada]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_SaldoLiberadoAsignado]  DEFAULT ((0)) FOR [SaldoLiberadoAsignado]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_SaldoLiberadoNoAsignado]  DEFAULT ((0)) FOR [SaldoLiberadoNoAsignado]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_CantidadRecolectada]  DEFAULT ((0)) FOR [CantidadRecolectada]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_SaldoRecolectadoAsignado]  DEFAULT ((0)) FOR [SaldoRecolectadoAsignado]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_SaldoRecolectadoNoAsignado]  DEFAULT ((0)) FOR [SaldoRecolectadoNoAsignado]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_CantidadIngresada]  DEFAULT ((0)) FOR [CantidadIngresada]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_SaldoIngresadoAsignado]  DEFAULT ((0)) FOR [SaldoIngresadoAsignado]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_SaldoIngresadoNoAsignado]  DEFAULT ((0)) FOR [SaldoIngresadoNoAsignado]
GO

ALTER TABLE [dbo].[OP_INVENTARIO_TEMPORAL] ADD  CONSTRAINT [DF_OP_INVENTARIO_TEMPORAL_FechaUltimaActualizacion]  DEFAULT (getdate()) FOR [FechaUltimaActualizacion]
GO

