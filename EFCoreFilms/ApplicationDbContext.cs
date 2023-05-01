﻿using EFCoreFilms.entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gender>().HasKey(prop => prop.Identifier);
            modelBuilder.Entity<Gender>().Property(prop => prop.Name).HasMaxLength(150).IsRequired();
        }

        public DbSet<Gender> Genders { get; set; }
    }
}
