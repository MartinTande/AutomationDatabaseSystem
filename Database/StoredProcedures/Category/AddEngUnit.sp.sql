-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'AddEngUnit'
    AND type = 'P')
DROP PROCEDURE AddEngUnit
GO

CREATE PROCEDURE AddEngUnit
    @Name varchar(50),
    @UnitId int
AS

BEGIN
    INSERT INTO ENG_UNIT
        (Name, UnitId)
    VALUES
        (@Name, @UnitId)
END