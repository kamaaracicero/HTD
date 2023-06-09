﻿using HTD.App.AddWindows;
using HTD.App.Configuration;
using HTD.App.Elements.TeacherMonitoring;
using HTD.App.UpdateWindows;
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

        private readonly IFilter<Teacher> _filter;

        public TeacherMonitoring()
        {
            _courseService = AppConfiguration.CourseService;
            _groupService = AppConfiguration.GroupService;
            _teacherService = AppConfiguration.TeacherService;
            _teacherCourseService = AppConfiguration.TeacherCourseService;
            _filter = AppConfiguration.TeacherFilter;

            Teachers = new List<Teacher>();
            TeacherCourses = new List<TeacherCourse>();
            Courses = new List<Course>();
            Groups = new List<Group>();

            InitializeComponent();
            TeachersDG.BeginningEdit += (s, ss) => ss.Cancel = true;
        }

        public List<Teacher> Teachers { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
        public List<Course> Courses { get; set; }
        public List<Group> Groups { get; set; }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await LoadTeachersData();
            await LoadCoursesData();
            await LoadGroupsData();
            await LoadTeacherCoursesData();

            UpdateTeachersView();
        }

        private async void RefreshTableB_Click(object sender, RoutedEventArgs e)
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
                Courses = res.Value.Where(c => c.IsActive == true).ToList();
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
                Groups = res.Value.Where(g => g.IsActive == true).ToList();
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
            var temp = _filter.Filter(Teachers, new TeacherFilterSettings
            {
                SearchName = SearchTB.Text
            }).ToList();

            UpdateDetailsView();

            TeachersDG.ItemsSource = temp.Select(t => new TeacherDataGridRow(t));
            TeachersDG.Items.Refresh();
        }

        private void UpdateDetailsView()
        {
            NameTB.Text = string.Empty;
            PhoneTB.Text = string.Empty;
            CoursesAndGroupsRTB.Document = new FlowDocument();
            StartWorkDateTB.Text = string.Empty;
        }

        private void UpdateDetailsView(Teacher teacher)
        {
            NameTB.Text = teacher.Name;
            PhoneTB.Text = teacher.Phone;
            CoursesAndGroupsRTB.Document = CreateDocument(teacher);
            StartWorkDateTB.Text = teacher.DateStartWork.ToShortDateString();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e) => UpdateTeachersView();

        private async void UpdateTeacherB_Click(object sender, RoutedEventArgs e)
        {
            if (TeachersDG.SelectedItem == null)
                return;

            var teacher = (TeachersDG.SelectedItem as TeacherDataGridRow).Instance;
            UpdateTeacherWindow window = new UpdateTeacherWindow(teacher);
            if (window.ShowDialog().Value)
            {
                var res = await _teacherService.Update(window.Value);
                if (res.Successfully)
                {
                    await LoadTeachersData();
                    UpdateTeachersView();
                }
                else
                {
                    MessageBox.Show("Не удалось редактировать преподавателя", "Ошибка");
                    await LoadTeachersData();
                    UpdateTeachersView();
                }
            }
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

        private void TeachersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeachersDG.SelectedItem != null)
            {
                var temp = TeachersDG.SelectedItem as TeacherDataGridRow;
                UpdateDetailsView(temp.Instance);
            }
        }

        private FlowDocument CreateDocument(Teacher teacher)
        {
            var teacherCourses = DependencyHelper.FindTeacherCourses(teacher, TeacherCourses, Courses);
            FlowDocument document = new FlowDocument();
            foreach (var course in teacherCourses)
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(new Bold(new Run($"{course.Name}\n")));
                var groups = DependencyHelper.FindCourseGroups(course, Groups);
                foreach (var group in groups)
                    paragraph.Inlines.Add(new Span(new Run($"    - {group.Name}\n")));

                document.Blocks.Add(paragraph);
            }

            return document;
        }
    }
}
