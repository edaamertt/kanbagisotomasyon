-- =====================================================
-- KAN BAĞIŞI OTOMASYONU VERİTABANI
-- =====================================================
-- Bu SQL dosyası, Kan Bağışı Otomasyonu projesi için
-- oluşturulmuş veritabanı tablolarını içermektedir.
--
-- İçerik:
-- 1. CalisanTbl  : Sistem yöneticisi / çalışan giriş bilgileri
-- 2. DonorTbl    : Kan bağışında bulunan donör bilgileri
-- 3. HastaTbl    : Kana ihtiyaç duyan hasta bilgileri
-- 4. KanTbl      : Kan gruplarına göre stok bilgileri
-- 5. TransferTbl: Hastalara yapılan kan transfer işlemleri
--
-- Not:
-- TransferTbl tablosu, işlem geçmişini tutmak amacıyla
-- sade bir yapıda tasarlanmıştır.
--
-- Veritabanı dersi kapsamında hazırlanmıştır.
-- =====================================================
-- =====================================================
-- KAN BAĞIŞI OTOMASYONU VERİTABANI TABLOLARI
-- =====================================================

CREATE TABLE [dbo].[CalisanTbl] (
    [CalNum] INT IDENTITY (1, 1) NOT NULL,
    [CalId]  VARCHAR (50) NOT NULL,
    [CalSif] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CalNum] ASC)
);

CREATE TABLE [dbo].[DonorTbl] (
    [DNum]      INT IDENTITY (100, 1) NOT NULL,
    [DAdSoyad]  VARCHAR (50) NOT NULL,
    [DYaş]      INT NOT NULL,
    [DCinsiyet] VARCHAR (50) NOT NULL,
    [DTelefon]  VARCHAR (50) NOT NULL,
    [DAdres]    VARCHAR (50) NOT NULL,
    [DKGrup]    VARCHAR (5)  NOT NULL,
    PRIMARY KEY CLUSTERED ([DNum] ASC)
);

CREATE TABLE [dbo].[HastaTbl] (
    [HNum]      INT IDENTITY (500, 1) NOT NULL,
    [HAdSoyad]  VARCHAR (50) NOT NULL,
    [HYas]      INT NOT NULL,
    [HTelefon]  VARCHAR (50) NOT NULL,
    [HCinsiyet] VARCHAR (10) NOT NULL,
    [HKGrup]    VARCHAR (5)  NOT NULL,
    [HAdres]    VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([HNum] ASC)
);

CREATE TABLE [dbo].[KanTbl] (
    [KGrup] VARCHAR (5) NOT NULL,
    [KStok] INT NULL,
    PRIMARY KEY CLUSTERED ([KGrup] ASC)
);

CREATE TABLE [dbo].[TransferTbl] (
    [TNum]     INT IDENTITY (1, 1) NOT NULL,
    [HAdSoyad] NVARCHAR (50) NULL,
    [KGrup]    NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([TNum] ASC)
);
