using System;

namespace HTD.DataEntities
{
    public class Outcome : IDataEntity
    {
        public Outcome(int id, int groupId, int pupilId, string incomeOrderNumber, DateTime incomeDate, bool payment)
        {
            Id = id;
            GroupId = groupId;
            PupilId = pupilId;
            OrderNumber = incomeOrderNumber;
            Date = incomeDate;
        }

        public Outcome()
            : this(0, 0, 0, string.Empty, new DateTime(2000, 1, 1), false)
        {
        }

        public int Id { get; set; }

        public int GroupId { get; set; }

        public int PupilId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Outcome))
                return;

            Outcome temp = obj as Outcome;
            if (temp != null)
            {
                GroupId = temp.GroupId;
                PupilId = temp.PupilId;
                OrderNumber = temp.OrderNumber;
                Date = temp.Date;
            }
        }

        public override int GetHashCode() => Id
            ^ GroupId.GetHashCode()
            ^ PupilId.GetHashCode()
            ^ OrderNumber.GetHashCode()
            ^ Date.GetHashCode();

        public override string ToString() => "Outcome order: " + OrderNumber;
    }
}
