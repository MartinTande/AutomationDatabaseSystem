-- Check if Stored Procedure exists and deletes it if it does
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'AddCategoryItem'
	AND type = 'P')
DROP PROCEDURE AddCategoryItem
GO

-- Stored Procedure
CREATE PROCEDURE AddCategoryItem
	-- Input parameters
    @TableName varchar(100),
    @Name varchar(100)
AS

BEGIN

    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'INSERT INTO ' + QUOTENAME(@TableName) + ' (Name) VALUES (@Name)'

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString, N'@Name nvarchar(100)', @Name

END