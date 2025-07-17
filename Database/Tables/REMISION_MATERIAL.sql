USE [NORCELEC]
GO

/****** Object:  Table [dbo].[REMISION_MATERIAL]    Script Date: 17/07/2025 01:41:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[REMISION_MATERIAL](
	[Empresa] [bigint] NOT NULL,
	[No_Remision] [bigint] NOT NULL,
	[Partida] [bigint] NOT NULL,
	[FechaHoraRemision] [datetime] NULL,
	[TipoDestinatario] [nvarchar](50) NULL,
	[Cve_Destinatario] [bigint] NULL,
	[RazonSocialDestinatario] [nvarchar](500) NULL,
	[RFCDestinatario] [nvarchar](15) NULL,
	[Calle] [nvarchar](255) NULL,
	[NoExterior] [nvarchar](20) NULL,
	[NoInterior] [nvarchar](50) NULL,
	[Colonia] [nvarchar](150) NULL,
	[Municipio] [nvarchar](100) NULL,
	[CP] [nvarchar](5) NULL,
	[Ciudad] [nvarchar](100) NULL,
	[Estado] [nvarchar](100) NULL,
	[Telefono] [nvarchar](100) NULL,
	[Celular] [nvarchar](100) NULL,
	[Email] [nvarchar](255) NULL,
	[Contacto] [nvarchar](50) NULL,
	[TelContacto] [nvarchar](100) NULL,
	[No_OP] [bigint] NULL,
	[No_Pedido] [bigint] NULL,
	[No_OrdenCompra] [bigint] NULL,
	[OC_Partida] [bigint] NULL,
	[OC_No_Parcialidad] [bigint] NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[Descripcion] [nvarchar](1000) NULL,
	[TipoMaterial] [nvarchar](50) NULL,
	[Cve_Material] [nvarchar](15) NULL,
	[Cve_Tela] [numeric](18, 0) NULL,
	[Cve_Grupo] [nvarchar](3) NULL,
	[Cve_Habilitacion] [numeric](18, 0) NULL,
	[PrecioU] [numeric](18, 4) NULL,
	[PorcentajeIVA] [numeric](18, 2) NULL,
	[Subtotal_Partida] [numeric](18, 4) NULL,
	[IVA_Partida] [numeric](18, 4) NULL,
	[Total_Partida] [numeric](18, 4) NULL,
	[Subtotal_Remision] [numeric](18, 4) NULL,
	[IVA_Remision] [numeric](18, 4) NULL,
	[Total_Remision] [numeric](18, 4) NULL,
	[ImporteEnLetra] [nvarchar](255) NULL,
	[Notas] [text] NULL,
	[CveUnidadMedida] [nvarchar](10) NULL,
	[UnidadMedida] [nvarchar](255) NULL,
	[Estatus] [nvarchar](50) NULL,
	[Impresa] [bit] NULL,
	[USUARIOIMPRESION] [bigint] NULL,
	[FECHAHORAIMPRESION] [datetime] NULL,
	[COMPUTADORAIMPRESION] [nvarchar](50) NULL,
	[USUARIOCANCELACION] [bigint] NULL,
	[FECHAHORACANCELACION] [datetime] NULL,
	[COMPUTADORACANCELACION] [nvarchar](50) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_REMISION_MATERIAL] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Remision] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

