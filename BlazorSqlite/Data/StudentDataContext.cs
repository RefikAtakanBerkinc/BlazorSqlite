﻿using Microsoft.EntityFrameworkCore;

namespace BlazorSqlite.Data
{
    public class StudentDataContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public StudentDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("StudentDB"));
        }

        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");

        }
    }
}
