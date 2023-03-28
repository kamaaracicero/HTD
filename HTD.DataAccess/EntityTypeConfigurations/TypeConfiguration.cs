using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class TypeConfiguration : EntityTypeConfiguration<Type>
    {
        public TypeConfiguration()
        {
            ToTable(nameof(Type)).HasKey(t => t.Id);
            HasIndex(t => t.Id).IsUnique();
            Property(t => t.Name).IsRequired().HasMaxLength(int.MaxValue).HasColumnName(nameof(Type.Name));
        }
    }
}
