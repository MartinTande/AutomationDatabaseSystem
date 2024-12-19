
-- Stored Procedure
CREATE PROCEDURE DeleteDatabase
    @Id int
AS

BEGIN
	DELETE 
	FROM DATABSE 
	WHERE Id=@Id
END;