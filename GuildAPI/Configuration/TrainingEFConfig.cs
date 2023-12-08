using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class TrainingEFConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(p => p.TrainingID);
            builder.Property(p => p.Theme).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Start).IsRequired();
            builder.Property(p => p.End).IsRequired();
            builder.Property(p => p.Attribute).IsRequired();
            builder.HasOne(p => p.Team).WithMany().HasForeignKey(p => p.TeamID);
        }
    }
}
