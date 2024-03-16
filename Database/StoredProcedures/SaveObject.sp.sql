IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'SaveObject'
	AND type = 'P')
DROP PROCEDURE SaveObject
GO

CREATE PROCEDURE SaveObject
	@ObjectName varchar(100),
	@ObjectType varchar(100)

AS

DECLARE
	@ObjectTypeId int

SELECT @ObjectTypeId=ObjectTypeId FROM OBJECT_TYPE WHERE ObjectType=@ObjectType

INSERT INTO TAG_OBJECT (ObjectName, ObjectTypeId) VALUES (@ObjectName, @ObjectTypeId)

GO