
CREATE PROCEDURE GetAllDatabases

AS

BEGIN
	SELECT Id, Name, DateCreated
	FROM [dbo].[DATABASE]
END;