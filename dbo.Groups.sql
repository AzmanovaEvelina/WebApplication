CREATE TABLE [dbo].[Groups] (
    [Id]           INT           NOT NULL IDENTITY(1,1),
    [groupNameRU]  VARCHAR(50) NULL,
    [groupNameENG] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

