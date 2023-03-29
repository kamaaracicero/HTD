using HTD.BusinessLogic.ErrorMessageGenerators;
using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.ModelConverters;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System.Windows;

namespace HTD.App.Dev.AddWindows
{
    public partial class AddTeacherCourse : Window
    {
        private readonly IModelConverter<AddTeacherCourseModel, TeacherCourse> _converter;

        public AddTeacherCourse(IModelConverter<AddTeacherCourseModel, TeacherCourse> converter)
        {
            _converter = converter;

            Model = new AddTeacherCourseModel();
            Value = null;

            InitializeComponent();
        }

        public AddTeacherCourseModel Model { get; private set; }

        public TeacherCourse Value { get; private set; }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            DevLogger.AddLog("AddB Click", 2, LogClass.Event, LogItem.TeacherCourse);

            Model.TeacherIdTB = this.TeacherIdTB.Text;
            Model.CourseIdTB = this.CourseIdTB.Text;

            var res = _converter.ConvertModel(Model);
            if (res.IsError)
            {
                DevLogger.AddLog("Convert error", 3, LogClass.Error, LogItem.TeacherCourse);

                MessageBox.Show(MessageBoxListErrors.GenerateMessage("Error in convert", res.Errors));
                return;
            }
            else
            {
                DevLogger.AddLog("Item converted", 3, LogClass.Success, LogItem.TeacherCourse);

                Value = res.Value;
                DialogResult = true;
                Close();
            }
        }
    }
}
