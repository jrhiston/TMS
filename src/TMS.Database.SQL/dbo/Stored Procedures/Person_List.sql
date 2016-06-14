-- =============================================
-- Author:		Jack Histon
-- Create date: 28/11/2015
-- Description: Lists all people in the database.
-- =============================================
CREATE PROCEDURE [dbo].[Person_List]
	@Identifier	BIGINT,
	@UserName	NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT info.* FROM Person p
	CROSS APPLY GetPerson(Id) info
	WHERE 
		(@Identifier IS NULL OR p.Id = @Identifier)
			AND
		(@UserName IS NULL OR p.UserName LIKE @UserName + '%')
END