using HTD.DataEntities;

namespace HTD.BusinessLogic.Models
{
    internal class GroupModel : IModel
    {
        public string NameTB { get; set; }

        public Course Course { get; set; }

        public string YearTB { get; set; }

        public bool PaymentCB { get; set; }
    }
}
