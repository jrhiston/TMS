CREATE TABLE [dbo].[ActivityTags] (
    [ActivityDataObject_id] BIGINT NOT NULL,
    [TagDataObject_id]      BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([TagDataObject_id] ASC, [ActivityDataObject_id] ASC),
    CONSTRAINT [FK_ActivityTags_Activity] FOREIGN KEY ([ActivityDataObject_id]) REFERENCES [dbo].[Activity] ([Id]),
    CONSTRAINT [FK_ActivityTags_Tag] FOREIGN KEY ([TagDataObject_id]) REFERENCES [dbo].[Tag] ([Id])
);



