CREATE TABLE [dbo].[Income]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [GroupId] INT NOT NULL,
    [PupilId] INT NOT NULL,
    [OrderNumber] NVARCHAR(MAX) NOT NULL,
    [Date] DATETIME NOT NULL,
    [Payment] BIT NOT NULL,
    CONSTRAINT pk_Income PRIMARY KEY([Id]),
)
