using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddPupilModelConverter : ModelConverter, IModelConverter<AddPupilModel, Pupil>
    {
        public ModelConvertResult<Pupil> ConvertModel(AddPupilModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Pupil);

            ModelConvertResult<Pupil> result = new ModelConvertResult<Pupil>();

            ConvertName(model, result);
            ConvertBirthDay(model, result);
            ConvertParentName(model, result);
            ConvertContactPhone(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Pupil);

            return result;
        }

        private void ConvertName(AddPupilModel model, ModelConvertResult<Pupil> result)
        {
            result.Value.Name = model.NameTB;
            DevLogger.AddLog("Name converted", 5, LogClass.Success, LogItem.Pupil);
        }

        private void ConvertBirthDay(AddPupilModel model, ModelConvertResult<Pupil> result)
        {
            var convertRes = GetDateFromString(model.BirthDayDP);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert birth day to date");

                DevLogger.AddLog("BirthDay can't be converted", 5, LogClass.Error, LogItem.Pupil);
            }
            else
            {
                result.Value.BirthDay = convertRes.res;

                DevLogger.AddLog("BirthDay converted", 5, LogClass.Success, LogItem.Pupil);
            }
        }

        private void ConvertParentName(AddPupilModel model, ModelConvertResult<Pupil> result)
        {
            result.Value.ParentName = model.ParentNameTB;
            DevLogger.AddLog("ParentName converted", 5, LogClass.Success, LogItem.Pupil);
        }

        private void ConvertContactPhone(AddPupilModel model, ModelConvertResult<Pupil> result)
        {
            result.Value.ContactPhone = model.ContactPhoneTB;
            DevLogger.AddLog("ContactPhone converted", 5, LogClass.Success, LogItem.Pupil);
        }
    }
}
