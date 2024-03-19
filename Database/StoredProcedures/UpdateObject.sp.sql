-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'UpdateObject'
	AND type = 'P')
DROP PROCEDURE UpdateObject
GO

CREATE PROCEDURE UpdateObject
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

UPDATE TAG_OBJECT SET
SfiNumber = @SfiNumber,
MainEqNumber = @MainEqNumber,
EqNumber = @EqNumber,
ObjectDescription = @ObjectDescription,
Hierarchy1Id = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1=@Hierarchy1),
Hierarchy2Id = (SELECT Hierarchy2Id FROM HIERARCHY_2 WHERE Hierarchy2=@Hierarchy2),
VduGroupId = (SELECT VduGroupId FROM VDU_GROUP WHERE VduGroup=@VduGroup),
AlarmGroupId = (SELECT AlarmGroupId FROM ALARM_GROUP WHERE AlarmGroup=@AlarmGroup),
OtdId = (SELECT OtdId FROM OTD WHERE Otd=@Otd)
AcknowledgeAllowedId = (SELECT AcknowledgeAllowedId FROM ACKNOWLEDGE_ALLOWED WHERE AcknowledgeAllowed=@AcknowledgeAllowed)
AlwaysVisibleId = (SELECT AlwaysVisibleId FROM ALWAYS_VISIBLE WHERE AlwaysVisible=@AlwaysVisible)
NodeId = (SELECT NodeId FROM NODE WHERE Node=@Node)
CabinetId = (SELECT CabinetId FROM CABINET WHERE Cabinet=@Cabinet)
DataBlockId = (SELECT DataBlockId FROM DATA_BLOCK WHERE DataBlock=@DataBlock)

WHERE ObjectId = @ObjectId

GO
