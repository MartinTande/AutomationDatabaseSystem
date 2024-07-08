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
    @Id int
AS
	-- Declare a temporary table to store the TagIds
    CREATE TABLE #TempTagIds (TagId INT)

    -- Insert the relevant TagIds into the temporary table
    INSERT INTO #TempTagIds (TagId)
    SELECT TagId
    FROM OBJECT_TAG
    WHERE ObjectId = @Id

    -- Delete the corresponding tags from the OBJECT_TAG table
    DELETE
    FROM OBJECT_TAG
    WHERE ObjectId = @Id

    -- Delete the corresponding rows from the TAG table
    DELETE
    FROM TAG
    WHERE Id IN (SELECT TagId FROM #TempTagIds)

    -- Clean up: drop the temporary table
    DROP TABLE #TempTagIds

	-- Delete the object from the OBJECT table
	DELETE 
	FROM OBJECT 
	WHERE Id=@Id

GO