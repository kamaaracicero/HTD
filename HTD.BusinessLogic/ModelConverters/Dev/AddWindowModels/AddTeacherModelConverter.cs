using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddTeacherModelConverter : ModelConverter, IModelConverter<AddTeacherModel, Teacher>
    {
        public ModelConvertResult<Teacher> ConvertModel(AddTeacherModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Teacher);

            ModelConvertResult<Teacher> result = new ModelConvertResult<Teacher>();

            ConvertName(model, result);
            ConvertPhone(model, result);
            ConvertDateStartWork(model, result);
            ConvertDateEndWork(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Teacher);

            return result;
        }

        private void ConvertName(AddTeacherModel model, ModelConvertResult<Teacher> result)
        {
            result.Value.Name = model.NameTB;
            DevLogger.AddLog("Name converted", 5, LogClass.Success, LogItem.Teacher);
        }

        private void ConvertPhone(AddTeacherModel model, ModelConvertResult<Teacher> result)
        {
            result.Value.Phone = model.PhoneTB;
            DevLogger.AddLog("Phone converted", 5, LogClass.Success, LogItem.Teacher);
        }

        private void ConvertDateStartWork(AddTeacherModel model, ModelConvertResult<Teacher> result)
        {
            var convertRes = GetDateFromString(model.DateStartWorkDP);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert date start work to date");

                DevLogger.AddLog("DateStartWork can't be converted", 5, LogClass.Error, LogItem.Teacher);
            }
            else
            {
                result.Value.DateStartWork = convertRes.res;

                DevLogger.AddLog("DateStartWork converted", 5, LogClass.Success, LogItem.Teacher);
            }
        }

        private void ConvertDateEndWork(AddTeacherModel model, ModelConvertResult<Teacher> result)
        {
            if (model.DateEndWorkDP == null)
            {
                result.Value.DateEndWork = null;
                DevLogger.AddLog("DateEndWork skipped", 5, LogClass.Success, LogItem.Teacher);
                return;
            }

            var convertRes = GetDateFromString(model.DateEndWorkDP);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert date end work to date");

                DevLogger.AddLog("DateEndWork can't be converted", 5, LogClass.Error, LogItem.Teacher);
            }
            else
            {
                result.Value.DateEndWork = convertRes.res;

                DevLogger.AddLog("DateStartWork converted", 5, LogClass.Success, LogItem.Teacher);
            }
        }
    }
}
