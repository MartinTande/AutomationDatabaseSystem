
-- Stored Procedure
CREATE PROCEDURE DeleteDatabase
    @Id int
AS

BEGIN
	DELETE 
	FROM [dbo].[DATABASE] 
	WHERE Id=@Id
END;