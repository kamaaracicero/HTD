using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class IncomeConfiguration : EntityTypeConfiguration<Income>
    {
        public IncomeConfiguration()
        {
            ToTable(nameof(Income)).HasKey(i => i.Id);
            HasIndex(i => i.Id).IsUnique();
            Property(i => i.GroupId).IsRequired().HasColumnName(nameof(Income.GroupId));
            Property(i => i.PupilId).IsRequired().HasColumnName(nameof(Income.PupilId));
            Property(i => i.OrderNumber).IsRequired().HasMaxLength(int.MaxValue).HasColumnName(nameof(Income.OrderNumber));
            Property(i => i.Date).IsRequired().HasColumnName(nameof(Income.Date));
            Property(i => i.Payment).IsRequired().HasColumnName(nameof(Income.Payment));
        }
    }
}
