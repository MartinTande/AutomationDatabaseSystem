
-- Stored Procedure
CREATE PROCEDURE UpdateTag
	-- Input parameters
	@Id int,
	@ObjectId int,
	@EqSuffix varchar(50),
	@Description varchar(100),
	@IoType varchar(50),
	@SignalType varchar(50),
	@Symbol varchar(50),
	@EngUnit varchar(50),
	@AlarmDelay varchar(50),
	@LowLimit int,
	@LowLowLimit int,
	@HighLimit int,
	@HighHighLimit int,
	@RangeLow int,
	@RangeHigh int,
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
	@IOStatus varchar(100)
AS

DECLARE
-- Internal variables
    @IoTypeId int,
    @SignalTypeId int,
    @EngUnitId int,
	@SymbolId int

SELECT @IoTypeId = Id
FROM IO_TYPE
WHERE Name = @IoType
SELECT @SignalTypeId = Id
FROM SIGNAL_TYPE
WHERE Name = @SignalType
SELECT @EngUnitId = Id
FROM ENG_UNIT
WHERE Name = @EngUnit
SELECT @SymbolId = Id 
FROM SYMBOL 
WHERE Name = @Symbol;

UPDATE TAG SET
	ObjectId = @ObjectId,
    EqSuffix = @EqSuffix,
    Description = @Description,
	SymbolId = @SymbolId,
    IoTypeId = @IoTypeId,
    SignalTypeId = @SignalTypeId,
    EngUnitId = @EngUnitId,
    LowLimit = @LowLimit,
    LowLowLimit = @LowLowLimit,
    HighLimit = @HighLimit,
    HighHighLimit = @HighHighLimit,
    RangeLow = @RangeLow,
    RangeHigh = @RangeHigh,
    Slot = @Slot,
    AbsoluteAddress = @AbsoluteAddress,
    SWPath = @SWPath,
    DBName = @DBName,
    ModbusAddress = @ModbusAddress,
    ModbusBit = @ModbusBit,
    IsE0 = @IsE0,
    IsVDR = @IsVDR,
	LastModified = getdate(),
	TP1 = @TP1,
	TP2 = @TP2,
	TP3 = @TP3,
	TP4 = @TP4,
	Channel = @Channel,
	IOStatus = @IOStatus,
	AlarmDelay = @AlarmDelay

WHERE Id = @Id

