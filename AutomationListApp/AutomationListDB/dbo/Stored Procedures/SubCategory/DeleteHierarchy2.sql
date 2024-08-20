
-- Stored Procedure
CREATE PROCEDURE DeleteHierarchy2
	-- Input parameters
    @Id int
AS

DELETE
FROM HIERARCHY_2
WHERE Id=@Id

