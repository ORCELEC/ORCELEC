USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_LIBERACIONES]    Script Date: 03/07/2025 06:45:15 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_LIBERACIONES](
	[Empresa] [int] NOT NULL,
	[No_Liberacion] [int] NOT NULL,
	[No_OP] [int] NOT NULL,
	[Talla] [varchar](10) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Computadora] [nvarchar](50) NOT NULL,
	[ID_Liberacion] [uniqueidentifier] NOT NULL,
	[Observaciones] [nvarchar](max) NULL,
	[CantidadRecolectada] [int] NULL,
	[UsuarioRecolecta] [int] NULL,
	[FechaHoraRecolecta] [datetime] NULL,
	[ComputadoraRecolecta] [nvarchar](50) NULL,
	[Recolectado] [bit] NULL,
	[CantidadIngresada] [int] NULL,
	[AlmacenIngreso] [nvarchar](50) NULL,
	[NumRecepcion] [nvarchar](50) NULL,
	[UsuarioIngreso] [int] NULL,
	[FechaHoraIngreso] [datetime] NULL,
	[ComputadoraIngreso] [nvarchar](50) NULL,
	[Ingresado] [bit] NULL,
 CONSTRAINT [PK_OP_LIBERACIONES_1] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Liberacion] ASC,
	[No_OP] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[OP_LIBERACIONES] ADD  CONSTRAINT [DF__OP_LIBERA__Fecha__08F5448B]  DEFAULT (getdate()) FOR [FechaHora]
GO

