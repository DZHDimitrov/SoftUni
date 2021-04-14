--01. One-To-One Relationship
CREATE TABLE Passports
(
PassportID INT PRIMARY KEY,
PassportNumber VARCHAR(30)
)
INSERT INTO Passports (PassportID,PassportNumber)VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

CREATE TABLE Persons
(
PersonID INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30),
Salary DECIMAL(18,2),
PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Persons VALUES
('Roberto',43300,102),
('Tom',56100,103),
('Yana',60200,101)

--02. One-To-Many Relationship
CREATE TABLE Manufacturers
(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30),
EstablishedOn Date
)

INSERT INTO Manufacturers VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

CREATE TABLE Models
(
ModelID INT PRIMARY KEY,
[Name] VARCHAR(30),
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(Id)
)

INSERT INTO Models VALUES
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

--03. Many-To-Many Relationship

CREATE TABLE Students
(
StudentID INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30)
)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams
(
ExamID INT PRIMARY KEY,
[Name] VARCHAR(50)
)

INSERT INTO Exams VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

CREATE TABLE StudentsExams
(

StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
ExamID INT FOREIGN KEY REFERENCES Exams(ExamId)
PRIMARY KEY (StudentID,ExamID)
)

INSERT INTO StudentsExams VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

--04. Self-Referencing

CREATE TABLE Teachers
(
TeacherID INT PRIMARY KEY,
[Name] NVARCHAR(30),
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted', 105),
(105,'Mark',101),
(106,'Greta',101)

--05. Online Store Database
CREATE DATABASE OnlineStore
USE OnlineStore
CREATE TABLE Cities
(
CityID INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE Customers
(
CustomerID INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID INT IDENTITY PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
ItemTypeID INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE Items
(
ItemID INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
PRIMARY KEY (OrderID,ItemID)
)

--06. University
CREATE DATABASE University
USE University

CREATE TABLE Majors
(
MajorID INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(30)
)

CREATE TABLE Students
(
StudentID INT IDENTITY PRIMARY KEY,
StudentNumber VARCHAR(20),
StudentName NVARCHAR(20),
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
PaymentID INT IDENTITY PRIMARY KEY,
PaymentDate Date,
PaymentAmount DECIMAL(18,2),
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
SubjectID INT IDENTITY PRIMARY KEY,
SubjectName VARCHAR(20)
)
CREATE TABLE Agenda
(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
PRIMARY KEY (StudentID,SubjectID)
)

--09. Peaks in Rila
USE Geography
SELECT MountainRange,p.PeakName,p.Elevation FROM Mountains AS m
	INNER JOIN Peaks AS p ON m.Id = p.MountainId
	WHERE MountainRange = 'Rila'
	ORDER BY p.Elevation DESC

	