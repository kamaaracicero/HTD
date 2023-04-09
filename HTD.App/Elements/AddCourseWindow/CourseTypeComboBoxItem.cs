using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.AddCourseWindow
{
    internal class CourseTypeComboBoxItem : ComboBoxItem
    {
        public CourseTypeComboBoxItem(CourseType instance)
            : base()
        {
            Instance = instance;

            Content = instance.Name;
        }

        public CourseType Instance { get; }
    }
}
