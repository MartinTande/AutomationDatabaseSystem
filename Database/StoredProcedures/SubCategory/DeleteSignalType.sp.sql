-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'DeleteSignalType'
	AND type = 'P')
DROP PROCEDURE DeleteSignalType
GO

-- Stored Procedure
CREATE PROCEDURE DeleteSignalType
	-- Input parameters
	@IoTypeId int,
	@SignalTypeId int
AS

BEGIN
	DELETE
	FROM IO_SIGNAL_TYPE
	WHERE SignalTypeId=@SignalTypeId AND IoTypeId=@IoTypeId

	IF NOT EXISTS (SELECT 1
	FROM IO_SIGNAL_TYPE
	WHERE SignalTypeId = @SignalTypeId)
	DELETE
	FROM SIGNAL_TYPE
	WHERE Id=@SignalTypeId
END