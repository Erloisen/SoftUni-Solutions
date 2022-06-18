/****** Section 1. DDL (30 pts) ******/
-- 1. Database design -----------------
CREATE DATABASE Airport
GO

USE Airport
GO

CREATE TABLE Passengers
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[FullName] VARCHAR(100) NOT NULL UNIQUE
	,[Email] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Pilots
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(30) NOT NULL UNIQUE
	,[LastName] VARCHAR(30) NOT NULL UNIQUE
	,[Age] TINYINT NOT NULL CHECK([Age] BETWEEN 21 AND 62)
	,[Rating] FLOAT CHECK([Rating] BETWEEN 0.00 AND 10.00)
)


CREATE TABLE AircraftTypes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[TypeName] VARCHAR(30) NOT NULL UNIQUE
)


CREATE TABLE Aircraft
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Manufacturer] VARCHAR(25) NOT NULL
	,[Model] VARCHAR(30) NOT NULL
	,[Year] INT NOT NULL
	,[FlightHours] INT
	,[Condition] CHAR(1) NOT NULL
	,[TypeId] INT NOT NULL REFERENCES AircraftTypes([Id])
	,CHECK([Year] >= 0)
)


CREATE TABLE PilotsAircraft
(
	[AircraftId] INT NOT NULL REFERENCES Aircraft([Id])
	,[PilotId] INT NOT NULL REFERENCES Pilots([Id])
	,PRIMARY KEY([AircraftId], [PilotId])
)


CREATE TABLE Airports
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[AirportName] VARCHAR(70) NOT NULL
	,[Country] VARCHAR(100) NOT NULL
)

CREATE TABLE FlightDestinations
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[AirportId] INT NOT NULL REFERENCES Airports([Id])
	,[Start] DATETIME NOT NULL
	,[AircraftId] INT NOT NULL REFERENCES Aircraft([Id])
	,[PassengerId] INT NOT NULL REFERENCES Passengers([Id])
	,[TicketPrice] DECIMAL(18, 2) NOT NULL DEFAULT 15
)


/****** Section 2. DML (10 pts) ******/
-- 2. Insert --------------------------
DECLARE @currentId INT;
	SET @currentId = 5
  WHILE (@currentId <= 15)
  BEGIN
	  DECLARE @fullName VARCHAR(100);
  	      SET @fullName = (SELECT CONCAT(p.[FirstName], ' ', p.[LastName])
  					         FROM Pilots AS p
  					        WHERE p.[Id] = @currentId)
  
  	  DECLARE @email VARCHAR(50);
  	      SET @email = (SELECT CONCAT(p.[FirstName], p.[LastName], '@gmail.com')
  				          FROM Pilots AS p
  				         WHERE p.[Id] = @currentId)
  	
  INSERT INTO Passengers([FullName], [Email])
  	   VALUES (@fullName, @email)
  
  	      SET @currentId += 1
  END


-- 3. Update --------------------------
UPDATE Aircraft 
   SET [Condition] = 'A'
 WHERE ([Condition] IN ('C', 'B')) AND ([FlightHours] IS NULL OR [FlightHours] <= 100) AND ([Year] >= 2013)

SELECT *
FROM Aircraft
WHERE ([Condition] IN ('C', 'B')) AND ([FlightHours] IS NULL OR [FlightHours] <= 100) AND ([Year] >= 2013)

SELECT *
FROM Aircraft
WHERE [Condition] = 'A'


-- 4. Delete --------------------------
DELETE
  FROM Passengers
 WHERE LEN([FullName]) <= 10
