using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddCourseModelConverter : ModelConverter, IModelConverter<AddCourseModel, Course>
    {
        public ModelConvertResult<Course> ConvertModel(AddCourseModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Course);

            ModelConvertResult<Course> result = new ModelConvertResult<Course>();

            ConvertName(model, result);
            ConvertTypeId(model,result);
            ConvertIsActive(model,result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Course);

            return result;
        }

        private void ConvertName(AddCourseModel model, ModelConvertResult<Course> result)
        {
            result.Value.Name = model.NameTB;
            DevLogger.AddLog("Name converted", 5, LogClass.Success, LogItem.Course);
        }

        private void ConvertTypeId(AddCourseModel model, ModelConvertResult<Course> result)
        {
            var convertRes = GetIntFromString(model.TypeIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert type id to int");

                DevLogger.AddLog("TypeId can't be converted", 5, LogClass.Error, LogItem.Course);
            }
            else
            {
                result.Value.TypeId = convertRes.res;

                DevLogger.AddLog("TypeId converted", 5, LogClass.Success, LogItem.Course);
            }
        }

        private void ConvertIsActive(AddCourseModel model, ModelConvertResult<Course> result)
        {
            result.Value.IsActive = model.IsActiveCB;
            DevLogger.AddLog("IsActive converted", 5, LogClass.Success, LogItem.Course);
        }
    }
}
