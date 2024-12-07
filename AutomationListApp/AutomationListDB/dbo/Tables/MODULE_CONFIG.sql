CREATE TABLE [dbo].[MODULE_CONFIG] (
    [Id]           INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [IoTypeId]     INT NOT NULL,
    [SignalTypeId] INT NULL,
    [ModuleTypeId] INT NOT NULL,
    FOREIGN KEY ([IoTypeId]) REFERENCES [dbo].[IO_TYPE] ([Id]),
    FOREIGN KEY ([ModuleTypeId]) REFERENCES [dbo].[MODULE_TYPE] ([Id]),
    FOREIGN KEY ([SignalTypeId]) REFERENCES [dbo].[SIGNAL_TYPE] ([Id])
);

