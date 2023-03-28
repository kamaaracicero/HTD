using HTD.App.Dev.AddWindows;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev
{
    public partial class DatabaseEdit : Window
    {
        private readonly IModelConverter<AddCourseModel, Course> _addCourseModelConverter;
        private readonly IModelConverter<AddGroupModel, Group> _addGroupModelConverter;
        private readonly IModelConverter<AddIncomeModel, Income> _addIncomeModelConverter;
        private readonly IModelConverter<AddLessonModel, Lesson> _addLessonModelConverter;
        private readonly IModelConverter<AddOutcomeModel, Outcome> _addOutcomeModelConverter;
        private readonly IModelConverter<AddPupilGroupModel, PupilGroup> _addPupilGroupModelConverter;
        private readonly IModelConverter<AddPupilModel, Pupil> _addPupilModelConverter;
        private readonly IModelConverter<AddTeacherCourseModel, TeacherCourse> _addTeacherCourseModelConverter;
        private readonly IModelConverter<AddTeacherModel, Teacher> _addTeacherModelConverter;
        private readonly IModelConverter<AddTypeModel, Type> _addTypeModelConverter;

        public DatabaseEdit()
        {
            _addCourseModelConverter = new AddCourseModelConverter();

            InitializeComponent();
        }

        private void AddCourseMI_Click(object sender, RoutedEventArgs e)
        {
            AddCourse window = new AddCourse(_addCourseModelConverter);
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
            AddGroup window = new AddGroup(_addGroupModelConverter);
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
            AddIncome window = new AddIncome(_addIncomeModelConverter);
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
            AddLesson window = new AddLesson(_addLessonModelConverter);
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
            AddOutcome window = new AddOutcome(_addOutcomeModelConverter);
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
            AddPupil window = new AddPupil(_addPupilModelConverter);
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
            AddPupilGroup window = new AddPupilGroup(_addPupilGroupModelConverter);
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
            AddTeacher window = new AddTeacher(_addTeacherModelConverter);
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
            AddTeacherCourse window = new AddTeacherCourse(_addTeacherCourseModelConverter);
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
            AddType window = new AddType(_addTypeModelConverter);
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
