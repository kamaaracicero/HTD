using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTD.App.Configuration
{
    internal static class AppServicesConfiguration
    {
        static AppServicesConfiguration()
        {

        }

        public static IService<Course> CourseService { get; }

        public static IService<Group> GroupService { get; }

        public static IService<Lesson> LessonService { get; }

        public static IService<Pupil> PupilService { get; }

        public static IService<PupilGroup> PupilGroupService { get; }

        public static IService<Teacher> TeacherService { get; }

        public static IService<TeacherCourse> TeacherCouserService { get; }

        public static IService<CourseType> TypeService { get; }
    }
}
