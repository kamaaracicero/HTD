using HTD.BusinessLogic.Filters;
using HTD.DataEntities;

namespace HTD.App.Configuration
{
    internal static class AppFilerConfiguration
    {
        static AppFilerConfiguration()
        {
            TeacherNameFilter = new TeacherNameFilter();
        }

        public static IFilter<Teacher> TeacherNameFilter { get; }
    }
}
