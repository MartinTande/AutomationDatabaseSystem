
-- Stored Procedure
CREATE PROCEDURE EditHierarchy2
	-- Input parameters
    @Id int,
	@Name varchar(100)
AS

UPDATE HIERARCHY_2 SET
Name = @Name

WHERE Id = @Id

