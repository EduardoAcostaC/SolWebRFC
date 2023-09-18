USE [Generacion22]
GO

/****** Object:  Table [dbo].[dbRFC]    Script Date: 18/09/2023 11:35:36 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dbRFC](
	[idRFC] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellidoPaterno] [varchar](100) NOT NULL,
	[apellidoMaterno] [varchar](100) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[rfc] [varchar](100) NULL,
	[repetido] [bit] NOT NULL,
	[activo] [bit] NOT NULL
) ON [PRIMARY]
GO

