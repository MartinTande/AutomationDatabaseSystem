CREATE TABLE [dbo].[CABINET] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NOT NULL,
    [Description]  VARCHAR (150) NULL,
    [NoIMs]        INT           NULL,
    [NoSlotsPerIM] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

