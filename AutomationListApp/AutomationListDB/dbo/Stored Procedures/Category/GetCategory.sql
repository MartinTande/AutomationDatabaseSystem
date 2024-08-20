
CREATE PROCEDURE GetCategory
    @TableName nvarchar(128)
AS
BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'SELECT Id, Name FROM ' + QUOTENAME(@TableName)

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString
END