-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'GetTagsByObjectType'
    AND type = 'P')
DROP PROCEDURE GetTagsByObjectType
GO

CREATE PROCEDURE GetTagsByObjectType
    @ObjectType varchar(150)
AS

DECLARE
-- Internal variables
    @ObjectTypeId int
BEGIN
    SELECT @ObjectTypeId = Id
    FROM IO_TYPE
    WHERE Name = @ObjectType

    SELECT *
    FROM TagData
    WHERE ObjectTypeId = @ObjectTypeId

END