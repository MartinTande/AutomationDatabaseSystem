CREATE TABLE [dbo].[IO_SIGNAL_TYPE] (
    [Id]           INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [IoTypeId]     INT NOT NULL,
    [SignalTypeId] INT NOT NULL,
    FOREIGN KEY ([IoTypeId]) REFERENCES [dbo].[IO_TYPE] ([Id]),
    FOREIGN KEY ([SignalTypeId]) REFERENCES [dbo].[SIGNAL_TYPE] ([Id])
);

