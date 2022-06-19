USE Zoo
GO

/****** Section 3. Querying (40 pts) ******/
-- 5. Volunteers ---------------------------
  SELECT v.[Name]
         ,v.[PhoneNumber]
         ,v.[Address]
         ,v.[AnimalId]
         ,v.[DepartmentId]
    FROM Volunteers AS v
ORDER BY v.[Name], v.[AnimalId], v.[DepartmentId]


-- 6. Animals data -------------------------
  SELECT a.[Name]
         ,[at].[AnimalType]
	     ,FORMAT(a.[BirthDate], 'dd.MM.yyyy') AS [BirthDate]
    FROM Animals AS a
    JOIN AnimalTypes AS [at] ON a.[AnimalTypeId] = [at].[Id]
ORDER BY a.[Name]


-- 7. Owners and Their Animals -------------
  SELECT TOP(5) 
         o.[Name]
         ,COUNT(o.[Id]) AS [CountOfAnimals]
    FROM Animals AS a
    JOIN Owners AS o ON a.[OwnerId] = o.[Id]
GROUP BY o.[Id], o.[Name]
ORDER BY [CountOfAnimals] DESC, o.[Name]


-- 8. Owners, Animals and Cages ------------
  SELECT CONCAT(o.[Name], '-', a.[Name]) AS [OwnersAnimals]
         ,o.[PhoneNumber]
		 ,ac.[CageId]
    FROM Owners AS o
    JOIN Animals AS a ON o.[Id] = a.[OwnerId]
    JOIN AnimalTypes AS [at] ON a.[AnimalTypeId] = [at].[Id]
    JOIN AnimalsCages AS ac ON a.[Id] = ac.[AnimalId]
   WHERE [at].[AnimalType] = 'mammals'
ORDER BY o.[Name], a.[Name] DESC


-- 9. Volunteers in Sofia ------------------
  SELECT v.[Name]
         ,v.[PhoneNumber]
		 ,TRIM(' Sofia, ' FROM v.[Address]) AS [Address]
    FROM Volunteers AS v
    JOIN VolunteersDepartments AS vd ON v.[DepartmentId] = vd.[Id]
   WHERE v.[Address] LIKE '%Sofia%'
     AND vd.[DepartmentName] = 'Education program assistant'
ORDER BY v.[Name]


-- 10. Animals for Adoption ----------------
  SELECT a.[Name] 
         ,YEAR(a.[BirthDate]) AS [BirthYear]
		 ,[at].[AnimalType]
    FROM Animals AS a
    JOIN AnimalTypes AS [at] ON a.[AnimalTypeId] = [at].[Id]
   WHERE (a.[OwnerId] IS NULL) 
     AND (YEAR(a.[BirthDate]) >= 2018) AND [at].[AnimalType] NOT IN ('Birds')
ORDER BY a.[Name]
GO

/****** Section 4. Programmability (20 pts) ******/
-- 11. All Volunteers in a Department -------------
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
     DECLARE @result INT;
	     SET @result = (SELECT COUNT(v.[Id])
                          FROM VolunteersDepartments AS vd
                     LEFT JOIN Volunteers AS v ON vd.[Id] = v.[DepartmentId]
                         WHERE vd.[DepartmentName] = @VolunteersDepartment)
	 RETURN @result
END
GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')
GO

-- 12. Animals with Owner or Not ------------------
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
     SELECT a.[Name]
	        ,ISNULL(o.[Name], 'For adoption')
       FROM Animals AS a
  LEFT JOIN Owners AS o ON a.[OwnerId] = o.[Id]
      WHERE a.[Name] = @AnimalName
GO


EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'