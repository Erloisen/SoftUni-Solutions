USE SoftUni

/****** Problem 01.	Employee Address  ******/
---------------------------------------------
SELECT TOP(5)	[EmployeeID]
				,[JobTitle]
				,e.[AddressID]
				,[AddressText]
  FROM Employees AS e
  JOIN Addresses AS a ON a.[AddressID] = e.[AddressID]
  ORDER BY e.[AddressID]


/****** Problem 02.	Addresses with Towns  ******/
-------------------------------------------------
SELECT TOP(50)	e.[FirstName]
				,e.[LastName]
				,t.[Name] AS [Town]
				,a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	ORDER BY e.[FirstName], e.[LastName]


/****** Problem 03.	Sales Employee ******/
------------------------------------------
SELECT	e.[EmployeeID]
		,e.[FirstName]
		,e.[LastName]
		,d.[Name] AS [DepartmentName]
	FROM Employees AS e
	JOIN Departments AS d ON d.[DepartmentID] = e.[DepartmentID]
	WHERE d.Name = 'Sales'
	ORDER BY e.[EmployeeID]


/****** Problem 04.	Employee Departments ******/
------------------------------------------------
SELECT TOP(5)	e.[EmployeeID]
				,e.[FirstName]
				,e.[Salary]
				,d.[Name] AS [DepartmentName]
	FROM Employees AS e
	JOIN Departments AS d ON d.[DepartmentID] = e.[DepartmentID]
	WHERE e.[Salary] > 15000
	ORDER BY d.[DepartmentID]


/****** Problem 05.	Employees Without Project ******/
-----------------------------------------------------
SELECT TOP(3)	e.[EmployeeID]
				,e.[FirstName]
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON ep.[EmployeeID] = e.[EmployeeID]
	LEFT JOIN Projects AS p ON p.[ProjectID] = ep.[ProjectID]
	WHERE p.[Name] IS NULL
	ORDER BY e.[EmployeeID]


/****** Problem 06.	Employees Hired After ******/
-------------------------------------------------
SELECT	e.[FirstName]
		,e.[LastName]
		,e.[HireDate]
		,d.[Name] AS [DeptName]
	FROM Employees AS e
	JOIN Departments AS d ON d.[DepartmentID] = e.[DepartmentID]
	WHERE e.[HireDate] > '1999-01-01'
		AND (d.[Name] IN ('Finance', 'Sales'))
	ORDER BY e.[HireDate]


SELECT	e.[FirstName]
		,e.[LastName]
		,e.[HireDate]
		,d.[Name] AS [DeptName]
	FROM Employees AS e
	JOIN Departments AS d ON d.[DepartmentID] = e.[DepartmentID]
	WHERE e.[HireDate] > '1999-01-01'
		AND (d.[Name] IN (SELECT	[Name]	FROM Departments	WHERE [Name] IN ('Finance', 'Sales')))
	ORDER BY e.[HireDate]


/****** Problem 07.	Employees with Project ******/
--------------------------------------------------
SELECT TOP(5)	e.[EmployeeID]
				,e.[FirstName]
				,p.[Name] AS [ProjectName]
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON ep.[EmployeeID] = e.[EmployeeID]
	JOIN Projects AS p ON p.[ProjectID] = ep.[ProjectID]
	WHERE p.[StartDate] > '2002-08-13'
		AND p.[EndDate] IS NULL
	ORDER BY e.[EmployeeID]


/****** Problem 08.	Employee 24 ******/
---------------------------------------
SELECT	e.[EmployeeID]
		,e.[FirstName]
		,CASE
			WHEN DATEPART(YEAR, p.[StartDate]) < 2005 THEN p.[Name]
			ELSE NULL
		END AS [ProjectName]
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON ep.[EmployeeID] = e.[EmployeeID]
	JOIN Projects AS p ON p.[ProjectID] = ep.[ProjectID]
	WHERE e.[EmployeeID] = '24'


/****** Problem 09.	Employee Manager ******/
--------------------------------------------
SELECT	e.[EmployeeID]
		,e.[FirstName]
		,e.[ManagerID]
		,m.[FirstName] AS [ManagerName]
	FROM Employees AS e
	LEFT JOIN Employees AS m ON m.[EmployeeID] = e.[ManagerID]
	WHERE e.[ManagerID] IN (3, 7)
	ORDER BY e.[EmployeeID]


/****** Problem 10. Employee Summary ******/
--------------------------------------------
SELECT TOP(50)	e.[EmployeeID]
				,CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName]
				,CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName]
				,d.[Name] AS [DepartmentName]
	FROM Employees AS e
	LEFT JOIN Employees AS m ON m.[EmployeeID] = e.[ManagerID]
	LEFT JOIN Departments As d ON d.[DepartmentID] = e.[DepartmentID]
	ORDER BY e.[EmployeeID]


/****** Problem 11. Min Average Salary ******/
----------------------------------------------
SELECT	TOP(1)
	(SELECT AVG(Salary)
		FROM Employees
		WHERE DepartmentID = d.DepartmentID
	) AS [MinAverageSalary]
	FROM Departments AS d
	ORDER BY [MinAverageSalary]

SELECT	TOP(1)
	AVG(Salary) AS [MinAverageSalary]
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY [MinAverageSalary]