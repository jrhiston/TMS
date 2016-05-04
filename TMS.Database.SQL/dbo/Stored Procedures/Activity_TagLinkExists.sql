
CREATE PROCEDURE dbo.Activity_TagLinkExists
	@ActivityId	BIGINT,
	@TagId		BIGINT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT CASE WHEN EXISTS (
	SELECT *
	FROM ActivityTags 
	WHERE TagDataObject_id = @TagId AND ActivityDataObject_id = @ActivityId)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END
END