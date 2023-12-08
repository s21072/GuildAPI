using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class MixedEqEFConfig : IEntityTypeConfiguration<MixedEq>
    {
        public void Configure(EntityTypeBuilder<MixedEq> builder)
        {
            builder.Property(p => p.Def).IsRequired().HasColumnName("Def");
            builder.Property(p => p.Dmg).IsRequired().HasColumnName("Dmg");
        }
    }
}
