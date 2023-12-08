using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class OffensiveEFConfig : IEntityTypeConfiguration<Offensive>
    {
        public void Configure(EntityTypeBuilder<Offensive> builder)
        {
            builder.Property(p => p.Dmg).IsRequired().HasColumnName("Dmg");
        }
    }
}
