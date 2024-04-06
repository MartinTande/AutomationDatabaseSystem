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

SELECT @Hierarchy1Id=Id FROM HIERARCHY_1 WHERE Name=@Hierarchy1Name
SELECT @Hierarchy2Id=Id FROM HIERARCHY_2 WHERE Name=@Hierarchy2Name
SELECT @VduGroupId=Id FROM VDU_GROUP WHERE Name=@VduGroupName
SELECT @AlarmGroupId=Id FROM ALARM_GROUP WHERE Name=@AlarmGroupName
SELECT @OtdId=Id FROM OTD WHERE Name=@OtdName
SELECT @AcknowledgeAllowedId=Id FROM ACKNOWLEDGE_ALLOWED WHERE Name=@AcknowledgeAllowedLocation
SELECT @AlwaysVisibleId=Id FROM ALWAYS_VISIBLE WHERE Name=@AlwaysVisibleLocation
SELECT @NodeId=Id FROM NODE WHERE Name=@NodeName
SELECT @CabinetId=Id FROM CABINET WHERE Name=@CabinetName
IF NOT EXISTS (SELECT * FROM DATA_BLOCK WHERE Name = @DataBlockName)
INSERT INTO DATA_BLOCK (Name) VALUES (@DataBlockName)

INSERT INTO TAG_OBJECT (SfiNumber, MainEqNumber, EqNumber, Description, Hierarchy1Id, Hierarchy2Id, VduGroupId, AlarmGroupId, OtdId, AcknowledgeAllowedId, AlwaysVisibleId, NodeId, CabinetId, DataBlockId) 
VALUES (@SfiNumber, @MainEqNumber, @EqNumber, @Description, @Hierarchy1Id, @Hierarchy2Id, @VduGroupId, @AlarmGroupId, @OtdId, @AcknowledgeAllowedId, @AlwaysVisibleId, @NodeId, @CabinetId, 
		(SELECT Id FROM DATA_BLOCK WHERE Name=@DataBlockName))

GO