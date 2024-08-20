
CREATE PROCEDURE GetTagsByObjectType
    @ObjectType varchar(150)
AS

DECLARE
-- Internal variables
    @ObjectTypeId int
BEGIN
    SELECT @ObjectTypeId = Id
    FROM OBJECT_TYPE
    WHERE Name = @ObjectType

    SELECT *
    FROM TagData
    WHERE ObjectTypeId = @ObjectTypeId

END