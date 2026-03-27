USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_ACUSES_TELA]    Script Date: 27/03/2026 01:33:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_ACUSES_TELA](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[Consecutivo] [int] NOT NULL,
	[TipoMaterial] [nvarchar](1) NOT NULL,
	[Cve_Material] [nvarchar](10) NOT NULL,
	[DescripcionMaterial] [nvarchar](255) NULL,
	[Folio] [nvarchar](100) NULL,
	[Cantidad] [numeric](18, 2) NULL,
	[FechaFirmaAcuse] [date] NULL,
	[QuienFirmaAcuse] [nvarchar](255) NULL,
	[Observaciones] [nvarchar](max) NULL,
	[RutaAcuse] [nvarchar](255) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_ACUSES_TELA] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Consecutivo] ASC,
	[TipoMaterial] ASC,
	[Cve_Material] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

