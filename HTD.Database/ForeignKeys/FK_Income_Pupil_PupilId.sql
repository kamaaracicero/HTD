ALTER TABLE [dbo].[Income]
	ADD CONSTRAINT [FK_Income_Pupil_PupilId]
	FOREIGN KEY ([PupilId])
	REFERENCES [dbo].[Pupil] ([Id]) ON DELETE CASCADE
