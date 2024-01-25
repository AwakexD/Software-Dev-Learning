-- Problem 1.	One-To-One Relationship

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(10, 2),
	PassportID INT REFERENCES Passports(PassportID) UNIQUE 
	--CONSTRAINT FK_Persons_Passports 
	--FOREIGN KEY (PassportID) 
	--REFERENCES Passports(PassportID)
)

CREATE TABLE Passports
(
	PassportID INT IDENTITY(101, 1) PRIMARY KEY,
	PassportNumber CHAR(8) NOT NULL
)

INSERT INTO Passports(PassportNumber) 
VALUES 
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

-- Problem 2.	One-To-Many Relationship

CREATE TABLE Models
(
	ModelID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(60) NOT NULL,
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID),
)

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	EstablishedOn DATE DEFAULT GETDATE(),
)

INSERT INTO Manufacturers (Name, EstablishedOn) 
VALUES	
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models(Name, ManufacturerID) VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 3),
	('Nova', 3)


-- Problem 3.	Many-To-Many Relationship

CREATE TABLE Students 
(
	StudentID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(30) NOT NULL,
)

CREATE TABLE Exams 
(
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(30) NOT NULL,
)
CREATE TABLE StudentsExams 
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID),
	CONSTRAINT PK_StudentExams
		PRIMARY KEY (StudentID, ExamID) 
)


INSERT INTO Students(Name)
VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams(Name)
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES
	(1,101),
	(1,102),
	(2,101),
	(2,103),
	(3,102),
	(3,103)


-- Problem 4.	Self-Referencing 

CREATE TABLE Teachers 
(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(30),
	ManagerID INT,
	FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (Name, ManagerID)
VALUES
    ('John', NULL),
    ('Maya', 106),
    ('Silvia', 106),
    ('Ted', 105),
    ('Mark', 101),
    ('Greta', 101);


-- Problem 5.	Online Store Database 

CREATE DATABASE OnlineStore;
GO

USE OnlineStore;

CREATE TABLE ItemTypes
(
	ItemTypeID INT IDENTITY(101, 1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderID INT IDENTITY(1001, 1) PRIMARY KEY,
	ItemID INT REFERENCES Items(ItemID) NOT NULL,
)

CREATE TABLE Cities
(
	CityID INT IDENTITY(101, 1) PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT REFERENCES OrderItems(OrderID) PRIMARY KEY,
	CustomerID INT REFERENCES Customers(CustomerID)
)

-- Problem 6.	University Database
CREATE DATABASE University;
GO

USE University;

CREATE TABLE Majors
(
	MajorID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber INT UNIQUE NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT IDENTITY(1001, 1) PRIMARY KEY,
	PaymentDate DATE DEFAULT GETDATE(),
	PaymentAmount DECIMAL(10, 2)  NOT NULL, 
	StudentID INT REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT IDENTITY(101, 1) PRIMARY KEY,
	SubjectName VARCHAR(255) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID)
	CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)

-- Problem 9.	Peaks in Rila

USE Geography;

SELECT 
	MountainRange, 
	PeakName, 
	Elevation 
FROM Peaks
	JOIN Mountains ON Peaks.MountainId = Mountains.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC

