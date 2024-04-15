-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetHierarchyNames2ByGroup'
	AND type = 'P')
DROP PROCEDURE GetHierarchy2NamesByGroup
GO

CREATE PROCEDURE GetHierarchy2NamesByGroup
	@Name varchar(50)
AS

SELECT Name
FROM HIERARCHY_2
WHERE Hierarchy1Id = (SELECT Id FROM HIERARCHY_1 WHERE Name = @Name);

GO
