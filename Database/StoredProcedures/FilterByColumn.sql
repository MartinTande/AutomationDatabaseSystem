CREATE PROCEDURE FilterByColumn
    @ColumnName NVARCHAR(255),
    @ColumnValue NVARCHAR(MAX)
AS
BEGIN
    DECLARE @SqlStatement NVARCHAR(MAX);

    SET @SqlStatement = N'SELECT * FROM GetTagObjectData' +
                        N' WHERE ' + QUOTENAME(@ColumnName) + N' = @ColumnValue;';

    EXEC sp_executesql @SqlStatement,
                       N'@ColumnValue NVARCHAR(MAX)',
                       @ColumnValue;
END;