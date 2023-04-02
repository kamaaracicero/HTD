using HTD.App.AddWindows;
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
    public partial class PupilMonitoring : Window
    {
        public PupilMonitoring()
        {
            InitializeComponent();
        }

        private void AddPupilB_Click(object sender, RoutedEventArgs e)
        {
            AddPupilWindow window = new AddPupilWindow();
            window.ShowDialog();
        }
    }
}
