using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddPupil : Window
    {
        private readonly IModelConverter<AddPupilModel, Pupil> _converter;

        public AddPupil(IModelConverter<AddPupilModel, Pupil> converter)
        {
            _converter = converter;

            Model = new AddPupilModel();
            Value = null;

            InitializeComponent();
        }

        public AddPupilModel Model { get; private set; }

        public Pupil Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            Model.NameTB = this.NameTB.Text;
            Model.BirthDayDP = this.BirthDayDP.Text;
            Model.ParentNameTB = this.ParentNameTB.Text;
            Model.ContactPhoneTB = this.ContactPhoneTB.Text;

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
