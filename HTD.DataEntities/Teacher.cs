using System;

namespace HTD.DataEntities
{
    public class Teacher : IDataEntity
    {
        public Teacher(int id, string name, string phone, DateTime dateStartWork, DateTime? dateEndWork)
        {
            Id = id;
            Name = name;
            Phone = phone;
            DateStartWork = dateStartWork;
            DateEndWork = dateEndWork;
        }

        public Teacher()
            : this(0, string.Empty, string.Empty, new DateTime(2020, 1, 1), null)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime DateStartWork { get; set; }

        public DateTime? DateEndWork { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Teacher))
                return;

            Teacher temp = obj as Teacher;
            if (temp != null)
            {
                Name = temp.Name;
                Phone = temp.Phone;
                DateStartWork = temp.DateStartWork;
                DateEndWork = temp.DateEndWork;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ Name.GetHashCode()
            ^ Phone.GetHashCode()
            ^ DateStartWork.GetHashCode()
            ^ DateEndWork.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Teacher))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Teacher) + ": " + Name;
    }
}
