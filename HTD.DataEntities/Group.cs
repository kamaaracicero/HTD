namespace HTD.DataEntities
{
    public class Group : IDataEntity
    {
        public Group(int id, int courseId, string name, int year, bool isActive, bool payment)
        {
            Id = id;
            CourseId = courseId;
            Name = name;
            Year = year;
            IsActive = isActive;
            Payment = payment;
        }

        public Group()
            : this(0, 0, string.Empty, 0, false, false)
        {
        }

        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public bool IsActive { get; set; }

        public bool Payment { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Group))
                return;

            Group temp = obj as Group;
            if (temp != null)
            {
                CourseId = temp.CourseId;
                Name = temp.Name;
                Year = temp.Year;
                IsActive = temp.IsActive;
                Payment = temp.Payment;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ CourseId.GetHashCode()
            ^ Name.GetHashCode()
            ^ Year.GetHashCode()
            ^ IsActive.GetHashCode()
            ^ Payment.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Group))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Group) + ": " + Name;
    }
}
