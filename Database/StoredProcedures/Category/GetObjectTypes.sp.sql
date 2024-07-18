-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'GetObjectTypes'
    AND type = 'P')
DROP PROCEDURE GetObjectTypes
GO

CREATE PROCEDURE GetObjectTypes
AS

BEGIN
    SELECT objectType.Id, objectType.Name, otd.Name AS OtdName
    FROM OBJECT_TYPE objectType
        JOIN OTD otd ON objectType.OtdId = otd.Id;
END