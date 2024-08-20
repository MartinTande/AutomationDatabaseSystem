﻿
-- View
CREATE VIEW TagData

AS

	SELECT
		TAG.Id,
		TAG.ObjectId,
		TAG.ObjectTypeId,
		TAG.EqSuffix,
		TAG.Description,
		SYMBOL.Name Symbol,
		IO_TYPE.Name IoType,
		SIGNAL_TYPE.Name SignalType,
		ENG_UNIT.Name EngUnit,
		TAG.AlarmDelay,
		TAG.RangeLow,
		TAG.RangeHigh,
		TAG.LowLowLimit,
		TAG.LowLimit,
		TAG.HighLimit,
		TAG.HighHighLimit,
		TAG.Slot,
		TAG.Channel,
		TAG.TP1,
		TAG.TP2,
		TAG.TP3,
		TAG.TP4,
		TAG.AbsoluteAddress,
		TAG.SWPath,
		TAG.DBName,
		TAG.ModbusAddress,
		TAG.ModbusBit,
		TAG.IsE0,
		TAG.IsVDR,
		TAG.IOStatus,
		TAG.LastModified
	FROM TAG
		LEFT JOIN IO_TYPE ON TAG.IoTypeId = IO_TYPE.Id
		LEFT JOIN SIGNAL_TYPE ON TAG.SignalTypeId = SIGNAL_TYPE.Id
		LEFT JOIN ENG_UNIT ON TAG.EngUnitId = ENG_UNIT.Id
		LEFT JOIN SYMBOL ON TAG.SymbolId = SYMBOL.Id

