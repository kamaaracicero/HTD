ALTER TABLE [dbo].[TeacherCourse]
	ADD CONSTRAINT [FK_TeacherCourse_Course_CourseId]
	FOREIGN KEY (CourseId)
	REFERENCES [dbo].[Course] ([Id]) ON DELETE CASCADE
