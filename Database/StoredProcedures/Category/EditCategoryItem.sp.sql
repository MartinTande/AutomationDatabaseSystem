-- Check if View exists and deletes it if yes
IF EXISTS (SELECT name
	FROM sysobjects
	WHERE name = 'GetCategory'
	AND type = 'P')
DROP PROCEDURE GetCategory
GO

CREATE PROCEDURE GetCategory
    @TableName nvarchar(128),
    @Name nvarchar(128),
    @Id int
AS
BEGIN
    DECLARE @SQLString nvarchar(MAX)

    -- Construct the dynamic SQL statement
    SET @SQLString = 'UPDATE ' + QUOTENAME(@TableName) + ' SET Name = ' 
                    + QUOTENAME(@Name) + ', WHERE ') + ' WHERE Id=' + 

    -- Execute the dynamic SQL
    EXEC sp_executesql @SQLString
END