-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'EditHierarchy1'
	AND type = 'P')
DROP PROCEDURE EditHierarchy1
GO

-- Stored Procedure
CREATE PROCEDURE EditHierarchy1
	-- Input parameters
    @Id int,
	@Name varchar(50)
AS

UPDATE HIERARCHY_1 SET
Name = @Name

WHERE Id = @Id

GO