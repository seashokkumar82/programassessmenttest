USE [master]
GO
/****** Object:  Database [ProgramAssessment]    Script Date: 12-06-2020 19:35:18 ******/
CREATE DATABASE [ProgramAssessment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProgramAssessment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProgramAssessment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProgramAssessment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ProgramAssessment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProgramAssessment] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProgramAssessment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProgramAssessment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProgramAssessment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProgramAssessment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProgramAssessment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProgramAssessment] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProgramAssessment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProgramAssessment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProgramAssessment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProgramAssessment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProgramAssessment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProgramAssessment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProgramAssessment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProgramAssessment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProgramAssessment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProgramAssessment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProgramAssessment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProgramAssessment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProgramAssessment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProgramAssessment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProgramAssessment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProgramAssessment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProgramAssessment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProgramAssessment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProgramAssessment] SET  MULTI_USER 
GO
ALTER DATABASE [ProgramAssessment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProgramAssessment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProgramAssessment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProgramAssessment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProgramAssessment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProgramAssessment] SET QUERY_STORE = OFF
GO
USE [ProgramAssessment]
GO
/****** Object:  Table [dbo].[ProgramAssessments]    Script Date: 12-06-2020 19:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramAssessments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [varchar](100) NOT NULL,
	[CompanyInfo] [varchar](500) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[CandidateProfile] [varchar](500) NOT NULL,
	[AccountInfo] [varchar](500) NOT NULL,
	[FilePath] [varchar](200) NULL,
	[RowUniqueID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProgramAssessments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 12-06-2020 19:35:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Photo] [varchar](500) NULL,
	[FileExtention] [varchar](5) NULL,
	[VideoLink] [varchar](500) NULL,
	[ProgramAssessId] [int] NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ProgramAssessments] ON 

INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (1, N'test job', N'<p>test company</p>', N'<p>test company</p>', N'<p>test candidate</p>', N'<p>test application</p>', N'', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (2, N'test job title for offering services', N'<p>test job title for offering services<br></p>', N'<p>test job title for offering services<br></p>', N'<p>test job title for offering services<br></p>', N'<p>test job title for offering services<br></p>', N'G:\ProgramAssessment\ProgramAssessment', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (3, N'job title is title of job update update 8b1144ab-d365-4201-b2ca-3d55723e8df4', N'<p>job title is title of job <span style="background-color: rgb(255, 255, 0);"><b>update</b></span><br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'\wwwroot\images', N'8b1144ab-d365-4201-b2ca-3d55723e8df4')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (4, N'job title is title of job', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'\wwwroot\images', N'2fd2e060-0891-4435-8ceb-e9700876640d')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (5, N'job title is title of job 2fd2e060-0891-4435-8ceb-e9700876640d', N'<p>job title is title of job&nbsp;<span style="color: rgb(51, 51, 51); font-weight: 700;">2fd2e060-0891-4435-8ceb-e9700876640d</span><br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'', N'7e86d931-e2ae-4ebd-ac8a-c26516f17cf3')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (6, N'job title is title of job job title is title of job', N'<p>job title is title of job<b><u>&nbsp;job title is title of job</u></b><br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'<p>job title is title of job<br></p>', N'\wwwroot\images', N'f2b2d46c-0023-48d4-a028-5a0c47ad978a')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (8, N'Please fill all the fields', N'<p><span style="color: rgb(169, 68, 66); background-color: rgb(242, 222, 222);">Please fill all the fields</span><br></p>', N'<p><span style="color: rgb(169, 68, 66); background-color: rgb(242, 222, 222);">Please fill all the fields</span><br></p>', N'<p><span style="color: rgb(169, 68, 66); background-color: rgb(242, 222, 222);">Please fill all the fields</span><br></p>', N'<p><span style="color: rgb(169, 68, 66); background-color: rgb(242, 222, 222);">Please fill all the fields</span><br></p>', N'\wwwroot\images', N'f97a2cf2-2ea3-40f9-8eb7-618bd298aed3')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (9, N'test 9c8dd410-1e17-4843-91ee-ce4fd3400107', N'<p>test&nbsp;<span style="color: rgb(51, 51, 51); font-weight: 700;">9c8dd410-1e17-4843-91ee-ce4fd3400107</span></p>', N'<p>testtetetest&nbsp;<span style="color: rgb(51, 51, 51); font-weight: 700;">9c8dd410-1e17-4843-91ee-ce4fd3400107</span></p>', N'<p>test&nbsp;<span style="color: rgb(51, 51, 51); font-weight: 700;">9c8dd410-1e17-4843-91ee-ce4fd3400107</span></p>', N'<p>test&nbsp;<span style="color: rgb(51, 51, 51); font-weight: 700;">9c8dd410-1e17-4843-91ee-ce4fd3400107</span></p>', N'\wwwroot\images', N'9c8dd410-1e17-4843-91ee-ce4fd3400107')
INSERT [dbo].[ProgramAssessments] ([Id], [JobTitle], [CompanyInfo], [Description], [CandidateProfile], [AccountInfo], [FilePath], [RowUniqueID]) VALUES (10, N'test', N'<p>test</p>', N'<p>test</p>', N'<p>test</p>', N'<p>test</p>', N'\wwwroot\images', N'05112d28-ef19-45b5-bda2-f2f94878b714')
SET IDENTITY_INSERT [dbo].[ProgramAssessments] OFF
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files] FOREIGN KEY([ProgramAssessId])
REFERENCES [dbo].[ProgramAssessments] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files]
GO
USE [master]
GO
ALTER DATABASE [ProgramAssessment] SET  READ_WRITE 
GO
