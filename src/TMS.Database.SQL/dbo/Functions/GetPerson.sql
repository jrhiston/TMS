-- =============================================
-- Author:		Jack Histon
-- Create date: 28/11/2015
-- Description:	Get a person.
-- =============================================
CREATE FUNCTION [dbo].[GetPerson]
(	
	@Identifier	BIGINT
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT Id, FirstName, LastName, UserName, PasswordHash FROM Person p WHERE Id = @Identifier
)