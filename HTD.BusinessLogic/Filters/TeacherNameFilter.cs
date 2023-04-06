using HTD.BusinessLogic.Filters.Settings;
using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.Filters
{
    internal class TeacherNameFilter : IFilter<Teacher>
    {
        public IEnumerable<Teacher> Filter(IEnumerable<Teacher> values, IFilterSettings<Teacher> settings)
        {
            Teacher[] res = null;
            var tempSettings = settings as TeacherNameFilterSettings;
            if (tempSettings != null)
                res = values.Where(t => t.Name.StartsWith(tempSettings.SearchName,
                    System.StringComparison.OrdinalIgnoreCase)).ToArray();

            return res;
        }
    }
}
