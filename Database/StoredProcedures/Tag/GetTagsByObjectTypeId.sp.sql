-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'GetTagsByObjectTypeId'
    AND type = 'P')
DROP PROCEDURE GetTagsByObjectTypeId
GO

CREATE PROCEDURE GetTagsByObjectTypeId
    @ObjectTypeId int
AS
BEGIN

    SELECT *
    FROM TagData
    WHERE ObjectTypeId = @ObjectTypeId

END