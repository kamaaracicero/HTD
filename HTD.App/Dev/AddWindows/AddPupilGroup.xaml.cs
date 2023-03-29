using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddPupilGroup : Window
    {
        private readonly IModelConverter<AddPupilGroupModel, PupilGroup> _converter;

        public AddPupilGroup(IModelConverter<AddPupilGroupModel, PupilGroup> converter)
        {
            _converter = converter;

            Model = new AddPupilGroupModel();
            Value = null;

            InitializeComponent();
        }

        public AddPupilGroupModel Model { get; private set; }

        public PupilGroup Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.PupilGroup);

            Model.PupilIdTB = this.PupilIdTB.Text;
            Model.GroupIdTB = this.GroupIdTB.Text;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.PupilGroup);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.PupilGroup);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
