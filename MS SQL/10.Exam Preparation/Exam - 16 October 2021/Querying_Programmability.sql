USE CigarShop
GO

/****** Section 3. Querying (40 pts) ******/
-- 5. Cigars by Price ----------------------
  SELECT c.[CigarName]
		 ,c.[PriceForSingleCigar]
	     ,c.[ImageURL]
    FROM Cigars AS c
ORDER BY c.[PriceForSingleCigar], c.[CigarName] DESC
GO

-- 6.	Cigars by Taste --------------------
  SELECT c.[Id]
		 ,c.[CigarName]
		 ,c.[PriceForSingleCigar]
		 ,t.[TasteType]
		 ,t.[TasteStrength]
    FROM Cigars AS c
    JOIN Tastes AS t ON c.[TastId] = t.[Id]
   WHERE t.[TasteType] IN ('Earthy', 'Woody')
ORDER BY c.[PriceForSingleCigar] DESC
GO

-- 7. Clients without Cigars ---------------
  SELECT c.[Id]
	  ,CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [ClientName]
	  ,c.[Email]
    FROM Clients AS c
   WHERE c.[Id] NOT IN (SELECT [ClientId] FROM ClientsCigars)
ORDER BY [ClientName]
GO

-- 8. First 5 Cigars------------------------
  SELECT TOP(5) 
	     c.[CigarName]
	     ,c.[PriceForSingleCigar], c.[ImageURL]
    FROM Cigars AS c
    JOIN Sizes AS s ON c.[SizeId] = s.[Id]
   WHERE s.[Length] >= 12 AND (c.[CigarName] LIKE '%ci%' OR c.[PriceForSingleCigar] >= 50 AND s.[RingRange] > 2.55)
ORDER BY c.[CigarName], c.[PriceForSingleCigar] DESC
GO

-- 9. Clients with ZIP Codes ---------------
    SELECT [Result].[FullName]
           ,[Result].[Country]
           ,[Result].[ZIP]
           ,CONCAT('$',[Result].[CigarPrice]) AS [CigarPrice]
	  FROM (SELECT CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [FullName]
	               ,a.[Country]
	               ,a.[ZIP]
	               ,ci.[PriceForSingleCigar] AS [CigarPrice]
	               ,RANK() OVER (PARTITION BY a.[ZIP] ORDER BY ci.[PriceForSingleCigar] DESC) AS [Rank]
              FROM Clients AS c
              JOIN Addresses AS a ON c.[AddressId] = a.[Id]
              JOIN ClientsCigars AS cc ON c.[Id] = cc.[ClientId]
              JOIN Cigars AS ci ON cc.[CigarId] = ci.[Id]
             WHERE a.[ZIP] NOT LIKE '%[^0-9]%') AS [Result]
     WHERE [Result].[Rank] = 1
  ORDER BY [Result].[FullName]
GO

   SELECT CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [FullName]
	      ,a.[Country]
	      ,a.[ZIP]
	      ,CONCAT('$', MAX(ci.[PriceForSingleCigar])) AS [CigarPrice]
     FROM Clients AS c
     JOIN Addresses AS a ON c.[AddressId] = a.[Id]
     JOIN ClientsCigars AS cc ON c.[Id] = cc.[ClientId]
     JOIN Cigars AS ci ON cc.[CigarId] = ci.[Id]
    WHERE a.[ZIP] NOT LIKE '%[^0-9]%'
 GROUP BY c.[FirstName], c.[LastName], a.[Id], a.[Country], a.[ZIP]
 ORDER BY [FullName]
GO

-- 10. Cigars by Size ----------------------
  SELECT c.[LastName]
         ,AVG(s.[Length]) AS [CiagrLength]
         ,CEILING(AVG(s.[RingRange])) AS [CiagrRingRange]
    FROM Clients AS c
    JOIN ClientsCigars AS cc ON c.[Id] = cc.[ClientId]
    JOIN Cigars AS ci ON cc.[CigarId] = ci.[Id]
    JOIN Sizes AS s ON ci.[SizeId] = s.[Id]
GROUP BY c.[LastName]
ORDER BY [CiagrLength] DESC
GO

/****** Section 4. Programmability (20 pts) ******/
-- 11. Client with Cigars -------------------------
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
      DECLARE @result INT;
	  SET @result = (SELECT COUNT(*)
                       FROM Clients AS c
                       JOIN ClientsCigars AS cc ON c.[Id] = cc.[ClientId]
                       JOIN Cigars AS ci ON cc.[CigarId] = ci.[Id]
                      WHERE c.[FirstName] = @name)

	  RETURN @result
END
GO

SELECT dbo.udf_ClientWithCigars('Betty')
GO

-- 12.	Search for Cigar with Specific Taste ------
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
  SELECT c.[CigarName]
		 ,CONCAT('$', c.[PriceForSingleCigar]) AS [Price]
		 ,t.[TasteType]
		 ,b.[BrandName]
		 ,CONCAT(s.[Length], ' cm') AS [CigarLength]
		 ,CONCAT(s.[RingRange], ' cm') AS [CigarRingRange]
    FROM Cigars AS c
    JOIN Tastes AS t ON c.[TastId] = t.[Id]
    JOIN Brands AS b ON c.[BrandId] = b.[Id]
    JOIN Sizes AS s ON c.[SizeId] = s.[Id]
   WHERE t.[TasteType] = @taste
ORDER BY [CigarLength], [CigarRingRange] DESC
GO

EXEC usp_SearchByTaste 'Woody'