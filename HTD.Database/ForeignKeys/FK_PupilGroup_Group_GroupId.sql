ALTER TABLE [dbo].[PupilGroup]
	ADD CONSTRAINT [FK_PupilGroup_Group_GroupId]
	FOREIGN KEY ([GroupId])
	REFERENCES [dbo].[Group] ([Id]) ON DELETE CASCADE
