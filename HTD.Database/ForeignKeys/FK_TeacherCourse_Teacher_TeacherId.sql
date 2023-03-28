ALTER TABLE [dbo].[TeacherCourse]
	ADD CONSTRAINT [FK_TeacherCourse_Teacher_TeacherId]
	FOREIGN KEY ([TeacherId])
	REFERENCES [dbo].[Teacher] ([Id]) ON DELETE CASCADE
