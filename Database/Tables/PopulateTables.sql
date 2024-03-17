-- Insert sample data into OBJECT_TYPE
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('Motor')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('Valve')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('TemperatureSensor')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('PressureSensor')

-- Insert sample data into HIERARCHY_1
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Bilge')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Cooling')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Fire System')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Utility System')

-- HIERARCHY_2
-- Retrieve Hierarchy1Id for "Cooling"
DECLARE @CoolingHierarchyId INT;
SET @CoolingHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'Cooling');

-- Insert subcategories under "Cooling"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('SW Cooling', @CoolingHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('FW Cooling', @CoolingHierarchyId);

-- Retrieve Hierarchy1Id for "Bilge"
DECLARE @BilgeHierarchyId INT;
SET @BilgeHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'Bilge');

-- Insert subcategories under "Bilge"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Oily Bilge', @BilgeHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Sludgy Bilge', @BilgeHierarchyId);

-- Retrieve Hierarchy1Id for "Fire System"
DECLARE @FireSystemHierarchyId INT;
SET @FireSystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'Fire System');

-- Insert subcategories under "Fire System"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Deck 1', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Drencher System', @FireSystemHierarchyId);

-- Retrieve Hierarchy1Id for "Fire System"
DECLARE @UtilitySystemHierarchyId INT;
SET @UtilitySystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'Utility System');

-- Insert subcategories under "Fire System"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Compressed Air System', @FUtilitySystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Hydraulic System', @UtilitySystemHierarchyId);

-- Insert sample data into EAS_GROUP
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Bilge')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Cooling')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Fire System')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Utility System')

-- Insert sample data into OTD
INSERT INTO OTD (Otd) VALUES ('AnalogOutput')
INSERT INTO OTD (Otd) VALUES ('DigitalOutput')
INSERT INTO OTD (Otd) VALUES ('AnalogInput')
INSERT INTO OTD (Otd) VALUES ('DigitalInput')