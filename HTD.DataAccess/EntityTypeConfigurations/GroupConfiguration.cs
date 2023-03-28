using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable(nameof(Group)).HasKey(g => g.Id);
            HasIndex(g => g.Id).IsUnique();
            Property(g => g.CourseId).IsRequired().HasColumnName(nameof(Group.CourseId));
            Property(g => g.Name).IsRequired().HasMaxLength(1000).HasColumnName(nameof(Group.Name));
            Property(g => g.Year).IsRequired().HasColumnName(nameof(Group.Year));
            Property(g => g.IsActive).IsRequired().HasColumnName(nameof(Group.IsActive));
            Property(g => g.Payment).IsRequired().HasColumnName(nameof(Group.Payment));
        }
    }
}
