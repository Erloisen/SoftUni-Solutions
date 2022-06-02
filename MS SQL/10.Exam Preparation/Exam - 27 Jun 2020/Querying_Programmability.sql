/****** Section 1. DDL ******/
--01. DDL---------------------
CREATE DATABASE WMS
GO

USE WMS
GO


CREATE TABLE Clients
(
	[ClientId] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName]	VARCHAR(50) NOT NULL
	,[Phone] VARCHAR(12) NOT NULL
	,CHECK(LEN([Phone]) = 12)
)

CREATE TABLE Mechanics
(
	[MechanicId] INT NOT NULL PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName]	VARCHAR(50) NOT NULL
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
	,[ModelId] INT NOT NULL REFERENCES Models(ModelId)
	,[Status] VARCHAR(11) NOT NULL DEFAULT 'Pending'
	,[ClientId] INT NOT NULL REFERENCES Clients([ClientId])
	,[MechanicId] INT REFERENCES Mechanics([MechanicId])
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
	,[Description] VARCHAR(255)
	,[Price] DECIMAL(6,2) NOT NULL
	,[VendorId] INT NOT NULL REFERENCES Vendors(VendorId)
	,[StockQty] INT NOT NULL DEFAULT 0
	,CHECK([Price] > 0)
	,CHECK([StockQty] >= 0)
)

CREATE TABLE OrderParts
(
	[OrderId] INT NOT NULL REFERENCES Orders([OrderId])
	,[PartId] INT NOT NULL REFERENCES Parts([PartId])
	,[Quantity] INT NOT NULL DEFAULT 1
	,PRIMARY KEY([OrderId], [PartId])
	,CHECK([Quantity] > 0)
)

CREATE TABLE PartsNeeded
(
	[JobId] INT NOT NULL REFERENCES Jobs([JobId])
	,[PartId] INT NOT NULL REFERENCES Parts([PartId])
	,[Quantity] INT NOT NULL DEFAULT 1
	,PRIMARY KEY([JobId], [PartId])
	,CHECK([Quantity] > 0)
)

GO


/****** Section 2. DML ******/
--02. Insert------------------
INSERT INTO Clients ([FirstName], [LastName], [Phone])
     VALUES ('Teri',	'Ennaco', '570-889-5187')
     	    ,('Merlyn', 'Lawler', '201-588-7810')
     	    ,('Georgene', 'Montezuma', '925-615-5185')
     	    ,('Jettie', 'Mconnell', '908-802-3564')
     	    ,('Lemuel', 'Latzke', '631-748-6479')
     	    ,('Melodie', 'Knipp', '805-690-1682')
     	    ,('Candida',	'Corbley', '908-275-8357')

INSERT INTO Parts ([SerialNumber], [Description], [Price], [VendorId])
     VALUES ('WP8182119', 'Door Boot Seal', 117.86, 2)
     	    ,('W10780048', 'Suspension Rod',	42.81, 1)
     	    ,('W10841140', 'Silicone Adhesive', 6.77, 4)
     	    ,('WPY055980', 'High Temperature Adhesive', 13.94, 3)
GO

--03. Update------------------
DECLARE @targetMechanicId INT = (SELECT m.[MechanicId]
								   FROM Mechanics AS m
								  WHERE m.[FirstName] = 'Ryan' AND m.[LastName] = 'Harnos')

UPDATE Jobs
   SET [MechanicId] = @targetMechanicId, [Status] = 'In Progress'
 WHERE [MechanicId] IS NULL AND [Status] = 'Pending'
GO


--04. Delete------------------
DELETE FROM OrderParts
      WHERE OrderId = 19

DELETE FROM Orders
      WHERE OrderId = 19
GO

/****** Section 3. Querying ******/
--05. Mechanic Assignments---------
  SELECT CONCAT(m.[FirstName], ' ', m.[LastName]) AS [Mechanic]
	     ,j.[Status]
         ,j.[IssueDate]
    FROM Mechanics AS m
    JOIN Jobs AS j ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId], j.[IssueDate], j.[JobId]
GO


--06. Current Clients--------------
  SELECT CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [Client]
      ,DATEDIFF(DAY, j.[IssueDate], '2017-04-24') AS [Days going]
      ,j.[Status]
    FROM Clients AS c
    JOIN Jobs AS j ON c.[ClientId] = j.[ClientId]
   WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.[ClientId] ASC
GO


--07. Mechanic Performance---------
  SELECT CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [Mechanic]
      ,AVG(DATEDIFF(DAY, j.[IssueDate], j.[FinishDate])) AS [Average Days]
    FROM Mechanics AS m
    JOIN Jobs AS j ON m.[MechanicId] = j.[MechanicId]
   WHERE j.[FinishDate] IS NOT NULL
GROUP BY m.[MechanicId], m.[FirstName], m.[LastName]
GO


--08. Available Mechanics----------
   SELECT CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [Available]
	 FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.[MechanicId] = j.[MechanicId]
    WHERE j.[JobId] IS NULL OR (SELECT COUNT(*)
								  FROM Jobs
								 WHERE [Status] <> 'Finished' AND [MechanicId] = m.[MechanicId]
							  GROUP BY [MechanicId], [Status]) IS NULL
 GROUP BY m.[MechanicId], m.[FirstName], m.[LastName]
