
CREATE FUNCTION [dbo].[GetUserGroup]
(	
	@UserGroupId	BIGINT
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT UserGroupId, Name, Description, Created, AuthorId FROM UserGroup WHERE UserGroupId = @UserGroupId
)