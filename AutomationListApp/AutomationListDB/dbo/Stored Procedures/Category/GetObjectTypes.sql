
CREATE PROCEDURE GetObjectTypes
AS

BEGIN
    SELECT objectType.Id, objectType.Name, otd.Name AS OtdName
    FROM OBJECT_TYPE objectType
        JOIN OTD otd ON objectType.OtdId = otd.Id;
END