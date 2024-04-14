-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetCategoryNames'
	AND type = 'P')
DROP PROCEDURE GetCategoryNames
GO

CREATE PROCEDURE GetCategoryNames
    @TableName nvarchar(128)
AS
BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'SELECT Name FROM ' + QUOTENAME(@TableName)

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString
END