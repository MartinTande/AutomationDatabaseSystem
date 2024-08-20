
-- Stored Procedure
CREATE PROCEDURE DeleteIoType
    -- Input parameters
    @Id int
AS

BEGIN
    DELETE 
    FROM IO_SIGNAL_TYPE
	WHERE IoTypeId=@Id

    DELETE FROM IO_TYPE
    WHERE Id=@Id
END