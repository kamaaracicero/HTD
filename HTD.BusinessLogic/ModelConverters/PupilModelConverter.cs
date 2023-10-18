using HTD.BusinessLogic.Models;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters
{
    internal class PupilModelConverter : ModelConverter, IModelConverter<PupilModel, Pupil>
    {
        public ModelConvertResult<Pupil> ConvertModel(PupilModel model)
        {
            ModelConvertResult<Pupil> result = new ModelConvertResult<Pupil>();

            ConvertName(model, result);
            ConvertParentName(model, result);
            ConvertContactPhone(model, result);
            ConvertBirthDay(model, result);
            ConvertClass(model, result);
            ConvertGUO(model, result);
            InitStandardValues(result);

            return result;
        }

        private void ConvertName(PupilModel model, ModelConvertResult<Pupil> result)
        {
            if (string.IsNullOrEmpty(model.NameTB))
            {
                result.IsError = true;
                result.Errors.Add("Ф.И.О. не должно быть пустым");
                return;
            }

            result.Value.Name = model.NameTB;
        }

        private void ConvertParentName(PupilModel model, ModelConvertResult<Pupil> result)
        {
            if (string.IsNullOrEmpty(model.ParentNameTB))
            {
                result.IsError = true;
                result.Errors.Add("Ф.И.О. представителя не должно быть пустым");
                return;
            }

            result.Value.ParentName = model.ParentNameTB;
        }

        private void ConvertContactPhone(PupilModel model, ModelConvertResult<Pupil> result)
        {
            if (string.IsNullOrEmpty(model.ContactPhoneTB))
            {
                result.IsError = true;
                result.Errors.Add("Номер телефона не должен быть пустым");
                return;
            }
            if (!CheckPhoneString(model.ContactPhoneTB))
            {
                result.IsError = true;
                result.Errors.Add("Номер телефона должен представлять формат из 12 цифр:\n    +375 (__) ___ __ __");
                return;
            }

            result.Value.ContactPhone = model.ContactPhoneTB;
        }

        private void ConvertBirthDay(PupilModel model, ModelConvertResult<Pupil> result)
        {
            if (string.IsNullOrEmpty(model.BirthDayDP))
            {
                result.IsError = true;
                result.Errors.Add("День рождения не должен быть пустым");
                return;
            }
            var convertResult = GetDateFromString(model.BirthDayDP);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить дату из введённого значения");
                return;
            }

            result.Value.BirthDay = convertResult.res;
        }

        private void ConvertClass(PupilModel model, ModelConvertResult<Pupil> result)
        {
            if (string.IsNullOrEmpty(model.ClassTB))
            {
                result.IsError = true;
                result.Errors.Add("Класс не должен быть пустым");
                return;
            }
            var convertResult = GetIntFromString(model.ClassTB);
            if (!convertResult.success)
            {
                result.IsError = true;
                result.Errors.Add("Невозможно получить номер класса из введённого значения");
                return;
            }

            result.Value.Class = convertResult.res;
        }

        private void ConvertGUO(PupilModel model, ModelConvertResult<Pupil> result)
        {
            if (string.IsNullOrEmpty(model.GUOTB))
            {
                result.IsError = true;
                result.Errors.Add("ГУО не должно быть пустым");
                return;
            }

            result.Value.GUO = model.GUOTB;
        }

        private void InitStandardValues(ModelConvertResult<Pupil> result)
        {
            if (result.IsError) { return; }

            result.Value.IsExpelled = false;
        }
    }
}
