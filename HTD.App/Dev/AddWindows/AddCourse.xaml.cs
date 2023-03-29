using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
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
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.Course);

            Model.NameTB = this.NameTB.Text;
            Model.TypeIdTB = this.TypeIdTB.Text;
            Model.IsActiveCB = this.IsActiveCB.IsChecked.Value;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.Course);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.Course);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
