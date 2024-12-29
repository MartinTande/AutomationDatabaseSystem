
CREATE PROCEDURE GetOtdByObjectType
    @ObjectType varchar(150)
AS

BEGIN
    SELECT Name
    FROM OTD
    WHERE Id=(SELECT OtdId FROM OBJECT_TYPE WHERE Name = @ObjectType);
END