﻿CREATE PROCEDURE GetDatabaseById
	@Id int
AS

BEGIN
	SELECT *
	FROM DATABASE
	WHERE Id = @Id
END;