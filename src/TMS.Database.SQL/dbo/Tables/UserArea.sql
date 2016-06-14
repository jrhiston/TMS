CREATE TABLE [dbo].[UserArea] (
    [AreaId] BIGINT NOT NULL,
    [UserId] BIGINT NOT NULL,
    CONSTRAINT [PK_UserArea] PRIMARY KEY CLUSTERED ([AreaId] ASC, [UserId] ASC),
    CONSTRAINT [FK_UserArea_Area] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([AreaId]),
    CONSTRAINT [FK_UserArea_Person] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Person] ([Id])
);

