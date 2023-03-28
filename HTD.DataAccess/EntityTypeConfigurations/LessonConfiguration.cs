using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class LessonConfiguration : EntityTypeConfiguration<Lesson>
    {
        public LessonConfiguration()
        {
            ToTable(nameof(Lesson)).HasKey(l => l.Id);
            HasIndex(l => l.Id).IsUnique();
            Property(l => l.GroupId).IsRequired().HasColumnName(nameof(Lesson.GroupId));
            Property(l => l.TeacherId).IsRequired().HasColumnName(nameof(Lesson.TeacherId));
            Property(l => l.Begin).IsRequired().HasColumnName(nameof(Lesson.Begin));
            Property(l => l.End).IsRequired().HasColumnName(nameof(Lesson.End));
            Property(l => l.Place).IsRequired().HasColumnName(nameof(Lesson.Place));
            Property(l => l.Date).IsRequired().HasColumnName(nameof(Lesson.Date));
        }
    }
}
