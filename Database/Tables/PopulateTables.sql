SET NOCOUNT ON

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

-- Insert sample data into EAS_GROUP
INSERT INTO EAS_GROUP (Name) VALUES ('Cooling')
INSERT INTO EAS_GROUP (Name) VALUES ('Bilge')
INSERT INTO EAS_GROUP (Name) VALUES ('Fire System')
INSERT INTO EAS_GROUP (Name) VALUES ('Utility Systems')
INSERT INTO EAS_GROUP (Name) VALUES ('Engines')
INSERT INTO EAS_GROUP (Name) VALUES ('System')
INSERT INTO EAS_GROUP (Name) VALUES ('Fuel and Lube Oil')
INSERT INTO EAS_GROUP (Name) VALUES ('HVAC')
INSERT INTO EAS_GROUP (Name) VALUES ('Misc')
INSERT INTO EAS_GROUP (Name) VALUES ('Propulsion')
INSERT INTO EAS_GROUP (Name) VALUES ('Switchboard')
INSERT INTO EAS_GROUP (Name) VALUES ('Tanks')

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
INSERT INTO OTD (Name) VALUES ('BO_TwoSensors')
INSERT INTO OTD (Name) VALUES ('BO_TwoSensors2')
INSERT INTO OTD (Name) VALUES ('BO_NetworkMonitor')
INSERT INTO OTD (Name) VALUES ('NA')

-- Insert sample data into NODE
INSERT INTO NODE (Name) VALUES ('PCU1')
INSERT INTO NODE (Name) VALUES ('PCU2')

-- Insert sample data into CABINET
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) VALUES ('C01', 'Main cabinet C01 with PLC', 1, 55)
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) VALUES ('C02', 'Main cabinet C02 with PLC', 1, 50)
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) VALUES ('C03', 'Remote I/O cabinet C03', 1, 50)
INSERT INTO CABINET (Name, Description, NoIMs, NoSlotsPerIM) VALUES ('C04', 'Remote I/O cabinet C04', 1, 50)

-- Insert sample data into LOCATION_GROUP
INSERT INTO LOCATION_GROUP (Name) VALUES ('ECR')
INSERT INTO LOCATION_GROUP (Name) VALUES ('Bridge')
INSERT INTO LOCATION_GROUP (Name) VALUES ('Switchboard Room')
INSERT INTO LOCATION_GROUP (Name) VALUES ('Battery Room')

-- Insert sample data into IO_TYPE
INSERT INTO IO_TYPE (Name) VALUES ('DI')
INSERT INTO IO_TYPE (Name) VALUES ('DO')
INSERT INTO IO_TYPE (Name) VALUES ('AI')
INSERT INTO IO_TYPE (Name) VALUES ('AO')
INSERT INTO IO_TYPE (Name) VALUES ('SDI')
INSERT INTO IO_TYPE (Name) VALUES ('SDO')
INSERT INTO IO_TYPE (Name) VALUES ('SAI')
INSERT INTO IO_TYPE (Name) VALUES ('SAO')

-- Insert sample data into SIGNAL_TYPE
INSERT INTO SIGNAL_TYPE (Name) VALUES ('NC')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('NO')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('NC, 230V Relay')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('NO, 230V Relay')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('Int')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('Real')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('Float')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('Word')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('Double')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('U_B_AnalogValueLong')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('4-20mA, 2W')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('4-20mA, 3W')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('4-20mA, 4W')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('PT100, 3W')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('PT100, 4W')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('TC')
INSERT INTO SIGNAL_TYPE (Name) VALUES ('0-10V')

-- Insert sample data into MODULE_TYPE
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('DI 8×24VDC ST', '6ES7131-6BF00-0BA0', 8,1,0,0,0,1)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('RQ 4×24VUC/2A CO ST', '6ES7132-6GD50-0BA0', 4,0,0,0,4,1)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('AI 4×I 2-/4-wire ST', '6ES7134-6GD00-0BA1', 4,8,0,0,0,1)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('AI 4×RTD/TC 2-/3-/4-wire HF', '6ES7134-6JD00-0CA1', 4,8,0,0,0,1)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('AI 4xU/I 2-wire ST', '6ES7134-6HD00-0BA1', 4,8,0,0,0,1)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('AQ 4×U/I ST', '6ES7135-6HD00-0BA1', 4,0,0,8,0,1)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('TM Count 1x24V', '6ES7138-6AA00-0BA0', 1,16,0,12,0,0)
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) VALUES ('CM PtP communication module', '6ES7137-6AA00-0BA0', 1,8,0,0,0,0)

