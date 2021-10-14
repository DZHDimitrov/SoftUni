--Section.01 DDL

---Create Bitbucket database
CREATE TABLE Users(
Id INT IDENTITY PRIMARY KEY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT NOT NULL,
ContributorId INT NOT NULL,
PRIMARY KEY (RepositoryId,ContributorId),
FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),
FOREIGN KEY (ContributorId) REFERENCES Users(Id)
)

CREATE TABLE Issues (
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL CONSTRAINT CHK_IssueLength CHECK (Len(IssueStatus) = 6),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits (
Id INT IDENTITY PRIMARY KEY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT REFERENCES Issues(Id) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files (
Id INT IDENTITY PRIMARY KEY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(15,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id)
)

--Section.02 DML

---02. Insert
INSERT INTO Files VALUES
('Trade.idk',2598.0,1,1),
('menu.net',9238.31,2,2),
('Administrate.soshy',1246.93,3,3),
('Controller.php',7353.15,4,4),
('Find.java',9957.86,5,5),
('Controller.json',14034.87,3,6),
('Operate.xix',7662.92,7,7)

INSERT INTO Issues VALUES
('Critical Problem with HomeController.cs file','open',1,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open',9,8)

---03. Update
UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId = 6

---04. Delete
DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3
DELETE FROM Issues
	WHERE RepositoryId = 3

--Section.03 Querying

---05. Commits
SELECT
	Id,
	Message,
	RepositoryId,
	ContributorId
FROM Commits
	ORDER BY Id ASC,Message ASC, RepositoryId ASC, ContributorId ASC
	
---06. Front-end
SELECT
	Id,
	Name,
	Size 
FROM Files
	WHERE Size > 1000 AND Name LIKE '%html%'
	ORDER BY Size DESC,Id ASC,Name ASC

---07. Issue Assignment
SELECT i.Id,CONCAT(u.Username,' : ',i.Title) AS IssueAssignee FROM Issues AS i
	INNER JOIN Users AS u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, i.AssigneeId ASC

---08. Single Files
SELECT f.Id,f.Name,CONCAT(f.Size,'KB') AS Size FROM Files AS f
	LEFT JOIN Files AS fi ON f.Id = fi.ParentId
	WHERE fi.Id IS NULL

---09. Commits in Repositories
SELECT TOP(5) c.RepositoryId,r.Name,COUNT(r.Id) AS Commits FROM Commits AS c
	INNER JOIN Repositories AS r ON c.RepositoryId =  r.Id
	GROUP BY RepositoryId,r.Name
	ORDER BY Commits DESC, c.RepositoryId ASC, r.Name ASC

SELECT TOP(5) r.Id,r.Name,COUNT(r.Id) AS Commits FROM Repositories AS r
	INNER JOIN Commits AS c ON r.Id = c.RepositoryId
	INNER JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
	GROUP BY r.Id,r.Name
	ORDER BY Commits DESC, r.Id,r.Name

---10. Average Size
SELECT Username,AVG(Size) AS Size FROM Files AS f
	INNER JOIN Commits AS c ON f.CommitId = c.Id
	INNER JOIN Users AS u ON c.ContributorId = u.Id
	GROUP BY c.ContributorId,Username
	ORDER BY Size DESC,Username ASC

--Section 04. Programmability
--- All User Commits

---11. All User Commits
GO

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
AS
BEGIN
RETURN (
SELECT COUNT(*) FROM Commits AS c
INNER JOIN Users AS u ON c.ContributorId = u.Id
WHERE u.Username = @username
)
END

GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

---12. Search for Files
GO

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(MAX))
AS
BEGIN
SELECT Id,Name,CONCAT(Size,'KB') AS Size FROM Files
WHERE Name LIKE '%' + @fileExtension
ORDER BY Id ASC, Name ASC, Size DESC
END

EXEC usp_SearchForFiles 'txt'
	