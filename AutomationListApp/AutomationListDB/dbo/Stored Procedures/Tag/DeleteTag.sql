
-- Stored Procedure
CREATE PROCEDURE DeleteTag
	-- Input parameters
	@Id int
AS

-- Need to delete reference of Tag in connection table first
DELETE
	FROM TAG 
	WHERE Id=@Id