-- Insert sample data into MODULE_CONFIG
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC, 230V Relay'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO, 230V Relay'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 4W'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 2W'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 3W'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 4W'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'TC'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4xU/I 2-wire ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST'))
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V'), (SELECT Id FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST'))


-- Insert connections into IO_SIGNAL_TYPE
-- DI
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'))
-- DO
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO, 230V Relay'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC, 230V Relay'))
-- SDI
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'))
-- SDO
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SDO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SDO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'))
-- AI
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 4W'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 3W'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 4W'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'TC'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V'))
-- AO
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'AO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V'))
-- SAI
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Int'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Real'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Float'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Word'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Double'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_B_AnalogValueLong'))
-- SAO
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Int'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Real'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Float'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Word'))
INSERT INTO IO_SIGNAL_TYPE (IoTypeId, SignalTypeId) VALUES ((SELECT Id FROM IO_TYPE WHERE Name = 'SAO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Double'))


-- Insert sample data into ENG_UNIT
INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('V', 1000)
INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('deg C', 1001)
INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('bar', 1002)
INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('rpm', 1003)
INSERT INTO ENG_UNIT (Name, UnitId) VALUES ('%', 1004)

-- Insert sample data into SYMBOL
INSERT INTO SYMBOL (Name) VALUES ('FI')
INSERT INTO SYMBOL (Name) VALUES ('LAH')
INSERT INTO SYMBOL (Name) VALUES ('LAL')
INSERT INTO SYMBOL (Name) VALUES ('LI')
INSERT INTO SYMBOL (Name) VALUES ('LIAL')
INSERT INTO SYMBOL (Name) VALUES ('PAL')
INSERT INTO SYMBOL (Name) VALUES ('PI')
INSERT INTO SYMBOL (Name) VALUES ('PIAL')
INSERT INTO SYMBOL (Name) VALUES ('PTL')
INSERT INTO SYMBOL (Name) VALUES ('QI')
INSERT INTO SYMBOL (Name) VALUES ('SAH')
INSERT INTO SYMBOL (Name) VALUES ('SI')
INSERT INTO SYMBOL (Name) VALUES ('TI')
INSERT INTO SYMBOL (Name) VALUES ('TIAH')
INSERT INTO SYMBOL (Name) VALUES ('XA')
INSERT INTO SYMBOL (Name) VALUES ('XC')
INSERT INTO SYMBOL (Name) VALUES ('XI')

