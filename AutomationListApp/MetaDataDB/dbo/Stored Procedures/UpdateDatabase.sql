CREATE PROCEDURE UpdateDatabase
	@Id int,
	@Name varchar(100)
AS

BEGIN
	UPDATE [dbo].[DATABASE] SET
	Name = @Name
	WHERE Id = @Id
END;
