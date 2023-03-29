using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;
using System;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddPupilGroupModelConverter : ModelConverter, IModelConverter<AddPupilGroupModel, PupilGroup>
    {
        public ModelConvertResult<PupilGroup> ConvertModel(AddPupilGroupModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.PupilGroup);

            ModelConvertResult<PupilGroup> result = new ModelConvertResult<PupilGroup>();

            ConvertGroupId(model, result);
            ConvertPupilId(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.PupilGroup);

            return result;
        }

        private void ConvertGroupId(AddPupilGroupModel model, ModelConvertResult<PupilGroup> result)
        {
            var convertRes = GetIntFromString(model.GroupIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert group id to int");

                DevLogger.AddLog("GroupId can't be converted", 5, LogClass.Error, LogItem.PupilGroup);
            }
            else
            {
                result.Value.GroupId = convertRes.res;

                DevLogger.AddLog("GroupId converted", 5, LogClass.Success, LogItem.PupilGroup);
            }
        }

        private void ConvertPupilId(AddPupilGroupModel model, ModelConvertResult<PupilGroup> result)
        {
            var convertRes = GetIntFromString(model.PupilIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert pupil id to int");

                DevLogger.AddLog("PupilId can't be converted", 5, LogClass.Error, LogItem.PupilGroup);
            }
            else
            {
                result.Value.PupilId = convertRes.res;

                DevLogger.AddLog("PupilId converted", 5, LogClass.Success, LogItem.PupilGroup);
            }
        }
    }
}
