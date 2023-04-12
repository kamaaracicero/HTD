using HTD.App.MonitoringWindows;
using System.Windows;

namespace HTD.App.Menu
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void OpenCoursesB_Click(object sender, RoutedEventArgs e)
        {
            CourseMonitoring courseMonitoring = new CourseMonitoring();
            courseMonitoring.Show();
            WindowState = WindowState.Minimized;
        }

        private void OpenTeacherssB_Click(object sender, RoutedEventArgs e)
        {
            TeacherMonitoring teacherMonitoring = new TeacherMonitoring();
            teacherMonitoring.Show();
            WindowState = WindowState.Minimized;
        }

        private void OpenPupilsB_Click(object sender, RoutedEventArgs e)
        {
            PupilMonitoring pupilMonitoring = new PupilMonitoring();
            pupilMonitoring.Show();
            WindowState = WindowState.Minimized;
        }

        private void OpenLessonsB_Click(object sender, RoutedEventArgs e)
        {
            LessonMonitoring lessonMonitoring = new LessonMonitoring();
            lessonMonitoring.Show();
            WindowState = WindowState.Minimized;
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StatisticsB_Click(object sender, RoutedEventArgs e)
        {
            StatisticsMonitoring window = new StatisticsMonitoring();
            window.Show();
            WindowState = WindowState.Minimized;
        }
    }
}
