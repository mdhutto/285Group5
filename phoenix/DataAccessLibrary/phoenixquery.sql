/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [master]
GO
/****** Object:  Database [phoenix2]    Script Date: 9/24/2017 1:18:03 AM ******/
CREATE DATABASE [phoenix2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'phoenix2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\phoenix2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'phoenix2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\phoenix2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [phoenix2] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [phoenix2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [phoenix2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [phoenix2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [phoenix2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [phoenix2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [phoenix2] SET ARITHABORT OFF 
GO
ALTER DATABASE [phoenix2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [phoenix2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [phoenix2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [phoenix2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [phoenix2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [phoenix2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [phoenix2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [phoenix2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [phoenix2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [phoenix2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [phoenix2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [phoenix2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [phoenix2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [phoenix2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [phoenix2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [phoenix2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [phoenix2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [phoenix2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [phoenix2] SET  MULTI_USER 
GO
ALTER DATABASE [phoenix2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [phoenix2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [phoenix2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [phoenix2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [phoenix2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [phoenix2] SET QUERY_STORE = OFF
GO
USE [phoenix2]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [phoenix2]
GO
/****** Object:  Table [dbo].[attendance]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[attendance](
	[meetingId] [int] NOT NULL,
	[memberId] [int] NOT NULL,
	[attendBool] [bit] NOT NULL,
 CONSTRAINT [PK_attendance] PRIMARY KEY CLUSTERED 
(
	[meetingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[face2faces]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[face2faces](
	[formId] [int] NOT NULL,
	[location] [varchar](50) NOT NULL,
	[metId1] [int] NOT NULL,
	[metId2] [int] NOT NULL,
	[metId3] [int] NULL,
	[metId4] [int] NULL,
 CONSTRAINT [PK_face2faces] PRIMARY KEY CLUSTERED 
(
	[formId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[forms]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[forms](
	[formId] [int] IDENTITY(1,1) NOT NULL,
	[formType] [varchar](15) NOT NULL,
	[formDate] [date] NOT NULL,
 CONSTRAINT [PK_forms] PRIMARY KEY CLUSTERED 
(
	[formId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[heresthemoneys]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[heresthemoneys](
	[formId] [int] NOT NULL,
	[referralFormId] [int] NULL,
	[client] [varchar](50) NOT NULL,
	[income] [money] NOT NULL,
 CONSTRAINT [PK_heresthemoneys] PRIMARY KEY CLUSTERED 
(
	[formId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[meetings]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[meetings](
	[meetingId] [int] IDENTITY(1,1) NOT NULL,
	[meetingDate] [date] NOT NULL,
	[speaker] [varchar](50) NULL,
 CONSTRAINT [PK_meetings] PRIMARY KEY CLUSTERED 
(
	[meetingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[members]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[members](
	[memberId] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](max) NOT NULL,
	[userPw] [varchar](max) NOT NULL,
	[first] [varchar](20) NOT NULL,
	[last] [varchar](20) NOT NULL,
	[photo] [varbinary](max) NULL,
	[company] [varchar](50) NULL,
	[profession] [varchar](20) NULL,
	[phone] [varchar](10) NOT NULL,
	[email] [varchar](100) NULL,
	[website] [varchar](50) NULL,
	[memberSince] [date] NOT NULL,
	[absenceCount] [int] NOT NULL,
	[adminBool] [bit] NOT NULL,
	[activeBool] [bit] NOT NULL,
 CONSTRAINT [PK_members] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nonmember_data]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nonmember_data](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[formId] [int] NOT NULL,
	[nonMemberInfo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_nonmember_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[referrals]    Script Date: 9/24/2017 1:18:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[referrals](
	[formId] [int] NOT NULL,
	[senderId] [int] NOT NULL,
	[senderIsMemberBool] [bit] NULL,
	[recipientId] [int] NOT NULL,
	[client] [varchar](50) NOT NULL,
	[businessCardBool] [bit] NOT NULL,
	[callClientBool] [bit] NOT NULL,
	[clientContact] [varchar](50) NULL,
	[comments] [varchar](500) NULL,
 CONSTRAINT [PK_referrals] PRIMARY KEY CLUSTERED 
(
	[formId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[attendance]  WITH CHECK ADD  CONSTRAINT [FK_attendance_meetings] FOREIGN KEY([meetingId])
REFERENCES [dbo].[meetings] ([meetingId])
GO
ALTER TABLE [dbo].[attendance] CHECK CONSTRAINT [FK_attendance_meetings]
GO
ALTER TABLE [dbo].[attendance]  WITH CHECK ADD  CONSTRAINT [FK_attendance_members] FOREIGN KEY([memberId])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[attendance] CHECK CONSTRAINT [FK_attendance_members]
GO
ALTER TABLE [dbo].[face2faces]  WITH CHECK ADD  CONSTRAINT [FK_face2faces_forms] FOREIGN KEY([formId])
REFERENCES [dbo].[forms] ([formId])
GO
ALTER TABLE [dbo].[face2faces] CHECK CONSTRAINT [FK_face2faces_forms]
GO
ALTER TABLE [dbo].[face2faces]  WITH CHECK ADD  CONSTRAINT [FK_face2faces_members] FOREIGN KEY([metId1])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[face2faces] CHECK CONSTRAINT [FK_face2faces_members]
GO
ALTER TABLE [dbo].[face2faces]  WITH CHECK ADD  CONSTRAINT [FK_face2faces_members1] FOREIGN KEY([metId2])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[face2faces] CHECK CONSTRAINT [FK_face2faces_members1]
GO
ALTER TABLE [dbo].[face2faces]  WITH CHECK ADD  CONSTRAINT [FK_face2faces_members2] FOREIGN KEY([metId3])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[face2faces] CHECK CONSTRAINT [FK_face2faces_members2]
GO
ALTER TABLE [dbo].[face2faces]  WITH CHECK ADD  CONSTRAINT [FK_face2faces_members3] FOREIGN KEY([metId4])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[face2faces] CHECK CONSTRAINT [FK_face2faces_members3]
GO
ALTER TABLE [dbo].[heresthemoneys]  WITH CHECK ADD  CONSTRAINT [FK_heresthemoneys_forms] FOREIGN KEY([formId])
REFERENCES [dbo].[forms] ([formId])
GO
ALTER TABLE [dbo].[heresthemoneys] CHECK CONSTRAINT [FK_heresthemoneys_forms]
GO
ALTER TABLE [dbo].[heresthemoneys]  WITH CHECK ADD  CONSTRAINT [FK_heresthemoneys_referrals] FOREIGN KEY([referralFormId])
REFERENCES [dbo].[referrals] ([formId])
GO
ALTER TABLE [dbo].[heresthemoneys] CHECK CONSTRAINT [FK_heresthemoneys_referrals]
GO
ALTER TABLE [dbo].[nonmember_data]  WITH CHECK ADD  CONSTRAINT [FK_nonmember_data_referrals] FOREIGN KEY([formId])
REFERENCES [dbo].[referrals] ([formId])
GO
ALTER TABLE [dbo].[nonmember_data] CHECK CONSTRAINT [FK_nonmember_data_referrals]
GO
ALTER TABLE [dbo].[referrals]  WITH CHECK ADD  CONSTRAINT [FK_referrals_forms] FOREIGN KEY([formId])
REFERENCES [dbo].[forms] ([formId])
GO
ALTER TABLE [dbo].[referrals] CHECK CONSTRAINT [FK_referrals_forms]
GO
ALTER TABLE [dbo].[referrals]  WITH CHECK ADD  CONSTRAINT [FK_referrals_members] FOREIGN KEY([senderId])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[referrals] CHECK CONSTRAINT [FK_referrals_members]
GO
ALTER TABLE [dbo].[referrals]  WITH CHECK ADD  CONSTRAINT [FK_referrals_members1] FOREIGN KEY([recipientId])
REFERENCES [dbo].[members] ([memberId])
GO
ALTER TABLE [dbo].[referrals] CHECK CONSTRAINT [FK_referrals_members1]
GO
USE [master]
GO
ALTER DATABASE [phoenix2] SET  READ_WRITE 
GO
