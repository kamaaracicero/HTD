using System.Collections.Generic;

namespace HTD.BusinessLogic.ModelConverters
{
    public class ModelConvertResult<TValue>
    {
        public bool IsError { get; set; }

        public List<string> Errors { get; set; }

        public TValue Value { get; set; }
    }
}
