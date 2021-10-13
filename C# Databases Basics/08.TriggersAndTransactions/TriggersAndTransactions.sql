--01. Create Table Logs
CREATE TABLE Logs (
LogId INT IDENTITY PRIMARY KEY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum DECIMAL(15,2),
NewSum DECIMAL(15,2)
)

GO

CREATE TRIGGER sumchange ON Accounts
FOR UPDATE
AS
	BEGIN
		INSERT INTO Logs VALUES(
		(SELECT Id FROM deleted),
		(SELECT Balance FROM deleted),
		(SELECT Balance FROM inserted)
		)
	END

--02. Create Table Emails
CREATE TABLE NotificationEmails(
Id INT IDENTITY PRIMARY KEY,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
Subject VARCHAR (MAX),
Body VARCHAR(MAX)
)

GO

CREATE TRIGGER notify ON Logs
FOR INSERT
AS
	BEGIN
	INSERT INTO NotificationEmails VALUES
	(
	(SELECT AccountId FROM inserted),
	 CONCAT('Balance change for account: ',
               (
                   SELECT AccountId
                   FROM inserted
               )),
     CONCAT('On ', FORMAT(GETDATE(), 'dd-MM-yyyy HH:mm'), ' your balance was changed from ',
               (
                   SELECT OldSum
                   FROM Logs
               ), ' to ',
               (
                   SELECT NewSum
                   FROM Logs
               ), '.')
	)
	END

--03. Deposit Money

CREATE PROCEDURE usp_DepositMoney
(
                 @accountId   INT,
                 @moneyAmount MONEY
)
AS
     BEGIN
         IF(@moneyAmount < 0)
             BEGIN
                 RAISERROR('Cannot deposit negative value', 16, 1);
         END;
             ELSE
             BEGIN
                 IF(@accountId IS NULL
                    OR @moneyAmount IS NULL)
                     BEGIN
                         RAISERROR('Missing value', 16, 1);
                 END;
         END;
         BEGIN TRANSACTION;
         UPDATE Accounts
           SET
               Balance+=@moneyAmount
         WHERE Id = @accountId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Account doesn''t exists', 16, 1);
         END;
         COMMIT;
     END;

--04. Withdraw money
CREATE PROC usp_WithdrawMoney (@AccountId INT,@MoneyAmount MONEY)
AS
BEGIN
	IF (@MoneyAmount < 0)
	BEGIN
		RAISERROR('Cannot deposit negative value',16,1)
	END
	ELSE IF(@MoneyAmount IS NULL OR @AccountId IS NULL)
	BEGIN
		RAISERROR('Missing value',16,1)
	END
	ELSE IF(@MoneyAmount > (SELECT Balance FROM Accounts WHERE Id = @AccountId))
	BEGIN
		RAISERROR('Insufficient amount',16,1)
	END
	BEGIN TRANSACTION
	 UPDATE Accounts
           SET
               Balance-=@moneyAmount
         WHERE Id = @accountId;
         IF(@@ROWCOUNT < 1)
             BEGIN
                 ROLLBACK;
                 RAISERROR('Account doesn''t exists', 16, 1);
         END;
         COMMIT;
END

GO
--05. Money Transfer
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
	AS
		BEGIN TRANSACTION
			EXEC usp_DepositMoney @ReceiverId, @Amount;
			EXEC usp_WithdrawMoney @SenderId, @Amount;
	COMMIT

GO
--06. Trigger
CREATE TRIGGER tr_userGameItems_LevelRestriction ON UserGameItems
INSTEAD OF UPDATE
AS
	BEGIN
	IF((SELECT Level FROM UsersGames WHERE Id = (SELECT UserGameId From inserted)) < (SELECT MinLevel FROM Items WHERE Id = (SELECT ItemId FROM inserted)))
		BEGIN
		RAISERROR('Your current level is not enough',16,1)
		END

	INSERT INTO UserGameItems VALUES
	(
	(SELECT ItemId FROM inserted),
	(SELECT UserGameId FROM inserted)
	)
	END

--07. Employees with Three Projects
CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
BEGIN TRANSACTION
	DECLARE @ProjectsCount INT;
	SET @ProjectsCount = (SELECT COUNT(ProjectID) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

	IF (@ProjectsCount >= 3)
		BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!',16,1)
		END
	INSERT INTO EmployeesProjects VALUES
	(@emloyeeId,@projectID)
	COMMIT
END

--08. Deleted Employees
CREATE TABLE Deleted_Employees(
EmployeeId INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
MiddleName VARCHAR(50),
JobTitle VARCHAR(50),
DepartmentId INT,
Salary DECIMAL(15,2)
)

GO

CREATE TRIGGER tr_FiredEmployees ON Employees
AFTER DELETE
AS
INSERT INTO Deleted_Employees(
FirstName,
LastName,
MiddleName,
JobTitle,
DepartmentId,
Salary)
	SELECT
	d.FirstName,
	d.LastName,
	d.MiddleName,
	d.JobTitle,
	d.DepartmentID,
	d.Salary 
	FROM deleted AS d
