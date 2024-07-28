-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'DeleteIoType'
    AND type = 'P')
DROP PROCEDURE DeleteIoType
GO

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