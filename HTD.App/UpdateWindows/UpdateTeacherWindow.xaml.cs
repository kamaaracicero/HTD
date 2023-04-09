using HTD.App.Configuration;
using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using HTD.DataEntities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace HTD.App.UpdateWindows
{
    public partial class UpdateTeacherWindow : Window
    {
        private readonly IModelConverter<TeacherModel, Teacher> _converter;

        public UpdateTeacherWindow(Teacher teacher)
        {
            _converter = AppConfiguration.AddTeacherConverter;

            Original = teacher;

            InitializeComponent();
            InitializeModel();
        }

        private Teacher Original { get; }

        public Teacher Value { get; private set; }

        private void SetValue()
        {
            TeacherModel model = new TeacherModel
            {
                NameTB = NameTB.Text,
                PhoneTB = PhoneTB.Text,
                StartWorkDateDP = StartWorkDateDP.Text,
            };

            var res = _converter.ConvertModel(model);
            if (!res.IsError)
            {
                Value = res.Value;
                Value.Id = Original.Id;

                DialogResult = true;
                Close();
            }
            else
            {
                var message = ErrorsListGenerator.GenerateMessage("Ошибка в обработке данных:", res.Errors);
                MessageBox.Show(message, "Ошибка");
            }
        }

        private void InitializeModel()
        {
            NameTB.Text = Original.Name;
            PhoneTB.Text = Original.Phone;
            StartWorkDateDP.Text = Original.DateStartWork.ToShortDateString();
        }

        private void StartWorkDateDP_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                DatePickerTextBox datePickerTextBox = FindVisualChild<DatePickerTextBox>(datePicker);
                if (datePickerTextBox != null)
                {

                    ContentControl watermark = datePickerTextBox
                        .Template.FindName("PART_Watermark", datePickerTextBox) as ContentControl;
                    if (watermark != null)
                    {
                        watermark.Content = "Введите дату...";
                    }
                }
            }
        }

        private T FindVisualChild<T>(DependencyObject depencencyObject)
            where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void NameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { SetValue(); }
        }

        private void PhoneTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { SetValue(); }
        }

        private void StartWorkDateDP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { SetValue(); }
        }

        private void AddB_Click(object sender, RoutedEventArgs e) => SetValue();
    }
}
