USE [master]
GO
/****** Object:  Database [PerpusDB]    Script Date: 23/12/2020 17:55:04 ******/
CREATE DATABASE [PerpusDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PerpusDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PerpusDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PerpusDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\PerpusDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PerpusDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PerpusDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PerpusDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PerpusDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PerpusDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PerpusDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PerpusDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PerpusDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PerpusDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PerpusDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PerpusDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PerpusDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PerpusDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PerpusDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PerpusDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PerpusDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PerpusDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PerpusDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PerpusDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PerpusDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PerpusDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PerpusDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PerpusDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PerpusDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PerpusDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PerpusDB] SET  MULTI_USER 
GO
ALTER DATABASE [PerpusDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PerpusDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PerpusDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PerpusDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PerpusDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PerpusDB] SET QUERY_STORE = OFF
GO
USE [PerpusDB]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 23/12/2020 17:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Author] [nvarchar](100) NULL,
	[PublishedDate] [date] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowBook]    Script Date: 23/12/2020 17:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[BorrowDate] [date] NULL,
	[ReturnDate] [date] NULL,
 CONSTRAINT [PK_BorrowBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 23/12/2020 17:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](200) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Book_Author]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_Book_Author] ON [dbo].[Book]
(
	[Author] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Book_Author_Title]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_Book_Author_Title] ON [dbo].[Book]
(
	[Author] ASC,
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Book_Title]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_Book_Title] ON [dbo].[Book]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BorrowBook_Book]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_BorrowBook_Book] ON [dbo].[BorrowBook]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BorrowBook_BookMember]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_BorrowBook_BookMember] ON [dbo].[BorrowBook]
(
	[BookId] ASC,
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BorrowBook_Member]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_BorrowBook_Member] ON [dbo].[BorrowBook]
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Member_Name]    Script Date: 23/12/2020 17:55:04 ******/
CREATE NONCLUSTERED INDEX [IX_Member_Name] ON [dbo].[Member]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
USE [master]
GO
ALTER DATABASE [PerpusDB] SET  READ_WRITE 
GO