
CREATE PROCEDURE Tag_Get
	@Identifier	BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT info.* FROM Tag a
	CROSS APPLY GetTag(a.Id) info
	WHERE a.Id = @Identifier
END