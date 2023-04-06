using HTD.BusinessLogic.Filters.Settings;
using System.Collections.Generic;

namespace HTD.BusinessLogic.Filters
{
    internal interface IFilter<TValue>
        where TValue : class
    {
        IEnumerable<TValue> Filter(IEnumerable<TValue> values, IFilterSettings<TValue> settings);
    }
}
