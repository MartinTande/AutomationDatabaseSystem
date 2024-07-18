IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetSignalTypesByIoType'
	AND type = 'P')
DROP PROCEDURE GetSignalTypesByIoType
GO

CREATE PROCEDURE GetSignalTypesByIoType
    @IoTypeName VARCHAR(50)
AS

BEGIN
    SELECT ST.Name
    FROM SIGNAL_TYPE ST
    INNER JOIN IO_SIGNAL_TYPE IST ON ST.Id = IST.SignalTypeId
    INNER JOIN IO_TYPE IT ON IST.IoTypeId = IT.Id
    WHERE IT.Name = @IoTypeName;
END