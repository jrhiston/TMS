
CREATE PROCEDURE [dbo].[Activity_List]
	@Owner	BIGINT = NULL,
	@UserGroupId BIGINT = NULL,
	@AreaId	BIGINT = NULL,
	@StartCreationDate DATETIME = NULL,
	@EndCreationDate DATETIME = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT info.* FROM Activity a
	CROSS APPLY GetActivity(a.Id) info
	LEFT JOIN ActivityUserGroup aug ON aug.ActivityId = a.Id
	WHERE
		(@Owner IS NULL OR @Owner = a.Owner_id)
	AND
		(@UserGroupId IS NULL OR @UserGroupId = aug.UserGroupId)
	AND
		(@AreaId IS NULL OR @AreaId = a.AreaId)
	AND
		(@StartCreationDate IS NULL OR @StartCreationDate <= a.CreationDate)
	AND
		(@EndCreationDate IS NULL OR @EndCreationDate >= a.CreationDate);

END