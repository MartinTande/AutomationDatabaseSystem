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


-- Insert sample data into MODULE_TYPE
-- Insert sample data for "DI 8×24VDC ST"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes) 
SELECT 'DI 8×24VDC ST', '6ES7131-6BF00-0BA0', 8, 1, 0, 0, 0, 1 
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST');

-- Insert sample data for "RQ 4×24VUC/2A CO ST"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'RQ 4×24VUC/2A CO ST', '6ES7132-6GD50-0BA0', 4, 0, 0, 0, 4, 1
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST');

-- Insert sample data for "AI 4×I 2-/4-wire ST"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'AI 4×I 2-/4-wire ST', '6ES7134-6GD00-0BA1', 4, 8, 0, 0, 0, 1
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST');
-- Insert sample data for "AI 4×RTD/TC 2-/3-/4-wire HF"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'AI 4×RTD/TC 2-/3-/4-wire HF', '6ES7134-6JD00-0CA1', 4, 8, 0, 0, 0, 1
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF');

-- Insert sample data for "AI 4xU/I 2-wire ST"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'AI 4xU/I 2-wire ST', '6ES7134-6HD00-0BA1', 4, 8, 0, 0, 0, 1
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'AI 4xU/I 2-wire ST');

-- Insert sample data for "AQ 4×U/I ST"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'AQ 4×U/I ST', '6ES7135-6HD00-0BA1', 4, 0, 0, 8, 0, 1
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST');

-- Insert sample data for "TM Count 1x24V"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'TM Count 1x24V', '6ES7138-6AA00-0BA0', 1, 16, 0, 12, 0, 0
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'TM Count 1x24V');

-- Insert sample data for "CM PtP communication module"
INSERT INTO MODULE_TYPE (Name, OrderNumber, Channels, InBytes, InBits, OutBytes, OutBits, QIBytes)
SELECT 'CM PtP communication module', '6ES7137-6AA00-0BA0', 1, 8, 0, 0, 0, 0
WHERE NOT EXISTS (SELECT 1 FROM MODULE_TYPE WHERE Name = 'CM PtP communication module');

-- Insert sample data into MODULE_CONFIG
INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'DI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'DI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'DI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'DI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'DI 8×24VDC ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'DO'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'DO')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'DO'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'DO')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'DO'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC, 230V Relay'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'DO')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NC, 230V Relay')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'DO'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO, 230V Relay'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'DO')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'NO, 230V Relay')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'RQ 4×24VUC/2A CO ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 4W'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 4W')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×I 2-/4-wire ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 2W'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 2W')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 3W'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 3W')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 4W'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'PT100, 4W')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'TC'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = 'TC')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4×RTD/TC 2-/3-/4-wire HF')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AI'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4xU/I 2-wire ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AI')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AI 4xU/I 2-wire ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AO'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AO')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = '4-20mA, 2W')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST')
);

INSERT INTO MODULE_CONFIG (IoTypeId, SignalTypeId, ModuleTypeId)
SELECT
    (SELECT Id FROM IO_TYPE WHERE Name = 'AO'),
    (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V'),
    (SELECT Id FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST')
WHERE NOT EXISTS (
    SELECT 1 FROM MODULE_CONFIG
    WHERE
        IoTypeId = (SELECT Id FROM IO_TYPE WHERE Name = 'AO')
        AND SignalTypeId = (SELECT Id FROM SIGNAL_TYPE WHERE Name = '0-10V')
        AND ModuleTypeId = (SELECT Id FROM MODULE_TYPE WHERE Name = 'AQ 4×U/I ST')
);

