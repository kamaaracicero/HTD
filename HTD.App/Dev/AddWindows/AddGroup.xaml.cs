using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddGroup : Window
    {
        private readonly IModelConverter<AddGroupModel, Group> _converter;

        public AddGroup(IModelConverter<AddGroupModel, Group> converter)
        {
            _converter = converter;

            Model = new AddGroupModel();
            Value = null;

            InitializeComponent();
        }

        public AddGroupModel Model { get; private set; }

        public Group Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            Model.CourseIdTB = this.CourseIdTB.Text;
            Model.NameTB = this.NameTB.Text;
            Model.YearTB = this.YearTB.Text;
            Model.IsActiveCB = this.IsActiveCB.IsChecked.Value;
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
