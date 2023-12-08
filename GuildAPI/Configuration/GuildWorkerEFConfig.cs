using GuildAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Configuration
{
    public class GuildWorkerEFConfig : IEntityTypeConfiguration<GuildWorker>
    {
        public void Configure(EntityTypeBuilder<GuildWorker> builder)
        {
            builder.HasKey(p => p.Pesel);
            builder.HasOne(p => p.Person).WithMany().HasForeignKey(p => p.Pesel);
            builder.Property(p => p.Salary).IsRequired();
            builder.Property(p => p.WorkRole).IsRequired();
            builder.Property(p => p.Bonus);
            builder.Property(p => p.NymberOfCommissionsDone);
        }
    }
}
