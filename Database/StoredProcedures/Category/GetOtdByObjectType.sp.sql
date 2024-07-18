-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'GetOtdByObjectType'
    AND type = 'P')
DROP PROCEDURE GetOtdByObjectType
GO

CREATE PROCEDURE GetOtdByObjectType
    @ObjectType varchar(150)
AS

BEGIN
    SELECT Name
    FROM OTD
    WHERE Id=(SELECT OtdId
    FROM OBJECT_TYPE
    WHERE Name = @ObjectType);
END