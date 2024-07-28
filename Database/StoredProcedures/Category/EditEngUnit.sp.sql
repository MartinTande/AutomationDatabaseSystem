-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'EditEngUnit'
    AND type = 'P')
DROP PROCEDURE EditEngUnit
GO

CREATE PROCEDURE EditEngUnit
    @Id int,
    @Name varchar(50),
    @UnitId int
AS

BEGIN
    UPDATE ENG_UNIT
    SET
    Name=@Name,
    UnitId=@UnitId
    WHERE Id=@Id
END