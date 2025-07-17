USE [NORCELEC]
GO

/****** Object:  Table [dbo].[ORDEN_COMPRA_FECHA_PROMESA_RECIBO]    Script Date: 17/07/2025 01:43:42 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDEN_COMPRA_FECHA_PROMESA_RECIBO](
	[Empresa] [bigint] NOT NULL,
	[No_OrdenCompra] [bigint] NOT NULL,
	[Partida] [bigint] NOT NULL,
	[No_Parcialidad] [bigint] NOT NULL,
	[No_Entrega] [bigint] NOT NULL,
	[CantidadRecibida] [numeric](18, 2) NULL,
	[FechaRecibo] [date] NULL,
	[FacturaRecibo] [nvarchar](50) NULL,
	[Estatus] [nvarchar](50) NULL,
	[USUARIOINGRESO] [bigint] NULL,
	[FECHAHORAINGRESO] [datetime] NULL,
	[COMPUTADORAINGRESO] [nvarchar](50) NULL,
	[USUARIOCANCELO] [bigint] NULL,
	[FECHAHORACANCELO] [datetime] NULL,
	[COMPUTADORACANCELO] [nvarchar](50) NULL,
	[CantidadDisponibleRemision] [numeric](18, 2) NULL,
 CONSTRAINT [PK_ORDEN_COMPRA_FECHA_PROMESA_RECIBO] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OrdenCompra] ASC,
	[Partida] ASC,
	[No_Parcialidad] ASC,
	[No_Entrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PUEDE CONTENER LOS VALORES INGRESADO Y CANCELADO' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ORDEN_COMPRA_FECHA_PROMESA_RECIBO', @level2type=N'COLUMN',@level2name=N'Estatus'
GO

