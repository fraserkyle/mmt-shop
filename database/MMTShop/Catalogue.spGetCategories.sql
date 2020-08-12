CREATE PROC Catalogue.spGetCategories
AS
BEGIN
	SELECT C.CategoryId, C.CategoryName
	FROM Catalogue.Categories C
END