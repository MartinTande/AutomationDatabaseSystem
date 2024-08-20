
CREATE PROCEDURE GetOtdInterfacesByOtd
	@Name varchar(50)
AS

SELECT Id, Name, Suffix, DataType, InterfaceType, IsOptional
FROM OTD_INTERFACE
WHERE OtdId = (SELECT Id FROM OTD WHERE Name = @Name);

