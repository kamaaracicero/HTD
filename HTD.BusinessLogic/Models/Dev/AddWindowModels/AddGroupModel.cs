namespace HTD.BusinessLogic.Models.Dev.AddWindowModels
{
    internal class AddGroupModel : IModel
    {
        public string CourseIdTB { get; set; }

        public string NameTB { get; set; }

        public string YearTB { get; set; }

        public bool IsActiveCB { get; set; }

        public bool PaymentCB { get; set; }
    }
}
