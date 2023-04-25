CREATE TABLE Categories (
	Id int IDENTITY(0,1) NOT NULL,
	Name varchar(60),
	CONSTRAINT Categories_PK PRIMARY KEY (Id),
	CONSTRAINT Categories_UniqueName UNIQUE (Name)
);

CREATE TABLE Products (
	Id int IDENTITY(0,1) NOT NULL,
	Name varchar(60),
	CONSTRAINT Products_PK PRIMARY KEY (Id),
	CONSTRAINT Products_UniqueName UNIQUE (Name)
);


CREATE TABLE ProductsCategories (
	ProductId int NOT NULL,
	CategoryId int NOT NULL,
	CONSTRAINT ProductsCategories_UN UNIQUE (ProductId, CategoryId),
	CONSTRAINT ProductsCategories_CategoryFK FOREIGN KEY (CategoryId) REFERENCES internal.dbo.Categories(Id),
        CONSTRAINT ProductsCategories_ProductFK FOREIGN KEY (ProductId) REFERENCES internal.dbo.Products(Id)
);

INSERT INTO Categories
VALUES ('Secret category'), ('Category'), ('Super category');

INSERT INTO Products 
VALUES ('Secret product'), ('Product'), ('Super product');

INSERT INTO ProductsCategories
VALUES (1, 1), (1, 2), (2,2)

SELECT p.Name, c.Name
FROM Products p 
LEFT JOIN ProductsCategories pc on p.Id = pc.ProductId 
LEFT JOIN Categories c on pc.CategoryId = c.Id 
