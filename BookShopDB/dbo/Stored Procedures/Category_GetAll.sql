CREATE PROCEDURE [dbo].[Category_GetAll]

AS

BEGIN

	SELECT Id, DisplayName, FriendlyUrl, ParentCategoryId, [Order]
	FROM Category
	ORDER BY [Order]

END