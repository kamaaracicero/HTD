using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddType : Window
    {
        private readonly IModelConverter<AddTypeModel, CourseType> _converter;

        public AddType(IModelConverter<AddTypeModel, CourseType> converter)
        {
            _converter = converter;

            Model = new AddTypeModel();
            Value = null;

            InitializeComponent();
        }

        public AddTypeModel Model { get; private set; }

        public CourseType Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.Type);

            Model.NameTB = this.NameTB.Text;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.Type);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.Type);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
