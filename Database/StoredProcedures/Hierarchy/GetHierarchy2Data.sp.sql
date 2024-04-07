-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetHierarchy2Data'
	AND type = 'P')
DROP PROCEDURE GetHierarchy2Data
GO

CREATE PROCEDURE GetHierarchy2Data
	@Hierarchy1Name varchar(50)
AS

SELECT Id, Hierarchy2Name
FROM HIERARCHY_2
WHERE Hierarchy1Id = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = @Hierarchy1Name);

GO
