USE [NORCELEC]
GO

/****** Object:  Table [dbo].[MAQUILADOR]    Script Date: 17/07/2025 01:42:15 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MAQUILADOR](
	[Cve_Maquilador] [numeric](18, 0) NOT NULL,
	[RFC] [nvarchar](15) NULL,
	[RazonSocial] [nvarchar](150) NULL,
	[Encargado] [nvarchar](150) NULL,
	[TipoTaller] [nvarchar](50) NULL,
	[Calle] [nvarchar](150) NULL,
	[Colonia] [nvarchar](150) NULL,
	[Estado] [nvarchar](100) NULL,
	[DelMun] [nvarchar](100) NULL,
	[Entidad] [nvarchar](100) NULL,
	[CP] [nvarchar](5) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Celular] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Ubicacion] [ntext] NULL,
	[Observaciones] [ntext] NULL,
	[DiasLaborales] [int] NULL,
	[Cve_Zona] [numeric](18, 0) NULL,
	[Cve_UsuCalidad] [numeric](18, 0) NULL,
	[Status] [bit] NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_MAQUILADOR] PRIMARY KEY CLUSTERED 
(
	[Cve_Maquilador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

