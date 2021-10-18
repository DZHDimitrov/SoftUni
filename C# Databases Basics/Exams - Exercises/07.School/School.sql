--Section.01 DDL
---01. Create School database
CREATE TABLE Students(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT CONSTRAINT chk_studentAgeRange CHECK (Age >= 5 AND Age <= 100),
Address NVARCHAR(50),
Phone NVARCHAR(10) CONSTRAINT chk_phoneLength CHECK (LEN(Phone) = 10)
)
CREATE TABLE Subjects(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(20) NOT NULL,
Lessons INT CONSTRAINT chk_lessons CHECK (Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT IDENTITY PRIMARY KEY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(15,2) CONSTRAINT chk_grade CHECK (Grade >= 2 AND Grade <= 6),
)

CREATE TABLE Exams(
Id INT IDENTITY PRIMARY KEY,
Date DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT NOT NULL,
ExamId INT NOT NULL,
Grade DECIMAL (15,2) CONSTRAINT chk_studentsExamsGrade CHECK (Grade >= 2 AND Grade <= 6)
PRIMARY KEY (StudentId,ExamId),
FOREIGN KEY (StudentId) REFERENCES Students(Id),
FOREIGN KEY (ExamId) REFERENCES Exams(Id)
)

CREATE TABLE Teachers(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Address NVARCHAR(20) NOT NULL,
Phone VARCHAR(10) CONSTRAINT chk_teacherPhoneLength CHECK (LEN(Phone) = 10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers(
StudentId INT NOT NULL,
TeacherId INT NOT NULL,
PRIMARY KEY (StudentId,TeacherId),
FOREIGN KEY (StudentId) REFERENCES Students(Id),
FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
)

--Section.02 DML
---02. Insert
INSERT INTO Teachers VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)

INSERT INTO Subjects VALUES
('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

---03. Update
SELECT * FROM Teachers
UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE (SubjectId = 1 OR SubjectId = 2) AND Grade >= 5.50

---04. Delete
DELETE FROM StudentsTeachers
	WHERE TeacherId IN 
	(
	SELECT Id FROM Teachers WHERE Phone LIKE '%72%'
	)
DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

--Section.03 Querying
---05.Teen Students
SELECT FirstName,LastName,Age FROM Students
	WHERE Age >= 12
	ORDER BY FirstName,LastName

---06.Students Teachers
SELECT s.FirstName,s.LastName,COUNT(TeacherId) AS TeachersCount FROM StudentsTeachers AS st
	INNER JOIN Students AS s ON s.Id = st.StudentId
	GROUP BY s.FirstName,S.LastName

---07.Students to Go
SELECT
	CONCAT(s.FirstName,' ',s.LastName) AS [Full Name]
FROM Students AS s
	LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
	WHERE se.StudentId IS NULL
	ORDER BY [Full Name]

---08. Top Students
SELECT TOP(10)
	S.FirstName,
	s.LastName,
	CONVERT(DECIMAL(15,2),AVG(Grade),2) AS Grade 
FROM StudentsExams AS st
	INNER JOIN Students AS s ON st.StudentId = s.Id
	GROUP BY StudentId,s.FirstName,s.LastName
	ORDER BY Grade DESC,s.FirstName,s.LastName

---09. Not So In The Studying
SELECT
CASE
	WHEN s.MiddleName IS NOT NULL THEN CONCAT(s.FirstName,' ',s.MiddleName,' ',s.LastName)
	ELSE CONCAT(s.FirstName,' ',s.LastName)
	END AS [Full Name]
FROM Students AS s
	LEFT JOIN StudentsSubjects AS sb ON s.Id = sb.StudentId
	WHERE sb.StudentId IS NULL
	ORDER BY [Full Name]

---10. Average Grade per Subject
SELECT
	s.Name,
	AVG(ss.Grade) AS AverageGrade
FROM StudentsSubjects AS ss
	INNER JOIN Subjects AS s ON ss.SubjectId = s.Id
	GROUP BY ss.SubjectId,s.Name
	ORDER BY ss.SubjectId

GO
---Section.04 Programmability
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(MAX)
BEGIN
	IF(
		(SELECT Id FROM Students WHERE Id = @studentId) IS NULL
	  )
	  BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	  END
    IF (@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END
DECLARE @CountOfGrades INT = (SELECT COUNT(StudentId) FROM StudentsExams
	WHERE StudentId = @studentId AND Grade >= @grade AND Grade <= @grade + 0.50
	GROUP BY StudentId)
DECLARE @StudentFirstName VARCHAR(MAX) = (SELECT FirstName FROM Students WHERE Id = @studentId)
	RETURN CONCAT('You have to update ',@CountOfGrades,' grades for the student ',@StudentFirstName)
END

GO

---12. Exclude from school
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF((SELECT s.Id FROM Students AS s WHERE s.Id = @StudentId) IS NULL)
		RAISERROR('This school has no student with the provided id!',16,1)
	BEGIN TRANSACTION
	BEGIN TRY
	DELETE FROM StudentsExams
		WHERE StudentId = @StudentId
	DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId
	DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId
	DELETE FROM Students
		WHERE Id = @StudentId
	COMMIT
	END TRY
	BEGIN CATCH
	ROLLBACK
	END CATCH
END

EXEC usp_ExcludeFromSchool 301
