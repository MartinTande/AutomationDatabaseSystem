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


-- Insert sample data into HIERARCHY_1
INSERT INTO HIERARCHY_1 (Name) SELECT 'Bilge' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Bilge');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Engines' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Engines');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Cooling' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Cooling');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Fire System' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Fire System');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Utility Systems' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Utility Systems');
INSERT INTO HIERARCHY_1 (Name) SELECT 'System' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'System');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Propulsion' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Propulsion');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Switchboard' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Switchboard');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Tanks' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Tanks');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Misc' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Misc');
INSERT INTO HIERARCHY_1 (Name) SELECT 'HVAC' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'HVAC');
INSERT INTO HIERARCHY_1 (Name) SELECT 'Fuel and Lube Oil' WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_1 WHERE Name = 'Fuel and Lube Oil');


-- HIERARCHY_2
-- Insert subcategories under "Cooling"
DECLARE @CoolingHierarchyId INT;
SET @CoolingHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Cooling');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'SW Cooling', @CoolingHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'SW Cooling');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'FW Cooling', @CoolingHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'FW Cooling');

-- Insert subcategories under "Propulsion"
DECLARE @PropulsionHierarchyId INT;
SET @PropulsionHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Propulsion');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Thruster Overview', @PropulsionHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Thruster Overview');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Thruster FWD', @PropulsionHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Thruster FWD');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Thruster AFT', @PropulsionHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Thruster AFT');

-- Insert subcategories under "Bilge"
DECLARE @BilgeHierarchyId INT;
SET @BilgeHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Bilge');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Bilge', @BilgeHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Bilge');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Oily Bilge', @BilgeHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Oily Bilge');

-- Insert subcategories under "Tanks"
DECLARE @TanksHierarchyId INT;
SET @TanksHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Tanks');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Below Deck 1', @TanksHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Below Deck 1');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Below Deck 2', @TanksHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Below Deck 2');

-- Insert subcategories under "Fire System"
DECLARE @FireSystemHierarchyId INT;
SET @FireSystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Fire System');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Deck 1', @FireSystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Deck 1');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Deck 2', @FireSystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Deck 2');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Drencher System', @FireSystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Drencher System');

-- Insert subcategories under "Utility Systems"
DECLARE @UtilitySystemHierarchyId INT;
SET @UtilitySystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Utility Systems');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Compressed Air System', @UtilitySystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Compressed Air System');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Hydraulic System', @UtilitySystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Hydraulic System');

-- Insert subcategories under "Misc"
DECLARE @MiscHierarchyId INT;
SET @MiscHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Misc');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Misc 1', @MiscHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Misc 1');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Misc 2', @MiscHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Misc 2');

-- Insert subcategories under "Switchboard"
DECLARE @SwitchboardHierarchyId INT;
SET @SwitchboardHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Switchboard');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Switchboard 1', @SwitchboardHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Switchboard 1');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Switchboard 2', @SwitchboardHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Switchboard 2');

-- Insert subcategories under "HVAC"
DECLARE @HVACHierarchyId INT;
SET @HVACHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'HVAC');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'HVAC 1', @HVACHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'HVAC 1');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'HVAC 2', @HVACHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'HVAC 2');

-- Insert subcategories under "Fuel and Lube Oil"
DECLARE @FuelAndLubeOilHierarchyId INT;
SET @FuelAndLubeOilHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Fuel and Lube Oil');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Fuel Oil', @FuelAndLubeOilHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Fuel Oil');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Lube Oil', @FuelAndLubeOilHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Lube Oil');

-- Insert subcategories under "System"
DECLARE @SystemHierarchyId INT;
SET @SystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'System');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'AUT Diagnostics', @SystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'AUT Diagnostics');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Scada Diagnostics', @SystemHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Scada Diagnostics');

-- Insert subcategories under "Engines"
DECLARE @EnginesHierarchyId INT;
SET @EnginesHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Engines');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Engine 1', @EnginesHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Engine 1');
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) SELECT 'Engine 2', @EnginesHierarchyId WHERE NOT EXISTS (SELECT 1 FROM HIERARCHY_2 WHERE Name = 'Engine 2');