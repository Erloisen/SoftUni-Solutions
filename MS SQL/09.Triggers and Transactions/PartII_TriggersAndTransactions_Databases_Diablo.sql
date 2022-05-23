USE Diablo
GO

/****** Problem 19.	Trigger ******/
-----------------------------------
--01.------------------------------
CREATE OR ALTER TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId INT = (SELECT [ItemId] FROM inserted)
DECLARE @userGameId INT = (SELECT [UserGameId] FROM inserted)

DECLARE @itemLevel INT = (SELECT [MinLevel] FROM Items WHERE [Id] = @itemId)
DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE [Id] = @userGameId)

IF (@userGameLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
	(@itemId, @userGameId)
END
GO

SELECT *
  FROM Users AS u
  JOIN UsersGames AS ug ON ug.UserId = u.Id
 WHERE ug.[Id] = 38
GO

SELECT *
  FROM Items
 WHERE Id = 2
GO

SELECT *
  FROM UserGameItems
 WHERE UserGameId = 38 AND ItemId = 14
GO

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
(14, 38)
GO

--02.------------------------------
UPDATE UsersGames
   SET Cash += 50000
 WHERE GameId = (SELECT [Id] FROM Games WHERE [Name] = 'Bali') AND 
       UserId IN (SELECT [Id] FROM Users WHERE [Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))
GO

CREATE OR ALTER PROCEDURE usp_BuiItem @userId INT, @itemId INT, @gameId INT
AS
BEGIN TRANSACTION
	DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @userId)
	DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)
	
	IF (@user IS NULL OR @item IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalide user or item Id!', 16, 1)
		RETURN
	END
	
	DECLARE @userCash DECIMAL(15, 2) = (SELECT [Cash] FROM UsersGames WHERE [UserId] = @userId AND GameId = @gameId)
	DECLARE @itemPrice DECIMAL(15, 2) = (SELECT [Price] FROM Items WHERE [Id] = @itemId)
	
	IF (@userCash - @itemPrice < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Insufficient fund!', 16, 2)
		RETURN
	END
	
	UPDATE UsersGames
	   SET [Cash] -= @itemPrice
	 WHERE [UserId] = @userId AND GameId = @gameId
	
	DECLARE @userGameId DECIMAL(15, 2) = (SELECT [Id] FROM UsersGames WHERE [UserId] = @userId AND GameId = @gameId)
	
	INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (@itemId, @userGameId)
COMMIT
GO


--03.------------------------------
DECLARE @itemId INT = 251

WHILE(@itemId <= 222)
BEGIN
	EXEC usp_BuiItem 12, @itemId, 212 --monoxidecos
	EXEC usp_BuiItem 22, @itemId, 212 --buildingdeltoid
	EXEC usp_BuiItem 37, @itemId, 212 --inguinalself
	EXEC usp_BuiItem 52, @itemId, 212 --loosenoise
	EXEC usp_BuiItem 61, @itemId, 212 --baleremuda

	 SET @itemId += 1
END
GO

DECLARE @secondGroupitemId INT = 501

WHILE(@secondGroupitemId <= 539)
BEGIN
	EXEC usp_BuiItem 12, @secondGroupitemId, 212 --monoxidecos
	EXEC usp_BuiItem 22, @secondGroupitemId, 212 --buildingdeltoid
	EXEC usp_BuiItem 37, @secondGroupitemId, 212 --inguinalself
	EXEC usp_BuiItem 52, @secondGroupitemId, 212 --loosenoise
	EXEC usp_BuiItem 61, @secondGroupitemId, 212 --baleremuda

	 SET @secondGroupitemId += 1
END
GO

SELECT [Id]
  FROM Users 
 WHERE Username
    IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO


--04.------------------------------
SELECT u.[Username]
	   ,g.[Name]
	   ,ug.[Cash]
	   ,i.[Name] AS [Item Name]
  FROM Users AS u
  JOIN UsersGames AS ug ON ug.[UserId] = u.[Id]
  JOIN Games AS g ON g.[Id] = ug.[GameId]
  JOIN UserGameItems AS ugi ON ugi.[UserGameId] = ug.[Id]
  JOIN Items AS i ON i.[Id] = ugi.[ItemId]
 WHERE g.[Name] = 'Bali'
 ORDER BY u.[Username], i.[Name]
GO


/****** Problem 20.	*Massive Shopping ******/
---------------------------------------------
DECLARE @userGameId INT = (SELECT ug.[Id] 
							 FROM UsersGames AS ug 
							WHERE ug.[UserId] = 9 AND ug.[GameId] = 87)
DECLARE @stamatCash MONEY = (SELECT ug.[Cash] 
						       FROM UsersGames AS ug 
						      WHERE ug.[Id] = @userGameId)

DECLARE @itemsPrice MONEY = (SELECT SUM(i.[Price]) AS [TotalPrice]
							   FROM Items AS i
							  WHERE i.[MinLevel] BETWEEN 11 AND 12)

IF (@stamatCash >= @itemsPrice)
BEGIN
	BEGIN TRANSACTION
   UPDATE UsersGames
	  SET Cash -= @itemsPrice
	WHERE Id = @userGameId

   INSERT INTO UserGameItems([ItemId], [UserGameId])
   SELECT Id, @userGameId 
     FROM Items AS i
    WHERE i.[MinLevel] BETWEEN 11 AND 12
COMMIT
END

SET @stamatCash = (SELECT ug.[Cash] 
				     FROM UsersGames AS ug 
				    WHERE ug.[Id] = @userGameId)

SET @itemsPrice = (SELECT SUM(i.[Price]) AS [TotalPrice]
					 FROM Items AS i
					WHERE i.[MinLevel] BETWEEN 11 AND 12)

IF (@stamatCash >= @itemsPrice)
BEGIN
	BEGIN TRANSACTION
   UPDATE UsersGames
	  SET Cash -= @itemsPrice
	WHERE Id = @userGameId

   INSERT INTO UserGameItems([ItemId], [UserGameId])
   SELECT Id, @userGameId 
     FROM Items AS i
    WHERE i.[MinLevel] BETWEEN 19 AND 21
COMMIT
END
GO

SELECT i.[Name]
  FROM Users AS u
  JOIN UsersGames AS ug ON ug.UserId = u.Id
  JOIN Games AS g ON g.Id = ug.GameId
  JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
  JOIN Items AS i ON i.Id = ugi.ItemId
 WHERE u.[Username] = 'Stamat' AND g.[Name] = 'Safflower'
GO