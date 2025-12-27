-- Önce hatalı tabloyu siliyoruz
DROP TABLE TransferTbl;

-- Şimdi doğrusunu oluşturuyoruz
CREATE TABLE TransferTbl (
    TNum INT PRIMARY KEY IDENTITY(1,1),
    HAdSoyad NVARCHAR(50),
    KGrup NVARCHAR(10)
);