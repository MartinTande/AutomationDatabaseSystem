-- Insert sample data into HIERARCHY_1
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Bilge')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Engines')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Cooling')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Fire System')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Utility Systems')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('System')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Propulsion')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Switchboard')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Tanks')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Misc')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('HVAC')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Fuel and Lube Oil')

-- HIERARCHY_2
-- Retrieve Hierarchy1Id for "Cooling"
DECLARE @CoolingHierarchyId INT;
SET @CoolingHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Cooling');

-- Insert subcategories under "Cooling"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('SW Cooling', @CoolingHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('FW Cooling', @CoolingHierarchyId);

-- Retrieve Hierarchy1Id for "Propulsion"
DECLARE @PropulsionHierarchyId INT;
SET @PropulsionHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Propulsion');

-- Insert subcategories under "Propulsion"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Thruster Overview', @PropulsionHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Thruster FWD', @PropulsionHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Thruster AFT', @PropulsionHierarchyId);

-- Retrieve Hierarchy1Id for "Bilge"
DECLARE @BilgeHierarchyId INT;
SET @BilgeHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Bilge');

-- Insert subcategories under "Bilge"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Bilge', @BilgeHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Oily Bilge', @BilgeHierarchyId);

-- Retrieve Hierarchy1Id for "Tanks"
DECLARE @TanksHierarchyId INT;
SET @TanksHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Tanks');

-- Insert subcategories under "Tanks"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Below Deck 1', @TanksHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Below Deck 2', @TanksHierarchyId);

-- Retrieve Hierarchy1Id for "Fire System"
DECLARE @FireSystemHierarchyId INT;
SET @FireSystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Fire System');

-- Insert subcategories under "Fire System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Deck 1', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Deck 2', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Drencher System', @FireSystemHierarchyId);

-- Retrieve Hierarchy1Id for "Utility Systems"
DECLARE @UtilitySystemHierarchyId INT;
SET @UtilitySystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Utility Systems');

-- Insert subcategories under "Utility Systems"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Compressed Air System', @UtilitySystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Hydraulic System', @UtilitySystemHierarchyId);

-- Retrieve Hierarchy1Id for "Misc"
DECLARE @MiscHierarchyId INT;
SET @MiscHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Misc');

-- Insert subcategories under "Misc"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Misc 1', @MiscHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Misc 2', @MiscHierarchyId);

-- Retrieve Hierarchy1Id for "Switchboard"
DECLARE @SwitchboardHierarchyId INT;
SET @SwitchboardHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Switchboard');

-- Insert subcategories under "Switchboard"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Switchboard 1', @SwitchboardHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Switchboard 2', @SwitchboardHierarchyId);

-- Retrieve Hierarchy1Id for "HVAC"
DECLARE @HVACHierarchyId INT;
SET @HVACHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'HVAC');

-- Insert subcategories under "HVAC"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('HVAC 1', @HVACHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('HVAC 2', @HVACHierarchyId);

-- Retrieve Hierarchy1Id for "Fuel and Lube Oil"
DECLARE @FuelAndLubeOilHierarchyId INT;
SET @FuelAndLubeOilHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Fuel and Lube Oil');

-- Insert subcategories under "Fuel and Lube Oil"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Fuel Oil', @FuelAndLubeOilHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Lube Oil', @FuelAndLubeOilHierarchyId);

-- Retrieve Hierarchy1Id for "System"
DECLARE @SystemHierarchyId INT;
SET @SystemHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'System');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('AUT Diagnostics', @SystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Scada Diagnostics', @SystemHierarchyId);

-- Retrieve Hierarchy1Id for "Engines"
DECLARE @EnginesHierarchyId INT;
SET @EnginesHierarchyId = (SELECT Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Engines');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Engine 1', @EnginesHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Engine 2', @EnginesHierarchyId);

-- Insert sample data into VDU_GROUP
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Cooling')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Bilge')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Fire System')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Utility Systems')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Engines')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('System')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Fuel and Lube Oil')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('HVAC')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Misc')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Propulsion')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Switchboard')
INSERT INTO VDU_GROUP (VduGroupName) VALUES ('Tanks')

