using System.Collections.Generic;

namespace HTD.BusinessLogic.ModelConverters
{
    public class ModelConvertResult<TValue>
        where TValue : class, new()
    {
        public ModelConvertResult()
        {
            IsError = false;
            Errors = new List<string>();
            Value = new TValue();
        }

        public bool IsError { get; set; }

        public List<string> Errors { get; set; }

        public TValue Value { get; set; }
    }
}
