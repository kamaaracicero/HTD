using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.AddLessonWindow
{
    internal class GroupComboBoxItem : ComboBoxItem
    {
        public GroupComboBoxItem(Group instance)
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Group Instance { get; set; }
    }
}
