using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.StatisticsMonitoring
{
    internal class CourseListBoxItem : ListBoxItem
    {
        public CourseListBoxItem(Course instance)
        {
            Instance = instance;

            Content = instance.Name;
        }

        public Course Instance { get; set; }
    }
}
