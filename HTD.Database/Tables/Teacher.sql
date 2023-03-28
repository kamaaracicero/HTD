CREATE TABLE [dbo].[Teacher]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(500) NOT NULL,
    [Phone] NVARCHAR(100) NOT NULL,
    [DateStartWork] DATETIME NOT NULL,
    [DateEndWork] DATETIME NULL,
    CONSTRAINT pk_Teacher PRIMARY KEY([Id]),
)
