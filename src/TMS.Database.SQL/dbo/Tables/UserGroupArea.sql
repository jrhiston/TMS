CREATE TABLE [dbo].[UserGroupArea] (
    [UserGroupId] BIGINT NOT NULL,
    [AreaId]      BIGINT NOT NULL,
    CONSTRAINT [PK_UserGroupArea] PRIMARY KEY CLUSTERED ([UserGroupId] ASC, [AreaId] ASC),
    CONSTRAINT [FK_UserGroupArea_Area] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([AreaId]),
    CONSTRAINT [FK_UserGroupArea_UserGroup] FOREIGN KEY ([UserGroupId]) REFERENCES [dbo].[UserGroup] ([UserGroupId])
);

