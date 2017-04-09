CREATE TABLE [dbo].[MapData] (
    [Id]   INT         IDENTITY NOT NULL,
    [Lon]  REAL        NOT NULL,
    [Lat]  REAL        NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
