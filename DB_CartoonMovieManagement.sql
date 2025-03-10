USE [master]
GO
/****** Object:  Database [CartoonProductManagement]    Script Date: 9/7/2024 9:21:50 AM ******/
CREATE DATABASE [CartoonProductManagement]
GO
ALTER DATABASE [CartoonProductManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CartoonProductManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CartoonProductManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CartoonProductManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CartoonProductManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CartoonProductManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CartoonProductManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CartoonProductManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CartoonProductManagement] SET  MULTI_USER 
GO
ALTER DATABASE [CartoonProductManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CartoonProductManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CartoonProductManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CartoonProductManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CartoonProductManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CartoonProductManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CartoonProductManagement', N'ON'
GO
ALTER DATABASE [CartoonProductManagement] SET QUERY_STORE = OFF
GO
USE [CartoonProductManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartoonMovie]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartoonMovie](
	[CartoonMovieId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[ReleasedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK_CartoonMovie] PRIMARY KEY CLUSTERED 
(
	[CartoonMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[CategoryParentId] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cooperator]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cooperator](
	[CooperatorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Cooperate] PRIMARY KEY CLUSTERED 
(
	[CooperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [varchar](250) NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NULL,
	[Date of birth] [date] NULL,
	[SocialMediaLink] [varchar](250) NULL,
	[Avatar] [varchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[Salary] [money] NOT NULL,
	[DepartmentId] [int] NULL,
	[StudioId] [int] NULL,
	[Citizen Identification] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeHistory]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeHistory](
	[EmployeeHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProfilePaper] PRIMARY KEY CLUSTERED 
(
	[EmployeeHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EpisodeMovie]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EpisodeMovie](
	[EpisodeMovieId] [int] IDENTITY(1,1) NOT NULL,
	[CartoonMovieId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[isActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[ReleasedDate] [datetime] NULL,
	[MovieLink] [varchar](250) NULL,
	[Duration] [int] NULL,
 CONSTRAINT [PK_EpisodeMovie] PRIMARY KEY CLUSTERED 
(
	[EpisodeMovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[CreaterId] [int] NOT NULL,
	[ReceiverId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[ReadedDate] [datetime] NULL,
	[Message] [nvarchar](max) NOT NULL,
	[NotificationType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[Create] [bit] NOT NULL,
	[Read] [bit] NOT NULL,
	[Update] [bit] NOT NULL,
	[Delete] [bit] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[CategoryId] [int] NOT NULL,
	[Budget] [money] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project_Cooperator]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project_Cooperator](
	[Project_CooperatorId] [int] IDENTITY(1,1) NOT NULL,
	[CooperatorId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK_Project_Cooperator] PRIMARY KEY CLUSTERED 
(
	[Project_CooperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryChangeLog]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryChangeLog](
	[SalaryChangeLogId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Change] [money] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_SalaryChangeLog] PRIMARY KEY CLUSTERED 
(
	[SalaryChangeLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ForAdmin] [bit] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studio]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studio](
	[StudioId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Studio] PRIMARY KEY CLUSTERED 
(
	[StudioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudioDevice]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudioDevice](
	[DeviceId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[isOwner] [bit] NOT NULL,
	[MoneyValue] [money] NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
	[AssignedDate] [datetime] NULL,
	[DeadlineDate] [datetime] NOT NULL,
	[CreaterId] [int] NOT NULL,
	[ReceiverId] [int] NULL,
	[StatusId] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[ResourceLink] [varchar](max) NULL,
	[SubmitLink] [varchar](max) NULL,
	[EpisodeMovieId] [int] NOT NULL,
	[Cost] [money] NULL,
	[TaskParentId] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskHistoryLog]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskHistoryLog](
	[TaskHistoryLogId] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[LogAction] [nvarchar](max) NULL,
	[UpdatedDate] [datetime] NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[EpisodeName] [nvarchar](max) NULL,
	[ReceiverName] [nvarchar](max) NULL,
	[DeadlineDate] [datetime] NULL,
	[SubmitedDate] [datetime] NULL,
	[ResourceLink] [nvarchar](max) NULL,
	[SubmitLink] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_TaskHistoryLog] PRIMARY KEY CLUSTERED 
(
	[TaskHistoryLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLoginLog]    Script Date: 9/7/2024 9:21:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLoginLog](
	[LoginLogId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[IpAddress] [varchar](max) NOT NULL,
	[UserAgent] [varchar](max) NOT NULL,
	[LoginTime] [datetime] NOT NULL,
	[Country] [varchar](250) NOT NULL,
	[Region] [varchar](250) NOT NULL,
	[City] [varchar](250) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[TimeZone] [varchar](250) NOT NULL,
 CONSTRAINT [PK_UserLoginLog] PRIMARY KEY CLUSTERED 
(
	[LoginLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [Email], [Password], [CreatedDate], [DeletedDate], [isActive], [RoleId], [EmployeeId]) VALUES (2, N'admin', N'123', CAST(N'2024-07-08T00:00:00.000' AS DateTime), NULL, 1, 1, 1)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [CreatedDate], [DeletedDate], [isActive], [RoleId], [EmployeeId]) VALUES (3, N'employee1', N'123', CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, 1, 3, 2)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [CreatedDate], [DeletedDate], [isActive], [RoleId], [EmployeeId]) VALUES (5, N'employee2', N'123', CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, 1, 2, 4)
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [CreatedDate], [DeletedDate], [isActive], [RoleId], [EmployeeId]) VALUES (6, N'employee3', N'123', CAST(N'2024-08-22T15:45:33.023' AS DateTime), NULL, 0, 2, 5)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[CartoonMovie] ON 

INSERT [dbo].[CartoonMovie] ([CartoonMovieId], [Name], [Description], [ProjectId], [CreatedDate], [DeletedDate], [ReleasedDate], [isActive]) VALUES (1, N'First Movie', N'1st', 1, CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, CAST(N'2024-08-30T11:11:39.190' AS DateTime), 0)
INSERT [dbo].[CartoonMovie] ([CartoonMovieId], [Name], [Description], [ProjectId], [CreatedDate], [DeletedDate], [ReleasedDate], [isActive]) VALUES (2, N'Second Movie', N'', 1, CAST(N'2024-08-12T13:55:34.970' AS DateTime), CAST(N'2024-08-13T15:19:36.847' AS DateTime), CAST(N'2024-08-12T13:55:34.973' AS DateTime), 0)
INSERT [dbo].[CartoonMovie] ([CartoonMovieId], [Name], [Description], [ProjectId], [CreatedDate], [DeletedDate], [ReleasedDate], [isActive]) VALUES (3, N'First', N'', 3, CAST(N'2024-08-13T15:55:55.977' AS DateTime), CAST(N'2024-08-13T15:56:25.343' AS DateTime), CAST(N'2024-08-13T15:55:55.977' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[CartoonMovie] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Name], [Description], [CreatedDate], [DeletedDate], [isActive], [CategoryParentId]) VALUES (1, N'3D Cartoon', NULL, CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, 1, NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Description], [CreatedDate], [DeletedDate], [isActive], [CategoryParentId]) VALUES (2, N'2D Cartoon Art', N'', CAST(N'2024-08-21T09:38:27.693' AS DateTime), CAST(N'2024-08-21T09:51:48.890' AS DateTime), 1, NULL)
INSERT [dbo].[Category] ([CategoryId], [Name], [Description], [CreatedDate], [DeletedDate], [isActive], [CategoryParentId]) VALUES (3, N'Children Cartoon', N'', CAST(N'2024-08-21T09:43:46.307' AS DateTime), NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [Name], [Description]) VALUES (1, N'Director', NULL)
INSERT [dbo].[Department] ([DepartmentId], [Name], [Description]) VALUES (2, N'Model', NULL)
INSERT [dbo].[Department] ([DepartmentId], [Name], [Description]) VALUES (5, N'Animation', N'')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [FullName], [Email], [PhoneNumber], [Gender], [Date of birth], [SocialMediaLink], [Avatar], [CreatedDate], [DeletedDate], [Salary], [DepartmentId], [StudioId], [Citizen Identification]) VALUES (1, N'admin', N'admin', N'0373392001', N'Male', CAST(N'1900-01-01' AS Date), N'#', NULL, CAST(N'2024-08-05T00:00:00.000' AS DateTime), NULL, 0.0000, NULL, NULL, N'0')
INSERT [dbo].[Employee] ([EmployeeId], [FullName], [Email], [PhoneNumber], [Gender], [Date of birth], [SocialMediaLink], [Avatar], [CreatedDate], [DeletedDate], [Salary], [DepartmentId], [StudioId], [Citizen Identification]) VALUES (2, N'Employee1', N'employee1@gmail.com', N'123', N'Male', CAST(N'1900-01-01' AS Date), N'#', NULL, CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, 200.0000, 1, 1, N'0')
INSERT [dbo].[Employee] ([EmployeeId], [FullName], [Email], [PhoneNumber], [Gender], [Date of birth], [SocialMediaLink], [Avatar], [CreatedDate], [DeletedDate], [Salary], [DepartmentId], [StudioId], [Citizen Identification]) VALUES (4, N'Employee2', N'employee2@gmail.com', N'12345', N'Male', CAST(N'1900-01-01' AS Date), N'#', N'451e63d8-43e3-4ce7-8866-5ebd15f35012.jpg', CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, 200.0000, 1, 1, N'012345678910')
INSERT [dbo].[Employee] ([EmployeeId], [FullName], [Email], [PhoneNumber], [Gender], [Date of birth], [SocialMediaLink], [Avatar], [CreatedDate], [DeletedDate], [Salary], [DepartmentId], [StudioId], [Citizen Identification]) VALUES (5, N'Employee3', N'employee3@gmail.com', N'123', N'Male', CAST(N'2024-08-22' AS Date), N'#', NULL, CAST(N'2024-08-22T13:31:40.503' AS DateTime), NULL, 0.0000, 1, 1, N'012345678910')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EpisodeMovie] ON 

INSERT [dbo].[EpisodeMovie] ([EpisodeMovieId], [CartoonMovieId], [Name], [Description], [isActive], [CreatedDate], [DeletedDate], [ReleasedDate], [MovieLink], [Duration]) VALUES (1, 1, N'First Episode', N'1st', 0, CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, CAST(N'2024-08-30T11:11:54.313' AS DateTime), NULL, NULL)
INSERT [dbo].[EpisodeMovie] ([EpisodeMovieId], [CartoonMovieId], [Name], [Description], [isActive], [CreatedDate], [DeletedDate], [ReleasedDate], [MovieLink], [Duration]) VALUES (2, 1, N'Second Episode', N'', 0, CAST(N'2024-08-12T09:44:38.353' AS DateTime), NULL, CAST(N'2024-08-12T16:35:54.970' AS DateTime), N'videoplayback (2).mp4', 94)
INSERT [dbo].[EpisodeMovie] ([EpisodeMovieId], [CartoonMovieId], [Name], [Description], [isActive], [CreatedDate], [DeletedDate], [ReleasedDate], [MovieLink], [Duration]) VALUES (3, 1, N'Thirh Episode', N'', 0, CAST(N'2024-08-12T09:56:59.373' AS DateTime), NULL, CAST(N'2024-08-12T16:35:15.073' AS DateTime), N'videoplayback (4).mp4', 136)
INSERT [dbo].[EpisodeMovie] ([EpisodeMovieId], [CartoonMovieId], [Name], [Description], [isActive], [CreatedDate], [DeletedDate], [ReleasedDate], [MovieLink], [Duration]) VALUES (4, 1, N'Fourth Episode', N'', 0, CAST(N'2024-08-12T10:09:07.747' AS DateTime), CAST(N'2024-08-13T15:38:20.783' AS DateTime), CAST(N'2024-08-12T16:34:26.773' AS DateTime), N'videoplayback (3).mp4', 545)
INSERT [dbo].[EpisodeMovie] ([EpisodeMovieId], [CartoonMovieId], [Name], [Description], [isActive], [CreatedDate], [DeletedDate], [ReleasedDate], [MovieLink], [Duration]) VALUES (5, 1, N'Firth Episode', N'5th', 0, CAST(N'2024-08-12T10:44:09.280' AS DateTime), CAST(N'2024-08-13T15:20:19.240' AS DateTime), CAST(N'2024-08-12T16:33:58.450' AS DateTime), N'videoplayback (1).mp4', 68)
INSERT [dbo].[EpisodeMovie] ([EpisodeMovieId], [CartoonMovieId], [Name], [Description], [isActive], [CreatedDate], [DeletedDate], [ReleasedDate], [MovieLink], [Duration]) VALUES (6, 2, N'First Episode', N'', 0, CAST(N'2024-08-12T15:15:49.683' AS DateTime), CAST(N'2024-08-13T16:00:54.643' AS DateTime), CAST(N'2024-08-12T16:14:50.137' AS DateTime), N'videoplayback.mp4', 108)
SET IDENTITY_INSERT [dbo].[EpisodeMovie] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([PermissionId], [RoleId], [TypeId], [Create], [Read], [Update], [Delete]) VALUES (1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[Permission] ([PermissionId], [RoleId], [TypeId], [Create], [Read], [Update], [Delete]) VALUES (2, 2, 1, 0, 1, 0, 0)
INSERT [dbo].[Permission] ([PermissionId], [RoleId], [TypeId], [Create], [Read], [Update], [Delete]) VALUES (3, 3, 1, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [Name], [Description], [CreatedDate], [DeletedDate], [CategoryId], [Budget]) VALUES (1, N'First Project', N'1', CAST(N'2024-08-30T10:59:11.977' AS DateTime), NULL, 1, 0.0000)
INSERT [dbo].[Project] ([ProjectId], [Name], [Description], [CreatedDate], [DeletedDate], [CategoryId], [Budget]) VALUES (2, N'Second Project', N'the second project', CAST(N'2024-08-08T14:14:58.657' AS DateTime), NULL, 1, 0.0000)
INSERT [dbo].[Project] ([ProjectId], [Name], [Description], [CreatedDate], [DeletedDate], [CategoryId], [Budget]) VALUES (3, N'Third Project', N'third', CAST(N'2024-08-09T14:21:51.250' AS DateTime), CAST(N'2024-08-13T15:56:25.280' AS DateTime), 1, 0.0000)
INSERT [dbo].[Project] ([ProjectId], [Name], [Description], [CreatedDate], [DeletedDate], [CategoryId], [Budget]) VALUES (4, N'Fourth Project', N'minh quan', CAST(N'2024-08-13T11:58:52.903' AS DateTime), CAST(N'2024-08-13T15:10:04.263' AS DateTime), 1, 0.0000)
INSERT [dbo].[Project] ([ProjectId], [Name], [Description], [CreatedDate], [DeletedDate], [CategoryId], [Budget]) VALUES (5, N'A Project', N'', CAST(N'2024-08-15T15:16:19.797' AS DateTime), NULL, 1, 0.0000)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (1, N'Admin', N'Adminator')
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (2, N'Employee', NULL)
INSERT [dbo].[Role] ([RoleId], [Name], [Description]) VALUES (3, N'Leader', N'Leader Employee')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[SalaryChangeLog] ON 

INSERT [dbo].[SalaryChangeLog] ([SalaryChangeLogId], [EmployeeId], [Change], [CreatedDate], [AccountId], [Note]) VALUES (1, 4, 100.0000, CAST(N'2024-08-16T15:08:40.913' AS DateTime), 2, N'good')
INSERT [dbo].[SalaryChangeLog] ([SalaryChangeLogId], [EmployeeId], [Change], [CreatedDate], [AccountId], [Note]) VALUES (2, 4, -100.0000, CAST(N'2024-08-16T15:09:04.763' AS DateTime), 2, N'bad')
INSERT [dbo].[SalaryChangeLog] ([SalaryChangeLogId], [EmployeeId], [Change], [CreatedDate], [AccountId], [Note]) VALUES (3, 2, 100.0000, CAST(N'2024-08-16T15:12:35.743' AS DateTime), 2, N'')
SET IDENTITY_INSERT [dbo].[SalaryChangeLog] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusId], [Name], [Description], [ForAdmin]) VALUES (1, N'On Going', N'On Going', 0)
INSERT [dbo].[Status] ([StatusId], [Name], [Description], [ForAdmin]) VALUES (2, N'Finish', N'Finish', 0)
INSERT [dbo].[Status] ([StatusId], [Name], [Description], [ForAdmin]) VALUES (3, N'Not Start', N'Not Start', 1)
INSERT [dbo].[Status] ([StatusId], [Name], [Description], [ForAdmin]) VALUES (6, N'Approved', N'Approved', 1)
INSERT [dbo].[Status] ([StatusId], [Name], [Description], [ForAdmin]) VALUES (7, N'Wait for Register', N'Wait for Register', 1)
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Studio] ON 

INSERT [dbo].[Studio] ([StudioId], [Name], [Description]) VALUES (1, N'Studio1', NULL)
INSERT [dbo].[Studio] ([StudioId], [Name], [Description]) VALUES (2, N'Studio2', NULL)
SET IDENTITY_INSERT [dbo].[Studio] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (3, N'Story', N'Story Movie', CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2024-09-08T00:00:00.000' AS DateTime), 2, 2, 2, N'done', N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', 1, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (4, N'Screen develop', N'', CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2024-10-08T00:00:00.000' AS DateTime), 2, 2, 3, NULL, N'', NULL, 1, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (5, N'Story 1.1', N'', CAST(N'2024-08-12T15:22:39.580' AS DateTime), CAST(N'2024-08-13T15:21:55.127' AS DateTime), NULL, CAST(N'2024-09-28T00:00:00.000' AS DateTime), 2, 2, 3, NULL, N'Sintel_Cover_Durian_Project.jpg', NULL, 1, NULL, 3)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (7, N'First Task', N'1st task 1', CAST(N'2024-08-09T13:37:02.090' AS DateTime), NULL, CAST(N'2024-08-13T10:06:11.587' AS DateTime), CAST(N'2024-08-15T10:26:41.850' AS DateTime), 2, 2, 2, N'done', N'videoplayback (6).mp4', N'videoplayback (7).mp4', 1, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (8, N'Second Task', N'the second 2 2', CAST(N'2024-08-09T13:48:43.500' AS DateTime), NULL, CAST(N'2024-08-15T10:15:32.540' AS DateTime), CAST(N'2024-08-15T10:41:58.803' AS DateTime), 2, 2, 1, NULL, N'The Mancandy FAQ - Rigging - _simple_ sperm - Simple Sperm #3.mp4', NULL, 1, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (9, N'1st', N'', CAST(N'2024-08-13T09:47:33.223' AS DateTime), CAST(N'2024-08-13T16:00:54.717' AS DateTime), CAST(N'2024-08-13T10:34:33.070' AS DateTime), CAST(N'2024-08-13T10:47:08.377' AS DateTime), 2, 2, 1, NULL, N'', NULL, 6, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (10, N'test delete', N'', CAST(N'2024-08-13T15:38:03.790' AS DateTime), CAST(N'2024-08-13T16:02:18.093' AS DateTime), CAST(N'2024-08-13T15:38:03.790' AS DateTime), CAST(N'2024-08-14T15:37:44.890' AS DateTime), 2, 2, 1, NULL, N'', NULL, 4, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (11, N'2st', N'', CAST(N'2024-08-14T15:41:55.317' AS DateTime), CAST(N'2024-08-15T10:24:09.377' AS DateTime), CAST(N'2024-08-14T15:41:55.317' AS DateTime), CAST(N'2024-08-14T16:41:22.840' AS DateTime), 2, 2, 1, NULL, N'', NULL, 2, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (13, N'for emp2', N'', CAST(N'2024-08-14T16:14:40.297' AS DateTime), NULL, NULL, CAST(N'2024-08-24T17:20:27.163' AS DateTime), 2, 4, 3, NULL, N'', NULL, 1, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (14, N'3th', N'the third', CAST(N'2024-08-15T10:23:46.560' AS DateTime), NULL, NULL, CAST(N'2024-08-16T10:23:26.237' AS DateTime), 2, 2, 1, NULL, N'', NULL, 3, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (15, N'story', N'', CAST(N'2024-08-15T17:19:20.807' AS DateTime), NULL, NULL, CAST(N'2024-08-16T17:19:00.950' AS DateTime), 2, 2, 1, NULL, N'', NULL, 3, NULL, NULL)
INSERT [dbo].[Task] ([TaskId], [Name], [Description], [CreatedDate], [DeletedDate], [AssignedDate], [DeadlineDate], [CreaterId], [ReceiverId], [StatusId], [Note], [ResourceLink], [SubmitLink], [EpisodeMovieId], [Cost], [TaskParentId]) VALUES (16, N'Task Register', N'', CAST(N'2024-08-19T15:30:50.250' AS DateTime), NULL, NULL, CAST(N'2024-08-27T23:10:08.307' AS DateTime), 2, 2, 1, NULL, N'', NULL, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskHistoryLog] ON 

INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (1, 8, N'Update', CAST(N'2024-08-15T10:15:32.633' AS DateTime), N'Second Task', N'the second 2 2', N'First Episode', N'Employee1', CAST(N'2024-08-15T10:41:58.803' AS DateTime), CAST(N'2024-08-15T10:15:32.540' AS DateTime), N'The Mancandy FAQ - Rigging - _simple_ sperm - Simple Sperm #3.mp4', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (2, 14, N'Create', CAST(N'2024-08-15T10:23:46.947' AS DateTime), N'3th', N'', N'Thirh Episode', N'Employee1', CAST(N'2024-08-16T10:23:26.237' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (3, 11, N'Delete', CAST(N'2024-08-15T10:24:09.377' AS DateTime), N'2st', N'', N'Second Episode', N'Employee1', CAST(N'2024-08-14T16:41:22.840' AS DateTime), CAST(N'2024-08-14T15:41:55.317' AS DateTime), N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (4, 3, N'Submit', CAST(N'2024-08-15T10:43:49.930' AS DateTime), N'Story', N'Story Movie', N'N/A', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, NULL, N'Finish', N'done ok')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (5, 3, N'Submit', CAST(N'2024-08-15T10:46:21.657' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, NULL, N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (6, 3, N'Submit', CAST(N'2024-08-15T10:48:38.177' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, NULL, N'Finish', N'done ok')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (7, 3, N'Submit', CAST(N'2024-08-15T10:49:02.003' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, NULL, N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (8, 3, N'Submit', CAST(N'2024-08-15T11:02:30.850' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, N'', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (9, 3, N'Submit', CAST(N'2024-08-15T11:05:05.263' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), CAST(N'2024-08-08T00:00:00.000' AS DateTime), NULL, N'Sintel_Cover_Durian_Project.jpg', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (10, 14, N'Update', CAST(N'2024-08-15T11:20:41.600' AS DateTime), N'3th', N'the third', N'Thirh Episode', N'Employee1', CAST(N'2024-08-16T10:23:26.237' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (11, 13, N'Update', CAST(N'2024-08-15T17:15:10.993' AS DateTime), N'for emp2', N'', N'First Episode', N'Employee2', CAST(N'2024-08-15T17:20:27.163' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (12, 4, N'Update', CAST(N'2024-08-15T17:18:09.560' AS DateTime), N'Screen develop', N'', N'First Episode', N'Employee1', CAST(N'2024-10-08T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Not Start', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (13, 4, N'Update', CAST(N'2024-08-15T17:18:48.907' AS DateTime), N'Screen develop', N'', N'First Episode', N'Employee1', CAST(N'2024-10-08T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'Not Start', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (14, 15, N'Create', CAST(N'2024-08-15T17:19:20.837' AS DateTime), N'story', N'', N'Thirh Episode', N'Employee1', CAST(N'2024-08-16T17:19:00.950' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (15, 15, N'Update', CAST(N'2024-08-15T17:19:33.157' AS DateTime), N'story', N'', N'Thirh Episode', N'Employee1', CAST(N'2024-08-16T17:19:00.950' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (16, 5, N'Update', CAST(N'2024-08-16T11:00:56.177' AS DateTime), N'Story 1.1', N'', N'First Episode', N'Employee1', CAST(N'2024-09-28T00:00:00.000' AS DateTime), NULL, N'Sintel_Cover_Durian_Project.jpg', NULL, N'Not Start', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (17, 16, N'Create', CAST(N'2024-08-19T15:30:59.693' AS DateTime), N'Task Register', N'', N'First Episode', NULL, CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'Wait for Register', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (20, 16, N'Request taking', CAST(N'2024-08-20T10:30:51.987' AS DateTime), N'Task Register', N'', N'First Episode', N'Employee1', CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'Wait for Register', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (21, 16, N'Update', CAST(N'2024-08-20T13:26:20.013' AS DateTime), N'Task Register', N'', N'First Episode', NULL, CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'Wait for Register', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (22, 16, N'Update', CAST(N'2024-08-20T13:26:50.050' AS DateTime), N'Task Register', N'', N'First Episode', NULL, CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'Wait for Register', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (23, 16, N'Update', CAST(N'2024-08-20T13:27:07.183' AS DateTime), N'Task Register', N'', N'First Episode', NULL, CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (24, 16, N'Update', CAST(N'2024-08-20T14:05:22.700' AS DateTime), N'Task Register', N'', N'First Episode', NULL, CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'Wait for Register', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (25, 16, N'Update', CAST(N'2024-08-20T15:43:39.997' AS DateTime), N'Task Register', N'', N'First Episode', N'Employee1', CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (26, 16, N'Update', CAST(N'2024-08-20T15:43:54.097' AS DateTime), N'Task Register', N'', N'First Episode', NULL, CAST(N'2024-08-31T15:30:08.307' AS DateTime), NULL, N'', NULL, N'Wait for Register', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (27, 13, N'Update', CAST(N'2024-08-20T15:49:08.277' AS DateTime), N'for emp2', N'', N'First Episode', N'Employee2', CAST(N'2024-08-24T17:20:27.163' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (28, 13, N'Update', CAST(N'2024-08-20T15:52:49.350' AS DateTime), N'for emp2', N'', N'First Episode', N'Employee1', CAST(N'2024-08-24T17:20:27.163' AS DateTime), NULL, N'', NULL, N'Not Start', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (30, 3, N'Update', CAST(N'2024-08-20T16:37:01.047' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Sintel_Cover_Durian_Project.jpg', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (31, 3, N'Update', CAST(N'2024-08-20T16:41:34.377' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Sintel_Cover_Durian_Project.jpg', N'Approved', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (32, 3, N'Update', CAST(N'2024-08-20T16:42:03.367' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Sintel_Cover_Durian_Project.jpg', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (33, 3, N'Update', CAST(N'2024-08-20T16:42:29.457' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Sintel_Cover_Durian_Project.jpg', N'Approved', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (34, 16, N'Update', CAST(N'2024-08-27T22:54:52.720' AS DateTime), N'Task Register', N'', N'First Episode', N'Employee1', CAST(N'2024-08-27T22:56:08.307' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (35, 16, N'Update', CAST(N'2024-08-27T22:55:25.690' AS DateTime), N'Task Register', N'', N'First Episode', N'Employee1', CAST(N'2024-08-27T22:57:08.307' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (36, 16, N'Update', CAST(N'2024-08-27T22:55:40.587' AS DateTime), N'Task Register', N'', N'First Episode', N'Employee1', CAST(N'2024-08-27T22:59:08.307' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (37, 16, N'Update', CAST(N'2024-08-27T23:06:36.363' AS DateTime), N'Task Register', N'', N'First Episode', N'Employee1', CAST(N'2024-08-27T23:10:08.307' AS DateTime), NULL, N'', NULL, N'On Going', NULL)
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (38, 3, N'Submit', CAST(N'2024-08-28T08:51:00.390' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'N/A', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (39, 3, N'Submit', CAST(N'2024-08-30T10:17:39.023' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Blender-Logo-2019.png', N'On Going', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (40, 3, N'Submit', CAST(N'2024-08-30T10:22:59.857' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (41, 3, N'Submit', CAST(N'2024-08-30T10:24:56.983' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'', N'On Going', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (42, 3, N'Submit', CAST(N'2024-08-30T10:27:00.573' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (43, 3, N'Update', CAST(N'2024-08-30T10:32:15.983' AS DateTime), N'Story', N'Story Movie Text', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, NULL, N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (44, 3, N'Update', CAST(N'2024-08-30T10:38:04.820' AS DateTime), N'Story', N'Story Movie Text', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'Sintel_Cover_Durian_Project.jpg', N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (45, 3, N'Update', CAST(N'2024-08-30T10:39:59.147' AS DateTime), N'Story', N'Story Movie Text', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'Sintel_Cover_Durian_Project.jpg', N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (46, 3, N'Update', CAST(N'2024-08-30T10:46:39.190' AS DateTime), N'Story', N'Story Movie Text', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'', N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (47, 3, N'Update', CAST(N'2024-08-30T11:13:27.063' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'', N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (48, 3, N'Update', CAST(N'2024-09-04T09:03:37.820' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'Blender-Logo-2019.png', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (49, 3, N'Submit', CAST(N'2024-09-04T09:04:19.130' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (50, 3, N'Submit', CAST(N'2024-09-04T09:05:09.583' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (51, 3, N'Submit', CAST(N'2024-09-04T09:06:49.510' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'Finish', N'done')
INSERT [dbo].[TaskHistoryLog] ([TaskHistoryLogId], [TaskId], [LogAction], [UpdatedDate], [Name], [Description], [EpisodeName], [ReceiverName], [DeadlineDate], [SubmitedDate], [ResourceLink], [SubmitLink], [Status], [Note]) VALUES (52, 3, N'Submit', CAST(N'2024-09-04T09:15:56.683' AS DateTime), N'Story', N'Story Movie', N'First Episode', N'Employee1', CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL, N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'depositphotos_220767694-stock-photo-handwriting-text-writing-example-concept.jpg', N'Finish', N'done')
SET IDENTITY_INSERT [dbo].[TaskHistoryLog] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([TypeId], [Name], [Description]) VALUES (1, N'Task', N'Task work')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Employee]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role]
GO
ALTER TABLE [dbo].[CartoonMovie]  WITH CHECK ADD  CONSTRAINT [FK_CartoonMovie_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[CartoonMovie] CHECK CONSTRAINT [FK_CartoonMovie_Project]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([CategoryParentId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Studio] FOREIGN KEY([StudioId])
REFERENCES [dbo].[Studio] ([StudioId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Studio]
GO
ALTER TABLE [dbo].[EmployeeHistory]  WITH CHECK ADD  CONSTRAINT [FK_ProfilePaper_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeHistory] CHECK CONSTRAINT [FK_ProfilePaper_Employee]
GO
ALTER TABLE [dbo].[EpisodeMovie]  WITH CHECK ADD  CONSTRAINT [FK_EpisodeMovie_CartoonMovie] FOREIGN KEY([CartoonMovieId])
REFERENCES [dbo].[CartoonMovie] ([CartoonMovieId])
GO
ALTER TABLE [dbo].[EpisodeMovie] CHECK CONSTRAINT [FK_EpisodeMovie_CartoonMovie]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Account] FOREIGN KEY([CreaterId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Account]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Account1] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Account1]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Role]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([TypeId])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Type]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Category]
GO
ALTER TABLE [dbo].[Project_Cooperator]  WITH CHECK ADD  CONSTRAINT [FK_Project_Cooperator_Cooperator] FOREIGN KEY([CooperatorId])
REFERENCES [dbo].[Cooperator] ([CooperatorId])
GO
ALTER TABLE [dbo].[Project_Cooperator] CHECK CONSTRAINT [FK_Project_Cooperator_Cooperator]
GO
ALTER TABLE [dbo].[Project_Cooperator]  WITH CHECK ADD  CONSTRAINT [FK_Project_Cooperator_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Project_Cooperator] CHECK CONSTRAINT [FK_Project_Cooperator_Project]
GO
ALTER TABLE [dbo].[SalaryChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_SalaryChangeLog_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[SalaryChangeLog] CHECK CONSTRAINT [FK_SalaryChangeLog_Account]
GO
ALTER TABLE [dbo].[SalaryChangeLog]  WITH CHECK ADD  CONSTRAINT [FK_SalaryChangeLog_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[SalaryChangeLog] CHECK CONSTRAINT [FK_SalaryChangeLog_Employee]
GO
ALTER TABLE [dbo].[StudioDevice]  WITH CHECK ADD  CONSTRAINT [FK_Device_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[StudioDevice] CHECK CONSTRAINT [FK_Device_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Account] FOREIGN KEY([CreaterId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Account]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Employee] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Employee]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_EpisodeMovie] FOREIGN KEY([EpisodeMovieId])
REFERENCES [dbo].[EpisodeMovie] ([EpisodeMovieId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_EpisodeMovie]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Task] FOREIGN KEY([TaskParentId])
REFERENCES [dbo].[Task] ([TaskId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Task]
GO
ALTER TABLE [dbo].[TaskHistoryLog]  WITH CHECK ADD  CONSTRAINT [FK_TaskHistoryLog_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
GO
ALTER TABLE [dbo].[TaskHistoryLog] CHECK CONSTRAINT [FK_TaskHistoryLog_Task]
GO
ALTER TABLE [dbo].[UserLoginLog]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginLog_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[UserLoginLog] CHECK CONSTRAINT [FK_UserLoginLog_Account]
GO
USE [master]
GO
ALTER DATABASE [CartoonProductManagement] SET  READ_WRITE 
GO
