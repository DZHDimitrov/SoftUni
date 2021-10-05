--01. Employee Address
SELECT TOP(5) EmployeeID AS EmployeeId,
			  JobTitle,
		      a.AddressID AS AddressId,
		      a.AddressText
	 FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID ASC

--02. Addresses with Towns

SELECT TOP(50) FirstName,
			   LastName,
			   t.[Name],
			   a.AddressText
     FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName ASC ,LastName ASC

--03. Sales Employee

SELECT EmployeeID,
	   FirstName,
	   LastName,
	   d.[Name] 
	 FROM Employees AS e
INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID ASC

--04. Employee Departments
SELECT TOP(5) EmployeeID,
			  FirstName,
			  Salary,
			  d.[Name]
	 FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID ASC

--05. Employees Without Project
SELECT TOP(3) e.EmployeeID,
			  e.FirstName 
	 FROM EmployeesProjects AS ep
RIGHT OUTER JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY EmployeeID ASC

--06. Employees Hired After
SELECT FirstName,
	   LastName,
	   HireDate, 
	   d.[Name] AS DeptName
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY HireDate ASC

--07. Employees With Project
SELECT TOP(5)e.EmployeeId AS EmployeeID,
			 FirstName,
			 p.[Name] AS ProjectName 
	 FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE CONVERT(VARCHAR,p.StartDate,4) > CONVERT(VARCHAR,'13.08.2002',4) AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

--08. Employee 24
SELECT e.EmployeeID,
	   FirstName,
	   CASE
		  WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		  ELSE p.[Name]
	   END AS ProjectName
	 FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--09. Employee Manager
SELECT e1.EmployeeID,
	   e1.FirstName,
	   e1.ManagerID,
	   e2.FirstName AS ManagerName
	 FROM Employees AS e1
INNER JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
WHERE e1.ManagerID IN (3,7)
ORDER BY EmployeeID ASC

--10. Employee Summary
SELECT TOP (50) e1.EmployeeID,
			    CONCAT(e1.FirstName,' ',e1.LastName) AS EmployeeName,
			    CONCAT(e2.FirstName,' ',e2.LastName) AS ManagerName,
			    d.[Name] AS DepartmentName
     FROM Employees AS e1
LEFT OUTER JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
INNER JOIN Departments AS d ON e1.DepartmentID = d.DepartmentID
ORDER BY EmployeeID ASC

--11. Min Average Salary
SELECT MIN(AverageQueryView.AverageSalary) AS [MinAverageSalary]
	FROM 
  ( 
   SELECT e.DepartmentID,
		  AVG(Salary) AS AverageSalary 
        FROM Employees AS e
	INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	GROUP BY e.DepartmentID
  )
AS [AverageQueryView]

--12. Highest Peak In Bulgaria
SELECT c.CountryCode,
	   m.MountainRange,
	   p.PeakName,
	   p.Elevation 
     FROM MountainsCountries AS mc
INNER JOIN Countries AS c ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m ON mc.MountainId = m.Id
INNER JOIN Peaks AS p ON m.Id = p.MountainId
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY Elevation DESC

--13. Count Mountain Ranges
SELECT c.CountryCode,
	   COUNT(MountainId) AS MountainRanges 
	 FROM MountainsCountries AS mc
INNER JOIN Countries AS c ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('US','RU','BG')
GROUP BY c.CountryCode

--14. Countries with Rivers
SELECT TOP (5) CountryName,
			   RiverName
	 FROM CountriesRivers AS cr
FULL OUTER JOIN Countries AS c ON cr.CountryCode = c.CountryCode
FULL OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE ContinentCode = 'AF'
ORDER BY CountryName ASC

--15. Continents and Currencies
SELECT ContinentCode,
		CurrencyCode,
		CurrencyUsage 
	FROM (SELECT ContinentCode,
				 CurrencyCode,
				 CurrencyUsage,
				 DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS [CurrencyRank]
			FROM (SELECT ContinentCode,
						 CurrencyCode,
						 Count(*) AS CurrencyUsage
					FROM Countries
				  GROUP BY ContinentCode,CurrencyCode
				  ) AS [CurrencyCountQuery]
	WHERE CurrencyUsage > 1) AS [CurrencyRankingQuery]
WHERE CurrencyRank =1
ORDER BY ContinentCode

--16. Countries without any mountains
SELECT COUNT(*) AS Count FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE mc.MountainId IS NULL
	
--17. Highest Peak and Longest River by country
SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.Length) AS LongestRiverLength 
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC,CountryName ASC

--18. Highest PeakName and Elevation by country
SELECT TOP(5)
	CountryName AS Country,
	ISNULL(PeakName,'(no highest peak)')AS [Highest Peak Name],
	ISNULL(Elevation,0) AS [Highest Peak Elevation],
	ISNULL(MountainRange,'(no mountain)') AS Mountain 
FROM (	
	SELECT c.CountryName,
		   p.PeakName,
		   p.Elevation,
		   m.MountainRange,
		   DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId) AS PeaksRankingSubquery
WHERE PeakRank = 1
ORDER BY Country,[Highest Peak Name]
