CREATE TABLE [dbo].[Activity] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (255) NULL,
    [CreationDate] DATETIME       NULL,
    [DeliveryTime] DATETIME       NULL,
    [Description]  NVARCHAR (255) NULL,
    [Owner_id]     BIGINT         NOT NULL,
    [AreaId]       BIGINT         NOT NULL,
    CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Activity_Area] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([AreaId]),
    CONSTRAINT [FK_Activity_Person] FOREIGN KEY ([Owner_id]) REFERENCES [dbo].[Person] ([Id])
);







