SET NOCOUNT ON

DROP TABLE IF EXISTS TAG;
DROP TABLE IF EXISTS OBJECT;
DROP TABLE IF EXISTS OBJECT_TYPE;
DROP TABLE IF EXISTS HIERARCHY_2;
DROP TABLE IF EXISTS HIERARCHY_1;
DROP TABLE IF EXISTS EAS_GROUP;--EAS group
DROP TABLE IF EXISTS ALARM_GROUP;-- alarm group
DROP TABLE IF EXISTS VDU_GROUP;-- customer defined groups
DROP TABLE IF EXISTS OTD_INTERFACE;
DROP TABLE IF EXISTS OTD;
DROP TABLE IF EXISTS ACKNOWLEDGE_ALLOWED;
DROP TABLE IF EXISTS ALWAYS_VISIBLE;
DROP TABLE IF EXISTS NODE;
DROP TABLE IF EXISTS LOCATION;
DROP TABLE IF EXISTS CABINET;
DROP TABLE IF EXISTS DATA_BLOCK;
DROP TABLE IF EXISTS IO_SIGNAL_TYPE;
DROP TABLE IF EXISTS SIGNAL_TYPE;
DROP TABLE IF EXISTS IO_TYPE;
DROP TABLE IF EXISTS ENG_UNIT;


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

CREATE TABLE EAS_GROUP
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

CREATE TABLE OTD_INTERFACE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	OtdId int NOT NULL FOREIGN KEY REFERENCES OTD(Id),
	Name varchar(150) NOT NULL,
	Suffix varchar(50) NOT NULL,
	DataType varchar(100) NOT NULL,
	InterfaceType varchar(150) NOT NULL,
	IsOptional bit
)

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

CREATE TABLE IO_TYPE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) NOT NULL UNIQUE
)
GO

CREATE TABLE SIGNAL_TYPE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50),
)
GO

CREATE TABLE IO_SIGNAL_TYPE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	IoTypeId int NOT NULL FOREIGN KEY REFERENCES IO_TYPE(Id),
	SignalTypeId int NOT NULL FOREIGN KEY REFERENCES SIGNAL_TYPE(Id)
)
GO

CREATE TABLE ENG_UNIT
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name varchar(50) UNIQUE,
	UnitId int UNIQUE
)
GO

CREATE TABLE OBJECT_TYPE
(
	Id int PRIMARY KEY IDENTITY (1,1),
	Name VARCHAR(150),
	OtdId int FOREIGN KEY REFERENCES OTD(Id),
)

CREATE TABLE OBJECT
(
	Id int PRIMARY KEY IDENTITY (1,1),
	SfiNumber varchar(50) NOT NULL,
	MainEqNumber varchar(50) NOT NULL,
	EqNumber varchar(50),
	Description varchar(150) NOT NULL,
	VduGroupId int NOT NULL FOREIGN KEY REFERENCES VDU_GROUP(Id),
	Hierarchy1Id int FOREIGN KEY REFERENCES HIERARCHY_1(Id),
	Hierarchy2Id int FOREIGN KEY REFERENCES HIERARCHY_2(Id),
	EasGroupId int FOREIGN KEY REFERENCES EAS_GROUP(Id),
	AlarmGroupId int FOREIGN KEY REFERENCES ALARM_GROUP(Id),
	OtdId int FOREIGN KEY REFERENCES OTD(Id),
	ObjectTypeId int FOREIGN KEY REFERENCES OBJECT_TYPE(Id),
	AcknowledgeAllowedId int FOREIGN KEY REFERENCES ACKNOWLEDGE_ALLOWED(Id),
	AlwaysVisibleId int FOREIGN KEY REFERENCES ALWAYS_VISIBLE(Id),
	NodeId int FOREIGN KEY REFERENCES NODE(Id),
	CabinetId int NOT NULL FOREIGN KEY REFERENCES CABINET(Id),
	LastModified DATETIME,
)
GO

CREATE TABLE TAG
(
	Id int PRIMARY KEY IDENTITY (1,1),
	ObjectId int FOREIGN KEY REFERENCES OBJECT(Id),
	ObjectTypeId int FOREIGN KEY REFERENCES OBJECT_TYPE(Id),
	EqSuffix varchar(50) NOT NULL,
	Description varchar(150) NOT NULL,
	IoTypeId int NOT NULL FOREIGN KEY REFERENCES IO_TYPE(Id),
	SignalTypeId int FOREIGN KEY REFERENCES SIGNAL_TYPE(Id),
	EngUnitId int FOREIGN KEY REFERENCES ENG_UNIT(Id),
	RangeLow int,
	RangeHigh int,
	LowLowLimit int,
	LowLimit int,
	HighLimit int,
	HighHighLimit int,
	Slot int,
	AbsoluteAddress varchar(50),
	SWPath varchar(150),
	DBName varchar(150),
	ModbusAddress int,
	ModbusBit int,
	IsE0 bit,
	IsVDR bit,
	LastModified DATETIME
)
GO
