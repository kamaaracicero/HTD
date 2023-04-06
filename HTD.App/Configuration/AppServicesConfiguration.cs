using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Configuration;

namespace HTD.App.Configuration
{
    internal static class AppServicesConfiguration
    {
        static AppServicesConfiguration()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;

            CourseService = new CourseService(connectionString);
            GroupService = new GroupService(connectionString);
            LessonService = new LessonService(connectionString);
            PupilService = new PupilService(connectionString);
            PupilGroupService = new PupilGroupService(connectionString);
            TeacherService = new TeacherService(connectionString);
            TeacherCourseService = new TeacherCourseService(connectionString);
            TypeService = new CourseTypeService(connectionString);
        }

        public static IService<Course> CourseService { get; }

        public static IService<Group> GroupService { get; }

        public static IService<Lesson> LessonService { get; }

        public static IService<Pupil> PupilService { get; }

        public static IService<PupilGroup> PupilGroupService { get; }

        public static IService<Teacher> TeacherService { get; }

        public static IService<TeacherCourse> TeacherCourseService { get; }

        public static IService<CourseType> TypeService { get; }
    }
}
