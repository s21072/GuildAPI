using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class AddressEFConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.AddressId);
            builder.Property(p => p.City).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Post).IsRequired().HasMaxLength(6);
            builder.Property(p => p.Number).IsRequired();
        }
    }
}
