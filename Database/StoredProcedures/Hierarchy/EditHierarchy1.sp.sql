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
    @Hierarchy1Id int,
	@Hierarchy1Name varchar(50)
AS

UPDATE HIERARCHY_1 SET
Hierarchy1Name = @Hierarchy1Name

WHERE Hierarchy1Id = @Hierarchy1Id

GO