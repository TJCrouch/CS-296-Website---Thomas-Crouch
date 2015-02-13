
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/12/2015 23:45:47
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
IF OBJECT_ID(N'[dbo].[FK_PlayerRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_PlayerRole];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Players] DROP CONSTRAINT [FK_TeamPlayer];
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
    [LeagueName] nvarchar(max)  NOT NULL,
    [RegionName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [TeamName] nvarchar(max)  NOT NULL,
    [LeagueName] nvarchar(max)  NOT NULL,
    [LeagueTeam_Team_LeagueName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [PlayerName] nvarchar(max)  NOT NULL,
    [TeamName] nvarchar(max)  NOT NULL,
    [LeagueName] nvarchar(max)  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [TeamPlayer_Player_TeamName] nvarchar(max)  NOT NULL,
    [PlayerRole_Player_RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleName] nvarchar(max)  NOT NULL,
    [PrimaryAttribute] nvarchar(max)  NOT NULL,
    [ChampionRole_Role_ChampionName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Champions'
CREATE TABLE [dbo].[Champions] (
    [ChampionName] nvarchar(max)  NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [PrimaryAttribute] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LeagueName] in table 'Leagues'
ALTER TABLE [dbo].[Leagues]
ADD CONSTRAINT [PK_Leagues]
    PRIMARY KEY CLUSTERED ([LeagueName] ASC);
GO

-- Creating primary key on [TeamName] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([TeamName] ASC);
GO

-- Creating primary key on [PlayerName] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([PlayerName] ASC);
GO

-- Creating primary key on [RoleName] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleName] ASC);
GO

-- Creating primary key on [ChampionName] in table 'Champions'
ALTER TABLE [dbo].[Champions]
ADD CONSTRAINT [PK_Champions]
    PRIMARY KEY CLUSTERED ([ChampionName] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LeagueTeam_Team_LeagueName] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_LeagueTeam]
    FOREIGN KEY ([LeagueTeam_Team_LeagueName])
    REFERENCES [dbo].[Leagues]
        ([LeagueName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LeagueTeam'
CREATE INDEX [IX_FK_LeagueTeam]
ON [dbo].[Teams]
    ([LeagueTeam_Team_LeagueName]);
GO

-- Creating foreign key on [TeamPlayer_Player_TeamName] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_TeamPlayer]
    FOREIGN KEY ([TeamPlayer_Player_TeamName])
    REFERENCES [dbo].[Teams]
        ([TeamName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayer'
CREATE INDEX [IX_FK_TeamPlayer]
ON [dbo].[Players]
    ([TeamPlayer_Player_TeamName]);
GO

-- Creating foreign key on [PlayerRole_Player_RoleName] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_PlayerRole]
    FOREIGN KEY ([PlayerRole_Player_RoleName])
    REFERENCES [dbo].[Roles]
        ([RoleName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerRole'
CREATE INDEX [IX_FK_PlayerRole]
ON [dbo].[Players]
    ([PlayerRole_Player_RoleName]);
GO

-- Creating foreign key on [ChampionRole_Role_ChampionName] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [FK_ChampionRole]
    FOREIGN KEY ([ChampionRole_Role_ChampionName])
    REFERENCES [dbo].[Champions]
        ([ChampionName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChampionRole'
CREATE INDEX [IX_FK_ChampionRole]
ON [dbo].[Roles]
    ([ChampionRole_Role_ChampionName]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------