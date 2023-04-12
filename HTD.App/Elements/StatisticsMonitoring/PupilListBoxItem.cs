using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.StatisticsMonitoring
{
    internal class PupilListBoxItem : ListBoxItem
    {
        public PupilListBoxItem(Pupil instance)
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Pupil Instance { get; set; }
    }
}
