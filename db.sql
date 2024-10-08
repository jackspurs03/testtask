USE [master]
GO
/****** Object:  Database [testtask]    Script Date: 05.09.2024 18:50:08 ******/
CREATE DATABASE [testtask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'testtask', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\testtask.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'testtask_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\testtask_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [testtask] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testtask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [testtask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [testtask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [testtask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [testtask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [testtask] SET ARITHABORT OFF 
GO
ALTER DATABASE [testtask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [testtask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [testtask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [testtask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [testtask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [testtask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [testtask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [testtask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [testtask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [testtask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [testtask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [testtask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [testtask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [testtask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [testtask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [testtask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [testtask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [testtask] SET RECOVERY FULL 
GO
ALTER DATABASE [testtask] SET  MULTI_USER 
GO
ALTER DATABASE [testtask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [testtask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [testtask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [testtask] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [testtask] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [testtask] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'testtask', N'ON'
GO
ALTER DATABASE [testtask] SET QUERY_STORE = ON
GO
ALTER DATABASE [testtask] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [testtask]
GO
/****** Object:  Table [dbo].[areas]    Script Date: 05.09.2024 18:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[areas](
	[area_id] [int] IDENTITY(1,1) NOT NULL,
	[area_name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cabinets]    Script Date: 05.09.2024 18:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cabinets](
	[cabinet_id] [int] IDENTITY(1,1) NOT NULL,
	[cabinet_number] [int] NOT NULL,
 CONSTRAINT [PK_cabinets] PRIMARY KEY CLUSTERED 
(
	[cabinet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctors]    Script Date: 05.09.2024 18:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctors](
	[doctor_id] [int] IDENTITY(1,1) NOT NULL,
	[fio] [varchar](255) NOT NULL,
	[cabinet_id] [int] NOT NULL,
	[spec_id] [int] NOT NULL,
	[area_id] [int] NULL,
 CONSTRAINT [PK_doctors] PRIMARY KEY CLUSTERED 
(
	[doctor_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 05.09.2024 18:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[patient_id] [int] IDENTITY(1,1) NOT NULL,
	[surname] [varchar](255) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[fathername] [varchar](255) NOT NULL,
	[birthdate] [date] NOT NULL,
	[sex] [tinyint] NOT NULL,
	[area_id] [int] NOT NULL,
 CONSTRAINT [PK_patients] PRIMARY KEY CLUSTERED 
(
	[patient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specializations]    Script Date: 05.09.2024 18:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specializations](
	[spec_id] [int] IDENTITY(1,1) NOT NULL,
	[spec_name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_specializations] PRIMARY KEY CLUSTERED 
(
	[spec_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[areas] ON 

INSERT [dbo].[areas] ([area_id], [area_name]) VALUES (1, N'Октябрьский')
INSERT [dbo].[areas] ([area_id], [area_name]) VALUES (2, N'Ленинский')
INSERT [dbo].[areas] ([area_id], [area_name]) VALUES (3, N'Первомайский')
SET IDENTITY_INSERT [dbo].[areas] OFF
GO
SET IDENTITY_INSERT [dbo].[cabinets] ON 

INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (1, 100)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (2, 101)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (3, 102)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (4, 103)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (5, 104)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (6, 105)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (7, 106)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (8, 107)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (9, 108)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (10, 201)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (11, 201)
INSERT [dbo].[cabinets] ([cabinet_id], [cabinet_number]) VALUES (12, 203)
SET IDENTITY_INSERT [dbo].[cabinets] OFF
GO
SET IDENTITY_INSERT [dbo].[doctors] ON 

INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (2, N'Блинов Михаил Михайлович 2', 1, 2, 1)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (3, N'Овсянникова Милана Давидовна', 2, 2, 2)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (4, N'Кузнецова Ирина Артёмовна', 3, 4, 3)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (5, N'Винокуров Андрей Арсентьевич', 4, 1, 3)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (6, N'Макарова Варвара Матвеевна', 5, 5, 1)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (7, N'Никонова Валерия Данииловна', 6, 3, 2)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (8, N'Ермаков Артур Владимирович', 7, 1, NULL)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (9, N'Царева Елена Тимофеевна', 8, 6, 1)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (10, N'Чернышева Дарья Игоревна', 9, 7, 2)
INSERT [dbo].[doctors] ([doctor_id], [fio], [cabinet_id], [spec_id], [area_id]) VALUES (11, N'Борисов Михаил Захарович', 10, 5, 3)
SET IDENTITY_INSERT [dbo].[doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[patients] ON 

INSERT [dbo].[patients] ([patient_id], [surname], [name], [fathername], [birthdate], [sex], [area_id]) VALUES (1, N'Крючков', N'Михаил', N'Дмитриевич', CAST(N'1992-12-20' AS Date), 1, 1)
INSERT [dbo].[patients] ([patient_id], [surname], [name], [fathername], [birthdate], [sex], [area_id]) VALUES (2, N'Филатова', N'Анисия', N'Юрьевна', CAST(N'1998-08-02' AS Date), 0, 2)
INSERT [dbo].[patients] ([patient_id], [surname], [name], [fathername], [birthdate], [sex], [area_id]) VALUES (3, N'Карпова', N'Александра', N'Владимировна', CAST(N'2001-07-26' AS Date), 0, 3)
SET IDENTITY_INSERT [dbo].[patients] OFF
GO
SET IDENTITY_INSERT [dbo].[specializations] ON 

INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (1, N'аллерголог')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (2, N'анестезиолог')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (3, N'кардиолог')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (4, N'онколог')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (5, N'терапевт')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (6, N'педиатр')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (7, N'хирург')
INSERT [dbo].[specializations] ([spec_id], [spec_name]) VALUES (8, N'психиатр')
SET IDENTITY_INSERT [dbo].[specializations] OFF
GO
ALTER TABLE [dbo].[doctors]  WITH CHECK ADD  CONSTRAINT [FK_doctors_area] FOREIGN KEY([area_id])
REFERENCES [dbo].[areas] ([area_id])
GO
ALTER TABLE [dbo].[doctors] CHECK CONSTRAINT [FK_doctors_area]
GO
ALTER TABLE [dbo].[doctors]  WITH CHECK ADD  CONSTRAINT [FK_doctors_cabinets] FOREIGN KEY([cabinet_id])
REFERENCES [dbo].[cabinets] ([cabinet_id])
GO
ALTER TABLE [dbo].[doctors] CHECK CONSTRAINT [FK_doctors_cabinets]
GO
ALTER TABLE [dbo].[doctors]  WITH CHECK ADD  CONSTRAINT [FK_doctors_specialization] FOREIGN KEY([spec_id])
REFERENCES [dbo].[specializations] ([spec_id])
GO
ALTER TABLE [dbo].[doctors] CHECK CONSTRAINT [FK_doctors_specialization]
GO
ALTER TABLE [dbo].[patients]  WITH CHECK ADD  CONSTRAINT [FK_patients_areas] FOREIGN KEY([area_id])
REFERENCES [dbo].[areas] ([area_id])
GO
ALTER TABLE [dbo].[patients] CHECK CONSTRAINT [FK_patients_areas]
GO
USE [master]
GO
ALTER DATABASE [testtask] SET  READ_WRITE 
GO
