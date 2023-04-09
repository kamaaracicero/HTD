using HTD.DataEntities;

namespace HTD.App.Elements.CourseMonitoring
{
    internal class CourseDataGridRow
    {
        public CourseDataGridRow(Course instance)
        {
            Instance = instance;

            Init();
        }

        public Course Instance { get; }

        public string Id { get; set; }

        public string Name { get; set; }

        private void Init()
        {
            Id = Instance.Id.ToString();
            Name = Instance.Name.ToString();
        }
    }
}
