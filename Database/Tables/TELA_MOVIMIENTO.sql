USE [NORCELEC]
GO

/****** Object:  Table [dbo].[TELA_MOVIMIENTO]    Script Date: 17/07/2025 01:44:46 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TELA_MOVIMIENTO](
	[Cve_Tela] [numeric](18, 0) NOT NULL,
	[NoMovimiento] [bigint] NOT NULL,
	[TipoMovimiento] [nvarchar](1) NULL,
	[FechaMovimiento] [date] NULL,
	[Origen] [nvarchar](50) NULL,
	[Origen_No] [numeric](18, 0) NULL,
	[No_Documento] [numeric](18, 0) NULL,
	[SaldoAnterior] [numeric](18, 2) NULL,
	[CantidadMovimiento] [numeric](18, 2) NULL,
	[SaldoFinal] [numeric](18, 2) NULL,
 CONSTRAINT [PK_TELA_MOVIMIENTO] PRIMARY KEY CLUSTERED 
(
	[Cve_Tela] ASC,
	[NoMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Puede ser Parcialidad de OC, No. de Remisión' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TELA_MOVIMIENTO', @level2type=N'COLUMN',@level2name=N'No_Documento'
GO

