USE [master]
GO
/****** Object:  Database [geal]    Script Date: 29/04/2020 18:30:25 ******/
CREATE DATABASE [geal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'geal', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\geal.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'geal_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\geal_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [geal] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [geal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [geal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [geal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [geal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [geal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [geal] SET ARITHABORT OFF 
GO
ALTER DATABASE [geal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [geal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [geal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [geal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [geal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [geal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [geal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [geal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [geal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [geal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [geal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [geal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [geal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [geal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [geal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [geal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [geal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [geal] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [geal] SET  MULTI_USER 
GO
ALTER DATABASE [geal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [geal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [geal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [geal] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [geal]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[RutCliente] [varchar](12) NOT NULL,
	[NombreCliente] [varchar](50) NULL,
	[Contacto1] [varchar](100) NULL,
	[Fono1] [varchar](50) NULL,
	[Correo1] [varchar](60) NULL,
	[Contacto2] [varchar](100) NULL,
	[Fono2] [varchar](50) NULL,
	[Correo2] [varchar](50) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[RutCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[RutEmpresa] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[RutEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FotoEmpresa]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FotoEmpresa](
	[IdFotoEmp] [int] IDENTITY(1,1) NOT NULL,
	[NombreImagen] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Imagen] [image] NULL,
	[RutEmpresa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FotoEmpresa] PRIMARY KEY CLUSTERED 
(
	[IdFotoEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FotoProyecto]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FotoProyecto](
	[IdFotoPro] [int] IDENTITY(1,1) NOT NULL,
	[NombreImagen] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Imagen] [image] NULL,
	[IdProyecto] [int] NOT NULL,
 CONSTRAINT [PK_FotoProyecto] PRIMARY KEY CLUSTERED 
(
	[IdFotoPro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FotoServicio]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FotoServicio](
	[IdFotoServ] [int] IDENTITY(1,1) NOT NULL,
	[NombreImagen] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Imagen] [image] NULL,
	[IdServicio] [int] NOT NULL,
 CONSTRAINT [PK_FotoServicio] PRIMARY KEY CLUSTERED 
(
	[IdFotoServ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProyecto] [varchar](50) NULL,
	[DescripcionPro] [varchar](300) NULL,
	[RutCliente] [varchar](12) NOT NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Servicio](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[NombreServicio] [varchar](100) NULL,
	[DescripcionServicio] [varchar](200) NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/04/2020 18:30:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Correo] [varchar](50) NULL,
	[Contrasena] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[FotoEmpresa]  WITH CHECK ADD  CONSTRAINT [FK_FotoEmpresa_Empresa] FOREIGN KEY([RutEmpresa])
REFERENCES [dbo].[Empresa] ([RutEmpresa])
GO
ALTER TABLE [dbo].[FotoEmpresa] CHECK CONSTRAINT [FK_FotoEmpresa_Empresa]
GO
ALTER TABLE [dbo].[FotoProyecto]  WITH CHECK ADD  CONSTRAINT [FK_FotoProyecto_Proyecto] FOREIGN KEY([IdProyecto])
REFERENCES [dbo].[Proyecto] ([IdProyecto])
GO
ALTER TABLE [dbo].[FotoProyecto] CHECK CONSTRAINT [FK_FotoProyecto_Proyecto]
GO
ALTER TABLE [dbo].[FotoServicio]  WITH CHECK ADD  CONSTRAINT [FK_FotoServicio_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[FotoServicio] CHECK CONSTRAINT [FK_FotoServicio_Servicio]
GO
ALTER TABLE [dbo].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_Cliente] FOREIGN KEY([RutCliente])
REFERENCES [dbo].[Cliente] ([RutCliente])
GO
ALTER TABLE [dbo].[Proyecto] CHECK CONSTRAINT [FK_Proyecto_Cliente]
GO
USE [master]
GO
ALTER DATABASE [geal] SET  READ_WRITE 
GO
