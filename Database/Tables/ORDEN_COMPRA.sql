USE [NORCELEC]
GO

/****** Object:  Table [dbo].[ORDEN_COMPRA]    Script Date: 17/07/2025 01:37:44 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ORDEN_COMPRA](
	[Empresa] [bigint] NOT NULL,
	[No_OrdenCompra] [numeric](18, 0) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[No_Pedido] [numeric](18, 0) NULL,
	[Cliente] [nvarchar](255) NULL,
	[Cve_Proveedor] [numeric](18, 0) NULL,
	[Nom_Proveedor] [nvarchar](255) NULL,
	[ProveedorRFC] [nvarchar](15) NULL,
	[ProveedorCalle] [nvarchar](255) NULL,
	[ProveedorColonia] [nvarchar](100) NULL,
	[ProveedorCiudad] [nvarchar](100) NULL,
	[ProveedorlMunDel] [nvarchar](50) NULL,
	[ProveedorEstado] [nvarchar](50) NULL,
	[ProveedorCP] [nvarchar](5) NULL,
	[ProveedorTelefono] [nvarchar](50) NULL,
	[ProveedorFax] [nvarchar](50) NULL,
	[ProveedorCelular] [nvarchar](50) NULL,
	[ProveedorAtencion] [nvarchar](100) NULL,
	[ProveedorViaEmbarque] [nvarchar](50) NULL,
	[ProveedorCondicionesPago] [nvarchar](50) NULL,
	[Cve_LugarEntrega] [bigint] NULL,
	[LugarEntregaNombre] [nvarchar](150) NULL,
	[LugarEntregaRFC] [nvarchar](15) NULL,
	[LugarEntregaCalle] [nvarchar](100) NULL,
	[LugarEntregaColonia] [nvarchar](100) NULL,
	[LugarEntregaDM] [nvarchar](100) NULL,
	[LugarEntregaEstado] [nvarchar](100) NULL,
	[LugarEntregaCiudad] [nvarchar](100) NULL,
	[LugarEntregaCP] [nvarchar](5) NULL,
	[LugarEntregaTelefono] [nvarchar](50) NULL,
	[LugarEntregaFax] [nvarchar](50) NULL,
	[LugarEntregaAtencion] [nvarchar](100) NULL,
	[TipoMaterial] [nvarchar](1) NULL,
	[Cve_Material] [nvarchar](15) NULL,
	[DescripcionMaterial] [nvarchar](255) NULL,
	[Cve_Unidad] [numeric](18, 0) NULL,
	[DescripcionUnidad] [nvarchar](100) NULL,
	[Factor] [numeric](18, 2) NULL,
	[CantidadOriginal] [numeric](18, 2) NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[PrecioUnitario] [numeric](18, 4) NULL,
	[Subtotal] [numeric](18, 4) NULL,
	[IVA] [numeric](18, 4) NULL,
	[Total] [numeric](18, 4) NULL,
	[Status] [nvarchar](50) NULL,
	[CantidadDisponible] [numeric](18, 2) NULL,
	[Recibido] [bit] NULL,
	[No_OP] [bigint] NULL,
	[USUARIOAUTORIZA] [bigint] NULL,
	[FECHAHORAAUTORIZA] [datetime] NULL,
	[COMPUTADORAAUTORIZA] [nvarchar](50) NULL,
	[USUARIOCANCELA] [bigint] NULL,
	[FECHAHORACANCELA] [datetime] NULL,
	[COMPUTADORACANCELA] [nvarchar](50) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_ORDEN_COMPRA] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OrdenCompra] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Puede tener los datos: CREADA, PROCESO DE AUTORIZACIÓN, AUTORIZADA, CANCELADA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ORDEN_COMPRA', @level2type=N'COLUMN',@level2name=N'Status'
GO

