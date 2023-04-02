using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddGroupModelConverter : ModelConverter, IModelConverter<AddGroupModel, Group>
    {
        public ModelConvertResult<Group> ConvertModel(AddGroupModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Group);

            ModelConvertResult<Group> result = new ModelConvertResult<Group>();

            ConvertCourseId(model, result);
            ConvertName(model, result);
            ConvertYear(model, result);
            ConvertIsActive(model, result);
            ConvertPayment(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Group);

            return result;
        }

        private void ConvertCourseId(AddGroupModel model, ModelConvertResult<Group> result)
        {
            var convertRes = GetIntFromString(model.CourseIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert course id to int");

                DevLogger.AddLog("CourseId can't be converted", 5, LogClass.Error, LogItem.Group);
            }
            else
            {
                result.Value.CourseId = convertRes.res;

                DevLogger.AddLog("CourseId converted", 5, LogClass.Success, LogItem.Group);
            }
        }

        private void ConvertName(AddGroupModel model, ModelConvertResult<Group> result)
        {
            result.Value.Name = model.NameTB;
            DevLogger.AddLog("Name converted", 5, LogClass.Success, LogItem.Group);
        }

        private void ConvertYear(AddGroupModel model, ModelConvertResult<Group> result)
        {
            var convertRes = GetIntFromString(model.YearTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert year to int");

                DevLogger.AddLog("Year can't be converted", 5, LogClass.Error, LogItem.Group);
            }
            else
            {
                result.Value.Year = convertRes.res;

                DevLogger.AddLog("Year converted", 5, LogClass.Success, LogItem.Group);
            }
        }

        private void ConvertIsActive(AddGroupModel model, ModelConvertResult<Group> result)
        {
            result.Value.IsActive = model.IsActiveCB;
            DevLogger.AddLog("IsActive converted", 5, LogClass.Success, LogItem.Group);
        }

        private void ConvertPayment(AddGroupModel model, ModelConvertResult<Group> result)
        {
            result.Value.Payment = model.PaymentCB;
            DevLogger.AddLog("IsActive converted", 5, LogClass.Success, LogItem.Group);
        }
    }
}
