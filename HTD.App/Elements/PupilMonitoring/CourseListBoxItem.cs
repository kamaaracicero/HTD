using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.PupilMonitoring
{
    internal class CourseListBoxItem : ListBoxItem
    {
        public CourseListBoxItem(Course instance)
            : base()
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Course Instance { get; set; }
    }
}
