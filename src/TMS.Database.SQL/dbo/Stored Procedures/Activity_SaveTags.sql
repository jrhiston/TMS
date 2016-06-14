
CREATE PROCEDURE [dbo].[Activity_SaveTags]
	@ActivityIdentifier BIGINT,
	@TagIds	BIGINT_LIST readonly
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM ActivityTags WHERE ActivityDataObject_id = @ActivityIdentifier

	INSERT INTO ActivityTags (ActivityDataObject_id, TagDataObject_id)
		SELECT @ActivityIdentifier, ti.Id FROM @TagIds ti

END