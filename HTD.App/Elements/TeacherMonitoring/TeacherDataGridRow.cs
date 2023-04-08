using HTD.DataEntities;

namespace HTD.App.Elements.TeacherMonitoring
{
    public class TeacherDataGridRow
    {
        public TeacherDataGridRow(Teacher instance)
        {
            Instance = instance;

            Init();
        }

        public Teacher Instance { get; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Phone { get; private set; }

        private void Init()
        {
            Id = Instance.Id.ToString();
            Name = Instance.Name.ToString();
            Phone = Instance.Phone.ToString();
        }
    }
}
