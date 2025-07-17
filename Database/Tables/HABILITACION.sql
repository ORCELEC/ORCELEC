USE [NORCELEC]
GO

/****** Object:  Table [dbo].[HABILITACION]    Script Date: 17/07/2025 01:45:36 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HABILITACION](
	[Cve_Grupo] [nvarchar](3) NOT NULL,
	[Cve_Habilitacion] [numeric](18, 0) NOT NULL,
	[Existencia] [numeric](18, 2) NULL,
	[Reservado] [numeric](18, 2) NULL,
	[Stock_Minimo] [numeric](18, 2) NULL,
	[Status] [bit] NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_HABILITACION] PRIMARY KEY CLUSTERED 
(
	[Cve_Grupo] ASC,
	[Cve_Habilitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

