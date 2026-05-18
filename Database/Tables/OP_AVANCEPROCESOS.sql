USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_AVANCEPROCESOS]    Script Date: 15/05/2026 03:20:53 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_AVANCEPROCESOS](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [numeric](18, 0) NOT NULL,
	[Cve_OP] [numeric](18, 0) NULL,
	[Fecha] [datetime] NOT NULL,
	[Nivel1] [int] NOT NULL,
	[Nivel2] [int] NOT NULL,
	[Nivel3] [int] NOT NULL,
	[SinCambios] [bit] NULL,
	[Talla] [nvarchar](20) NOT NULL,
	[Cantidad] [numeric](18, 0) NULL,
	[Txt_Talla1] [numeric](18, 0) NULL,
	[Txt_Talla2] [numeric](18, 0) NULL,
	[Txt_Talla3] [numeric](18, 0) NULL,
	[Txt_Talla4] [numeric](18, 0) NULL,
	[Txt_Talla5] [numeric](18, 0) NULL,
	[Txt_Talla6] [numeric](18, 0) NULL,
	[Txt_Talla7] [numeric](18, 0) NULL,
	[Txt_Talla8] [numeric](18, 0) NULL,
	[Txt_Talla9] [numeric](18, 0) NULL,
	[Txt_Talla10] [numeric](18, 0) NULL,
	[Txt_Talla11] [numeric](18, 0) NULL,
	[Txt_Talla12] [numeric](18, 0) NULL,
	[Txt_Talla13] [numeric](18, 0) NULL,
	[Txt_Talla14] [numeric](18, 0) NULL,
	[Txt_Talla15] [numeric](18, 0) NULL,
	[Txt_Talla16] [numeric](18, 0) NULL,
	[ID_Liberacion] [uniqueidentifier] NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_AVANCEPROCESOS] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Fecha] ASC,
	[Nivel1] ASC,
	[Nivel2] ASC,
	[Nivel3] ASC,
	[Talla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

