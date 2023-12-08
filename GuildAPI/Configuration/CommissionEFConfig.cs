using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class CommissionEFConfig : IEntityTypeConfiguration<Commission>
    {
        public void Configure(EntityTypeBuilder<Commission> builder)
        {
            builder.HasKey(p => p.CommissionID);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(20);
            builder.Property(p => p.CommissionType).IsRequired();
            builder.Property(p => p.MinRank).IsRequired();
            builder.Property(p => p.CreateTime).IsRequired();
            builder.Property(p => p.AcceptTime);
            builder.Property(p => p.FinishTime);
            builder.Property(p => p.Reword).IsRequired();
            builder.Property(p => p.Rates).IsRequired().HasMaxLength(2).HasDefaultValue(1);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);
            builder.HasOne(p => p.Fissure).WithMany().HasForeignKey(p => p.FissureID);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.Pesel);
            builder.HasOne(p => p.Team).WithMany().HasForeignKey(p => p.TeamID);
        }
    }
}
