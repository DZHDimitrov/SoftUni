--Section.1 DDL
CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2) 
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT Not Null,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATETIME NOT NULL,
	ArrivalDate DATETIME NOT NULL,
	ReturnDate DATETIME NOT NULL,
	CancelDate DATETIME,
	 CONSTRAINT CHK_CheckDate1 CHECK(BookDate < ArrivalDate),
	 CONSTRAINT CHK_CheckDate3 CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT Not Null CHECK(Luggage >= 0)
	PRIMARY KEY(AccountId, TripId)
)
--Section.2 DML
---02. Insert
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
  ('John', 'Smith', 'Smith', '34', '1975-07-21', 'j_smith@gmail.com'),
  ('Gosho', NULL, 'Petrov', '11', '1978-05-16', 'g_petrov@gmail.com'),
  ('Ivan', 'Petrovich', 'Pavlov', '59', '1849-09-26', 'i_pavlov@softuni.bg'),
  ('Friedrich', 'Wilhelm', 'Nietzsche', '2', '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
  (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
  (102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
  (103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
  (104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
  (109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

---03. Update
UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN (5, 7, 9)

---04. Delete
DELETE FROM AccountsTrips
WHERE AccountId = 47

--Section 3. Querying

---05. EEE-Mails
SELECT
	FirstName,
	LastName,
	FORMAT(BirthDate,'MM-dd-yyyy'),
	c.Name AS HomeTown,Email
FROM Accounts AS a
	INNER JOIN Cities AS c ON a.CityId = c.Id
	WHERE Email LIKE 'e%'
	ORDER BY c.Name ASC

---06. City  Statistics
SELECT c.Name, Count(*) AS Hotels FROM Hotels AS h
	INNER JOIN Cities AS c ON h.CityId = c.Id
	GROUP BY CityId,c.Name
	ORDER BY Hotels DESC,c.Name ASC

---07. Longest and Shortest Trips
SELECT
AccountId,
CONCAT(a.FirstName, ' ',a.LastName) AS FullName,
LongestTrip,ShortestTrip 
FROM(
	SELECT
	AccountId,
	MAX(DATEDIFF(day,t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS ShortestTrip
	FROM AccountsTrips AS act
		INNER JOIN Accounts AS a ON act.AccountId = a.Id
		INNER JOIN Trips AS t ON act.TripId = t.Id
		WHERE a.MiddleName IS NULL AND CancelDate IS NULL
		GROUP BY AccountId
		) AS temp
INNER JOIN Accounts AS a ON temp.AccountId = a.Id
ORDER BY LongestTrip DESC, ShortestTrip ASC

---08. Metropolis
SELECT temp.Id,c.Name,c.CountryCode,Accounts FROM(
	SELECT
		CityId AS Id, 
		COUNT(*) AS Accounts 
	FROM Accounts AS a
		INNER JOIN Cities AS c ON a.CityId = c.Id
		GROUP BY a.CityId
		) AS temp
INNER JOIN Cities AS c ON temp.Id = c.Id
ORDER BY Accounts DESC

---09. Romantic Getaways
SELECT
	a.Id,
	Email,
	c.Name AS City,
	COUNT(*) AS Trips
FROM AccountsTrips AS act
	 INNER JOIN Accounts AS a ON act.AccountId = a.Id
	 INNER JOIN Cities AS c ON a.CityId = c.Id
	 INNER JOIN Trips AS t ON act.TripId = t.Id
	 INNER JOIN Rooms AS r ON t.RoomId = r.Id
	 INNER JOIN Hotels AS h ON r.HotelId = h.Id
	 WHERE a.CityId = h.CityId
	 GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips DESC, a.Id

---10. GDPR Violation
SELECT
	t.Id,
	CONCAT(a.FirstName,' ',ISNULL(a.MiddleName + ' ',''),a.LastName) AS FullName,
	ca.Name AS [From],
	c.Name AS [To],
	CASE 
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate), ' days')
	END AS Duration
FROM Trips AS t
INNER JOIN AccountsTrips AS act ON t.Id = act.TripId
INNER JOIN Accounts AS a ON act.AccountId = a.Id
INNER JOIN Cities AS ca ON a.CityId = ca.Id
INNER JOIN Rooms AS r ON t.RoomId = r.Id
INNER JOIN Hotels AS h ON r.HotelId = h.Id
INNER JOIN Cities AS c ON c.Id = h.CityId
ORDER BY FullName,t.Id

---11. Programmability
GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME2, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
DECLARE @BookedRooms TABLE(Id INT)
INSERT INTO @BookedRooms
	SELECT DISTINCT R.Id
	FROM Rooms AS R
	LEFT JOIN Trips AS T ON R.Id = T.RoomId
	WHERE R.HotelId = @HotelId AND @Date BETWEEN T.ArrivalDate AND T.ReturnDate AND T.CancelDate IS NULL

DECLARE @Rooms TABLE (Id INT,Price DECIMAL(15,2),Type VARCHAR(20),Beds INT,TotalPrice DECIMAL(15,2))
INSERT INTO @Rooms
	SELECT TOP(1)
	R.Id,
	R.Price,
	R.Type,
	R.Beds,
	@People * (H.BaseRate + R.Price) AS TotalPrice
	FROM Rooms AS R
	LEFT JOIN Hotels AS H ON R.HotelId = H.Id
	WHERE R.HotelId = @HotelId AND
	R.Beds >= @People AND
	R.Id NOT IN (SELECT Id FROM @BookedRooms)
	ORDER BY TotalPrice DESC

DECLARE @RoomCount INT = (SELECT COUNT(*) FROM Rooms)

IF(@RoomCount < 1)
	BEGIN
		RETURN 'No rooms available'
	END
DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', Type, ' (', Beds, ' beds) - ', '$', TotalPrice)
                                    FROM @Rooms)
RETURN @Result
END
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

GO
---12. Switch Room
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
  BEGIN
    DECLARE @SourceHotelId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                    JOIN Trips T on R.Id = T.RoomId
                                  WHERE T.Id = @TripId)

    DECLARE @TargetHotelId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                  WHERE R.Id = @TargetRoomId)

    IF (@SourceHotelId <> @TargetHotelId)
      THROW 50013, 'Target room is in another hotel!', 1

    DECLARE @PeopleCount INT = (SELECT COUNT(*)
                                FROM AccountsTrips
                                WHERE TripId = @TripId)

    DECLARE @TargetRoomBeds INT = (SELECT Beds
                                   FROM Rooms
                                   WHERE Id = @TargetRoomId)

    IF (@PeopleCount > @TargetRoomBeds)
      THROW 50013, 'Not enough beds in target room!', 1

    UPDATE Trips
    SET RoomId = @TargetRoomId
    WHERE Id = @TripId
  END
EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

