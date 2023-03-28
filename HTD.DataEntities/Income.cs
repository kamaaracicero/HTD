using System;

namespace HTD.DataEntities
{
    public class Income : IDataEntity
    {
        public Income(int id, int groupId, int pupilId, string incomeOrderNumber, DateTime incomeDate, bool payment)
        {
            Id = id;
            GroupId = groupId;
            PupilId = pupilId;
            OrderNumber = incomeOrderNumber;
            Date = incomeDate;
            Payment = payment;
        }

        public Income()
            : this(0, 0, 0, string.Empty, new DateTime(2000, 1, 1), false)
        {
        }

        public int Id { get; set; }

        public int GroupId { get; set; }

        public int PupilId { get; set; }

        public string OrderNumber { get; set; }

        public DateTime Date { get; set; }

        public bool Payment { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Income))
                return;

            Income temp = obj as Income;
            if (temp != null)
            {
                GroupId = temp.GroupId;
                PupilId = temp.PupilId;
                OrderNumber = temp.OrderNumber;
                Date = temp.Date;
                Payment = temp.Payment;
            }
        }

        public override int GetHashCode() => Id
            ^ GroupId.GetHashCode()
            ^ PupilId.GetHashCode()
            ^ OrderNumber.GetHashCode()
            ^ Date.GetHashCode()
            ^ Payment.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Income))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => "Income order: " + OrderNumber;
    }
}
