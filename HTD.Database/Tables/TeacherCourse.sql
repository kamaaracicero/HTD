CREATE TABLE [dbo].[TeacherCourse]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[TeacherId] INT NOT NULL,
	[CourseId] INT NOT NULL,
	CONSTRAINT pk_TeacherCourse PRIMARY KEY([Id])
)
