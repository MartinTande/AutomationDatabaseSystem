-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'DeleteCategoryItem'
	AND type = 'P')
DROP PROCEDURE DeleteCategoryItem
GO

CREATE PROCEDURE DeleteCategoryItem
    @TableName nvarchar(128),
    @Id int
AS
BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'DELETE FROM ' + QUOTENAME(@TableName) + ' WHERE Id=' + QUOTENAME(@Id)

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString
END