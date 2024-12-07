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

-- Insert sample data into OTD
INSERT INTO OTD (Name) SELECT 'BO_1DI' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_1DI')
INSERT INTO OTD (Name) SELECT 'BO_1DO' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_1DO')
INSERT INTO OTD (Name) SELECT 'BO_8DI_8DO' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_8DI_8DO')
INSERT INTO OTD (Name) SELECT 'BO_Diag_Device' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Diag_Device')
INSERT INTO OTD (Name) SELECT 'BO_Diag_Slot' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Diag_Slot')
INSERT INTO OTD (Name) SELECT 'BO_Diag_HMI' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Diag_HMI')
INSERT INTO OTD (Name) SELECT 'BO_AnalogIn' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_AnalogIn')
INSERT INTO OTD (Name) SELECT 'BO_AnalogIn_AllAlarms' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_AnalogIn_AllAlarms')
INSERT INTO OTD (Name) SELECT 'BO_AnalogOut' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_AnalogOut')
INSERT INTO OTD (Name) SELECT 'BO_Breaker' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Breaker')
INSERT INTO OTD (Name) SELECT 'IASO_DeadMan' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'IASO_DeadMan')
INSERT INTO OTD (Name) SELECT 'BO_DutyStby' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_DutyStby')
INSERT INTO OTD (Name) SELECT 'BO_Motor' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Motor')
INSERT INTO OTD (Name) SELECT 'BO_Motor2D2V' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Motor2D2V')
INSERT INTO OTD (Name) SELECT 'BO_MotorFC' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_MotorFC')
INSERT INTO OTD (Name) SELECT 'BO_Precharge' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Precharge')
INSERT INTO OTD (Name) SELECT 'BO_PID' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_PID')
INSERT INTO OTD (Name) SELECT 'BO_Valve' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Valve')
INSERT INTO OTD (Name) SELECT 'BO_ValveAI_AO' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_ValveAI_AO')
INSERT INTO OTD (Name) SELECT 'BO_ValveAI_AO_Eltorque' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_ValveAI_AO_Eltorque')
INSERT INTO OTD (Name) SELECT 'BO_Value' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Value')
INSERT INTO OTD (Name) SELECT 'BO_Tank' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_Tank')
INSERT INTO OTD (Name) SELECT 'BO_TwoSensors' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_TwoSensors')
INSERT INTO OTD (Name) SELECT 'BO_TwoSensors2' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_TwoSensors2')
INSERT INTO OTD (Name) SELECT 'BO_NetworkMonitor' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'BO_NetworkMonitor')
INSERT INTO OTD (Name) SELECT 'NA' WHERE NOT EXISTS (SELECT 1 FROM OTD WHERE Name = 'NA')