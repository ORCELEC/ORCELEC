USE [NORCELEC]
GO

/****** Object:  Table [dbo].[SUGERIDO_COMPRA]    Script Date: 09/10/2025 11:32:14 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SUGERIDO_COMPRA](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido] [bigint] NOT NULL,
	[Consecutivo] [int] NOT NULL,
	[Cve_Prenda] [bigint] NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](20) NOT NULL,
	[Cve_Tela] [numeric](18, 0) NULL,
	[Cve_Grupo] [nvarchar](3) NULL,
	[Cve_Habilitacion] [numeric](18, 0) NULL,
	[DescripcionMaterial] [nvarchar](255) NULL,
	[Stock] [numeric](18, 2) NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[Unidad] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[No_OP] [numeric](18, 0) NOT NULL,
	[No_OrdenCompra] [numeric](18, 0) NULL,
	[CantidadComprada] [numeric](18, 2) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_SUGERIDO_COMPRA_1] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido] ASC,
	[Consecutivo] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC,
	[No_OP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PENDIENTE (Cuando esta pendiente para compra, condición para aparecer en Sugerido de compra", CANCELADO, RESERVADO (que en algún momento fue explosionado y se reservo) , INVENTARIO (que existe en inventario al momento de autorizar el pedido y explosionar), INVENTARIO OP (que se encuentra en inventario al momento de solicitar un material adicional en la OP)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SUGERIDO_COMPRA', @level2type=N'COLUMN',@level2name=N'Status'
GO

