using HTD.DataEntities;

namespace HTD.BusinessLogic.Models
{
    internal class CourseModel : IModel
    {
        public string NameTB { get; set; }

        public CourseType TypeCB { get; set; }
    }
}
