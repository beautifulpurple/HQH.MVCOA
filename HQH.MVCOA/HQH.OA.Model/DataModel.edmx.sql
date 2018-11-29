
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2018 21:20:09
-- Generated from EDMX file: D:\视频教学\MVC\MVCOA-again\MVCOA-Project\HQH.MVCOA\HQH.OA.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HQH_MVCOA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsreInfoOrderInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderInfoes] DROP CONSTRAINT [FK_UsreInfoOrderInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OrderInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderInfoes];
GO
IF OBJECT_ID(N'[dbo].[UsreInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsreInfoes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OrderInfoes'
CREATE TABLE [dbo].[OrderInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(100)  NULL,
    [CustomId] int  NOT NULL,
    [UsreInfoId] int  NOT NULL
);
GO

-- Creating table 'UserInfoes'
CREATE TABLE [dbo].[UserInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'OrderInfoes'
ALTER TABLE [dbo].[OrderInfoes]
ADD CONSTRAINT [PK_OrderInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfoes'
ALTER TABLE [dbo].[UserInfoes]
ADD CONSTRAINT [PK_UserInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsreInfoId] in table 'OrderInfoes'
ALTER TABLE [dbo].[OrderInfoes]
ADD CONSTRAINT [FK_UsreInfoOrderInfo]
    FOREIGN KEY ([UsreInfoId])
    REFERENCES [dbo].[UserInfoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsreInfoOrderInfo'
CREATE INDEX [IX_FK_UsreInfoOrderInfo]
ON [dbo].[OrderInfoes]
    ([UsreInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------