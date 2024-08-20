
CREATE PROCEDURE GetHierarchy2ByGroup
	@Name varchar(50)
AS

SELECT Id, Name
FROM HIERARCHY_2
WHERE Hierarchy1Id = (SELECT Id FROM HIERARCHY_1 WHERE Name = @Name);

