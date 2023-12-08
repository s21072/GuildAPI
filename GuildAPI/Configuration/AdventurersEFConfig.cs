using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class AdventurersEFConfig : IEntityTypeConfiguration<Adventurers>
    {
        public void Configure(EntityTypeBuilder<Adventurers> builder)
        {
            builder.HasKey(p => p.Pesel);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.Pesel);
            builder.Property(p => p.Str).IsRequired().HasMaxLength(4);
            builder.Property(p => p.Spd).IsRequired().HasMaxLength(4);
            builder.Property(p => p.Int).IsRequired().HasMaxLength(4);
            builder.Property(p => p.Vit).IsRequired().HasMaxLength(4);
            builder.HasOne(p => p.Commission).WithMany().HasForeignKey(p => p.CommissionID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Team).WithMany().HasForeignKey(p => p.TeamID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
