CREATE PROCEDURE GetDatabaseById
	@Id int
AS

BEGIN
	SELECT Id, Name, DateCreated
	FROM [dbo].[DATABASE]
	WHERE Id = @Id
END;