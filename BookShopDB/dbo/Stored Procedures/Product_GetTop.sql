-- =============================================
-- Visszaadja a legújabb termékeket
-- =============================================
CREATE PROCEDURE [dbo].[Product_GetTop]
AS
BEGIN

	SELECT TOP 6
		Product.Id, 
		Product.Title, 
		Product.FriendlyUrl, 
		Product.CategoryId, 
		Product.Subtitle, 
		Product.CoverUrl, 
		Product.Price, 
		Product.DiscountPrice,
		Author.Id as AuthorId,
		Author.DisplayName as AuthorDisplayName,
		Author.FriendlyUrl as AuthorFriendlyUrl
	FROM Product
	INNER JOIN dbo.ProductAuthor 
		ON Product.Id = ProductAuthor.ProductID
	INNER JOIN dbo.Author 
		ON ProductAuthor.AuthorID = Author.ID
	WHERE Price < 4000

END