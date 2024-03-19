-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'UpdateObject'
	AND type = 'P')
DROP PROCEDURE UpdateObject
GO

CREATE PROCEDURE UpdateObject
	-- Input parameters
	@ObjectId int,
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

UPDATE TAG_OBJECT SET
SfiNumber = @SfiNumber,
MainEqNumber = @MainEqNumber,
EqNumber = @EqNumber,
ObjectDescription = @ObjectDescription,
Hierarchy1Id = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name=@Hierarchy1Name),
Hierarchy2Id = (SELECT Hierarchy2Id FROM HIERARCHY_2 WHERE Hierarchy2Name=@Hierarchy2Name),
VduGroupId = (SELECT VduGroupId FROM VDU_GROUP WHERE VduGroupName=@VduGroupName),
AlarmGroupId = (SELECT AlarmGroupId FROM ALARM_GROUP WHERE AlarmGroupName=@AlarmGroupName),
OtdId = (SELECT OtdId FROM OTD WHERE OtdName=@OtdName),
AcknowledgeAllowedId = (SELECT AcknowledgeAllowedId FROM ACKNOWLEDGE_ALLOWED WHERE AcknowledgeAllowedLocation=@AcknowledgeAllowedLocation),
AlwaysVisibleId = (SELECT AlwaysVisibleId FROM ALWAYS_VISIBLE WHERE AlwaysVisibleLocation=@AlwaysVisibleLocation),
NodeId = (SELECT NodeId FROM NODE WHERE NodeName=@NodeName),
CabinetId = (SELECT CabinetId FROM CABINET WHERE CabinetName=@CabinetName),
DataBlockId = (SELECT DataBlockId FROM DATA_BLOCK WHERE DataBlockName=@DataBlockName)

WHERE ObjectId = @ObjectId

GO
