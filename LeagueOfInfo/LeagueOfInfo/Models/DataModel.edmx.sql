
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/14/2015 01:35:20
-- Generated from EDMX file: C:\Users\Thomas\Desktop\CS 296\Website\LeagueOfInfo\LeagueOfInfo\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LeagueTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_LeagueTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_TeamPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayerRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_PlayerRole];
GO
IF OBJECT_ID(N'[dbo].[FK_ChampionRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [FK_ChampionRole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Leagues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Leagues];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[Players]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Players];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Champions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Champions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Leagues'
CREATE TABLE [dbo].[Leagues] (
    [LeagueID] nvarchar(max)  NOT NULL,
    [LeagueName] nvarchar(max)  NOT NULL,
    [RegionName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [TeamID] nvarchar(max)  NOT NULL,
    [TeamName] nvarchar(max)  NOT NULL,
    [LeagueName] nvarchar(max)  NOT NULL,
    [LeagueTeam_Team_LeagueID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [PlayerID] nvarchar(max)  NOT NULL,
    [PlayerName] nvarchar(max)  NOT NULL,
    [TeamName] nvarchar(max)  NOT NULL,
    [LeagueName] nvarchar(max)  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [TeamPlayer_Player_TeamID] nvarchar(max)  NOT NULL,
    [PlayerRole_Player_RoleID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] nvarchar(max)  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [PrimaryAttribute] nvarchar(max)  NOT NULL,
    [ChampionRole_Role_ChampionID] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Champions'
CREATE TABLE [dbo].[Champions] (
    [ChampionID] nvarchar(max)  NOT NULL,
    [ChampionName] nvarchar(max)  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [PrimaryAttribute] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LeagueID] in table 'Leagues'
ALTER TABLE [dbo].[Leagues]
ADD CONSTRAINT [PK_Leagues]
    PRIMARY KEY CLUSTERED ([LeagueID] ASC);
GO

-- Creating primary key on [TeamID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([TeamID] ASC);
GO

-- Creating primary key on [PlayerID] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([PlayerID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [ChampionID] in table 'Champions'
ALTER TABLE [dbo].[Champions]
ADD CONSTRAINT [PK_Champions]
    PRIMARY KEY CLUSTERED ([ChampionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LeagueTeam_Team_LeagueID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_LeagueTeam]
    FOREIGN KEY ([LeagueTeam_Team_LeagueID])
    REFERENCES [dbo].[Leagues]
        ([LeagueID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LeagueTeam'
CREATE INDEX [IX_FK_LeagueTeam]
ON [dbo].[Teams]
    ([LeagueTeam_Team_LeagueID]);
GO

-- Creating foreign key on [TeamPlayer_Player_TeamID] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_TeamPlayer]
    FOREIGN KEY ([TeamPlayer_Player_TeamID])
    REFERENCES [dbo].[Teams]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayer'
CREATE INDEX [IX_FK_TeamPlayer]
ON [dbo].[Players]
    ([TeamPlayer_Player_TeamID]);
GO

-- Creating foreign key on [PlayerRole_Player_RoleID] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_PlayerRole]
    FOREIGN KEY ([PlayerRole_Player_RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerRole'
CREATE INDEX [IX_FK_PlayerRole]
ON [dbo].[Players]
    ([PlayerRole_Player_RoleID]);
GO

-- Creating foreign key on [ChampionRole_Role_ChampionID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_ChampionRole]
    FOREIGN KEY ([ChampionRole_Role_ChampionID])
    REFERENCES [dbo].[Champions]
        ([ChampionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChampionRole'
CREATE INDEX [IX_FK_ChampionRole]
ON [dbo].[Roles]
    ([ChampionRole_Role_ChampionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------