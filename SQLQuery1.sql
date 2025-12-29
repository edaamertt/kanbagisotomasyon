USE [master]
GO
/****** Object:  Database [KanBankasi]   Script Date: 29.12.2025 14:53:14 ******/
CREATE DATABASE[KanBankasi]

 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KanBankasi', FILENAME = N'C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KanBankasi_log', FILENAME = N'C:\Users\lenova\Desktop\KanBankasi\WindowsFormsApp1\WindowsFormsApp1\KanBankasi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE ALTER DATABASE [KanBankasi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KanBankasi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE[KanBankasi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KanBankasi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE[KanBankasi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE[KanBankasi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KanBankasi] SET ARITHABORT OFF 
GO
ALTER DATABASE [KanBankasi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE[KanBankasi] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [KanBankasi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE[KanBankasi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE[KanBankasi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KanBankasi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KanBankasi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KanBankasi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KanBankasi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KanBankasi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KanBankasi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KanBankasi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KanBankasi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KanBankasi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KanBankasi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KanBankasi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KanBankasi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KanBankasi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KanBankasi]SET  MULTI_USER 
GO
ALTER DATABASE [KanBankasi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KanBankasi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KanBankasi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KanBankasi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KanBankasi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KanBankasi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KanBankasi] SET QUERY_STORE = OFF
GO
USE [KanBankasi]
GO
/****** Object:  Table [dbo].[CalisanTbl]    Script Date: 29.12.2025 14:53:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalisanTbl](
	[CalNum] [int] IDENTITY(1,1) NOT NULL,
	[CalId] [varchar](50) NOT NULL,
	[CalSif] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CalNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonorTbl]    Script Date: 29.12.2025 14:53:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonorTbl](
	[DNum] [int] IDENTITY(100,1) NOT NULL,
	[DAdSoyad] [varchar](50) NOT NULL,
	[DYaş] [int] NOT NULL,
	[DCinsiyet] [varchar](50) NOT NULL,
	[DTelefon] [varchar](50) NOT NULL,
	[DAdres] [varchar](50) NOT NULL,
	[DKGrup] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HastaTbl]    Script Date: 29.12.2025 14:53:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HastaTbl](
	[HNum] [int] IDENTITY(500,1) NOT NULL,
	[HAdSoyad] [varchar](50) NOT NULL,
	[HYas] [int] NOT NULL,
	[HTelefon] [varchar](50) NOT NULL,
	[HCinsiyet] [varchar](10) NOT NULL,
	[HKGrup] [varchar](5) NOT NULL,
	[HAdres] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KanTbl]    Script Date: 29.12.2025 14:53:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KanTbl](
	[KGrup] [varchar](5) NOT NULL,
	[KStok] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[KGrup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferTbl]    Script Date: 29.12.2025 14:53:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferTbl](
	[TNum] [int] IDENTITY(1,1) NOT NULL,
	[HAdSoyad] [nvarchar](50) NULL,
	[KGrup] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[TNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CalisanTbl] ON 

INSERT [dbo].[CalisanTbl] ([CalNum], [CalId], [CalSif]) VALUES (6, N'Eda Mert', N'5252')
INSERT [dbo].[CalisanTbl] ([CalNum], [CalId], [CalSif]) VALUES (7, N'Zeynep Fidan', N'3939')
INSERT [dbo].[CalisanTbl] ([CalNum], [CalId], [CalSif]) VALUES (8, N'Nehir Seyrek', N'3434')
INSERT [dbo].[CalisanTbl] ([CalNum], [CalId], [CalSif]) VALUES (9, N'Furkan Arslan', N'1818')
SET IDENTITY_INSERT [dbo].[CalisanTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[DonorTbl] ON 

INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (103, N'Irem Ceren', 21, N'Kadin', N'5325532', N'kartal', N'AB+')
INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (104, N'Özge Aydin', 24, N'Kadin', N'5949800831', N'Sancaktepe', N'B-')
INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (105, N'Sema Nur', 32, N'Kadin', N'53653657', N'Izmit', N'B+')
INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (106, N'Emirhan Çayir', 29, N'Erkek', N'76366674372', N'Tekirdag', N'A+')
INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (107, N'Ömer Aslan', 22, N'Erkek', N'573263567', N'Ümraniye', N'B+')
INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (108, N'Burak Kurt', 25, N'Erkek', N'54636553', N'Çekmeköy', N'0-')
INSERT [dbo].[DonorTbl] ([DNum], [DAdSoyad], [DYaş], [DCinsiyet], [DTelefon], [DAdres], [DKGrup]) VALUES (109, N'Ceren Simsek', 37, N'Kadin', N'5464563', N'Erenköy', N'AB-')
SET IDENTITY_INSERT [dbo].[DonorTbl] OFF
GO
SET IDENTITY_INSERT [dbo].[HastaTbl] ON 

INSERT [dbo].[HastaTbl] ([HNum], [HAdSoyad], [HYas], [HTelefon], [HCinsiyet], [HKGrup], [HAdres]) VALUES (506, N'Mustafa Bostanci', 26, N'56255373', N'Erkek', N'A-', N'Çankiri')
INSERT [dbo].[HastaTbl] ([HNum], [HAdSoyad], [HYas], [HTelefon], [HCinsiyet], [HKGrup], [HAdres]) VALUES (507, N'Hasan Savas', 33, N'572336467', N'Erkek', N'0+', N'Beylikdüzü')
INSERT [dbo].[HastaTbl] ([HNum], [HAdSoyad], [HYas], [HTelefon], [HCinsiyet], [HKGrup], [HAdres]) VALUES (508, N'Mete Aras', 23, N'536624663', N'Erkek', N'0-', N'Mecidiyeköy')
INSERT [dbo].[HastaTbl] ([HNum], [HAdSoyad], [HYas], [HTelefon], [HCinsiyet], [HKGrup], [HAdres]) VALUES (509, N'Can Yilmaz', 42, N'52656365', N'Erkek', N'AB-', N'Ankara')
SET IDENTITY_INSERT [dbo].[HastaTbl] OFF
GO
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'0+', 1)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'0-', 0)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'A+', 3)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'A-', 0)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'AB+', 0)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'AB-', 1)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'B+', 2)
INSERT [dbo].[KanTbl] ([KGrup], [KStok]) VALUES (N'B-', 0)
GO
SET IDENTITY_INSERT [dbo].[TransferTbl] ON 

INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (1, N'fatma', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (2, N'fatma', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (3, N'fatma', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (4, N'fatma', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (5, N'fatma', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (6, N'fatma', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (7, N'Hasan Savas', N'0+')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (8, N'Can Yilmaz', N'AB-')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (9, N'Mustafa Bostanci', N'A-')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (10, N'Mustafa Bostanci', N'A-')
INSERT [dbo].[TransferTbl] ([TNum], [HAdSoyad], [KGrup]) VALUES (11, N'Mete Aras', N'0-')
SET IDENTITY_INSERT [dbo].[TransferTbl] OFF
GO
USE [master]
GO
ALTER DATABASE [KanBankasi] SET READ_WRITE 
GO


