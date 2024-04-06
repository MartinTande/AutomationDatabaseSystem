-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'DeleteObject'
	AND type = 'P')
DROP PROCEDURE DeleteObject
GO

-- Stored Procedure
CREATE PROCEDURE DeleteObject
	-- Input parameters
    @ObjectId int
AS

DELETE 
FROM TAG_OBJECT 
WHERE ObjectId=@ObjectId

GO