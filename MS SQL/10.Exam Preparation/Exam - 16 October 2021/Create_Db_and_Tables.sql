CREATE DATABASE CigarShop
GO

USE CigarShop
GO

/****** Section 1. DDL (30 pts) ******/
-- 01.	Database design ---------------
CREATE TABLE Sizes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Length] INT NOT NULL
	,[RingRange] DECIMAL(2, 1) NOT NULL
	,CHECK([Length] BETWEEN 10 AND 25)
	,CHECK([RingRange] BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[TasteType] NVARCHAR(20) NOT NULL
	,[TasteStrength] NVARCHAR(15) NOT NULL
	,[ImageURL] NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[BrandName] NVARCHAR(30) NOT NULL UNIQUE
	,[BrandDescription] NVARCHAR(MAX)
)


CREATE TABLE Cigars
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[CigarName] NVARCHAR(80) NOT NULL
	,[BrandId] INT NOT NULL REFERENCES Brands([Id])
	,[TastId] INT NOT NULL REFERENCES Tastes([Id])
	,[SizeId] INT NOT NULL REFERENCES Sizes([Id])
	,[PriceForSingleCigar] MONEY NOT NULL
	,[ImageURL] NVARCHAR(100) NOT NULL
)


CREATE TABLE Addresses
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[Town] NVARCHAR(30) NOT NULL
	,[Country] NVARCHAR(30) NOT NULL
	,[Streat] NVARCHAR(100) NOT NULL
	,[ZIP] NVARCHAR(20) NOT NULL
)


CREATE TABLE Clients
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] NVARCHAR(30) NOT NULL
	,[LastName] NVARCHAR(30) NOT NULL
	,[Email] NVARCHAR(50) NOT NULL
	,[AddressId] INT NOT NULL REFERENCES Addresses([Id])
)


CREATE TABLE ClientsCigars
(
	[ClientId] INT NOT NULL REFERENCES Clients([Id])
	,[CigarId] INT NOT NULL REFERENCES Cigars([Id])
	,PRIMARY KEY([ClientId], [CigarId])
)


/****** Section 2. DML (10 pts) ******/
-- 2. Insert --------------------------
INSERT INTO Cigars([CigarName], [BrandId], [TastId], [SizeId], [PriceForSingleCigar], [ImageURL])
     VALUES ('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg')
			,('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg')
			,('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg')
			,('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg')
			,('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')
GO

INSERT INTO Addresses([Town], [Country], [Streat], [ZIP])
	 VALUES ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000)
			,('Athens', 'Greece', '4342 McDonald Avenue', 10435)
			,('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)
GO

-- 3. Update---------------------------
UPDATE Cigars
   SET PriceForSingleCigar *= 1.20
 WHERE [TastId] = 1
GO

UPDATE Brands
   SET [BrandDescription] = 'New description'
 WHERE [BrandDescription] IS NULL
GO

-- 4. Delete---------------------------
DELETE
  FROM Clients
 WHERE [AddressId] IN (SELECT [Id] FROM Addresses WHERE [Country] LIKE 'C%')
GO

DELETE
  FROM Addresses
 WHERE [Country] LIKE 'C%'
GO