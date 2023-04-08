using HTD.BusinessLogic.Filters.Settings;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTD.BusinessLogic.Filters
{
    internal class TeacherNameFilter : IFilter<Teacher>
    {
        public IEnumerable<Teacher> Filter(IEnumerable<Teacher> values, IFilterSettings<Teacher> settings)
        {
            IEnumerable<Teacher> res = null;
            var config = settings as TeacherNameFilterSettings;
            if (config != null)
                if (string.IsNullOrEmpty(config.SearchName))
                    res = values;
                else
                    res = values.Where(t => t.Name.StartsWith(config.SearchName, StringComparison.OrdinalIgnoreCase));

            return res;
        }
    }
}
