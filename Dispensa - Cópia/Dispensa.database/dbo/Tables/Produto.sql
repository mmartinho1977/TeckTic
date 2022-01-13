CREATE TABLE [dbo].[Produto] (
    [Codigo]           INT            IDENTITY (1, 1) NOT NULL,
    [Descricao]        NVARCHAR (250) NOT NULL,
    [Preco]            DECIMAL (18, 2)   NOT NULL,
    [QuantidadeAtual]  INT            NOT NULL,
    [QuantidadeMaxima] INT            NOT NULL,
    [QuantidadeMinima] INT            NOT NULL,
    [CodigoCategoria]  INT NOT NULL,
    [DataCompra] DATETIME NOT NULL, 

    CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED ([Codigo] ASC), 
    CONSTRAINT [FK_Produto_Categoria] FOREIGN KEY ([CodigoCategoria]) REFERENCES [Categoria]([Codigo])

);

