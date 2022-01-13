CREATE TABLE [dbo].[UserDevice]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [DeviceId] INT NOT NULL, 
    [Profile] NCHAR(30) NOT NULL, 
    [Active] BIT NOT NULL, 
    [CreationDate] SMALLDATETIME NOT NULL, 
    [UpdateDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [FK_UserDevice_Users] FOREIGN KEY (UserId) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_UserDevice_Devices] FOREIGN KEY (DeviceId) REFERENCES[Devices]([Id]), 
    
)
