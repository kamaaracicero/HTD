ALTER TABLE [dbo].[Lesson]
	ADD CONSTRAINT [FK_Lesson_Group_GroupId]
	FOREIGN KEY ([GroupId])
	REFERENCES [dbo].[Group] ([Id]) ON DELETE CASCADE
