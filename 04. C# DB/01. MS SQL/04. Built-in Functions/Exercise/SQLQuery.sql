-- Part I – Queries for SoftUni Database

-- 01. Find Names of All Employees by First Name
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'SA%'

 -- 02. Find Names of All Employees by Last Name
 SELECT [FirstName],
	    [LastName]
   FROM [Employees]
  WHERE [LastName] LIKE '%EI%'

-- 03. Find First Names of All Employees
SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10) 
   AND [HireDate] BETWEEN '1995-01-01' AND '2005-12-31'

-- 04. Find All Employees Except Engineers
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE [JobTitle] NOT LIKE '%ENGINEER%'

-- 05. Find Towns with Name Length
  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC

-- 06. Find Towns Starting With
  SELECT [TownID],
		 [Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

-- 07. Find Towns Not Starting With
  SELECT [TownID],[Name]
    FROM [Towns]
   WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

-- 08. Create View Employees Hired After 2000 Year
CREATE VIEW [V_EmployeesHiredAfter2000] AS (
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [HireDate] >= '2001'
)

-- 09. Length of Last Name
SELECT [FirstName],
	   [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

 -- 10. Rank Employees by Salary
  SELECT [EmployeeID],
		 [FirstName],
		 [LastName],
		 [Salary],
		 DENSE_RANK() OVER
		 (PARTITION BY [Salary] ORDER BY [EmployeeID] ASC) AS [Rank]
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

-- * 11. Find All Employees with Rank 2
SELECT * 
FROM (
	  SELECT [EmployeeID],
			 [FirstName],
			 [LastName],
			 [Salary],
			 DENSE_RANK() OVER
			 (PARTITION BY [Salary] ORDER BY [EmployeeID] ASC) AS [Rank]
		FROM [Employees]
	   WHERE [Salary] BETWEEN 10000 AND 50000	
) AS RankedEmployees
WHERE [Rank] = 2
ORDER BY [Salary] DESC

-- Part II – Queries for Geography Database

-- 12. Countries Holding 'A' 3 or More Times
  SELECT [CountryName], 
		 [IsoCode]
    FROM [Countries]
   WHERE LEN([CountryName]) - LEN(REPLACE([CountryName], 'A', '')) >= 3
ORDER BY [IsoCode] ASC

-- 13. Mix of Peak and River Names
   SELECT [p].[PeakName],
   	      [r].[RiverName],
   	      LOWER(
			CONCAT([p].[PeakName],
				SUBSTRING([r].[RiverName], 2, LEN([r].[RiverName]))
				)
		  ) AS [Mix]
     FROM [Peaks] AS [p], [Rivers] AS [r]
    WHERE RIGHT([p].[PeakName], 1) = LEFT( [r].[RiverName], 1)
 ORDER BY [Mix]

-- Part III – Queries for Diablo Database

-- 14. Games from 2011 and 2012 Year
  SELECT TOP(50)
  	     [Name],
		 FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM [Games]
   WHERE YEAR([Start]) IN ('2011', '2012')
ORDER BY [Start] ASC

-- 15. User Email Providers
  SELECT [Username],
		 SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider],
		 [Username]

-- 16. Get Users with IP Address Like Pattern
SELECT [Username],[IpAddress]
FROM [Users]
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

-- 17. Show All Games with Duration and Part of the Day
SELECT [Name],
	   CASE
			WHEN DATEPART(hour, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
			WHEN DATEPART(hour, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
			WHEN DATEPART(hour, [Start]) BETWEEN 18 AND 24 THEN 'Evening'
	   END AS [Part of the Day],
	   CASE
			WHEN [Duration] <= 3 THEN 'Extra Short'
			WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			WHEN [Duration] IS NULL THEN 'Extra Long'
	   END AS [Duration]
FROM [Games]
ORDER BY [Name] ASC,
		 [Duration] ASC,
		 [Part of the Day] ASC

-- Part IV – Date Functions Queries

-- 18. Orders Table
SELECT [ProductName],
	   [OrderDate],
	   DATEADD(day, 3, [OrderDate]) AS [Pay Due],
	   DATEADD(month, 1, [OrderDate]) AS [Deliver Due]
  FROM [Orders]

-- 19. People Table
CREATE DATABASE [PersonData]
			USE [PersonData]

CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATE NOT NULL
)

INSERT INTO [People] ([Name], [Birthdate])
VALUES
('John Smith', '1990-05-14'),
('Emily Johnson', '1985-11-23'),
('Michael Brown', '1992-07-08'),
('Sarah Davis', '1998-03-19'),
('David Wilson', '1979-12-02'),
('Laura Martinez', '2000-06-30'),
('James Anderson', '1988-09-15'),
('Olivia Taylor', '1995-01-27'),
('Daniel Thomas', '1983-04-11'),
('Sophia White', '2001-10-05')

SELECT [Name],
	   [Birthdate],
	   DATEDIFF(year, [Birthdate], GETDATE()) AS [Age in Years],
	   DATEDIFF(month, [Birthdate], GETDATE()) AS [Age in Months],
	   DATEDIFF(day, [Birthdate], GETDATE()) AS [Age in Days],
	   DATEDIFF(minute, [Birthdate], GETDATE()) AS [Age in Minutes]
  FROM [People]
