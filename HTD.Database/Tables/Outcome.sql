CREATE TABLE [dbo].[Outcome]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [GroupId] INT NOT NULL,
    [PupilId] INT NOT NULL,
    [OrderNumber] NVARCHAR(MAX) NOT NULL,
    [Date] DATETIME NOT NULL,
    CONSTRAINT pk_Outcome PRIMARY KEY([Id])
)
