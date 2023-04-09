using HTD.DataEntities;

namespace HTD.BusinessLogic.Filters.Settings
{
    public class TeacherFilterSettings : IFilterSettings<Teacher>
    {
        public string SearchName { get; set; }
    }
}
