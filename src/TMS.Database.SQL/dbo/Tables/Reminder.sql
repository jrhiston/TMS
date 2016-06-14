CREATE TABLE [dbo].[Reminder] (
    [Id]          BIGINT         NOT NULL,
    [RemindTime]  DATETIME       NULL,
    [Description] NVARCHAR (255) NULL,
    [Activity_id] BIGINT         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



