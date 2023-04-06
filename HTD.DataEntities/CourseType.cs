namespace HTD.DataEntities
{
    public class CourseType : IDataEntity
    {
        public CourseType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public CourseType()
            : this(0, string.Empty)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is CourseType))
                return;

            CourseType temp = obj as CourseType;
            if (temp != null)
            {
                Name = temp.Name;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ Name.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CourseType))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(CourseType) + ": " + Name;
    }
}
