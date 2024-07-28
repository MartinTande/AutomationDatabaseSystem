-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'GetEngUnits'
    AND type = 'P')
DROP PROCEDURE GetEngUnits
GO

CREATE PROCEDURE GetEngUnits
AS

BEGIN
    SELECT Id, Name, UnitId
    FROM
        ENG_UNIT
END