-- Insert sample data into OBJECT_TYPE
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Digital sensor', (SELECT Id FROM OTD WHERE Name = 'BO_1DI'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Fire detector', (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Fire detector with commands', (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Multi DI/DO Object', (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Analog sensor', (SELECT Id FROM OTD WHERE Name = 'BO_AnalogIn'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Analog sensor with alarms', (SELECT Id FROM OTD WHERE Name = 'BO_AnalogIn_AllAlarms'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Analog actuator', (SELECT Id FROM OTD WHERE Name = 'BO_AnalogOut'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Breaker', (SELECT Id FROM OTD WHERE Name = 'BO_Breaker'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Breaker feedback only', (SELECT Id FROM OTD WHERE Name = 'BO_Breaker'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Duty Standby', (SELECT Id FROM OTD WHERE Name = 'BO_DutyStby'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Motor', (SELECT Id FROM OTD WHERE Name = 'BO_Motor'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Motor feedback only', (SELECT Id FROM OTD WHERE Name = 'BO_Motor'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Motor FC', (SELECT Id FROM OTD WHERE Name = 'BO_MotorFC'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('PID controller', (SELECT Id FROM OTD WHERE Name = 'BO_PID'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve Feedback only', (SELECT Id FROM OTD WHERE Name = 'BO_Valve'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve', (SELECT Id FROM OTD WHERE Name = 'BO_Valve'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve w/o command', (SELECT Id FROM OTD WHERE Name = 'BO_Valve'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve Analog', (SELECT Id FROM OTD WHERE Name = 'BO_ValveAI_AO'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Tank', (SELECT Id FROM OTD WHERE Name = 'BO_Tank'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Two Sensor selector', (SELECT Id FROM OTD WHERE Name = 'BO_TwoSensors'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Network Monitor', (SELECT Id FROM OTD WHERE Name = 'NO_NetworkMonitor'))
INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('NA', (SELECT Id FROM OTD WHERE Name = 'NA'))

-- Retrieve Ids for "Digital sensor"
DECLARE @DigitalSensorId INT;
SET @DigitalSensorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Digital sensor');

-- Insert subcategories under "Digital sensor"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@DigitalSensorId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));

-- Retrieve Ids for "Fire detector"
DECLARE @FireDetectorId INT;
SET @FireDetectorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Fire detector');

-- Insert subcategories under "Fire detector"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorId, '02', 'Warning', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorId, '03', 'Fault', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorId, '04', 'Test', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));

-- Retrieve Ids for "Fire detector with commands"
DECLARE @FireDetectorWithCommandsId INT;
SET @FireDetectorWithCommandsId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Fire detector with commands');

-- Insert subcategories under "Fire detector with commands"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '02', 'Warning', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '03', 'Fault', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '04', 'Disabled', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '05', 'Test', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '21', 'Disable', (SELECT Id FROM IO_TYPE WHERE Name = 'SDO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@FireDetectorWithCommandsId, '22', 'Enable', (SELECT Id FROM IO_TYPE WHERE Name = 'SDO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));

-- Retrieve Ids for "Motor"
DECLARE @MotorId INT;
SET @MotorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Motor');

-- Insert subcategories under "Motor"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '11', 'Running feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '12', 'Local selector', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '21', 'Start command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '22', 'Stop command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '18', 'Auxiliary fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));

-- Retrieve Ids for "MotorFeedbackOnly"
DECLARE @MotorFeedbackOnlyId INT;
SET @MotorFeedbackOnlyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Motor feedback only');

-- Insert subcategories under "MotorFeedbackOnly"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFeedbackOnlyId, '11', 'Running feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));

-- Retrieve Ids for "Motor FC"
DECLARE @MotorFCId INT;
SET @MotorFCId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Motor FC');

-- Insert subcategories under "Motor FC"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '11', 'Running feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '12', 'Local selector', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '21', 'Start command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '22', 'Stop command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '18', 'Auxiliary fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '61', 'Speed feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '62', 'Speed setpoint', (SELECT Id FROM IO_TYPE WHERE Name = 'AO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'));

-- Retrieve Ids for "Valve"
DECLARE @ValveId INT;
SET @ValveId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Valve');

-- Insert subcategories under "Valve"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '01', 'Closed feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '02', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '03', 'Close command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '04', 'Open command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '07', 'Valve - fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));

-- Retrieve Ids for "Valve feedback only"
DECLARE @ValveFeedbackOnlyId INT;
SET @ValveFeedbackOnlyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Valve feedback only');

-- Insert subcategories under "Valve feedback only"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveFeedbackOnlyId, '01', 'Closed feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveFeedbackOnlyId, '02', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveFeedbackOnlyId, '07', 'Valve - fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));

-- Retrieve Ids for "Analog sensor"
DECLARE @AnalogSensorId INT;
SET @AnalogSensorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Analog sensor');

-- Insert subcategories under "Analog sensor"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorId, '41', 'Value', (SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Int'));

-- Retrieve Ids for "Analog sensor with alarms"
DECLARE @AnalogSensorAlarmsId INT;
SET @AnalogSensorAlarmsId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Analog sensor with alarms');

-- Insert subcategories under "Analog sensor with alarms"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '41', 'Value', (SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Int'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '41_Q', 'Sensor fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '01', 'High High', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '02', 'High', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '03', 'Low', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '04', 'Low Low', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));

-- Retrieve Ids for "Breaker"
DECLARE @BreakerId INT;
SET @BreakerId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Breaker');

-- Insert subcategories under "Breaker"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '31', 'Close feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '32', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '33', 'Close command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '34', 'Open command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));

-- Retrieve Ids for "BreakerFeedbackOnly"
DECLARE @BreakerIdFeedbackOnly INT;
SET @BreakerIdFeedbackOnly = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Breaker feedback only');

-- Insert subcategories under "BreakerFeedbackOnly"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerIdFeedbackOnly, '31', 'Close feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerIdFeedbackOnly, '32', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));

-- Retrieve Ids for "PIDController"
DECLARE @PIDControllerId INT;
SET @PIDControllerId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'PID controller');

-- Insert subcategories under "PIDController"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@PIDControllerId, '61', 'Output value', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@PIDControllerId, '62', 'Process value', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));

-- Retrieve Ids for "DutyStandby"
DECLARE @DutyStandbyId INT;
SET @DutyStandbyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Duty standby');

-- Insert subcategories under "DutyStandby"
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@DutyStandbyId, '01', 'Object 1 process', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));
INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@DutyStandbyId, '02', 'Object 2 process', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));
