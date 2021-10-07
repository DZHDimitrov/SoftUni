--01. Records' Count
SELECT COUNT(*) AS Count FROM WizzardDeposits

--02. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

--03. Longest Magic Wand Per Deposit Groups
SELECT DepositGroup,MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
	GROUP BY DepositGroup

--04. Smallest Deposit Group Per Magic Wand Size
SELECT TOP(2) 
	DepositGroup 
FROM 
	(SELECT 
		DepositGroup,
		AVG(MagicWandSize) AS AverageWandSize 
	 FROM WizzardDeposits
	 GROUP BY DepositGroup) as dt
ORDER BY AverageWandSize ASC

--05. Deposits Sum
SELECT DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
	GROUP BY DepositGroup

--06. Deposits Sum for Ollivander Family
SELECT DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup

--07. Deposits Filter
SELECT DepositGroup,SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

--08. Deposit Charge
SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator
	ORDER BY MagicWandCreator ASC

--09. Age Groups
SELECT 
	CASE
		WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
		WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
		WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
		WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
		WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
		WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroups,
	COUNT(*) As WizardCount
FROM WizzardDeposits
GROUP BY
	CASE
		WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
		WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
		WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
		WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
		WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
		WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
		ELSE '[61+]'
	END

--10. First Letter
SELECT DISTINCT SUBSTRING(FirstName,1,1) AS FirstLetter FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY FirstName,LastName
	ORDER BY FirstLetter ASC

--11. Average Interest
SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest FROM WizzardDeposits
	WHERE DepositStartDate > '01/01/1985'
	GROUP BY DepositGroup,IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12. Rich Wizard, Poor Wizard
SELECT SUM(dt.[difference]) As SumDifference
FROM (SELECT DepositAmount - (SELECT DepositAmount FROM WizzardDeposits WHERE Id = g.Id + 1) 
AS [difference] FROM WizzardDeposits g) AS dt

--13. Departments Total Salaries
GO
SELECT DepartmentID,SUM(Salary) AS TotalSalary FROM Employees
	GROUP BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID,MIN(Salary) AS MinimumSalary FROM Employees
	WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
	GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT * INTO temp FROM Employees
	WHERE Salary > 30000

DELETE FROM temp
	WHERE ManagerID = 42

UPDATE temp
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID,AVG(Salary) AS AverageSalary FROM temp
	GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID,MAX(Salary) AS MaxSalary FROM Employees
	GROUP BY DepartmentID
	HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

--17. Employees Count Salaries
SELECT COUNT(*) AS Count FROM Employees
	WHERE ManagerID IS NULL

--18. 3rd Highest Salary
SELECT 
	DepartmentID,
	Salary
FROM (
	SELECT
		DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
	GROUP BY DepartmentID,Salary) as sub
WHERE sub.SalaryRank = 3

--19. Salary Challenge
SELECT TOP 10  e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
INNER JOIN
(SELECT e.DepartmentID, avg(e.Salary) AS avgs
FROM Employees AS e
GROUP BY e.DepartmentID) AS avgSalaries on e.DepartmentID = avgSalaries.DepartmentID
WHERE e.Salary > avgSalaries.avgs
ORDER BY e.DepartmentID
