
CREATE PROCEDURE [dbo].[Activity_DeleteTag]
	@TagId		BIGINT,
	@ActivityId	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM ActivityTags 
	WHERE ActivityDataObject_id = @ActivityId 
		AND TagDataObject_id = @TagId
END