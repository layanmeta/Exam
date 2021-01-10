USE [master]
GO
/****** Object:  Database [partThree]    Script Date: 10/01/2021 22:12:08 ******/
CREATE DATABASE [partThree]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'partThree', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\partThree.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'partThree_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\partThree_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [partThree] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [partThree].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [partThree] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [partThree] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [partThree] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [partThree] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [partThree] SET ARITHABORT OFF 
GO
ALTER DATABASE [partThree] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [partThree] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [partThree] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [partThree] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [partThree] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [partThree] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [partThree] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [partThree] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [partThree] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [partThree] SET  DISABLE_BROKER 
GO
ALTER DATABASE [partThree] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [partThree] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [partThree] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [partThree] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [partThree] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [partThree] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [partThree] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [partThree] SET RECOVERY FULL 
GO
ALTER DATABASE [partThree] SET  MULTI_USER 
GO
ALTER DATABASE [partThree] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [partThree] SET DB_CHAINING OFF 
GO
ALTER DATABASE [partThree] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [partThree] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [partThree] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [partThree] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'partThree', N'ON'
GO
ALTER DATABASE [partThree] SET QUERY_STORE = OFF
GO
USE [partThree]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 10/01/2021 22:12:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[District_ID] [bigint] NULL,
	[Mayor] [varchar](50) NULL,
	[Population] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Districts]    Script Date: 10/01/2021 22:12:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[DistrictID] [bigint] IDENTITY(1,1) NOT NULL,
	[DistrictName] [text] NULL,
	[Population] [int] NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Districts] FOREIGN KEY([District_ID])
REFERENCES [dbo].[Districts] ([DistrictID])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Districts]
GO
USE [master]
GO
ALTER DATABASE [partThree] SET  READ_WRITE 
GO
