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

    SELECT *
    FROM TagData
    WHERE ObjectId = @ObjectId

END