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


-- Insert sample data into EAS_GROUP
INSERT INTO EAS_GROUP (Name) SELECT 'Cooling' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Cooling')
INSERT INTO EAS_GROUP (Name) SELECT 'Bilge' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Bilge')
INSERT INTO EAS_GROUP (Name) SELECT 'Fire System' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Fire System')
INSERT INTO EAS_GROUP (Name) SELECT 'Utility Systems' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Utility Systems')
INSERT INTO EAS_GROUP (Name) SELECT 'Engines' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Engines')
INSERT INTO EAS_GROUP (Name) SELECT 'System' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'System')
INSERT INTO EAS_GROUP (Name) SELECT 'Fuel and Lube Oil' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Fuel and Lube Oil')
INSERT INTO EAS_GROUP (Name) SELECT 'HVAC' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'HVAC')
INSERT INTO EAS_GROUP (Name) SELECT 'Misc' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Misc')
INSERT INTO EAS_GROUP (Name) SELECT 'Propulsion' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Propulsion')
INSERT INTO EAS_GROUP (Name) SELECT 'Switchboard' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Switchboard')
INSERT INTO EAS_GROUP (Name) SELECT 'Tanks' WHERE NOT EXISTS (SELECT 1 FROM EAS_GROUP WHERE Name = 'Tanks')

-- Insert sample data into ALARM_GROUP
INSERT INTO ALARM_GROUP (Name) SELECT 'Shutdown' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Shutdown')
INSERT INTO ALARM_GROUP (Name) SELECT 'Load Reduction' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Load Reduction')
INSERT INTO ALARM_GROUP (Name) SELECT 'Thrusters' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Thrusters')
INSERT INTO ALARM_GROUP (Name) SELECT 'Switchboard' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Switchboard')
INSERT INTO ALARM_GROUP (Name) SELECT 'Battery' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Battery')
INSERT INTO ALARM_GROUP (Name) SELECT 'Machinery' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Machinery')
INSERT INTO ALARM_GROUP (Name) SELECT 'Bilge' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Bilge')
INSERT INTO ALARM_GROUP (Name) SELECT 'Fire' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Fire')
INSERT INTO ALARM_GROUP (Name) SELECT 'Dead Man Alarm' WHERE NOT EXISTS (SELECT 1 FROM ALARM_GROUP WHERE Name = 'Dead Man Alarm')


-- Insert sample data into LOCATION_GROUP
INSERT INTO LOCATION_GROUP (Name) SELECT 'ECR' WHERE NOT EXISTS (SELECT 1 FROM LOCATION_GROUP WHERE Name = 'ECR')
INSERT INTO LOCATION_GROUP (Name) SELECT 'Bridge' WHERE NOT EXISTS (SELECT 1 FROM LOCATION_GROUP WHERE Name = 'Bridge')
INSERT INTO LOCATION_GROUP (Name) SELECT 'Switchboard Room' WHERE NOT EXISTS (SELECT 1 FROM LOCATION_GROUP WHERE Name = 'Switchboard Room')
INSERT INTO LOCATION_GROUP (Name) SELECT 'Battery Room' WHERE NOT EXISTS (SELECT 1 FROM LOCATION_GROUP WHERE Name = 'Battery Room')