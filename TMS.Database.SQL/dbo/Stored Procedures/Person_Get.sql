-- =============================================
-- Author:		Jack Histon
-- Create date: 28/11/2015
-- Description:	Retrieves a person object.
-- =============================================
CREATE PROCEDURE [dbo].[Person_Get]
	@Identifier	BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT info.* FROM Person p
	CROSS APPLY GetPerson(Id) info
	WHERE p.Id = @Identifier
END