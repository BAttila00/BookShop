CREATE FUNCTION [dbo].[Split](@String varchar(8000), @Delimiter char(1))       
	RETURNS @temptable TABLE (Items varchar(8000))       
AS

BEGIN
    DECLARE @idx int       
    DECLARE @slice varchar(8000)       

    SELECT @idx = 1       
        IF LEN(@String)<1 OR @String IS NULL RETURN

    WHILE @idx!= 0       
    BEGIN       
        SET @idx = CHARINDEX(@Delimiter,@String)       
        IF @idx!=0       
            SET @slice = LEFT(@String,@idx - 1)       
        ELSE
            SET @slice = @String       

        IF(LEN(@slice)>0)  
            INSERT INTO @temptable(Items) VALUES( LTRIM(RTRIM( @slice) ))

        SET @String = RIGHT(@String, LEN(@String) - @idx)       
        IF LEN(@String) = 0 BREAK
    END

	RETURN
END