
CREATE PROCEDURE dbo.UserGroup_Get
	@UserGroupId	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT info.*
	FROM UserGroup ug
	CROSS APPLY GetUserGroup(ug.UserGroupId) info
	WHERE ug.UserGroupId = @UserGroupId
END