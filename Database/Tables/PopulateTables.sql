-- Insert sample data into OBJECT_TYPE
INSERT INTO OBJECT_TYPE (ObjectTypeName) VALUES ('Motor')
INSERT INTO OBJECT_TYPE (ObjectTypeName) VALUES ('Valve')
INSERT INTO OBJECT_TYPE (ObjectTypeName) VALUES ('TemperatureSensor')
INSERT INTO OBJECT_TYPE (ObjectTypeName) VALUES ('PressureSensor')

-- Insert sample data into HIERARCHY_1
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Bilge')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Engines')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Cooling')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Fire System')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('Utility System')
INSERT INTO HIERARCHY_1 (Hierarchy1Name) VALUES ('System')

-- HIERARCHY_2
-- Retrieve Hierarchy1Id for "Cooling"
DECLARE @CoolingHierarchyId INT;
SET @CoolingHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Cooling');

-- Insert subcategories under "Cooling"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('SW Cooling', @CoolingHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('FW Cooling', @CoolingHierarchyId);

-- Retrieve Hierarchy1Id for "Bilge"
DECLARE @BilgeHierarchyId INT;
SET @BilgeHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Bilge');

-- Insert subcategories under "Bilge"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Oily Bilge', @BilgeHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Sludgy Bilge', @BilgeHierarchyId);

-- Retrieve Hierarchy1Id for "Fire System"
DECLARE @FireSystemHierarchyId INT;
SET @FireSystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Fire System');

-- Insert subcategories under "Fire System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Deck 1', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Deck 2', @FireSystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Drencher System', @FireSystemHierarchyId);

-- Retrieve Hierarchy1Id for "Utility System"
DECLARE @UtilitySystemHierarchyId INT;
SET @UtilitySystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Utility System');

-- Insert subcategories under "Utility System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Compressed Air System', @UtilitySystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Hydraulic System', @UtilitySystemHierarchyId);

-- Retrieve Hierarchy1Id for "System"
DECLARE @SystemHierarchyId INT;
SET @SystemHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'System');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('AUT Diagnostics', @SystemHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Scada Diagnostics', @SystemHierarchyId);

-- Retrieve Hierarchy1Id for "Engines"
DECLARE @EnginesHierarchyId INT;
SET @EnginesHierarchyId = (SELECT Hierarchy1Id FROM HIERARCHY_1 WHERE Hierarchy1Name = 'Engines');

-- Insert subcategories under "System"
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Engine 1', @EnginesHierarchyId);
INSERT INTO HIERARCHY_2 (Hierarchy2Name, Hierarchy1Id) VALUES ('Engine 2', @EnginesHierarchyId);

-- Insert sample data into EAS_GROUP
INSERT INTO EAS_GROUP (EasGroupName) VALUES ('Bilge')
INSERT INTO EAS_GROUP (EasGroupName) VALUES ('Cooling')
INSERT INTO EAS_GROUP (EasGroupName) VALUES ('Fire System')
INSERT INTO EAS_GROUP (EasGroupName) VALUES ('Utility System')
INSERT INTO EAS_GROUP (EasGroupName) VALUES ('Engines')
INSERT INTO EAS_GROUP (EasGroupName) VALUES ('System')

-- Insert sample data into OTD
INSERT INTO OTD (OtdName) VALUES ('BO_MOTOR')
INSERT INTO OTD (OtdName) VALUES ('BO_ANALOG')
INSERT INTO OTD (OtdName) VALUES ('BO_DIGITAL')

-- Insert sample data into NODE
INSERT INTO NODE (NodeName) VALUES ('PCU1')
INSERT INTO NODE (NodeName) VALUES ('PCU2')

-- Insert sample data into LOCATION
INSERT INTO LOCATION (LocationName) VALUES ('ECR')
INSERT INTO LOCATION (LocationName) VALUES ('Bridge')
INSERT INTO LOCATION (LocationName) VALUES ('Switchboard Room')
INSERT INTO LOCATION (LocationName) VALUES ('Battery Room')

-- Insert sample data into ACKNOWLEDGE_ALLOWED
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedLocation) VALUES ('ECR')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedLocation) VALUES ('Bridge')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedLocation) VALUES ('Switchboard Room')
INSERT INTO ACKNOWLEDGE_ALLOWED (AcknowledgeAllowedLocation) VALUES ('Battery Room')

-- Insert sample data into ALWAYS_VISIBLE
INSERT INTO ALWAYS_VISIBLE (AlwaysVisibleLocation) VALUES ('ECR')
INSERT INTO ALWAYS_VISIBLE (AlwaysVisibleLocation) VALUES ('Bridge')