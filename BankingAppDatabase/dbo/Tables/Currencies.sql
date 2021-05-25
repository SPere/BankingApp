CREATE TABLE [dbo].[Currencies] (
    [CurrencyId] INT        IDENTITY (1, 1) NOT NULL,
    [Code]       NCHAR (3)  NOT NULL,
    [Name]       NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED ([CurrencyId] ASC)
);

