CREATE TABLE [dbo].[Balances] (
    [UserId]     INT   NOT NULL,
    [Amount]    MONEY NOT NULL,
    [CurrencyId] INT   NOT NULL,
    CONSTRAINT [PK_Balances] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Balances_Currencies] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currencies] ([CurrencyId]),
    CONSTRAINT [FK_Balances_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

