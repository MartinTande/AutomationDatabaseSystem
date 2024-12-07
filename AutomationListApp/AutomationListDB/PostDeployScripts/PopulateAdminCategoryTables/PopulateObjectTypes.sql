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


-- OBJECT_TYPES
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Digital alarm' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_1DI'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Digital alarm', (SELECT Id FROM OTD WHERE Name = 'BO_1DI'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Digital indicator' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_1DI'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Digital indicator', (SELECT Id FROM OTD WHERE Name = 'BO_1DI'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Fire detector' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Fire detector', (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Fire detector with commands' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Fire detector with commands', (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Multi DI/DO Object' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Multi DI/DO Object', (SELECT Id FROM OTD WHERE Name = 'BO_8DI_8DO'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Analog sensor' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_AnalogIn'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Analog sensor', (SELECT Id FROM OTD WHERE Name = 'BO_AnalogIn'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Analog sensor with alarms' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_AnalogIn'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Analog sensor with alarms', (SELECT Id FROM OTD WHERE Name = 'BO_AnalogIn'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Analog actuator' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_AnalogOut'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Analog actuator', (SELECT Id FROM OTD WHERE Name = 'BO_AnalogOut'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Breaker' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Breaker'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Breaker', (SELECT Id FROM OTD WHERE Name = 'BO_Breaker'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Breaker feedback only' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Breaker'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Breaker feedback only', (SELECT Id FROM OTD WHERE Name = 'BO_Breaker'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Duty Standby' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_DutyStby'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Duty Standby', (SELECT Id FROM OTD WHERE Name = 'BO_DutyStby'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Motor' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Motor'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Motor', (SELECT Id FROM OTD WHERE Name = 'BO_Motor'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Motor feedback only' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Motor'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Motor feedback only', (SELECT Id FROM OTD WHERE Name = 'BO_Motor'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Motor with VFD' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_MotorFC'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Motor with VFD', (SELECT Id FROM OTD WHERE Name = 'BO_MotorFC'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'PID controller' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_PID'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('PID controller', (SELECT Id FROM OTD WHERE Name = 'BO_PID'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Valve feedback only' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Valve'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve feedback only', (SELECT Id FROM OTD WHERE Name = 'BO_Valve'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Valve' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Valve'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve', (SELECT Id FROM OTD WHERE Name = 'BO_Valve'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Valve analog' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_ValveAI_AO'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Valve analog', (SELECT Id FROM OTD WHERE Name = 'BO_ValveAI_AO'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Tank' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_Tank'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Tank', (SELECT Id FROM OTD WHERE Name = 'BO_Tank'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Two Sensor selector' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_TwoSensors'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Two Sensor selector', (SELECT Id FROM OTD WHERE Name = 'BO_TwoSensors'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'Network Monitor' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'BO_NetworkMonitor'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('Network Monitor', (SELECT Id FROM OTD WHERE Name = 'BO_NetworkMonitor'));
IF NOT EXISTS (SELECT 1 FROM OBJECT_TYPE WHERE Name = 'NA' AND OtdId = (SELECT Id FROM OTD WHERE Name = 'NA'))
    INSERT INTO OBJECT_TYPE (Name, OtdId) VALUES ('NA', (SELECT Id FROM OTD WHERE Name = 'NA'));


-- Digital Alarm
DECLARE @DigitalAlarmId INT;
SET @DigitalAlarmId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Digital alarm');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @DigitalAlarmId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId, SymbolId)
    VALUES (@DigitaAlarmId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'), (SELECT Id FROM SYMBOL WHERE Name = 'XI'));


-- Digital Indicator
DECLARE @DigitalIndicatorId INT;
SET @DigitalIndicatorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Digital sensor');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @DigitalIndicatorId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId, SymbolId)
    VALUES (@DigitalIndicatorId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'), (SELECT Id FROM SYMBOL WHERE Name = 'XI'));


-- Fire detector
DECLARE @FireDetectorId INT;
SET @FireDetectorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Fire detector');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorId AND EqSuffix = '02')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorId, '02', 'Warning', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorId AND EqSuffix = '03')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorId, '03', 'Fault', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorId AND EqSuffix = '04')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorId, '04', 'Disabled', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorId AND EqSuffix = '04')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorId, '05', 'Test', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));


-- Fire detector with commands
DECLARE @FireDetectorWithCommandsId INT;
SET @FireDetectorWithCommandsId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Fire detector with commands');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '01', 'Alarm', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '02')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '02', 'Warning', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '03')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '03', 'Fault', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '04')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '04', 'Disabled', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '05')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '05', 'Test', (SELECT Id FROM IO_TYPE WHERE Name = 'SDI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '21')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '21', 'Disable', (SELECT Id FROM IO_TYPE WHERE Name = 'SDO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @FireDetectorWithCommandsId AND EqSuffix = '22')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId)
    VALUES (@FireDetectorWithCommandsId, '22', 'Enable', (SELECT Id FROM IO_TYPE WHERE Name = 'SDO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));


-- Motor
DECLARE @MotorId INT;
SET @MotorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Motor');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorId AND EqSuffix = '11')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '11', 'Running feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorId AND EqSuffix = '12')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '12', 'Local selector', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorId AND EqSuffix = '21')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '21', 'Start command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorId AND EqSuffix = '22')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '22', 'Stop command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorId AND EqSuffix = '18')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorId, '18', 'Auxiliary fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));


-- Motor Feedback Only
DECLARE @MotorFbOnlyId INT;
SET @MotorFbOnlyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Motor');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFbOnlyId AND EqSuffix = '11')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFbOnlyId, '11', 'Running feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));


-- Motor FC
DECLARE @MotorFCId INT;
SET @MotorFCId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Motor');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '11')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '11', 'Running feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '12')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '12', 'Local selector', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '21')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '21', 'Start command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '22')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '22', 'Stop command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '18')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '18', 'Auxiliary fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '61')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '22', 'Speed feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @MotorFCId AND EqSuffix = '62')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@MotorFCId, '18', 'Speed seetpoint', (SELECT Id FROM IO_TYPE WHERE Name = 'AO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'));


-- Valve
DECLARE @ValveId INT;
SET @ValveId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Valve');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '01', 'Closed feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveId AND EqSuffix = '02')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '02', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveId AND EqSuffix = '03')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '03', 'Close command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveId AND EqSuffix = '04')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '04', 'Open command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveId AND EqSuffix = '07')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveId, '07', 'Valve - fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));


-- Valve feedback only
DECLARE @ValveFbOnlyId INT;
SET @ValveFbOnlyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Valve');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveFbOnlyId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveFbOnlyId, '01', 'Closed feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveFbOnlyId AND EqSuffix = '02')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveFbOnlyId, '02', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @ValveFbOnlyId AND EqSuffix = '07')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@ValveFbOnlyId, '07', 'Valve - fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));


-- Analog Sensor
DECLARE @AnalogSensorId INT;
SET @AnalogSensorId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Analog sensor');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorId AND EqSuffix = '41')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorId, '41', 'Value', (SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Int'));


