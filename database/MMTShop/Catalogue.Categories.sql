CREATE TABLE Catalogue.Categories
(
	CategoryId INT NOT NULL CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED,
	CategoryName VARCHAR(255) NOT NULL,
	CategoryProductsFeatured BIT NOT NULL
		CONSTRAINT DF_Categories_CategoryProductsFeatured DEFAULT (0)
)

CREATE UNIQUE NONCLUSTERED INDEX UIDX_Categories_CategoryName ON Catalogue.Categories (CategoryName)