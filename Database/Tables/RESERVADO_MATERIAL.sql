USE [NORCELEC]
GO

/****** Object:  Table [dbo].[RESERVADO_MATERIAL]    Script Date: 17/07/2025 06:41:21 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RESERVADO_MATERIAL](
	[Empresa] [numeric](18, 0) NOT NULL,
	[No_Reservado] [bigint] NOT NULL,
	[No_Pedido] [numeric](18, 0) NULL,
	[TipoMaterial] [nvarchar](1) NULL,
	[Cve_Material] [nvarchar](10) NULL,
	[Cve_Tela] [numeric](18, 0) NULL,
	[Cve_Grupo] [nvarchar](3) NULL,
	[Cve_Habilitacion] [numeric](18, 0) NULL,
	[DescripcionMaterial] [nvarchar](500) NULL,
	[TipoReservado] [nvarchar](255) NULL,
	[Origen_No] [numeric](18, 0) NULL,
	[No_Documento] [numeric](18, 0) NULL,
	[No_OP] [bigint] NULL,
	[CantidadReservada] [numeric](18, 2) NULL,
	[CantidadUsada] [numeric](18, 2) NULL,
	[Estatus] [nvarchar](50) NULL,
	[FECHAHORA] [datetime] NULL,
 CONSTRAINT [PK_RESERVADO_MATERIAL] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Reservado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