GO


--09. Past Expenses----------------
   SELECT j.[JobId]
	      ,ISNULL(SUM(p.[Price] * op.[Quantity]), 0) AS [Total]
     FROM Jobs AS j
LEFT JOIN Orders AS o ON j.[JobId] = o.[JobId]
LEFT JOIN OrderParts AS op ON o.[OrderId] = op.[OrderId]
LEFT JOIN Parts AS p ON op.[PartId] = p.[PartId]
    WHERE j.[Status] = 'Finished'
 GROUP BY j.[JobId]
 ORDER BY [Total] DESC, j.[JobId]


--10. Missing Parts----------------
   SELECT p.[PartId]
		  ,p.[Description]
		  ,pn.[Quantity] AS [Required]
		  ,p.[StockQty] AS [In Stock]
		  ,IIF(o.[Delivered] = 0, op.[Quantity], 0) AS [Ordered]
	 FROM Parts AS p
LEFT JOIN PartsNeeded AS pn ON p.[PartId] = pn.[PartId]
LEFT JOIN OrderParts AS op ON pn.[PartId] = op.[PartId]
LEFT JOIN Jobs AS j ON pn.[JobId] = j.[JobId]
LEFT JOIN Orders AS o ON j.[JobId] = o.[JobId]
	WHERE j.[Status] != 'Finished'
	  AND p.[StockQty] + IIF(o.[Delivered] = 0, op.[Quantity], 0) < pn.[Quantity]
	ORDER BY p.[PartId]
GO

   SELECT p.[PartId]
	      ,p.[Description]
	      ,SUM(pn.[Quantity]) AS [Required]
	      ,SUM(p.[StockQty]) AS [In Stock]
	      ,0 AS [Ordered]
     FROM Jobs AS j
FULL JOIN Orders AS o ON j.[JobId] = o.[JobId]
	 JOIN PartsNeeded AS pn ON pn.[JobId] = j.[JobId]
     JOIN Parts AS p ON p.[PartId] = pn.[PartId]
	WHERE j.[Status] != 'Finished' AND o.[Delivered] IS NULL
 GROUP BY p.[PartId], p.[Description]
   HAVING SUM(p.[StockQty]) < SUM(pn.[Quantity])
GO


/****** Section 4. Programmability ******/
--11. Place Order-------------------------
CREATE OR ALTER PROCEDURE usp_PlaceOrder (@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT)
AS
	DECLARE @status VARCHAR(10) = (SELECT j.[Status]
							     FROM Jobs AS j
							    WHERE j.[JobId] = @JobId)

	DECLARE @PartId VARCHAR(10) = (SELECT p.[PartId]
										   FROM Parts AS p
										  WHERE p.[SerialNumber] = @SerialNumber)
	IF (@Quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1
	ELSE IF (@status IS NULL)
		THROW 50013, 'Job not found!', 1
	ELSE IF (@status = 'Finished')
		THROW 50011, 'This job is not active!', 1
	ELSE IF (@PartId IS NULL)
		THROW 50014, 'Part not found!', 1
	
	DECLARE @OrderId INT = (SELECT o.[OrderId]
							  FROM Orders AS o
							 WHERE o.[JobId] = @JobId AND o.[IssueDate] IS NULL)

	IF (@OrderId IS NULL)
	BEGIN
		INSERT INTO Orders (JobId, IssueDate) VALUES (@JobId, NULL)
	END

	SET @OrderId = (SELECT o.[OrderId]
				      FROM Orders AS o
					 WHERE o.[JobId] = @JobId AND o.[IssueDate] IS NULL)

	DECLARE @OrderPartExist INT = (SELECT OrderId
									 FROM OrderParts
									WHERE OrderId = @OrderId AND PartId = @PartId)

	IF (@OrderPartExist IS NULL)
	BEGIN
		INSERT INTO OrderParts ([OrderId], [PartId], [Quantity]) VALUES (@OrderId, @PartId, @Quantity)
	END
	ELSE
	BEGIN
		UPDATE OrderParts 
		   SET [Quantity] += @Quantity	
		 WHERE [OrderId] = @OrderId AND [PartId] = @PartId
	END
GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH


--12. Cost of Order-----------------------
CREATE OR ALTER FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL (6,2)
AS
BEGIN
	DECLARE @result DECIMAL(6,2)
	SET @result = (SELECT SUM(p.[Price] * op.[Quantity]) AS [Result]
					 FROM Jobs AS j
					 JOIN Orders AS o ON j.[JobId] = o.[JobId]
					 JOIN OrderParts AS op ON o.OrderId = op.[OrderId]
	                 JOIN Parts AS p ON op.[PartId] = p.[PartId]
					WHERE j.[JobId] = @JobId
				 GROUP BY j.[JobId])

	IF (@result IS NULL)
	SET @result = 0

	RETURN @result
END

SELECT dbo.udf_GetCost(3)