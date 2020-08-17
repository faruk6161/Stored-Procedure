CREATE PROCEDURE [dbo].[Sil]	
	@yoneticiid INT
AS
	DELETE FROM dbo.yonetici WHERE yoneticiid=@yoneticiid