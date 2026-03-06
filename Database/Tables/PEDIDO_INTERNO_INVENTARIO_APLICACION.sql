USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PEDIDO_INTERNO_INVENTARIO_APLICACION]    Script Date: 05/03/2026 05:58:18 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PEDIDO_INTERNO_INVENTARIO_APLICACION](
	[Empresa] [bigint] NOT NULL,
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[No_Pedido_Origen] [bigint] NOT NULL,
	[Partida_Origen] [bigint] NOT NULL,
	[No_Pedido_Destino] [bigint] NOT NULL,
	[Partida_Destino] [bigint] NOT NULL,
	[Cve_Prenda] [bigint] NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[CantidadAsignada] [bigint] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
	[UsuarioAsignacion] [bigint] NOT NULL,
	[ComputadoraAsignacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PEDIDO_INTERNO_INVENTARIO_APLICACION] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

