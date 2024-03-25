-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'FilterByColumn'
	AND type = 'P')
DROP PROCEDURE FilterByColumn
GO

CREATE PROCEDURE FilterByColumn
    @ColumnName VARCHAR(255),
    @ColumnValues VARCHAR(255)
AS

BEGIN

SELECT *
FROM GetTagObjectData
WHERE @ColumnName = @ColumnValues

END;