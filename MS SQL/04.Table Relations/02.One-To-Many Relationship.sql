CREATE TABLE Manufacturers
(
	[ManufacturerID] INT IDENTITY PRIMARY KEY
	,[Name]			 NVARCHAR(50) UNIQUE
	,[EstablishedOn] DATE NOT NULL
)

INSERT INTO Manufacturers([Name], [EstablishedOn])
	VALUES ('BMW', '07/03/1916')
			,('Tesla', '01/01/2003')
			,('Lada', '01/05/1966')

CREATE TABLE Models
(
	[ModelID] INT IDENTITY(101, 1) PRIMARY KEY
	,[Name] NVARCHAR(50) UNIQUE
	,[ManufacturerID] INT REFERENCES Manufacturers([ManufacturerID])
)

INSERT INTO Models([Name], [ManufacturerID])
	VALUES ('X1', 1)
			,('i6', 1)
			,('Model S', 2)
			,('Model X', 2)
			,('Model 3', 2)
			,('Nova', 3)

SELECT m.[Name], mo.[Name] AS ModelName, m.[EstablishedOn]
	FROM Manufacturers AS m
	JOIN Models AS mo ON mo.ManufacturerID = m.ManufacturerID