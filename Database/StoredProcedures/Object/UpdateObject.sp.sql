-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'UpdateObject'
	AND type = 'P')
DROP PROCEDURE UpdateObject
GO

CREATE PROCEDURE UpdateObject
	-- Input parameters
	@Id int,
	@SfiNumber int,
	@MainEqNumber varchar(100),
	@EqNumber varchar(100),
	@Description varchar(100),
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
Description = @Description,
Hierarchy1Id = (SELECT Id FROM HIERARCHY_1 WHERE Name=@Hierarchy1Name),
Hierarchy2Id = (SELECT Id FROM HIERARCHY_2 WHERE Name=@Hierarchy2Name),
VduGroupId = (SELECT Id FROM VDU_GROUP WHERE Name=@VduGroupName),
AlarmGroupId = (SELECT Id FROM ALARM_GROUP WHERE Name=@AlarmGroupName),
OtdId = (SELECT Id FROM OTD WHERE Name=@OtdName),
AcknowledgeAllowedId = (SELECT Id FROM ACKNOWLEDGE_ALLOWED WHERE Name=@AcknowledgeAllowedLocation),
AlwaysVisibleId = (SELECT Id FROM ALWAYS_VISIBLE WHERE Name=@AlwaysVisibleLocation),
NodeId = (SELECT Id FROM NODE WHERE Name=@NodeName),
CabinetId = (SELECT Id FROM CABINET WHERE Name=@CabinetName),
DataBlockId = (SELECT Id FROM DATA_BLOCK WHERE Name=@DataBlockName)

WHERE Id = @Id

GO
