CREATE TABLE [dbo].[Utilizadores]
(
	[IDUtilizador] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [username] NVARCHAR(10) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL
)
