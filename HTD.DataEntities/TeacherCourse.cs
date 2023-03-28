namespace HTD.DataEntities
{
    public class TeacherCourse : IDataEntity
    {
        public TeacherCourse(int id, int teacherId, int courseId)
        {
            Id = id;
            TeacherId = teacherId;
            CourseId = courseId;
        }

        public TeacherCourse()
            : this(0, 0, 0)
        {
        }

        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public void Update(object obj)
        {
            if (obj == null || !(obj is TeacherCourse))
                return;

            TeacherCourse temp = obj as TeacherCourse;
            if (temp != null)
            {
                TeacherId = temp.TeacherId;
                CourseId = temp.CourseId;
            }
        }

        public override int GetHashCode() => Id.GetHashCode()
            ^ TeacherId.GetHashCode()
            ^ CourseId.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is TeacherCourse))
                return false;

            return obj.GetHashCode() == GetHashCode();
        }

        public override string ToString() => nameof(TeacherCourse)
            + ": " + TeacherId.ToString() + " - " + CourseId.ToString();
    }
}
