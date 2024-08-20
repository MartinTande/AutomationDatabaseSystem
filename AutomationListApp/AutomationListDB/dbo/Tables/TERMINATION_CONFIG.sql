CREATE TABLE [dbo].[TERMINATION_CONFIG] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [IoTypeId]     INT NOT NULL,
    [SignalTypeId] INT NOT NULL,
    [ModuleTypeId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IoTypeId]) REFERENCES [dbo].[IO_TYPE] ([Id]),
    FOREIGN KEY ([ModuleTypeId]) REFERENCES [dbo].[MODULE_TYPE] ([Id]),
    FOREIGN KEY ([SignalTypeId]) REFERENCES [dbo].[SIGNAL_TYPE] ([Id])
);

