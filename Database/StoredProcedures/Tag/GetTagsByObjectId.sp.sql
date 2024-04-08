-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetTagsByObjectId'
	AND type = 'P')
DROP PROCEDURE GetTagsByObjectId
GO

CREATE PROCEDURE GetTagsByObjectId
    @ObjectId int
AS
BEGIN
    -- Declare a temporary table to store the TagIds
    CREATE TABLE #TempTagIds (TagId INT)

    -- Insert the relevant TagIds into the temporary table
    INSERT INTO #TempTagIds (TagId)
    SELECT TagId
    FROM OBJECT_TAG
    WHERE ObjectId = @ObjectId

    -- Retrieve the corresponding tags from the TAG table
    SELECT *
    FROM TAG
    WHERE Id IN (SELECT TagId FROM #TempTagIds)

    -- Clean up: drop the temporary table
    DROP TABLE #TempTagIds
END