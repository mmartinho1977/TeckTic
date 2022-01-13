﻿/*
Deployment script for Pantry

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Pantry"
:setvar DefaultFilePrefix "Pantry"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

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
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS(SELECT [Name] FROM [SYS].[DATABASES] WHERE [Name] = 'Pantry')
BEGIN
CREATE DATABASE Pantry COLLATE LATIN1_GENERAL_CI_AS
-- ATENÇÃO QUE TEM TAMBÉM QUE SE ALTERAR A COLLATION NAS PROPRIEDADES DESTE PROJETO
END 

GO

GO
PRINT N'Starting rebuilding table [dbo].[Utilizadores]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Utilizadores] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] BINARY (64)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Utilizadores])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Utilizadores] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Utilizadores] ([Id], [Username], [Password])
        SELECT   [Id],
                 [Username],
                 [Password]
        FROM     [dbo].[Utilizadores]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Utilizadores] OFF;
    END

DROP TABLE [dbo].[Utilizadores];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Utilizadores]', N'Utilizadores';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF NOT EXISTS(SELECT [Descricao] FROM [dbo].[Categoria])
BEGIN 
INSERT INTO [dbo].[Categoria] ([Descricao])
     VALUES
           ('mercearia'),
           ('frescos'),
           ('higiene')
END


IF NOT EXISTS(SELECT [Username] FROM [dbo].[Utilizadores])
BEGIN 
INSERT INTO [dbo].[Utilizadores] ([Username], [Password])
     VALUES
           ('user1', HASHBYTES('SHA2_512', '123456')),
           ('admin', HASHBYTES('SHA2_512', '123456'))
END


IF NOT EXISTS(SELECT [Descricao] FROM [dbo].[Produto])
BEGIN 
INSERT INTO [dbo].[Produto] ([Descricao]
           ,[Preco]
           ,[QuantidadeAtual]
           ,[QuantidadeMaxima]
           ,[QuantidadeMinima]
           ,[CodigoCategoria])
     VALUES
           ('massa', 0.8, 2, 5, 2, 1),
           ('arroz', 1.1, 5, 3, 3, 1),
           ('courget', 1.9, 3, 3, 3, 2)
END




GO

GO
PRINT N'Update complete.';


GO
