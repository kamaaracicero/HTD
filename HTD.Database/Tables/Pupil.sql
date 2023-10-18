CREATE TABLE [dbo].[Pupil]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(500) NOT NULL,
    [BirthDay] DATE NOT NULL,
    [ParentName] NVARCHAR(500) NOT NULL,
    [ContactPhone] NVARCHAR(100) NOT NULL,
    [IsExpelled] BIT NOT NULL,
    [Class] INT NULL,
	[GUO] NVARCHAR(300) NULL,
    CONSTRAINT pk_Pupil PRIMARY KEY([Id]),
)
