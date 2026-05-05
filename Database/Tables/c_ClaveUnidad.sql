USE [NORCELEC]
GO

/****** Object:  Table [dbo].[c_ClaveUnidad]    Script Date: 04/05/2026 09:02:59 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[c_ClaveUnidad](
	[c_ClaveUnidad] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
 CONSTRAINT [PK_c_ClaveUnidad] PRIMARY KEY CLUSTERED 
(
	[c_ClaveUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

