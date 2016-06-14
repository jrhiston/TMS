CREATE TABLE [dbo].[Area] (
    [AreaId]      BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (254) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED ([AreaId] ASC),
    CONSTRAINT [FK_Area_Area] FOREIGN KEY ([AreaId]) REFERENCES [dbo].[Area] ([AreaId])
);

