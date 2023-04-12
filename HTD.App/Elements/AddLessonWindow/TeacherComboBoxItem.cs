using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.AddLessonWindow
{
    internal class TeacherComboBoxItem : ComboBoxItem
    {
        public TeacherComboBoxItem(Teacher instance)
        {
            Instance = instance;

            Content = Instance.Name;
        }

        public Teacher Instance { get; set; }
    }
}
