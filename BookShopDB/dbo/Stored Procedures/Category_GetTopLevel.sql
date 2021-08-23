-- =============================================
-- Visszaadja a legfelső szintű kategóriákat.
-- =============================================
CREATE PROCEDURE [dbo].[Category_GetTopLevel]
AS
BEGIN

	SELECT Id, DisplayName, FriendlyUrl, ParentCategoryId 
	FROM Category
	WHERE ParentCategoryId IS NULL

END