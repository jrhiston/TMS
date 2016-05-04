
CREATE PROCEDURE [dbo].[Tag_Delete]
	@Identifier	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Tag WHERE Id = @Identifier
END