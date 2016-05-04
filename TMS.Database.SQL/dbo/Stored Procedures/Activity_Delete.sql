
CREATE PROCEDURE [dbo].[Activity_Delete]
	@Identifier	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Activity WHERE Id = @Identifier
END