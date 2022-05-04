CREATE DATABASE DatabaseDemo
USE DatabaseDemo

CREATE TABLE Passports
(
	[PassportID]		INT IDENTITY(101, 1) PRIMARY KEY
	,[PassportNumber]	VARCHAR(8) UNIQUE
)

INSERT INTO Passports([PassportNumber])
	VALUES ('N34FG21B')
		   ,('K65LO4R7')
		   ,('ZE657QP2')

CREATE TABLE Persons
(
	[PersonID]		INT IDENTITY(1, 1) PRIMARY KEY
	,[FirstName]	NVARCHAR(50) NOT NULL
	,[Salary]		DECIMAL(7, 2) NOT NULL
	,[PassportID]	INT REFERENCES Passports(PassportID)
)

INSERT INTO Persons([FirstName], [Salary], [PassportID])
	VALUES ('Roberto', 43300.00, 102)
		   ,('Tom', 56100.00, 103)
		   ,('Yana', 60200.00, 101)

SELECT [FirstName], [Salary], pass.[PassportNumber]
	FROM Persons AS p
	JOIN Passports AS pass ON pass.PassportID = p.PassportID