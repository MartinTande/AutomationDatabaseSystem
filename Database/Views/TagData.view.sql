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
TAG.Description,
TAG.LowLimit,
TAG.LowLowLimit,
TAG.HighLimit,
TAG.HighHighLimit,
SIGNAL_TYPE.Name SignalTypeName,
IO_TYPE.Name IoTypeName

FROM TAG
INNER JOIN SIGNAL_TYPE ON TAG.SignalTypeId = SIGNAL_TYPE.Id
INNER JOIN IO_TYPE ON TAG.IoTypeId = IO_TYPE.Id

GO