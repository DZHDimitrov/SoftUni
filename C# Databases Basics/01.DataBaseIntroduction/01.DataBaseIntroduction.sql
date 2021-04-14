--Problem 01.Create database
CREATE DATABASE  Minions

--Problem 02.Create tables
CREATE TABLE Minions
(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30),
Age INT
)

CREATE TABLE Towns
(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30)
)

--Problem 03.Alter minions table
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--Problem 04.Insert records in both tables
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna')

INSERT INTO Minions([Name],Age,TownId) VALUES
('Kevin',22,1),
('Bob',15,3),
('Steward',null,2)

--Problem 05.Delete from All Tables
DELETE FROM Minions

DELETE FROM Towns

--Problem 6.DROP All tables
DROP TABLE Minions,Towns

--Problem 7.Create Table People
CREATE TABLE People
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(18,2),
[Weight] DECIMAL(4,2),
Gender VARCHAR(10) NOT NULL CONSTRAINT chk_Gender CHECK (Gender = 'm' or Gender =  'f'),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name],Picture,Height,[Weight],Gender,Birthdate,Biography) VALUES
('Todor Todorov',NULL,180.2,96.5,'m','05-05-2000',NULL),
('Ivan Stoyanov',NULL,187.2,87.5,'m','05-01-2001',NULL),
('Georgi Ilchev',NULL,190.2,93.5,'m','05-05-1995',NULL),
('Qna Ivanova',NULL,175.2,65.8,'f','05-05-1996',NULL),
('Teodora Georgieva',NULL,165.2,68,'f','05-01-1998',NULL)

--Problem 8.Create Table Users
CREATE TABLE Users
(
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATE,
IsDeleted BIT
)

INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime,IsDeleted) VALUES
('TestName1','asdfdh',NULL,'01-01-2020',1),
('TestName2','qweewq',NULL,'03-01-2020',0),
('TestName3','cxvvxc',NULL,'04-01-2020',1),
('TestName4','12feqef',NULL,'05-01-2020',0),
('TestName5','hhfrgqw',NULL,'06-01-2020',1)

--Problem 9.Change Primary key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0783360BB5

ALTER TABLE Users
ADD PRIMARY KEY (Id,Username)
--Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT chk_PasswordLength CHECK (LEN([Password]) > 5)

--Problem 11. Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT df_LastLogin DEFAULT GETDATE() FOR LastLoginTime

--Problem 12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK__Users__77222459A8EEE1E5

ALTER TABLE Users
ADD PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT chk_UsernameLength CHECK (LEN([Username]) >= 3)

