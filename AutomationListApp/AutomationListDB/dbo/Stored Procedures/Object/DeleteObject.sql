
-- Stored Procedure
CREATE PROCEDURE DeleteObject
	-- Input parameters
    @Id int
AS
	DELETE 
	FROM OBJECT 
	WHERE Id=@Id

