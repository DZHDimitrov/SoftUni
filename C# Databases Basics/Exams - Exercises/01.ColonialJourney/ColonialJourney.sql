--Section 1. DDL
--- 01. Create Database
CREATE TABLE Planets (
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
)

CREATE TABLE Spaceports (
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
PlanetId INT NOT NULL FOREIGN KEY REFERENCES Planets(Id),

)

CREATE TABLE Spaceships (
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT (0)
)

CREATE TABLE Colonists (
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) NOT NULL UNIQUE,
BirthDate DATE NOT NULL
)

CREATE TABLE Journeys (
Id INT IDENTITY PRIMARY KEY,
JourneyStart DateTime2 NOT NULL,
JourneyEnd Datetime2 NOT NULL,
Purpose VARCHAR(11) NULL CHECK (Purpose IN ('Medical' , 'Technical' , 'Educational' , 'Military',NULL)),
DestinationSpaceportId INT NOT NULL FOREIGN KEY REFERENCES Spaceports(Id),
SpaceshipId INT NOT NULL FOREIGN KEY REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards (
Id INT IDENTITY PRIMARY KEY,
CardNumber VARCHAR(10) NOT NULL CHECK (LEN(CardNumber) = 10),
JobDuringJourney VARCHAR(8) NULL CHECK (JobDuringJourney IN ('Pilot','Engineer','Trooper','Cleaner','Cook',NULL)),
ColonistId INT NOT NULL FOREIGN KEY REFERENCES Colonists(Id),
JourneyId INT NOT NULL FOREIGN KEY REFERENCES Journeys(Id)
)

--Section 2. DML

---02. Insert
INSERT INTO Planets VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',6)

SELECT * FROM Spaceships

---03. Update
UPDATE Spaceships
	SET LightSpeedRate += 1
	WHERE Id BETWEEN 8 and 12

---04. Delete
DELETE FROM TravelCards
	WHERE JourneyId IN (1,2,3)
DELETE FROM Journeys
	WHERE Id IN (1,2,3)

--SECTION 3. Querying

---05. Select all military journeys
SELECT 
Id,
FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
	WHERE Purpose = 'Military'
	ORDER BY JourneyStart ASC

---06. Select all pilots
SELECT 
c.Id,
CONCAT(c.FirstName,' ',c.LastName) AS full_name
FROM TravelCards AS tc
	INNER JOIN Colonists AS c ON tc.ColonistId = c.Id
	WHERE tc.JobDuringJourney = 'Pilot'
	ORDER BY c.Id ASC

---7. Count Colonists
SELECT COUNT(*) AS count FROM TravelCards AS tc
	INNER JOIN Colonists AS c ON tc.ColonistId = c.Id
	INNER JOIN Journeys AS j ON tc.JourneyId = j.Id
	WHERE j.Purpose = 'Technical'

---8. Select spaceships with pilots younger than 30 years
SELECT s.Name,s.Manufacturer FROM TravelCards AS  tc
	INNER JOIN Journeys AS j ON tc.JourneyId = j.Id
	INNER JOIN Colonists AS c ON tc.ColonistId = c.Id
	INNER JOIN Spaceships AS s ON j.SpaceshipId = s.Id
	WHERE YEAR('01/01/2019') - YEAR(c.BirthDate) < 30 AND tc.JobDuringJourney='pilot'
	ORDER BY s.Name

--- 9. Select all planets and their journey count
SELECT p.Name,COUNT(*) AS JourneysCount FROM Journeys AS j
	INNER JOIN Spaceports as sp ON j.DestinationSpaceportId = sp.Id
	INNER JOIN Planets as p ON sp.PlanetId = p.Id
	GROUP BY p.Name
	ORDER BY JourneysCount DESC,p.Name ASC

---10. Select Second Oldest Important Colonist
SELECT 
JobDuringJourney,
CONCAT(c.FirstName,' ',c.LastName) AS FullName,
JobRank 
FROM (
	SELECT
	tc.JobDuringJourney,
	tc.ColonistId,
	DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) AS JobRank
	FROM TravelCards as tc
	INNER JOIN Colonists AS c ON tc.ColonistId = c.Id
	GROUP BY tc.JobDuringJourney,c.BirthDate,tc.ColonistId) as tempQuery
INNER JOIN Colonists AS c ON c.Id = tempQuery.ColonistId
WHERE tempQuery.JobRank = 2
ORDER BY tempQuery.JobDuringJourney

GO
--Section 4. Programmability

--- 11.Get Colonists Count
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
RETURN (SELECT COUNT(*) FROM Journeys AS j
	JOIN Spaceports AS s ON s.Id = j.DestinationSpaceportId
	JOIN Planets AS p ON p.Id = s.PlanetId
	JOIN TravelCards AS tc ON tc.JourneyId = j.Id
	JOIN Colonists AS c ON c.Id = tc.ColonistId
	WHERE p.Name = @PlanetName)
END

GO

SELECT dbo.udf_GetColonistsCount('Otroyphus') AS Count

GO

--- 12.Change Journey Purpose
CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30))
AS
BEGIN
	IF(@JourneyId NOT IN (SELECT Id FROM Journeys))
	BEGIN
		;THROW 50001, 'The journey does not exist!', 1;
	END
	ELSE IF(@NewPurpose = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId))
	BEGIN
		;THROW 50002, 'You cannot change the purpose!',2;
	END
	UPDATE Journeys
		SET Purpose = @NewPurpose
		WHERE Id = @JourneyId
END

EXEC usp_ChangeJourneyPurpose 196,'Technical'
	