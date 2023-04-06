using HTD.DataEntities;

namespace HTD.BusinessLogic.Models.AddWindows
{
    internal class LessonModel : IModel
    {
        public Group GroupCB { get; set; }

        public Teacher TeacherCB { get; set; }

        public string StartTB { get; set; }

        public string EndTB { get; set; }

        public string PlaceTB { get; set; }

        public Day DayCB { get; set; }
    }
}
