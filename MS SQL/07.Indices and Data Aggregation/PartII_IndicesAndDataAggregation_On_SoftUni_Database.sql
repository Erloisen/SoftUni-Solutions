USE SoftUni

/****** Problem 13. Departments Total Salaries ******/
------------------------------------------------------
SELECT	e.[DepartmentID]
		,SUM(e.[Salary]) AS [TotalSalary]
  FROM Employees AS e
  GROUP BY e.[DepartmentID]


/****** Problem 14. Employees Minimum Salaries ******/
------------------------------------------------------
SELECT	e.[DepartmentID]
		,MIN(e.[Salary])
	FROM Employees AS e
	WHERE e.[DepartmentID] IN (2, 5, 7) AND HireDate > '01/01/2000'
	GROUP BY e.[DepartmentID]


/****** Problem 15. Employees Average Salaries ******/
------------------------------------------------------
SELECT * INTO NewTable
	FROM Employees AS e
	WHERE e.[Salary] > 30000

DELETE FROM NewTable
WHERE [ManagerID] = 42

UPDATE NewTable
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT	nt.[DepartmentID]
		,AVG(nt.[Salary]) AS [AverageSalary]
	FROM NewTable AS nt
	GROUP BY nt.[DepartmentID]


/****** Problem 16. Employees Maximum Salaries ******/
------------------------------------------------------
SELECT	e.[DepartmentID]
		,MAX(e.[Salary]) AS [MaxSalary]
	FROM Employees AS e
	GROUP BY e.[DepartmentID]
	HAVING MAX(e.[Salary]) < 30000 OR MAX(e.[Salary]) > 70000


/****** Problem 17. Employees Count Salaries ******/
----------------------------------------------------
SELECT COUNT(e.[Salary]) AS [Count]
	FROM Employees AS e
	WHERE e.[ManagerID] IS NULL


/****** Problem 18. 3rd Highest Salary ******/
----------------------------------------------
SELECT DISTINCT	Result.[DepartmentID]
				,Result.[Salary] AS [ThirdHighestSalary]
	FROM (SELECT	e.[DepartmentID]
					,e.[Salary]
					,DENSE_RANK() OVER(PARTITION BY e.[DepartmentID] ORDER BY e.[Salary] DESC) AS [RankSalary]
		  FROM Employees AS e) AS Result
	WHERE Result.[RankSalary] = 3


/****** Problem 19. Salary Challenge ******/
--------------------------------------------
SELECT TOP(10)	e.[FirstName], e.[LastName], e.[DepartmentID]
  FROM Employees AS e
 WHERE e.[Salary] > (SELECT	AVG(em.[Salary]) AS [AverageSalary]
					   FROM Employees AS em
					  WHERE em.[DepartmentID] = e.[DepartmentID]
				   GROUP BY em.[DepartmentID])
ORDER BY e.[DepartmentID]