﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET NOCOUNT ON


-- Insert sample data into ENG_UNIT if not already exists
IF NOT EXISTS (SELECT 1 FROM ENG_UNIT WHERE Name = 'V' AND UnitId = 1000)
    INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('V', 1000);
IF NOT EXISTS (SELECT 1 FROM ENG_UNIT WHERE Name = 'deg C' AND UnitId = 1001)
    INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('deg C', 1001);
IF NOT EXISTS (SELECT 1 FROM ENG_UNIT WHERE Name = 'bar' AND UnitId = 1002)
    INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('bar', 1002);
IF NOT EXISTS (SELECT 1 FROM ENG_UNIT WHERE Name = 'rpm' AND UnitId = 1003)
    INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('rpm', 1003);
IF NOT EXISTS (SELECT 1 FROM ENG_UNIT WHERE Name = '%' AND UnitId = 1004)
    INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('%', 1004);