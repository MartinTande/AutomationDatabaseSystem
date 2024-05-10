-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetLastInsertedObjectId'
	AND type = 'P')
DROP PROCEDURE GetLastInsertedObjectId
GO

-- Stored Procedure
CREATE PROCEDURE GetLastInsertedObjectId
	-- Input parameters
AS

DECLARE
	-- Internal variables
	@LastInsertedObjectId int

    SET @LastInsertedObjectId=IDENT_CURRENT('OBJECT')

    -- Return the result
    SELECT @LastInsertedObjectId AS LastInsertedObjectId;
GO