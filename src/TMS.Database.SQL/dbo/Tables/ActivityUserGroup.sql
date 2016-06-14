CREATE TABLE [dbo].[ActivityUserGroup] (
    [UserGroupId] BIGINT NOT NULL,
    [ActivityId]  BIGINT NOT NULL,
    CONSTRAINT [PK_ActivityUserGroup] PRIMARY KEY CLUSTERED ([UserGroupId] ASC, [ActivityId] ASC),
    CONSTRAINT [FK_ActivityUserGroup_UserGroup] FOREIGN KEY ([UserGroupId]) REFERENCES [dbo].[UserGroup] ([UserGroupId])
);

