-- 01. Create Database
CREATE DATABASE [Minions]
			USE [Minions]

-- 02. Create Tables
CREATE TABLE [Minions] (
	[Id]	INT		PRIMARY KEY,
	[Name]	VARCHAR(50),
	[Age]	INT
)

CREATE TABLE [Towns] (
	[Id]	INT PRIMARY KEY,
	[Name]	VARCHAR(50)
)

-- 03. Alter Minions Table
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])

-- 04. Insert Records in Both Tables
INSERT	INTO [Towns] 
        ([Id], [Name])
		VALUES
		(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

INSERT	INTO [Minions] ([Id], [Name], [Age], [TownId])
		VALUES
		(1, 'Kevin',	22,		1),
		(2, 'Bob',		15,		3),
		(3, 'Steward',	NULL,	2)

-- 05. Truncate Table Minions
TRUNCATE TABLE [Minions]

-- 06. Drop All Tables
DROP TABLE [Minions]
DROP TABLE [Towns]

-- 07. Create Table People
CREATE TABLE [People] (
	[Id]				INT PRIMARY		KEY IDENTITY,
	[Username]			VARCHAR(30)		UNIQUE NOT NULL,
	[Password]			VARCHAR(26)		NOT NULL,
	[ProfilePicture]	VARBINARY(MAX),
	[LastLoginTime]		DATETIME2,
	[IsDeleted]			BIT
)

INSERT  INTO [People]
        ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
        VALUES
        ('john_doe',		'Jd2024SecurePass01',	NULL, '2026-05-10 14:23:11',	0),
        ('maria_smith',		'Maria#77821Pass',		NULL, '2026-05-12 09:15:44',	0),
        ('alex_ivanov',		'AlexPwd998877',		NULL, '2026-05-14 20:41:03',	0),
        ('emma_wilson',		'EmmaSecure4455',		NULL, '2026-05-15 08:05:27',	0),
        ('nikolay_petrov',	'NikPetrov2026Pwd',		NULL, NULL,						0);

-- 08. Create Table Users
CREATE TABLE [Users] (
	[Id]				BIGINT				PRIMARY KEY IDENTITY,
	[Username]			VARCHAR(30)			UNIQUE NOT NULL,
	[Password]			VARCHAR(26)			NOT NULL,
	[ProfilePicture]	VARBINARY(MAX),
	[LastLoginTime]		DATETIME2,
	[IsDeleted]			BIT,

	CHECK(LEN([ProfilePicture]) <= 921600) -- Image with size up to 900 KB.
)

INSERT  INTO [Users]
        ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
        VALUES
        ('john_doe',		'Jd2024SecurePass01',	NULL, '2026-05-10 14:23:11',	0),
        ('maria_smith',		'Maria#77821Pass',		NULL, '2026-05-12 09:15:44',	0),
        ('alex_ivanov',		'AlexPwd998877',		NULL, '2026-05-14 20:41:03',	0),
        ('emma_wilson',		'EmmaSecure4455',		NULL, '2026-05-15 08:05:27',	0),
        ('nikolay_petrov',	'NikPetrov2026Pwd',		NULL, NULL,						0);

-- 09. Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC07815DEA70]

ALTER TABLE [Users]
ADD PRIMARY KEY([Id], [Username])

-- 10. Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT [C_Password_Min_Lenght] CHECK(LEN([Password]) >= 5)

-- 11. Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT(GETDATE()) FOR [LastLoginTime]

-- 12. Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__7722245901FC39E3]

ALTER TABLE [Users]
ADD PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [C_Username_Min_Lenght] CHECK(LEN([Username]) >= 3)

-- 13. Movies Database
CREATE DATABASE [Movies]
			USE [Movies]

CREATE TABLE [Directors] (
	[Id]			INT				PRIMARY KEY IDENTITY,
	[DirectorName]	VARCHAR(50)		NOT NULL,
	[Notes]			VARCHAR(500)
)

CREATE TABLE [Genres] (
	[Id]		INT				PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(50)		NOT NULL,
	[Notes]		VARCHAR(500)
)

CREATE TABLE [Categories] (
	[Id]			INT				PRIMARY	KEY IDENTITY,
	[CategoryName]	VARCHAR(50)		NOT NULL,
	[Notes]			VARCHAR(500)
)

