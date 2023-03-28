using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddIncome : Window
    {
        private readonly IModelConverter<AddIncomeModel, Income> _converter;

        public AddIncome(IModelConverter<AddIncomeModel, Income> converter)
        {
            _converter = converter;

            Model = new AddIncomeModel();
            Value = null;

            InitializeComponent();
        }

        public AddIncomeModel Model { get; private set; }

        public Income Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            Model.PupilIdTB = this.PupilIdTB.Text;
            Model.GroupIdTB = this.GroupIdTB.Text;
            Model.OrderNumberTB = this.OrderNumberTB.Text;
            Model.DateDP = this.DateDP.Text;
            Model.PaymentCB = this.PaymentCB.IsChecked.Value;

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
