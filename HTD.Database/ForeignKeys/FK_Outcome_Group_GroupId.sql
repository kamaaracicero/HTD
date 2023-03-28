ALTER TABLE [dbo].[Outcome]
	ADD CONSTRAINT [FK_Outcome_Group_GroupId]
	FOREIGN KEY ([GroupId])
	REFERENCES [dbo].[Group] ([Id]) ON DELETE CASCADE
