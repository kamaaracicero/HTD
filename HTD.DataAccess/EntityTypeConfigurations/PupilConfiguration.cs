﻿using HTD.DataEntities;
using System.Data.Entity.ModelConfiguration;

namespace HTD.DataAccess.EntityTypeConfigurations
{
    internal class PupilConfiguration : EntityTypeConfiguration<Pupil>
    {
        public PupilConfiguration()
        {
            ToTable(nameof(Pupil)).HasKey(p => p.Id);
            HasIndex(p => p.Id).IsUnique();
            Property(p => p.Name).IsRequired().HasMaxLength(500).HasColumnName(nameof(Pupil.Name));
            Property(p => p.BirthDay).IsRequired().HasColumnName(nameof(Pupil.BirthDay));
            Property(p => p.ParentName).IsRequired().HasMaxLength(500).HasColumnName(nameof(Pupil.ParentName));
            Property(p => p.ContactPhone).IsRequired().HasMaxLength(100).HasColumnName(nameof(Pupil.ContactPhone));
            Property(p => p.IsExpelled).IsRequired().HasColumnName(nameof(Pupil.IsExpelled));
            Property(p => p.Class).IsOptional().HasColumnName(nameof(Pupil.Class));
            Property(p => p.GUO).IsOptional().HasMaxLength(300).HasColumnName(nameof(Pupil.GUO));
        }
    }
}
