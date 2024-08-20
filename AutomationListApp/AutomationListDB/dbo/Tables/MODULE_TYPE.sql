CREATE TABLE [dbo].[MODULE_TYPE] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (150) NOT NULL,
    [OrderNumber] VARCHAR (255) NOT NULL,
    [Channels]    INT           NOT NULL,
    [InBytes]     INT           NOT NULL,
    [InBits]      INT           NOT NULL,
    [OutBytes]    INT           NOT NULL,
    [OutBits]     INT           NOT NULL,
    [QIBytes]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC),
    UNIQUE NONCLUSTERED ([OrderNumber] ASC)
);

