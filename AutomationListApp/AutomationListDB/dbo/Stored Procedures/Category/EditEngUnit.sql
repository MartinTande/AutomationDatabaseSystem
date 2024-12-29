
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