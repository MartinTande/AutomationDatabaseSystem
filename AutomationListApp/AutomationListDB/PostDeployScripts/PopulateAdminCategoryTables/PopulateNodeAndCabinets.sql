/*
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


-- Insert sample data into NODE
INSERT INTO NODE (Name) SELECT 'PCU1' WHERE NOT EXISTS (SELECT 1 FROM NODE WHERE Name = 'PCU1')
INSERT INTO NODE (Name) SELECT 'PCU2' WHERE NOT EXISTS (SELECT 1 FROM NODE WHERE Name = 'PCU2')

-- Insert sample data into CABINET
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) SELECT 'C01', 'Main cabinet C01 with PLC', 1, 55 WHERE NOT EXISTS (SELECT 1 FROM CABINET WHERE Name = 'C01');
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) SELECT 'C02', 'Main cabinet C02 with PLC', 1, 50 WHERE NOT EXISTS (SELECT 1 FROM CABINET WHERE Name = 'C02');
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) SELECT 'C03', 'Remote I/O cabinet C03', 1, 50 WHERE NOT EXISTS (SELECT 1 FROM CABINET WHERE Name = 'C03');
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) SELECT 'C04', 'Remote I/O cabinet C04', 1, 50 WHERE NOT EXISTS (SELECT 1 FROM CABINET WHERE Name = 'C04');
