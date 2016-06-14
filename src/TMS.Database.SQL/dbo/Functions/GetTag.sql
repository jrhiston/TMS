
CREATE FUNCTION [dbo].[GetTag]
(	
	@Identifier	BIGINT
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT Id, CanSetOnActivity, Created, Description, Name, Reusable, CreatorId FROM Tag WHERE Id = @Identifier
)