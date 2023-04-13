using HTD.App.AddWindows;
using HTD.App.Configuration;
using HTD.App.Elements.CourseMonitoring;
using HTD.App.Elements.GroupsMonitoring;
using HTD.App.Elements.PupilMonitoring;
using HTD.App.Elements.TeacherMonitoring;
using HTD.App.UpdateWindows;
using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Filters;
using HTD.BusinessLogic.Filters.Settings;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTD.App.MonitoringWindows
{
    public partial class CourseMonitoring : Window
    {
        private readonly IService<Course> _courseService;
        private readonly IService<Group> _groupService;
        private readonly IService<Teacher> _teacherService;
        private readonly IService<TeacherCourse> _teacherCourseService;
        private readonly IService<Pupil> _pupilService;
        private readonly IService<PupilGroup> _pupilGroupService;

        private readonly IFilter<Course> _filter;

        public CourseMonitoring()
        {
            _courseService = AppConfiguration.CourseService;
            _groupService = AppConfiguration.GroupService;
            _teacherService = AppConfiguration.TeacherService;
            _teacherCourseService = AppConfiguration.TeacherCourseService;
            _pupilService = AppConfiguration.PupilService;
            _pupilGroupService = AppConfiguration.PupilGroupService;

            _filter = AppConfiguration.CourseFilter;

            InitializeComponent();
            CoursesDG.BeginningEdit += (s, ss) => ss.Cancel = true;
        }

        public List<Course> Courses { get; set; }
        public List<Group> Groups { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
        public List<Pupil> Pupils { get; set; }
        public List<PupilGroup> PupilGroups { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadCoursesData();
            await LoadGroupsData();
            await LoadTeachersData();
            await LoadTeacherCoursesData();
            await LoadPupilsData();
            await LoadPupilGroupsData();

            UpdateCoursesView();
        }

        private async void RefreshTableB_Click(object sender, RoutedEventArgs e)
        {
            await LoadCoursesData();
            await LoadGroupsData();
            await LoadTeachersData();
            await LoadTeacherCoursesData();
            await LoadPupilsData();
            await LoadPupilGroupsData();

            UpdateCoursesView();
        }

        private void UpdateCoursesView()
        {
            var temp = _filter.Filter(Courses, new CourseFilterSettings
            {
                NameTB = SearchCourseNameTB.Text,
                TeacherNameTB = SearchTeacherNameTB.Text,
                TeacherCourses = TeacherCourses,
                Teachers = Teachers,
            }).ToList();

            UpdateDetailsView();

            CoursesDG.ItemsSource = temp.Select(t => new CourseDataGridRow(t));
            CoursesDG.Items.Refresh();
        }

        private void UpdateDetailsView()
        {
            PupilCountTB.Text = string.Empty;
            GroupCountTB.Text = string.Empty;
            CourseTeachersLB.ItemsSource = null;
            CourseTeachersLB.Items.Refresh();
        }

        private void UpdateDetailsView(Course course)
        {
            PupilCountTB.Text = DependencyHelper
                .FindCoursePupils(course, Groups, PupilGroups, Pupils)
                .Count().ToString();
            GroupCountTB.Text = DependencyHelper
                .FindCourseGroups(course, Groups)
                .Count().ToString();
            CourseTeachersLB.ItemsSource = DependencyHelper
                .FindCourseTeachers(course, TeacherCourses, Teachers)
                .Select(t => new TeacherListBoxItem(t));
            CourseTeachersLB.Items.Refresh();
        }

        private async Task LoadGroupsData()
        {
            var res = await _groupService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных групп", "Ошибка");
                return;
            }
            else
            {
                Groups = res.Value.Where(g => g.IsActive == true).ToList();
            }
        }

        private async Task LoadTeachersData()
        {
            var res = await _teacherService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных преподавателей", "Ошибка");
                return;
            }
            else
            {
                Teachers = res.Value.ToList();
            }
        }

        private async Task LoadTeacherCoursesData()
        {
            var res = await _teacherCourseService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке зависимостей", "Ошибка");
                return;
            }
            else
            {
                TeacherCourses = res.Value.ToList();
            }
        }

        private async Task LoadCoursesData()
        {
            var res = await _courseService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных кружков", "Ошибка");
                return;
            }
            else
            {
                Courses = res.Value.Where(c => c.IsActive == true).ToList();
            }
        }

        private async Task LoadPupilsData()
        {
            var res = await _pupilService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных учеников", "Ошибка");
                return;
            }
            else
            {
                Pupils = res.Value.Where(p => p.IsExpelled == false).ToList();
            }
        }

        private async Task LoadPupilGroupsData()
        {
            var res = await _pupilGroupService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке зависимостей", "Ошибка");
                return;
            }
            else
            {
                PupilGroups = res.Value.ToList();
            }
        }

        private void ShowGroupsB_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDG.SelectedItem == null)
                return;

            Course course = (CoursesDG.SelectedItem as CourseDataGridRow).Instance;
            GroupMonitoring monitoring = new GroupMonitoring(course);
            monitoring.Show();

            WindowState = WindowState.Minimized;
        }

        private async void AddCourseB_Click(object sender, RoutedEventArgs e)
        {
            AddCourseWindow window = new AddCourseWindow();
            if (window.ShowDialog().Value)
            {
                var res = await _courseService.Insert(window.Value);
                foreach (var teacher in window.AssignedTeachers)
                {
                    var teacherRes = await _teacherCourseService
                        .Insert(new TeacherCourse(0, teacher.Id, window.Value.Id));
                    if (!teacherRes.Successfully)
                        MessageBox.Show("Не удалось добавить зависимость", "Ошибка");
                }
                if (!res.Successfully)
                {
                    MessageBox.Show("Не удалось добавить кружок", "Ошибка");
                }
                else
                {
                    await LoadCoursesData();
                    await LoadTeacherCoursesData();

                    UpdateCoursesView();
                }
            }
        }

        private void CoursesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoursesDG.SelectedItem != null)
            {
                var temp = CoursesDG.SelectedItem as CourseDataGridRow;
                UpdateDetailsView(temp.Instance);
            }
        }

        private void SearchCourseNameTB_TextChanged(object sender, TextChangedEventArgs e) => UpdateCoursesView();

        private void SearchTeacherNameTB_TextChanged(object sender, TextChangedEventArgs e) => UpdateCoursesView();

        private async void ArchiveCourseB_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDG.SelectedItem == null)
                return;

            var course = (CoursesDG.SelectedItem as CourseDataGridRow).Instance;
            if (MessageBox.Show("Поместить выбранный кружок в архив?", "Предупреждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                course.IsActive = false;
                var courseRes = await _courseService.Update(course);
                if (!courseRes.Successfully)
                    MessageBox.Show("Не удалось архивировать кружок", "Ошибка");

                var groups = DependencyHelper.FindCourseGroups(course, Groups);
                var flag = false;
                foreach (var group in groups)
                {
                    group.IsActive = false;
                    var groupRes = await _groupService.Update(group);
                    if (!groupRes.Successfully)
                        flag = true;
                }
                if (flag)
                    MessageBox.Show("Не удалось архивировать группы кружка", "Ошибка");

                await LoadCoursesData();
                await LoadGroupsData();
                UpdateCoursesView();
            }
        }

        private async void RedactTeachersMI_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDG.SelectedItem == null)
                return;

            var course = (CoursesDG.SelectedItem as CourseDataGridRow).Instance;
            UpdateTeachersListWindow window = new UpdateTeachersListWindow(course);
            if (window.ShowDialog().Value)
            {
                await LoadTeacherCoursesData();
                UpdateCoursesView();
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
