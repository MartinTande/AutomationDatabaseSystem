CREATE TABLE [dbo].[OBJECT_TYPE] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  VARCHAR (150) NULL,
    [OtdId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([OtdId]) REFERENCES [dbo].[OTD] ([Id])
);

