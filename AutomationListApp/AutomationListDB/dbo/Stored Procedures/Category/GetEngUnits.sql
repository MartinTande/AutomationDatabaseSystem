﻿
CREATE PROCEDURE GetEngUnits
AS

BEGIN
    SELECT Id, Name, UnitId
    FROM
        ENG_UNIT
END