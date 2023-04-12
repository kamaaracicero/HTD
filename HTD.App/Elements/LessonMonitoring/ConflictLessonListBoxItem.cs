using HTD.DataEntities;

namespace HTD.App.Elements.LessonMonitoring
{
    internal class ConflictLessonListBoxItem
    {
        private const string TimeFormat = "{0:00}:{1:00}-{2:00}:{3:00}";
        private const string NameFormat = "{0}    Год: {1}";

        public ConflictLessonListBoxItem(Lesson lesson1, Lesson lesson2,
            Group group1, Group group2,
            Teacher teacher1, Teacher teacher2)
        {
            Lesson1 = lesson1;
            Lesson2 = lesson2;

            Group1 = group1;
            Group2 = group2;

            Teacher1 = teacher1;
            Teacher2 = teacher2;

            Init();
        }

        public string Day { get; set; }

        public string FirstLessonTimeTB { get; set; }

        public string FirstLessonNameTB { get; set; }

        public string FirstLessonTeacherTB { get; set; }

        public string SecondLessonTimeTB { get; set; }

        public string SecondLessonNameTB { get; set; }

        public string SecondLessonTeacherTB { get; set; }

        public Group Group1 { get; }

        public Group Group2 { get; }

        public Teacher Teacher1 { get; }

        public Teacher Teacher2 { get; }

        public Lesson Lesson1 { get; }

        public Lesson Lesson2 { get; }

        private void Init()
        {
            switch ((Day)Lesson1.Day)
            {
                case DataEntities.Day.Monday:
                    Day = "Понедельник";
                    break;
                case DataEntities.Day.Tuesday:
                    Day = "Вторник";
                    break;
                case DataEntities.Day.Wednesday:
                    Day = "Среда";
                    break;
                case DataEntities.Day.Thursday:
                    Day = "Четверг";
                    break;
                case DataEntities.Day.Friday:
                    Day = "Пятница";
                    break;
                case DataEntities.Day.Saturday:
                    Day = "Суббота";
                    break;
                case DataEntities.Day.Sunday:
                    Day = "Воскресенье";
                    break;
            }

            FirstLessonTimeTB = string.Format(TimeFormat,
                Lesson1.Begin.Hours, Lesson1.Begin.Minutes,
                Lesson1.End.Hours, Lesson1.End.Minutes);
            FirstLessonNameTB = string.Format(NameFormat, Group1.Name, Group1.Year);
            FirstLessonTeacherTB = Teacher1.Name;

            SecondLessonTimeTB = string.Format(TimeFormat,
                Lesson2.Begin.Hours, Lesson2.Begin.Minutes,
                Lesson2.End.Hours, Lesson2.End.Minutes);
            SecondLessonNameTB = string.Format(NameFormat, Group1.Name, Group1.Year);
            SecondLessonTeacherTB = Teacher2.Name;
        }
    }
}
