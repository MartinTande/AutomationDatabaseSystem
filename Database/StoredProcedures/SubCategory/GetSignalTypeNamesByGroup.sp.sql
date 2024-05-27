IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetSignalTypeNamesByGroup'
	AND type = 'P')
DROP PROCEDURE GetSignalTypeNamesByGroup
GO

CREATE PROCEDURE GetSignalTypeNamesByGroup
	@Name varchar(50)
AS

SELECT Name
FROM SIGNAL_TYPE
WHERE IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = @Name);

GO