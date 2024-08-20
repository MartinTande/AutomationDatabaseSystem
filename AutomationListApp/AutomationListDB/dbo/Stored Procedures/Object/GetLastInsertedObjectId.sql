
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
