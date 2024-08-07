-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\Tables\\CreateTables.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\Tables\\PopulateTables.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Category\\DeleteCategoryItem.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Category\\EditCategoryItem.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Category\\GetCategory.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\AddHierarchy1.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\AddHierarchy2.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\DeleteHierarchy2.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\DeleteHierarchy1.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\EditHierarchy1.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\EditHierarchy2.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Hierarchy\\GetHierarchy2ByGroup.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Object\\CreateObject.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Object\\EditObject.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Object\\UpdateObject.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Object\\GetAllObject.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\StoredProcedures\\Object\\GetObjectById.sp.sql
-- :r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\Views\\ObjectData.view.sql


/* SCRIPT: CREATE_DB.sql */
/* BUILD A DATABASE */

-- This is the main caller for each script
SET NOCOUNT ON
GO

PRINT 'CREATING DATABASE'

:On Error exit

:r C:\\Users\\mrtan\\source\\repos\\AutomationDatabaseSystem\\Database\\Tables\\CreateTables.sql

PRINT 'DATABASE CREATE IS COMPLETE'
GO