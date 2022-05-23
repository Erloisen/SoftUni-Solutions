USE Bank
GO

/****** Problem 14. Create Table Logs ******/
---------------------------------------------
CREATE TABLE Logs
(
	[LogId] INT PRIMARY KEY IDENTITY
	,[AccountId] INT NOT NULL REFERENCES Accounts(Id)
	,[OldSum] MONEY NOT NULL
	,[NewSum] MONEY NOT NULL
)
GO

CREATE TRIGGER tr_OnAccountChangeAddLogRecord ON Accounts FOR UPDATE
AS
	INSERT Logs ([AccountId], [OldSum], [NewSum])
	SELECT i.[Id]
		   ,d.[Balance]
		   ,i.[Balance] 
	  FROM inserted AS i
	  JOIN deleted AS d ON d.Id = i.Id
GO

UPDATE Accounts
   SET Balance += 10 
 WHERE Accounts.[Id] = 1

GO

SELECT *
  FROM Logs
GO


/****** Problem 15. Create Table Emails ******/
-----------------------------------------------
CREATE TABLE NotificationEmails
(
	[Id] INT PRIMARY KEY IDENTITY
	,[Recipient] INT FOREIGN KEY REFERENCES Accounts(Id)
	,[Subject] VARCHAR(50) NOT NULL
	,[Body] VARCHAR(MAX) NOT NULL
)
GO

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @newSum DECIMAL(15, 2) = (SELECT TOP(1) NewSum FROM inserted)
	 INSERT NotificationEmails([Recipient], [Subject], [Body]) VALUES
	 (
		@accountId
		,CONCAT('Balance change for account: ', @accountId)
		,CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldSum, ' to ', @newSum, '.')
	 )
GO

SELECT * 
  FROM Accounts 
 WHERE Id = 5
GO

UPDATE Accounts
   SET Balance -= 1000
 WHERE Accounts.Id = 5
GO

SELECT *
  FROM NotificationEmails
GO


/****** Problem 16. Deposit Money ******/
-----------------------------------------
CREATE PROCEDURE usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(15, 4)
AS
BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

	IF (@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account Id!', 16, 1)
		RETURN
	END

	IF (@moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Amount can not be negative number!', 16, 1)
		RETURN
	END

UPDATE Accounts
   SET Balance += @moneyAmount
 WHERE Id = @accountId
COMMIT
GO

EXEC usp_DepositMoney 1, 10
GO

SELECT *
  FROM Accounts
 WHERE Id = 1
 GO

/****** Problem 17. Withdraw Money Procedure ******/
----------------------------------------------------
CREATE PROCEDURE usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15, 4)
AS
BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
	DECLARE @accountBalance DECIMAL(15, 4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)
	IF(@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account Id!', 16, 2)
		RETURN
	END

	IF(@moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Amount can not be negative number!', 16, 2)
		RETURN
	END

	IF((@accountBalance - @moneyAmount) < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Isufficient funds!', 16, 1)
		RETURN
	END

UPDATE Accounts
   SET Balance -= @moneyAmount
 WHERE Id = @accountId
COMMIT
GO

EXEC usp_WithdrawMoney 5, 25
GO

SELECT *
  FROM Accounts
 WHERE Id = 5
GO

/****** Problem 18. Money Transfer ******/
------------------------------------------
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	EXEC usp_WithdrawMoney @senderId, @amount
	EXEC usp_DepositMoney @receiverId, @amount
COMMIT
GO

EXEC usp_TransferMoney 5, 1, 5000
GO

SELECT *
  FROM Accounts

SELECT *
  FROM Logs

SELECT *
  FROM NotificationEmails