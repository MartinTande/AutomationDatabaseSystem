-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'DeleteTag'
	AND type = 'P')
DROP PROCEDURE DeleteTag
GO

-- Stored Procedure
CREATE PROCEDURE DeleteTag
	-- Input parameters
    @Id int
AS

-- Need to delete reference of Tag in connection table first
DELETE
FROM OBJECT_TAG
WHERE TagId=@Id

DELETE
FROM TAG 
WHERE Id=@Id

GO