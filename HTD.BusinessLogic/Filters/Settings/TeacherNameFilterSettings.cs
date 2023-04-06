using HTD.DataEntities;

namespace HTD.BusinessLogic.Filters.Settings
{
    public class TeacherNameFilterSettings : IFilterSettings<Teacher>
    {
        public string SearchName { get; set; }
    }
}
