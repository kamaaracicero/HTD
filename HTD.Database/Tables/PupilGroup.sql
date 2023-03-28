CREATE TABLE [dbo].[PupilGroup]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[PupilId] INT NOT NULL,
	[GroupId] INT NOT NULL,
	CONSTRAINT pk_PupilGroup PRIMARY KEY([Id]),
)
