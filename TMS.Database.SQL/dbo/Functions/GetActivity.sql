
CREATE FUNCTION [dbo].[GetActivity]
(	
	@Identifier	BIGINT
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT Id, CreationDate, DeliveryTime, Description, Owner_id, Title FROM Activity WHERE Id = @Identifier
)