--Problem 13. Movies DataBase
CREATE TABLE Directors
(
Id INT IDENTITY PRIMARY KEY,
DirectorName VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Directors(DirectorName,Notes) VALUES
('Todor','asdgfgf'),
('Ivan','qweewq'),
('Stoqn','dfdsfv'),
('Pesho','eqwrqt'),
('Gosho','rqerqre')


CREATE TABLE Genres
(
Id INT IDENTITY PRIMARY KEY,
GenreName VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Genres(GenreName,Notes) VALUES
('Comedy','good'),
('Thriller','good'),
('Action','very good'),
('Romantic','excellent'),
('Drama','decent')

CREATE TABLE Categories
(
Id INT IDENTITY PRIMARY KEY,
CategoryName VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Categories (CategoryName,Notes) VALUES
('Category1','asdf'),
('Category2','dafda'),
('Category3','htrhtr'),
('Category4','qrqwe'),
('Category5','qfwfwrfw')

CREATE TABLE Movies
(
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyRightYear DATE,
[Length] FLOAT NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating TINYINT,
Notes VARCHAR(MAX)
)

INSERT INTO Movies(Title,DirectorId,CopyRightYear,[Length],GenreId,CategoryId,Rating,Notes) VALUES
('Pepe',1,'01-01-2015',1.25,3,2,5,NULL),
('Test1',1,'01-01-2016',1.55,1,3,4,NULL),
('Test2',1,'01-01-2017',1.25,2,3,2,NULL),
('Test3',1,'01-01-2018',1.52,1,1,5,NULL),
('Test4',1,'01-01-2019',1.55,3,3,2,NULL)

--Problem 14.Car Rental Database
CREATE DATABASE CarRental

CREATE TABLE Categories
(
Id INT IDENTITY PRIMARY KEY,
CategoryName VARCHAR(30) NOT NULL,
DailyRate TINYINT,
WeeklyRate TINYINT,
MonthlyRate TINYINT,
WeekendRate TiNYINT
)

INSERT INTO Categories (CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
('Test1',5,6,7,5),
('Test2',1,2,3,3),
('Test3',4,2,1,3)

CREATE TABLE Cars
(
Id INT IDENTITY PRIMARY KEY,
PlateNumber VARCHAR(30) NOT NULL,
Manufacturer NVARCHAR(30) NOT NULL,
Model VARCHAR(30) NOT NULL,
CarYear DATE,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors TINYINT,
Picutre VARBINARY(MAX),
Condition VARCHAR(10),
Available BIT
)
INSERT INTO Cars
(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picutre,Condition,Available) VALUES
('qwq123','manufacturertest1','test1','05-01-2020',1,4,NULL,'good',1),
('qwrerqre','manufacturertest2','test2','02-04-2020',2,4,NULL,'bad',1),
('qweqrqer','manufacturertest3','test3','03-05-2020',3,4,NULL,'excellent',1)

CREATE TABLE Employees
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title VARCHAR(20) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Todor','Todorov','Job1',NULL),
('Ivan','Ivanov','Job2',NULL),
('Stoyan','Stoyanov','Job3',NULL)

CREATE TABLE Customers
(
Id INT IDENTITY PRIMARY KEY,
DriverLicenseNumber VARCHAR(50) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] VARCHAR(70),
City VARCHAR(50) NOT NULL,
ZIPCode VARCHAR(20),
Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
('driverLicenseTest1','PeshoPeshov','Slaveikov','Burgas','213413',NULL),
('driverLicenseTest2','GoshoGoshov','Izgrev','Sofia','124325',NULL),
('driverLicenseTest3','ZlatinZlatev','Zornica','Varna','1234324',NULL)

CREATE TABLE RentalOrders
(
Id INT IDENTITY PRIMARY KEY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel INT,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL,
SartDate DATE,
EndDate DATE,
TotalDays INT NOT NULL,
RateApplied TINYINT,
TaxRate DECIMAL(5,2),
OrderStatus VARCHAR(10),
Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1,1,1,7,50,100,50,'01-01-2015','05-05-2015',4,10,150.2,'test1',NULL),
(2,3,1,7,50,100,50,'01-01-2015','05-05-2015',4,10,150.2,'test2',NULL),
(3,1,3,7,50,100,50,'01-01-2015','05-05-2015',4,10,150.2,'test3',NULL)

--Problem 15. Hotel database

CREATE DATABASE Hotel

CREATE TABLE Employees
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title VARCHAR(20) NOT NULL,
Notes VARCHAR(MAX)
)
INSERT INTO Employees VALUES
('Pesho','Peshev','TestTitle1',NULL),
('Stoyan','Jechev','TestTitle2',NULL),
('Живко','Тошев','TestTitle3',NULL)

CREATE TABLE Customers
(
AccountNumber VARCHAR(10) PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
LastNaem NVARCHAR(30) NOT NULL,
PhoneNumber VARCHAR(10),
EmergencyName NVARCHAR(30),
EmergencyNumber NVARCHAR(10),
Notes VARCHAR(MAX)
)
INSERT INTO Customers VALUES
('B-10','Живко','Иванов','0125235',NULL,NULL,NULL),
('A-15','Ивайло','Стоянов','32141355',NULL,NULL,NULL),
('C-11','Здравко','Жечев','41343112',NULL,NULL,NULL)

CREATE TABLE RoomStatus
(
Id INT IDENTITY PRIMARY KEY,
RoomStatus BIT,
Notes VARCHAR(MAX)
)
INSERT INTO RoomStatus VALUES
(0,NULL),
(1,NULL),
(0,'good one')

CREATE TABLE BedTypes
(
Id INT IDENTITY PRIMARY KEY,
BedType VARCHAR(20),
Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single',NULL),
('Bedroom',NULL),
('doubleBed',NULL)

CREATE TABLE RoomTypes
(
Id INT IDENTITY PRIMARY KEY,
RoomType VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)
INSERT INTO RoomTypes VALUES
('Single',NULL),
('Studio',NULL),
('Apartment',NULL)

CREATE TABLE Rooms
(
Id INT IDENTITY PRIMARY KEY,
RoomNumber VARCHAR(20) NOT NULL,
RoomType INT FOREIGN KEY REFERENCES RoomTypes(Id),
BedType INT FOREIGN KEY REFERENCES BedTypes(Id),
Rate TINYINT,
RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(Id),
Notes VARCHAR(MAX)
)
INSERT INTO Rooms VALUES
('B-25',2,1,5,3,NULL),
('C-25',3,1,5,1,NULL),
('A-25',1,1,5,2,NULL)

CREATE TABLE Payments
(
Id INT IDENTITY PRIMARY KEY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber VARCHAR(30),
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL(10,2),
TaxAmount DECIMAL(10,2),
PaymentTotal DECIMAL(10,2),
Notes VARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged,TaxAmount,PaymentTotal,Notes)VALUES
(1,'01-01-2015','qweqrqt','03-05-2015','07-05-2015',5,15.2,2.3,10,NULL),
(1,'01-01-2015','rgehete','03-05-2015','07-05-2015',5,15.2,2.3,10,NULL),
(1,'01-01-2015','rwegrg','03-05-2015','07-05-2015',5,15.2,2.3,10,NULL)

CREATE TABLE Occupancies
(
Id INT IDENTITY PRIMARY KEY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumer VARCHAR(30),
RoomNumber VARCHAR(30),
RateApplied TINYINT,
PhoneCharge DECIMAL(8,2),
Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1,'03-05-2017','B-25','10',5,10.5,NULL),
(2,'01-07-2017','A-25','10',5,10.5,NULL),
(3,'04-04-2017','C-25','10',5,10.5,NULL)


--Problem 16. Create SoftUni Database
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30)
)

CREATE TABLE Addresses
(
Id INT IDENTITY PRIMARY KEY,
AddressText VARCHAR(30),
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30)
)

CREATE TABLE Employees
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL,
MiddleName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20),
JobTitle VARCHAR(30) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE,
Salary DECIMAL(18,2),
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

