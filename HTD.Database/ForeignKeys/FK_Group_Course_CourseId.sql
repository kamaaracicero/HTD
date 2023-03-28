ALTER TABLE [dbo].[Group]
	ADD CONSTRAINT [FK_Group_Course_CourseId]
	FOREIGN KEY ([CourseId])
	REFERENCES [dbo].[Course] ([Id]) ON DELETE CASCADE
