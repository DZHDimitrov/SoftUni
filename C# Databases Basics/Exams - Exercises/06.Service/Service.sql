--Section.01 DDL
---01. Create Service database
CREATE TABLE Users(
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) UNIQUE NOT NULL,
Password VARCHAR(50) NOT NULL,
Name VARCHAR(50) NULL,
Birthdate DATETIME NULL,
Age INT CONSTRAINT chk_AgeRange CHECK (Age >= 14 AND Age <= 110),
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME,
Age INT CONSTRAINT chk_AgeRangeEmployees CHECK (Age >= 14 AND Age <= 110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status(
Id INT IDENTITY PRIMARY KEY,
Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT IDENTITY PRIMARY KEY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
OpenDate DATETIME NOT NULL,
CloseDate DATETIME NULL,
Description VARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--02. DML
---02. Insert
INSERT INTO Employees (FirstName,LastName,Birthdate,DepartmentId) VALUES
('Marlo','O''Malley','1958-9-21',1),
('Niki','Stanaghan','1969-11-26',4),
('Ayrton','Senna','1960-03-21',9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports (CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

---03. Update
UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

---04. Delete
DELETE FROM Reports
	WHERE StatusId = 4

--Section.03 Querying
---05. Unassigned Reports
SELECT 
	Description,
	FORMAT(OpenDate,'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
	WHERE EmployeeId IS NULL
	ORDER BY r.OpenDate,Description

---06. Reports & Categories
SELECT Description,c.Name FROM Reports AS r
	INNER JOIN Categories AS c ON r.CategoryId = c.Id
	WHERE r.CategoryId IS NOT NULL
	ORDER BY Description,c.Name

---07. Most Reported Category
SELECT TOP(5)
	c.Name AS CategoryName,
	COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
	INNER JOIN Categories AS c ON r.CategoryId = c.Id
	GROUP BY CategoryId,c.Name
	ORDER BY ReportsNumber DESC,c.Name

---08. Birthday Report
SELECT
u.Username,
c.Name AS CategoryName 
FROM Reports AS r
	INNER JOIN Users AS u ON r.UserId = u.Id
	INNER JOIN Categories AS c ON r.CategoryId = c.Id
	WHERE MONTH(r.OpenDate) = MONTH(u.Birthdate) AND DAY(r.OpenDate) = DAY(u.Birthdate)
	ORDER BY Username,c.Name

---09. Users per Employee
SELECT
CONCAT(e.FirstName,' ',e.LastName) AS FullName,
COUNT(UserId) AS UsersCount FROM Reports AS r
	RIGHT JOIN Users AS u ON r.UserId = u.Id
	RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
	GROUP BY r.EmployeeId,e.FirstName,e.LastName
	ORDER BY UsersCount DESC, FullName

---10. Full Info
SELECT
	ISNULL(e.FirstName + ' ' +  e.LastName, 'None') AS Employee,
	ISNULL(d.Name,'None') AS Department,
	c.Name AS Category,
	r.Description,
	FORMAT(OpenDate,'dd.MM.yyyy') AS OpenDate,
	s.Label AS Status,
	ISNULL(u.Name,'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN Users AS u ON u.Id = r.UserId
LEFT JOIN Status AS s ON s.Id = r.StatusId
ORDER BY e.FirstName DESC,e.LastName DESC,d.Name,c.Name,r.Description,r.OpenDate,s.Label,u.Name

--Section.04 Programmability
---11. Hours to Complete
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL) RETURN 0
	RETURN (SELECT DATEDIFF(HOUR,@StartDate,@EndDate))
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
GO
---12. Assign Employee
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
DECLARE @CategoryDepartmentId INT = (
										SELECT
											c.DepartmentId
										FROM Reports AS r
										INNER JOIN Categories AS c ON r.CategoryId = c.Id
										WHERE r.Id = @ReportId
									 )
	IF(@EmployeeDepartmentId != @CategoryDepartmentId)
	BEGIN
	RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
	END
UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId
END