-- Analog sensor with alarms
DECLARE @AnalogSensorAlarmsId INT;
SET @AnalogSensorAlarmsId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Analog sensor with alarms');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorAlarmsId AND EqSuffix = '41')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '41', 'Value', (SELECT Id FROM IO_TYPE WHERE Name = 'AI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'Int'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorAlarmsId AND EqSuffix = '41_Q')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '41_Q', 'Sensor fault', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorAlarmsId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '01', 'High High', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorAlarmsId AND EqSuffix = '02')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '02', 'High', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorAlarmsId AND EqSuffix = '03')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '03', 'Low', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @AnalogSensorAlarmsId AND EqSuffix = '04')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@AnalogSensorAlarmsId, '04', 'Low Low', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'));


-- Breaker
DECLARE @BreakerId INT;
SET @BreakerId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Breaker');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @BreakerId AND EqSuffix = '31')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '31', 'Close feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @BreakerId AND EqSuffix = '32')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '32', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @BreakerId AND EqSuffix = '33')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '33', 'Close command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @BreakerId AND EqSuffix = '34')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerId, '34', 'Open command', (SELECT Id FROM IO_TYPE WHERE Name = 'DO'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));


-- Breaker feedback only
DECLARE @BreakerFbOnlyId INT;
SET @BreakerFbOnlyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Breaker');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @BreakerFbOnlyId AND EqSuffix = '31')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerFbOnlyId, '31', 'Close feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @BreakerFbOnlyId AND EqSuffix = '32')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@BreakerFbOnlyId, '32', 'Open feedback', (SELECT Id FROM IO_TYPE WHERE Name = 'DI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'));


-- PID Controller
DECLARE @PIDControllerId INT;
SET @PIDControllerId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'PID controller');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @PIDControllerId AND EqSuffix = '61')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@PIDControllerId, '61', 'Output value', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @PIDControllerId AND EqSuffix = '62')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@PIDControllerId, '62', 'Process value', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));


-- Duty Standby Object
DECLARE @DutyStandbyId INT;
SET @DutyStandbyId = (SELECT Id FROM OBJECT_TYPE WHERE Name = 'Duty standby');

IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @DutyStandbyId AND EqSuffix = '01')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@DutyStandbyId, '01', 'Object 1 process', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));
IF NOT EXISTS (SELECT 1 FROM TAG WHERE ObjectTypeId = @DutyStandbyId AND EqSuffix = '02')
    INSERT INTO TAG (ObjectTypeId, EqSuffix, Description, IoTypeId, SignalTypeId) VALUES (@DutyStandbyId, '02', 'Object 2 process', (SELECT Id FROM IO_TYPE WHERE Name = 'SAI'), (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'U_AnalogValueLong'));