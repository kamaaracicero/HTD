using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddLesson : Window
    {
        private readonly IModelConverter<AddLessonModel, Lesson> _converter;

        public AddLesson(IModelConverter<AddLessonModel, Lesson> converter)
        {
            _converter = converter;

            Model = new AddLessonModel();
            Value = null;

            InitializeComponent();
        }

        public AddLessonModel Model { get; private set; }

        public Lesson Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            Model.GroupIdTB = this.GroupIdTB.Text;
            Model.TeacherIdTB = this.TeacherIdTB.Text;
            Model.BeginTB = this.BeginTB.Text;
            Model.EndTB = this.EndTB.Text;
            Model.PlaceTB = this.PlaceTB.Text;
            Model.DateDP = this.DateDP.Text;

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
