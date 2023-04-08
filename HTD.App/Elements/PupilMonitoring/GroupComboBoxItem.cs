using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.PupilMonitoring
{
    internal class GroupComboBoxItem : ComboBoxItem
    {
        public GroupComboBoxItem(Group instance, string header = null)
            : base()
        {
            Instance = instance;

            Content = header == null ? instance.Name : header;
        }

        public Group Instance { get; set; }
    }
}
