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
    @Hierarchy2Id int,
	@Hierarchy1Name varchar(50),
	@Hierarchy2Name varchar(50)
AS

UPDATE HIERARCHY_2 SET
Hierarchy2Name = @Hierarchy2Name,
Hierarchy1Id = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name=@Hierarchy1Name)

WHERE Hierarchy2Id = @Hierarchy2Id

GO