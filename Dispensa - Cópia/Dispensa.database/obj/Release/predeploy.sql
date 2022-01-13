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

--IF NOT EXISTS(SELECT [Name] FROM [SYS].[DATABASES] WHERE [Name] = 'Pantry')
--BEGIN
--CREATE DATABASE Pantry COLLATE LATIN1_GENERAL_CI_AS
---- ATENÇÃO QUE TEM TAMBÉM QUE SE ALTERAR A COLLATION NAS PROPRIEDADES DESTE PROJETO
--END 


--IF (EXISTS (SELECT *
--   FROM INFORMATION_SCHEMA.TABLES
--   WHERE TABLE_SCHEMA = 'Pantry'
--   AND TABLE_NAME = 'Produto'))
--   BEGIN
--      DROP TABLE Produto;
--   END; 

--  IF (EXISTS (SELECT *
--   FROM INFORMATION_SCHEMA.TABLES
--   WHERE TABLE_SCHEMA = 'Pantry'
--   AND TABLE_NAME = 'Categoria'))
--   BEGIN
--      DROP TABLE Categoria;
--   END;
   
--   IF (EXISTS (SELECT *
--   FROM INFORMATION_SCHEMA.TABLES
--   WHERE TABLE_SCHEMA = 'Pantry'
--   AND TABLE_NAME = 'Utilizadores'))
--   BEGIN
--      DROP TABLE Utilizadores;
--   END; 
GO
