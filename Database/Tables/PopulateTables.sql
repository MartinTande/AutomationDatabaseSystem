-- Object Type
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('Motor')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('Valve')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('TemperatureSensor')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('PressureSensor')

-- Hierarchy 1
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Bilge')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Cooling')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Fire System')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Utility System')

-- Hierarchy 2
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('Bilge')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('Oily Bilge')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('SW Cooling')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('FW Cooling')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('Drencher System')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('Deck 1')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('Compressed Air')
INSERT INTO HIERARCHY_2 (Hierarchy2) VALUES ('Hydraulic System')

-- Eas Group
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Bilge')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Cooling')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Fire System')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Utility System')

-- OTDs
INSERT INTO OTD (Otd) VALUES ('AnalogOuput')
INSERT INTO OTD (Otd) VALUES ('DigitalOutput')
INSERT INTO OTD (Otd) VALUES ('AnalogInput')
INSERT INTO OTD (Otd) VALUES ('DigitalInput')