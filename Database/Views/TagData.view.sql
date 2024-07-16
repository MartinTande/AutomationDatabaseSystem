-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
FROM sysobjects
WHERE name = 'TagData'
	AND type = 'V')
DROP VIEW TagData
GO

-- View
CREATE VIEW TagData

AS

	SELECT
		TAG.Id,
		TAG.ObjectId,
		TAG.EqSuffix,
		TAG.Description,
		IO_TYPE.Name IoType,
		SIGNAL_TYPE.Name SignalType,
		ENG_UNIT.Name EngUnit,
		TAG.RangeLow,
		TAG.RangeHigh,
		TAG.LowLowLimit,
		TAG.LowLimit,
		TAG.HighLimit,
		TAG.HighHighLimit,
		TAG.Slot,
		TAG.AbsoluteAddress,
		TAG.SWPath,
		TAG.DBName,
		TAG.ModbusAddress,
		TAG.ModbusBit,
		TAG.IsE0,
		TAG.IsVDR
	FROM TAG
		LEFT JOIN IO_TYPE ON TAG.IoTypeId = IO_TYPE.Id
		LEFT JOIN SIGNAL_TYPE ON TAG.SignalTypeId = SIGNAL_TYPE.Id
		LEFT JOIN ENG_UNIT ON TAG.EngUnitId = ENG_UNIT.Id

GO