﻿
CREATE PROCEDURE GetObjectById
	@Id int
AS

BEGIN

SELECT *
FROM ObjectData
WHERE Id=@Id;

END;