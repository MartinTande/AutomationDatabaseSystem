CREATE TABLE [dbo].[OTD_INTERFACE] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [OtdId]         INT           NOT NULL,
    [Name]          VARCHAR (150) NOT NULL,
    [Suffix]        VARCHAR (50)  NOT NULL,
    [DataType]      VARCHAR (100) NOT NULL,
    [InterfaceType] VARCHAR (150) NOT NULL,
    [IsOptional]    BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([OtdId]) REFERENCES [dbo].[OTD] ([Id])
);

