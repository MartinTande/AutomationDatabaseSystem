-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'DeleteHierarchy1'
	AND type = 'P')
DROP PROCEDURE DeleteHierarchy1
GO

-- Stored Procedure
CREATE PROCEDURE DeleteHierarchy1
	-- Input parameters
    @Hierarchy1Id int
AS

DELETE 
FROM HIERARCHY_1
WHERE Hierarchy1Id=@Hierarchy1Id

GO