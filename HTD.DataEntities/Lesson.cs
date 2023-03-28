﻿using System;

namespace HTD.DataEntities
{
    public class Lesson : IDataEntity
    {
        public Lesson(int id, int groupId, int teacherId, DateTime begin, DateTime end, int place, DateTime date)
        {
            Id = id;
            GroupId = groupId;
            TeacherId = teacherId;
            Begin = begin;
            End = end;
            Place = place;
            Date = date;
        }

        public Lesson()
            : this(0, 0, 0, new DateTime(2000, 1, 1), new DateTime(2000, 1, 1), 0, new DateTime(2000, 1, 1))
        {
        }

        public int Id { get; set; }

        public int GroupId { get; set; }

        public int TeacherId { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public int Place { get; set; }

        public DateTime Date { get; set; }

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
                Date = temp.Date;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ GroupId.GetHashCode()
            ^ TeacherId.GetHashCode()
            ^ Begin.GetHashCode()
            ^ End.GetHashCode()
            ^ Place.GetHashCode()
            ^ Date.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Lesson))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(Lesson)
            + ": " + Begin.ToShortTimeString()
            + "-" + End.ToShortTimeString();
    }
}
