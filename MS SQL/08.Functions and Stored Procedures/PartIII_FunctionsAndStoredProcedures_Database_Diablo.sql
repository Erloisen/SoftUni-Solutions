USE Diablo
GO

/****** Problem 13.	*Scalar Function: Cash in User Games Odd Rows ******/
-------------------------------------------------------------------------
CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS TABLE AS
RETURN
(
 SELECT SUM(t.[SumCash]) AS [SumCash]
   FROM (SELECT ug.[Cash] AS [SumCash]
 			    ,ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [Row Number]
 		   FROM Games AS g
 		   JOIN UsersGames AS ug ON ug.[GameId] = g.[Id]
		  WHERE g.[Name] = @gameName) AS t
  WHERE t.[Row Number] % 2 = 1
)

SELECT *
  FROM dbo.ufn_CashInUsersGames('Love in a mist')