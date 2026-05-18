USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_TABLA_MEDIDA_TOMA_MEDIDA]    Script Date: 15/05/2026 03:20:39 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_TABLA_MEDIDA_TOMA_MEDIDA](
	[Empresa] [bigint] NOT NULL,
	[OP] [numeric](18, 0) NOT NULL,
	[Talla] [nvarchar](50) NOT NULL,
	[Partida] [bigint] NOT NULL,
	[NoMedida] [bigint] NOT NULL,
	[Toma_Medida] [numeric](18, 4) NULL,
	[Terminado] [bit] NULL,
	[USUARIO] [numeric](18, 0) NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_TABLA_MEDIDA_TOMA_MEDIDA] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[OP] ASC,
	[Talla] ASC,
	[Partida] ASC,
	[NoMedida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

