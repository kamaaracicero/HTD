namespace HTD.DataEntities
{
    public class Type : IDataEntity
    {
        public Type(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Type()
            : this(0, string.Empty)
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Type))
                return;

            Type temp = obj as Type;
            if (temp != null)
            {
                Name = temp.Name;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ Name.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Type))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Type) + ": " + Name;
    }
}
