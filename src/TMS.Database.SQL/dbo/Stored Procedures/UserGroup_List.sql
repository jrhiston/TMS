
CREATE PROCEDURE [dbo].[UserGroup_List]
	@UserGroupName	NVARCHAR(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT info.* FROM UserGroup ug
	CROSS APPLY GetUserGroup(ug.UserGroupId) info
	WHERE
		(@UserGroupName IS NULL OR @UserGroupName = ug.Name)
END