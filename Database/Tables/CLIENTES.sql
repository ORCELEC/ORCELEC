USE [NORCELEC]
GO

/****** Object:  Table [dbo].[CLIENTES]    Script Date: 15/05/2026 03:22:18 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CLIENTES](
	[Cve_Cliente] [numeric](38, 0) NOT NULL,
	[Nom_Cliente] [nvarchar](255) NULL,
	[RFC] [nvarchar](15) NULL,
	[Calle] [nvarchar](255) NULL,
	[NoExterior] [nvarchar](20) NULL,
	[NoInterior] [nvarchar](50) NULL,
	[Colonia] [nvarchar](100) NULL,
	[Municipio] [nvarchar](100) NULL,
	[CP] [nvarchar](5) NULL,
	[Ciudad] [nvarchar](100) NULL,
	[Estado] [nvarchar](100) NULL,
	[Telefono] [nvarchar](100) NULL,
	[Fax] [nvarchar](100) NULL,
	[Email] [nvarchar](255) NULL,
	[Contacto] [nvarchar](50) NULL,
	[TelContacto] [nvarchar](100) NULL,
	[Tipo] [nvarchar](100) NULL,
	[Giro] [nvarchar](100) NULL,
	[DiasRevision] [ntext] NULL,
	[DiasPago] [ntext] NULL,
	[InsCobranza] [ntext] NULL,
	[InsEntrega] [ntext] NULL,
	[StatusCliente] [nvarchar](10) NULL,
	[MetodoPago] [nvarchar](100) NULL,
	[CuentaPago] [nvarchar](150) NULL,
	[BancoPago] [nvarchar](100) NULL,
	[ConsecutivoRemisionIndependiente] [bit] NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[USUARIOAUTORIZA] [numeric](18, 0) NULL,
	[FECHAHORAAUTORIZA] [datetime] NULL,
	[COMPUTADORAAUTORIZA] [nvarchar](50) NULL,
 CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED 
(
	[Cve_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

