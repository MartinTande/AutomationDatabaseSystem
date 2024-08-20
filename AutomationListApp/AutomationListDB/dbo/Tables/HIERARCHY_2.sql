CREATE TABLE [dbo].[HIERARCHY_2] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [Hierarchy1Id] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Hierarchy1Id]) REFERENCES [dbo].[HIERARCHY_1] ([Id]),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

