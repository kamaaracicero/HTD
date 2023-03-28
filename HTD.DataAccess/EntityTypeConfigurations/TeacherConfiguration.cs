using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            ToTable(nameof(Teacher)).HasKey(t => t.Id);
            HasIndex(t => t.Id).IsUnique();
            Property(t => t.Name).IsRequired().HasMaxLength(500).HasColumnName(nameof(Teacher.Name));
            Property(t => t.Phone).IsRequired().HasMaxLength(100).HasColumnName(nameof(Teacher.Phone));
            Property(t => t.DateStartWork).IsRequired().HasColumnName(nameof(Teacher.DateStartWork));
            Property(t => t.DateEndWork).IsOptional().HasColumnName(nameof(Teacher.DateEndWork));
        }
    }
}
