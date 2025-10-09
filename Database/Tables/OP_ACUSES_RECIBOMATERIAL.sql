USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_ACUSES_RECIBOMATERIAL]    Script Date: 09/10/2025 11:34:01 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_ACUSES_RECIBOMATERIAL](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[No_OrdenCompra] [bigint] NOT NULL,
	[Partida] [bigint] NOT NULL,
	[No_Parcialidad] [bigint] NOT NULL,
	[Consecutivo] [bigint] NOT NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](15) NOT NULL,
	[DescripcionMaterial] [nvarchar](255) NULL,
	[No_RemisionSistema] [bigint] NULL,
	[No_RemisionFisica] [nvarchar](50) NULL,
	[CantidadRemisionFisica] [numeric](18, 2) NULL,
	[FechaFirmaAcuse] [date] NULL,
	[QuienFirmaAcuse] [nvarchar](255) NULL,
	[RutaAcuse] [nvarchar](255) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[USUARIOACUSE] [bigint] NULL,
	[FECHAHORAACUSE] [datetime] NULL,
	[COMPUTADORAACUSE] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_ACUSES_RECIBOMATERIAL] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[No_OrdenCompra] ASC,
	[Partida] ASC,
	[No_Parcialidad] ASC,
	[Consecutivo] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

