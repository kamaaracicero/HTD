using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class CourseTypeConfiguration : EntityTypeConfiguration<CourseType>
    {
        public CourseTypeConfiguration()
        {
            ToTable(nameof(CourseType)).HasKey(t => t.Id);
            HasIndex(t => t.Id).IsUnique();
            Property(t => t.Name).IsRequired().HasMaxLength(int.MaxValue).HasColumnName(nameof(CourseType.Name));
        }
    }
}
