-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'CreateObject'
	AND type = 'P')
DROP PROCEDURE CreateObject
GO

-- Stored Procedure
CREATE PROCEDURE CreateObject
	-- Input parameters
	@SfiNumber int,
	@MainEqNumber varchar(100),
	@EqNumber varchar(100),
	@ObjectDescription varchar(100),
	@Hierarchy1 varchar(50),
	@Hierarchy2 varchar(50),
	@VduGroup varchar(50),
	@AlarmGroup varchar(50),
	@Otd varchar(50),
	@AcknowledgeAllowed varchar(100),
	@AlwaysVisible varchar(100),
	@Node varchar(100),
	@Cabinet varchar(100),
	@DataBlock varchar(100),
AS

DECLARE
	-- Internal variables
	@Hierarchy1Id int,
	@Hierarchy2Id int,
	@VduGroupId int,
	@AlarmGroupId int,
	@OtdId int,
	@AcknowledgeAllowedId int,
	@AlwaysVisibleId int,
	@NodeId int,
	@CabinetId int,
	@DataBlockId int

SELECT @Hierarchy1Id=Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1=@Hierarchy1
SELECT @Hierarchy2Id=Hierarchy2Id FROM HIERARCHY_2 WHERE Hierarchy2=@Hierarchy2
SELECT @VduGroupId=VduGroupId FROM VDU_GROUP WHERE VduGroup=@VduGroup
SELECT @AlarmGroupId=AlarmGroupId FROM ALARM_GROUP WHERE AlarmGroup=@AlarmGroup
SELECT @OtdId=OtdId FROM OTD WHERE Otd=@Otd
SELECT @AcknowledgeAllowedId=AcknowledgeAllowedId FROM ACKNOWLEDGE_ALLOWED WHERE AcknowledgeAllowed=@AcknowledgeAllowed
SELECT @AlwaysVisibleId=AlwaysVisibleId FROM ALWAYS_VISIBLE WHERE AlwaysVisible=@AlwaysVisible
SELECT @NodeId=NodeId FROM NODE WHERE Node=@Node
SELECT @CabinetId=CabinetId FROM CABINET WHERE Cabinet=@Cabinet
SELECT @DataBlockId=DataBlockId FROM DATA_BLOCK WHERE DataBlock=@DataBlock

INSERT INTO TAG_OBJECT (SfiNumber, MainEqNumber, EqNumber, ObjectDescription, Hierarchy1Id, Hierarchy2Id, VduGroupId, AlarmGroupId, OtdId, AcknowledgeAllowedId, AlwaysVisibleId, NodeId, CabinetId, DataBlockId) 
VALUES (@SfiNumber, @MainEqNumber, @EqNumber, @ObjectDescription, @Hierarchy1Id, @Hierarchy2Id, @VduGroupId, @AlarmGroupId, @OtdId, @AcknowledgeAllowedId, @AlwaysVisibleId, @NodeId, @CabinetId, @DataBlockId)

GO