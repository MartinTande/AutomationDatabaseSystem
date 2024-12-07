CREATE TABLE [dbo].[MODULE_TYPE] (
    [Id]          INT           PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (150) NOT NULL UNIQUE,
    [OrderNumber] VARCHAR (255) NOT NULL UNIQUE,
    [Channels]    INT           NOT NULL,
    [InBytes]     INT           NOT NULL,
    [InBits]      INT           NOT NULL,
    [OutBytes]    INT           NOT NULL,
    [OutBits]     INT           NOT NULL,
    [QIBytes]     INT           NULL
);

