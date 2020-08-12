CREATE PROC Catalogue.spGetProductsByCategoryId
	@CategoryId INT
AS
BEGIN
	SELECT P.ProductId, P.ProductSku, P.ProductName, P.ProductDescription, P.ProductPrice
	FROM Catalogue.Products P
	WHERE
		P.CategoryId = @CategoryId
END