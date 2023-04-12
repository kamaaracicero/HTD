using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.AddLessonWindow
{
    internal class DayComboBoxItem : ComboBoxItem
    {
        public DayComboBoxItem(Day instance, string header)
        {
            Instance = instance;

            Content = header;
        }

        public Day Instance { get;set; }
    }
}
