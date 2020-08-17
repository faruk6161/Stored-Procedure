CREATE PROCEDURE [dbo].[Guncelle]
@yoneticiid INT,
@kullaniciadi VARCHAR(50),
@sifre VARCHAR(50),
@ad VARCHAR(50),
@soyad VARCHAR(50)

AS
	UPDATE dbo.yonetici SET kullaniciadi=@kullaniciadi,sifre=@sifre,ad=@ad,soyad=@soyad 
	WHERE yoneticiid=@yoneticiid