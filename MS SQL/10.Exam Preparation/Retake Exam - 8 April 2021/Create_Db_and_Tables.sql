/****** Section 1. DDL (30 pts) ******/
-- 1. Table design --------------------
CREATE DATABASE [Service]
GO

USE [Service]
GO

CREATE TABLE Users
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
    ,[Username] VARCHAR(30) NOT NULL UNIQUE
	,[Password] VARCHAR(50) NOT NULL
    ,[Name] VARCHAR(50) 
    ,[Birthdate] DATETIME2
    ,[Age] INT CHECK([Age] BETWEEN 14 AND 110)
    ,[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
    ,[FirstName] VARCHAR(25)
    ,[LastName] VARCHAR(25)
    ,[Birthdate] DATETIME
    ,[Age] INT CHECK([Age] BETWEEN 14 AND 110)
    ,[DepartmentId] INT REFERENCES Departments([Id])
)

CREATE TABLE Categories
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
    ,[DepartmentId] INT NOT NULL REFERENCES Departments([Id])
)

CREATE TABLE [Status]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[CategoryId] INT NOT NULL REFERENCES Categories([Id])
    ,[StatusId] INT NOT NULL REFERENCES [Status]([Id])
    ,[OpenDate] DATETIME NOT NULL
    ,[CloseDate] DATETIME
    ,[Description] VARCHAR(200) NOT NULL
    ,[UserId] INT NOT NULL REFERENCES Users([Id])
    ,[EmployeeId] INT REFERENCES Employees([Id])
)
GO

/****** Section 2. DML (10 pts) ******/
-- 2. Insert --------------------------
INSERT INTO Employees([FirstName], [LastName], [Birthdate], [DepartmentId])
VALUES ('Marlo', 'O''Malley', '1958-9-21', 1)
       ,('Niki', 'Stanaghan', '1969-11-26', 4)
       ,('Ayrton', 'Senna', '1960-03-21', 9)
       ,('Ronnie', 'Peterson', '1944-02-14', 9)
       ,('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId])
VALUES (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2)
       ,(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5)
       ,(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2)
       ,(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)
GO

-- 3. Update --------------------------
UPDATE Reports
SET [CloseDate] = GETDATE()
WHERE [CloseDate] IS NULL
GO

-- 4. Delete --------------------------
DELETE
FROM Reports
WHERE [StatusId] = 4
GO

