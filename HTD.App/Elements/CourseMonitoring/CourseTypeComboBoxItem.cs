using HTD.DataEntities;
using System.Windows.Controls;

namespace HTD.App.Elements.CourseMonitoring
{
    internal class CourseTypeComboBoxItem : ComboBoxItem
    {
        public CourseTypeComboBoxItem(CourseType instance, string header = null)
            : base()
        {
            Instance = instance;

            Content = header == null ? instance.Name : header;
        }

        public CourseType Instance { get; set; }
    }
}