CREATE TABLE [Movies] (
	[Id]				INT				PRIMARY KEY IDENTITY,
	[Title]				VARCHAR(100)	NOT NULL,
	[DirectorId]		INT				FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear]		INT				NOT NULL,
	[Length]			INT				NOT NULL,
	[GenreId]			INT				FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId]		INT				FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating]			VARCHAR(20),
	[Notes]				VARCHAR(500)
)

INSERT  INTO [Directors] 
        ([DirectorName], [Notes]) 
        VALUES
        ('Christopher Nolan',	 'Known for complex storytelling'),
        ('Steven Spielberg',	 'Famous blockbuster director'),
        ('Quentin Tarantino',	 'Stylized dialogue and violence'),
        ('Greta Gerwig',		 'Modern character-driven films'),
        ('James Cameron',		 NULL);

INSERT  INTO [Genres] 
        ([GenreName], [Notes]) 
        VALUES
        ('Sci-Fi',		'Science fiction films'),
        ('Action',		'High energy and combat-focused'),
        ('Drama',		'Character-driven storytelling'),
        ('Thriller',	'Suspense and tension'),
        ('Adventure',	'Exploration and journey-based films');

INSERT  INTO [Categories] 
        ([CategoryName], [Notes]) 
        VALUES
        ('Blockbuster',		'High budget mainstream movies'),
        ('Indie',			'Independent productions'),
        ('Classic',			'Older influential films'),
        ('Family',			'Suitable for all ages'),
        ('Oscar-Worthy',	NULL);

INSERT  INTO [Movies] 
        ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
        VALUES
        ('Inception',		1, 2010, 148, 1, 1, 'PG-13',    'Dream infiltration concept'),
        ('Jurassic Park',	2, 1993, 127, 5, 1, 'PG-13',    'Dinosaurs brought to life'),
        ('Pulp Fiction',	3, 1994, 154, 4, 3, 'R',        'Non-linear storytelling'),
        ('Little Women',	4, 2019, 135, 3, 2, 'PG',       'Family drama adaptation'),
        ('Avatar',			5, 2009, 162, 1, 1, 'PG-13',    'Pandora alien world');

-- 14. Car Rental Database
CREATE DATABASE [CarRental]
			USE [CarRental]

CREATE TABLE [Categories] (
	[Id]			INT			        PRIMARY KEY IDENTITY,
	[CategoryName]	VARCHAR(50)         NOT NULL,
	[DailyRate]		DECIMAL(10, 2)		NOT NULL,
	[WeeklyRate]	DECIMAL(10, 2)		NOT NULL,
	[MonthlyRate]	DECIMAL(10, 2)		NOT NULL,
	[WeekendRate]	DECIMAL(10, 2)		NOT NULL
)

CREATE TABLE [Cars] (
    [Id]			INT				PRIMARY KEY IDENTITY,
    [PlateNumber]	VARCHAR(20)		NOT NULL,
    [Manufacturer]	VARCHAR(50)		NOT NULL,
    [Model]			VARCHAR(50)		NOT NULL,
    [CarYear]		INT				NOT NULL,
    [CategoryId]	INT				FOREIGN KEY REFERENCES [Categories]([Id]),
    [Doors]			INT				NOT NULL,
    [Picture]		VARBINARY(MAX),
    [Condition]		VARCHAR(50)		NOT NULL,
    [Available]		BIT				NOT NULL,
)

CREATE TABLE [Employees] (
    [Id]		INT			PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(50)	NOT NULL,
    [LastName]	VARCHAR(50)	NOT NULL,
    [Title]		VARCHAR(50)	NOT NULL,
    [Notes]		VARCHAR(500)
)

CREATE TABLE [Customers] (
    [Id]					INT				PRIMARY KEY IDENTITY,
    [DriverLicenceNumber]	VARCHAR(50)		NOT NULL,
    [FullName]				VARCHAR(50)		NOT NULL,
    [Address]				VARCHAR(100)	NOT NULL,
    [City]					VARCHAR(100)	NOT NULL,
    [ZIPCode]				VARCHAR(20)		NOT NULL,
    [Notes]					VARCHAR(500)
)

