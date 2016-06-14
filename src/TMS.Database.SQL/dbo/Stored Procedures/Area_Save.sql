
CREATE PROCEDURE dbo.Area_Save
	@AreaId			BIGINT,
	@Name			NVARCHAR(254),
	@Description	NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;

	IF @AreaId IS NULL OR @AreaId <= 0 
		INSERT INTO Area
		(Name, Description)
			VALUES
		(@Name, @Description)
	ELSE
		UPDATE Area
		SET Name = @Name,
			Description = @Description
		WHERE AreaId = @AreaId

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END