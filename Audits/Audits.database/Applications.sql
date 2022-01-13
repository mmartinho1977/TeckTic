CREATE TABLE [dbo].[Applications]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Code] NVARCHAR(10) NOT NULL,
	[Description] INT NOT NULL,
	[InstalationDate] DATETIME NOT NULL,
	[Type] INT NOT NULL,
	[Renovation] INT NOT NULL,
	[KeyLicence] NVARCHAR(10) NOT NULL, 
    [DeviceId] INT NOT NULL, 
    CONSTRAINT [FK_Applications_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [Devices]([Id]), 
    CONSTRAINT [CK_Applications_Code] UNIQUE (Code)
)
