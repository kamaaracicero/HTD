CREATE TABLE [dbo].[Group]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [CourseId] INT NOT NULL,
    [Name] NVARCHAR(1000) NOT NULL,
    [Year] INT NOT NULL,
    [IsActive] BIT NOT NULL,
    [Payment] BIT NOT NULL,
    CONSTRAINT pk_Group PRIMARY KEY([Id]),
)
