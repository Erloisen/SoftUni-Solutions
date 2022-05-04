USE Orders
/****** Problem 18.	Orders Table ******/
----------------------------------------
SELECT	[ProductName]
		,[OrderDate]
		,[OrderDate] + 3 AS [Pay Due]
		,DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM Orders

SELECT	[ProductName]
		,[OrderDate]
		,DATEADD(DAY, 3,[OrderDate]) AS [Pay Due]
		,DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM Orders


/****** Problem 19.	People Table ******/
----------------------------------------
CREATE TABLE People
(
	[Id] INT IDENTITY PRIMARY KEY
	,[Name] NVARCHAR(100) NOT NULL
	,[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO People([Name], [Birthdate])
	VALUES	('Victor', '2000-12-07')
			,('Steven', '1992-09-10')
			,('Stephen', '1910-09-19')
			,('John', '2010-01-06')

SELECT	[Name]
		,DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years]
		,DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months]
		,DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days]
		,DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
	FROM People