using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddTeacher : Window
    {
        private readonly IModelConverter<AddTeacherModel, Teacher> _converter;

        public AddTeacher(IModelConverter<AddTeacherModel, Teacher> converter)
        {
            _converter = converter;

            Model = new AddTeacherModel();
            Value = null;

            InitializeComponent();
        }

        public AddTeacherModel Model { get; private set; }

        public Teacher Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.Teacher);

            Model.NameTB = this.NameTB.Text;
            Model.PhoneTB = this.PhoneTB.Text;
            Model.DateStartWorkDP = this.DateStartWorkDP.Text;
            Model.DateEndWorkDP = this.DateEndWorkDP.Text;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.Teacher);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.Teacher);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