-- Insert sample data into ALARM_GROUP
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Shutdown')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Load Reduction')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Thrusters')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Switchboard')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Battery')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Machinery')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Bilge')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Fire')
INSERT INTO ALARM_GROUP (AlarmGroupName) VALUES ('Dead Man Alarm')

-- Insert sample data into OTD
INSERT INTO OTD (OtdName) VALUES ('BO_1DI')
INSERT INTO OTD (OtdName) VALUES ('BO_8DI_8DO')
INSERT INTO OTD (OtdName) VALUES ('BO_Diag_Device')
INSERT INTO OTD (OtdName) VALUES ('BO_Diag_Slot')
INSERT INTO OTD (OtdName) VALUES ('BO_Diag_HMI')
INSERT INTO OTD (OtdName) VALUES ('BO_AnalogIn')
INSERT INTO OTD (OtdName) VALUES ('BO_AnalogIn_AllAlarms')
INSERT INTO OTD (OtdName) VALUES ('BO_AnalogOut')
INSERT INTO OTD (OtdName) VALUES ('BO_Breaker')
INSERT INTO OTD (OtdName) VALUES ('IASO_DeadMan')
INSERT INTO OTD (OtdName) VALUES ('BO_DutyStby')
INSERT INTO OTD (OtdName) VALUES ('BO_Motor')
INSERT INTO OTD (OtdName) VALUES ('BO_Motor2D2V')
INSERT INTO OTD (OtdName) VALUES ('BO_MotorFC')
INSERT INTO OTD (OtdName) VALUES ('BO_Precharge')
INSERT INTO OTD (OtdName) VALUES ('BO_PID')
INSERT INTO OTD (OtdName) VALUES ('BO_Valve')
INSERT INTO OTD (OtdName) VALUES ('BO_ValveAI_AO')
INSERT INTO OTD (OtdName) VALUES ('BO_Value')
INSERT INTO OTD (OtdName) VALUES ('BO_Tank')
INSERT INTO OTD (OtdName) VALUES ('BO_TwoSensors2')
INSERT INTO OTD (OtdName) VALUES ('BO_NetworkMonitor')
INSERT INTO OTD (OtdName) VALUES ('NA')

-- Insert sample data into NODE
INSERT INTO NODE (NodeName) VALUES ('PCU1')
INSERT INTO NODE (NodeName) VALUES ('PCU2')

-- Insert sample data into CABINET
INSERT INTO CABINET (CabinetName) VALUES ('C01')
INSERT INTO CABINET (CabinetName) VALUES ('C02')

-- Insert sample data into LOCATION
INSERT INTO LOCATION (LocationName) VALUES ('ECR')
INSERT INTO LOCATION (LocationName) VALUES ('Bridge')
INSERT INTO LOCATION (LocationName) VALUES ('Switchboard Room')
INSERT INTO LOCATION (LocationName) VALUES ('Battery Room')

-- Insert sample data into ACKNOWLEDGE_ALLOWED
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedName) VALUES ('ECR')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedName) VALUES ('Bridge')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedName) VALUES ('Switchboard Room')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedName) VALUES ('Battery Room')

-- Insert sample data into ALWAYS_VISIBLE
INSERT INTO ALWAYS_VISIBLE (AlwaysVisibleName) VALUES ('ECR')
INSERT INTO ALWAYS_VISIBLE (AlwaysVisibleName) VALUES ('Bridge')

-- Insert sample data into SIGNAL_TYPE
INSERT INTO SIGNAL_TYPE (SignalTypeName) VALUES ('DI')
INSERT INTO SIGNAL_TYPE (SignalTypeName) VALUES ('DO')
INSERT INTO SIGNAL_TYPE (SignalTypeName) VALUES ('AI')
INSERT INTO SIGNAL_TYPE (SignalTypeName) VALUES ('AO')
INSERT INTO SIGNAL_TYPE (SignalTypeName) VALUES ('SDI')
INSERT INTO SIGNAL_TYPE (SignalTypeName) VALUES ('SAI')

-- Insert sample data into IO_TYPE
INSERT INTO IO_TYPE (IoTypeName) VALUES ('Analog')
INSERT INTO IO_TYPE (IoTypeName) VALUES ('Digital')