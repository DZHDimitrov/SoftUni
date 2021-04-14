--01. Find Names of All Employees by First Name
USE SoftUni
SELECT FirstName,LastName FROM Employees
	WHERE FirstName LIKE 'SA%'

--02. Find Names of All employees by Last Name
SELECT FirstName,LastName FROM Employees
	WHERE LastName LIKE '%ei%' 

--03. Find First Names of All Employees
SELECT FirstName FROM Employees
	WHERE DepartmentID IN (3,10) AND (YEAR(HireDate) BETWEEN 1995 AND 2005)

--04. Find All Employees Except Engineers
SELECT FirstName,LastName FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
SELECT [Name] FROM Towns
	WHERE LEN([Name]) IN (5,6)
	ORDER BY [Name] ASC

--06. Find Towns Starting With
SELECT TownId,[Name] FROM Towns
	WHERE [Name] LIKE '[M,K,B,E]%'
	ORDER BY [Name] ASC

--07. Find Towns Not Starting With
SELECT TownID,[Name] FROM Towns
	WHERE [Name] NOT LIKE '[R,B,D]%'
	ORDER BY [Name] ASC

--08. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName FROM Employees
	WHERE YEAR(HireDate) > 2000

--09. Length of Last Name
SELECT FirstName,LastName FROM Employees
	WHERE LEN(LastName) = 5

--10. Rank Employees by Salary
SELECT EmployeeID,
		FirstName,
		LastName,
		Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
		FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--11. Find All Employees With Rank2
SELECT * FROM (SELECT EmployeeID,
		FirstName,
		LastName,
		Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
		FROM Employees) AS Ranked
	WHERE [Rank] = 2 AND Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC

--12. Countries Holding ‘A’ 3 or More Times
USE Geography
SELECT CountryName,IsoCode AS [ISO Code] FROM Countries
	WHERE LEN(CountryName) - LEN(REPLACE(CountryName,'A','')) >= 3
	ORDER BY IsoCode

--13. Mix of Peak and River Names
USE Geography
SELECT p.PeakName,
		RiverName,
		LOWER(SUBSTRING(p.PeakName,0,LEN(p.PeakName))+RiverName) AS Mix 
FROM Peaks AS p,Rivers AS r
  WHERE RIGHT(p.PeakName,1) = LEFT(RiverName,1)
  ORDER BY Mix

--14. Games from 2011 and 2012 year
USE Diablo
SELECT TOP(50)[Name],FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games
	WHERE YEAR([Start]) IN (2011,2012)
	ORDER BY [Start]

--15. User Email Providers
SELECT Username,
		SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)-CHARINDEX('@',Email) +1) 
		AS [Email Provider]
		FROM Users
		ORDER BY [Email Provider] ASC,Username ASC

--16. Get Users with IPAdress Like Pattern
SELECT Username,IpAddress FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

--17. Show All Games with Duration and Part of the Day
SELECT [Name],
	CASE
		WHEN DATEPART(HOUR,[Start]) >= 0 AND DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR,[Start]) >= 12 AND DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR,[Start]) >= 18 AND DATEPART(HOUR,[Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],
	Case
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
 FROM Games
ORDER BY [Name] ASC ,[Duration] ASC ,[Part of the Day] ASC

--18. Orders Table
USE Orders

SELECT ProductName,
	   OrderDate,
	   DATEADD(DAY,3,OrderDate) AS [Pay Due],
	   DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
FROM Orders

--19. People Table
CREATE TABLE People
(
Id INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30),
Birthdate DATE
)

INSERT INTO People VALUES
('Victor','2000-12-07 00:00:00.000'),
('Steven','1992-09-10 00:00:00.000'),
('Stephen','1910-09-19 00:00:00.000'),
('John','2010-01-06 00:00:00.000')

SELECT [Name],
	   DATEDIFF(YEAR,Birthdate,GETDATE()) AS [Age in Years],
	   DATEDIFF(MONTH,Birthdate,GETDATE()) AS [Age in Months],
	   DATEDIFF(DAY,Birthdate,GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE,Birthdate,GETDATE()) AS [Age in Minutes]
FROM people