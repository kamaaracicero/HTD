using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddIncomeModelConverter : ModelConverter, IModelConverter<AddIncomeModel, Income>
    {
        public ModelConvertResult<Income> ConvertModel(AddIncomeModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Income);

            ModelConvertResult<Income> result = new ModelConvertResult<Income>();

            ConvertGroupId(model, result);
            ConvertPupilId(model, result);
            ConvertOrderNumber(model, result);
            ConvertDate(model, result);
            ConvertPayment(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Income);

            return result;
        }

        private void ConvertGroupId(AddIncomeModel model, ModelConvertResult<Income> result)
        {
            var convertRes = GetIntFromString(model.GroupIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert group id to int");

                DevLogger.AddLog("GroupId can't be converted", 5, LogClass.Error, LogItem.Income);
            }
            else
            {
                result.Value.GroupId = convertRes.res;

                DevLogger.AddLog("GroupId converted", 5, LogClass.Success, LogItem.Income);
            }
        }

        private void ConvertPupilId(AddIncomeModel model, ModelConvertResult<Income> result)
        {
            var convertRes = GetIntFromString(model.PupilIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert pupil id to int");

                DevLogger.AddLog("PupilId can't be converted", 5, LogClass.Error, LogItem.Income);
            }
            else
            {
                result.Value.PupilId = convertRes.res;

                DevLogger.AddLog("PupilId converted", 5, LogClass.Success, LogItem.Income);
            }
        }

        private void ConvertOrderNumber(AddIncomeModel model, ModelConvertResult<Income> result)
        {
            result.Value.OrderNumber = model.OrderNumberTB;
            DevLogger.AddLog("Order number converted", 5, LogClass.Success, LogItem.Income);
        }

        private void ConvertDate(AddIncomeModel model, ModelConvertResult<Income> result)
        {
            var convertRes = GetDateFromString(model.DateDP);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert date to date");

                DevLogger.AddLog("Date can't be converted", 5, LogClass.Error, LogItem.Income);
            }
            else
            {
                result.Value.Date = convertRes.res;

                DevLogger.AddLog("Date converted", 5, LogClass.Success, LogItem.Income);
            }
        }

        private void ConvertPayment(AddIncomeModel model, ModelConvertResult<Income> result)
        {
            result.Value.Payment = model.PaymentCB;
            DevLogger.AddLog("Payment converted", 5, LogClass.Success, LogItem.Income);
        }
    }
}
