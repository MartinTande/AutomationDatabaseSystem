CREATE TABLE [dbo].[CABINET] (
    [Id]           INT           PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NOT NULL UNIQUE,
    [Description]  VARCHAR (150) NULL,
    [NoIMs]        INT           NULL,
    [NoSlotsPerIM] INT           NULL
);

