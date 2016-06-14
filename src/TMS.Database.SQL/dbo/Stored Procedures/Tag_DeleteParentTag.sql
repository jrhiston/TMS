
CREATE PROCEDURE Tag_DeleteParentTag
	@TagId			BIGINT,
	@ParentTagId	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM RelatedTag WHERE ParentID = @ParentTagId AND ChildID = @TagId
END