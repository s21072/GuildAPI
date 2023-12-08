using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class PersonEFConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Pesel);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Birth).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.Property(p => p.IsAdventurer).IsRequired();
            builder.Property(p => p.Rank);
            builder.Property(p => p.Start).IsRequired();
            builder.Property(p => p.Retirement);
            builder.HasOne(p => p.Address).WithMany().HasForeignKey(p => p.AddressId);
        }
    }
}
