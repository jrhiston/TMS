-- =============================================
-- Author:		Jack Histon
-- Create date: 28/11/2015
-- Description:	Delete a person
-- =============================================
CREATE PROCEDURE [dbo].[Person_Delete]
	@Identifier BIGINT
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM Person WHERE Id = @Identifier
END