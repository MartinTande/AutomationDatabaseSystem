CREATE TABLE [dbo].[OBJECT_TYPE] (
    [Id]    INT           PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (150) NULL,
    [OtdId] INT           NULL,
    FOREIGN KEY ([OtdId]) REFERENCES [dbo].[OTD] ([Id])
);

