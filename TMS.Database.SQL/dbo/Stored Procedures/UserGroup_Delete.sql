
CREATE PROCEDURE [dbo].[UserGroup_Delete]
	@UserGroupId BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM UserGroup WHERE UserGroupId = @UserGroupId
END