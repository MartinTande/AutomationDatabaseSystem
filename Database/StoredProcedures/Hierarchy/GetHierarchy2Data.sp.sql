-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetHierarchy2ByGroup'
	AND type = 'P')
DROP PROCEDURE GetHierarchy2ByGroup
GO

CREATE PROCEDURE GetHierarchy2ByGroup
	@Name varchar(50)
AS

SELECT Id, Name
FROM HIERARCHY_2
WHERE Hierarchy1Id = (SELECT Id FROM HIERARCHY_1 WHERE Name = @Name);

GO
