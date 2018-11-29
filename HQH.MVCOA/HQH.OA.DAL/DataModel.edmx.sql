
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2018 18:15:06
-- Generated from EDMX file: D:\视频教学\MVC\MVCOA-again\MVCOA-Project\HQH.MVCOA\HQH.OA.DAL\DataModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Custom'
CREATE TABLE [dbo].[Custom] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'OrderInfoe'
CREATE TABLE [dbo].[OrderInfoe] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderContent] nvarchar(100)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Custom'
ALTER TABLE [dbo].[Custom]
ADD CONSTRAINT [PK_Custom]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderInfoe'
ALTER TABLE [dbo].[OrderInfoe]
ADD CONSTRAINT [PK_OrderInfoe]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------