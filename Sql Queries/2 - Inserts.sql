INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Varuna Venkatesh', 7579)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Kathleen Nolan', 409)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Oana Claudia Ionascu', 8309)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Laura Davies', 8304)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Jennifer Hyde', 7582)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Philippa Slinger', 7583)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Sian Godwyn', 8305)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Angela Leo', 7686)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Urszula Uryszek', 8302)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Amelie Pentecouteau', 8410)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Patricia Penalver', 8749)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Susi Caldwell', 8620)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Katarzyna Mirgos', 8652)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Eve Tollenaar', 8750)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Alice Walton', 5537)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Agnieszka Gajek', 8616)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Paschalia Paschali', 6501)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Maria Mytilinaiou', 8307)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Lucie Pocinkova', 7552)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Elitsa Gosheva', 7584)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Lito Vera Fouki', 7791)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Carmen Soggia', 8409)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Alice Lanzotti', 8493)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Silvia Lambiase', 8502)
INSERT INTO [dbo].[Player]([Name],[RegistrationNumber])VALUES('Jasmine Mills', 8619)


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


INSERT INTO [dbo].[Team]([Name],[Colour],[Code])VALUES('Manchester Marvels 1','Black','MM1')
INSERT INTO [dbo].[Team]([Name],[Colour],[Code])VALUES('Manchester Marvels 2','Yellow','MM2')


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

DECLARE @pid int = 1

WHILE (@pid < 15)
BEGIN
	INSERT INTO [dbo].[TeamPlayer]([TeamId],[PlayerId],[ActiveFrom])VALUES(2,@pid,GETDATE())
	SET @pid = (SELECT @pid + 1)
END
GO

DECLARE @pid int = 15

WHILE (@pid < 26)
BEGIN
	INSERT INTO [dbo].[TeamPlayer]([TeamId],[PlayerId],[ActiveFrom])VALUES(2,@pid,GETDATE())
	SET @pid = (SELECT @pid + 1)
END
GO


---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


