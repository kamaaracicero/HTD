using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.DataSearchs
{
    internal static class DependencySearch
    {
        public static IEnumerable<Course> FindTeacherCourses(Teacher teacher,
            IEnumerable<TeacherCourse> dependencies, IEnumerable<Course> courses)
        {
            var dependencySearch = dependencies.Where(d => d.TeacherId == teacher.Id);
            var ids = dependencySearch.Select(d => d.CourseId).ToArray();
            return courses.Where(c => ids.Contains(c.Id)).ToArray();
        }

        public static IEnumerable<Group> FindCourseGroups(Course course, IEnumerable<Group> groups)
        {
            return groups.Where(g => g.CourseId== course.Id);
        }
    }
}
