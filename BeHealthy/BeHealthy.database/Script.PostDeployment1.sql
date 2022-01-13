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
/* IMPOSTOS */
IF NOT EXISTS(SELECT [IDUtilizador] FROM [dbo].[Utilizadores])
BEGIN	
	INSERT INTO [dbo].[Utilizadores] ([username], [password])
		VALUES ('ADMIN', '12345')
END

IF NOT EXISTS(SELECT [IDTipoAlimentos] FROM [dbo].[TipoAlimentos])
BEGIN	
	INSERT INTO [dbo].[TipoAlimentos] ([Descricao])
		VALUES ('Fruta')
END