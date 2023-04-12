using HTD.DataEntities;
using System.Windows;
using System.Collections.Generic;
using HTD.BusinessLogic.Services;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using System.Threading.Tasks;
using System.Linq;
using HTD.App.Elements.AddCourseWindow;
using HTD.App.Configuration;
using System.Windows.Input;
using HTD.BusinessLogic.ErrorMessageGenerators;
using System;

namespace HTD.App.AddWindows
{
    public partial class AddCourseWindow : Window
    {
        private readonly IService<CourseType> _courseTypeService;
        private readonly IService<Teacher> _teacherService;

        private readonly IModelConverter<CourseModel, Course> _converter;

        public AddCourseWindow()
        {
            _courseTypeService = AppConfiguration.CourseTypeService;
            _teacherService = AppConfiguration.TeacherService;

            _converter = AppConfiguration.AddCourseConverter;

            AssignedTeachers = new List<Teacher>();

            InitializeComponent();
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await LoadTeachersData();
            await LoadCourseTypesData();

            UpdateTeachersComboBoxView();
            UpdateCourseTypesComboBoxView();
        }

        public List<Teacher> AssignedTeachers { get; private set; }

        public Course Value { get; private set; }

        public List<CourseType> CourseTypes { get; set; }

        public List<Teacher> Teachers { get; set; }

        private void UpdateTeachersComboBoxView()
        {
            List<TeacherComboBoxItem> items = new List<TeacherComboBoxItem>
            {
                new TeacherComboBoxItem(null, "Без выбора"),
            };
            items.AddRange(Teachers.Select(t => new TeacherComboBoxItem(t)));

            TeachersCB.ItemsSource = items;
            TeachersCB.Items.Refresh();
            TeachersCB.SelectedIndex = 0;
        }

        private void UpdateTeachersView()
        {
            if (AssignedTeachers.Count == 0)
            {
                AssignedTeachersLB.ItemsSource = null;
                AssignedTeachersLB.Items.Refresh();
            }
            else
            {
                AssignedTeachersLB.ItemsSource = AssignedTeachers.Select(t => new TeacherListBoxItem(t));
                AssignedTeachersLB.Items.Refresh();
            }
        }

        private void UpdateCourseTypesComboBoxView()
        {
            if (CourseTypes.Count == 0)
                return;

            CourseTypesCB.ItemsSource = CourseTypes.Select(c => new CourseTypeComboBoxItem(c));
            CourseTypesCB.Items.Refresh();
            CourseTypesCB.SelectedIndex = 0;
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

        private async Task LoadCourseTypesData()
        {
            var res = await _courseTypeService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных типов кружков", "Ошибка");
                return;
            }
            else
            {
                CourseTypes = res.Value.ToList();
            }
        }

        private async void AddNewTypeB_Click(object sender, RoutedEventArgs e)
        {
            AddCourseTypeWindow window = new AddCourseTypeWindow();
            if (window.ShowDialog().Value)
            {
                var res = await _courseTypeService.Insert(window.Value);
                if (!res.Successfully)
                {
                    MessageBox.Show("Не удалось добавить тип кружка", "Ошибка");
                }
                else
                {
                    await LoadCourseTypesData();
                    UpdateCourseTypesComboBoxView();
                }
            }
        }

        private void AddTeacherB_Click(object sender, RoutedEventArgs e)
        {
            var instance = (TeachersCB.SelectedItem as TeacherComboBoxItem).Instance;
            if (instance == null)
                return;
            else
            {
                if (AssignedTeachers.Contains(instance))
                    return;

                AssignedTeachers.Add(instance);
                UpdateTeachersView();
            }
        }

        private void DeleteTeacherMI_Click(object sender, RoutedEventArgs e)
        {
            if (AssignedTeachersLB.SelectedItem == null)
                return;

            var instance = (AssignedTeachersLB.SelectedItem as TeacherListBoxItem).Instance;
            AssignedTeachers.Remove(instance);
            UpdateTeachersView();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SetValue()
        {
            if (CourseTypesCB.SelectedItem == null)
            {
                MessageBox.Show("Требуется выбрать тип кружка", "Ошибка");
                return;
            }

            CourseModel model = new CourseModel
            {
                NameTB = NameTB.Text.Trim(),
                TypeCB = (CourseTypesCB.SelectedItem as CourseTypeComboBoxItem).Instance,
            };

            var res = _converter.ConvertModel(model);
            if (!res.IsError)
            {
                Value = res.Value;
                DialogResult = true;
                Close();
            }
            else
            {
                var message = ErrorsListGenerator.GenerateMessage("Ошибка в обработке данных:", res.Errors);
                MessageBox.Show(message, "Ошибка");
            }
        }

        private void AddB_Click(object sender, RoutedEventArgs e) => SetValue();

        private void NameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetValue();
        }
    }
}
