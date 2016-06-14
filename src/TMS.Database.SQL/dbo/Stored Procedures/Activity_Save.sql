
CREATE PROCEDURE [dbo].[Activity_Save]
	@Identifier	BIGINT,
	@CreationDate	DATETIME,
	@DeliveryTime	DATETIME,
	@Description	NVARCHAR(255),
	@Owner			BIGINT,
	@Title			NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @Identifier IS NULL OR @Identifier <= 0
		INSERT INTO Activity 
		(Title, CreationDate, DeliveryTime, Description, Owner_id)
			VALUES 
		(@Title, @CreationDate, @DeliveryTime, @Description, @Owner)
	ELSE
		UPDATE Activity 
		SET Title = @Title,
			CreationDate = @CreationDate,
			DeliveryTime = @DeliveryTime,
			Description = @Description,
			Owner_id = @Owner
		WHERE Id = @Identifier

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END