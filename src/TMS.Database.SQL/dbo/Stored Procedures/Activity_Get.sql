
CREATE PROCEDURE [dbo].[Activity_Get]
	@Identifier	BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT info.* FROM Activity a
	CROSS APPLY GetActivity(a.Id) info
	WHERE a.Id = @Identifier;

	--WITH TagHierarchy (Id, CanSetOnActivity, Created, Description, Name, Reusable, ChildID) AS
	--(
	--	SELECT info.*, cast(NULL as BIGINT) FROM ActivityTags at
	--	CROSS APPLY GetTag(at.TagDataObject_id) info
	--	WHERE at.ActivityDataObject_id = @Identifier

	--	UNION ALL

	--	SELECT info.*, th.Id FROM RelatedTag rt
	--	CROSS APPLY GetTag(rt.ParentID) info
	--	INNER JOIN TagHierarchy th ON rt.ChildID = th.Id
	--)

	--SELECT * FROM TagHierarchy
END