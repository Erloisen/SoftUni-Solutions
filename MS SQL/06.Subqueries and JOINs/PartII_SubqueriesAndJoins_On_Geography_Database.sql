USE Geography


/****** Problem 12. Highest Peaks in Bulgaria ******/
-----------------------------------------------------
SELECT	mc.[CountryCode]
		,m.[MountainRange]
		,p.[PeakName]
		,p.[Elevation]
	FROM Peaks AS p
	FULL JOIN Mountains AS m ON m.[Id] = p.[MountainId]
	FULL JOIN MountainsCountries AS mc ON mc.[MountainId] = m.[Id]
	WHERE mc.[CountryCode] = 'BG' 
		 AND p.[Elevation] > 2835
 ORDER BY p.[Elevation] DESC


/****** Problem 13. Count Mountain Ranges ******/
-------------------------------------------------
SELECT	c.[CountryCode]
		,(SELECT COUNT(*)
			FROM MountainsCountries AS mc
		   WHERE mc.[CountryCode] = c.[CountryCode]
		) AS [MountainRanges]
  FROM Countries AS c
 WHERE c.[CountryCode] IN ('US', 'RU', 'BG')

SELECT	c.[CountryCode]
		,COUNT(*) AS [MountainRanges]
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON mc.[CountryCode] = c.[CountryCode]
   WHERE c.[CountryCode] IN ('US', 'RU', 'BG')
GROUP BY c.[CountryCode]

/****** Problem 14. Countries with Rivers ******/
-------------------------------------------------
SELECT TOP(5)
		c.[CountryName]
		,r.[RiverName]
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.[CountryCode] = c.[CountryCode]
	LEFT JOIN Rivers AS r ON r.[Id] = cr.[RiverId]
	LEFT JOIN Continents AS con ON con.[ContinentCode] = c.[ContinentCode]
	WHERE con.[ContinentName] = 'Africa'
	ORDER BY c.[CountryName]


/****** Problem 15. *Continents and Currencies ******/
------------------------------------------------------
SELECT	cc.[ContinentCode]
		,cc.[CurrencyCode]
		,[CurrencyUsage]
	FROM (SELECT  c.[ContinentCode]
				 ,c.[CurrencyCode]
				 ,COUNT(c.[CurrencyCode]) AS [CurrencyUsage]
				 ,DENSE_RANK() OVER(PARTITION BY c.[ContinentCode] ORDER BY COUNT(c.[CurrencyCode]) DESC) AS [Ranked]
			FROM Countries AS c
			GROUP BY c.[ContinentCode], c.[CurrencyCode]
	) AS cc
	WHERE [Ranked] = 1 AND [CurrencyUsage] > 1
	ORDER BY [ContinentCode]


/****** Problem 16. Countries Without Any Mountains ******/
-----------------------------------------------------------
SELECT	COUNT(*) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.[CountryCode] = c.[CountryCode]
	LEFT JOIN Mountains AS m ON m.[Id] = mc.[MountainId]
	WHERE m.[MountainRange] IS NULL
	GROUP BY m.[MountainRange]

SELECT COUNT(c.CountryName) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.[CountryCode] = c.[CountryCode]
	WHERE mc.[MountainId] IS NULL


/****** Problem 17. Highest Peak and Longest River by Country ******/
---------------------------------------------------------------------
SELECT	TOP(5)
		c.[CountryName]
		,MAX(p.[Elevation]) AS [HighestPeakElevation]
		,MAX(r.[Length]) AS [LongestRiverLength]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.[CountryCode] = c.[CountryCode]
	LEFT JOIN Mountains AS m ON m.[Id] = mc.[MountainId]
	LEFT JOIN Peaks AS p ON p.[MountainId] = m.[Id]
	LEFT JOIN CountriesRivers AS cr ON cr.[CountryCode] = c.[CountryCode]
	LEFT JOIN Rivers AS r ON r.[Id] = cr.[RiverId]
	GROUP BY c.[CountryName]
	ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName]


/****** Problem 18. *Highest Peak Name and Elevation by Country ******/
-----------------------------------------------------------------------
SELECT	TOP(5)
		[CountryName] AS [Country]
		,ISNULL(Result.[PeakName], '(no highest peak)') AS [Highest Peak Name]
		,ISNULL(Result.[Elevation], 0) AS [Highest Peak Elevation]
		,ISNULL(Result.[MountainRange], '(no mountain)') AS [Mountain]
	FROM (SELECT	c.[CountryName]
					,p.[PeakName]
					,p.[Elevation]
					,m.[MountainRange]
					,DENSE_RANK() OVER (PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [Rank]
			FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc ON mc.[CountryCode] = c.[CountryCode]
			LEFT JOIN Mountains AS m ON m.[Id] = mc.[MountainId]
			LEFT JOIN Peaks AS p ON p.[MountainId] = m.[Id]
		 ) AS Result
	WHERE [Rank] = 1
	ORDER BY [Country], [Highest Peak Name]