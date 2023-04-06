using HTD.BusinessLogic.Models.AddWindows;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.AddWindows
{
    internal class TeacherModelConverter : ModelConverter, IModelConverter<TeacherModel, Teacher>
    {
        public ModelConvertResult<Teacher> ConvertModel(TeacherModel model)
        {
            ModelConvertResult<Teacher> result = new ModelConvertResult<Teacher>();

            ConvertName(model, result);
            ConvertPhone(model, result);
            ConvertStartWorkDate(model, result);
            InitStandardValues(result);

            return result;
        }

        private void ConvertName(TeacherModel model, ModelConvertResult<Teacher> result)
        {
            if (string.IsNullOrEmpty(model.NameTB))
            {
                result.IsError = true;
                result.Errors.Add("Ф.И.О. не должно быть пустым");
                return;
            }

            result.Value.Name = model.NameTB;
        }

        private void ConvertPhone(TeacherModel model, ModelConvertResult<Teacher> result)
        {
            if (string.IsNullOrEmpty(model.PhoneTB))
            {
                result.IsError = true;
                result.Errors.Add("Номер телефона не должен быть пустым");
                return;
            }

            result.Value.Phone = model.PhoneTB;
        }

        private void ConvertStartWorkDate(TeacherModel model, ModelConvertResult<Teacher> result)
        {
            if (string.IsNullOrEmpty(model.StartWorkDateDP))
            {
                result.IsError = true;
                result.Errors.Add("Дата начала работы не должна быть пуста");
                return;
            }
            var convertResult = GetDateFromString(model.StartWorkDateDP);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить дату из введённого значения");
                return;
            }

            result.Value.DateStartWork = convertResult.res;
        }

        private void InitStandardValues(ModelConvertResult<Teacher> result)
        {
            if (result.IsError) { return; }

            result.Value.DateEndWork = null;
        }
    }
}
