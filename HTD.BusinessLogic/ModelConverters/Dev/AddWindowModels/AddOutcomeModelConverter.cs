using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddOutcomeModelConverter : ModelConverter, IModelConverter<AddOutcomeModel, Outcome>
    {
        public ModelConvertResult<Outcome> ConvertModel(AddOutcomeModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Outcome);

            ModelConvertResult<Outcome> result = new ModelConvertResult<Outcome>();

            ConvertGroupId(model, result);
            ConvertPupilId(model, result);
            ConvertOrderNumber(model, result);
            ConvertDate(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Outcome);

            return result;
        }

        private void ConvertGroupId(AddOutcomeModel model, ModelConvertResult<Outcome> result)
        {
            var convertRes = GetIntFromString(model.GroupIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert group id to int");

                DevLogger.AddLog("GroupId can't be converted", 5, LogClass.Error, LogItem.Outcome);
            }
            else
            {
                result.Value.GroupId = convertRes.res;

                DevLogger.AddLog("GroupId converted", 5, LogClass.Success, LogItem.Outcome);
            }
        }

        private void ConvertPupilId(AddOutcomeModel model, ModelConvertResult<Outcome> result)
        {
            var convertRes = GetIntFromString(model.PupilIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert pupil id to int");

                DevLogger.AddLog("PupilId can't be converted", 5, LogClass.Error, LogItem.Outcome);
            }
            else
            {
                result.Value.PupilId = convertRes.res;

                DevLogger.AddLog("PupilId converted", 5, LogClass.Success, LogItem.Outcome);
            }
        }

        private void ConvertOrderNumber(AddOutcomeModel model, ModelConvertResult<Outcome> result)
        {
            result.Value.OrderNumber = model.OrderNumberTB;
            DevLogger.AddLog("Order number converted", 5, LogClass.Success, LogItem.Outcome);
        }

        private void ConvertDate(AddOutcomeModel model, ModelConvertResult<Outcome> result)
        {
            var convertRes = GetDateFromString(model.DateDP);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert date to date time");

                DevLogger.AddLog("Date can't be converted", 5, LogClass.Error, LogItem.Outcome);
            }
            else
            {
                result.Value.Date = convertRes.res;

                DevLogger.AddLog("Date converted", 5, LogClass.Success, LogItem.Outcome);
            }
        }
    }
}
