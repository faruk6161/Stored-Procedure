CREATE PROCEDURE dbo.Ekle

@yoneticiid INT,
@kullaniciadi VARCHAR(50),
@sifre VARCHAR(50),
@ad VARCHAR(50),
@soyad VARCHAR(50)

AS
INSERT INTO dbo.yonetici
(
    yoneticiid,
    kullaniciadi,
    sifre,
    ad,
    soyad
)
VALUES
(   @yoneticiid,   -- yoneticiid - int
    @kullaniciadi, -- kullaniciadi - nvarchar(50)
    @sifre, -- sifre - nvarchar(50)
    @ad, -- ad - nvarchar(50)
    @soyad  -- soyad - nvarchar(50)
    )