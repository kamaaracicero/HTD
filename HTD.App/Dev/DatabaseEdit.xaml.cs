using HTD.App.Dev.AddWindows;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Configuration;
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

        private readonly IService<Course> _courseService;
        private readonly IService<Group> _groupService;
        private readonly IService<Income> _incomeService;
        private readonly IService<Lesson> _lessonService;
        private readonly IService<Outcome> _outcomeService;
        private readonly IService<PupilGroup> _pupilGroupService;
        private readonly IService<Pupil> _pupilService;
        private readonly IService<TeacherCourse> _teacherCourseService;
        private readonly IService<Teacher> _teacherService;
        private readonly IService<Type> _typeService;

        public DatabaseEdit()
        {
#if DEBUG
            var connectionString = ConfigurationManager.ConnectionStrings["DevDB"].ConnectionString;
#else
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;
#endif
            _addCourseModelConverter = new AddCourseModelConverter();
            _addGroupModelConverter = new AddGroupModelConverter();
            _addIncomeModelConverter = new AddIncomeModelConverter();
            _addLessonModelConverter = new AddLessonModelConverter();
            _addOutcomeModelConverter = new AddOutcomeModelConverter();
            _addPupilGroupModelConverter = new AddPupilGroupModelConverter();
            _addPupilModelConverter = new AddPupilModelConverter();
            _addTeacherCourseModelConverter = new AddTeacherCourseModelConverter();
            _addTeacherModelConverter = new AddTeacherModelConverter();
            _addTypeModelConverter = new AddTypeModelConverter();

            _courseService = new CourseService(connectionString);
            _groupService = new GroupService(connectionString);
            _incomeService = new IncomeService(connectionString);
            _lessonService = new LessonService(connectionString);
            _outcomeService = new OutcomeService(connectionString);
            _pupilGroupService =new PupilGroupService(connectionString);
            _pupilService = new PupilService(connectionString);
            _teacherCourseService = new TeacherCourseService(connectionString);
            _teacherService = new TeacherService(connectionString);
            _typeService = new TypeService(connectionString);

            InitializeComponent();
        }

        private async void AddCourseMI_Click(object sender, RoutedEventArgs e)
        {
            AddCourse window = new AddCourse(_addCourseModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _courseService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add course");
            }
        }
        private void DeleteCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddGroupMI_Click(object sender, RoutedEventArgs e)
        {
            AddGroup window = new AddGroup(_addGroupModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _groupService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add group");
            }
        }
        private void DeleteGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddIncomeMI_Click(object sender, RoutedEventArgs e)
        {
            AddIncome window = new AddIncome(_addIncomeModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _incomeService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add group");
            }
        }
        private void DeleteIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddLessonMI_Click(object sender, RoutedEventArgs e)
        {
            AddLesson window = new AddLesson(_addLessonModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _lessonService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add lesson");
            }
        }
        private void DeleteLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddOutcomeMI_Click(object sender, RoutedEventArgs e)
        {
            AddOutcome window = new AddOutcome(_addOutcomeModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _outcomeService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add group");
            }
        }
        private void DeleteOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddPupilMI_Click(object sender, RoutedEventArgs e)
        {
            AddPupil window = new AddPupil(_addPupilModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _pupilService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add pupil");
            }
        }
        private void DeletePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdatePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddPupilGroupMI_Click(object sender, RoutedEventArgs e)
        {
            AddPupilGroup window = new AddPupilGroup(_addPupilGroupModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _pupilGroupService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add pupil group");
            }
        }
        private void DeletePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdatePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddTeacherMI_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher window = new AddTeacher(_addTeacherModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _teacherService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add teacher");
            }
        }
        private void DeleteTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherCourse window = new AddTeacherCourse(_addTeacherCourseModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _teacherCourseService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add teacher course");
            }
        }
        private void DeleteTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddTypeMI_Click(object sender, RoutedEventArgs e)
        {
            AddType window = new AddType(_addTypeModelConverter);
            if (window.ShowDialog().Value)
            {
                var res = await _typeService.Insert(window.Value);
                if (!res.Successfully)
                    MessageBox.Show("Error. Cannot add type");
            }
        }
        private void DeleteTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
        private void UpdateTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
