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
	@ObjectType varchar(50),
	@Hierarchy1 varchar(50),
	@Hierarchy2 varchar(50),
	@EasGroup varchar(50),
	@Otd varchar(50),
	@AcknowledgeAllowed varchar(100),
	@AlwaysVisible varchar(100)
AS

DECLARE
	-- Internal variables
	@ObjectTypeId int,
	@Hierarchy1Id varchar(50),
	@Hierarchy2Id varchar(50),
	@EasGroupId varchar(50),
	@OtdId varchar(50)

SELECT @ObjectTypeId=ObjectTypeId FROM OBJECT_TYPE WHERE ObjectType=@ObjectType
SELECT @Hierarchy1Id=Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1=@Hierarchy1
SELECT @Hierarchy2Id=Hierarchy2Id FROM HIERARCHY_2 WHERE Hierarchy2=@Hierarchy2
SELECT @EasGroupId=EasGroupId FROM EAS_GROUP WHERE EasGroup=@EasGroup
SELECT @OtdId=OtdId FROM OTD WHERE Otd=@Otd

INSERT INTO TAG_OBJECT (ObjectName, ObjectTypeId, Hierarchy1Id, Hierarchy2Id, EasGroupId, OtdId) 
VALUES (@ObjectName, @ObjectTypeId, @Hierarchy1Id, @Hierarchy2Id, @EasGroupId, @OtdId)

GO