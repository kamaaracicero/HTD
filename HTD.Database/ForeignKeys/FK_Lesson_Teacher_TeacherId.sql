ALTER TABLE [dbo].[Lesson]
	ADD CONSTRAINT [FK_Lesson_Teacher_TeacherId]
	FOREIGN KEY ([TeacherId])
	REFERENCES [dbo].[Teacher] ([Id]) ON DELETE CASCADE
