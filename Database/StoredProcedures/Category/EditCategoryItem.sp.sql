-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'EditCategoryItem'
	AND type = 'P')
DROP PROCEDURE EditCategoryItem
GO

CREATE PROCEDURE EditCategoryItem
    @TableName nvarchar(128),
    @Name nvarchar(128)
AS
BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'UPDATE ' + QUOTENAME(@TableName) + ' SET Name = ' 
                    + QUOTENAME(@Name) + ', WHERE ') + ' WHERE Id=' + 

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString
END