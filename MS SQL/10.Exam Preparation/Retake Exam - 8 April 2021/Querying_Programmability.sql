USE Service
GO

/****** Section 3. Querying (40 pts) ******/
-- 5.	Unassigned Reports -----------------
  SELECT r.[Description]
         ,FORMAT(r.[OpenDate], 'dd-MM-yyyy') AS [OpenDate]
    FROM Reports AS r
   WHERE r.[EmployeeId] IS NULL
ORDER BY r.[OpenDate] ASC, r.[Description] ASC
GO

-- 6. Reports & Categories -----------------
  SELECT r.[Description]
         ,c.[Name] AS CategoryName
    FROM Reports AS r
    JOIN Categories AS c ON r.[CategoryId] = c.[Id]
   WHERE r.[CategoryId] IS NOT NULL
ORDER BY r.[Description], c.[Name]
GO

-- 7. Most Reported Category ---------------
  SELECT TOP(5) 
         c.[Name] AS [CategoryName]
         ,COUNT(r.[CategoryId]) AS [ReportsNumber]
    FROM Categories AS c
    JOIN Reports AS r ON c.[Id] = r.[CategoryId]
GROUP BY c.[Id], c.[Name]
ORDER BY [ReportsNumber] DESC, c.[Name]
GO

-- 8. Birthday Report ----------------------
  SELECT u.[Username]
         ,c.[Name] AS [CategoryName]
    FROM Reports AS r
    JOIN Users AS u ON r.[UserId] = u.[Id]
    JOIN Categories AS c ON r.[CategoryId] = c.[Id]
   WHERE DAY(r.[OpenDate]) = DAY(u.[Birthdate])
     AND MONTH(r.[OpenDate]) = MONTH(u.[Birthdate])
ORDER BY u.[Username], c.[Name]
GO

  SELECT u.[Username]
         ,c.[Name] AS [CategoryName]
    FROM Reports AS r
    JOIN Users AS u ON r.[UserId] = u.[Id]
    JOIN Categories AS c ON r.[CategoryId] = c.[Id]
   WHERE FORMAT(r.[OpenDate], 'dd/MM') = FORMAT(u.[Birthdate], 'dd/MM')
ORDER BY u.[Username], c.[Name]
GO

-- 9. Users per Employee -------------------
SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName]
      ,COUNT(u.[Id]) AS [UsersCount]
FROM Employees AS e
LEFT JOIN Reports AS r ON e.[Id] = r.[EmployeeId]
LEFT JOIN Users AS u ON r.[UserId] = u.[Id]
GROUP BY e.[FirstName], e.[LastName]
ORDER BY [UsersCount] DESC, [FullName]
GO

-- 10. Full Info ---------------------------
   SELECT CASE
              WHEN r.[EmployeeId] IS NULL THEN 'None'
              ELSE CONCAT_WS(' ', e.[FirstName], e.[LastName])
	      END AS [Employee]
          ,ISNULL(d.[Name], 'None') AS [Department]
	      ,ISNULL(c.[Name], 'None') AS [Category]
	      ,ISNULL(r.[Description], 'None') AS [Description]
	      ,ISNULL(FORMAT(r.[OpenDate], 'dd.MM.yyyy'), 'None') AS [OpenDate]
	      ,ISNULL(s.[Label], 'None') AS [Status]
	      ,ISNULL(u.[Name], 'None') AS [User]
     FROM Reports AS r
LEFT JOIN Employees AS e ON r.[EmployeeId] = e.[Id]
LEFT JOIN Categories AS c ON r.[CategoryId] = c.[Id]
LEFT JOIN Departments AS d ON e.[DepartmentId] = d.[Id]
LEFT JOIN Users As u ON r.[UserId] = u.[Id]
LEFT JOIN [Status] AS s ON r.[StatusId] = s.[Id]
 ORDER BY e.[FirstName] DESC
          ,e.[LastName] DESC
          ,d.[Name] ASC
		  ,c.[Name] ASC
		  ,r.[Description] ASC
		  ,r.[OpenDate] ASC
		  ,s.[Label] ASC
		  ,u.[Username] ASC
GO

-- 11. Hours to Complete -------------------
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
      DECLARE @result INT;
	  IF ((@StartDate IS NULL) OR (@EndDate IS NULL))
	  BEGIN
           SET @result = 0
	  END
	  ELSE
      SET @result = DATEDIFF(HOUR, @StartDate, @EndDate)
      RETURN @result;
END
GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
  FROM Reports
GO

-- 12. Assign Employee ---------------------
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
    DECLARE @employeeDepart INT = (SELECT e.[DepartmentId]
                                     FROM Employees AS e
                                    WHERE e.[Id] = @EmployeeId)

    DECLARE @reportDepart INT = (SELECT c.[DepartmentId]
                                   FROM Reports AS r
                                   JOIN Categories AS c ON r.[CategoryId] = c.[Id]
                                  WHERE r.[Id] = @ReportId)

    IF (@employeeDepart != @reportDepart)
	THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
    
    UPDATE Reports
       SET Reports.[EmployeeId] = @EmployeeId
     WHERE Reports.[Id] = @ReportId
         
GO


EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2
GO