USE Bitbucket
GO

/****** Section 3. Querying (40 pts) ******/
--05. Commits-------------------------------
  SELECT [Id], [Message], [RepositoryId], [ContributorId]
    FROM Commits
ORDER BY [Id], [Message], [RepositoryId], [ContributorId]

--06. Front-end-----------------------------
  SELECT [Id], [Name], [Size]
    FROM Files
   WHERE [Size] > 1000 AND [Name] LIKE '%html'
ORDER BY [Size] DESC, [Id], [Name]


--07. Issue Assignment----------------------
    SELECT i.[Id]
	       ,CONCAT_WS(' : ', u.[Username], i.[Title]) AS [IssueAssignee]
      FROM Users AS u
RIGHT JOIN Issues AS i ON u.[Id] = i.[AssigneeId]
  ORDER BY i.[Id] DESC, i.[AssigneeId]


--08. Single Files--------------------------
  SELECT i.[Id]
	     ,i.[Name]
	     ,CONCAT(i.[Size], 'KB')
    FROM Files AS i
   WHERE NOT EXISTS (SELECT 1 FROM Files AS p WHERE p.[ParentId] = i.[Id])
ORDER BY i.[Id], i.[Name] ASC, i.[Size] DESC


--09. Commits in Repositories---------------
SELECT TOP(5) r.[Id]
	         ,r.[Name]
		     ,COUNT(r.[Name]) AS [Commits]
        FROM Repositories AS r
        JOIN Commits AS c ON r.[Id] = c.[RepositoryId]
        JOIN RepositoriesContributors AS rc ON r.[Id] = rc.[RepositoryId]
    GROUP BY r.[Name], r.[Id]
    ORDER BY [Commits] DESC, r.[Id], r.[Name]


--10. Average Size--------------------------
  SELECT u.[Username]
         ,AVG(f.[Size]) AS [Size]
    FROM Users AS u
    JOIN Commits AS c ON u.[Id] = c.[ContributorId]
    JOIN Files AS f ON c.[Id] = f.[CommitId]
GROUP BY u.[Username]
ORDER BY [Size] DESC, u.[Username] ASC


/****** Section 4. Programmability (20 pts) ******/
--11. All User Commits-----------------------------
CREATE FUNCTION udf_AllUserCommits (@username VARCHAR(30))
RETURNS INT
AS
BEGIN
		DECLARE @result INT;
		    SET @result = (SELECT COUNT(c.[ContributorId])
						     FROM Commits AS c
		                     JOIN Users AS u ON c.[ContributorId] = u.[Id]
		                    WHERE u.[Username] = @username
		                 GROUP BY c.[ContributorId]);
		IF (@result IS NULL)
			SET @result = 0

		 RETURN @result;
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')
SELECT dbo.udf_AllUserCommits('WhoDenoteBel')


--12. Search for Files-----------------------------
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
	  SELECT [Id]
		     ,[Name]
		     ,CONCAT([Size], 'KB') AS [Size]
	    FROM Files
	   WHERE [Name] Like '%' + @fileExtension
	ORDER BY [Id], [Name], [Size] DESC
GO

EXEC usp_SearchForFiles 'txt'