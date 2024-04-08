-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'CreateTag'
	AND type = 'P')
DROP PROCEDURE CreateTag
GO

-- Stored Procedure
CREATE PROCEDURE CreateTag
	-- Input parameters
	@ObjectId int,
	@Suffix int,
	@Description varchar(100),
	@SignalTypeName varchar(50),
	@IoTypeName varchar(50),
	@LowLimit varchar(50),
	@LowLowLimit varchar(50),
	@HighLimit varchar(50),
	@HighHighLimit varchar(100)
AS
BEGIN
	DECLARE
		-- Internal variables
		@SignalTypeId int,
		@IoTypeId int,
		@InsertedTagId int; -- Scalar variable to store the inserted tag's ID

	SELECT @SignalTypeId = Id FROM SIGNAL_TYPE WHERE Name = @SignalTypeName;
	SELECT @IoTypeId = Id FROM IO_TYPE WHERE Name = @IoTypeName;

	-- Insert the tag
	INSERT INTO TAG (Suffix, Description, SignalTypeId, IoTypeId, LowLimit, LowLowLimit, HighLimit, HighHighLimit) 
	VALUES (@Suffix, @Description, @SignalTypeId, @IoTypeId, @LowLimit, @LowLowLimit, @HighLimit, @HighHighLimit);

	-- Get the inserted tag's ID
	SELECT @InsertedTagId=IDENT_CURRENT('TAG')
	
	-- Insert tag and object Id into joint table
	INSERT INTO OBJECT_TAG (TagId, ObjectId)
	VALUES (@InsertedTagId, @ObjectId);

END