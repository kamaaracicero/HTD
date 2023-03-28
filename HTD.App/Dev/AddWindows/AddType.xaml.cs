using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddType : Window
    {
        private readonly IModelConverter<AddTypeModel, Type> _converter;

        public AddType(IModelConverter<AddTypeModel, Type> converter)
        {
            _converter = converter;

            Model = new AddTypeModel();
            Value = null;

            InitializeComponent();
        }

        public AddTypeModel Model { get; private set; }

        public Type Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            Model.NameTB = this.NameTB.Text;

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
