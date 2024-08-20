
CREATE PROCEDURE EditCategoryItem
    @TableName nvarchar(128),
    @Name nvarchar(128),
    @Id int
AS

BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
	SET @SQLString = 'UPDATE ' + QUOTENAME(@TableName) + ' SET Name=@Name WHERE Id=@Id'

    -- Execute the dynamic SQL with parameters
    EXEC sp_executesql @SQLString, N'@Name nvarchar(128), @Id int', @Name, @Id
END