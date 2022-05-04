CREATE DATABASE University
USE University

CREATE TABLE Majors
(
	[MajorID] INT PRIMARY KEY
	,[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Students
(
	[StudentID] INT PRIMARY KEY
	,[StundetNumber] CHAR(10) NOT NULL UNIQUE
	,[StudentName] NVARCHAR(100) NOT NULL
	,[MajorID] INT REFERENCES Majors([MajorID])
)

CREATE TABLE Subjects
(
	[SubjectID] INT PRIMARY KEY
	,[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE Payments
(
	[PaymentID] INT PRIMARY KEY
	,[PaymentDate] DATE NOT NULL
	,[PaymentAmount] DECIMAL(10, 2) NOT NULL
	,[StudentID] INT REFERENCES Students([StudentID])
)

CREATE TABLE Agenda
(
	[StudentID] INT REFERENCES Students([StudentID])
	,[SubjectID] INT REFERENCES Subjects([SubjectID])
	,PRIMARY KEY([StudentID], [SubjectID]) 
)