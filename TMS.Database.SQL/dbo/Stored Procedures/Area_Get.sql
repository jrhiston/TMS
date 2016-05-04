
CREATE PROCEDURE dbo.Area_Get
	@AreaId	BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT info.*
	FROM Area a
	CROSS APPLY GetArea(a.AreaId) info
	WHERE a.AreaId = @AreaId
END