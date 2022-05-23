USE SoftUni
GO

/****** Problem 21. Employees with Three Projects ******/
 ---------------------------------------------------------
CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @emplyee INT = (SELECT [EmployeeID] FROM Employees WHERE [EmployeeID] = @emloyeeId)
	DECLARE @project INT = (SELECT [ProjectID] FROM Projects WHERE [ProjectID] = @projectID)
	
	IF (@emplyee IS NULL OR @project IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalide emplyee Id or projrct Id', 16, 1)
		RETURN
	END

	DECLARE @countEmplyeeProject INT = (SELECT COUNT(*) 
										  FROM EmployeesProjects AS ep
										 WHERE ep.[EmployeeID] = @emloyeeId AND ep.[ProjectID] = @projectID)
	IF (@countEmplyeeProject > 0)
	BEGIN
		ROLLBACK
           RAISERROR ('This employee is already in that project!', 16, 2)
		RETURN
	END

	DECLARE @maxEmplyeeProjectsCount INT = 3
	DECLARE @emplyeeProjectCounts INT = (SELECT COUNT(*) 
										  FROM EmployeesProjects AS ep
										 WHERE ep.[EmployeeID] = @emloyeeId)

	IF (@emplyeeProjectCounts >= @maxEmplyeeProjectsCount)
	BEGIN
		ROLLBACK
	    RAISERROR ('The employee has too many projects!', 16, 1)
		RETURN
	END

	INSERT INTO EmployeesProjects([EmployeeID], [ProjectID])
		 VALUES (@emloyeeId, @projectID)
COMMIT
GO

SELECT *
  FROM EmployeesProjects
 WHERE [EmployeeID] = 3
GO

EXEC usp_AssignProject 3, 111 --Too many projects
EXEC usp_AssignProject 2, 1   --Add new project


/****** Problem 22. Delete Employees ******/
 -------------------------------------------
CREATE TABLE Deleted_Employees
(
	[EmployeeId] INT PRIMARY KEY IDENTITY
	,[FirstName] VARCHAR(50) NOT NULL
	,[LastName] VARCHAR(50) NOT NULL
	,[MiddleName] VARCHAR(50)
	,[JobTitle] VARCHAR(50) NOT NULL
	,[DepartmentId] INT NOT NULL
	,[Salary] MONEY NOT NULL
) 
GO

CREATE TRIGGER tr_OnDeletedEmployee ON Employees
   FOR DELETE
AS
	INSERT Deleted_Employees ([FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentID], [Salary])
	SELECT [FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentID], [Salary] 
	  FROM deleted
GO