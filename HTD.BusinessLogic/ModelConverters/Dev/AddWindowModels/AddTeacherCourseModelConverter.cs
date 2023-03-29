using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddTeacherCourseModelConverter : ModelConverter, IModelConverter<AddTeacherCourseModel, TeacherCourse>
    {
        public ModelConvertResult<TeacherCourse> ConvertModel(AddTeacherCourseModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.TeacherCourse);

            ModelConvertResult<TeacherCourse> result = new ModelConvertResult<TeacherCourse>();

            ConvertTeacherId(model, result);
            ConvertCourseId(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.TeacherCourse);

            return result;
        }

        private void ConvertTeacherId(AddTeacherCourseModel model, ModelConvertResult<TeacherCourse> result)
        {
            var convertRes = GetIntFromString(model.TeacherIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert teacher id to int");

                DevLogger.AddLog("TeacherId can't be converted", 5, LogClass.Error, LogItem.TeacherCourse);
            }
            else
            {
                result.Value.TeacherId = convertRes.res;

                DevLogger.AddLog("TeacherId converted", 5, LogClass.Success, LogItem.TeacherCourse);
            }
        }

        private void ConvertCourseId(AddTeacherCourseModel model, ModelConvertResult<TeacherCourse> result)
        {
            var convertRes = GetIntFromString(model.CourseIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert course id to int");

                DevLogger.AddLog("CourseId can't be converted", 5, LogClass.Error, LogItem.TeacherCourse);
            }
            else
            {
                result.Value.CourseId = convertRes.res;

                DevLogger.AddLog("CourseId converted", 5, LogClass.Success, LogItem.TeacherCourse);
            }
        }
    }
}
