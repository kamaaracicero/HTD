CREATE TABLE [dbo].[Course]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(500) NOT NULL,
    [TypeId] INT NOT NULL,
    [IsActive] BIT NOT NULL,
    CONSTRAINT pk_Course PRIMARY KEY([Id]),
)
