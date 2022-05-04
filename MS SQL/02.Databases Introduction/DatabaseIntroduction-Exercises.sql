/****** Exercises: Database Introduction  ******/
------------------------------------------------

----Problem 1.	Create Database----
CREATE DATABASE Minions
USE Minions


----Problem 2.	Create Tables----
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50)
)


----Problem 3.	Alter Minions Table----
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

----Problem 4.	Insert Records in Both Tables----
-- CRTL + SHIFT + R - clear cache
INSERT INTO Towns (Id, Name) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1,		'Kevin',	22,		1),
(2,		'Bob',		15,		3),
(3,		'Steward',	NULL,	2)

--SELECT * FROM Minions


----Problem 5.	Truncate Table Minions----
DELETE FROM Minions


----Problem 6.	Drop All Tables----
DROP TABLE Minions
DROP TABLE Towns

----Problem 7.	Create Table People----

CREATE TABLE People
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARCHAR(MAX),
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] CHAR NOT NULL CHECK (Gender = 'm' OR Gender = 'f'),
	[Birthdate] DATETIME NOT NULL,
	[Biography] NVARCHAR(MAX)
)
INSERT INTO People
(Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES ('Elsiaveta', 'https://softuni.bg/users/profile/showavatar/c1b7f815-a9fb-494e-9295-cb0aeb8fa3b6', '1.57', '45.700', 'f', '11/18/1980', 'Currently is studying a database course at SoftUni University'),
('Veneta', NULL, '1.70', '60.700', 'f', '03/21/1970', 'Shi is accountant'),
('Nelly', NULL, '1.77', '62.00', 'f', '06/30/1983', NULL),
('Stoyan', NULL, '1.97', '98.200', 'm', '11/17/1983', 'Currently is Director of the Sofia Regional Directorate of Forestry'),
('Vladimir', NULL, '1.65', '65.00', 'm', '05/24/1975', 'Currently is Director of Municipality forest department in Samokov')


----Problem 8.	Create Table Users----
CREATE TABLE Users
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARCHAR(MAX),
	[LastLoginTime] DATETIME,
	[IsDeleted] BIT 
)
INSERT INTO Users
([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('Elisaveta', '123456', 'https://softuni.bg/users/profile/showavatar/c1b7f815-a9fb-494e-9295-cb0aeb8fa3b6', '04/12/2022', 0),
		('Stoyan', 'StrongPass123', NULL, '01/01/2022', 0),
		('Niki', 'SomePass', NULL, '05/15/2022', 0),
		('Stamo', 'Pass123', NULL, '05/17/2022', 0),
		('Kaloyan', 'SPass123', NULL, '10/20/2022', 0)


----Problem 9.	Change Primary Key----
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0736A28AD6

ALTER TABLE Users
ADD CONSTRAINT PK__IdUsername
PRIMARY KEY (Id, Username) 


----Problem 10.	Add Check Constraint----
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN(Password) > 5)

----Problem 11.	Set Default Value of a Field----
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime]


----Problem 12.	Set Unique Field----
ALTER TABLE Users
DROP CONSTRAINT PK__IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UC_Username
UNIQUE (DATALENGTH(Username) >= 3)


----Problem 13.	Movies Database-----
CREATE DATABASE Movies

USE Movies
CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(200) NOT NULL,
	Notes VARCHAR(MAX),
)

CREATE TABLE Genres 
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX),
)

