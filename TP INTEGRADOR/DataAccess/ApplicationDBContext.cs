﻿using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.DBSeeders;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Work> Works { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeder = new List<IEntitySeeder> {
                new UserSeeder(),
                new ProjectSeeder(),
                new ServiceSeeder(),
                new WorkSeeder()
            };

            seeder.ForEach(seed => seed.SeedDB(modelBuilder));


            base.OnModelCreating(modelBuilder);
        }
    }
}