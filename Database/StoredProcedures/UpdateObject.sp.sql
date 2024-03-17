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
	@ObjectName varchar(50),
	@ObjectType varchar(50),
	@Hierarchy1 varchar(50),
	@Hierarchy2 varchar(50),
	@EasGroup varchar(50),
	@Otd varchar(50)
AS

UPDATE TAG_OBJECT SET
ObjectName = @ObjectName,
ObjectTypeId = (SELECT ObjectTypeId FROM OBJECT_TYPE WHERE ObjectType=@ObjectType),
Hierarchy1Id = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1=@Hierarchy1),
Hierarchy2Id = (SELECT Hierarchy2Id FROM HIERARCHY_2 WHERE Hierarchy2=@Hierarchy2),
EasGroupId = (SELECT EasGroupId FROM EAS_GROUP WHERE EasGroup=@EasGroup),
OtdId = (SELECT OtdId FROM OTD WHERE Otd=@Otd)

WHERE ObjectId = @ObjectId

GO
