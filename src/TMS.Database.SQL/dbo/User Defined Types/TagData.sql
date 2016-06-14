CREATE TYPE [dbo].[TagData] AS TABLE (
    [Identifier]       BIGINT         NULL,
    [CanSetOnActivity] BIT            NULL,
    [Created]          DATETIME       NULL,
    [Description]      NVARCHAR (255) NULL,
    [Name]             NVARCHAR (255) NULL,
    [Reusable]         BIT            NULL);

