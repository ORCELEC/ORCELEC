USE [NORCELEC]
GO

/****** Object:  Table [dbo].[OP_ASIGNACION]    Script Date: 10/07/2025 12:39:32 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OP_ASIGNACION](
	[Empresa] [bigint] NOT NULL,
	[No_OP] [numeric](18, 0) NOT NULL,
	[Asignada] [bit] NULL,
	[FechaParaAsignar] [date] NULL,
	[Cve_Maquilador] [numeric](18, 0) NULL,
	[Nom_Maquilador] [nvarchar](255) NULL,
	[FechaInicio] [date] NULL,
	[FechaFinalizacion] [date] NULL,
	[FechaFinalizacionReal] [date] NULL,
	[DiasProceso] [bigint] NULL,
	[EnProceso] [bit] NULL,
	[Finalizada] [bit] NULL,
	[Cancelada] [bit] NULL,
	[ReasignacionTotal] [bit] NULL,
	[ReasignacionParcial] [bit] NULL,
	[Estatus] [nvarchar](50) NULL,
	[USUARIOAsigno] [numeric](18, 0) NULL,
	[FECHAHORAAsignacion] [datetime] NULL,
	[COMPUTADORAAsignacion] [nvarchar](50) NULL,
	[USUARIOAutorizo] [bigint] NULL,
	[FECHAHORAAutorizo] [datetime] NULL,
	[COMPUTADORAAutorizo] [nvarchar](50) NULL,
	[MoldeListo] [bit] NULL,
	[USUARIOMoldeListo] [bigint] NULL,
	[FECHAHORAMoldeListo] [datetime] NULL,
	[COMPUTADORAMoldeListo] [nvarchar](50) NULL,
	[MaterialesListos] [bit] NULL,
	[USUARIOMaterialesListos] [bigint] NULL,
	[FECHAHORAMaterialesListos] [datetime] NULL,
	[COMPUTADORAMaterialesListos] [nvarchar](50) NULL,
	[MaquiladorListo] [bit] NULL,
	[USUARIOMaquiladorListo] [bigint] NULL,
	[FECHAHORAMaquiladorListo] [datetime] NULL,
	[COMPUTADORAMaquiladorListo] [nvarchar](50) NULL,
	[ConfirmacionATiempo14Dias] [bit] NULL,
	[ConfirmacionATiempo14DiasRespuesta] [nvarchar](2) NULL,
	[USUARIOConfirmacionATiempo14Dias] [bigint] NULL,
	[FECHAHORAConfirmacionATiempo14Dias] [datetime] NULL,
	[COMPUTADORAConfirmacionATiempo14Dias] [nvarchar](50) NULL,
	[ConfirmacionATiempo7Dias] [bit] NULL,
	[ConfirmacionATiempo7DiasRespuesta] [nvarchar](2) NULL,
	[USUARIOConfirmacionATiempo7Dias] [bigint] NULL,
	[FECHAHORAConfirmacionATiempo7Dias] [datetime] NULL,
	[COMPUTADORAConfirmacionATiempo7Dias] [nvarchar](50) NULL,
	[ImportadaSistemaAnterior] [bit] NULL,
	[No_OPSistemaAnterior] [numeric](18, 0) NULL,
	[ObservacionesPedidoInterno] [nvarchar](max) NULL,
	[ObservacionesOPAlAutorizar] [nvarchar](max) NULL,
	[Impresa] [bit] NULL,
	[USUARIOImpresa] [bigint] NULL,
	[FECHAHORAImpresa] [datetime] NULL,
	[COMPUTADORAImpresa] [nvarchar](50) NULL,
	[No_OPOriginal] [bigint] NULL,
 CONSTRAINT [PK_OP_ASIGNACION] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_OP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[OP_ASIGNACION] ADD  CONSTRAINT [DF_OP_ASIGNACION_ImportadaSistemaAnterior]  DEFAULT ((0)) FOR [ImportadaSistemaAnterior]
GO

ALTER TABLE [dbo].[OP_ASIGNACION] ADD  CONSTRAINT [DF_OP_ASIGNACION_Impresa]  DEFAULT ((0)) FOR [Impresa]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valores: PENDIENTE, PROCESO DE AUTORIZACIÓN, AUTORIZADA, CANCELADA, FINALIZADA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OP_ASIGNACION', @level2type=N'COLUMN',@level2name=N'Estatus'
GO

