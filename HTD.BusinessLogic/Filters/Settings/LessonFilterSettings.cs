using HTD.DataEntities;

namespace HTD.BusinessLogic.Filters.Settings
{
    internal class LessonFilterSettings : IFilterSettings<Lesson>
    {
        public Teacher SelectedTeacherCB { get; set; }

        public Group SelectedGroupCB { get; set; }
    }
}
