using HTD.BusinessLogic.Filters;
using HTD.DataEntities;

namespace HTD.App.Configuration
{
    internal static class AppFilerConfiguration
    {
        static AppFilerConfiguration()
        {
            TeacherNameFilter = new TeacherNameFilter();
            PupilFullFilter = new PupilFullFilter();
        }

        public static IFilter<Teacher> TeacherNameFilter { get; }

        public static IFilter<Pupil> PupilFullFilter { get; }
    }
}