CREATE TABLE [RentalOrders] (
    [Id]				INT				PRIMARY KEY IDENTITY,
    [EmployeeId]		INT				FOREIGN KEY REFERENCES  [Employees]([Id]),
    [CustomerId]		INT				FOREIGN KEY REFERENCES  [Customers]([Id]),
    [CarId]				INT				FOREIGN KEY REFERENCES	[Cars]([Id]),
    [TankLevel]			DECIMAL(10, 2)	NOT NULL,
    [KilometrageStart]	INT				NOT NULL,
    [KilometrageEnd]	INT,
    [TotalKilometrage]	INT,
    [StartDate]			DATETIME		NOT NULL,
    [EndDate]			DATETIME,
    [TotalDays]			INT,
    [RateApplied]		DECIMAL(10, 2)	NOT NULL,
    [TaxRate]			DECIMAL(10, 2)	NOT NULL,
    [OrderStatus]		VARCHAR(50)	    NOT NULL,
    [Notes]				VARCHAR(500),
)

INSERT  INTO [Categories]
        ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
        VALUES
        ('Economy', 30.00, 180.00, 700.00, 50.00),
        ('SUV', 60.00, 350.00, 1300.00, 90.00),
        ('Luxury', 120.00, 700.00, 2500.00, 180.00)

INSERT  INTO [Cars]
        ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Available])
        VALUES
        ('CA1234AB', 'Toyota',      'Corolla',  2020, 1, 4, NULL, 'Excellent', 1),
        ('CB5678CD', 'BMW',         'X5',       2022, 2, 4, NULL, 'Very Good', 1),
        ('CC9012EF', 'Mercedes',    'S-Class',  2023, 3, 4, NULL, 'Excellent', 0)

INSERT  INTO [Employees]
        ([FirstName], [LastName], [Title], [Notes])
        VALUES
        ('Ivan',    'Petrov',   'Manager',      'Handles premium customers'),
        ('Maria',   'Ivanova',  'Sales Agent',  'Works morning shifts'),
        ('Georgi',  'Dimitrov', 'Support',      'Responsible for vehicle inspections')

INSERT  INTO [Customers]
        ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode], [Notes])
        VALUES
        ('DL123456', 'Nikolay Georgiev',    '15 Vitosha Blvd',  'Sofia',    '1000', 'Frequent customer'),
        ('DL654321', 'Elena Petrova',       '22 Shipka Str',    'Plovdiv',  '4000', NULL),
        ('DL777888', 'Dimitar Kolev',       '7 Rakovski Str',   'Varna',    '9000', 'Requested GPS included')

