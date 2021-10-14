--Section.01 DDL
---01. Create Airport database
CREATE TABLE Planes(
Id INT IDENTITY PRIMARY KEY,
Name VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
Range INT NOT NULL
)

CREATE TABLE Flights(
Id INT IDENTITY PRIMARY KEY,
DepartureTime DATETIME,
ArrivalTime DATETIME,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
Id INT IDENTITY PRIMARY KEY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
Address VARCHAR(30),
PassportId VARCHAR(11)
)

CREATE TABLE LuggageTypes(
Id INT IDENTITY PRIMARY KEY,
Type VARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages(
Id INT IDENTITY PRIMARY KEY,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
Id INT IDENTITY PRIMARY KEY,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(15,2) NOT NULL
)

--Section.02 DML
---02. Insert
INSERT INTO Planes VALUES
('Airbus 336',112,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

---03. Update
UPDATE Tickets
	SET Price += Price * 0.13
	WHERE FlightId IN (
						SELECT FlightId FROM Tickets AS t
							INNER JOIN Flights AS f ON t.FlightId = f.Id
							WHERE f.Destination = 'Carlsbad'
					  )
---04. Delete
DELETE FROM Tickets
	WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')
DELETE FROM Flights
	WHERE Destination ='Ayn Halagim'

--Section.03 Querying
---05. The "Tr" Planes
SELECT * FROM Planes
	WHERE Name LIKE '%tr%'
	ORDER BY Id ASC,Name ASC,Seats ASC,Range ASC

---06. Flight Profits
SELECT FlightId,SUM(Price) Price FROM Tickets
	GROUP BY FlightId
	ORDER BY Price DESC, FlightId ASC

---07. Passenger Trips
SELECT
	CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	Origin,
	Destination 
FROM Tickets AS t
	INNER JOIN Passengers AS p ON t.PassengerId = p.Id
	INNER JOIN Flights AS f ON t.FlightId = f.Id
	ORDER BY [Full Name],Origin,Destination

---08. Non Adventures People
SELECT
	FirstName,
	LastName,
	Age 
FROM Passengers AS p
	LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
	WHERE t.Id IS NULL
	ORDER BY Age DESC,FirstName,LastName

---09. Full Info
SELECT
	CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	pl.Name AS [Plane Name],
	CONCAT(f.Origin,' - ',f.Destination) AS Trip,
	lt.Type AS [Luggage Type]
FROM Tickets AS t
	JOIN Passengers AS p ON t.PassengerId = p.Id
	JOIN Flights AS f ON t.FlightId = f.Id
	JOIN Luggages AS l ON t.LuggageId = l.Id
	JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
	JOIN Planes AS pl ON f.PlaneId = pl.Id
	ORDER BY [Full Name],[Plane Name],Trip,[Luggage Type]

---10. PSP
SELECT pl.Name AS [Name],pl.Seats,COUNT(t.Id) AS [Passengers Count] FROM Tickets AS t
	RIGHT JOIN Flights AS f ON t.FlightId = f.Id
	RIGHT JOIN Planes AS pl ON f.PlaneId = pl.Id
	GROUP BY pl.Id,pl.Name,pl.Seats
	ORDER BY [Passengers Count] DESC, [Name] ASC ,Seats ASC

GO
--Section.04 Programmability
---11. Vacation
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(MAX), @destination VARCHAR(MAX), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@peopleCount <= 0)
		BEGIN
		RETURN 'Invalid people count!'
		END
	DECLARE @currentDestination INT;
	DECLARE @planeId INT;
	DECLARE @allowedPeopleCount INT;
	SET @currentDestination = (SELECT Id FROM Flights WHERE Origin = @origin AND Destination = @destination)
	IF (@currentDestination IS NULL)
	BEGIN
	RETURN 'Invalid flight!'
	END
	SET @planeId = (SELECT PlaneId FROM Flights WHERE Origin = @origin AND Destination = @destination)
	SET @allowedPeopleCOunt = (SELECT Seats FROM Planes
		WHERE Id = @planeId)
	IF(@peopleCount > @allowedPeopleCount)
	BEGIN
	RETURN 'Invalid flight!'
	END
	RETURN CONCAT('Total price ',(SELECT (t.Price * @peopleCount) FROM Tickets AS t
		INNER JOIN Flights AS f ON t.FlightId = f.Id
		WHERE f.Origin = @origin AND Destination = @destination))											
END

GO
--12. Wrong Data
CREATE PROC usp_CancelFlights
AS
BEGIN
UPDATE Flights
	SET ArrivalTime = NULL,
		DepartureTime = NULL
	WHERE ArrivalTime > DepartureTime
END