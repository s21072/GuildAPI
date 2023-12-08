using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class FissureEFConfig : IEntityTypeConfiguration<Fissure>
    {
        public void Configure(EntityTypeBuilder<Fissure> builder)
        {
            builder.HasKey(p => p.FissureID);
            builder.Property(p => p.NSLoc).IsRequired();
            builder.Property(p => p.WELoc).IsRequired();
            builder.Property(p => p.OSLev).IsRequired();
            builder.Property(p => p.Rank);
            builder.Property(p => p.FissureTypes).IsRequired();
            builder.Property(p => p.FindDate).IsRequired();
            builder.Property(p => p.CloseDate);
            
        }
    }
}
