using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.AddCourseWindow
{
    internal class TeacherComboBoxItem : ComboBoxItem
    {
        public TeacherComboBoxItem(Teacher instance, string header = null)
            : base()
        {
            Instance = instance;

            Content = header == null ? instance.Name : header;
        }

        public Teacher Instance { get; }
    }
}
