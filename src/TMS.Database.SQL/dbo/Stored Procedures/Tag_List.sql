
CREATE PROCEDURE [dbo].[Tag_List]
	@ActivityId	BIGINT = NULL,
	@TagName	NVARCHAR(255) = NULL,
	@ChildTagId	BIGINT = NULL,
	@ParentTagId	BIGINT = NULL,
	@Reusable BIT = NULL,
	@CreatorId BIGINT,
	@CanSetOnActivity BIT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT info.* FROM Tag t
	CROSS APPLY GetTag(t.Id) info
	LEFT JOIN ActivityTags at ON t.Id = at.TagDataObject_id
	LEFT JOIN RelatedTag crt ON t.Id = crt.ParentID
	LEFT JOIN RelatedTag crt2 ON t.Id = crt2.ChildID
	WHERE
		(@ActivityId IS NULL OR @ActivityId = at.ActivityDataObject_id)
	AND
		(@TagName IS NULL OR @TagName LIKE '%' + t.Name)
	AND 
		(@ChildTagId IS NULL OR crt.ChildID = @ChildTagId)
	AND
		(@ParentTagId IS NULL OR crt2.ParentID = @ParentTagId)
	AND
		(@Reusable IS NULL OR t.Reusable = @Reusable)
	AND
		(@CreatorId IS NULL OR t.CreatorId = @CreatorId)
	AND
		(@CanSetOnActivity IS NULL OR t.CanSetOnActivity = @CanSetOnActivity)
END