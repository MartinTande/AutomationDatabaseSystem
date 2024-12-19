

-- Stored Procedure
CREATE PROCEDURE CreateObject
	-- Input parameters
	@Name varchar(100)
AS

BEGIN
	-- Checks to see if the Database already exists, if not it inserts it
	IF NOT EXISTS (SELECT *
	FROM DATABASE
	WHERE Name = @Name)
	INSERT INTO DATABASE
		(Name)
	VALUES
		(@Name)


	INSERT INTO OBJECT
		(Name, DateCreated)
	VALUES
		(@Name, getdate())
END;