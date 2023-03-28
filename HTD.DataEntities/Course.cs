namespace HTD.DataEntities
{
    public class Course : IDataEntity
    {
        public Course(int id, string name, int typeId, bool isActive)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
            IsActive = isActive;
        }

        public Course()
            : this(0, string.Empty, 0, false)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public bool IsActive { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Course))
                return;

            Course temp = obj as Course;
            if (temp != null)
            {
                Name = temp.Name;
                TypeId = temp.TypeId;
                IsActive = temp.IsActive;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ Name.GetHashCode()
            ^ TypeId.GetHashCode()
            ^ IsActive.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null  || !(obj is Course))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Course) + ": " + Name;
    }
}
