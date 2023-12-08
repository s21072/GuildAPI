using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class DefensiveEFConfig : IEntityTypeConfiguration<Defensive>
    {
        public void Configure(EntityTypeBuilder<Defensive> builder)
        {
            builder.Property(p => p.Def).IsRequired().HasColumnName("Def");
        }
    }
}
