
-- Stored Procedure
CREATE PROCEDURE AddOtdInterface
	-- Input parameters
	@OtdName varchar(50),
	@OtdInterfaceName varchar(100),
	@Suffix varchar(100),
	@DataType varchar(100),
	@InterfaceType varchar(150),
	@IsOptional bit
AS

DECLARE
	-- Internal variables
	@OtdId int
BEGIN
	SELECT @OtdId=Id FROM OTD WHERE Name=@OtdName

	INSERT INTO OTD_INTERFACE 
		(OtdId, Name, Suffix, DataType, InterfaceType, IsOptional)
	VALUES 
		(@OtdId, @OtdInterfaceName, @Suffix, @DataType, @InterfaceType, @IsOptional)
END;
