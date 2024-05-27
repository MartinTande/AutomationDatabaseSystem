-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'UpdateTag'
	AND type = 'P')
DROP PROCEDURE UpdateTag
GO

-- Stored Procedure
CREATE PROCEDURE UpdateTag
	-- Input parameters
	@Id int,
	@EqSuffix int,
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

DECLARE
-- Internal variables
    @IoTypeId int,
    @SignalTypeId int,
    @EngUnitId int

SELECT @IoTypeId = Id FROM IO_TYPE WHERE Name = @IoType
SELECT @SignalTypeId = Id FROM SIGNAL_TYPE WHERE Name = @SignalType
SELECT @EngUnitId = Id FROM ENG_UNIT WHERE Name = @EngUnit

UPDATE TAG SET
    EqSuffix = @EqSuffix,
    Description = @Description,
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
    IsVDR = @IsVDR

WHERE Id = @Id

GO
