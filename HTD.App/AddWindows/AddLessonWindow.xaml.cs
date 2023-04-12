using HTD.App.Configuration;
using HTD.App.Elements.AddLessonWindow;
using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HTD.App.AddWindows
{
    public partial class AddLessonWindow : Window
    {
        private readonly IService<Teacher> _teacherService;
        private readonly IService<Group> _groupService;

        private readonly IModelConverter<LessonModel, Lesson> _converter;

        public AddLessonWindow()
        {
            _teacherService = AppConfiguration.TeacherService;
            _groupService = AppConfiguration.GroupService;

            _converter = AppConfiguration.AddLessonConverter;

            InitializeComponent();
        }

        public List<Teacher> Teachers { get; set; }

        public List<Group> Groups { get; set; }

        public Lesson Value { get; set; }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await LoadGroupsData();
            await LoadTeachersData();

            UpdateTeachersComboBoxView();
            UpdateGroupsComboBoxView();
            UpdateDaysComboBoxView();
        }

        private void SetValue()
        {
            LessonModel model = new LessonModel
            {
                Teacher = (TeachersCB.SelectedItem as TeacherComboBoxItem).Instance,
                Group = (GroupsCB.SelectedItem as GroupComboBoxItem).Instance,
                StartTB = StartTB.Text.Trim(),
                EndTB = EndTB.Text.Trim(),
                Day = (DaysCB.SelectedItem as DayComboBoxItem).Instance,
                PlaceTB = PlaceTB.Text.Trim(),
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

        private void UpdateTeachersComboBoxView()
        {
            TeachersCB.ItemsSource = Teachers.Select(t => new TeacherComboBoxItem(t));
            TeachersCB.Items.Refresh();
            TeachersCB.SelectedIndex = 0;
        }

        private void UpdateGroupsComboBoxView()
        {
            GroupsCB.ItemsSource = Groups.Select(g => new GroupComboBoxItem(g));
            GroupsCB.Items.Refresh();
            GroupsCB.SelectedIndex = 0;
        }

        private void UpdateDaysComboBoxView()
        {
            DaysCB.ItemsSource = new List<DayComboBoxItem>
            {
                new DayComboBoxItem(Day.Monday, "Понедельник"),
                new DayComboBoxItem(Day.Tuesday, "Вторник"),
                new DayComboBoxItem(Day.Wednesday, "Среда"),
                new DayComboBoxItem(Day.Thursday, "Четверг"),
                new DayComboBoxItem(Day.Friday, "Пятница"),
                new DayComboBoxItem(Day.Saturday, "Суббота"),
                new DayComboBoxItem(Day.Sunday, "Воскресенье"),
            };
            DaysCB.Items.Refresh();
            DaysCB.SelectedIndex = 0;
        }

        private void PlaceTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetValue();
        }

        private void StartTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetValue();
        }

        private void EndTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetValue();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddB_Click(object sender, RoutedEventArgs e) => SetValue();
    }
}
