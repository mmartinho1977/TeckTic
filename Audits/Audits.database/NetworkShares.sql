CREATE TABLE [dbo].[NetworkShares]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Path] NVARCHAR(100) NOT NULL, 
    [DeviceId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Active] BIT NOT NULL, 
    [CreationDate] SMALLDATETIME NOT NULL, 
    [UpdateDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [FK_NetworkShares_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [Devices]([Id]), 
    CONSTRAINT [FK_NetworkShares_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
