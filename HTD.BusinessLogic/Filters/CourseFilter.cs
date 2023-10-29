using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Filters.Settings;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.Filters
{
    internal class CourseFilter : IFilter<Course>
    {
        public IEnumerable<Course> Filter(IEnumerable<Course> values, IFilterSettings<Course> settings)
        {
            IEnumerable<Course> res = null;
            var config = settings as CourseFilterSettings;
            if (config != null)
            {
                res = values.Where(p => p.IsActive == true);
                res = FilterByName(config, res);
                res = FilterByTeacherName(config, res);
                res = FilterByType(config, res);
            }
            return res;
        }

        private IEnumerable<Course> FilterByName(CourseFilterSettings settings, IEnumerable<Course> courses)
        {
            if (string.IsNullOrEmpty(settings.NameTB))
                return courses;
            else
                return courses.Where(c => c.Name.StartsWith(settings.NameTB, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<Course> FilterByType(CourseFilterSettings settings, IEnumerable<Course> courses)
        {
            if (settings.CourseType == null)
                return courses;
            else
                return courses.Where(c => c.TypeId == settings.CourseType.Id);
        }

        private IEnumerable<Course> FilterByTeacherName(CourseFilterSettings settings, IEnumerable<Course> courses)
        {
            if (string.IsNullOrEmpty(settings.TeacherNameTB))
                return courses;
            else
            {
                var teachers = settings.Teachers.Where(t =>
                    t.Name.StartsWith(settings.TeacherNameTB, StringComparison.OrdinalIgnoreCase));
                if (teachers.Count() == 0)
                    return new Course[0];

                return DependencyHelper.FindTeachersCourses(teachers, settings.TeacherCourses, courses);
            }
        }
    }
}
