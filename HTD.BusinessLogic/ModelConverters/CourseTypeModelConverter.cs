using HTD.BusinessLogic.Models;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters
{
    internal class CourseTypeModelConverter : ModelConverter, IModelConverter<CourseTypeModel, CourseType>
    {
        public ModelConvertResult<CourseType> ConvertModel(CourseTypeModel model)
        {
            ModelConvertResult<CourseType> result = new ModelConvertResult<CourseType>();

            ConvertName(model, result);

            return result;
        }

        private void ConvertName(CourseTypeModel model, ModelConvertResult<CourseType> result)
        {
            if (string.IsNullOrEmpty(model.NameTB))
            {
                result.IsError = true;
                result.Errors.Add("Название не должно быть пустым");
                return;
            }
            result.Value.Name = model.NameTB;
        }
    }
}
