using HTD.App.AddWindows;
using HTD.App.Dev.AddWindows;
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

namespace HTD.App.MonitoringWindows
{
    public partial class CourseMonitoring : Window
    {
        public CourseMonitoring()
        {
            InitializeComponent();
        }

        private void ShowGroupsB_Click(object sender, RoutedEventArgs e)
        {
            GroupMonitoring groupMonitoring = new GroupMonitoring();
            groupMonitoring.Show();
        }

        private void AddCourseB_Click(object sender, RoutedEventArgs e)
        {
            AddCourseWindow window = new AddCourseWindow();
            window.ShowDialog();
        }
    }
}
