using HTD.BusinessLogic.Models;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters
{
    internal class GroupModelConverter : ModelConverter, IModelConverter<GroupModel, Group>
    {
        public ModelConvertResult<Group> ConvertModel(GroupModel model)
        {
            ModelConvertResult<Group> result = new ModelConvertResult<Group>();

            ConvertName(model, result);
            ConvertYear(model, result);
            ConvertPayment(model, result);
            InitDependencies(model, result);
            InitStandardValues(result);

            return result;
        }

        private void ConvertName(GroupModel model, ModelConvertResult<Group> result)
        {
            if (string.IsNullOrEmpty(model.NameTB))
            {
                result.IsError = true;
                result.Errors.Add("Название не должно быть пустым");
                return;
            }
            result.Value.Name = model.NameTB;
        }

        private void ConvertYear(GroupModel model, ModelConvertResult<Group> result)
        {
            if (string.IsNullOrEmpty(model.YearTB))
            {
                result.IsError = true;
                result.Errors.Add("Год группы не должен быть пустым");
                return;
            }
            var convertResult = GetIntFromString(model.YearTB);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить год из введённого значения");
                return;
            }

            result.Value.Year = convertResult.res;
        }

        private void ConvertPayment(GroupModel model, ModelConvertResult<Group> result)
        {
            result.Value.Payment = model.PaymentCB;
        }

        private void InitDependencies(GroupModel model, ModelConvertResult<Group> result)
        {
            if (result.IsError) { return; }

            result.Value.CourseId = model.Course.Id;
        }

        private void InitStandardValues(ModelConvertResult<Group> result)
        {
            if (result.IsError) { return; }

            result.Value.IsActive = true;
        }
    }
}
