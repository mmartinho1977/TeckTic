CREATE TABLE [dbo].[Alimentos]
(
	[IDAlimento] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Nome] NCHAR(10) NOT NULL, 
    [Descricao] NVARCHAR(50) NOT NULL, 
    [ValorEnergetico] INT NOT NULL, 
    [Lipidos] FLOAT NOT NULL, 
    [Hidratos] FLOAT NOT NULL, 
    [Sal] FLOAT NOT NULL, 
    [Fibra] FLOAT NOT NULL, 
    [Proteina] FLOAT NOT NULL, 
    [Ferro] FLOAT NOT NULL, 
    [Imagem] NVARCHAR(50) NOT NULL, 
    [IDUtilizador] INT NOT NULL, 
    [IDTipoAlimentos] INT NOT NULL, 
    CONSTRAINT [FK_Alimentos_Utilizadores] FOREIGN KEY ([IDUtilizador]) REFERENCES [Utilizadores]([IDUtilizador]), 
    CONSTRAINT [FK_Alimentos_TipoAlimentos] FOREIGN KEY ([IDTipoAlimentos]) REFERENCES [TipoAlimentos]([IDTipoAlimentos])
)
