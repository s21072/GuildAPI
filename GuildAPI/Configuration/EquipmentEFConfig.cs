using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class EquipmentEFConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(p => p.EquipmentID);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Rank).IsRequired();
            /*builder.HasDiscriminator<string>("EqType").HasValue<Offensive>(nameof(Offensive))
             .HasValue<Defensive>(nameof(Defensive)).HasValue<MixedEq>(nameof(MixedEq));
            builder.Property("EqType").HasMaxLength(20);*/
        }
    }
}
