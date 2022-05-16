USE Gringotts

/****** Probem 01. Records’ Count ******/
------------------------------------------
SELECT	COUNT(*) AS [Count]
  FROM WizzardDeposits


/****** Probem 02. Longest Magic Wand ******/
---------------------------------------------
SELECT	MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM WizzardDeposits


/****** Probem 03. Longest Magic Wand per Deposit Groups ******/
----------------------------------------------------------------
SELECT	[DepositGroup]
		,MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM WizzardDeposits
	GROUP BY [DepositGroup]


/****** Probem 04. *Smallest Deposit Group per Magic Wand Size ******/
----------------------------------------------------------------------
SELECT TOP(2)
		w.[DepositGroup]
	FROM WizzardDeposits AS w
	GROUP BY w.[DepositGroup]
	ORDER BY AVG(w.[MagicWandSize])


/****** Probem 05. Deposits Sum ******/
---------------------------------------
SELECT	w.[DepositGroup]
		,SUM(w.[DepositAmount]) AS [TotalSum]
	FROM WizzardDeposits AS w
	GROUP BY w.[DepositGroup]


/****** Probem 06. Deposits Sum for Ollivander Family ******/
-------------------------------------------------------------
SELECT	w.[DepositGroup]
		,SUM(w.[DepositAmount]) AS [TotalSum]
	FROM WizzardDeposits AS w
	WHERE w.[MagicWandCreator] = 'Ollivander family'
	GROUP BY w.[DepositGroup]
	

/****** Probem 07. Deposits Filter ******/
------------------------------------------
SELECT	w.[DepositGroup]
		,SUM(w.[DepositAmount]) AS [TotalSum]
	FROM WizzardDeposits AS w
	WHERE w.[MagicWandCreator] = 'Ollivander family'
	GROUP BY w.[DepositGroup]
	HAVING SUM(w.[DepositAmount]) < 150000
	ORDER BY [TotalSum] DESC
	

/****** Probem 08. Deposit Charge ******/
-----------------------------------------
SELECT	w.[DepositGroup]
		,w.[MagicWandCreator]
		,MIN(w.[DepositCharge]) AS [MinDepositCharge]
	FROM WizzardDeposits AS w
	GROUP BY w.[DepositGroup], w.[MagicWandCreator]


/****** Probem 09. Age Groups ******/
-------------------------------------
SELECT	w.[Age]
		,COUNT(w.[Age])
	FROM WizzardDeposits AS w
	GROUP BY w.[Age]
	HAVING w.[Age] > 11 AND w.[Age] <= 20

SELECT *
	FROM (SELECT
	CASE 
		WHEN w.[Age] BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN w.[Age] BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN w.[Age] BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN w.[Age] BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN w.[Age] BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN w.[Age] BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN w.[Age] >= 61 THEN '[61+]'
		END AS [AgeGroup]
		FROM WizzardDeposits AS w ) AS Groups
		GROUP BY Groups.[AgeGroup]
		ORDER BY [AgeGroup]


/****** Probem 10. First Letter ******/
---------------------------------------
SELECT	SUBSTRING(w.[FirstName], 1, 1) AS [FirstLetter]
	FROM WizzardDeposits AS w
	WHERE w.[DepositGroup] = 'Troll Chest'
	GROUP BY SUBSTRING(w.[FirstName], 1, 1)


/****** Probem 11. Average Interest ******/
-------------------------------------------
SELECT	w.[DepositGroup]
		,w.[IsDepositExpired]
		,AVG(w.[DepositInterest]) AS [AverageInterest]
	FROM WizzardDeposits AS w
	WHERE w.[DepositStartDate] >= '01/01/1985'
	GROUP BY w.[DepositGroup], w.[IsDepositExpired]
	ORDER BY w.[DepositGroup] DESC, w.[IsDepositExpired]


/****** Probem 12. Rich Wizard, Poor Wizard ******/
---------------------------------------------------
SELECT SUM(Result.[SumDifference]) AS [SumDifference]
	FROM (SELECT	w.[FirstName]
					,w.[DepositAmount]
					,w.[DepositAmount] - LEAD(w.[DepositAmount], 1, NULL)
						OVER (ORDER BY w.[Id]) AS [SumDifference]
		 FROM WizzardDeposits AS w) AS Result


SELECT	SUM(Guest.[DepositAmount] - Host.[DepositAmount]) AS [SumDifference]
	FROM WizzardDeposits AS Host
	JOIN WizzardDeposits AS Guest ON Guest.Id + 1 = Host.Id
