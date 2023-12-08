using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class CEOsEFConfig : IEntityTypeConfiguration<CEO>
    {
        public void Configure(EntityTypeBuilder<CEO> builder)
        {
            builder.HasKey(p => p.Pesel);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.Pesel);
        }
    }
}
