CREATE TABLE [dbo].[ENG_UNIT] (
    [Id]     INT          PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NULL UNIQUE,
    [UnitId] INT          NULL UNIQUE
);

