IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetOtdInterfacesByGroup'
	AND type = 'P')
DROP PROCEDURE GetOtdInterfacesByGroup
GO

CREATE PROCEDURE GetOtdInterfacesByGroup
	@Name varchar(50)
AS

SELECT Id, Name, Suffix, DataType, InterfaceType, IsOptional
FROM OTD_INTERFACE
WHERE OtdId = (SELECT Id FROM OTD WHERE Name = @Name);

GO