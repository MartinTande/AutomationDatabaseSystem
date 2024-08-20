CREATE TABLE [dbo].[ENG_UNIT] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (50) NULL,
    [UnitId] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC),
    UNIQUE NONCLUSTERED ([UnitId] ASC)
);

