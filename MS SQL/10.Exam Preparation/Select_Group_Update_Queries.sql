USE TripService
GO

/***** Section 02. DLL (10pts) *****/
-------------------------------------
--02. Insert-------------------------

INSERT INTO Accounts ([FirstName], [MiddleName], [LastName], [CityId], [BirthDate], [Email])
VALUES 
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com')
,('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com')
,('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg')
,('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips ([RoomId], [BookDate], [ArrivalDate], [ReturnDate], [CancelDate])
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02')
,(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29')
,(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL)
,(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10')
,(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)


--03. Update-------------------------
SELECT *
  FROM Rooms
 WHERE [HotelId] IN (5, 7, 9)

UPDATE Rooms
   SET [Price] = [Price] * 1.14
 WHERE [HotelId] IN (5, 7, 9)


--04. Delete-------------------------
SELECT *
  FROM AccountsTrips
 WHERE [AccountId] = 47

DELETE FROM AccountsTrips
      WHERE [AccountId] = 47


/***** Section 3. Querying (40 pts) *****/
------------------------------------------
--05. EEE-Mails---------------------------
SELECT a.[FirstName]
	   ,a.[LastName]
	   ,FORMAT(a.[BirthDate],'MM-dd-yyyy')
	   ,c.[Name] AS [Hometown]
	   ,a.[Email]
  FROM Accounts AS a
  JOIN Cities AS c ON a.[CityId] = c.[Id]
 WHERE [Email] LIKE 'e%'
 ORDER BY c.[Name] ASC


--06. City Statistics---------------------
SELECT DISTINCT c.[Name] AS [City]
	   ,COUNT(h.[Name]) OVER (PARTITION BY c.[Id]) AS [Hotels]
  FROM Cities AS c
  JOIN Hotels AS h ON c.[Id] = h.[CityId]
 ORDER BY [Hotels] DESC, c.[Name] ASC

SELECT c.[Name] AS [City]
	   ,COUNT(*) AS [Hotels]
  FROM Hotels AS h
  JOIN Cities AS c ON h.[CityId] = c.[Id]
  GROUP BY c.[Name]
  ORDER BY [Hotels] DESC, c.[Name] ASC


--07. Longest and Shortest Trips----------
SELECT [at].[AccountId]
	   ,CONCAT(a.[FirstName], ' ', a.[LastName]) AS [FullName]
	   ,MAX(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [LongestTrip]
	   ,MIN(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [ShortestTrip]
  FROM Accounts AS a
  JOIN AccountsTrips AS [at] ON a.Id = [at].[AccountId]
  JOIN Trips AS t ON [at].[TripId] = t.[Id]
 WHERE a.[MiddleName] IS NULL AND t.[CancelDate] IS NULL
 GROUP BY [at].[AccountId], a.[FirstName], a.[LastName]
 ORDER BY [LongestTrip] DESC, [ShortestTrip] ASC


--08. Metropolis--------------------------
SELECT TOP(10) c.[Id]
	   ,c.[Name] AS [City]
	   ,c.[CountryCode] AS [Country]
	   ,COUNT(*) AS [Accounts]
  FROM Cities AS c
  JOIN Accounts AS a ON c.[Id] = a.[CityId]
 GROUP BY c.Id, c.[Name], c.[CountryCode]
 ORDER BY [Accounts] DESC


--09. Romantic Getaways-------------------
SELECT a.[Id]
	   ,a.[Email]
	   ,ac.[Name] AS [City]
	   ,COUNT(*) AS [Trips]
  FROM AccountsTrips AS [at]
  JOIN Accounts AS a ON at.[AccountId] = a.[Id]
  JOIN Cities AS ac ON a.[CityId] = ac.[Id]
  JOIN Trips AS t ON [at].[TripId] = t.[Id]
  JOIN Rooms AS r ON t.[RoomId] = r.[Id]
  JOIN Hotels AS h ON r.[HotelId] = h.[Id]
  JOIN Cities AS hc ON h.[CityId] = hc.[Id]
 WHERE ac.[Id] = hc.[Id]
 GROUP BY a.[Id], a.[Email], ac.[Name]
 ORDER BY [Trips] DESC, a.[Id]


--10. GDPR Violation----------------------
SELECT t.[Id]
	   ,CONCAT(a.[FirstName], ' ', ISNULL(a.[MiddleName] + ' ', ''), a.[LastName]) AS [Full Name]
	   ,ac.[Name] AS [From]
	   ,hc.[Name] AS [To]
	   ,CASE
			WHEN t.[CancelDate] IS NOT NULL THEN 'Canceled'
			ELSE CONCAT(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate]), ' days') 
	   END AS [Duration]
  FROM AccountsTrips AS [at]
  JOIN Trips AS t ON [at].TripId = t.[Id]
  JOIN Rooms AS r ON t.[RoomId] = r.[Id]
  JOIN Hotels AS h ON r.[HotelId] = h.[Id]
  JOIN Cities AS hc ON h.[CityId] = hc.[Id]
  JOIN Accounts AS a ON [at].AccountId = a.[Id]
  JOIN Cities AS ac ON a.[CityId] = ac.[Id]
 ORDER BY [Full Name], t.[Id]


/***** Section 4. Programmability (14 pts) *****/
-------------------------------------------------
--11. Available Room-----------------------------
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @RoomInfo NVARCHAR(MAX) = (SELECT TOP(1) CONCAT('Room ', r.[Id], ': ', r.[Type], ' (', r.[Beds], ' beds) - $', CONVERT(VARCHAR, (h.[BaseRate] + r.[Price]) * @People))
	  FROM Rooms AS r
	  JOIN Hotels AS h ON r.[HotelId] = h.[Id]
	 WHERE h.[Id] = @HotelId AND r.[Beds] >= @People
	   AND NOT EXISTS (SELECT * 
						 FROM Trips AS t 
						WHERE t.[RoomId] = r.[Id] 
						  AND t.[CancelDate] IS NULL
						  AND @Date BETWEEN t.[ArrivalDate] AND t.[ReturnDate])
	 ORDER BY (h.[BaseRate] + r.[Price]) * @People DESC)

	 IF (@RoomInfo IS NULL)
	 BEGIN
		 RETURN 'No rooms available'
	 END
	 
		RETURN @RoomInfo
END
GO

SELECT dbo.udf_GetAvailableRoom (112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom (94, '2015-07-26', 3)


--12. Switch Room--------------------------------
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	--If the target room ID is in a different hotel, than the trip is in, raise an exception with the message “Target room is in another hotel!”.
	DECLARE @TripHotelId INT = (SELECT r.[HotelId]
							  FROM Trips AS t
							  JOIN Rooms AS r ON t.[RoomId] = r.[Id]
							 WHERE t.[Id] = @TripId)
	
	DECLARE @TargetRoomHotelId INT = (SELECT r.[HotelId]
										FROM Rooms AS r
									   WHERE r.[Id] = @TargetRoomId)
	
	
	IF (@TripHotelId != @TargetRoomHotelId)
	THROW 50001, 'Target room is in another hotel!', 1

	--If the target room doesn’t have enough beds for all the trip’s accounts, raise an exception with the message “Not enough beds in target room!”.

	DECLARE @BedsInTargetRoom INT = (SELECT r.[Beds]
									   FROM Rooms AS r
									  WHERE r.[Id] = @TargetRoomId)
	DECLARE @TripAccounts INT = (SELECT COUNT(*)
								   FROM AccountsTrips AS [at]
								  WHERE [at].[TripId] = @TripId)
	IF (@BedsInTargetRoom < @TripAccounts)
		THROW 50002, 'Not enough beds in target room!', 1
	
	
	--If all the above conditions pass, change the trip’s room ID to the target room ID.
	UPDATE Trips
	   SET RoomId = @TargetRoomId 
	 WHERE Id = @TripId
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8