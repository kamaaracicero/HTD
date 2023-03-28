using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class TeacherCourseConfiguration : EntityTypeConfiguration<TeacherCourse>
    {
        public TeacherCourseConfiguration()
        {
            ToTable(nameof(TeacherCourse)).HasKey(t => t.Id);
            HasIndex(t => t.Id).IsUnique();
            Property(t => t.TeacherId).IsRequired().HasColumnName(nameof(TeacherCourse.TeacherId));
            Property(t => t.CourseId).IsRequired().HasColumnName(nameof(TeacherCourse.CourseId));
        }
    }
}
