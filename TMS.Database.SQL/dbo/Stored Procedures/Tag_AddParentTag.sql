
CREATE PROCEDURE Tag_AddParentTag
	@TagId			BIGINT,
	@ParentTagId	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO RelatedTag (ParentID, ChildID) VALUES (@ParentTagId, @TagId);
END