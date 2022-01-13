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
--DELETE FROM PRODUTO;
--DELETE FROM CATEGORIA;
--DELETE FROM UTILIZADORES; 

IF NOT EXISTS(SELECT [Descricao] FROM [dbo].[Categoria])
BEGIN 
INSERT INTO [dbo].[Categoria] ([Descricao])
     VALUES
           ('mercearia'),
           ('frescos'),
           ('higiene')
END


IF NOT EXISTS(SELECT [Id] FROM [dbo].[Utilizadores])
BEGIN 
INSERT INTO [dbo].[Utilizadores] ([Username], [Password])
     VALUES
           ('user1', HASHBYTES('SHA2_512', '123456')),
           ('admin', HASHBYTES('SHA2_512', '123456'))
END


IF NOT EXISTS(SELECT [Codigo] FROM [dbo].[Produto])
BEGIN 
INSERT INTO [dbo].[Produto] ([Descricao]
           ,[Preco]
           ,[QuantidadeAtual]
           ,[QuantidadeMaxima]
           ,[QuantidadeMinima]
           ,[DataCompra]
           ,[CodigoCategoria])
     VALUES
           ('massa', 0.8, 2, 5, 2, GETDATE(), 1),
           ('arroz', 1.1, 5, 3, 3, GETDATE(), 1),
           ('courget', 1.9, 3, 3, 3, GETDATE(), 2)
END




GO
