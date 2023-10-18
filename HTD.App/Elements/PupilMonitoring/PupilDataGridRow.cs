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

        public string DateOfBirth { get; private set; }

        public string Class { get; private set; }

        public string GUO {  get; private set; }

        public void Init()
        {
            Id = Instance.Id.ToString();
            Name = Instance.Name;
            ContactPhone = Instance.ContactPhone;
            DateOfBirth = Instance.BirthDay.ToShortDateString();
            Class = Instance.Class == null ? "---" : Instance.Class.ToString();
            GUO = Instance.GUO ?? "---";
        }
    }
}
