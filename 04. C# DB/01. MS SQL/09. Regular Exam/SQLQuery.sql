CREATE DATABASE [EuroLeagues]
USE [EuroLeagues]
 
-- 01
CREATE TABLE [Leagues] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Players] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Position] NVARCHAR(20) NOT NULL
)

CREATE TABLE [PlayerStats] (
	[PlayerId] INT FOREIGN KEY REFERENCES [Players]([Id]),
	[Goals] INT DEFAULT 0 NOT NULL,
	[Assists] INT DEFAULT 0 NOT NULL,
	PRIMARY KEY ([PlayerId])
)

CREATE TABLE [Teams] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	[City] NVARCHAR(50) NOT NULL,
	[LeagueId] INT FOREIGN KEY REFERENCES [Leagues]([Id]) NOT NULL
)

CREATE TABLE [TeamStats] (
	[TeamId] INT FOREIGN KEY REFERENCES [Teams]([Id]),
	[Wins] INT DEFAULT 0 NOT NULL,
	[Draws] INT DEFAULT 0 NOT NULL,
	[Losses] INT DEFAULT 0 NOT NULL,
	PRIMARY KEY ([TeamId])
)

CREATE TABLE [PlayersTeams] (
	[PlayerId] INT FOREIGN KEY REFERENCES [Players]([Id]),
	[TeamId] INT FOREIGN KEY REFERENCES [Teams]([Id]),
	PRIMARY KEY ([PlayerId], [TeamId])
)

CREATE TABLE [Matches] (
	[Id] INT PRIMARY KEY IDENTITY,
	[HomeTeamId] INT FOREIGN KEY REFERENCES [Teams]([Id]) NOT NULL,
	[AwayTeamId] INT FOREIGN KEY REFERENCES [Teams]([Id]) NOT NULL,
	[MatchDate] DATETIME2 NOT NULL,
	[HomeTeamGoals] INT DEFAULT 0 NOT NULL,
	[AwayTeamGoals] INT DEFAULT 0 NOT NULL,
	[LeagueId] INT FOREIGN KEY REFERENCES [Leagues]([Id]) NOT NULL
)

-- 02
INSERT INTO [Leagues] ([Name])
VALUES ('Eredivisie')

INSERT INTO [Teams] ([Name], [City], [LeagueId])
VALUES 
('PSV', 'Eindhoven', 6),
('Ajax', 'Amsterdam', 6)

INSERT INTO [Players] ([Name], [Position])
VALUES 
('Luuk de Jong', 'Forward'),
('Josip Sutalo', 'Defender')

INSERT INTO [Matches] ([HomeTeamId], [AwayTeamId], [MatchDate], [HomeTeamGoals], [AwayTeamGoals], [LeagueId])
VALUES (98, 97, '2024-11-02 20:45:00', 3, 2, 6)

INSERT INTO [PlayersTeams] ([PlayerId], [TeamId])
VALUES 
(2305, 97),
(2306, 98)

INSERT INTO [PlayerStats] ([PlayerId], [Goals], [Assists])
VALUES 
(2305, 2, 0),
(2306, 2, 0)

INSERT INTO [TeamStats] ([TeamId], [Wins], [Draws], [Losses])
VALUES 
(97, 15, 1, 3),
(98, 14, 3, 2)

-- 03
UPDATE [ps]
   SET [ps].[Goals] = [Goals] + 1
  FROM [PlayersTeams] AS [pt]
  JOIN [Teams] AS [t] ON [pt].[TeamId] = [t].[Id]
  JOIN [Leagues] AS [l] ON [t].[LeagueId] = [l].[Id]
  JOIN [Players] AS [p] ON [pt].[PlayerId] = [p].[Id]
  JOIN [PlayerStats] AS [ps] ON [p].[Id] = [ps].[PlayerId]
 WHERE [l].[Name] = 'La Liga'
   AND [p].[Position] = 'Forward'

-- 04
DELETE [p]
  FROM [Players] AS [p]
  JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
  JOIN [Teams] AS [t] ON [pt].[TeamId] = [t].[Id]
 WHERE [t].[Name] = 'Eredivisie'

  DELETE [pt]
    FROM [Players] AS [p]
    JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
   WHERE [p].[Name] IN ('Luuk de Jong', 'Josip Sutalo')

  DELETE [ps]
    FROM [Players] AS [p]
    JOIN [PlayerStats]AS [ps] ON [ps].[PlayerId] = [p].[Id]
   WHERE [p].[Name] IN ('Luuk de Jong', 'Josip Sutalo')

 DELETE [p]
   FROM [Players] AS [p]
   JOIN [PlayersTeams] AS [pt] ON [pt].[PlayerId] = [p].[Id]
  WHERE [p].[Name] IN ('Luuk de Jong', 'Josip Sutalo')

-- 05
  SELECT *
	FROM (
		SELECT FORMAT([MatchDate], 'yyyy-MM-dd') AS [MatchDate],
			   [HomeTeamGoals],
			   [AwayTeamGoals],[HomeTeamGoals] + [AwayTeamGoals] AS [TotalGoals]
		  FROM [Matches]
) AS [MatchByTotalGoals]
   WHERE [TotalGoals] >= 5
