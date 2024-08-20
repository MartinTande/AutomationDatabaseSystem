
-- Stored Procedure
CREATE PROCEDURE AddCategoryItem
	-- Input parameters
    @TableName varchar(100),
    @Name varchar(100)
AS

BEGIN

    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'IF NOT EXISTS (SELECT 1 FROM ' + QUOTENAME(@TableName) + ' WHERE Name = @Name) 
                        INSERT INTO ' + QUOTENAME(@TableName) + ' (Name) VALUES (@Name)'

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString, N'@Name nvarchar(100)', @Name

END