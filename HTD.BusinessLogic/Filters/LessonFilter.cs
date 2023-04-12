using HTD.BusinessLogic.Filters.Settings;
using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.Filters
{
    internal class LessonFilter : IFilter<Lesson>
    {
        public IEnumerable<Lesson> Filter(IEnumerable<Lesson> values, IFilterSettings<Lesson> settings)
        {
            IEnumerable<Lesson> res = null;
            var config = settings as LessonFilterSettings;
            if (config != null)
            {
                res = values;
                res = FilterBySelectedTeacher(res, config);
                res = FilterBySelectedGroup(res, config);
            }
            return res;
        }

        public IEnumerable<Lesson> FilterBySelectedTeacher(IEnumerable<Lesson> lessons,
            LessonFilterSettings settings)
        {
            if (settings.SelectedTeacherCB == null)
                return lessons;
            else
                return lessons.Where(l => l.TeacherId == settings.SelectedTeacherCB.Id);
        }

        public IEnumerable<Lesson> FilterBySelectedGroup(IEnumerable<Lesson> lessons,
            LessonFilterSettings settings)
        {
            if (settings.SelectedGroupCB == null)
                return lessons;
            else
                return lessons.Where(l => l.GroupId == settings.SelectedGroupCB.Id);
        }
    }
}
