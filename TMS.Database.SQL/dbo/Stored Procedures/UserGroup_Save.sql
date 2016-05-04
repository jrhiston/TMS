
CREATE PROCEDURE dbo.UserGroup_Save
	@UserGroupId	BIGINT,
	@Name			NVARCHAR(100),
	@Description	NVARCHAR(MAX),
	@Created		DATETIME,
	@AuthorId		BIGINT
AS
BEGIN
	SET NOCOUNT ON;

    IF @UserGroupId IS NULL OR @UserGroupId <= 0
		INSERT INTO UserGroup 
		(Name, Description, Created, AuthorId)
			VALUES 
		(@Name, @Description, @Created, @AuthorId)
	ELSE
		UPDATE UserGroup 
		SET Name = @Name,
			Description = @Description,
			Created = @Created,
			AuthorId = @AuthorId
		WHERE UserGroupId = @UserGroupId

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END