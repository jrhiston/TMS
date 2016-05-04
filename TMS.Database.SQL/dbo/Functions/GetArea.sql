
CREATE FUNCTION dbo.GetArea
(	
	@AreaId	BIGINT
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT	AreaId, 
			Name, 
			Description 
	FROM Area 
	WHERE AreaId = @AreaId
)