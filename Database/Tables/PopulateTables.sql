-- Insert sample data into HIERARCHY_1
INSERT INTO HIERARCHY_1 (Name) VALUES ('Bilge')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Engines')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Cooling')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Fire System')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Utility Systems')
INSERT INTO HIERARCHY_1 (Name) VALUES ('System')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Propulsion')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Switchboard')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Tanks')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Misc')
INSERT INTO HIERARCHY_1 (Name) VALUES ('HVAC')
INSERT INTO HIERARCHY_1 (Name) VALUES ('Fuel and Lube Oil')

-- HIERARCHY_2
-- Retrieve Hierarchy1Id for "Cooling"
DECLARE @CoolingHierarchyId INT;
SET @CoolingHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Cooling');

-- Insert subcategories under "Cooling"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('SW Cooling', @CoolingHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('FW Cooling', @CoolingHierarchyId);

-- Retrieve Hierarchy1Id for "Propulsion"
DECLARE @PropulsionHierarchyId INT;
SET @PropulsionHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Propulsion');

-- Insert subcategories under "Propulsion"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Thruster Overview', @PropulsionHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Thruster FWD', @PropulsionHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Thruster AFT', @PropulsionHierarchyId);

-- Retrieve Hierarchy1Id for "Bilge"
DECLARE @BilgeHierarchyId INT;
SET @BilgeHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Bilge');

-- Insert subcategories under "Bilge"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Bilge', @BilgeHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Oily Bilge', @BilgeHierarchyId);

-- Retrieve Hierarchy1Id for "Tanks"
DECLARE @TanksHierarchyId INT;
SET @TanksHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Tanks');

-- Insert subcategories under "Tanks"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Below Deck 1', @TanksHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Below Deck 2', @TanksHierarchyId);

-- Retrieve Hierarchy1Id for "Fire System"
DECLARE @FireSystemHierarchyId INT;
SET @FireSystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Fire System');

-- Insert subcategories under "Fire System"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Deck 1', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Deck 2', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Drencher System', @FireSystemHierarchyId);

-- Retrieve Hierarchy1Id for "Utility Systems"
DECLARE @UtilitySystemHierarchyId INT;
SET @UtilitySystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Utility Systems');

-- Insert subcategories under "Utility Systems"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Compressed Air System', @UtilitySystemHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Hydraulic System', @UtilitySystemHierarchyId);

-- Retrieve Hierarchy1Id for "Misc"
DECLARE @MiscHierarchyId INT;
SET @MiscHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Misc');

-- Insert subcategories under "Misc"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Misc 1', @MiscHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Misc 2', @MiscHierarchyId);

-- Retrieve Hierarchy1Id for "Switchboard"
DECLARE @SwitchboardHierarchyId INT;
SET @SwitchboardHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Switchboard');

-- Insert subcategories under "Switchboard"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Switchboard 1', @SwitchboardHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Switchboard 2', @SwitchboardHierarchyId);

-- Retrieve Hierarchy1Id for "HVAC"
DECLARE @HVACHierarchyId INT;
SET @HVACHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'HVAC');

-- Insert subcategories under "HVAC"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('HVAC 1', @HVACHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('HVAC 2', @HVACHierarchyId);

-- Retrieve Hierarchy1Id for "Fuel and Lube Oil"
DECLARE @FuelAndLubeOilHierarchyId INT;
SET @FuelAndLubeOilHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Fuel and Lube Oil');

-- Insert subcategories under "Fuel and Lube Oil"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Fuel Oil', @FuelAndLubeOilHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Lube Oil', @FuelAndLubeOilHierarchyId);

-- Retrieve Hierarchy1Id for "System"
DECLARE @SystemHierarchyId INT;
SET @SystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'System');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('AUT Diagnostics', @SystemHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Scada Diagnostics', @SystemHierarchyId);

-- Retrieve Hierarchy1Id for "Engines"
DECLARE @EnginesHierarchyId INT;
SET @EnginesHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Name = 'Engines');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Engine 1', @EnginesHierarchyId);
INSERT INTO HIERARCHY_2 (Name, Hierarchy1Id) VALUES ('Engine 2', @EnginesHierarchyId);

-- Insert sample data into VDU_GROUP
INSERT INTO VDU_GROUP (Name) VALUES ('Cooling')
INSERT INTO VDU_GROUP (Name) VALUES ('Bilge')
INSERT INTO VDU_GROUP (Name) VALUES ('Fire System')
INSERT INTO VDU_GROUP (Name) VALUES ('Utility Systems')
INSERT INTO VDU_GROUP (Name) VALUES ('Engines')
INSERT INTO VDU_GROUP (Name) VALUES ('System')
INSERT INTO VDU_GROUP (Name) VALUES ('Fuel and Lube Oil')
INSERT INTO VDU_GROUP (Name) VALUES ('HVAC')
INSERT INTO VDU_GROUP (Name) VALUES ('Misc')
INSERT INTO VDU_GROUP (Name) VALUES ('Propulsion')
INSERT INTO VDU_GROUP (Name) VALUES ('Switchboard')
INSERT INTO VDU_GROUP (Name) VALUES ('Tanks')

