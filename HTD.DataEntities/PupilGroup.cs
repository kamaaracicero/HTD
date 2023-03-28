namespace HTD.DataEntities
{
    public class PupilGroup : IDataEntity
    {
        public PupilGroup(int id, int pupilId, int groupId)
        {
            Id = id;
            PupilId = pupilId;
            GroupId = groupId;
        }

        public PupilGroup()
            : this(0, 0, 0)
        {
        }

        public int Id { get; set; }

        public int PupilId { get; set; }

        public int GroupId { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is PupilGroup))
                return;

            PupilGroup temp = obj as PupilGroup;
            if (temp != null)
            {
                PupilId = temp.PupilId;
                GroupId = temp.GroupId;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ PupilId.GetHashCode()
            ^ GroupId.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PupilGroup))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(PupilGroup)
            + ": " + PupilId.ToString() + " - " + GroupId.ToString();
    }
}
