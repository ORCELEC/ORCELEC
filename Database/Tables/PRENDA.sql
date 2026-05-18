USE [NORCELEC]
GO

/****** Object:  Table [dbo].[PRENDA]    Script Date: 15/05/2026 03:19:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PRENDA](
	[Cve_Prenda] [numeric](18, 0) NOT NULL,
	[Cve_TipoPrenda] [numeric](18, 0) NULL,
	[Tipo_Prenda] [nvarchar](100) NULL,
	[Tela] [nvarchar](100) NULL,
	[Color] [nvarchar](100) NULL,
	[Sexo] [nvarchar](50) NULL,
	[Manga] [nvarchar](50) NULL,
	[Adicional] [nvarchar](255) NULL,
	[Descripcion] [text] NULL,
	[TipoPrenda] [nvarchar](1) NULL,
	[Cve_TipoTalla] [numeric](18, 0) NULL,
	[LlevaProceso] [bit] NULL,
	[Status] [nvarchar](50) NULL,
	[CveProdServ] [nvarchar](50) NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[USUARIOAUTORIZA] [bigint] NULL,
	[FECHAHORAAUTORIZA] [datetime] NULL,
	[COMPUTADORAAUTORIZA] [nvarchar](50) NULL,
	[USUARIOCANCELACION] [bigint] NULL,
	[FECHAHORACANCELACION] [datetime] NULL,
	[COMPUTADORACANCELACION] [nvarchar](50) NULL,
	[Cve_PrendaSistemaAnterior] [bigint] NULL,
 CONSTRAINT [PK_PRENDA] PRIMARY KEY CLUSTERED 
(
	[Cve_Prenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N-NORMAL,E-ESPECIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PRENDA', @level2type=N'COLUMN',@level2name=N'TipoPrenda'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Guarda el Estatus de la Descripción de Prenda, EDICIÓN, PROCESO DE AUTORIZACIÓN, AUTORIZADA, CANCELADA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PRENDA', @level2type=N'COLUMN',@level2name=N'Status'
GO

