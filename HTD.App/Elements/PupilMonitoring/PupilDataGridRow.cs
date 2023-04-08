using HTD.DataEntities;

namespace HTD.App.Elements.PupilMonitoring
{
    internal class PupilDataGridRow
    {
        public PupilDataGridRow(Pupil instance)
        {
            Instance = instance;

            Init();
        }

        public Pupil Instance { get; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string ContactPhone { get; private set; }

        public void Init()
        {
            Id = Instance.Id.ToString();
            Name = Instance.Name;
            ContactPhone = Instance.ContactPhone;
        }
    }
}
