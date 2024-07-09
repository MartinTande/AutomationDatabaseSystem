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
	@VduGroup varchar(100),
	@Hierarchy1 varchar(50),
	@Hierarchy2 varchar(50),
	@EasGroup varchar(50),
	@AlarmGroup varchar(50),
	@Otd varchar(50),
	@AcknowledgeAllowed varchar(100),
	@AlwaysVisible varchar(100),
	@Node varchar(100),
	@Cabinet varchar(100)
AS

UPDATE OBJECT SET
	SfiNumber = @SfiNumber,
	MainEqNumber = @MainEqNumber,
	EqNumber = @EqNumber,
	Description = @Description,
	VduGroup = @VduGroup,
	Hierarchy1Id = (SELECT Id FROM HIERARCHY_1 WHERE Name = @Hierarchy1),
	Hierarchy2Id = (SELECT Id FROM HIERARCHY_2 WHERE Name = @Hierarchy2),
	EasGroupId = (SELECT Id FROM EAS_GROUP WHERE Name = @EasGroup),
	AlarmGroupId = (SELECT Id FROM ALARM_GROUP WHERE Name = @AlarmGroup),
	OtdId = (SELECT Id FROM OTD WHERE Name=@Otd),
	AcknowledgeAllowedId = (SELECT Id FROM ACKNOWLEDGE_ALLOWED WHERE Name=@AcknowledgeAllowed),
	AlwaysVisibleId = (SELECT Id FROM ALWAYS_VISIBLE WHERE Name=@AlwaysVisible),
	NodeId = (SELECT Id FROM NODE WHERE Name=@Node),
	CabinetId = (SELECT Id FROM CABINET WHERE Name=@Cabinet)

WHERE Id = @Id

GO
