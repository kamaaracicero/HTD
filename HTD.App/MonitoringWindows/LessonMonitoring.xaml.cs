using HTD.App.AddWindows;
using System.Windows;

namespace HTD.App.MonitoringWindows
{
    public partial class LessonMonitoring : Window
    {
        public LessonMonitoring()
        {
            InitializeComponent();
        }

        private void AddCourseB_Click(object sender, RoutedEventArgs e)
        {
            AddLessonWindow window = new AddLessonWindow();
            window.Show();
        }
    }
}
