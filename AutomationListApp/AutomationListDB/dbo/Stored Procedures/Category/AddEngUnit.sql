
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