/*
Inserting Seed Data
*/

IF(NOT EXISTS(SELECT 1 FROM dbo.[Users]))
BEGIN
    INSERT INTO dbo.[Users] (Name) VALUES('Ada');
    INSERT INTO dbo.[Users] (Name) VALUES('Kimberly');
    INSERT INTO dbo.[Users] (Name) VALUES('Fern');

    INSERT INTO dbo.Currencies (Code, Name) VALUES('EUR', 'Euro');
    INSERT INTO dbo.Currencies (Code, Name) VALUES('GBP', 'GB');
    INSERT INTO dbo.Currencies (Code, Name) VALUES('USD', 'USA');
    
    DECLARE @UserId INT, @CurrencyId INT;
    SELECT @UserId = UserId  FROM dbo.[Users] WHERE Name = 'Ada';
    SELECT @CurrencyId = CurrencyId FROM dbo.Currencies WHERE Code = 'EUR';
    INSERT INTO Balances (UserId, CurrencyId, Amount) VALUES(@UserId, @CurrencyId, 1000);

    SELECT @UserId = UserId FROM dbo.[Users] WHERE Name = 'Kimberly';
    INSERT INTO Balances (UserId, CurrencyId, Amount) VALUES(@UserId, @CurrencyId, 500);

    SELECT @UserId = UserId FROM dbo.[Users] WHERE Name = 'Fern';
    INSERT INTO Balances (UserId, CurrencyId, Amount) VALUES(@UserId, @CurrencyId, 200);
END;