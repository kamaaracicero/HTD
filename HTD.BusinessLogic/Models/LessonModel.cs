using HTD.DataEntities;

namespace HTD.BusinessLogic.Models
{
    internal class LessonModel : IModel
    {
        public Group Group { get; set; }

        public Teacher Teacher { get; set; }

        public string StartTB { get; set; }

        public string EndTB { get; set; }

        public string PlaceTB { get; set; }

        public Day Day { get; set; }
    }
}
