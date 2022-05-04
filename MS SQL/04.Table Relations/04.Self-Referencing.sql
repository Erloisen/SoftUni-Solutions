CREATE TABLE Teachers
(
	[TeacherID]		INT IDENTITY(101,1) PRIMARY KEY
	,[Name]			NVARCHAR(100) NOT NULL UNIQUE
	,[ManagerID]	INT REFERENCES Teachers([TeacherID])
)

INSERT INTO Teachers([Name], [ManagerID])
	VALUES	('John', NULL)
			,('Maya', 106)
			,('Silvia', 106)
			,('Ted', 105)
			,('Mark', 101)
			,('Greta', 101)

SELECT *
	FROM Teachers