using HTD.DataEntities;
using System.Windows;
using System.Collections.Generic;

namespace HTD.App.AddWindows
{
    public partial class AddCourseWindow : Window
    {
        public AddCourseWindow()
        {
            AddedTeachers = new List<Teacher>();

            InitializeComponent();
        }

        public List<Teacher> AddedTeachers { get; private set; }

        public Course Value { get; private set; }

        private void AddNewTypeB_Click(object sender, RoutedEventArgs e)
        {
            AddCourseTypeWindow window = new AddCourseTypeWindow();
            if (window.ShowDialog().Value)
            {

            }
        }
    }
}
