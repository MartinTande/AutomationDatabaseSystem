﻿
CREATE PROCEDURE GetAllDatabases

AS

BEGIN
	SELECT Id, Name, DateCreated
	FROM DATABASE
END;