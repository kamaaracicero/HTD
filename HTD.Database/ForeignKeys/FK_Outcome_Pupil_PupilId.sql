ALTER TABLE [dbo].[Outcome]
	ADD CONSTRAINT [FK_Outcome_Pupil_PupilId]
	FOREIGN KEY ([PupilId])
	REFERENCES [dbo].[Pupil] ([Id]) ON DELETE CASCADE
