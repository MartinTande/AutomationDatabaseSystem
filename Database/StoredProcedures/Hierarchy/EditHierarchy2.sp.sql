-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'EditHierarchy2'
	AND type = 'P')
DROP PROCEDURE EditHierarchy2
GO

-- Stored Procedure
CREATE PROCEDURE EditHierarchy2
	-- Input parameters
    @Id int,
	@Name varchar(100)
AS

UPDATE HIERARCHY_2 SET
Name = @Name

WHERE Id = @Id

GO