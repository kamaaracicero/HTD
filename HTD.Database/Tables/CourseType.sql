CREATE TABLE [dbo].[CourseType]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT pk_Type PRIMARY KEY([Id]),
)
