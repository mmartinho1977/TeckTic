CREATE TABLE [dbo].[Drives]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Type] NVARCHAR(20) NOT NULL,
	[Size] INT NOT NULL, 
    [DeviceId] INT NOT NULL,

    [Active] BIT NOT NULL, 
    [CreationDate] SMALLDATETIME NOT NULL, 
    [UpdateDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [FK_Drives_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [Devices]([Id])

)
