using HTD.BusinessLogic.Loggers;
using HTD.BusinessLogic.Loggers.Dev;
using HTD.BusinessLogic.Models.Dev.AddWindowModels;
using HTD.DataEntities;

namespace HTD.BusinessLogic.ModelConverters.Dev.AddWindowModels
{
    internal class AddLessonModelConverter : ModelConverter, IModelConverter<AddLessonModel, Lesson>
    {
        public ModelConvertResult<Lesson> ConvertModel(AddLessonModel model)
        {
            DevLogger.AddLog("Convert start", 4, LogClass.Event, LogItem.Lesson);

            ModelConvertResult<Lesson> result = new ModelConvertResult<Lesson>();

            ConvertGroupId(model, result);
            ConvertTeacherId(model, result);
            ConvertBegin(model, result);
            ConvertEnd(model, result);
            ConvertPlace(model, result);
            ConvertDate(model, result);

            DevLogger.AddLog("Convert end", 4, LogClass.Event, LogItem.Lesson);

            return result;
        }

        private void ConvertGroupId(AddLessonModel model, ModelConvertResult<Lesson> result)
        {
            var convertRes = GetIntFromString(model.GroupIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert group id to int");

                DevLogger.AddLog("GroupId can't be converted", 5, LogClass.Error, LogItem.Lesson);
            }
            else
            {
                result.Value.GroupId = convertRes.res;

                DevLogger.AddLog("GroupId converted", 5, LogClass.Success, LogItem.Lesson);
            }
        }

        private void ConvertTeacherId(AddLessonModel model, ModelConvertResult<Lesson> result)
        {
            var convertRes = GetIntFromString(model.TeacherIdTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert teacher id to int");

                DevLogger.AddLog("TeacherId can't be converted", 5, LogClass.Error, LogItem.Lesson);
            }
            else
            {
                result.Value.TeacherId = convertRes.res;

                DevLogger.AddLog("TeacherId converted", 5, LogClass.Success, LogItem.Lesson);
            }
        }

        private void ConvertBegin(AddLessonModel model, ModelConvertResult<Lesson> result)
        {
            var convertRes = GetTimeFromString(model.BeginTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert begin to time");

                DevLogger.AddLog("Begin can't be converted", 5, LogClass.Error, LogItem.Lesson);
            }
            else
            {
                result.Value.Begin = convertRes.res;

                DevLogger.AddLog("Begin converted", 5, LogClass.Success, LogItem.Lesson);
            }
        }

        private void ConvertEnd(AddLessonModel model, ModelConvertResult<Lesson> result)
        {
            var convertRes = GetTimeFromString(model.EndTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert end to time");

                DevLogger.AddLog("End can't be converted", 5, LogClass.Error, LogItem.Lesson);
            }
            else
            {
                result.Value.End = convertRes.res;

                DevLogger.AddLog("End converted", 5, LogClass.Success, LogItem.Lesson);
            }
        }

        private void ConvertPlace(AddLessonModel model, ModelConvertResult<Lesson> result)
        {
            var convertRes = GetIntFromString(model.PlaceTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert place to int");

                DevLogger.AddLog("Place can't be converted", 5, LogClass.Error, LogItem.Lesson);
            }
            else
            {
                result.Value.Place = convertRes.res;

                DevLogger.AddLog("Place converted", 5, LogClass.Success, LogItem.Lesson);
            }
        }

        private void ConvertDate(AddLessonModel model, ModelConvertResult<Lesson> result)
        {
            var convertRes = GetIntFromString(model.DayTB);
            if (!convertRes.success)
            {
                result.IsError = true;
                result.Errors.Add("Can't convert date to date");

                DevLogger.AddLog("Date can't be converted", 5, LogClass.Error, LogItem.Lesson);
            }
            else
            {
                result.Value.Day = convertRes.res;

                DevLogger.AddLog("Date converted", 5, LogClass.Success, LogItem.Lesson);
            }
        }
    }
}
