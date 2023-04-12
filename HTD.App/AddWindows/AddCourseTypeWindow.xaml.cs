using HTD.App.Configuration;
using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using HTD.DataEntities;
using System.Windows;
using System.Windows.Input;

namespace HTD.App.AddWindows
{
    public partial class AddCourseTypeWindow : Window
    {
        private readonly IModelConverter<CourseTypeModel, CourseType> _converter;

        public AddCourseTypeWindow()
        {
            _converter = AppConfiguration.AddCourseTypeConverter;

            InitializeComponent();
        }

        public CourseType Value { get; private set; }

        private void SetValue()
        {
            CourseTypeModel model = new CourseTypeModel
            {
                NameTB = NameTB.Text.Trim(),
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

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddB_Click(object sender, RoutedEventArgs e) => SetValue();

        private void NameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { SetValue(); }
        }
    }
}
