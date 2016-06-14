
CREATE PROCEDURE [dbo].[Activity_AddTag]
	@TagId		BIGINT,
	@ActivityId	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ActivityTags (ActivityDataObject_id, TagDataObject_id) VALUES (@ActivityId, @TagId)
END