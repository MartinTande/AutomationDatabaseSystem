
-- Stored Procedure
CREATE PROCEDURE DeleteTag
	-- Input parameters
	@Id int
AS

BEGIN
	DELETE
		FROM TAG 
		WHERE Id=@Id
END;
