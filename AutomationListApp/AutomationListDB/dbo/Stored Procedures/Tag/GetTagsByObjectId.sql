
CREATE PROCEDURE GetTagsByObjectId
    @ObjectId int
AS
BEGIN

    SELECT *
    FROM TagData
    WHERE ObjectId = @ObjectId

END