using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddOutcome : Window
    {
        private readonly IModelConverter<AddOutcomeModel, Outcome> _converter;

        public AddOutcome(IModelConverter<AddOutcomeModel, Outcome> converter)
        {
            _converter = converter;

            Model = new AddOutcomeModel();
            Value = null;

            InitializeComponent();
        }

        public AddOutcomeModel Model { get; private set; }

        public Outcome Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.Outcome);

            Model.PupilIdTB = this.PupilIdTB.Text;
            Model.GroupIdTB = this.GroupIdTB.Text;
            Model.OrderNumberTB = this.OrderNumberTB.Text;
            Model.DateDP = this.DateDP.Text;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.Outcome);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.Outcome);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
