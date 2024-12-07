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

-- Admin category tables
:r .\PopulateAdminCategoryTables\PopulateEngUnits.sql
:r .\PopulateAdminCategoryTables\PopulateIoAndSignalTypes.sql
:r .\PopulateAdminCategoryTables\PopulateOtds.sql	
:r .\PopulateAdminCategoryTables\PopulateSymbols.sql
:r .\PopulateAdminCategoryTables\PopulateSymbols.sql
:r .\PopulateAdminCategoryTables\PopulateModuleTypeAndConfig.sql


-- Project category tables
:r .\PopulateProjetCategoryTables\PopulateDefaultHierarchy.sql
:r .\PopulateProjetCategoryTables\PopulateEasAlarmLocationGroups.sql
:r .\PopulateProjetCategoryTables\PopulateNodeAndCabinets.sql