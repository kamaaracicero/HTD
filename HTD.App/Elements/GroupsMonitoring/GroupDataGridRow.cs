using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace HTD.App.Elements.GroupsMonitoring
{
    internal class GroupDataGridRow
    {
        public GroupDataGridRow(Group instance, IEnumerable<Pupil> pupils)
        {
            Instance = instance;
            Pupils = pupils;

            Init();
        }

        public Group Instance { get; }

        public IEnumerable<Pupil> Pupils { get; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string PupilCount { get; set; }

        private void Init()
        {
            Id = Instance.Id.ToString();
            Name = Instance.Name.ToString();
            PupilCount = Pupils.Count().ToString();
        }
    }
}
