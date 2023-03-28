namespace HTD.BusinessLogic.Models.Dev.AddWindowModels
{
    public class AddIncomeModel : IModel
    {
        public string GroupIdTB { get; set; }

        public string PupilIdTB { get; set; }

        public string OrderNumberTB { get; set; }

        public string DateDP { get; set; }

        public bool PaymentCB { get; set; }
    }
}
