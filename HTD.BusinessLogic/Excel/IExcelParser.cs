using System.Collections.Generic;

namespace HTD.BusinessLogic.Excel
{
    public interface IExcelParser<TData>
    {
        void Parse(IEnumerable<TData> data, string path);
    }
}
