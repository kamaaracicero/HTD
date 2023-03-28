using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class PupilGroupConfiguration : EntityTypeConfiguration<PupilGroup>
    {
        public PupilGroupConfiguration()
        {
            ToTable(nameof(PupilGroup)).HasKey(p => p.Id);
            HasIndex(p => p.Id).IsUnique();
            Property(p => p.PupilId).IsRequired().HasColumnName(nameof(PupilGroup.PupilId));
            Property(p => p.GroupId).IsRequired().HasColumnName(nameof(PupilGroup.GroupId));
        }
    }
}
