using HTD.DataEntities;
using System.Collections.Generic;

namespace HTD.BusinessLogic.Filters.Settings
{
    internal class CourseFilterSettings : IFilterSettings<Course>
    {
        public string NameTB { get; set; }

        public string TeacherNameTB { get; set; }

        public CourseType CourseType {  get; set; }

        public IEnumerable<TeacherCourse> TeacherCourses { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
