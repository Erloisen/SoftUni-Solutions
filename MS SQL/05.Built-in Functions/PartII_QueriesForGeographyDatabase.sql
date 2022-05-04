USE [Geography]

/****** Problem 12.	Countries Holding ‘A’ 3 or More Times  ******/
------------------------------------------------------------------
SELECT	[CountryName] AS [Country Name]
		,[IsoCode] AS [ISO Code]
  FROM Countries
  WHERE LEN([CountryName]) - LEN(REPLACE([CountryName], 'A', '')) >= 3
  ORDER BY [IsoCode]

SELECT	[CountryName]
		,[IsoCode]
  FROM Countries
  WHERE -LEN([CountryName]) + LEN(REPLACE([CountryName], 'A', '><')) >= 3
  ORDER BY [IsoCode]

SELECT [CountryName] AS [Country Name]
		,[IsoCode] AS [ISO Code]
	FROM Countries
	WHERE [CountryName] LIKE '%a%a%a%'
	ORDER BY [IsoCode]


/****** Problem 12.	Mix of Peak and River Names  ******/
--------------------------------------------------------
SELECT	[PeakName]
		,[RiverName]
		,CONCAT(LOWER(LEFT(p.[PeakName], LEN(p.[PeakName]) - 1)), LOWER(r.[RiverName])) AS [Mix]
	FROM Peaks AS p
	JOIN Rivers AS r ON RIGHT(p.[PeakName], 1) = LEFT(r.[RiverName], 1)
	ORDER BY [Mix]

SELECT	[PeakName]
		,[RiverName]
		,CONCAT(LOWER(p.[PeakName]), LOWER(RIGHT(r.[RiverName], LEN(r.[RiverName]) - 1))) AS [Mix]
	FROM Peaks AS p
	JOIN Rivers AS r ON RIGHT(p.[PeakName], 1) = LEFT(r.[RiverName], 1)
	ORDER BY [Mix]

SELECT	[PeakName]
		,[RiverName]
		,CONCAT(LOWER(SUBSTRING(p.[PeakName], 1, LEN(p.[PeakName]) - 1)), LOWER(SUBSTRING(r.[RiverName], 1, LEN(r.[RiverName])))) AS [Mix]
	FROM Peaks AS p
	JOIN Rivers AS r ON RIGHT(p.[PeakName], 1) = LEFT(r.[RiverName], 1)
	ORDER BY [Mix]

SELECT	[PeakName]
		,[RiverName]
		,CONCAT(LOWER(SUBSTRING(p.[PeakName], 1, LEN(p.[PeakName]))), LOWER(SUBSTRING(r.[RiverName], 2, LEN(r.[RiverName]) - 1))) AS [Mix]
	FROM Peaks AS p
	JOIN Rivers AS r ON RIGHT(p.[PeakName], 1) = LEFT(r.[RiverName], 1)
	ORDER BY [Mix]
