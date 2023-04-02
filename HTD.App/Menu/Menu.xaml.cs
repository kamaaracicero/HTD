using HTD.App.MonitoringWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HTD.App.Menu
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
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

        }

        private void OpenLessonsB_Click(object sender, RoutedEventArgs e)
        {
            LessonMonitoring lessonMonitoring = new LessonMonitoring();
            lessonMonitoring.Show();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
