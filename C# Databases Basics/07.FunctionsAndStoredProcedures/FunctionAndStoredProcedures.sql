--01. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
	WHERE Salary > 35000
END

--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(19,4))
AS
BEGIN
	SELECT FirstName,LastName FROM Employees
		WHERE Salary >= @number
END

--03. Town Names Starting with
CREATE PROC usp_GetTownsStartingWith (@townName VARCHAR(50))
AS
BEGIN
	SELECT Name FROM Towns
	WHERE Name LIKE @townName + '%'
END

--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS
BEGIN
	SELECT FirstName,LastName FROM Employees as e
	INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.Name = @townName
END

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(20)
AS
BEGIN
	IF(@salary < 30000)
	BEGIN
		RETURN 'Low'
	END
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		RETURN 'Average'
	END
	RETURN 'High'
END

--06. Employees by salary level
CREATE PROC usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(20))
AS
BEGIN
	SELECT FirstName,LastName FROM (
		SELECT FirstName,LastName,dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees) temp
	WHERE [Salary Level] = @LevelOfSalary
END

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	DECLARE @isComprised BIT = 0
	WHILE @counter <= LEN(@word)
	BEGIN
		IF(CHARINDEX(SUBSTRING(@word,@counter,1),@setOfLetters) = 0)
		BEGIN
			RETURN 0
		END
		SET @counter += 1
	END
RETURN 1
END

--08. Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

DECLARE @empIDsToBeDeleted TABLE
(
Id int
)

INSERT INTO @empIDsToBeDeleted
SELECT e.EmployeeID
FROM Employees AS e
WHERE e.DepartmentID = @departmentId

ALTER TABLE Departments
ALTER COLUMN ManagerID int NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
WHERE EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
WHERE DepartmentID = @departmentId 

SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
SELECT CONCAT(FirstName,' ',LastName) AS [Full Name] FROM AccountHolders
END

EXEC usp_GetHoldersFullName

GO

--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
BEGIN
	SELECT FirstName AS [First Name],LastName AS [Last Name] FROM (
		SELECT FirstName,LastName,SUM(a.Balance) AS TotalBalance FROM AccountHolders as ah
		INNER JOIN Accounts as a ON ah.Id = a.AccountHolderId
		GROUP BY FirstName,LastName
		HAVING SUM(a.Balance) > @number) as temp
	ORDER BY FirstName,LastName
END

GO

EXEC usp_GetHoldersWithBalanceHigherThan 50

GO

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15,4),
@YearlyInterestRate FLOAT,
@NumberOfYears INT )
RETURNS DECIMAL(15,4)
BEGIN
    DECLARE @FutureValue DECIMAL(15,4);

    SET @FutureValue = @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
    
    RETURN @FutureValue
END

GO

--12. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	SELECT
	a.Id AS [Account Id],
	FirstName AS [First Name],
	LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance,@yearlyInterestRate,5) AS [Balance in 5 years] 
	FROM AccountHolders as ah
	INNER JOIN Accounts as a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId
END

EXEC dbo.usp_CalculateFutureValueForAccount 2,0.1

GO

--13. Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames(@gameName varchar(max))
RETURNS @returnedTable TABLE
(
SumCash money
)
AS
BEGIN
	DECLARE @result money

	SET @result = 
	(SELECT SUM(ug.Cash) AS Cash
	FROM
		(SELECT Cash, GameId, ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
		FROM UsersGames
		WHERE GameId = (SELECT Id FROM Games WHERE Name = @gameName)
		) AS ug
	WHERE ug.RowNumber % 2 != 0
	)

	INSERT INTO @returnedTable SELECT @result
	RETURN
END
