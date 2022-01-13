CREATE TABLE [dbo].[Utilizador]
(
	[Codigo] INT NOT NULL IDENTITY (1, 1)  PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL,
	[Password] BINARY(64) NOT NULL
)

