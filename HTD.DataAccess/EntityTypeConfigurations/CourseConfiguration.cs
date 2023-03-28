using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable(nameof(Course)).HasKey(c => c.Id);
            HasIndex(c => c.Id).IsUnique();
            Property(c => c.Name).IsRequired().HasMaxLength(500).HasColumnName(nameof(Course.Name));
            Property(c => c.TypeId).IsRequired().HasColumnName(nameof(Course.TypeId));
            Property(c => c.IsActive).IsRequired().HasColumnName(nameof(Course.IsActive));
        }
    }
}
