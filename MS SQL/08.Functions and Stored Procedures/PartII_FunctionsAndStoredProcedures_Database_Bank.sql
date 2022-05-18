USE Bank

/****** Problem 09. Find Full Name ******/
------------------------------------------
CREATE PROC usp_GetHoldersFullName
AS
SELECT ac.[FirstName] + ' ' + ac.[LastName] AS [Full Name]
  FROM AccountHolders AS ac

EXEC dbo.usp_GetHoldersFullName


/****** Problem 10.	People with Balance Higher Than ******/
-----------------------------------------------------------
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@moneyInTotal MONEY)
AS
	 SELECT ah.[FirstName]
		    ,ah.[LastName]
	   FROM AccountHolders AS ah
       JOIN Accounts AS a ON a.[AccountHolderId] = ah.[Id]
   GROUP BY ah.[FirstName], ah.[LastName]
     HAVING SUM(Balance) > @moneyInTotal
   ORDER BY ah.[FirstName], ah.[LastName]

EXEC usp_GetHoldersWithBalanceHigherThan 10000


/****** Problem 11.	Future Value Function ******/
-------------------------------------------------
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15,4)
AS
BEGIN
	DECLARE @result DECIMAL(15,4)
	SET @result = @sum * (POWER((1 + @yearlyInterestRate), @numberOfYears))
	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)


/****** Problem 12.	Calculating Interest ******/
------------------------------------------------
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@accounTd INT, @interestRate FLOAT)
AS
	SELECT ah.[Id] AS [Account Id]
		   ,ah.[FirstName] AS [First Name]
		   ,ah.[LastName] AS [Last Name]
		   ,a.[Balance] AS [Current Balance]
		   ,dbo.ufn_CalculateFutureValue(a.[Balance], @interestRate, 5) AS [Balance in 5 years]
	  FROM AccountHolders AS ah
	  JOIN Accounts AS a ON a.Id = ah.Id
	 WHERE a.[Id] = @accounTd

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1