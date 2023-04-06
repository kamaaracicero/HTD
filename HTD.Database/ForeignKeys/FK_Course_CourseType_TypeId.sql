ALTER TABLE [dbo].[Course]
	ADD CONSTRAINT [FK_Course_CourseType_TypeId]
	FOREIGN KEY ([TypeId])
	REFERENCES [dbo].[CourseType] ([Id]) ON DELETE CASCADE
