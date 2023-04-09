using HTD.BusinessLogic.Filters;
using HTD.DataEntities;

namespace HTD.App.Configuration
{
    internal static class AppFilterConfiguration
    {
        static AppFilterConfiguration()
        {
            TeacherFilter = new TeacherFilter();
            PupilFilter = new PupilFilter();
            CourseFilter = new CourseFilter();
        }

        public static IFilter<Course> CourseFilter { get; set; }

        public static IFilter<Teacher> TeacherFilter { get; }

        public static IFilter<Pupil> PupilFilter { get; }
    }
}
