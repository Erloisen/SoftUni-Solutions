USE SoftUni


/****** Problem 01. Employees with Salary Above 35000 ******/
-------------------------------------------------------------
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000
AS
SELECT	e.[FirstName] AS [First Name]
		,e.[LastName] AS [Last Name]
  FROM Employees AS e
  WHERE e.[Salary] > 35000
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000


/****** 02. Employees with Salary Above Number ******/
------------------------------------------------------
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@inputSalary DECIMAL(18,4))
AS
	 SELECT	e.[FirstName] AS [First Name]
			,e.[LastName] AS [Last Name]
	   FROM	Employees AS e
	  WHERE	e.[Salary] >= @inputSalary

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 1000


/****** 03. Town Names Starting With ******/
--------------------------------------------
CREATE PROC usp_GetTownsStartingWith (@targetString NVARCHAR(50))
AS
     SELECT	t.[Name] AS [Town]
       FROM	Towns AS t
      WHERE	t.[Name] LIKE @targetString + '%'

EXEC dbo.usp_GetTownsStartingWith 'Sof'


/****** 04. Employees from Town ******/
---------------------------------------
CREATE PROC usp_GetEmployeesFromTown (@targetTown NVARCHAR(50))
AS
	 SELECT	e.[FirstName] AS [First Name]
			,e.[LastName] AS [Last Name]
	   FROM Employees AS e
	   JOIN Addresses AS a ON a.[AddressID] = e.[AddressID]
	   JOIN Towns AS t ON t.[TownID] = a.[TownID]
	  WHERE t.[Name] = @targetTown

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'


/****** 05. Salary Level Function ******/
-----------------------------------------
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)
	IF (@salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF (@salary <= 50000)
		SET @salaryLevel = 'Average'
	ELSE 
		SET @salaryLevel = 'High'
RETURN @salaryLevel
END


/****** 06. Employees by Salary Level ******/
---------------------------------------------
CREATE PROC usp_EmployeesBySalaryLevel (@levelOfSalary VARCHAR(7))
AS
	SELECT	e.[FirstName] AS [First Name]
			,e.[LastName] AS [Last Name]
	  FROM	Employees AS e
	 WHERE	dbo.ufn_GetSalaryLevel(e.[Salary]) LIKE @levelOfSalary


/****** 07. Define Function ******/
-----------------------------------
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
BEGIN
DECLARE @count INT = 1
WHILE (@count <= LEN(@word))
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1)
		IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
			RETURN 0
	
		SET @count += 1;
	END
	RETURN 1
END


/****** 08. Delete Employees and Departments ******/
----------------------------------------------------
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
   SET ManagerID = NULL
 WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
   SET ManagerID = NULL
 WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments
   SET ManagerID = NULL
 WHERE DepartmentID = @departmentId

DELETE FROM Employees
 WHERE DepartmentID = @departmentId

DELETE FROM Departments
 WHERE DepartmentID = @departmentId

SELECT COUNT(*)
  FROM Employees AS e
 WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 2

SELECT *
  FROM Employees
  WHERE DepartmentID = 1