-- Insert sample data into ALARM_GROUP
INSERT INTO ALARM_GROUP (Name) VALUES ('Shutdown')
INSERT INTO ALARM_GROUP (Name) VALUES ('Load Reduction')
INSERT INTO ALARM_GROUP (Name) VALUES ('Thrusters')
INSERT INTO ALARM_GROUP (Name) VALUES ('Switchboard')
INSERT INTO ALARM_GROUP (Name) VALUES ('Battery')
INSERT INTO ALARM_GROUP (Name) VALUES ('Machinery')
INSERT INTO ALARM_GROUP (Name) VALUES ('Bilge')
INSERT INTO ALARM_GROUP (Name) VALUES ('Fire')
INSERT INTO ALARM_GROUP (Name) VALUES ('Dead Man Alarm')

-- Insert sample data into OTD
INSERT INTO OTD (Name) VALUES ('BO_1DI')
INSERT INTO OTD (Name) VALUES ('BO_8DI_8DO')
INSERT INTO OTD (Name) VALUES ('BO_Diag_Device')
INSERT INTO OTD (Name) VALUES ('BO_Diag_Slot')
INSERT INTO OTD (Name) VALUES ('BO_Diag_HMI')
INSERT INTO OTD (Name) VALUES ('BO_AnalogIn')
INSERT INTO OTD (Name) VALUES ('BO_AnalogIn_AllAlarms')
INSERT INTO OTD (Name) VALUES ('BO_AnalogOut')
INSERT INTO OTD (Name) VALUES ('BO_Breaker')
INSERT INTO OTD (Name) VALUES ('IASO_DeadMan')
INSERT INTO OTD (Name) VALUES ('BO_DutyStby')
INSERT INTO OTD (Name) VALUES ('BO_Motor')
INSERT INTO OTD (Name) VALUES ('BO_Motor2D2V')
INSERT INTO OTD (Name) VALUES ('BO_MotorFC')
INSERT INTO OTD (Name) VALUES ('BO_Precharge')
INSERT INTO OTD (Name) VALUES ('BO_PID')
INSERT INTO OTD (Name) VALUES ('BO_Valve')
INSERT INTO OTD (Name) VALUES ('BO_ValveAI_AO')
INSERT INTO OTD (Name) VALUES ('BO_Value')
INSERT INTO OTD (Name) VALUES ('BO_Tank')
INSERT INTO OTD (Name) VALUES ('BO_TwoSensors2')
INSERT INTO OTD (Name) VALUES ('BO_NetworkMonitor')
INSERT INTO OTD (Name) VALUES ('NA')

-- Insert sample data into NODE
INSERT INTO NODE (Name) VALUES ('PCU1')
INSERT INTO NODE (Name) VALUES ('PCU2')

-- Insert sample data into CABINET
INSERT INTO CABINET (Name) VALUES ('C01')
INSERT INTO CABINET (Name) VALUES ('C02')

-- Insert sample data into LOCATION
INSERT INTO LOCATION (Name) VALUES ('ECR')
INSERT INTO LOCATION (Name) VALUES ('Bridge')
INSERT INTO LOCATION (Name) VALUES ('Switchboard Room')
INSERT INTO LOCATION (Name) VALUES ('Battery Room')

-- Insert sample data into ACKNOWLEDGE_ALLOWED
INSERT INTO ACKNOWLEDGE_ALLOWED (Name) VALUES ('ECR')
INSERT INTO ACKNOWLEDGE_ALLOWED (Name) VALUES ('Bridge')
INSERT INTO ACKNOWLEDGE_ALLOWED (Name) VALUES ('Switchboard Room')
INSERT INTO ACKNOWLEDGE_ALLOWED (Name) VALUES ('Battery Room')

-- Insert sample data into ALWAYS_VISIBLE
INSERT INTO ALWAYS_VISIBLE (Name) VALUES ('ECR')
INSERT INTO ALWAYS_VISIBLE (Name) VALUES ('Bridge')

-- Insert sample data into SIGNAL_TYPE
INSERT INTO SIGNAL_TYPE (Name) VALUES ('DI')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('DO')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('AI')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('AO')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('SDI')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('SAI')

-- Insert sample data into IO_TYPE
INSERT INTO IO_TYPE (Name) VALUES ('Analog')
INSERT INTO IO_TYPE (Name) VALUES ('Digital')