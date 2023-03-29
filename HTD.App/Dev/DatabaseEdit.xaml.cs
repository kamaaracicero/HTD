using HTD.App.Dev.AddWindows;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Configuration;
using System.Threading.Tasks;
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

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await UpdateCoursesViewModel();
            await UpdateGroupsViewModel();
            await UpdateIncomesViewModel();
            await UpdateLessonsViewModel();
            await UpdateOutcomesViewModel();
            await UpdatePupilsViewModel();
            await UpdatePupilGroupsViewModel();
            await UpdateTeachersViewModel();
            await UpdateTeacherCoursesViewModel();
            await UpdateTypesViewModel();
        }

        private async Task UpdateCoursesViewModel()
        {
            var temp = await _courseService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading courses");
                DevLogger.AddLog("Failed to load courses", 0, LogClass.Error, LogItem.Course);
                return;
            }

            CoursesDG.ItemsSource = temp.Value;
            CoursesDG.Items.Refresh();
            DevLogger.AddLog("Courses loaded", 0, LogClass.Success, LogItem.Course);
        }

        private async Task UpdateGroupsViewModel()
        {
            var temp = await _groupService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading groups");
                DevLogger.AddLog("Failed to load groups", 0, LogClass.Error, LogItem.Group);
                return;
            }

            GroupsDG.ItemsSource = temp.Value;
            GroupsDG.Items.Refresh();
            DevLogger.AddLog("Groups loaded", 0, LogClass.Success, LogItem.Group);
        }

        private async Task UpdateIncomesViewModel()
        {
            var temp = await _incomeService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading incomes");
                DevLogger.AddLog("Failed to load incomes", 0, LogClass.Error, LogItem.Income);
                return;
            }

            IncomesDG.ItemsSource = temp.Value;
            IncomesDG.Items.Refresh();
            DevLogger.AddLog("Incomes loaded", 0, LogClass.Success, LogItem.Income);
        }

        private async Task UpdateLessonsViewModel()
        {
            var temp = await _lessonService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading lessons");
                DevLogger.AddLog("Failed to load lessons", 0, LogClass.Error, LogItem.Lesson);
                return;
            }

            LessonsDG.ItemsSource = temp.Value;
            LessonsDG.Items.Refresh();
            DevLogger.AddLog("Lessons loaded", 0, LogClass.Success, LogItem.Lesson);
        }

        private async Task UpdateOutcomesViewModel()
        {
            var temp = await _outcomeService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading outcomes");
                DevLogger.AddLog("Failed to load outcomes", 0, LogClass.Error, LogItem.Outcome);
                return;
            }

            OutcomesDG.ItemsSource = temp.Value;
            OutcomesDG.Items.Refresh();
            DevLogger.AddLog("Outcomes loaded", 0, LogClass.Success, LogItem.Outcome);
        }

        private async Task UpdatePupilGroupsViewModel()
        {
            var temp = await _pupilGroupService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading pupil groups");
                DevLogger.AddLog("Failed to load pupil groups", 0, LogClass.Error, LogItem.PupilGroup);
                return;
            }

            PupilGroupsDG.ItemsSource = temp.Value;
            PupilGroupsDG.Items.Refresh();
            DevLogger.AddLog("Pupil groups loaded", 0, LogClass.Success, LogItem.PupilGroup);
        }

        private async Task UpdatePupilsViewModel()
        {
            var temp = await _pupilService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading pupils");
                DevLogger.AddLog("Failed to load pupils", 0, LogClass.Error, LogItem.Pupil);
                return;
            }

            PupilsDG.ItemsSource = temp.Value;
            PupilsDG.Items.Refresh();
            DevLogger.AddLog("Pupils loaded", 0, LogClass.Success, LogItem.Pupil);
        }

        private async Task UpdateTeacherCoursesViewModel()
        {
            var temp = await _teacherCourseService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading teacher courses");
                DevLogger.AddLog("Failed to load teacher courses", 0, LogClass.Error, LogItem.TeacherCourse);
                return;
            }

            TeacherCoursesDG.ItemsSource = temp.Value;
            TeacherCoursesDG.Items.Refresh();
            DevLogger.AddLog("Teacher courses loaded", 0, LogClass.Success, LogItem.TeacherCourse);
        }

        private async Task UpdateTeachersViewModel()
        {
            var temp = await _teacherService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading teachers");
                DevLogger.AddLog("Failed to load teachers", 0, LogClass.Error, LogItem.Teacher);
                return;
            }

            TeachersDG.ItemsSource = temp.Value;
            TeachersDG.Items.Refresh();
            DevLogger.AddLog("Teachers loaded", 0, LogClass.Success, LogItem.Teacher);
        }

        private async Task UpdateTypesViewModel()
        {
            var temp = await _typeService.Select();
            if (!temp.Successfully)
            {
                MessageBox.Show("Error in loading types");
                DevLogger.AddLog("Failed to load types", 0, LogClass.Error, LogItem.Type);
                return;
            }

            TypesDG.ItemsSource = temp.Value;
            TypesDG.Items.Refresh();
            DevLogger.AddLog("Teachers loaded", 0, LogClass.Success, LogItem.Type);
        }

        private async void AddCourseMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddCourseMI Click", 0, LogClass.Event, LogItem.Course);

            AddCourse window = new AddCourse(_addCourseModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Course);

                var res = await _courseService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add course");

                    DevLogger.AddLog("Failed to add course to database", 1, LogClass.Error, LogItem.Course);
                }
                else
                    DevLogger.AddLog("Course added", 1, LogClass.Success, LogItem.Course);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Course);
            }

            await UpdateCoursesViewModel();
        }
        private async void DeleteCourseMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteCourseMI Click", 0, LogClass.Event, LogItem.Course);

            if (CoursesDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Course);

                return;
            }

            var item = CoursesDG.SelectedItem as Course;
            var res = await _courseService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Course);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Course);
            }

            await UpdateCoursesViewModel();
        }
        private void UpdateCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddGroupMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddGroupMI Click", 0, LogClass.Event, LogItem.Group);

            AddGroup window = new AddGroup(_addGroupModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Group);

                var res = await _groupService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add group");

                    DevLogger.AddLog("Failed to add group to database", 1, LogClass.Error, LogItem.Group);
                }
                else
                    DevLogger.AddLog("Group added", 1, LogClass.Success, LogItem.Group);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Group);
            }

            await UpdateGroupsViewModel();
        }
        private async void DeleteGroupMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteGroupMI Click", 0, LogClass.Event, LogItem.Group);

            if (GroupsDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Group);

                return;
            }

            var item = GroupsDG.SelectedItem as Group;
            var res = await _groupService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Group);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Group);
            }

            await UpdateGroupsViewModel();
        }
        private void UpdateGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddIncomeMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddIncomeMI Click", 0, LogClass.Event, LogItem.Income);

            AddIncome window = new AddIncome(_addIncomeModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Income);

                var res = await _incomeService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add income");

                    DevLogger.AddLog("Failed to add income to database", 1, LogClass.Error, LogItem.Income);
                }
                else
                    DevLogger.AddLog("Income added", 1, LogClass.Success, LogItem.Income);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Income);
            }

            await UpdateIncomesViewModel();
        }
        private async void DeleteIncomeMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteIncomeMI Click", 0, LogClass.Event, LogItem.Income);

            if (IncomesDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Income);

                return;
            }

            var item = IncomesDG.SelectedItem as Income;
            var res = await _incomeService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Income);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Income);
            }

            await UpdateIncomesViewModel();
        }
        private void UpdateIncomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddLessonMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddLessonMI Click", 0, LogClass.Event, LogItem.Lesson);

            AddLesson window = new AddLesson(_addLessonModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Lesson);

                var res = await _lessonService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add lesson");

                    DevLogger.AddLog("Failed to add lesson to database", 1, LogClass.Error, LogItem.Lesson);
                }
                else
                    DevLogger.AddLog("Lesson added", 1, LogClass.Success, LogItem.Lesson);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Lesson);
            }

            await UpdateLessonsViewModel();
        }
        private async void DeleteLessonMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteLessonMI Click", 0, LogClass.Event, LogItem.Lesson);

            if (LessonsDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Lesson);

                return;
            }

            var item = LessonsDG.SelectedItem as Lesson;
            var res = await _lessonService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Lesson);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Lesson);
            }

            await UpdateLessonsViewModel();
        }
        private void UpdateLessonMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddOutcomeMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddOutcomeMI Click", 0, LogClass.Event, LogItem.Outcome);

            AddOutcome window = new AddOutcome(_addOutcomeModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Outcome);

                var res = await _outcomeService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add outcome");

                    DevLogger.AddLog("Failed to add outcome to database", 1, LogClass.Error, LogItem.Outcome);
                }
                else
                    DevLogger.AddLog("Outcome added", 1, LogClass.Success, LogItem.Outcome);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Outcome);
            }

            await UpdateOutcomesViewModel();
        }
        private async void DeleteOutcomeMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteOutcomeMI Click", 0, LogClass.Event, LogItem.Outcome);

            if (OutcomesDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Outcome);

                return;
            }

            var item = OutcomesDG.SelectedItem as Outcome;
            var res = await _outcomeService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Outcome);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Outcome);
            }

            await UpdateOutcomesViewModel();
        }
        private void UpdateOutcomeMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddPupilMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddPupilMI Click", 0, LogClass.Event, LogItem.Pupil);

            AddPupil window = new AddPupil(_addPupilModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Pupil);

                var res = await _pupilService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add pupil");

                    DevLogger.AddLog("Failed to add pupil to database", 1, LogClass.Error, LogItem.Pupil);
                }
                else
                    DevLogger.AddLog("Pupil added", 1, LogClass.Success, LogItem.Pupil);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Pupil);
            }

            await UpdatePupilsViewModel();
        }
        private async void DeletePupilMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeletePupilMI Click", 0, LogClass.Event, LogItem.Pupil);

            if (PupilsDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Pupil);

                return;
            }

            var item = PupilsDG.SelectedItem as Pupil;
            var res = await _pupilService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Pupil);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Pupil);
            }

            await UpdatePupilsViewModel();
        }
        private void UpdatePupilMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddPupilGroupMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddPupilMI Click", 0, LogClass.Event, LogItem.PupilGroup);

            AddPupilGroup window = new AddPupilGroup(_addPupilGroupModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.PupilGroup);

                var res = await _pupilGroupService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add pupil group");

                    DevLogger.AddLog("Failed to add pupil group to database", 1, LogClass.Error, LogItem.PupilGroup);
                }
                else
                    DevLogger.AddLog("PupilGroup added", 1, LogClass.Success, LogItem.PupilGroup);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.PupilGroup);
            }

            await UpdatePupilGroupsViewModel();
        }
        private async void DeletePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeletePupilGroupMI Click", 0, LogClass.Event, LogItem.PupilGroup);

            if (PupilGroupsDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.PupilGroup);

                return;
            }

            var item = PupilGroupsDG.SelectedItem as PupilGroup;
            var res = await _pupilGroupService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.PupilGroup);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.PupilGroup);
            }

            await UpdatePupilGroupsViewModel();
        }
        private void UpdatePupilGroupMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddTeacherMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddTeacherMI Click", 0, LogClass.Event, LogItem.Teacher);

            AddTeacher window = new AddTeacher(_addTeacherModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Teacher);

                var res = await _teacherService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add teacher");

                    DevLogger.AddLog("Failed to add teacher to database", 1, LogClass.Error, LogItem.Teacher);
                }
                else
                    DevLogger.AddLog("Teacher added", 1, LogClass.Success, LogItem.Teacher);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Teacher);
            }

            await UpdateTeachersViewModel();
        }
        private async void DeleteTeacherMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteTeacherMI Click", 0, LogClass.Event, LogItem.Teacher);

            if (TeachersDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Teacher);

                return;
            }

            var item = TeachersDG.SelectedItem as Teacher;
            var res = await _teacherService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Teacher);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Teacher);
            }

            await UpdateTeachersViewModel();
        }
        private void UpdateTeacherMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddTeacherCourseMI Click", 0, LogClass.Event, LogItem.TeacherCourse);

            AddTeacherCourse window = new AddTeacherCourse(_addTeacherCourseModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.TeacherCourse);

                var res = await _teacherCourseService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add teacher course");

                    DevLogger.AddLog("Failed to add teacher course to database", 1, LogClass.Error, LogItem.TeacherCourse);
                }
                else
                    DevLogger.AddLog("TeacherCourse added", 1, LogClass.Success, LogItem.TeacherCourse);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.TeacherCourse);
            }

            await UpdateTeacherCoursesViewModel();
        }
        private async void DeleteTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteTeacherMI Click", 0, LogClass.Event, LogItem.TeacherCourse);

            if (TeacherCoursesDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.TeacherCourse);

                return;
            }

            var item = TeacherCoursesDG.SelectedItem as TeacherCourse;
            var res = await _teacherCourseService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.TeacherCourse);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.TeacherCourse);
            }

            await UpdateTeacherCoursesViewModel();
        }
        private void UpdateTeacherCourseMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void AddTypeMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddTeacherMI Click", 0, LogClass.Event, LogItem.Type);

            AddType window = new AddType(_addTypeModelConverter);
            if (window.ShowDialog().Value)
            {
                DevLogger.AddLog("Value received", 1, LogClass.Event, LogItem.Type);

                var res = await _typeService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Error. Cannot add type");

                    DevLogger.AddLog("Failed to add type to database", 1, LogClass.Error, LogItem.Type);
                }
                else
                    DevLogger.AddLog("Type added", 1, LogClass.Success, LogItem.Type);
            }
            else
            {
                DevLogger.AddLog("Window closed", 0, LogClass.Event, LogItem.Type);
            }

            await UpdateTypesViewModel();
        }
        private async void DeleteTypeMI_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("DeleteTypeMI Click", 0, LogClass.Event, LogItem.Type);

            if (TypesDG.SelectedItem == null)
            {
                DevLogger.AddLog("Item is null", 1, LogClass.Event, LogItem.Type);

                return;
            }

            var item = TypesDG.SelectedItem as Type;
            var res = await _typeService.Delete(item);
            if (res.Successfully)
            {
                MessageBox.Show("Item deleted");
                DevLogger.AddLog("Item deleted", 1, LogClass.Success, LogItem.Type);
            }
            else
            {
                MessageBox.Show("Error");
                DevLogger.AddLog("Delete is not completed", 1, LogClass.Error, LogItem.Type);
            }

            await UpdateTypesViewModel();
        }
        private void UpdateTypeMI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
