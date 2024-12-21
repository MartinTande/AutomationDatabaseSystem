CREATE PROCEDURE [dbo].[CreateDatabase]
	-- Input parameters
	@Name varchar(100)
AS

BEGIN
	-- Checks to see if the Database already exists, if not it inserts it
	IF NOT EXISTS (SELECT *	FROM [dbo].[DATABASE] WHERE Name = @Name)
	INSERT INTO [dbo].[DATABASE]
		(Name)
	VALUES
		(@Name)

	INSERT INTO OBJECT
		(Name, DateCreated)
	VALUES
		(@Name, getdate())
END;