ORDER BY [TotalGoals] DESC,
		 [MatchDate] ASC

-- 06
  SELECT [p].[Name],[t].[City]
	FROM [PlayersTeams] AS [pm]
	JOIN [Players] AS [p] ON [pm].[PlayerId] = [p].[Id]
	JOIN [Teams] AS [t] ON [pm].[TeamId] = [t].[Id]
   WHERE [PlayerId] IN (
		SELECT [Id]
		FROM [Players]
		WHERE [Name] LIKE '%Aaron%'
)
ORDER BY [p].[Name] ASC

-- 07
  SELECT [p].[Id],[p].[Name],[p].[Position]
	FROM [PlayersTeams] AS [pt]
	JOIN [Players] AS [p] ON [pt].[PlayerId] = [p].[Id]
	JOIN [Teams] AS [t] ON [pt].[TeamId] = [t].[Id]
   WHERE [t].[City] = 'London'
ORDER BY [p].[Name] ASC

-- 08
  SELECT TOP(10)
		 [ht].[Name] AS [HomeTeamName],
		 [at].[Name] AS [AwayTeamName],
		 [l].[Name] AS [LeagueName],
		 FORMAT([m].[MatchDate], 'yyyy-MM-dd') AS [MatchDate]
	FROM [Matches] AS [m]
	JOIN [Leagues] AS [l] ON [m].[LeagueId] = [l].[Id]
	JOIN [Teams] AS [ht] ON [m].[HomeTeamId] = [ht].[Id]
	JOIN [Teams] AS [at] ON [m].[AwayTeamId] = [at].[Id]
   WHERE [MatchDate] BETWEEN '09.01.2024' AND '09.15.2024'
	 AND [l].[Id] % 2 = 0
ORDER BY [m].[MatchDate] ASC,
		 [ht].[Name] ASC
		 
-- 09
  SELECT [GuestTeamsGrouped].[AwayTeamId],
		 [t].[Name],
		 [GuestTeamsGrouped].[TotalAwayGoals]
	FROM (
	  SELECT [AwayTeamId],
			 SUM([AwayTeamGoals]) AS [TotalAwayGoals]
		FROM [Matches]
	GROUP BY [AwayTeamId]
) AS [GuestTeamsGrouped]
	JOIN [Teams] AS [t] ON [GuestTeamsGrouped].[AwayTeamId] = [t].[Id]
   WHERE [GuestTeamsGrouped].[TotalAwayGoals] >= 6
ORDER BY [GuestTeamsGrouped].[TotalAwayGoals] DESC,
		 [t].[Name] ASC

-- 10
  SELECT [Name], ROUND(AVG([Total]), 2) AS [AvgScoringRate]
    FROM (
		SELECT CAST([HomeTeamGoals] AS FLOAT) + [AwayTeamGoals] AS [Total],[l].[Name]
		FROM [Matches] AS [m]
		JOIN [Leagues] AS [l] ON [m].[LeagueId] = [l].[Id]
) AS [TotalMatchGoals]
GROUP BY [Name]
ORDER BY [AvgScoringRate] DESC

-- 11
CREATE FUNCTION [udf_LeagueTopScorer](@leageName NVARCHAR(50))
RETURNS TABLE
AS
RETURN (
	SELECT [Name], [Goals]
	  FROM (
			SELECT [p].[Name],
					[ps].[Goals],
					DENSE_RANK() OVER (ORDER BY [ps].[Goals] DESC) AS [Rank]
			FROM [PlayersTeams] AS [pt]
			JOIN [Teams] AS [t] ON [pt].[TeamId] = [t].[Id]
			JOIN [Leagues] AS [l] ON [t].[LeagueId] = [l].[Id]
			JOIN [Players] AS [p] ON [pt].[PlayerId] = [p].[Id]
			JOIN [PlayerStats] AS [ps] ON [p].[Id] = [ps].[PlayerId]
			WHERE [l].[Name] = @leageName
	) AS [RankedPlayers]
	 WHERE [Rank] = 1
)

SELECT * FROM dbo.udf_LeagueTopScorer('Serie A')

-- 12
CREATE PROCEDURE [usp_UpdatePlayerStats]
	@PlayerId INT,
	@GoalsDelta INT = NULL,
	@AssistsDelta INT = NULL
AS
BEGIN
	IF NOT EXISTS (SELECT [PlayerId] FROM [PlayerStats] WHERE [PlayerId] = @PlayerId)
	BEGIN
		INSERT INTO [PlayerStats] ([PlayerId]) VALUES (@PlayerId)
	END

	UPDATE [PlayerStats]
	   SET [Goals] = [Goals] + ISNULL(@GoalsDelta, 0)
	 WHERE [PlayerId] = @PlayerId

	UPDATE [PlayerStats]
	   SET [Assists] = [Assists] + ISNULL(@AssistsDelta, 0)
	 WHERE [PlayerId] = @PlayerId
END