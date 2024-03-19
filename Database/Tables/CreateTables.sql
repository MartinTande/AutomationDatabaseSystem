DROP TABLE IF EXISTS TAG_OBJECT;
DROP TABLE IF EXISTS HIERARCHY_2;
DROP TABLE IF EXISTS HIERARCHY_1;
DROP TABLE IF EXISTS VDU_GROUP; --EAS group = VDU group
DROP TABLE IF EXISTS ALARM_GROUP; -- alarm groups
DROP TABLE IF EXISTS OTD;
DROP TABLE IF EXISTS ACKNOWLEDGE_ALLOWED;
DROP TABLE IF EXISTS ALWAYS_VISIBLE;
DROP TABLE IF EXISTS NODE;
DROP TABLE IF EXISTS LOCATION;
DROP TABLE IF EXISTS CABINET;
DROP TABLE IF EXISTS DATA_BLOCK;


CREATE TABLE HIERARCHY_1
(
	Hierarchy1Id int PRIMARY KEY IDENTITY (1,1),
	Hierarchy1Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE HIERARCHY_2
(
	Hierarchy2Id int PRIMARY KEY IDENTITY (1,1),
	Hierarchy2Name varchar(50) NOT NULL UNIQUE,
	Hierarchy1Id int NOT NULL FOREIGN KEY REFERENCES HIERARCHY_1(Hierarchy1Id)
)
GO

CREATE TABLE VDU_GROUP
(
	VduGroupId int PRIMARY KEY IDENTITY (1,1),
	VduGroupName varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE ALARM_GROUP
(
	AlarmGroupId int PRIMARY KEY IDENTITY (1,1),
	AlarmGroupName varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE OTD
(
	OtdId int PRIMARY KEY IDENTITY (1,1),
	OtdName varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE ACKNOWLEDGE_ALLOWED
(
	AcknowledgeAllowedId int PRIMARY KEY IDENTITY (1,1),
	AcknowledgeAllowedLocation varchar(200) NOT NULL UNIQUE,
)
GO

CREATE TABLE ALWAYS_VISIBLE
(
	AlwaysVisibleId int PRIMARY KEY IDENTITY (1,1),
	AlwaysVisibleLocation varchar(200) NOT NULL UNIQUE,
)
GO

CREATE TABLE LOCATION
(
	LocationId int PRIMARY KEY IDENTITY (1,1),
	LocationName varchar(200) NOT NULL UNIQUE
)
GO

CREATE TABLE NODE
(
	NodeId int PRIMARY KEY IDENTITY (1,1),
	NodeName varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE CABINET
(
	CabinetId int PRIMARY KEY IDENTITY (1,1),
	CabinetName varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE DATA_BLOCK
(
	DataBlockId int PRIMARY KEY IDENTITY (1,1),
	DataBlockName varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE TAG_OBJECT
(
	ObjectId int PRIMARY KEY IDENTITY (1,1),
	SfiNumber int NOT NULL,
	MainEqNumber varchar(50) NOT NULL,
	EqNumber varchar(50),
	ObjectDescription varchar(50) NOT NULL UNIQUE,
	Hierarchy1Id int NOT NULL FOREIGN KEY REFERENCES HIERARCHY_1(Hierarchy1Id),
	Hierarchy2Id int NOT NULL FOREIGN KEY REFERENCES HIERARCHY_2(Hierarchy2Id),
	VduGroupId int NOT NULL FOREIGN KEY REFERENCES VDU_GROUP(VduGroupId),
	AlarmGroupId int NOT NULL FOREIGN KEY REFERENCES ALARM_GROUP(AlarmGroupId),
	OtdId int NOT NULL FOREIGN KEY REFERENCES OTD(OtdId),
	AcknowledgeAllowedId int FOREIGN KEY REFERENCES ACKNOWLEDGE_ALLOWED(AcknowledgeAllowedId),
	AlwaysVisibleId int FOREIGN KEY REFERENCES ALWAYS_VISIBLE(AlwaysVisibleId),
	NodeId int NOT NULL FOREIGN KEY REFERENCES NODE(NodeId),
	CabinetId int NOT NULL FOREIGN KEY REFERENCES CABINET(CabinetId),
	DataBlockId int FOREIGN KEY REFERENCES DATA_BLOCK(DataBlockId),
)
GO