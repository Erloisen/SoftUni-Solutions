CREATE DATABASE ColonialJourney
GO

USE ColonialJourney
GO

/****** Section 1. DDL  ******/
--01. Database Design----------
CREATE TABLE Planets
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[PlanetId] INT NOT NULL REFERENCES Planets([Id])
)

CREATE TABLE Spaceships
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,[Manufacturer] VARCHAR(30) NOT NULL
	,[LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE Colonists
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(20) NOT NULL
	,[LastName] VARCHAR(20) NOT NULL
	,[Ucn] VARCHAR(10) NOT NULL UNIQUE
	,[BirthDate] DATE NOT NULL
)

CREATE TABLE Journeys
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[JourneyStart] DATETIME NOT NULL
	,[JourneyEnd] DATETIME NOT NULL
	,[Purpose] VARCHAR(11)
	,[DestinationSpaceportId] INT NOT NULL REFERENCES Spaceports([Id])
	,[SpaceshipId] INT NOT NULL REFERENCES Spaceships([Id])
	,CHECK([Purpose] IN ('Medical', 'Technical', 'Educational', 'Military'))
)

CREATE TABLE TravelCards
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[CardNumber] VARCHAR(10) NOT NULL UNIQUE
	,[JobDuringJourney] VARCHAR(8)
	,[ColonistId] INT NOT NULL REFERENCES Colonists([Id])
	,[JourneyId] INT NOT NULL REFERENCES Journeys([Id])
	,CHECK(LEN([CardNumber]) = 10)
	,CHECK([JobDuringJourney] IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'))
)

GO

/****** Section 2. DML ******/
--02. Insert------------------
INSERT INTO Planets ([Name])
VALUES ('Mars')
	   ,('Earth')
	   ,('Jupiter')
	   ,('Saturn')

INSERT INTO Spaceships ([Name], [Manufacturer], [LightSpeedRate])
VALUES ('Golf', 'VW', 3)
	   ,('WakaWaka', 'Wakanda', 4)
	   ,('Falcon9', 'SpaceX', 1)
	   ,('Bed', 'Vidolov', 6)

GO

--03. Update------------------
UPDATE Spaceships
   SET [LightSpeedRate] += 1
 WHERE [Id] BETWEEN 8 AND 12

GO
--04. Delete------------------
DELETE FROM TravelCards
      WHERE [JourneyId] BETWEEN 1 AND 3

DELETE FROM Journeys
      WHERE [Id] BETWEEN 1 AND 3

GO