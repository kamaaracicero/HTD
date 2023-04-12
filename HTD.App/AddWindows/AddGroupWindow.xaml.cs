using HTD.App.Configuration;
using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models;
using HTD.DataEntities;
using System.Windows;
using System.Windows.Input;

namespace HTD.App.AddWindows
{
    public partial class AddGroupWindow : Window
    {
        private readonly Course _course;
        private readonly IModelConverter<GroupModel, Group> _converter;

        public AddGroupWindow(Course course)
        {
            _converter = AppConfiguration.AddGroupConverter;
            _course = course;

            InitializeComponent();
        }

        public Group Value { get; private set; }

        private void SetValue()
        {
            GroupModel model = new GroupModel
            {
                NameTB = NameTB.Text.Trim(),
                YearTB = YearTB.Text.Trim(),
                PaymentCB = PaymentCB.IsChecked.Value,
                Course = _course,
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

        private void NameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetValue();
        }

        private void YearTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetValue();
        }

        private void AddB_Click(object sender, RoutedEventArgs e) => SetValue();

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
