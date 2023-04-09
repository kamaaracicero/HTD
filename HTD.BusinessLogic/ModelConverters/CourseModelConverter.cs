using HTD.BusinessLogic.Models;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters
{
    internal class CourseModelConverter : ModelConverter, IModelConverter<CourseModel, Course>
    {
        public ModelConvertResult<Course> ConvertModel(CourseModel model)
        {
            ModelConvertResult<Course> result = new ModelConvertResult<Course>();

            ConvertName(model, result);
            InitDependencies(model, result);
            InitStandardValues(result);

            return result;
        }

        private void ConvertName(CourseModel model, ModelConvertResult<Course> result)
        {
            if (string.IsNullOrEmpty(model.NameTB))
            {
                result.IsError = true;
                result.Errors.Add("Название не должно быть пустым");
                return;
            }
            result.Value.Name = model.NameTB;
        }

        private void InitDependencies(CourseModel model, ModelConvertResult<Course> result)
        {
            if (result.IsError) { return; }

            result.Value.TypeId = model.TypeCB.Id;
        }

        private void InitStandardValues(ModelConvertResult<Course> result)
        {
            if (result.IsError) { return; }

            result.Value.IsActive = true;
        }
    }
}
