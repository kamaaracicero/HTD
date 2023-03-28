CREATE TABLE [dbo].[Lesson]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [GroupId] INT NOT NULL,
    [TeacherId] INT NOT NULL,
    [Begin] TIME NOT NULL,
    [End] TIME NOT NULL,
    [Place] INT NOT NULL,
    [Date] DATE NOT NULL,
    CONSTRAINT pk_Lesson PRIMARY KEY([Id]),
)
