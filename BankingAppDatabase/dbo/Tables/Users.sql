CREATE TABLE [dbo].[Users] (
    [UserId] INT        IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR(15) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

