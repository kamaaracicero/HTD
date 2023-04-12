using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.StatisticsMonitoring
{
    internal class CourseTypeListBoxItem : ListBoxItem
    {
        public CourseTypeListBoxItem(CourseType instance)
        {
            Instance = instance;

            Content = instance.Name;
        }

        public CourseType Instance { get; }
    }
}
