﻿/*
Deployment script for Audits

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Audits"
:setvar DefaultFilePrefix "Audits"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[UserDevice]...';


GO
CREATE TABLE [dbo].[UserDevice] (
    [Id]       INT        NOT NULL,
    [UserId]   INT        NOT NULL,
    [DeviceId] INT        NOT NULL,
    [Profile]  NCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_UserDevice_Users]...';


GO
ALTER TABLE [dbo].[UserDevice] WITH NOCHECK
    ADD CONSTRAINT [FK_UserDevice_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]);


GO
PRINT N'Creating [dbo].[FK_UserDevice_Devices]...';


GO
ALTER TABLE [dbo].[UserDevice] WITH NOCHECK
    ADD CONSTRAINT [FK_UserDevice_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[UserDevice] WITH CHECK CHECK CONSTRAINT [FK_UserDevice_Users];

ALTER TABLE [dbo].[UserDevice] WITH CHECK CHECK CONSTRAINT [FK_UserDevice_Devices];


GO
PRINT N'Update complete.';


GO