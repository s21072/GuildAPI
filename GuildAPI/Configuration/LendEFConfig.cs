using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class LendEFConfig : IEntityTypeConfiguration<Lend>
    {
        public void Configure(EntityTypeBuilder<Lend> builder)
        {
            builder.HasKey(p => p.LendID);
            builder.Property(p => p.From).IsRequired();
            builder.Property(p => p.To).IsRequired();
            builder.Property(p => p.HowMuch).IsRequired();
            builder.HasOne(p => p.Equipment).WithMany().HasForeignKey(p => p.EquipmentID);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.Pesel);
            builder.HasOne(p => p.Training).WithMany().HasForeignKey(p => p.TrainingID);
        }
    }
}
