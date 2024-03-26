-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetObjectById'
	AND type = 'P')
DROP PROCEDURE GetObjectById
GO

CREATE PROCEDURE GetObjectById
	@Id int
AS

BEGIN

SELECT *
FROM ObjectData
WHERE ObjectId=@Id;

END;