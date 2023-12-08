using System;
using GuildAPI.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GuildAPI.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Adventurers> Adventurers { get; set; }
        public DbSet<GuildWorker> GuildWorkers { get; set; }
        public DbSet<CEO> CEOs { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fissure> Fissures { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Defensive> Defensive { get; set; }
        public DbSet<Offensive> Offensive { get; set; }
        public DbSet<MixedEq> MixedEq { get; set; }

        protected MyDBContext(){}

        public MyDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AddressEFConfig());
            modelBuilder.ApplyConfiguration(new AdventurersEFConfig());
            modelBuilder.ApplyConfiguration(new CEOsEFConfig());
            modelBuilder.ApplyConfiguration(new CommissionEFConfig());
            modelBuilder.ApplyConfiguration(new DefensiveEFConfig());
            modelBuilder.ApplyConfiguration(new EquipmentEFConfig());
            modelBuilder.ApplyConfiguration(new FissureEFConfig());
            modelBuilder.ApplyConfiguration(new GuildWorkerEFConfig());
            modelBuilder.ApplyConfiguration(new LendEFConfig());
            modelBuilder.ApplyConfiguration(new MixedEqEFConfig());
            modelBuilder.ApplyConfiguration(new OffensiveEFConfig());
            modelBuilder.ApplyConfiguration(new PersonEFConfig());
            modelBuilder.ApplyConfiguration(new TeamEFConfig());
            modelBuilder.ApplyConfiguration(new TrainingEFConfig());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=NewGuildDB;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
