USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_PROCESOS]    Script Date: 20/10/2025 12:47:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_PROCESOS](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[Cve_Prenda] [numeric](18, 0) NOT NULL,
	[Orden] [int] NOT NULL,
	[Nivel1] [int] NOT NULL,
	[Nivel2] [int] NOT NULL,
	[Nivel3] [int] NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_PROCESOS] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Cve_Prenda] ASC,
	[Orden] ASC,
	[Nivel1] ASC,
	[Nivel2] ASC,
	[Nivel3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

