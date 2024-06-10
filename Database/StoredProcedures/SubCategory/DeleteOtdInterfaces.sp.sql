-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'DeleteOtdInterfaces'
	AND type = 'P')
DROP PROCEDURE DeleteOtdInterfaces
GO

-- Stored Procedure
CREATE PROCEDURE DeleteOtdInterfaces
	-- Input parameters
AS

DELETE
FROM OTD_INTERFACE

GO