
-- Stored Procedure
CREATE PROCEDURE CreateTag
	-- Input parameters
	@ObjectId int,
	@EqSuffix varchar(50),
	@Description varchar(100),
	@IoType varchar(50),
	@SignalType varchar(50),
	@Symbol varchar(50),
	@EngUnit varchar(50),
	@AlarmDelay varchar(50),
	@RangeLow int,
	@RangeHigh int,
	@LowLowLimit int,
	@LowLimit int,
	@HighLimit int,
	@HighHighLimit int,
	@Slot int,
	@Channel int,
	@TP1 int,
	@TP2 int,
	@TP3 int,
	@TP4 int,
	@AbsoluteAddress varchar(50),
	@SWPath varchar(150),
	@DBName varchar(150),
	@ModbusAddress int,
	@ModbusBit int,
	@IsE0 bit,
	@IsVDR bit,
	@IOStatus varchar(100),
	@InterfaceModule varchar(100),
	@UserLock bit,
	@IOLock bit,
	@BeijerBoxId int
AS
BEGIN
	DECLARE
		-- Internal variables
		@IoTypeId int,
		@SignalTypeId int,
		@EngUnitId int,
		@SymbolId int,
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
	WHERE Name = @EngUnit
	SELECT @SymbolId = Id 
	FROM SYMBOL 
	WHERE Name = @Symbol;

	-- Insert the tag
	INSERT INTO TAG
		(ObjectId, EqSuffix, Description, IoTypeId, SignalTypeId, EngUnitId, SymbolId, RangeLow, RangeHigh, LowLowLimit, LowLimit, HighLimit, HighHighLimit,
		Slot, Channel, TP1, TP2, TP3, TP4, AbsoluteAddress, SWPath, DBName, ModbusAddress, ModbusBit, IsE0, IsVDR, IOStatus, InterfaceModule, UserLock, IOLock, BeijerBoxId, LastModified)
	VALUES
		(@ObjectId, @EqSuffix, @Description, @IoTypeId, @SignalTypeId, @EngUnitId, @SymbolId, @RangeLow, @RangeHigh, @LowLowLimit, @LowLimit, @HighLimit, @HighHighLimit,
			@Slot, @Channel, @TP1, @TP2, @TP3, @TP4, @AbsoluteAddress, @SWPath, @DBName, @ModbusAddress, @ModbusBit, @IsE0, @IsVDR, @IOStatus, @InterfaceModule, @UserLock, @IOLock, @BeijerBoxId, getdate());

END