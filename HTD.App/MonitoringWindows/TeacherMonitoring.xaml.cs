using HTD.App.AddWindows;
using HTD.App.Configuration;
using HTD.App.Elements.TeacherMonitoring;
using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Filters;
using HTD.BusinessLogic.Filters.Settings;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace HTD.App.MonitoringWindows
{
    public partial class TeacherMonitoring : Window
    {
        private readonly IService<Course> _courseService;
        private readonly IService<Group> _groupService;
        private readonly IService<Teacher> _teacherService;
        private readonly IService<TeacherCourse> _teacherCourseService;
        private readonly IFilter<Teacher> _teacherNameFilter;

        public TeacherMonitoring()
        {
            _courseService = AppServicesConfiguration.CourseService;
            _groupService = AppServicesConfiguration.GroupService;
            _teacherService = AppServicesConfiguration.TeacherService;
            _teacherCourseService = AppServicesConfiguration.TeacherCourseService;
            _teacherNameFilter = AppFilerConfiguration.TeacherNameFilter;

            Teachers = new List<Teacher>();
            Courses = new List<Course>();

            InitializeComponent();
            TeachersDG.BeginningEdit += (s, ss) => ss.Cancel = true;
        }

        public List<Teacher> Teachers { get; set; }

        public List<Course> Courses { get; set; }

        public List<Group> Groups { get; set; }

        public List<TeacherCourse> TeacherCourses { get; set; }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await LoadTeachersData();
            await LoadCoursesData();
            await LoadGroupsData();
            await LoadTeacherCoursesData();

            UpdateTeachersView();
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
                Courses = res.Value.ToList();
            }
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
                Groups = res.Value.ToList();
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

        private void UpdateTeachersView()
        {
            var temp = Teachers;
            if (!string.IsNullOrEmpty(SearchTB.Text))
                temp = _teacherNameFilter.Filter(Teachers, new TeacherNameFilterSettings
                    { SearchName = SearchTB.Text }).ToList();

            UpdateTeacherView();

            TeachersDG.ItemsSource = temp.Select(t => new TeacherDataGridRow(t));
            TeachersDG.Items.Refresh();
        }

        private void UpdateTeacherView()
        {
            NameTB.Text = string.Empty;
            PhoneTB.Text = string.Empty;
            CoursesAndGroupsRTB.Document = new FlowDocument();
            StartWorkDateTB.Text = string.Empty;
        }

        private void UpdateTeacherView(Teacher teacher)
        {
            NameTB.Text = teacher.Name;
            PhoneTB.Text = teacher.Phone;
            CoursesAndGroupsRTB.Document = CreateDocument(teacher);
            StartWorkDateTB.Text = teacher.DateStartWork.ToShortDateString();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e) => UpdateTeachersView();

        private void UpdateTeacherB_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersDG.SelectedItem == null)
                return;
        }

        private async void FireTeacherB_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersDG.SelectedItem == null)
                return;

            Teacher teacher = (TeachersDG.SelectedItem as TeacherDataGridRow).Instance;
            if (MessageBox.Show($"Уволить {teacher.Name}?", "Предупреждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var res = await _teacherService.Delete(teacher);
                if (res.Successfully)
                {
                    await LoadTeacherCoursesData();
                    await LoadTeachersData();
                    UpdateTeachersView();
                }
                else
                {
                    MessageBox.Show("Не удалось уволить преподавателя", "Ошибка");
                    await LoadTeacherCoursesData();
                    await LoadTeachersData();
                    UpdateTeachersView();
                }
            }
        }

        private async void AddTeacherB_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherWindow window = new AddTeacherWindow();
            if (window.ShowDialog().Value)
            {
                var res = await _teacherService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Не удалось добавить преподавателя", "Ошибка");
                }
                else
                {
                    await LoadTeachersData();
                    UpdateTeachersView();
                }
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void RefreshTableB_Click(object sender, RoutedEventArgs e)
        {
            await LoadTeachersData();
            await LoadCoursesData();
            await LoadGroupsData();
            await LoadTeacherCoursesData();

            UpdateTeachersView();
        }

        private void TeachersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeachersDG.SelectedItem != null)
            {
                var temp = TeachersDG.SelectedItem as TeacherDataGridRow;
                UpdateTeacherView(temp.Instance);
            }
        }

        private FlowDocument CreateDocument(Teacher teacher)
        {
            var teacherCourses = DependencySearch.FindTeacherCourses(teacher, TeacherCourses, Courses);
            FlowDocument document = new FlowDocument();
            foreach (var course in teacherCourses)
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(new Bold(new Run($"{course.Name}\n")));
                var groups = DependencySearch.FindCourseGroups(course, Groups);
                foreach (var group in groups)
                    paragraph.Inlines.Add(new Span(new Run($"    - {group.Name}\n")));

                document.Blocks.Add(paragraph);
            }

            return document;
        }
    }
}
