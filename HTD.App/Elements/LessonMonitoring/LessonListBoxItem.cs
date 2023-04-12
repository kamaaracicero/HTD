using HTD.DataEntities;

namespace HTD.App.Elements.LessonMonitoring
{
    internal class LessonListBoxItem
    {
        private const string TimeFormat = "{0:00}:{1:00}-{2:00}:{3:00}";
        private const string PlaceFormat = "Кабинет: {0}";

        public LessonListBoxItem(Lesson lesson, Course course, Teacher teacher, Group group)
            : base()
        {
            Instance = lesson;
            CourseValue = course;
            TeacherValue = teacher;
            GroupValue = group;

            Init();
        }

        public Lesson Instance { get; set; }

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
                Instance.Begin.Hours,
                Instance.Begin.Minutes,
                Instance.End.Hours,
                Instance.End.Minutes);

            if (CourseValue == null)
                Course = "Кружок архивирован. Занятие невозможно";
            else
                Course = CourseValue.Name;

            if (TeacherValue == null)
                Teacher = "Учитель удалён. Занятие невозможно";
            else
                Teacher = TeacherValue.Name;

            if (GroupValue == null)
                Group = "Группа архивирована. Занятие невозможно";
            else
                Group = GroupValue.Name;

            Place = string.Format(PlaceFormat, Instance.Place.ToString());
        }
    }
}
