CREATE TABLE [dbo].[PersonActivity] (
    [ActivityDataObject_id] BIGINT NOT NULL,
    [PersonDataObject_id]   BIGINT NOT NULL,
    PRIMARY KEY CLUSTERED ([PersonDataObject_id] ASC, [ActivityDataObject_id] ASC),
    CONSTRAINT [FK2D30E4FCC997C5E1] FOREIGN KEY ([PersonDataObject_id]) REFERENCES [dbo].[Person] ([Id])
);



