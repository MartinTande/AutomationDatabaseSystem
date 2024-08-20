
CREATE PROCEDURE UpdateObject
	-- Input parameters
	@Id int,
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

-- Checks to see if the VduGroup input is present in the table, if not it inserts it
IF NOT EXISTS (SELECT *
FROM VDU_GROUP
WHERE Name = @VduGroup)
INSERT INTO VDU_GROUP
	(Name)
VALUES
	(@VduGroup)


UPDATE OBJECT SET
	SfiNumber = @SfiNumber,
	MainEqNumber = @MainEqNumber,
	EqNumber = @EqNumber,
	Description = @Description,
	VduGroupId = (SELECT Id
FROM VDU_GROUP
WHERE Name=@VduGroup),
	Hierarchy1Id = (SELECT Id
FROM HIERARCHY_1
WHERE Name = @Hierarchy1),
	Hierarchy2Id = (SELECT Id
FROM HIERARCHY_2
WHERE Name = @Hierarchy2),
	EasGroupId = (SELECT Id
FROM EAS_GROUP
WHERE Name = @EasGroup),
	AlarmGroupId = (SELECT Id
FROM ALARM_GROUP
WHERE Name = @AlarmGroup),
	OtdId = (SELECT Id
FROM OTD
WHERE Name=@Otd),
	ObjectTypeId = (SELECT Id
FROM OBJECT_TYPE
WHERE Name=@ObjectType),
	AcknowledgeAllowedId = (SELECT Id
FROM LOCATION_GROUP
WHERE Name=@AcknowledgeAllowed),
	AlwaysVisibleId = (SELECT Id
FROM LOCATION_GROUP
WHERE Name=@AlwaysVisible),
	NodeId = (SELECT Id
FROM NODE
WHERE Name=@Node),
	CabinetId = (SELECT Id
FROM CABINET
WHERE Name=@Cabinet),
	Revision = @Revision,
	LastModified = getdate()

WHERE Id = @Id

