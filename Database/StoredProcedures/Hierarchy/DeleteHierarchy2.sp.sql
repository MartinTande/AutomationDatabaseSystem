-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'DeleteHierarchy2'
	AND type = 'P')
DROP PROCEDURE DeleteHierarchy2
GO

-- Stored Procedure
CREATE PROCEDURE DeleteHierarchy2
	-- Input parameters
    @Id int
AS

DELETE
FROM HIERARCHY_2
WHERE Id=@Id

GO