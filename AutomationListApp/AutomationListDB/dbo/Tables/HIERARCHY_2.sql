CREATE TABLE [dbo].[HIERARCHY_2] (
    [Id]           INT          PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL UNIQUE,
    [Hierarchy1Id] INT          NOT NULL,
    FOREIGN KEY ([Hierarchy1Id]) REFERENCES [dbo].[HIERARCHY_1] ([Id])
);

