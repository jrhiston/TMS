
CREATE PROCEDURE [dbo].[Person_Save]
	@Identifier	BIGINT,
	@FirstName	NVARCHAR(255),
	@LastName	NVARCHAR(255),
	@PasswordHash	NVARCHAR(255),
	@UserName		NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF @Identifier IS NULL OR @Identifier <= 0
		INSERT INTO Person (FirstName, LastName, UserName, PasswordHash) VALUES (@FirstName, @LastName, @UserName, @PasswordHash)
	ELSE
		UPDATE Person 
		SET FirstName = @FirstName,
			LastName = @LastName,
			UserName = @UserName,
			PasswordHash = @PasswordHash
		WHERE Id = @Identifier

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END