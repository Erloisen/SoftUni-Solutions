CREATE DATABASE WMS

USE WMS
GO

CREATE TABLE Clients
(
	[ClientId] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName] VARCHAR(50) NOT NULL
	,[Phone] CHAR(12) NOT NULL
	,CHECK(LEN([Phone]) = 12)
)

CREATE TABLE Mechanics
(
	[MechanicId] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName] VARCHAR(50) NOT NULL
	,[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	[ModelId] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs
(
	[JobId] INT NOT NULL PRIMARY KEY IDENTITY
	,[ModelId] INT NOT NULL FOREIGN KEY REFERENCES Models([ModelId])
	,[Status] VARCHAR(12) DEFAULT 'Pending' NOT NULL
	,[ClientId] INT NOT NULL FOREIGN KEY REFERENCES Clients([ClientId])
	,[MechanicId] INT FOREIGN KEY REFERENCES Mechanics([MechanicId])
	,[IssueDate] DATE NOT NULL
	,[FinishDate] DATE
	,CHECK([Status] IN ('Pending', 'In Progress', 'Finished'))
)

CREATE TABLE Orders
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY
	,[JobId] INT NOT NULL REFERENCES Jobs([JobId])
	,[IssueDate] DATE
	,[Delivered] BIT NOT NULL DEFAULT 0
)

CREATE TABLE Vendors
(
	[VendorId] INT NOT NULL PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
	[PartId] INT NOT NULL PRIMARY KEY IDENTITY
	,[SerialNumber] VARCHAR(50) NOT NULL UNIQUE
	,[Description] VARCHAR(50)
	,[Price] DECIMAL(6,2) NOT NULL
	,[VendorId] INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId)
	,[StockQty] INT NOT NULL DEFAULT 0
	,CHECK([Price] > 0)
	,CHECK([StockQty] >= 0)
)

CREATE TABLE OrderParts
(
	[OrderId] INT NOT NULL FOREIGN KEY REFERENCES Orders([OrderId])
	,[PartId] INT NOT NULL FOREIGN KEY REFERENCES Parts([PartId])
	,[Quantity] INT NOT NULL DEFAULT 1
	,CONSTRAINT PK_OrderParts PRIMARY KEY([OrderId], [PartId])
	,CHECK([Quantity] > 0)
)

CREATE TABLE PartsNeeded
(
	[JobId] INT NOT NULL REFERENCES Jobs([JobId])
	,[PartId] INT NOT NULL REFERENCES Parts([PartId])
	,[Quantity] INT NOT NULL DEFAULT 1
	,CONSTRAINT PK_PartsNeeded PRIMARY KEY([JobId], [PartId])
	,CHECK([Quantity] > 0)
)