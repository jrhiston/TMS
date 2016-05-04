
CREATE PROCEDURE Area_List
	@AreaId	BIGINT = NULL,
	@UserId	BIGINT = NULL,
	@UserGroupId	BIGINT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT info.* FROM Area a
	CROSS APPLY GetArea(a.AreaId) info
	WHERE 
		(@AreaId IS NULL OR @AreaId = a.AreaId)
END