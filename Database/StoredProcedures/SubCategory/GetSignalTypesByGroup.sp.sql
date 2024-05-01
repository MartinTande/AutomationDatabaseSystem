IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetSignalTypesByGroup'
	AND type = 'P')
DROP PROCEDURE GetSignalTypesByGroup
GO

CREATE PROCEDURE GetSignalTypesByGroup
	@Name varchar(50)
AS

SELECT Id, Name
FROM SIGNAL_TYPE
WHERE IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = @Name);

GO