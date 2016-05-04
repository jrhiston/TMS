CREATE TABLE [dbo].[Tag] (
    [Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (255) NULL,
    [Description]      NVARCHAR (255) NULL,
    [Created]          DATETIME       NULL,
    [CanSetOnActivity] BIT            NULL,
    [Reusable]         BIT            NULL,
    [CreatorId]        BIGINT         NOT NULL,
    CONSTRAINT [PK__Tag__3214EC07A43DE496] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Tag_Person] FOREIGN KEY ([CreatorId]) REFERENCES [dbo].[Person] ([Id])
);





