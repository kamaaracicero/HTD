using HTD.BusinessLogic.Filters;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Configuration;

namespace HTD.App.Configuration
{
    internal static class AppConfiguration
    {
        static AppConfiguration()
        {
            TeacherFilter = new TeacherFilter();
            PupilFilter = new PupilFilter();
            CourseFilter = new CourseFilter();

            AddCourseConverter = new CourseModelConverter();
            AddCourseTypeConverter = new CourseTypeModelConverter();
            AddTeacherConverter = new TeacherModelConverter();
            AddPupilConverter = new PupilModelConverter();
            AddGroupConverter = new GroupModelConverter();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;

            CourseService = new CourseService(connectionString);
            GroupService = new GroupService(connectionString);
            LessonService = new LessonService(connectionString);
            PupilService = new PupilService(connectionString);
            PupilGroupService = new PupilGroupService(connectionString);
            TeacherService = new TeacherService(connectionString);
            TeacherCourseService = new TeacherCourseService(connectionString);
            CourseTypeService = new CourseTypeService(connectionString);
        }

        public static IFilter<Course> CourseFilter { get; set; }

        public static IFilter<Teacher> TeacherFilter { get; }

        public static IFilter<Pupil> PupilFilter { get; }

        public static IModelConverter<CourseModel, Course> AddCourseConverter { get; }

        public static IModelConverter<CourseTypeModel, CourseType> AddCourseTypeConverter { get; }

        public static IModelConverter<GroupModel, Group> AddGroupConverter { get; }

        public static IModelConverter<LessonModel, Lesson> AddLessonConverter { get; }

        public static IModelConverter<PupilModel, Pupil> AddPupilConverter { get; }

        public static IModelConverter<TeacherModel, Teacher> AddTeacherConverter { get; }

        public static IService<Course> CourseService { get; }

        public static IService<Group> GroupService { get; }

        public static IService<Lesson> LessonService { get; }

        public static IService<Pupil> PupilService { get; }

        public static IService<PupilGroup> PupilGroupService { get; }

        public static IService<Teacher> TeacherService { get; }

        public static IService<TeacherCourse> TeacherCourseService { get; }

        public static IService<CourseType> CourseTypeService { get; }
    }
}
