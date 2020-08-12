CREATE PROC Catalogue.spGetFeaturedProducts
AS
BEGIN
	SELECT ProductSku, ProductName, ProductDescription, ProductPrice
	FROM Catalogue.Products P
		INNER JOIN Catalogue.Categories C
			 ON P.CategoryId = C.CategoryId
	WHERE
		C.[CategoryProductsFeatured] = 1
		OR P.ProductFeatured = 1
END