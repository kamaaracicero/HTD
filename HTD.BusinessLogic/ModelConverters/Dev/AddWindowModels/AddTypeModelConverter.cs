using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddTypeModelConverter : ModelConverter, IModelConverter<AddTypeModel, Type>
    {
        public ModelConvertResult<Type> ConvertModel(AddTypeModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Type);

            ModelConvertResult<Type> result = new ModelConvertResult<Type>();

            ConvertName(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Type);

            return result;
        }

        private void ConvertName(AddTypeModel model, ModelConvertResult<Type> result)
        {
            result.Value.Name = model.NameTB;
            DevLogger.AddLog("Name converted", 5, LogClass.Success, LogItem.Type);
        }
    }
}
