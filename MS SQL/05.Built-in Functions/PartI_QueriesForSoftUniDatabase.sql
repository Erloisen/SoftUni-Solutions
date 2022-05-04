USE SoftUni

/****** Problem 01.	Find Names of All Employees by First Name ******/
---------------------------------------------------------------------
SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE [FirstName] LIKE 'Sa%'

SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE SUBSTRING([FirstName], 1, 2) = 'Sa'

SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE LEFT([FirstName], 2) = 'Sa'

SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE CHARINDEX('Sa', [FirstName], 1) = 1


/****** Problem 02. Find Names of All employees by Last Name ******/
--------------------------------------------------------------------
SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE [LastName] LIKE '%ei%'

SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE CHARINDEX('ei', [LastName]) != 0


/****** Problem 03.	Find First Names of All Employees ******/
-------------------------------------------------------------
SELECT [FirstName]
	FROM Employees
	WHERE [DepartmentID] = 3 OR [DepartmentID] = 10 AND YEAR([HireDate]) BETWEEN '1995' AND '2005'

SELECT	[FirstName]
	FROM Employees
	WHERE [DepartmentID] IN (3, 10) AND DATEPART(YEAR, [HireDate]) BETWEEN '1995' AND '2005'



/****** Problem 04.	Find All Employees Except Engineers ******/
---------------------------------------------------------------
SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE [JobTitle] NOT LIKE '%engineer%'

SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE CHARINDEX('engineer', [JobTitle]) = 0


/****** Problem 05.	Find Towns with Name Length ******/
-------------------------------------------------------
SELECT	[Name]
	FROM Towns
	WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	ORDER BY [Name]

SELECT	[Name]
	FROM Towns
	WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name]


/****** Problem 06.	Find Towns Starting With ******/
----------------------------------------------------
SELECT *
	FROM Towns
	WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name]

SELECT *
	FROM Towns
	WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name]

SELECT *
	FROM Towns
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name]


/****** Problem 07.	Find Towns Not Starting With ******/
--------------------------------------------------------
SELECT *
	FROM Towns
	WHERE [Name] NOT LIKE '[RBD]%'
	ORDER BY [Name]

SELECT *
	FROM Towns
	WHERE SUBSTRING([Name], 1, 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name]

SELECT *
	FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
	ORDER BY [Name]


/****** Problem 08.	Create View Employees Hired After 2000 Year ******/
-----------------------------------------------------------------------
CREATE VIEW [V_EmployeesHiredAfter2000] AS
	SELECT	[FirstName]
			,[LastName]
	FROM Employees
	WHERE DATEPART(YEAR, [HireDate]) > 2000

SELECT * FROM V_EmployeesHiredAfter2000


/****** Problem 09.	Length of Last Name ******/
-----------------------------------------------
SELECT	[FirstName]
		,[LastName]
	FROM Employees
	WHERE LEN([LastName]) = 5


/****** Problem 10.	Rank Employees by Salary ******/
----------------------------------------------------
SELECT	[EmployeeID]
		,[FirstName]
		,[LastName]
		,[Salary]
		,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM Employees
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC


/****** Problem 11.*	Find All Employees with Rank 2 ******/
----------------------------------------------------
SELECT * 
	FROM (SELECT [EmployeeID]
				 ,[FirstName]
				 ,[LastName]
				 ,[Salary]
				 ,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
		  FROM Employees
		  WHERE ([Salary] BETWEEN 10000 AND 50000)) AS r
	WHERE r.[Rank] = 2
	ORDER BY [Salary] DESC