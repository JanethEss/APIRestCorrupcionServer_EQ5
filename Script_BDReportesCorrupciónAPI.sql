USE [ReportesCorrupcionAPI]
GO
/****** Object:  Table [dbo].[Estatus]    Script Date: 21/11/2023 04:38:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estatus](
	[Status] [varchar](45) NOT NULL,
	[Descripcion] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reportes]    Script Date: 21/11/2023 04:38:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reportes](
	[Folio_Reporte] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Fecha_Reporte] [date] NOT NULL,
	[Status] [varchar](45) NOT NULL,
	[Usuario] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Folio_Reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 21/11/2023 04:38:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Usuario] [varchar](45) NOT NULL,
	[Nombre] [varchar](45) NOT NULL,
	[ApeMaterno] [varchar](45) NOT NULL,
	[ApePaterno] [varchar](45) NOT NULL,
	[Contrasena] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reportes]  WITH CHECK ADD FOREIGN KEY([Status])
REFERENCES [dbo].[Estatus] ([Status])
GO
ALTER TABLE [dbo].[Reportes]  WITH CHECK ADD FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Usuario])
GO
