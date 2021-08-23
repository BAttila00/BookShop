-- Insert the categories
INSERT INTO Category
( DisplayName, FriendlyUrl, ParentCategoryId, [Order] )
VALUES
(N'Ezoterika','Ezoterika', NULL, '00'),
(N'Feng shui','Feng-shui', 1, '00.01'),
(N'Horoszkóp, asztrológia','Horoszkop-asztrologia', 1, '00.02'),
(N'Parapszichológia','Parapszichologia', 1, '00.03'),
(N'Irodalom','Irodalom', NULL, '01'),
(N'Életrajz','Eletrajz', 5, '01.01'),
(N'Dráma, színmű','Drama-szinmu', 5, '01.02'),
(N'Vers, eposz','Vers-eposz', 5, '01.03'),
(N'Tankönyvek','Tankonyvek', NULL, '02'), --9
(N'Matematika','Matematika',9, '02.01'),
(N'Kémia','Kemia',9, '02.02'),
(N'Közgazdaságtudomány','Kozgazdasagtudomany',9, '02.03'),
(N'Biológia','Biologia',9, '02.04'),
(N'Regény','Regeny', NULL, '03'), --14
(N'Családregény','Csaladregeny', 14, '03.01'),
(N'Fantasy','Fantasy', 14, '03.02'),
(N'Erotikus','Erotikus', 14, '03.03'),	
(N'Krimi','Krimi', 14, '03.04'),
(N'Sci-fi','Scifi', 14, '03.05'),	
(N'Thriller','Thriller', 14, '03.06'),	
(N'Történelmi','Tortenelmi', 14, '03.07')
GO