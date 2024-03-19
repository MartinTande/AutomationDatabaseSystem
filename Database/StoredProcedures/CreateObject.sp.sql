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
	@Hierarchy1Name varchar(50),
	@Hierarchy2Name varchar(50),
	@VduGroupName varchar(50),
	@AlarmGroupName varchar(50),
	@OtdName varchar(50),
	@AcknowledgeAllowedLocation varchar(100),
	@AlwaysVisibleLocation varchar(100),
	@NodeName varchar(100),
	@CabinetName varchar(100),
	@DataBlockName varchar(100)
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

SELECT @Hierarchy1Id=Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name=@Hierarchy1Name
SELECT @Hierarchy2Id=Hierarchy2Id FROM HIERARCHY_2 WHERE Hierarchy2Name=@Hierarchy2Name
SELECT @VduGroupId=VduGroupId FROM VDU_GROUP WHERE VduGroupName=@VduGroupName
SELECT @AlarmGroupId=AlarmGroupId FROM ALARM_GROUP WHERE AlarmGroupName=@AlarmGroupName
SELECT @OtdId=OtdId FROM OTD WHERE OtdName=@OtdName
SELECT @AcknowledgeAllowedId=AcknowledgeAllowedId FROM ACKNOWLEDGE_ALLOWED WHERE AcknowledgeAllowedLocation=@AcknowledgeAllowedLocation
SELECT @AlwaysVisibleId=AlwaysVisibleId FROM ALWAYS_VISIBLE WHERE AlwaysVisibleLocation=@AlwaysVisibleLocation
SELECT @NodeId=NodeId FROM NODE WHERE NodeName=@NodeName
SELECT @CabinetId=CabinetId FROM CABINET WHERE CabinetName=@CabinetName
SELECT @DataBlockId=DataBlockId FROM DATA_BLOCK WHERE DataBlockName=@DataBlockName

INSERT INTO TAG_OBJECT (SfiNumber, MainEqNumber, EqNumber, ObjectDescription, Hierarchy1Id, Hierarchy2Id, VduGroupId, AlarmGroupId, OtdId, AcknowledgeAllowedId, AlwaysVisibleId, NodeId, CabinetId, DataBlockId) 
VALUES (@SfiNumber, @MainEqNumber, @EqNumber, @ObjectDescription, @Hierarchy1Id, @Hierarchy2Id, @VduGroupId, @AlarmGroupId, @OtdId, @AcknowledgeAllowedId, @AlwaysVisibleId, @NodeId, @CabinetId, @DataBlockId)

GO