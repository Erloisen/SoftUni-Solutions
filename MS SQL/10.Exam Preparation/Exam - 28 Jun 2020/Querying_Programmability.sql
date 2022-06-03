USE ColonialJourney
GO

/****** Section 3. Querying ******/
--05. Select All Military Journeys-
  SELECT j.[Id]
	     ,FORMAT(j.[JourneyStart], 'dd/MM/yyyy') AS [JourneyStart]
	     ,FORMAT(j.[JourneyEnd], 'dd/MM/yyyy') AS [JourneyEnd]
    FROM Journeys AS j
   WHERE j.[Purpose] = 'Military'
ORDER BY j.[JourneyStart] ASC



--06. Select All Pilots------------
  SELECT c.[Id]
	     ,CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [full_name]
    FROM Colonists AS c
    JOIN TravelCards AS tc ON c.[Id] = tc.[ColonistId]
   WHERE tc.[JobDuringJourney] = 'Pilot'
ORDER BY c.[Id] ASC


--07. Count Colonists--------------
  SELECT COUNT(j.[Purpose]) AS [count]
    FROM Colonists AS c
    JOIN TravelCards AS tc ON c.[Id] = tc.[ColonistId]
	JOIN Journeys AS j ON tc.[JourneyId] = j.[Id]
   WHERE j.[Purpose] = 'Technical'


--08. Select Spaceships With Pilots
  SELECT ss.[Name]
		 ,ss.[Manufacturer]
    FROM TravelCards AS tc
    JOIN Colonists AS c ON tc.[ColonistId] = c.[Id]
    JOIN Journeys AS j ON tc.[JourneyId] = j.[Id]
    JOIN Spaceships AS ss ON j.[SpaceshipId] = ss.[Id]
   WHERE tc.[JobDuringJourney] = 'Pilot' AND DATEDIFF(YEAR, c.[BirthDate], '01/01/2019') < 30
ORDER BY ss.[Name]


--09. Planets And Journeys---------
    SELECT p.[Name]
		   ,COUNT(p.[Name]) AS [JourneysCount]
      FROM Planets AS p
RIGHT JOIN Spaceports AS sp ON p.[Id] = sp.[PlanetId]
RIGHT JOIN Journeys AS j ON sp.[Id] = j.[DestinationSpaceportId]
  GROUP BY p.[Name]
  ORDER BY [JourneysCount] DESC, p.[Name] ASC


  SELECT p.[Name]
		 ,COUNT(p.[Id]) AS [JourneysCount]
    FROM Journeys AS j
    JOIN Spaceports AS sp ON j.[DestinationSpaceportId] = sp.[Id]
    JOIN Planets AS p ON sp.[PlanetId] = p.[Id]
GROUP BY p.[Id], p.[Name]
ORDER BY [JourneysCount] DESC, p.[Name] ASC


--10. Select Special Colonists-----
SELECT *
  FROM ( SELECT tc.[JobDuringJourney]
		        ,CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [FullName]
		        ,DENSE_RANK() OVER(PARTITION BY tc.[JobDuringJourney] ORDER BY c.[BirthDate]) AS [JobRank]
	       FROM TravelCards AS tc
	       JOIN Colonists AS c ON tc.[ColonistId] = c.[Id]
	       JOIN Journeys AS j ON tc.[JourneyId] = j.[Id]
	   GROUP BY tc.[JobDuringJourney], c.[FirstName], c.[LastName], c.[BirthDate] ) AS r
 WHERE r.[JobRank] = 2


/****** Section 4. Programmability ******/
--11. Get Colonists Count-----------------
CREATE OR ALTER FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN
	 DECLARE @result INT;
		 SET @result = (SELECT COUNT(*) AS [Count]
					      FROM Colonists AS c
					 LEFT JOIN TravelCards AS tc ON c.[Id] = tc.[ColonistId]
					 LEFT JOIN Journeys AS j ON tc.[JourneyId] = j.[Id]
					 LEFT JOIN Spaceports AS sp ON j.[DestinationSpaceportId] = sp.[Id]
					 LEFT JOIN Planets AS p ON sp.[PlanetId] = p.[Id]
				         WHERE p.[Name] = @PlanetName )

	  RETURN @result
END

SELECT dbo.udf_GetColonistsCount('Otroyphus')
SELECT dbo.udf_GetColonistsCount('Lescore')
SELECT dbo.udf_GetColonistsCount('5Q5')


--12. Change Journey Purpose--------------
CREATE OR ALTER PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
	DECLARE @existId INT = ( SELECT j.[Id]
							   FROM Journeys AS j
							  WHERE j.[Id] = @JourneyId )
	DECLARE @CurrentPurpose VARCHAR(11) = (SELECT j.[Purpose]
											 FROM Journeys AS j
											WHERE j.[Id] = @JourneyId AND j.[Purpose] = @NewPurpose )

	IF (@existId IS NULL)
		THROW 50001, 'The journey does not exist!', 1

	IF (@CurrentPurpose = @NewPurpose)
		THROW 50002, 'You cannot change the purpose!', 1

	UPDATE Journeys
	   SET [Purpose] = @NewPurpose
	 WHERE [Id] = @JourneyId
GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'
