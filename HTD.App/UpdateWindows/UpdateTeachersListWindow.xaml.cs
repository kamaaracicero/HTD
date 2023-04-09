using HTD.App.Configuration;
using HTD.App.Elements.UpdateTeachersListWindow;
using HTD.BusinessLogic.DataSearchs;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HTD.App.UpdateWindows
{
    public partial class UpdateTeachersListWindow : Window
    {
        public IService<Teacher> _teacherService;
        public IService<TeacherCourse> _teacherCourseService;

        public UpdateTeachersListWindow(Course course)
        {
            _teacherService = AppConfiguration.TeacherService;
            _teacherCourseService = AppConfiguration.TeacherCourseService;

            Course = course;

            InitializeComponent();
        }

        public Course Course { get; set; }

        public List<Teacher> AddedTeachers { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<TeacherCourse> TeacherCourses { get; set; }

        private async void Window_Initialized(object sender, System.EventArgs e)
        {
            await LoadTeachersData();
            await LoadTeacherCoursesData();

            LoadAddedTeachers();

            UpdateAddedTeachersView();
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

        private void LoadAddedTeachers()
        {
            AddedTeachers = new List<Teacher>();
            AddedTeachers.AddRange(DependencyHelper.FindCourseTeachers(Course, TeacherCourses, Teachers));
        }

        private void UpdateAddedTeachersView()
        {
            AddedTeachersLB.ItemsSource = AddedTeachers.Select(t => new TeacherListBoxItem(t));
            AddedTeachersLB.Items.Refresh();
        }

        private void UpdateTeachersView()
        {
            var temp = Teachers.Where(t => t.Name.StartsWith(SearchByTeacherNameTB.Text,
                StringComparison.OrdinalIgnoreCase));
            TeachersLB.ItemsSource = temp
                .Where(t => !AddedTeachers.Contains(t))
                .Select(t => new TeacherListBoxItem(t));
            TeachersLB.Items.Refresh();
        }

        private async void AddTeacherB_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersLB.SelectedItem == null)
                return;

            var teacher = (TeachersLB.SelectedItem as TeacherListBoxItem).Instance;
            var res = await _teacherCourseService.Insert(new TeacherCourse(0, teacher.Id, Course.Id));
            if (res.Successfully)
            {
                await LoadTeacherCoursesData();

                LoadAddedTeachers();
                UpdateAddedTeachersView();
                UpdateTeachersView();
            }
            else
            {
                MessageBox.Show("Не удалось добавить преподавателя", "Ошибка");
                await LoadTeachersData();
                await LoadTeacherCoursesData();

                LoadAddedTeachers();
                UpdateAddedTeachersView();
                UpdateTeachersView();
            }
        }

        private async void DeleteAddedTeacherMI_Click(object sender, RoutedEventArgs e)
        {
            if (AddedTeachersLB.SelectedItem == null)
                return;

            var teacher = (AddedTeachersLB.SelectedItem as TeacherListBoxItem).Instance;
            var dependency = TeacherCourses.FirstOrDefault(d => d.CourseId == Course.Id && d.TeacherId == teacher.Id);
            if (dependency == null)
            {
                MessageBox.Show("Не удалось найти зависимость. Откройте окно заново", "Ошибка");
                DialogResult = false;
                Close();
            }

            var res = await _teacherCourseService.Delete(dependency);
            if (res.Successfully)
            {
                await LoadTeacherCoursesData();

                LoadAddedTeachers();
                UpdateAddedTeachersView();
                UpdateTeachersView();
            }
            else
            {
                MessageBox.Show("Не удалось отстранить преподавателя", "Ошибка");
                await LoadTeachersData();
                await LoadTeacherCoursesData();

                LoadAddedTeachers();
                UpdateAddedTeachersView();
                UpdateTeachersView();
            }
        }

        private void SearchByTeacherNameTB_TextChanged(object sender, TextChangedEventArgs e) => UpdateTeachersView();

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }
    }
}
