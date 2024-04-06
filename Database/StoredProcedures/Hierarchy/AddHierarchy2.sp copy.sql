-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'AddHierarchy2'
	AND type = 'P')
DROP PROCEDURE AddHierarchy2
GO

-- Stored Procedure
CREATE PROCEDURE AddHierarchy2
	-- Input parameters
	@Hierarchy1Name varchar(50),
	@Hierarchy2Name varchar(50)
AS

DECLARE
	-- Internal variables
	@Hierarchy1Id int

SELECT @Hierarchy1Id=Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name=@Hierarchy1Name

INSERT INTO HIERARCHY_2 (Hierarchy1Id, Hierarchy2Name)
VALUES (@Hierarchy1Id, @Hierarchy2Name)

GO