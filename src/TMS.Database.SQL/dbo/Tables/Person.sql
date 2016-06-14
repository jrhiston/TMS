CREATE TABLE [dbo].[Person] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (255) NULL,
    [LastName]     NVARCHAR (255) NULL,
    [UserName]     NVARCHAR (255) NULL,
    [PasswordHash] NVARCHAR (255) NULL,
    CONSTRAINT [PK__Person__3214EC07AED3CE6E] PRIMARY KEY CLUSTERED ([Id] ASC)
);



