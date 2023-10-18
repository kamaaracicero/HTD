using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTD.BusinessLogic.Word
{
    public interface IWordParser<TData>
    {
        void ParseWordDoc(TData data, string path);
    }
}
