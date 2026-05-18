USE [NORCELEC]
GO

/****** Object:  Table [dbo].[REMISION]    Script Date: 15/05/2026 06:34:03 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[REMISION](
	[Empresa] [bigint] NOT NULL,
	[No_Remision] [bigint] NOT NULL,
	[Partida] [bigint] NOT NULL,
	[FechaHoraRemision] [datetime] NULL,
	[Estatus] [nvarchar](50) NULL,
	[Cve_Cliente] [bigint] NULL,
	[Cliente_Nombre] [nvarchar](255) NULL,
	[ClienteRFC] [nvarchar](15) NULL,
	[ClienteCalle] [nvarchar](255) NULL,
	[ClienteNoExterior] [nvarchar](20) NULL,
	[ClienteNoInterior] [nvarchar](50) NULL,
	[ClienteColonia] [nvarchar](100) NULL,
	[ClienteMunicipio] [nvarchar](100) NULL,
	[ClienteCP] [nvarchar](5) NULL,
	[ClienteCiudad] [nvarchar](100) NULL,
	[ClienteEstado] [nvarchar](100) NULL,
	[ClienteTelefono] [nvarchar](100) NULL,
	[ClienteFax] [nvarchar](100) NULL,
	[ClienteEmail] [nvarchar](255) NULL,
	[ClienteContacto] [nvarchar](50) NULL,
	[ClienteTelContacto] [nvarchar](100) NULL,
	[Cve_PedCliente] [nvarchar](100) NULL,
	[Cve_Proveedor] [nvarchar](100) NULL,
	[Orden_Surtimiento] [nvarchar](100) NULL,
	[Contrato_Cliente] [nvarchar](100) NULL,
	[No_Pedido] [bigint] NULL,
	[Num_Folio] [bigint] NULL,
	[LugarDeEntrega] [bigint] NULL,
	[NombreLugarDeEntrega] [nvarchar](150) NULL,
	[LugarDeEntregaCalle] [nvarchar](80) NULL,
	[LugarDeEntregaNoExterior] [nvarchar](20) NULL,
	[LugarDeEntregaNoInterior] [nvarchar](50) NULL,
	[LugarDeEntregaColonia] [nvarchar](50) NULL,
	[LugarDeEntregaMunicipio] [nvarchar](50) NULL,
	[LugarDeEntregaCP] [nvarchar](5) NULL,
	[LugarDeEntregaCiudad] [nvarchar](50) NULL,
	[LugarDeEntregaEstado] [nvarchar](50) NULL,
	[LugarDeEntregaTelefono] [nvarchar](50) NULL,
	[LugarDeEntregaFax] [nvarchar](50) NULL,
	[LugarDeEntregaEmail] [nvarchar](255) NULL,
	[LugarDeEntregaContacto] [nvarchar](50) NULL,
	[LugarDeEntregaTelContacto] [nvarchar](50) NULL,
	[LugarDeEntregaAtencion] [nvarchar](50) NULL,
	[LugarDeEntregaTelAtencion] [nvarchar](50) NULL,
	[CondicionesPago] [nvarchar](100) NULL,
	[PorcentajeIVA] [numeric](18, 2) NULL,
	[CveArticuloCliente] [nvarchar](50) NULL,
	[Talla] [nvarchar](50) NULL,
	[Cantidad] [numeric](18, 0) NULL,
	[Descripcion] [nvarchar](1000) NULL,
	[CveUnidadMedida] [nvarchar](10) NULL,
	[UnidadMedida] [nvarchar](255) NULL,
	[Precio] [numeric](18, 4) NULL,
	[PartidaSubtotal] [numeric](18, 4) NULL,
	[PartidaIVA] [numeric](18, 4) NULL,
	[PartidaTotal] [numeric](18, 4) NULL,
	[RemisionSubtotal] [numeric](18, 4) NULL,
	[RemisionIVA] [numeric](18, 4) NULL,
	[RemisionTotal] [numeric](18, 4) NULL,
	[ImporteEnLetra] [nvarchar](255) NULL,
	[Impreso] [bit] NULL,
	[USUARIOIMPRESION] [bigint] NULL,
	[FECHAHORAIMPRESION] [datetime] NULL,
	[COMPUTADORAIMPRESION] [nvarchar](50) NULL,
	[USUARIO] [bigint] NULL,
	[FECHAHORA] [datetime] NULL,
	[COMPUTADORA] [nvarchar](50) NULL,
	[USUARIOCANCELO] [bigint] NULL,
	[FECHAHORACANCELO] [datetime] NULL,
	[COMPUTADORACANCELO] [nvarchar](50) NULL,
 CONSTRAINT [PK_REMISION] PRIMARY KEY CLUSTERED 
(
	[Empresa] ASC,
	[No_Remision] ASC,
	[Partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

