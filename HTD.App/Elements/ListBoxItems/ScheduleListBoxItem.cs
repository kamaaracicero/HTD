using HTD.DataEntities;

namespace HTD.App.Elements.ListBoxItems
{
    internal class ScheduleListBoxItem
    {
        private const string TimeFormat = "{0}-{1}";

        public ScheduleListBoxItem(Lesson lesson, Course course, Teacher teacher, Group group)
            : base()
        {
            LessonValue = lesson;
            CourseValue = course;
            TeacherValue = teacher;
            GroupValue = group;

            // Init();
        }

        public Lesson LessonValue { get; set; }

        public Course CourseValue { get; set; }

        public Teacher TeacherValue { get; set; }

        public Group GroupValue { get; set; }

        public string Time { get; set; }

        public string Course { get; set; }

        public string Teacher { get; set; }

        public string Group { get; set; }

        public string Place { get; set; }

        private void Init()
        {
            Time = string.Format(TimeFormat,
                LessonValue.Begin.ToShortDateString(),
                LessonValue.End.ToShortTimeString());
            Course = CourseValue.Name;
            Teacher = TeacherValue.Name;
            Group = GroupValue.Name;
            Place = LessonValue.Place.ToString();
        }
    }
}
