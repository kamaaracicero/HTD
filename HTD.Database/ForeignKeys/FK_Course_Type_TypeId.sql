ALTER TABLE [dbo].[Course]
	ADD CONSTRAINT [FK_Course_Type_TypeId]
	FOREIGN KEY ([TypeId])
	REFERENCES [dbo].[Type] ([Id]) ON DELETE CASCADE
