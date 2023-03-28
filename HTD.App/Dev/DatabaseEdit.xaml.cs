using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HTD.App.Dev
{
    public partial class DatabaseEdit : Window
    {
        public DatabaseEdit()
        {
            InitializeComponent();
            CoursesDG.ItemsSource = new List<Course>
            {
                new Course(1, "temp_1", 1, false),
                new Course(2, "temp_2", 2, true),
            };
            GroupsDG.ItemsSource = new List<Group>
            {
                new Group(1, 1, "temp_1", 2012, true, true),
                new Group(2, 2, "temp_2", 2013, false, true),
            };
            IncomesDG.ItemsSource = new List<Income>
            {
                new Income(1, 1, 1, "income_1", new DateTime(2020, 1, 1), false),
                new Income(2, 2, 2, "income_2", new DateTime(2021, 2, 2), true),
            };
            LessonsDG.ItemsSource = new List<Lesson>
            {
                new Lesson(1, 1, 1, new DateTime(2022, 1, 1), new DateTime(2022, 2, 2), 104, new DateTime(2023, 2, 3)),
                new Lesson(2, 2, 2, new DateTime(2012, 1, 1), new DateTime(2012, 2, 2), 12, new DateTime(2013, 2, 3)),
            };
        }

        private void AddCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPupilMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeletePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdatePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeletePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdatePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
