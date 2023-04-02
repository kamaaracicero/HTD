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
        }

        private void OpenTeacherssB_Click(object sender, RoutedEventArgs e)
        {
            TeacherMonitoring teacherMonitoring = new TeacherMonitoring();
            teacherMonitoring.Show();
        }

        private void OpenPupilsB_Click(object sender, RoutedEventArgs e)
        {
            PupilMonitoring pupilMonitoring = new PupilMonitoring();
            pupilMonitoring.Show();
        }

        private void OpenLessonsB_Click(object sender, RoutedEventArgs e)
        {
            LessonMonitoring lessonMonitoring = new LessonMonitoring();
            lessonMonitoring.Show();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatisticsB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
