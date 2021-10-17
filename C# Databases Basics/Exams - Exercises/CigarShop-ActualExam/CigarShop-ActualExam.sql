--Section.01 DDL
---01. Create CigarShop database
CREATE TABLE Sizes
(
	Id INT IDENTITY PRIMARY KEY,
	Length INT CONSTRAINT chk_length CHECK (Length >= 10 AND Length <= 25) NOT NULL,
	RingRange DECIMAL(15,2) CONSTRAINT chk_RingRange CHECK (RingRange >= 1.5 AND RingRange <= 7.5) NOT NULL
)

CREATE TABLE Tastes
(
	Id INT IDENTITY PRIMARY KEY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT IDENTITY PRIMARY KEY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT IDENTITY PRIMARY KEY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(15,2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT IDENTITY PRIMARY KEY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL,
	CigarId INT NOT NULL,
	PRIMARY KEY(ClientId,CigarId),
	FOREIGN KEY (ClientId) REFERENCES Clients(Id),
	FOREIGN KEY (CigarId) REFERENCES Cigars(Id)
)

--Section.02 DML
---02. Insert
INSERT INTO Cigars (CigarName,BrandId,TastId,SizeId,PriceForSingleCigar,ImageURL) VALUES
('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town,Country,Streat,ZIP) VALUES
('Sofia','Bulgaria','18 Bul. Vasil levski',1000),
('Athens','Greece','4342 McDonald Avenue',10435),
('Zagreb','Croatia','4333 Lauren Drive',10000)

---03. Update
UPDATE Cigars
	SET PriceForSingleCigar += PriceForSingleCigar * 0.20
	WHERE CigarName IN (SELECT c.CigarName FROM Cigars AS c
	INNER JOIN Tastes AS t ON c.TastId = t.Id
	WHERE t.TasteType = 'Spicy')
UPDATE Brands
	SET BrandDescription = 'New description'
	WHERE BrandDescription IS NULL

---04. Delete

DELETE FROM Clients
	WHERE AddressId IN (SELECT Id FROM Addresses
	WHERE Country LIKE 'C%')
DELETE FROM Addresses
	WHERE Id IN (SELECT Id FROM Addresses
	WHERE Country LIKE 'C%')

--Section.03 Querying
---05. Cigars by Price
SELECT CigarName,PriceForSingleCigar,ImageURL FROM Cigars
	ORDER BY PriceForSingleCigar ASC,CigarName DESC

---06. Cigars by Taste
SELECT
	c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,t.
	TasteStrength 
FROM Cigars AS c
	INNER JOIN Tastes AS t ON c.TastId = t.Id
	WHERE t.TasteType IN ('Earthy','Woody')
	ORDER BY PriceForSingleCigar DESC

---07. Clients without Cigars
SELECT
c.Id,
CONCAT(c.FirstName,' ',c.LastName) AS [ClientName],
c.Email
FROM Clients AS c
	LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
	WHERE cc.ClientId IS NULL
	ORDER BY [ClientName]

---08. First 5 Cigars
SELECT TOP(5) c.CigarName,c.PriceForSingleCigar,c.ImageURL FROM Cigars AS c
	INNER JOIN Sizes AS s ON c.SizeId = s.Id
	WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
	ORDER BY c.CigarName ASC,c.PriceForSingleCigar DESC

---09. Clients with ZIP Codes

SELECT
	CONCAT(c.FirstName,' ',c.LastName) AS FullName,
	a.Country,
	a.ZIP,
	CONCAT('$',MAX(ci.PriceForSingleCigar)) AS CigarPrice 
FROM Clients AS c
	INNER JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
	INNER JOIN Cigars AS ci ON cc.CigarId = ci.Id
	INNER JOIN Addresses AS a ON c.AddressId = a.Id
	WHERE ZIP NOT LIKE '%[^0-9]%'
	GROUP BY c.FirstName,c.LastName,a.Country,a.ZIP
	ORDER BY FullName

---10. Cigars by Size
SELECT
	c.LastName,
	AVG(s.Length) AS CiagrLength,
	CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients AS c
	LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
	INNER JOIN Cigars AS ci ON cc.CigarId = ci.Id
	INNER JOIN Sizes AS s ON ci.SizeId = s.Id
	GROUP BY c.LastName
	ORDER BY CiagrLength DESC
GO
--Section.04 Programmability
---11. Client with Cigars
CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(MAX))
RETURNS INT
BEGIN
	RETURN (SELECT COUNT(*) FROM Clients AS c
		INNER JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
		WHERE c.FirstName = @name)
END

GO
---12. Search for Cigar with Specific Taste
CREATE PROC usp_SearchByTaste(@taste VARCHAR(MAX))
AS
BEGIN
SELECT
	c.CigarName,
	CONCAT('$',c.PriceForSingleCigar) AS Price,
	t.TasteType,
	b.BrandName,
	CONCAT(s.Length,' ','cm') AS CigarLength,
	CONCAT(s.RingRange,' ','cm') AS CigarRingRange
FROM Cigars AS c
	INNER JOIN Tastes AS t ON c.TastId = t.Id
	INNER JOIN Brands AS b ON c.BrandId = b.Id
	INNER JOIN Sizes AS s ON c.SizeId = s.Id
	WHERE t.TasteType = @taste
	ORDER BY s.Length,s.RingRange DESC
END