CREATE TABLE Categories  
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX),
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors([Id]),
	CopyRightYear INT NOT NULL,
	[Length] DECIMAL(5, 2),
	GenreId INT FOREIGN KEY REFERENCES Genres([Id]),
	CategoryId INT FOREIGN KEY REFERENCES Categories([Id]),
	Rating DECIMAL(5,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors ([DirectorName], [Notes])
VALUES ('Christopher Nolan', NULL),
		('Rajkumar Hirani', NULL),
		('David Fincher', NULL),
		('Quentin Tarantino', NULL),
		('David Yates', NULL)

INSERT INTO Genres ([GenreName], [Notes])
VALUES ('Action', NULL),
		('Comedy', NULL),
		('Fantasy', NULL),
		('Romance', NULL),
		('Mystery', NULL)

INSERT INTO Categories([CategoryName], [Notes])
VALUES ('Biography', NULL),
		('Sci-fi', NULL),
		('Documentary', NULL),
		('Adventure', NULL),
		('Musicals-Dance', NULL)

INSERT INTO Movies([Title], [DirectorId], [CopyRightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES ('The Shawshank Redemption', 3, 1994, 2.22, 2, 4, 9.3, 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.'),
		('The Godfather', 2, 1972, 2.55, 1, 3, 9.2, 'The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.'),
		('The Dark Knight', 1, 2008, 2.32, 1, 5, 9.1, 'When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.'),
		('The Lord of the Rings: The Return of the King', 4, 2003, 3.21, 3, 4, 9.0, NULL),
		('Schindler''s List', 5, 1993, 3.15, 4, 1, 9.0, 'In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.')

--DROP TABLE [Movies]


----Problem 14.	Car Rental Database----
CREATE DATABASE [CarRental]

USE [CarRental]
CREATE TABLE [Categories]
(
	[Id]			INT PRIMARY KEY IDENTITY
	,[CategoryName]	VARCHAR(50) NOT NULL
	,[DailyRate]	DECIMAL(5, 2) NOT NULL
	,[WeeklyRate]	DECIMAL(5, 2) NOT NULL
	,[MonthlyRate]	DECIMAL(5, 2) NOT NULL
	,[WeekendRate]	DECIMAL(5, 2) NOT NULL
)

CREATE TABLE [Cars]
(
	[Id]			INT PRIMARY KEY IDENTITY
	,[PlateNumber]	VARCHAR(8) UNIQUE NOT NULL
	,[Manufacturer]	VARCHAR(20) NOT NULL
	,[Model]		VARCHAR(30) NOT NULL
	,[CarYear]		INT
	,[CategoryId]	INT FOREIGN KEY REFERENCES [Categories]([Id])
	,[Doors]		TINYINT NOT NULL
	,[Picture]		VARCHAR(MAX)
	,[Condition]	VARCHAR(50)
	,[Available]	BIT NOT NULL
)

CREATE TABLE [Employees]
(
	[Id]			INT PRIMARY KEY IDENTITY
	,[FirstName]	VARCHAR(20) NOT NULL
	,[LastName]		VARCHAR(20) NOT NULL
	,[Title]		VARCHAR(30)
	,[Notes]		NVARCHAR(MAX)
)

CREATE TABLE [Customers]
(
	[Id]					INT PRIMARY KEY IDENTITY
	,[DriverLicenceNumber]	INT UNIQUE NOT NULL
	,[FullName]				VARCHAR(50) NOT NULL
	,[Address]				VARCHAR(100) NOT NULL
	,[City]					VARCHAR(30) NOT NULL
	,[ZIPCode]				SMALLINT
	,[Notes]				NVARCHAR(MAX)
)

CREATE TABLE [RentalOrders]
(
	[Id]				INT PRIMARY KEY IDENTITY
	,[EmployeeId]		INT FOREIGN KEY REFERENCES [Employees]([Id])
	,[CustomerId]		INT FOREIGN KEY REFERENCES [Customers]([Id])
	,[CarId]			INT FOREIGN KEY REFERENCES [Cars]([Id])
	,[TankLevel]		TINYINT NOT NULL
	,[KilometrageStart]	DECIMAL(9, 3) NOT NULL
	,[KilometrageEnd]	DECIMAL(9, 3) NOT NULL
	,[TotalKilometrage]	AS ([KilometrageEnd] - [KilometrageStart])
	,[StartDate]		DATETIME2 NOT NULL
	,[EndDate]			DATETIME2 NOT NULL
	,[TotalDays]		AS DATEDIFF(DAY, [StartDate], [EndDate])
	,[RateApplied]		DECIMAL(5, 2) NOT NULL
	,[TaxRate]			DECIMAL DEFAULT 0.20
	,[OrderStatus]		VARCHAR(30) NOT NULL
	,[Notes]			NVARCHAR(MAX)
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES ('Hatchback', 25.00, 150.00, 525.00, 75.00)
		,('Sedan', 38.50, 250.00, 899.00, 89.00)
		,('Coupe', 43.00, 279.00, 999.00, 99.00)

INSERT INTO [Cars]([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
VALUES ('CB1990AA', 'Audi', 'A7', 2022, 2, 5, 'https://mediaservice.audi.com/media/live/50710/fly1400x601n1/4ka/2021.png?wid=850', 'Brand new', 1)
		,('CO4567DE', 'BMW', '330i Sport', 2021, 3, 5, 'https://imgd.aeplcdn.com/664x374/cw/ec/37067/BMW-3-Series-Exterior-167583.jpg?wm=0&q=75', 'New', 1)
		,('B1234TH', 'Toyota', 'Yaris', 2021, 1, 3, NULL, 'New', 1)

INSERT INTO [Employees]([FirstName], [LastName],[Title], [Notes])
VALUES ('Ivan', 'Ivanov', 'Director', NULL),
		('Niki', 'Kostov', 'Manager', NULL),
		('Victor', 'Dakov', 'Saler', NULL)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
VALUES (123456789, 'Sofia Topalova', '23 Macedonia str.', 'Sofia', 1000, NULL)
		,(234567891, 'Ani Nikolova', '10 Ivan Vazov str.', 'Plovdiv', 4000, 'The driver licence is with expired date')
		,(345678912, 'Peter Petrov', '45 Elin Pelin str.', 'Veliko Tarnovo', 2300, 'Very good driver')

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [OrderStatus], [Notes])
VALUES (1, 3, 2, 55, 2500, 3864, '2022-04-13', '2022-04-20', 75.00, 'upcoming', NULL)
		,(2, 2, 1, 40, 17455, 17455, '2022-03-07', '2022-03-11', 425.00, 'refused', 'Forthcoming renewal of driver''s license')
		,(3, 1, 3, 60, 25000, 27896, '2022-04-08', '2022-04-17', 678.00, 'ongoing', NULL)
		
----Problem 15.	Hotel Database----
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
	[Id]				INT PRIMARY KEY
	,[FirstName]		VARCHAR(70) NOT NULL
	,[LastName]			VARCHAR(70) NOT NULL
	,[Title]			VARCHAR(50) NOT NULL
	,[Notes]			VARCHAR(MAX)
)
				   		
CREATE TABLE Customers
(
	[AccountNumber]		INT PRIMARY KEY
	,[FirstName]		VARCHAR(70) NOT NULL
	,[LastName]			VARCHAR(70) NOT NULL
	,[PhoneNumber]		CHAR(10) NOT NULL
	,[EmergencyName]	VARCHAR(70) NOT NULL
	,[EmergencyNumber]	CHAR(10) NOT NULL
	,[Notes]			VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	[RoomStatus]		BIT NOT NULL
	,[Notes]			VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
	[RoomType]			VARCHAR(20) NOT NULL
	,[Notes]			VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	[BedType]			VARCHAR(30) NOT NULL
	,[Notes]			VARCHAR(MAX)
)

CREATE TABLE Rooms
(
	[RoomNumber]		INT PRIMARY KEY
	,[RoomType]			VARCHAR(20) NOT NULL
	,[BedType]			VARCHAR(30) NOT NULL
	,[Rate]				INT 
	,[RoomStatus]		BIT NOT NULL
	,[Notes]			VARCHAR(MAX)
)

CREATE TABLE Payments
(
	[Id]				INT PRIMARY KEY
	,[EmployeeId]		INT NOT NULL
	,[PaymentDate]		DATETIME2 NOT NULL
	,[AccountNumber]	INT NOT NULL
	,[FirstDateOccupied]DATETIME2 NOT NULL
	,[LastDateOccupied]	DATETIME2 NOT NULL
	,[TotalDays]		AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied])
	,[AmountCharged]	DECIMAL(15, 2) NOT NULL
	,[TaxRate]			INT
	,[TaxAmount]		INT
	,[PaymentTotal]		AS ([AmountCharged] + [TaxRate] + [TaxAmount])
	,[Notes]			VARCHAR(MAX)
)

CREATE TABLE Occupancies
(
	[Id]				INT PRIMARY KEY
	,[EmployeeId]		INT NOT NULL
	,[DateOccupied]		DATETIME2 NOT NULL
	,[AccountNumber]	INT NOT NULL
	,[RoomNumber]		INT NOT NULL
	,[RateApplied]		INT
	,[PhoneCharge]		DECIMAL(15, 2)
	,[Notes]			VARCHAR(MAX)
)

INSERT INTO [Employees]([Id], [FirstName], [LastName], [Title], [Notes])
VALUES (1, 'Peter', 'Petrov', 'Director', NULL)
		,(2, 'George', 'Georgiev', 'CEO', 'random note')
		,(3, 'Marya', 'Petrova', 'HR', NULL)


INSERT INTO [Customers]([AccountNumber], [FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
VALUES (001, 'Ivan', 'Georgiev', 0888868686, 'George Georgiev', 0888878787, NULL)
		,(002, 'Peter', 'Ivanov', 0888545454, 'Ivan Ivanov', 0888636363, NULL)
		,(003, 'Marya', 'Ivanova', 0888424242, 'Ivan Ivanov', 0888363636, 'random note')

INSERT INTO [RoomStatus]([RoomStatus], [Notes])
VALUES (0 , NULL)
		,(0, NULL)
		,(1, NULL)

INSERT INTO [RoomTypes]([RoomType], [Notes])
VALUES ('Apartment', 'Baby cot avalible')
		,('Studio', NULL)
		,('Double room', NULL)

INSERT INTO [BedTypes]([BedType], [Notes])
VALUES ('Double bed', 'Baby cot avalible')
		,('King size bed', NULL)
		,('Single bed', NULL)

INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
VALUES (110, 'Studio', 'Double bed', 7, 0, NULL)
		,(111, 'Apartament', 'King size bed', 10, 0, NULL)
		,(112, 'Double room', 'Single bed', 9, 1, NULL)

INSERT INTO [Payments]([Id], [EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [AmountCharged], [TaxRate], [TaxAmount], [Notes])
VALUES (1, 1, GETDATE(), 001, '2022-01-05', '2022-06-05', 249.98, 1.00, 15.00, NULL)
		,(2, 2, GETDATE(), 002, '2022-06-15', '2022-06-17', 199.98, 1.00, 7.49, NULL)
		,(3, 3, GETDATE(), 003, '2022-08-10', '2022-08-17', 478.98, 5.00, 25.49, NULL)

INSERT INTO [Occupancies]([Id], [EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
VALUES (1, 1, GETDATE(), 001, 112, 9, NULL, NULL)
		,(2, 2, GETDATE(), 002, 110, 7, NULL, NULL)
		,(3, 3, GETDATE(), 003, 111, 10, NULL, NULL)


----Problem 16.	Create SoftUni Database----
CREATE DATABASE [SoftUni]

USE SoftUni
CREATE TABLE [Towns]
(
	[Id]			INT IDENTITY(1, 1) PRIMARY KEY
	,[Name]			VARCHAR(MAX)
)

CREATE TABLE [Addresses]
(
	[Id]			INT IDENTITY(1, 1) PRIMARY KEY
	,[AddressText]	VARCHAR(70) NOT NULL
	,[TownId]		INT FOREIGN KEY REFERENCES SoftUni.dbo.Towns(Id)
)

CREATE TABLE [Departments]
(
	[Id]			INT IDENTITY(1, 1) PRIMARY KEY
	,[Name]			NVARCHAR(MAX)
)

CREATE TABLE [Employees]
(
	[Id]			INT IDENTITY(1, 1) PRIMARY KEY
	,[FirstName]	NVARCHAR(70) NOT NULL
	,[MiddleName]	NVARCHAR(70)
	,[LastName]		NVARCHAR(70) NOT NULL
	,[JobTitle]		NVARCHAR(50) NOT NULL
	,[DepartmentId] INT FOREIGN KEY REFERENCES SoftUni.dbo.Departments(Id)
	,[HireDate]		DATE NOT NULL
	,[Salary]		DECIMAL(10, 2) NOT NULL
	,[AddressId]	INT FOREIGN KEY REFERENCES SoftUni.dbo.Addresses(Id)
)


----Problem 17.	Backup Database----
BACKUP DATABASE [SoftUni]
TO DISK = 'F:\DB\SoftUniDB.bak'

DROP DATABASE [SoftUni]
RESTORE DATABASE [SoftUni]
FROM DISK = 'F:\DB\SoftUniDB.bak'


----Problem 18.	Basic Insert----
INSERT INTO SoftUni.dbo.Towns([Name])
VALUES ('Sofia')
		,('Plovdiv')
		,('Varna')
		,('Burgas')

INSERT INTO SoftUni.dbo.Departments([Name])
VALUES ('Engineering')
		,('Sales')
		,('Marketing')
		,('Software Development')
		,('Quality Assurance')

INSERT INTO SoftUni.dbo.Employees([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00)
		,('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00)
		,('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25)
		,('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00)
		,('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)


----Problem 19.	Basic Select All Fields----
SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

----Problem 20.	Basic Select All Fields and Order Them----
	SELECT * 
		FROM [Towns]
ORDER BY [Name] ASC

	SELECT * 
		FROM [Departments]
ORDER BY [Name] ASC

	SELECT * 
		FROM [Employees]
ORDER BY [Salary] DESC


----Problem 21.	Basic Select Some Fields----
SELECT [Name]
		FROM [Towns]
ORDER BY [Name] ASC

SELECT [Name]
		FROM [Departments]
ORDER BY [Name] ASC

SELECT [FirstName], [LastName], [JobTitle], [Salary]
		FROM [Employees]
ORDER BY [Salary] DESC


----Problem 22.	Increase Employees Salary----
UPDATE [Employees]
	SET [Salary] *= 1.1
SELECT [Salary] FROM [Employees]


----Problem 23.	Decrease Tax Rate----
USE [Hotel]
UPDATE [Payments]
	SET [TaxRate] *= 0.97
SELECT [TaxRate] FROM [Payments]


----Problem 24.	Delete All Records----
USE [Hotel]
TRUNCATE TABLE [Occupancies]
