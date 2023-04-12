using HTD.BusinessLogic.Models;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters
{
    internal class LessonModelConverter : ModelConverter, IModelConverter<LessonModel, Lesson>
    {
        public ModelConvertResult<Lesson> ConvertModel(LessonModel model)
        {
            ModelConvertResult<Lesson> result = new ModelConvertResult<Lesson>();

            ConvertStartTime(model, result);
            ConvertEndTime(model, result);
            CheckTime(result);
            ConvertPlace(model, result);
            InitDependencies(model, result);

            return result;
        }

        private void ConvertStartTime(LessonModel model, ModelConvertResult<Lesson> result)
        {
            if (string.IsNullOrEmpty(model.StartTB))
            {
                result.IsError = true;
                result.Errors.Add("Время начала не должно быть пустым");
                return;
            }
            var convertResult = GetTimeFromString(model.StartTB);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить время начала из введённого значения");
                return;
            }

            result.Value.Begin = convertResult.res;
        }

        private void ConvertEndTime(LessonModel model, ModelConvertResult<Lesson> result)
        {
            if (string.IsNullOrEmpty(model.EndTB))
            {
                result.IsError = true;
                result.Errors.Add("Время окончания не должно быть пустым");
                return;
            }
            var convertResult = GetTimeFromString(model.EndTB);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить время окончания из введённого значения");
                return;
            }

            result.Value.End = convertResult.res;
        }

        private void ConvertPlace(LessonModel model, ModelConvertResult<Lesson> result)
        {
            if (string.IsNullOrEmpty(model.PlaceTB))
            {
                result.IsError = true;
                result.Errors.Add("Номер кабинета не должен быть пустым");
                return;
            }
            var convertResult = GetIntFromString(model.PlaceTB);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить номер кабинета из введённого значения");
                return;
            }

            result.Value.Place = convertResult.res;
        }

        private void CheckTime(ModelConvertResult<Lesson> res)
        {
            if (res.Value.Begin > res.Value.End)
            {
                res.IsError = true;
                res.Errors.Add("Время начала должно быть раньше окончания");
            }
        }

        private void InitDependencies(LessonModel model, ModelConvertResult<Lesson> result)
        {
            if (result.IsError) { return; }

            result.Value.TeacherId = model.Teacher.Id;
            result.Value.GroupId = model.Group.Id;
            result.Value.Day = (int)model.Day;
        }
    }
}
