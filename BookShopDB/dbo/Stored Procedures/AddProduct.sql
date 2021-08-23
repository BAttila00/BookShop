CREATE PROCEDURE [dbo].[AddProduct]
	@Title nvarchar(100),
	@SubTitle nvarchar(100),
	@PictureUrl nvarchar(100),
	@Price int,
	@PublishYear int,
	@PageNumber int,
	@CategoryName nvarchar(50),
	@Publisher nvarchar(100),
	@Author nvarchar(100),
	@ShortDescription nvarchar(MAX)
AS

BEGIN

	-- Kategória ID megkeresése
	DECLARE @CategoryId INT
	SELECT @CategoryId = Id FROM Category WHERE DisplayName = @CategoryName

	-- Kiadó keresése / beszúrása
	DECLARE @PublisherId INT
	SELECT @PublisherId = Id FROM Publisher WHERE DisplayName = @Publisher

	IF( @PublisherId IS NULL )
	BEGIN
		INSERT INTO Publisher
		( DisplayName )
		VALUES
		( @Publisher )

		SET @PublisherId = @@IDENTITY
	END

	-- Termék beszúrása
	INSERT INTO Product
	( Title, SubTitle, CoverUrl, ShortDescription, Price, PublishYear, PageNumber, CategoryId, PublisherId  )
	VALUES
	( @Title, @SubTitle, @PictureUrl, @ShortDescription, @Price, @PublishYear, @PageNumber, @CategoryId, @PublisherId)

	DECLARE @PId int
	SET @PId = @@IDENTITY

	-- Szerző beszúrása
	DECLARE c CURSOR FOR SELECT * FROM dbo.Split(@Author, ',')
	OPEN c

	DECLARE @AName nvarchar(100)
	DECLARE @AId int
	FETCH NEXT FROM c INTO @AName

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SELECT @AId = Id FROM Author WHERE DisplayName = @AName
		IF( @AId IS NULL )
		BEGIN
			INSERT INTO Author ( DisplayName ) VALUES( @AName )
			SET @AId = @@IDENTITY
		END

		IF( NOT EXISTS( SELECT * FROM ProductAuthor WHERE ProductId = @PId AND AuthorId = @AId ) )
		BEGIN
			INSERT INTO ProductAuthor ( ProductId, AuthorId ) VALUES ( @PId, @AId )
		END

		FETCH NEXT FROM c INTO @AName
	END

	CLOSE c
	DEALLOCATE c
END