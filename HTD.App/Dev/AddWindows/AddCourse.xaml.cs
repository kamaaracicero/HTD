using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddCourse : Window
    {
        private readonly IModelConverter<AddCourseModel, Course> _converter;

        public AddCourse(IModelConverter<AddCourseModel, Course> converter)
        {
            _converter = converter;

            Model = new AddCourseModel();
            Value = null;

            InitializeComponent();
        }

        public AddCourseModel Model { get; private set; }

        public Course Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            Model.NameTB = this.NameTB.Text;
            Model.TypeIdTB = this.TypeIdTB.Text;
            Model.IsActiveCB = this.IsActiveCB.IsChecked.Value;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
