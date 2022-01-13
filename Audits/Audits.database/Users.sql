CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Code] NVARCHAR(10) NOT NULL ,
	[Name] NVARCHAR(50) NOT NULL ,
	[Profile] NVARCHAR(20) NOT NULL ,
	[ExternalAccessAllowed] BIT NOT NULL ,
	[PasswordDateSet] DATETIME NOT NULL, 

    [Username] NCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL, 
    [CreationDate] SMALLDATETIME NOT NULL, 
    [UpdateDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [CK_Users_Code] UNIQUE (Code) 

)
