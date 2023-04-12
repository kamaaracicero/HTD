using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.StatisticsMonitoring
{
    internal class GroupListBoxItem : ListBoxItem
    {
        public GroupListBoxItem(Group instance)
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Group Instance { get; set; }
    }
}
