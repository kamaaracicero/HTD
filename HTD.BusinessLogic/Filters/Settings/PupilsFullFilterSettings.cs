using HTD.DataEntities;
using System.Collections.Generic;

namespace HTD.BusinessLogic.Filters.Settings
{
    internal class PupilsFullFilterSettings : IFilterSettings<Pupil>
    {
        public string PupilNameTB { get; set; }

        public string TeacherNameTB { get; set; }

        public bool PaymentTrueCB { get; set; }

        public bool PaymentFalseCB { get; set; }

        public Group SelectedGroupCB { get; set; }

        public CourseType SelectedCourseTypeCB { get; set; }

        public IEnumerable<PupilGroup> PupilGroups { get; set; }

        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<CourseType> CourseTypes { get; set; }

        public IEnumerable<TeacherCourse> TeacherCourses { get; set; }

        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
