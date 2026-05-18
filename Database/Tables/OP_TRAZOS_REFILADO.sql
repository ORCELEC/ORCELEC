USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_TRAZOS_REFILADO]    Script Date: 15/05/2026 03:23:37 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_TRAZOS_REFILADO](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [bigint] NOT NULL,
	[Consecutivo] [bigint] NOT NULL,
	[Partida] [bigint] NOT NULL,
	[TallaOrigen] [nvarchar](50) NULL,
	[No_OPDestino] [bigint] NULL,
	[TallaDestino] [nvarchar](50) NULL,
	[Cantidad] [bigint] NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
 CONSTRAINT [PK_OP_TRAZOS_REFILADO] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC,
	[Consecutivo] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