INSERT INTO [RentalOrders]
([EmployeeId], [CustomerId], [CarId], [TankLevel],
[KilometrageStart], [KilometrageEnd], [TotalKilometrage],
[StartDate], [EndDate], [TotalDays],
[RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
    (1, 1, 1, 100, 15000, 15200, 200,
     '2026-05-01', '2026-05-05', 4,
     30.00, 20.00, 'Completed', 'Returned on time'),

    (2, 2, 2, 80, 22000, NULL, NULL,
     '2026-05-10', NULL, NULL,
     60.00, 20.00, 'Active', 'Customer extended rental'),

    (3, 3, 3, 90, 5000, 5400, 400,
     '2026-04-15', '2026-04-20', 5,
     120.00, 20.00, 'Completed', 'Minor scratch reported')

-- 15. Hotel Database
CREATE DATABASE [Hotel]
            USE [Hotel]

CREATE TABLE [Employees] (
    [Id]            INT             PRIMARY KEY IDENTITY,
    [FirstName]     VARCHAR(50)     NOT NULL,
    [LastName]      VARCHAR(50)     NOT NULL,
    [Title]         VARCHAR(50),
    [Notes]         VARCHAR(500)
)

CREATE TABLE [Customers] (
    [AccountNumber]     INT            PRIMARY KEY IDENTITY,
    [FirstName]         VARCHAR(50)    NOT NULL,
    [LastName]          VARCHAR(50)    NOT NULL,
    [PhoneNumber]       VARCHAR(30),
    [EmergencyName]     VARCHAR(50),
    [EmergencyNumber]   VARCHAR(30),
    [Notes]             VARCHAR(500)
)

CREATE TABLE [RoomStatus] (
    [RoomStatus]    VARCHAR(50) PRIMARY KEY,
    [Notes]         VARCHAR(500)
)

CREATE TABLE [RoomTypes] (
    [RoomType]  VARCHAR(50) PRIMARY KEY,
    [Notes]     VARCHAR(500)
)

CREATE TABLE [BedTypes] (
    [BedType]   VARCHAR(50) PRIMARY KEY,
    [Notes]     VARCHAR(500)
)

CREATE TABLE [Rooms] (
    [RoomNumber]    INT             PRIMARY KEY,
    [RoomType]      VARCHAR(50)     FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
    [BedType]       VARCHAR(50)     FOREIGN KEY REFERENCES [BedTypes]([BedType]),
    [Rate]          DECIMAL(10, 2)  NOT NULL,
    [RoomStatus]    VARCHAR(50)     FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
    [Notes]         VARCHAR(500),
)

CREATE TABLE [Payments] (
    [Id]                    INT                 PRIMARY KEY IDENTITY,
    [EmployeeId]            INT                 FOREIGN KEY REFERENCES [Employees]([Id]),
    [PaymentDate]           DATETIME,
    [AccountNumber]         INT                 FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
    [FirstDateOccupied]     DATETIME            NOT NULL,
    [LastDateOccupied]      DATETIME            NOT NULL,
    [TotalDays]             INT                 NOT NULL,
    [AmountCharged]         DECIMAL(10, 2)      NOT NULL,
    [TaxRate]               DECIMAL(10, 2)      NOT NULL,
    [TaxAmount]             DECIMAL(10, 2)      NOT NULL,
    [PaymentTotal]          DECIMAL(10, 2)      NOT NULL,
    [Notes]                 VARCHAR(500),
)

CREATE TABLE [Occupancies] (
    [Id]                INT             PRIMARY KEY IDENTITY,
    [EmployeeId]        INT             FOREIGN KEY REFERENCES [Employees]([Id]),
    [DateOccupied]      DATETIME        NOT NULL,
    [AccountNumber]     INT             FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
    [RoomNumber]        INT             FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
    [RateApplied]       DECIMAL(10, 2)  NOT NULL,
    [PhoneCharge]       DECIMAL(10, 2)  NOT NULL,
    [Notes]             VARCHAR(500),
)

INSERT  INTO 
        [Employees] ([FirstName], [LastName], [Title], [Notes])
        VALUES
        ('John',    'Smith',    'Manager',      'Handles front desk operations'),
        ('Anna',    'Johnson',  'Receptionist', 'Works night shifts'),
        ('Peter',   'Brown',    'Accountant',   'Manages billing and payroll');

INSERT  INTO
        [Customers] ([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
        VALUES
        ('Michael', 'Davis', '0888123456', 'Laura Davis',   '0888765432',   'VIP customer'),
        ('Emily',   'Clark', '0888234567', 'Robert Clark',  '0888876543',   NULL),
        ('Daniel',  'Lewis', '0888345678', 'Sarah Lewis',   '0888987654',   'Prefers quiet rooms');

INSERT  INTO 
        [RoomStatus] ([RoomStatus], [Notes])
        VALUES
        ('Available',   'Room is ready for booking'),
        ('Occupied',    'Guest currently staying'),
        ('Maintenance', 'Room under maintenance');

INSERT  INTO 
        [RoomTypes] ([RoomType], [Notes])
        VALUES
        ('Single',  'Room for one person'),
        ('Double',  'Room for two people'),
        ('Suite',   'Luxury room with extra space');

INSERT  INTO 
        [BedTypes] ([BedType], [Notes])
        VALUES
        ('Single Bed',  'One-person bed'),
        ('Double Bed',  'Two-person bed'),
        ('King Bed',    'Large luxury bed');

INSERT  INTO 
        [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
        VALUES
        (101, 'Single', 'Single Bed',   80.00,  'Available',    'Near elevator'),
        (202, 'Double', 'Double Bed',   120.00, 'Occupied',     'Sea view room'),
        (303, 'Suite',  'King Bed',     250.00, 'Maintenance',  'Renovation in progress');

INSERT  INTO 
        [Payments] ([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied],
        [TotalDays], [AmountCharged], [TaxRate], [TaxAmount], [PaymentTotal], [Notes])
        VALUES
        (1, '2026-05-10', 1, '2026-05-01', '2026-05-05', 4, 400.00, 0.20, 80.00,    480.00, 'Paid in cash'),
        (2, '2026-05-12', 2, '2026-05-03', '2026-05-06', 3, 300.00, 0.20, 60.00,    360.00, 'Paid by card'),
        (3, '2026-05-15', 3, '2026-05-07', '2026-05-10', 3, 600.00, 0.20, 120.00,   720.00, 'Includes discount');

INSERT  INTO 
        [Occupancies] ([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge], [Notes])
        VALUES
        (1, '2026-05-01', 1, 101, 80.00, 10.00, 'No issues'),
        (2, '2026-05-03', 2, 202, 120.00, 15.00, 'Requested extra towels'),
        (3, '2026-05-07', 3, 303, 250.00, 25.00, 'VIP guest');

-- 16. Create SoftUni Database
CREATE DATABASE [SoftUni]
            USE [SoftUni]

CREATE TABLE [Towns] (
    [Id]    INT             PRIMARY KEY IDENTITY,
    [Name]  VARCHAR(100)    NOT NULL
)

CREATE TABLE [Addresses] (
    [Id]            INT             PRIMARY KEY IDENTITY,
    [AddressText]   VARCHAR(100)    NOT NULL,
    [TownId]        INT             FOREIGN KEY REFERENCES [Towns]([Id])
)

CREATE TABLE [Departments] (
    [Id]    INT             PRIMARY KEY IDENTITY,
    [Name]  VARCHAR(50)     NOT NULL
)

CREATE TABLE [Employees] (
    [Id]            INT             PRIMARY KEY IDENTITY,
    [FirstName]     VARCHAR(50)     NOT NULL,
    [MiddleName]    VARCHAR(50),
    [LastName]      VARCHAR(50)     NOT NULL,
    [JobTitle]      VARCHAR(50)     NOT NULL,
    [DepartmentId]  INT             FOREIGN KEY REFERENCES [Departments]([Id]),
    [HireDate]      DATE            NOT NULL,
    [Salary]        DECIMAL(10, 2)  NOT NULL,
    [AddressId]     INT             FOREIGN KEY REFERENCES [Addresses]([Id])
)

-- 17. Backup Database
-- 18. Basic Insert

INSERT  INTO [Towns]
        ([Name])
        VALUES
        ('Sofia'),
        ('Plovdiv'),
        ('Varna'),
        ('Burgas')

INSERT  INTO [Departments] 
        ([Name])
        VALUES
        ('Engineering'),
        ('Sales'),
        ('Marketing'),
        ('Software Development'),
        ('Quality Assurance') 

INSERT  INTO [Employees]
        ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
        VALUES
        ('Ivan',    'Ivanov',   'Ivanov',   '.NET Developer',   4, '2013-02-01', 3500.00),
        ('Petar',   'Petrov',   'Petrov',   'Senior Engineer',  1, '2004-03-02', 4000.00),
        ('Maria',   'Petrova',  'Ivanova',  'Intern',           5, '2016-08-28', 525.25),
        ('Georgi',  'Teziev',   'Ivanov',   'CEO',              2, '2007-12-09', 3000.00),
        ('Peter',   'Pan',      'Pan',      'Intern',           3, '2016-08-28', 599.88)

-- 19. Basic Select All Fields
SELECT * 
  FROM [Towns]

SELECT * 
  FROM [Departments]

SELECT * 
  FROM [Employees]

-- 20. Basic Select All Fields and Order Them
  SELECT * 
    FROM [Towns]
ORDER BY [Name] ASC

  SELECT * 
    FROM [Departments]
ORDER BY [Name] ASC

  SELECT * 
    FROM [Employees]
ORDER BY [Salary] DESC

-- 21. Basic Select Some Fields
  SELECT [Name]
    FROM [Towns]
ORDER BY [Name] ASC

  SELECT [Name] 
    FROM [Departments]
ORDER BY [Name] ASC

  SELECT [FirstName], [LastName], [JobTitle], [Salary]
    FROM [Employees]
ORDER BY [Salary] DESC

-- 22. Increase Employees Salary
UPDATE [Employees]
   SET [Salary] *= 1.10

  SELECT [Salary]
    FROM [Employees]

-- 23. Decrease Tax Rate
USE [Hotel]

UPDATE [Payments]
   SET [TaxRate] *= 0.97

SELECT [TaxRate]
  FROM [Payments]

-- 24. Delete All Records
TRUNCATE TABLE [Occupancies]