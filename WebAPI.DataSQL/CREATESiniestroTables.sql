USE [Central]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Drilo_Siniestro_tercero_Drilo_Siniestro]') AND parent_object_id = OBJECT_ID(N'[dbo].[Drilo_Siniestro_tercero]'))
ALTER TABLE [dbo].[Drilo_Siniestro_tercero] DROP CONSTRAINT [FK_Drilo_Siniestro_tercero_Drilo_Siniestro]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Drilo_Siniestro_foto_Drilo_Siniestro]') AND parent_object_id = OBJECT_ID(N'[dbo].[Drilo_Siniestro_foto]'))
ALTER TABLE [dbo].[Drilo_Siniestro_foto] DROP CONSTRAINT [FK_Drilo_Siniestro_foto_Drilo_Siniestro]
GO

USE [Central]
GO

/****** Object:  Table [dbo].[Drilo_Siniestro_tercero]    Script Date: 04/15/2018 01:56:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_Siniestro_tercero]') AND type in (N'U'))
DROP TABLE [dbo].[Drilo_Siniestro_tercero]
GO

/****** Object:  Table [dbo].[Drilo_Siniestro_foto]    Script Date: 04/15/2018 01:56:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_Siniestro_foto]') AND type in (N'U'))
DROP TABLE [dbo].[Drilo_Siniestro_foto]
GO

/****** Object:  Table [dbo].[Drilo_Siniestro]    Script Date: 04/15/2018 01:56:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Drilo_Siniestro]') AND type in (N'U'))
DROP TABLE [dbo].[Drilo_Siniestro]
GO

USE [Central]
GO

/****** Object:  Table [dbo].[Drilo_Siniestro_tercero]    Script Date: 04/15/2018 01:56:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Drilo_Siniestro_tercero](
	[id] [int] NOT NULL,
	[siniestro_id] [int] NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[email] [varchar](60) NOT NULL,
	[patente] [varchar](20) NOT NULL,
	[marcas] [varchar](MAX) NOT NULL,
	[modelo] [varchar](150) NOT NULL,
	[ano] [int] NOT NULL,
 CONSTRAINT [tercero_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [Central]
GO

/****** Object:  Table [dbo].[Drilo_Siniestro_foto]    Script Date: 04/15/2018 01:56:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Drilo_Siniestro_foto](
	[id] [int] NOT NULL,
	[siniestro_id] [int] NOT NULL,
	[path] [varchar](255) NOT NULL,
 CONSTRAINT [foto_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [Central]
GO

/****** Object:  Table [dbo].[Drilo_Siniestro]    Script Date: 04/15/2018 01:56:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Drilo_Siniestro](
	[id] [int] NOT NULL,
	[id_empresa] [int] NULL,
	[patente] [varchar](20) NULL,
	[email] [varchar](60) NULL,
	[denunciante_nombre] [varchar](255) NOT NULL,
	[denunciante_rut] [varchar](15) NOT NULL,
	[denunciante_nacionalidad] [varchar](30) NOT NULL,
	[denunciante_domicilio] [varchar](255) NOT NULL,
	[denunciante_comuna] [varchar](60) NOT NULL,
	[siniestro_fecha] [date] NOT NULL,
	[siniestro_hora] [time](7) NOT NULL,
	[siniestro_direccion] [varchar](255) NOT NULL,
	[siniestro_ciudad] [varchar](60) NOT NULL,
	[siniestro_tipo] [varchar](30) NOT NULL,
	[sinitro_tipo_otro] [varchar](60) NOT NULL,
	[siniestro_accion] [varchar](30) NOT NULL,
	[siniestro_relato] [varchar](MAX) NOT NULL,
	[siniestro_dano] [varchar](MAX) NOT NULL,
	[ci_archivo] [varchar](255) NOT NULL,
	[licencia_archivo] [varchar](255) NOT NULL,
	[lesionados] [bit] NOT NULL,
	[unidad_polocial] [varchar](255) NOT NULL,
	[fecha_aviso] [date] NOT NULL,
	[hora_aviso] [time](7) NOT NULL,
	[num_parte] [varchar](20) NOT NULL,
	[num_folio] [varchar](20) NOT NULL,
	[num_constancia] [varchar](20) NOT NULL,
	[citacion] [bit] NOT NULL,
	[citacion_fecha] [date] NOT NULL,
	[juzgado] [varchar](150) NOT NULL,
	[constancia_archivo] [varchar](20) NOT NULL,
 CONSTRAINT [siniestro_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Drilo_Siniestro_tercero]  WITH CHECK ADD  CONSTRAINT [FK_Drilo_Siniestro_tercero_Drilo_Siniestro] FOREIGN KEY([siniestro_id])
REFERENCES [dbo].[Drilo_Siniestro] ([id])
GO

ALTER TABLE [dbo].[Drilo_Siniestro_tercero] CHECK CONSTRAINT [FK_Drilo_Siniestro_tercero_Drilo_Siniestro]
GO

ALTER TABLE [dbo].[Drilo_Siniestro_foto]  WITH CHECK ADD  CONSTRAINT [FK_Drilo_Siniestro_foto_Drilo_Siniestro] FOREIGN KEY([id])
REFERENCES [dbo].[Drilo_Siniestro] ([id])
GO

ALTER TABLE [dbo].[Drilo_Siniestro_foto] CHECK CONSTRAINT [FK_Drilo_Siniestro_foto_Drilo_Siniestro]
GO

