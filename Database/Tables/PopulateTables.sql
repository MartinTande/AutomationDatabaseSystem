-- Insert sample data into OBJECT_TYPE
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('Motor')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('Valve')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('TemperatureSensor')
INSERT INTO OBJECT_TYPE (ObjectType) VALUES ('PressureSensor')

-- Insert sample data into HIERARCHY_1
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Bilge')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Engines')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Cooling')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Fire System')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('Utility System')
INSERT INTO HIERARCHY_1 (Hierarchy1) VALUES ('System')

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
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Deck 2', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Drencher System', @FireSystemHierarchyId);

-- Retrieve Hierarchy1Id for "Utility System"
DECLARE @UtilitySystemHierarchyId INT;
SET @UtilitySystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'Utility System');

-- Insert subcategories under "Utility System"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Compressed Air System', @UtilitySystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Hydraulic System', @UtilitySystemHierarchyId);

-- Retrieve Hierarchy1Id for "System"
DECLARE @SystemHierarchyId INT;
SET @SystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'System');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('AUT Diagnostics', @SystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Scada Diagnostics', @SystemHierarchyId);

-- Retrieve Hierarchy1Id for "Engines"
DECLARE @EnginesHierarchyId INT;
SET @EnginesHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1 = 'Engines');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Engine 1', @EnginesHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2, Hierarchy1Id) VALUES ('Engine 2', @EnginesHierarchyId);

-- Insert sample data into EAS_GROUP
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Bilge')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Cooling')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Fire System')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Utility System')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('Engines')
INSERT INTO EAS_GROUP (EasGroup) VALUES ('System')

-- Insert sample data into OTD
INSERT INTO OTD (Otd) VALUES ('BO_MOTOR')
INSERT INTO OTD (Otd) VALUES ('BO_ANALOG')
INSERT INTO OTD (Otd) VALUES ('BO_DIGITAL')

-- Insert sample data into NODE
INSERT INTO NODE (Node) VALUES ('PCU1')
INSERT INTO NODE (Node) VALUES ('PCU2')

-- Insert sample data into LOCATION
INSERT INTO LOCATION (LocationName) VALUES ('ECR')
INSERT INTO LOCATION (LocationName) VALUES ('Bridge')
INSERT INTO LOCATION (LocationName) VALUES ('Switchboard Room')
INSERT INTO LOCATION (LocationName) VALUES ('Battery Room')

-- Insert sample data into ACKNOWLEDGE_ALLOWED
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowed) VALUES ('ECR')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowed) VALUES ('Bridge')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowed) VALUES ('Switchboard Room')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowed) VALUES ('Battery Room')

-- Insert sample data into ALWAYS_VISIBLE
INSERT INTO ALWAYS_VISIBLE (AlwaysVisible) VALUES ('ECR')
INSERT INTO ALWAYS_VISIBLE (AlwaysVisible) VALUES ('Bridge')