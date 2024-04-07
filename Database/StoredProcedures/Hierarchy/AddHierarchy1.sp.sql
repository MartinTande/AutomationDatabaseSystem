-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'AddHierarchy1'
	AND type = 'P')
DROP PROCEDURE AddHierarchy1
GO

-- Stored Procedure
CREATE PROCEDURE AddHierarchy1
	-- Input parameters
	@Name varchar(50)
AS

INSERT INTO HIERARCHY_1 (Name)
VALUES (@Name)

GO