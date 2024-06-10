-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'AddOtdInterface'
	AND type = 'P')
DROP PROCEDURE AddOtdInterface
GO

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

SELECT @OtdId=Id FROM OTD WHERE Name=@OtdName

INSERT INTO OTD_INTERFACE (OtdId, Name, Suffix, DataType, InterfaceType, IsOptional)
VALUES (@OtdId, @OtdInterfaceName, @Suffix, @DataType, @InterfaceType, @IsOptional)

GO