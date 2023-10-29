using HTD.App.Configuration;
using HTD.App.Elements.UpdateCourseTypeWindow;
using HTD.BusinessLogic.Services;
using HTD.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HTD.App.UpdateWindows
{
    public partial class UpdateCourseTypeWindow : Window
    {
        IService<CourseType> _courseTypeService;

        public UpdateCourseTypeWindow(Course original)
        {
            _courseTypeService = AppConfiguration.CourseTypeService;

            Original = original;

            InitializeComponent();
        }

        public Course Original { get; }

        public List<CourseType> CourseTypes { get; set; }

        private async Task LoadCourseTypesData()
        {
            var res = await _courseTypeService.Select();
            if (!res.Successfully)
            {
                MessageBox.Show("Ошибка в загрузке данных групп", "Ошибка");
                return;
            }
            else
            {
                CourseTypes = res.Value.ToList();
            }
        }

        private async void Window_Initialized(object sender, EventArgs e)
        {
            await LoadCourseTypesData();

            UpdateCourseTypesComboBoxView();
        }

        private void UpdateCourseTypesComboBoxView()
        {
            List<CourseTypeComboBoxItem> items = new List<CourseTypeComboBoxItem>();
            items.AddRange(CourseTypes.Select(c => new CourseTypeComboBoxItem(c)));

            CourseTypesCB.ItemsSource = items;
            CourseTypesCB.Items.Refresh();
            CourseTypesCB.SelectedIndex = CourseTypes
                .FindIndex(c => c.Id == Original.TypeId);
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void UpdateB_Click(object sender, RoutedEventArgs e)
        {
            CourseType type = (CourseTypesCB.SelectedItem as CourseTypeComboBoxItem).Instance;

            Original.TypeId = type.Id;
            DialogResult = true;
            Close();
        }
    }
}
