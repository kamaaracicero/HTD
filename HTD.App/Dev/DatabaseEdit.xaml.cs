using HTD.App.Dev.AddWindows;
using System.Windows;

namespace HTD.App.Dev
{
    public partial class DatabaseEdit : Window
    {
        public DatabaseEdit()
        {
            InitializeComponent();
        }

        private void AddCourseMI_Click(object sender, RoutedEventArgs e)
        {
            AddCourse window = new AddCourse();
            window.ShowDialog();
        }
        private void DeleteCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddGroupMI_Click(object sender, RoutedEventArgs e)
        {
            AddGroup window = new AddGroup();
            window.Show();
        }
        private void DeleteGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddIncomeMI_Click(object sender, RoutedEventArgs e)
        {
            AddIncome window = new AddIncome();
            window.Show();
        }
        private void DeleteIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddLessonMI_Click(object sender, RoutedEventArgs e)
        {
            AddLesson window = new AddLesson();
            window.Show();
        }
        private void DeleteLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOutcomeMI_Click(object sender, RoutedEventArgs e)
        {
            AddOutcome window = new AddOutcome();
            window.Show();
        }
        private void DeleteOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPupilMI_Click(object sender, RoutedEventArgs e)
        {
            AddPupil window = new AddPupil();
            window.Show();
        }
        private void DeletePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdatePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPupilGroupMI_Click(object sender, RoutedEventArgs e)
        {
            AddPupilGroup window = new AddPupilGroup();
            window.Show();
        }
        private void DeletePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdatePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTeacherMI_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher window = new AddTeacher();
            window.Show();
        }
        private void DeleteTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherCourse window = new AddTeacherCourse();
            window.Show();
        }
        private void DeleteTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTypeMI_Click(object sender, RoutedEventArgs e)
        {
            AddType window = new AddType();
            window.Show();
        }
        private void DeleteTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
