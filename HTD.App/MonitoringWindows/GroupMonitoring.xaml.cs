﻿using HTD.App.AddWindows;
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
    /// <summary>
    /// Interaction logic for GroupMonitoring.xaml
    /// </summary>
    public partial class GroupMonitoring : Window
    {
        public GroupMonitoring()
        {
            InitializeComponent();
        }

        private void RefreshTableB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenNewGroupB_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow window = new AddGroupWindow();
            window.Show();
        }
    }
}