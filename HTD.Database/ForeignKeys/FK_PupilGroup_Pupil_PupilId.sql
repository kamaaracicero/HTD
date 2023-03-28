ALTER TABLE [dbo].[PupilGroup]
	ADD CONSTRAINT [FK_PupilGroup_Pupil_PupilId]
	FOREIGN KEY ([PupilId])
	REFERENCES [dbo].[Pupil] ([Id]) ON DELETE CASCADE
