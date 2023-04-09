using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.DataSearchs
{
    internal static class DependencyHelper
    {
        /// <summary>
        /// Найти все кружки одного преподавателя.
        /// </summary>
        /// <param name="teacher"></param>
        /// <param name="dependencies"></param>
        /// <param name="courses"></param>
        /// <returns></returns>
        public static IEnumerable<Course> FindTeacherCourses(Teacher teacher,
            IEnumerable<TeacherCourse> dependencies, IEnumerable<Course> courses)
        {
            var dependencySearch = dependencies.Where(d => d.TeacherId == teacher.Id);
            var ids = dependencySearch.Select(d => d.CourseId);
            return courses.Where(c => ids.Contains(c.Id));
        }

        /// <summary>
        /// Найти все кружки выбранных преподавателей.
        /// </summary>
        /// <param name="teachers"></param>
        /// <param name="dependencies"></param>
        /// <param name="courses"></param>
        /// <returns></returns>
        public static IEnumerable<Course> FindTeachersCourses(IEnumerable<Teacher> teachers,
            IEnumerable<TeacherCourse> dependencies, IEnumerable<Course> courses)
        {
            List<int> ids = new List<int>();
            foreach (var teacher in teachers)
            {
                var dependencySearch = dependencies.Where(d => d.TeacherId == teacher.Id);
                ids.AddRange(dependencySearch.Select(d => d.CourseId));
            }
            ids = ids.Distinct().ToList();
            return courses.Where(c => ids.Contains(c.Id));
        }

        /// <summary>
        /// Найти все группы одного кружка
        /// </summary>
        /// <param name="course"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public static IEnumerable<Group> FindCourseGroups(Course course, IEnumerable<Group> groups)
        {
            return groups.Where(g => g.CourseId== course.Id);
        }

        /// <summary>
        /// Найти все группы выбранных кружков
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public static IEnumerable<Group> FindCoursesGroups(IEnumerable<Course> courses, IEnumerable<Group> groups)
        {
            List<int> ids = new List<int>();
            foreach (var course in courses)
                ids.AddRange(groups.Where(g => g.CourseId == course.Id).Select(g => g.Id));
            ids = ids.Distinct().ToList();
            return groups.Where(g => ids.Contains(g.Id));
        }

        public static IEnumerable<Pupil> FindGroupPupils(Group group,
            IEnumerable<PupilGroup> dependencies, IEnumerable<Pupil> pupils)
        {
            var dependencySearch = dependencies.Where(d => d.GroupId == group.Id);
            var ids = dependencySearch.Select(d => d.PupilId);
            return pupils.Where(p => ids.Contains(p.Id));
        }

        /// <summary>
        /// Найти всех учеников выбранныых групп
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="dependencies"></param>
        /// <param name="pupils"></param>
        /// <returns></returns>
        public static IEnumerable<Pupil> FindGroupsPupils(IEnumerable<Group> groups,
            IEnumerable<PupilGroup> dependencies, IEnumerable<Pupil> pupils)
        {
            List<int> ids = new List<int>();
            foreach (var group in groups)
            {
                var dependencySearch = dependencies.Where(d => d.GroupId == group.Id);
                ids.AddRange(dependencySearch.Select(d => d.PupilId));
            }
            ids = ids.Distinct().ToList();
            return pupils.Where(p => ids.Contains(p.Id));
        }

        /// <summary>
        /// Найти все группы ученика
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="dependencies"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public static IEnumerable<Group> FindPupilGroups(Pupil pupil,
            IEnumerable<PupilGroup> dependencies, IEnumerable<Group> groups)
        {
            var dependencySearch = dependencies.Where(d => d.PupilId == pupil.Id);
            var ids = dependencySearch.Select(d => d.GroupId);
            return groups.Where(g => ids.Contains(g.Id));
        }

        /// <summary>
        /// Найти все кружки ученика
        /// </summary>
        /// <param name="pupil"></param>
        /// <param name="dependencies"></param>
        /// <param name="groups"></param>
        /// <param name="courses"></param>
        /// <returns></returns>
        public static IEnumerable<Course> FindPupilCourses(Pupil pupil,
            IEnumerable<PupilGroup> dependencies,
            IEnumerable<Group> groups,
            IEnumerable<Course> courses)
        {
            var ids = FindPupilGroups(pupil, dependencies, groups)
                .Select(g => g.CourseId).Distinct();
            return courses.Where(c => ids.Contains(c.Id));
        }

        public static IEnumerable<Pupil> FindCoursePupils(Course course,
            IEnumerable<Group> groups,
            IEnumerable<PupilGroup> dependencies,
            IEnumerable<Pupil> pupils)
        {
            var tempGroups = FindCourseGroups(course, groups);
            return FindGroupsPupils(groups, dependencies, pupils);
        }

        public static IEnumerable<Teacher> FindCourseTeachers(Course course,
            IEnumerable<TeacherCourse> dependencies, IEnumerable<Teacher> teachers)
        {
            var dependencySearch = dependencies.Where(d => d.CourseId == course.Id);
            var ids = dependencySearch.Select(d => d.TeacherId);
            return teachers.Where(t => ids.Contains(t.Id));
        }
    }
}
