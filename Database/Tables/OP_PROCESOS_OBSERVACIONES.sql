USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_PROCESOS_OBSERVACIONES]    Script Date: 20/10/2025 12:48:31 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_PROCESOS_OBSERVACIONES](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [nvarchar](15) NOT NULL,
	[Nivel1] [int] NOT NULL,
	[Nivel2] [int] NOT NULL,
	[Nivel3] [int] NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[Consecutivo] [bigint] NOT NULL,
	[Observacion] [ntext] NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_PROCESOS_OBSERVACIONES] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Nivel1] ASC,
	[Nivel2] ASC,
	[Nivel3] ASC,
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

