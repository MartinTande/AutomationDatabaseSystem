
-- Stored Procedure
CREATE PROCEDURE AddSignalType
	-- Input parameters
	@IoTypeId varchar(50),
	@SignalTypeName varchar(50)
AS

BEGIN
	SET NOCOUNT ON;

	-- Check if the SIGNAL_TYPE already exists
	IF NOT EXISTS (SELECT 1
	FROM SIGNAL_TYPE
	WHERE Name = @SignalTypeName)
    BEGIN
		-- Insert the new SIGNAL_TYPE
		INSERT INTO SIGNAL_TYPE
			(Name)
		VALUES
			(@SignalTypeName);
	END

	-- Insert the connection in IO_SIGNAL_TYPE
	DECLARE @SignalTypeId INT;
	SELECT @SignalTypeId = Id
	FROM SIGNAL_TYPE
	WHERE Name = @SignalTypeName;

	IF @SignalTypeId IS NOT NULL
    BEGIN
		INSERT INTO IO_SIGNAL_TYPE
			(IoTypeId, SignalTypeId)
		VALUES
			(@IoTypeId, @SignalTypeId);
	END
END