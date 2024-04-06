DROP TABLE IF EXISTS OBJECT;
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
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE HIERARCHY_2
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE,
	Hierarchy1Id int NOT NULL FOREIGN KEY REFERENCES HIERARCHY_1(Id)
)
GO

CREATE TABLE VDU_GROUP
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE ALARM_GROUP
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE OTD
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE ACKNOWLEDGE_ALLOWED
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(200) NOT NULL UNIQUE,
)
GO

CREATE TABLE ALWAYS_VISIBLE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(200) NOT NULL UNIQUE,
)
GO

CREATE TABLE LOCATION
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(200) NOT NULL UNIQUE
)
GO

CREATE TABLE NODE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE CABINET
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE DATA_BLOCK
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE OBJECT
(
	ObjectId int PRIMARY KEY IDENTITY (1,1),
	SfiNumber int NOT NULL,
	MainEqNumber varchar(50) NOT NULL,
	EqNumber varchar(50),
	Description varchar(50) NOT NULL UNIQUE,
	Hierarchy1Id int NOT NULL FOREIGN KEY REFERENCES HIERARCHY_1(Id),
	Hierarchy2Id int NOT NULL FOREIGN KEY REFERENCES HIERARCHY_2(Id),
	VduGroupId int NOT NULL FOREIGN KEY REFERENCES VDU_GROUP(Id),
	AlarmGroupId int NOT NULL FOREIGN KEY REFERENCES ALARM_GROUP(Id),
	OtdId int NOT NULL FOREIGN KEY REFERENCES OTD(Id),
	AcknowledgeAllowedId int FOREIGN KEY REFERENCES ACKNOWLEDGE_ALLOWED(Id),
	AlwaysVisibleId int FOREIGN KEY REFERENCES ALWAYS_VISIBLE(Id),
	NodeId int NOT NULL FOREIGN KEY REFERENCES NODE(Id),
	CabinetId int NOT NULL FOREIGN KEY REFERENCES CABINET(Id),
	DataBlockId int FOREIGN KEY REFERENCES DATA_BLOCK(Id),
)
GO