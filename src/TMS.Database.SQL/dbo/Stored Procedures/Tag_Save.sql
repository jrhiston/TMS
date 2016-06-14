
CREATE PROCEDURE [dbo].[Tag_Save]
	@Identifier			BIGINT,
	@CanSetOnActivity	BIT,
	@Created			DATETIME,
	@Description		NVARCHAR(255),
	@Name				NVARCHAR(255),
	@Reusable			BIT,
	@CreatorId			BIGINT
AS
BEGIN
	SET NOCOUNT ON;

    IF @Identifier IS NULL OR @Identifier <= 0
		INSERT INTO Tag 
		(CanSetOnActivity, Created, Description, Name, Reusable, CreatorId)
			VALUES 
		(@CanSetOnActivity, @Created, @Description, @Name, @Reusable, @CreatorId)
	ELSE
		UPDATE Tag 
		SET CanSetOnActivity = @CanSetOnActivity,
			Description = @Description,
			Name = @Name,
			Reusable = @Reusable
		WHERE Id = @Identifier

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END