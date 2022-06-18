USE Airport
GO

/****** Section 3. Querying (40 pts) ******/
-- 5. Aircraft -----------------------------
  SELECT a.[Manufacturer]
         ,a.[Model]
		 ,a.[FlightHours]
		 ,a.[Condition]
    FROM Aircraft AS a
ORDER BY a.[FlightHours] DESC


-- 6. Pilots and Aircraft ------------------
  SELECT p.[FirstName]
         ,p.[LastName]
		 ,a.[Manufacturer]
		 ,a.[Model]
		 ,a.[FlightHours]
    FROM Aircraft AS a
    JOIN PilotsAircraft AS pa ON a.[Id] = pa.[AircraftId]
    JOIN Pilots AS p ON pa.[PilotId] = p.[Id]
   WHERE a.[FlightHours] IS NOT NULL AND a.[FlightHours] < 304
ORDER BY a.[FlightHours] DESC, p.[FirstName]


-- 7. Top 20 Flight Destinations -----------
  SELECT TOP(20)
         fd.[Id]
	     ,fd.[Start]
	     ,p.[FullName]
	     ,a.[AirportName]
	     ,fd.[TicketPrice]
    FROM FlightDestinations AS fd
    JOIN Airports AS a ON fd.[AirportId] = a.[Id]
    JOIN Passengers AS p ON fd.[PassengerId] = p.[Id]
   WHERE DAY(fd.[Start]) % 2 = 0
ORDER BY fd.[TicketPrice] DESC, a.[AirportName]


-- 8. Number of Flights for Each Aircraft --
  SELECT a.[Id] AS [AircraftId]
         ,a.[Manufacturer] 
	     ,a.[FlightHours]
	     ,COUNT(a.[Id]) AS [FlightDestinationsCount]
	     ,ROUND(AVG(fd.[TicketPrice]), 2) AS [AvgPrice]
    FROM FlightDestinations AS fd
    JOIN Aircraft AS a ON a.[Id] = fd.[AircraftId]
GROUP BY a.[Id], a.[Manufacturer], a.[FlightHours]
  HAVING COUNT(a.[Id]) >= 2
ORDER BY [FlightDestinationsCount] DESC, [AircraftId]


-- 9. Regular Passengers -------------------
  SELECT p.[FullName]
         ,COUNT(p.[Id]) AS [CountOfAircraft]
	     ,SUM(fd.[TicketPrice]) AS [TotalPayed]
    FROM Passengers AS p
    JOIN FlightDestinations AS fd ON p.[Id] = fd.[PassengerId]
    JOIN Aircraft AS a ON fd.[AircraftId] = a.[Id]
GROUP BY p.[FullName]
  HAVING (COUNT(p.[Id]) > 1) AND (SUBSTRING(p.[FullName], 2, 1) = 'a')
ORDER BY p.[FullName]


-- 10. Full Info for Flight Destinations ---
  SELECT a.[AirportName]
         ,fd.[Start]
		 ,fd.[TicketPrice]
		 ,p.[FullName]
		 ,ac.[Manufacturer]
		 ,ac.[Model]
    FROM FlightDestinations AS fd
    JOIN Passengers AS p ON fd.[PassengerId] = p.[Id]
    JOIN Airports AS a ON fd.[AirportId] = a.[Id]
    JOIN Aircraft AS ac ON fd.[AircraftId] = ac.[Id]
   WHERE (DATEPART(hour, fd.[Start]) BETWEEN 6 AND 20) AND fd.[TicketPrice] > 2500
ORDER BY ac.[Model]
GO


/****** Section 4. Programmability (20 pts) ******/
-- 11. Find all Destinations by Email Address -----
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
      DECLARE @result INT
          SET @result = (SELECT COUNT(p.[Id])
                           FROM Passengers AS p
                           JOIN FlightDestinations AS fd ON p.[Id] = fd.[PassengerId]
                          WHERE p.[Email] = @email
                       GROUP BY p.[Id])

          IF (@result IS NULL)
          BEGIN
               SET @result = 0
          END
 
          RETURN @result
END
GO


SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')
GO

-- 12. Full Info for Airports ---------------------
CREATE PROCEDURE usp_SearchByAirportName (@airportName VARCHAR(70))
AS
     SELECT a.[AirportName]
            ,p.[FullName]
   		    ,CASE WHEN fd.[TicketPrice] <= 400 THEN 'Low'
   			      WHEN fd.[TicketPrice] >= 401 AND fd.[TicketPrice] <= 1500 THEN 'Medium'
   			      WHEN fd.[TicketPrice] >= 1501 THEN 'High'
   		     END AS [LevelOfTickerPrice]
   	        ,ac.[Manufacturer]
   	        ,ac.[Condition]
            ,[at].[TypeName]
       FROM Airports AS a
       JOIN FlightDestinations AS fd ON a.[Id] = fd.[AirportId]
       JOIN Passengers AS p ON fd.[PassengerId] = p.[Id]
       JOIN Aircraft AS ac ON fd.[AircraftId] = ac.[Id]
       JOIN AircraftTypes AS [at] ON ac.[TypeId] = [at].[Id] 
      WHERE a.[AirportName] = @airportName
   ORDER BY ac.[Manufacturer], p.[FullName]
GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'