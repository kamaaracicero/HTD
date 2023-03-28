using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class OutcomeConfiguration : EntityTypeConfiguration<Outcome>
    {
        public OutcomeConfiguration()
        {
            ToTable(nameof(Outcome)).HasKey(o => o.Id);
            HasIndex(o => o.Id).IsUnique();
            Property(o => o.GroupId).IsRequired().HasColumnName(nameof(Outcome.GroupId));
            Property(o => o.PupilId).IsRequired().HasColumnName(nameof(Outcome.PupilId));
            Property(o => o.OrderNumber).IsRequired().HasMaxLength(int.MaxValue).HasColumnName(nameof(Outcome.OrderNumber));
            Property(o => o.Date).IsRequired().HasColumnName(nameof(Outcome.Date));
        }
    }
}
