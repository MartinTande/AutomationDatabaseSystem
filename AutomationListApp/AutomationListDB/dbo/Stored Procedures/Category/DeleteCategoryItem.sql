
CREATE PROCEDURE DeleteCategoryItem
    @TableName nvarchar(128),
    @Id int
AS

BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'DELETE FROM ' + QUOTENAME(@TableName) + ' WHERE Id=@Id'

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString, N'@Id int', @Id
END