--Problem 18. Basic Insert
INSERT INTO Towns VALUES
('Sofia'),
('Plovidv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',3,'01/02/2013',3500.00,1),
('Petar','Petrov','Petrov','Senior Engineer',1,'02/03/2004',4000.00,1),
('Maria','Petrova','Ivanova','Intern',4,'08/28/2016',525.25,2),
('Georgi','Teziev','Ivanov','CEO',2,'09/12/2007',3000.00,3),
('Peter','Pan','Pan','Intern',3,'08/28/2016',599.88,1)
--Problem 19.Basic Select All Fields
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--Problem 20.	Basic Select All Fields and Order Them
SELECT * FROM Towns
	ORDER BY [Name]

SELECT * FROM Departments
	ORDER BY [Name]

SELECT * FROM Employees
	ORDER BY Salary DESC

--Problem 21. Basic Select Some Fields
SELECT [Name] FROM Towns
	ORDER BY [Name]

SELECT [Name] FROM Departments
	ORDER BY [Name]

SELECT FirstName,LastName,JobTitle,Salary FROM Employees
	ORDER BY Salary DESC

--Problem 22. Increase Employees Salary
UPDATE Employees
	SET Salary = Salary + Salary * 0.10

SELECT Salary FROM Employees

--Problem 23. Decrease Tax Rate
Update Payments
	SET TaxRate = TaxRate - TaxRate * 0.03

SELECT TaxRate FROM Payments

--Problem 24. Delete All Records
DELETE FROM Occupancies