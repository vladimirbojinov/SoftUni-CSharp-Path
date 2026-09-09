-- Part I – Queries for SoftUni Database

-- 01. Employees with Salary Above 35000

CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [Salary] > 35000
END

EXEC [usp_GetEmployeesSalaryAbove35000]

-- 02. Employees with Salary Above Number
CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber]
	@minSalary DECIMAL(18, 4)
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE [Salary] >= @minSalary
END

EXEC [usp_GetEmployeesSalaryAboveNumber] 48100

-- 03. Town Names Starting With
CREATE PROCEDURE [usp_GetTownsStartingWith]
	@startString VARCHAR(50)
AS
BEGIN
	SELECT [Name]
	  FROM [Towns]
	 WHERE [Name] LIKE CONCAT(@startString, '%')
END

EXEC [usp_GetTownsStartingWith] 'b'

-- 04. Employees from Town
CREATE PROCEDURE [usp_GetEmployeesFromTown]
	@town VARCHAR(50)
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees] AS [e]
	  JOIN [Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
	  JOIN [Towns] AS [t] ON [a].[TownID] = [t].[TownID]
	 WHERE [t].[Name] = @town
END

EXEC [usp_GetEmployeesFromTown] 'SOFIA'

-- 05. Salary Level Function
CREATE FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(50)
AS
BEGIN
	IF (@salary < 30000) RETURN 'Low'
	ELSE IF (@salary BETWEEN 30000 AND 50000) RETURN 'Average'
	ELSE RETURN 'High'

	RETURN 'NA'
END

SELECT [dbo].[ufn_GetSalaryLevel](13500.00)
SELECT [dbo].[ufn_GetSalaryLevel](43300.00)
SELECT [dbo].[ufn_GetSalaryLevel](125500.00)

-- 06. Employees by Salary Level
CREATE PROCEDURE [usp_EmployeesBySalaryLevel]
	@salaryLevel VARCHAR(50)
AS
BEGIN
	SELECT [FirstName],
		   [LastName]
	  FROM [Employees]
	 WHERE @salaryLevel = [dbo].[ufn_GetSalaryLevel]([Salary])
END

EXEC [usp_EmployeesBySalaryLevel] 'HIGH'

-- 07. Define Function
CREATE FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1

	WHILE @index <= LEN(@word)
	BEGIN
		IF CHARINDEX(SUBSTRING(@word, @index, 1), @setOfLetters) = 0 RETURN 0
		SET @index += 1
	END

	RETURN 1
END

SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia')
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'halves')
SELECT [dbo].[ufn_IsWordComprised]('bobr', 'Rob')

-- 08. * Delete Employees and Departments
CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment]
	@departmentId INT
AS
BEGIN
	 ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT

	DECLARE @deleteEmployees TABLE ([EmployeeID] INT)

	INSERT INTO @deleteEmployees ([EmployeeID])
		 SELECT [EmployeeID]
		   FROM [Employees]
		  WHERE [DepartmentID] = @departmentId

	UPDATE [Employees]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN ( SELECT [EmployeeID] FROM @deleteEmployees)

	UPDATE [Departments]
	   SET [ManagerID] = NULL
	 WHERE [ManagerID] IN ( SELECT [EmployeeID] FROM @deleteEmployees)

	DELETE
	  FROM [EmployeesProjects]
	 WHERE [EmployeeID] IN ( SELECT [EmployeeID] FROM @deleteEmployees)

	DELETE
	  FROM [Employees]
	 WHERE [EmployeeID] IN ( SELECT [EmployeeID] FROM @deleteEmployees)

	DELETE
	  FROM [Departments]
	 WHERE [DepartmentID] = @departmentId

	SELECT COUNT(*)
	  FROM [Employees]
	 WHERE [DepartmentID] = @departmentId
END

EXEC [usp_DeleteEmployeesFromDepartment] 5

-- Part II – Queries for Bank Database

-- 09. Find Full Name
CREATE PROCEDURE [usp_GetHoldersFullName]
AS
BEGIN 
	SELECT CONCAT_WS(' ',[FirstName], [LastName]) AS [Full Name]
	  FROM [AccountHolders]
END

EXEC  [usp_GetHoldersFullName]

-- 10. People with Balance Higher Than
CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan]
	@money MONEY
AS
BEGIN
		SELECT [h].[FirstName],
		   [h].[LastName]
		  FROM (
				SELECT [AccountHolderId],
					   SUM([Balance]) AS [Total]
				  FROM [Accounts]
			  GROUP BY [AccountHolderId]
				HAVING SUM([Balance]) > @money
		  ) AS [GroupedAccountsBalance]
		  JOIN [AccountHolders] AS [h] ON [AccountHolderId] = [h].[Id]		
	  ORDER BY [FirstName] ASC, [LastName] ASC
END

EXEC [usp_GetHoldersWithBalanceHigherThan] 10000.00

-- 11. Future Value Function
CREATE FUNCTION [ufn_CalculateFutureValue] (@sum MONEY, @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
BEGIN
	-- FV = sum * ((1 + yearlyInterestRate)^years)
	RETURN CAST(@sum * POWER((1 + @yearlyInterestRate), @years) AS DECIMAL(18, 4))
END

SELECT [dbo].[ufn_CalculateFutureValue] (1000, 0.1, 5) AS [Output]

-- 12. Calculating Interest
CREATE PROCEDURE [usp_CalculateFutureValueForAccount]
	@id INT,
	@interestRate FLOAT
AS
BEGIN
	SELECT [h].[Id],[h].[FirstName],[h].[LastName],[a].[Balance],[dbo].[ufn_CalculateFutureValue] ([a].[Balance], @interestRate, 5) AS [Balance in 5 year]
	FROM [Accounts] AS [a]
	JOIN [AccountHolders] AS [h] ON [a].[Id] = [h].[Id]
	WHERE [h].[Id] = @id
END

EXEC [usp_CalculateFutureValueForAccount] 1, 0.1

-- Part III – Queries for Diablo Database

-- 13. * Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION [ufn_CashInUsersGames] (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    WITH [GamesRowedByCash] AS (
        SELECT [ug].[Cash], 
               ROW_NUMBER() OVER (PARTITION BY [ug].[GameId] ORDER BY [ug].[Cash]) AS [RowNumber]
          FROM [UsersGames] AS [ug]
          JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
         WHERE [g].[Name] = @gameName
    )

    SELECT SUM([Cash]) AS [SumCash]
      FROM [GamesRowedByCash]
     WHERE [RowNumber] % 2 != 1
)

SELECT [SumCash]
FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')