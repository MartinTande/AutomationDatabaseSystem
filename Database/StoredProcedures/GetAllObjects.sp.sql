-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetAllObjects'
	AND type = 'P')
DROP PROCEDURE GetAllObjects
GO

CREATE PROCEDURE GetAllObjects

AS

BEGIN
SELECT *
FROM ObjectData

END;