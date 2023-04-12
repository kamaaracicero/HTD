using System;

namespace HTD.DataEntities
{
    public class Lesson : IDataEntity
    {
        public Lesson(int id, int groupId, int teacherId, TimeSpan begin, TimeSpan end, int place, int date)
        {
            Id = id;
            GroupId = groupId;
            TeacherId = teacherId;
            Begin = begin;
            End = end;
            Place = place;
            Day = date;
        }

        public Lesson()
            : this(0, 0, 0, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), 0, 0)
        {
        }

        public int Id { get; set; }

        public int GroupId { get; set; }

        public int TeacherId { get; set; }

        public TimeSpan Begin { get; set; }

        public TimeSpan End { get; set; }

        public int Place { get; set; }

        public int Day { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is Lesson))
                return;

            Lesson temp = obj as Lesson;
            if (temp != null)
            {
                GroupId = temp.GroupId;
                TeacherId = temp.TeacherId;
                Begin = temp.Begin;
                End = temp.End;
                Place = temp.Place;
                Day = temp.Day;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ GroupId.GetHashCode()
            ^ TeacherId.GetHashCode()
            ^ Begin.GetHashCode()
            ^ End.GetHashCode()
            ^ Place.GetHashCode()
            ^ Day.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Lesson))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Lesson)
            + ": " + Begin.ToString()
            + "-" + End.ToString();
    }
}
