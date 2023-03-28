using HTD.BusinessLogic.ServiceResults;
using System;

namespace HTD.BusinessLogic.Services
{
    internal abstract class Service
    {
        protected readonly string ConnectionString;

        protected Service(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected void AppendErrorToResult(ServiceResult result, object service, string message)
        {
            if (service is null || result is null || message is null)
                throw new ArgumentNullException(nameof(service));

            result.Errors.Add(new ServiceException(nameof(service), message));
        }
    }
}
