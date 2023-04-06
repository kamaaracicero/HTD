using HTD.BusinessLogic.Models.AddWindows;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.AddWindows
{
    internal class CourseTypeConverter : ModelConverter, IModelConverter<CourseTypeModel, CourseType>
    {
        public ModelConvertResult<CourseType> ConvertModel(CourseTypeModel model)
        {
            ModelConvertResult<CourseType> result = new ModelConvertResult<CourseType>();

            ConvertName(model, result);

            return result;
        }

        private void ConvertName(CourseTypeModel model, ModelConvertResult<CourseType> result)
        {
            result.Value.Name = model.NameTB;
        }
    }
}
