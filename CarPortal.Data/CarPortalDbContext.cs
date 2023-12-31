﻿using CarPortal.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarPortal.Data
{
    public class CarPortalDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid> , Guid >
    {
        public CarPortalDbContext(DbContextOptions<CarPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Model> Models { get; set; } = null!;

        public DbSet<Make> Makes { get; set; } = null!;

        public DbSet<EngineType> EngineTypes { get; set; } = null!;

        public DbSet<Color> Colors { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Condition> Conditions { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Region> Regions { get; set; } = null!;

        public DbSet<Offer> Offers { get; set; } = null!;

        public DbSet<Image> Images { get; set; } = null!;

        public DbSet<Like> Likes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
	        builder.Entity<Like>()
		        .HasOne(l => l.User)
		        .WithMany(u => u.Likes)
		        .HasForeignKey(l => l.UserId)
		        .OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Like>()
		        .HasOne(l => l.Offer)
		        .WithMany(o => o.Likes)
		        .HasForeignKey(l => l.OfferId)
		        .OnDelete(DeleteBehavior.Cascade);

			Assembly configAssembly = Assembly.GetAssembly(typeof(CarPortalDbContext)) ??
	                                  Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}