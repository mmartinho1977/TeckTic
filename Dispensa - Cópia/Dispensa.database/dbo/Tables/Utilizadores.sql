CREATE TABLE [dbo].[Utilizadores]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] BINARY(64) NOT NULL
)
