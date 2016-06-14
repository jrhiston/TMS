CREATE TABLE [dbo].[UserGroup] (
    [UserGroupId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Created]     DATETIME       NOT NULL,
    [AuthorId]    BIGINT         NOT NULL,
    CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED ([UserGroupId] ASC),
    CONSTRAINT [FK_UserGroup_Person] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Person] ([Id])
);



