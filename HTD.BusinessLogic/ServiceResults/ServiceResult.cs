using System.Collections.Generic;

namespace HTD.BusinessLogic.ServiceResults
{
    public class ServiceResult
    {
        public ServiceResult(bool successfully = false)
        {
            Successfully = successfully;
            Errors = new List<ServiceException>();
        }

        public bool Successfully { get; set; }

        public IList<ServiceException> Errors { get; set; }

        public void AppendErrors(ServiceResult result)
        {
            if (result.Errors.Count == 0)
            {
                return;
            }

            foreach (var error in result.Errors)
            {
                Errors.Add(error);
            }
        }
    }

    public class ServiceResult<TValue> : ServiceResult
    {
        public ServiceResult(bool result, TValue value)
            : base(result)
        {
            Value = value;
        }

        public ServiceResult(bool result = false)
            : this(result, default)
        {
        }

        public TValue Value { get; set; }
    }
}
