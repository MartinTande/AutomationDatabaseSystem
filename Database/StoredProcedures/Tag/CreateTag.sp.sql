-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'CreateTag'
	AND type = 'P')
DROP PROCEDURE CreateTag
GO

-- Stored Procedure
CREATE PROCEDURE CreateTag
	-- Input parameters
	@ObjectId int,
	@EqSuffix varchar(50),
	@Description varchar(100),
	@IoType varchar(50),
	@SignalType varchar(50),
	@EngUnit varchar(50),
	@LowLimit int,
	@LowLowLimit int,
	@HighLimit int,
	@HighHighLimit int,
	@RangeLow int,
	@RangeHigh int,
	@Slot int,
	@AbsoluteAddress varchar(50),
	@SWPath varchar(150),
	@DBName varchar(150),
	@ModbusAddress int,
	@ModbusBit int,
	@IsE0 bit,
	@IsVDR bit
AS
BEGIN
	DECLARE
		-- Internal variables
		@IoTypeId int,
		@SignalTypeId int,
		@EngUnitId int,
		@InsertedTagId int;
	-- Scalar variable to store the inserted tag's ID

	SELECT @IoTypeId = Id
	FROM IO_TYPE
	WHERE Name = @IoType;
	SELECT @SignalTypeId = Id
	FROM SIGNAL_TYPE
	WHERE Name = @SignalType;
	SELECT @EngUnitId = Id
	FROM ENG_UNIT
	WHERE Name = @EngUnit;

	-- Insert the tag
	INSERT INTO TAG
		(ObjectId, EqSuffix, Description, IoTypeId, SignalTypeId, EngUnitId, RangeLow, RangeHigh, LowLowLimit, LowLimit, HighLimit, HighHighLimit,
		Slot, AbsoluteAddress, SWPath, DBName, ModbusAddress, ModbusBit, IsE0, IsVDR, LastModified)
	VALUES
		(@ObjectId, @EqSuffix, @Description, @IoTypeId, @SignalTypeId, @EngUnitId, @RangeLow, @RangeHigh, @LowLowLimit, @LowLimit, @HighLimit, @HighHighLimit,
			@Slot, @AbsoluteAddress, @SWPath, @DBName, @ModbusAddress, @ModbusBit, @IsE0, @IsVDR, getdate());

END