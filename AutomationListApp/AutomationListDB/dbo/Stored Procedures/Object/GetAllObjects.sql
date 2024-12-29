
CREATE PROCEDURE GetAllObjects

AS

BEGIN
	SELECT *
	FROM ObjectData
	ORDER BY 
		SfiNumber ASC,
		MainEqNumber ASC,
		EqNumber ASC
END;