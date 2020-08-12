EXEC (N'CREATE SCHEMA Catalogue')

CREATE TABLE Catalogue.Categories
(
	CategoryId INT NOT NULL CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED,
	CategoryName VARCHAR(255) NOT NULL,
	CategoryProductsFeatured BIT NOT NULL
		CONSTRAINT DF_Categories_CategoryProductsFeatured DEFAULT (0)
)

CREATE UNIQUE NONCLUSTERED INDEX UIDX_Categories_CategoryName ON Catalogue.Categories (CategoryName)

CREATE TABLE Catalogue.Products
(
	ProductId INT NOT NULL IDENTITY (1,1) 
		CONSTRAINT PK_Products PRIMARY KEY CLUSTERED,
	CategoryId INT NOT NULL
		CONSTRAINT FK_Products_Categories_CategoryId FOREIGN KEY REFERENCES Catalogue.Categories (CategoryId),
	ProductName VARCHAR(255) NOT NULL,
	ProductPrice DECIMAL(17,2) NOT NULL
		CONSTRAINT DF_Products_ProductPrice DEFAULT (99999999999.99),
	ProductDescription VARCHAR(MAX) NOT NULL,
	ProductFeatured BIT NOT NULL
		CONSTRAINT DF_Products_ProductFeatured DEFAULT (0),
	Sku AS CAST(CategoryId AS VARCHAR(10)) + RIGHT('0000'+CAST(ProductId AS VARCHAR(4)),4)
)

CREATE NONCLUSTERED INDEX IDX_Products_CategoryId ON Catalogue.Products (CategoryId)