--Section.01 DDL
---01. Create Bakery Database
CREATE TABLE Countries(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender VARCHAR(1) CONSTRAINT CHK_Gender CHECK(Gender IN ('M','F')),
Age INT,
PhoneNumber VARCHAR(10) CONSTRAINT CHK_PhoneNumber CHECK(LEN(PhoneNumber) = 10),
CountryId INT FOREIGN KEY REFERENCES Countries
)

CREATE TABLE Products(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(25) UNIQUE,
[Description] NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price MONEY CONSTRAINT CHK_Money CHECK(Price >= 0)
)

CREATE TABLE Feedbacks(
Id INT IDENTITY PRIMARY KEY,
[Description] NVARCHAR(255),
Rate DECIMAL(10,2) CONSTRAINT CHK_Rate CHECK (Rate >= 0 AND Rate <= 10),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors (
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients (
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30),
[Description] NVARCHAR(200),
OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients (
ProductId INT NOT NULL,
IngredientId INT NOT NULL,
PRIMARY KEY(ProductId,IngredientId),
FOREIGN KEY (ProductId) REFERENCES Products(Id),
FOREIGN KEY (IngredientId) REFERENCES Ingredients(Id)
)

--Section.02 DML

---02. Insert
INSERT INTO Distributors VALUES
('Deloitte & Touche','6 Arch St #9757','Customizable neutral traveling',2),
('Congress Title','58 Hancock St','Customer loyalty',13),
('Kitchen People','3 E 31st St #77','Triple-buffered stable delivery',1),
('General Color Co Inc','6185 Bohn St #72','Focus group',21),
('Beck Corporation','21 E 64th Ave','Quality-focused 4th generation hardware',23)

INSERT INTO Customers VALUES
('Francoise','Rautenstrauch','M',15,'0195698399',5),
('Kendra','Loud','F',22,'0063631526',11),
('Lourdes','Bauswell','M',50,'0139037043',8),
('Hannah','Edmison','F',18,'0043343686',1),
('Tom','Loeza','M',31,'0144876096',23),
('Queenie','Kramarczyk','F',30,'0064215793',29),
('Hiu','Portaro','M',25,'0068277755',16),
('Josefa','Opitz','F',43,'0197887645',17)

---03. Update
UPDATE Ingredients
	SET DistributorId = 35
	WHERE [Name] IN ('Bay Leaf','Paprika','Poppy')
UPDATE Ingredients
	SET OriginCountryId = 14
	WHERE OriginCountryId = 8

--04. Delete
DELETE FROM Feedbacks
	WHERE CustomerId = 14 OR ProductId = 5

--Section.03 Querying

---05. Products by Price
SELECT [Name],Price,[Description] FROM Products
	ORDER BY Price DESC,[Name] ASC

---06. Negative Feedback
SELECT
	ProductId,
	Rate,
	f.[Description],
	CustomerId,Age,Gender
FROM Feedbacks AS f
	INNER JOIN Products AS p ON f.ProductId = p.Id
	INNER JOIN Customers AS c ON f.CustomerId = c.Id
	WHERE f.Rate < 5.0
	ORDER BY ProductId DESC, Rate ASC

---07. Customers without Feedback
SELECT
CONCAT(c.FirstName,' ',c.LastName) AS CustomerName,
PhoneNumber,
Gender
FROM Customers AS c
	LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
	WHERE f.Id IS NULL
	ORDER BY c.Id ASC
	
---08. Customers by Criteria
SELECT FirstName,Age,PhoneNumber FROM Customers AS ct
	INNER JOIN Countries AS c ON ct.CountryId = c.Id
	WHERE (ct.Age >= 21 AND
		  ct.FirstName LIKE '%an%') OR
		  (ct.PhoneNumber LIKE '%38' AND
		  c.Name NOT IN ('Greece'))
	ORDER BY FirstName ASC,Age DESC

---09. Middle Range Distributors
SELECT * FROM Feedbacks AS f
	INNER JOIN Products AS p ON f.ProductId = p.Id

SELECT
	d.Name AS DistributorName,
	i.Name AS IngredientName,
	p.Name AS ProductName,
	AVG(Rate) AS AverageRate
FROM Ingredients AS i
	INNER JOIN Distributors AS d ON i.DistributorId = d.Id
	INNER JOIN ProductsIngredients AS [pi] ON i.Id = [pi].IngredientId
	INNER JOIN Products AS p ON [pi].ProductId = p.Id
	INNER JOIN Feedbacks AS f ON p.Id = f.ProductId
	GROUP BY f.ProductId,d.Name,i.Name,p.Name
	HAVING AVG(Rate) >= 5 AND AVG(Rate) <= 8
	ORDER BY d.Name,i.Name,p.Name

--10. Country Representative
SELECT 
	CountryName,
	DistributorName
FROM (
	SELECT
		c.Name AS CountryName,
		d.Name AS DistributorName,
		COUNT(i.DistributorId) AS IngredientsByDistributor,
		DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.DistributorId) DESC) AS Rank
	FROM Countries AS c
		INNER JOIN Distributors AS d ON c.Id = d.CountryId
		INNER JOIN Ingredients AS i ON i.DistributorId = d.Id
		GROUP BY c.Name,d.Name
	 ) AS ranked
WHERE Rank = 1
ORDER BY CountryName,DistributorName

---Section.04 Programmability
GO
--11. Customers with Countries
CREATE VIEW v_UserWithCountries AS
SELECT
	CONCAT(ct.FirstName,' ',ct.LastName) AS CustomerName,
	Age,
	Gender,
	c.Name AS CountryName
FROM Customers AS ct
	INNER JOIN Countries AS c ON ct.CountryId = c.Id

GO
--12. Delete Products
CREATE TRIGGER tr_DeleteProducts ON Products INSTEAD OF DELETE
AS
	BEGIN
		DECLARE @productId INT = (SELECT Id FROM deleted);
		DELETE FROM Feedbacks WHERE ProductId = @productId
		DELETE FROM ProductsIngredients WHERE ProductId = @productId
		DELETE FROM Products WHERE Id = @productId

	END
