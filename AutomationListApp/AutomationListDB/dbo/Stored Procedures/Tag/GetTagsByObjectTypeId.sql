
CREATE PROCEDURE GetTagsByObjectTypeId
    @ObjectTypeId int
AS
BEGIN

    SELECT *
    FROM TagData
    WHERE ObjectTypeId = @ObjectTypeId

END