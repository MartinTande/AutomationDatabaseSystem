
-- Stored Procedure
CREATE PROCEDURE AddHierarchy2
	-- Input parameters
	@Hierarchy1Name varchar(50),
	@Hierarchy2Name varchar(50)
AS

DECLARE
	-- Internal variables
	@Hierarchy1Id int

SELECT @Hierarchy1Id=Id FROM HIERARCHY_1 WHERE Name=@Hierarchy1Name

INSERT INTO HIERARCHY_2 (Hierarchy1Id, Name)
VALUES (@Hierarchy1Id, @Hierarchy2Name)

