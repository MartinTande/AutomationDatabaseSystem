

-- Stored Procedure
CREATE PROCEDURE CreateObject
	-- Input parameters
	@SfiNumber varchar(50),
	@MainEqNumber varchar(100),
	@EqNumber varchar(100),
	@Description varchar(100),
	@VduGroup varchar(100),
	@Hierarchy1 varchar(50),
	@Hierarchy2 varchar(50),
	@EasGroup varchar(50),
	@AlarmGroup varchar(50),
	@Otd varchar(50),
	@ObjectType varchar(150),
	@AcknowledgeAllowed varchar(100),
	@AlwaysVisible varchar(100),
	@Node varchar(100),
	@Cabinet varchar(100),
	@Revision varchar(50)
AS

BEGIN
	DECLARE
		-- Internal variables
		@VduGroupId int,
		@Hierarchy1Id int,
		@Hierarchy2Id int,
		@EasGroupId int,
		@AlarmGroupId int,
		@OtdId int,
		@ObjectTypeId int,
		@AcknowledgeAllowedId int,
		@AlwaysVisibleId int,
		@NodeId int,
		@CabinetId int

	-- Checks to see if the VduGroup input is present in the table, if not it inserts it
	IF NOT EXISTS (SELECT *
	FROM VDU_GROUP
	WHERE Name = @VduGroup)
	INSERT INTO VDU_GROUP
		(Name)
	VALUES
		(@VduGroup)

	SELECT @VduGroupId=Id FROM VDU_GROUP WHERE Name=@VduGroup
	SELECT @Hierarchy1Id=Id FROM HIERARCHY_1 WHERE Name=@Hierarchy1
	SELECT @Hierarchy2Id=Id FROM HIERARCHY_2 WHERE Name=@Hierarchy2
	SELECT @EasGroupId=Id FROM EAS_GROUP WHERE Name=@EasGroup
	SELECT @AlarmGroupId=Id FROM ALARM_GROUP WHERE Name=@AlarmGroup
	SELECT @OtdId=Id FROM OTD WHERE Name=@Otd
	SELECT @ObjectTypeId=Id FROM OBJECT_TYPE WHERE Name=@ObjectType
	SELECT @AcknowledgeAllowedId=Id FROM LOCATION_GROUP WHERE Name=@AcknowledgeAllowed
	SELECT @AlwaysVisibleId=Id FROM LOCATION_GROUP WHERE Name=@AlwaysVisible
	SELECT @NodeId=Id FROM NODE WHERE Name=@Node
	SELECT @CabinetId=Id FROM CABINET WHERE Name=@Cabinet

	INSERT INTO OBJECT
		(SfiNumber, MainEqNumber, EqNumber, Description, VduGroupId, Hierarchy1Id, Hierarchy2Id, EasGroupId, AlarmGroupId, OtdId, ObjectTypeId, AcknowledgeAllowedId, AlwaysVisibleId, NodeId, CabinetId, Revision, LastModified)
	VALUES
		(@SfiNumber, @MainEqNumber, @EqNumber, @Description, @VduGroupId, @Hierarchy1Id, @Hierarchy2Id, @EasGroupId, @AlarmGroupId, @OtdId, @ObjectTypeId, @AcknowledgeAllowedId, @AlwaysVisibleId, @NodeId, @CabinetId, @Revision, getdate())

END;