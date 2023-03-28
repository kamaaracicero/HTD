using System;

namespace HTD.DataEntities
{
    public class Pupil : IDataEntity
    {
        public Pupil(int id, string name, DateTime birthDay, string parentName, string contactPhone)
        {
            Id = id;
            Name = name;
            BirthDay = birthDay;
            ParentName = parentName;
            ContactPhone = contactPhone;
        }

        public Pupil()
            : this(0, string.Empty, new DateTime(2000, 1, 1), string.Empty, string.Empty)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public string ParentName { get; set; }

        public string ContactPhone { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Pupil))
                return;

            Pupil temp = obj as Pupil;
            if (temp != null)
            {
                Name = temp.Name;
                BirthDay = temp.BirthDay;
                ParentName = temp.ParentName;
                ContactPhone = temp.ContactPhone;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ Name.GetHashCode()
            ^ BirthDay.GetHashCode()
            ^ ParentName.GetHashCode()
            ^ ContactPhone.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Pupil))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Pupil) + ": " + Name;
    }
}
