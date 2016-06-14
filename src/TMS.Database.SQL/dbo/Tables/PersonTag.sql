CREATE TABLE [dbo].[PersonTag] (
    [PersonDataObject_id] BIGINT NOT NULL,
    [TagDataObject_id]    BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([TagDataObject_id] ASC, [PersonDataObject_id] ASC),
    CONSTRAINT [FK951E8663C997C5E1] FOREIGN KEY ([PersonDataObject_id]) REFERENCES [dbo].[Person] ([Id])
);



