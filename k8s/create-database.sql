/****** Object:  Database [Fiap_Hackathon]    Script Date: 28/01/2025 11:55:51 ******/
CREATE DATABASE [Fiap_Hackathon]

ALTER DATABASE [Fiap_Hackathon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fiap_Hackathon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fiap_Hackathon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fiap_Hackathon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fiap_Hackathon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fiap_Hackathon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fiap_Hackathon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Fiap_Hackathon] SET  MULTI_USER 
GO
ALTER DATABASE [Fiap_Hackathon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fiap_Hackathon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fiap_Hackathon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fiap_Hackathon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fiap_Hackathon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Fiap_Hackathon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Fiap_Hackathon] SET QUERY_STORE = OFF
GO
USE [Fiap_Hackathon]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 28/01/2025 11:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [varchar](50) NOT NULL,
	[IdPatient] [varchar](50) NOT NULL,
	[IdDoctor] [varchar](50) NOT NULL,
	[IdDoctorsTimetablesDate] [varchar](50) NOT NULL,
	[IdDoctorsTimetablesTime] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auth]    Script Date: 28/01/2025 11:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth](
	[Id] [varchar](50) NOT NULL,
	[IdUser] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[LastLoginDate] [datetime] NULL,
 CONSTRAINT [PK_Auth_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorsTimetablesDate]    Script Date: 28/01/2025 11:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorsTimetablesDate](
	[Id] [varchar](50) NOT NULL,
	[IdDoctor] [varchar](50) NOT NULL,
	[AvailableDate] [date] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_DoctorsTimetablesDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorsTimetablesTimes]    Script Date: 28/01/2025 11:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorsTimetablesTimes](
	[Id] [varchar](50) NOT NULL,
	[IdDoctorsTimetablesDate] [varchar](50) NOT NULL,
	[Time] [char](5) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_DoctorsTimetablesTimes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 28/01/2025 11:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[Id] [varchar](50) NOT NULL,
	[IdAppointments] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[Message] [varchar](200) NOT NULL,
	[Success] [bit] NOT NULL,
	[ErrorMessage] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/01/2025 11:55:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CRM] [varchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Amount] DECIMAL(18,2) NULL,
    [Specialty] VARCHAR(100) NULL,
    [Score] INT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_DoctorsTimetablesDate] FOREIGN KEY([IdDoctorsTimetablesDate])
REFERENCES [dbo].[DoctorsTimetablesDate] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_DoctorsTimetablesDate]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_DoctorsTimetablesTimes] FOREIGN KEY([IdDoctorsTimetablesTime])
REFERENCES [dbo].[DoctorsTimetablesTimes] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_DoctorsTimetablesTimes]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Users] FOREIGN KEY([IdPatient])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Users]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Users1] FOREIGN KEY([IdDoctor])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Users1]
GO
ALTER TABLE [dbo].[Auth]  WITH CHECK ADD  CONSTRAINT [FK_Auth_Users1] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Auth] CHECK CONSTRAINT [FK_Auth_Users1]
GO
ALTER TABLE [dbo].[DoctorsTimetablesDate]  WITH CHECK ADD  CONSTRAINT [FK_DoctorsTimetablesDate_Users] FOREIGN KEY([IdDoctor])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[DoctorsTimetablesDate] CHECK CONSTRAINT [FK_DoctorsTimetablesDate_Users]
GO
ALTER TABLE [dbo].[DoctorsTimetablesTimes]  WITH CHECK ADD  CONSTRAINT [FK_DoctorsTimetablesTimes_DoctorsTimetablesDate] FOREIGN KEY([IdDoctorsTimetablesDate])
REFERENCES [dbo].[DoctorsTimetablesDate] ([Id])
GO
ALTER TABLE [dbo].[DoctorsTimetablesTimes] CHECK CONSTRAINT [FK_DoctorsTimetablesTimes_DoctorsTimetablesDate]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Appointments] FOREIGN KEY([IdAppointments])
REFERENCES [dbo].[Appointments] ([Id])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Appointments]
GO
USE [master]
GO
ALTER DATABASE [Fiap_Hackathon] SET  READ_WRITE 
GO
