CREATE TABLE Students
(
	[StudentID]	INT IDENTITY PRIMARY KEY
	,[Name]		NVARCHAR(50) NOT NULL
)

INSERT INTO Students([Name])
	VALUES	('Mila')
			,('Toni')
			,('Ron')

SELECT *
	FROM Students

CREATE TABLE Exams
(
	[ExamID]	INT IDENTITY(101, 1) PRIMARY KEY
	,[Name]		NVARCHAR(50) NOT NULL
)

INSERT INTO Exams([Name])
	VALUES	('SpringMVC')
			,('Neo4j')
			,('Oracle 11g')

SELECT *
	FROM Exams

CREATE TABLE StudentsExams
(
	[StudentID]								INT
	,[ExamID]								INT
	,CONSTRAINT	PK_StudentsExams			PRIMARY KEY([StudentID], [ExamID])
	,CONSTRAINT	FK_StudentsExams_Students	FOREIGN KEY([StudentID])	REFERENCES Students([StudentID])
	,CONSTRAINT	FK_StudentsExams_Exams		FOREIGN KEY([ExamID])		REFERENCES Exams([ExamID])
)

/*
CREATE TABLE StudentsExams
(
	[StudentID]	INT REFERENCES Students([StudentID])
	,[ExamID]	INT REFERENCES Exams([ExamID])
	,PRIMARY KEY([StudentID], [ExamID])		
)
*/

INSERT INTO StudentsExams([StudentID], [ExamID])
	VALUES	(1, 101)
			,(1, 102)
			,(2, 101)
			,(3, 103)
			,(2, 102)
			,(2, 103)

SELECT s.[Name] AS StudentName, e.[Name] AS Exam
	FROM StudentsExams AS se
	JOIN Students AS s ON s.StudentID = se.StudentID
	JOIN Exams AS e ON e.ExamID = se.ExamID