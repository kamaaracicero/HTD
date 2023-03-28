namespace HTD.BusinessLogic.ServiceResults
{
    public class ServiceException
    {
        public ServiceException(string serviceName, string description)
        {
            ServiceName = serviceName;
            Description = description;
        }

        public string ServiceName { get; set; }

        public string Description { get; set; }
    }
}
