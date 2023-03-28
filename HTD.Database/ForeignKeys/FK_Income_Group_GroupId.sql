ALTER TABLE [dbo].[Income]
	ADD CONSTRAINT [FK_Income_Group_GroupId]
	FOREIGN KEY ([GroupId])
	REFERENCES [dbo].[Group] ([Id]) ON DELETE CASCADE
