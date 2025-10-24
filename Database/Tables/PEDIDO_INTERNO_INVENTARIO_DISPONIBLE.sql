USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO_INVENTARIO_DISPONIBLE]    Script Date: 24/10/2025 01:07:29 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO_INVENTARIO_DISPONIBLE](
	[Empresa] [bigint] NOT NULL,
	[No_Pedido_Origen] [bigint] NOT NULL,
	[Partida_Origen] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[CantidadRegistrada] [bigint] NOT NULL,
	[CantidadAsignada] [bigint] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[UsuarioRegistro] [bigint] NOT NULL,
	[ComputadoraRegistro] [nvarchar](50) NOT NULL,
	[FechaUltimaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO_INVENTARIO_DISPONIBLE] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Pedido_Origen] ASC,
	[Partida_Origen] ASC,
	[Cve_Prenda] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PEDIDO_INTERNO_INVENTARIO_DISPONIBLE] ADD  CONSTRAINT [DF_PEDIDO_INTERNO_INVENTARIO_DISPONIBLE_CantidadAsignada]  DEFAULT ((0)) FOR [CantidadAsignada]
GO

